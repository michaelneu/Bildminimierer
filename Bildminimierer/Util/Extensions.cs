using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;

namespace Bildminimierer.Util
{
    public static class Extensions
    {
        public static List<string> WalkRecursive(this DirectoryInfo info)
        {
            List<string> elements = new List<string>();

            foreach (var item in info.GetDirectories())
            {
                List<string> subitems = item.WalkRecursive();
                elements.AddRange(subitems);
            }

            foreach (var item in info.GetFiles())
            {
                if (item.IsImage())
                {
                    elements.Add(item.FullName);
                }
            }

            return elements;
        }

        public static DirectoryInfo GetNextFreeName(this DirectoryInfo info)
        {
            List<int> numbers = new List<int>();

            string pattern = string.Format(@"{0}\s*(\d+)*", info.Name);
            var nameMatch = new Regex(pattern, RegexOptions.Compiled);

            List<string> items = new List<string>();
            DirectoryInfo parent = info.Parent;
            items.AddRange(parent.GetDirectories().Select(x => x.Name));
            items.AddRange(parent.GetFiles().Select(x => x.Name));

            foreach (var item in items)
            {
                var match = nameMatch.Match(item);

                if (match.Success && match.Groups[1].Value.Length > 0)
                {
                    int i = int.Parse(match.Groups[1].Value);
                    numbers.Add(i);
                }
            }

            int max = 0;
            if (numbers.Count > 0)
            {
                max = numbers.Max();
            }

            string dirname = string.Format("{0} {1}", info.Name, max + 1);
            dirname = Path.Combine(parent.FullName, dirname);

            return new DirectoryInfo(dirname);
        }

        public static void ShowInExplorer(this DirectoryInfo info)
        {
            Process explorer = new Process();
            explorer.StartInfo = new ProcessStartInfo("explorer.exe", info.FullName);
            explorer.Start();
        }


        private static string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".gif", ".tif" };
        public static bool IsImage(this FileInfo info)
        {
            return imageExtensions.Contains(info.Extension.ToLower());
        }
    }
}

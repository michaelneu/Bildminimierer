using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Bildminimierer.Util;

namespace Bildminimierer
{
    public partial class Form1 : Form
    {
        private volatile bool debug;
        private BackgroundWorker resizer;

        public Form1()
        {
            InitializeComponent();

            resizer = new BackgroundWorker();
            resizer.WorkerReportsProgress = true;
            resizer.WorkerSupportsCancellation = true;

            resizer.DoWork += (s, e) =>
                {
                    object[] args = (object[])e.Argument;

                    string folder = (string)args[0];
                    DirectoryInfo directory = new DirectoryInfo(folder);


                    if (debug)
                    {
                        MessageBox.Show("Directory: " + directory.FullName);
                    }


                    int filesize = (int)args[1];

                    if (directory.Exists)
                    {
                        resizer.ReportProgress(0);

                        // create the same directory, just append a number
                        DirectoryInfo destinationDirectory = directory.GetNextFreeName();
                        e.Result = destinationDirectory;

                        List<string> elements = directory.WalkRecursive();

                        
                        if (debug)
                        {
                            MessageBox.Show("Paths: \n\n" + string.Join("\n", elements.ToArray()));
                        }

                        
                        int i = 0,
                            count = elements.Count;
                        double percentage = 0,
                            percentageOneFile = 100f / count;

                        while (!e.Cancel && i < count)
                        {
                            string element = elements[i];

                            // get the destination path of the file
                            string destination = element.Replace(folder, destinationDirectory.FullName);
                            FileInfo destinationFileInfo = new FileInfo(destination);

                            // create the destination directory
                            if (!destinationFileInfo.Directory.Exists)
                            {
                                
                                
                                if (debug)
                                {
                                    MessageBox.Show("Directory created: \n" + destinationFileInfo.Directory.FullName);
                                }


                                destinationFileInfo.Directory.Create();
                            }

                            // resize the image
                            FileInfo sourceFileInfo = new FileInfo(element);
                            Image.Resize(sourceFileInfo, destinationFileInfo, filesize);


                            if (debug)
                            {
                                MessageBox.Show("Image resized: \n" + sourceFileInfo.FullName);
                            }


                            i++;
                            percentage += percentageOneFile;

                            resizer.ReportProgress((int)Math.Round(percentage));
                        }
                    }
                };

            resizer.ProgressChanged += (s, a) =>
                {
                    progress.Value = a.ProgressPercentage;
                };

            resizer.RunWorkerCompleted += (s, a) =>
                {
                    tb_filesize.Enabled = true;
                    btn_selectFolder.Enabled = true;
                    btn_startCancel.Text = "Start";

                    if (!a.Cancelled && a.Error == null)
                    {
                        DirectoryInfo result = (DirectoryInfo)a.Result;
                        result.ShowInExplorer();
                    } 
                    else if (a.Error != null)
                    {
                        MessageBox.Show(a.Error.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
        }


        private void btn_startCancel_Click(object sender, EventArgs e)
        {
            if (resizer.IsBusy)
            {
                resizer.CancelAsync();
            }
            else
            {
                tb_filesize.Enabled = false;
                btn_selectFolder.Enabled = false;
                btn_startCancel.Text = "Abbrechen";

                object[] args = { txt_folder.Text, tb_filesize.Value };
                resizer.RunWorkerAsync(args);
            }
        }

        private void tb_filesize_Scroll(object sender, EventArgs e)
        {
            lbl_filesizePreview.Text = string.Format("~ {0} kB", tb_filesize.Value);
        }

        private void btn_selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dia = new FolderBrowserDialog();
            
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_folder.Text = dia.SelectedPath;
                btn_startCancel.Enabled = true;
            }
        }

        #region Toggle debugging by clicking the "Folder"-Label n - 1 times
        private const int amountClicksForDebug = 10,
                          millisBetweenClicks  = 750;
        private DateTime lastClick;
        private int currentClickCount;
        private void ToggleDebug(object sender, MouseEventArgs e)
        {
            DateTime now = DateTime.Now;

            if (lastClick.Year != 1)
            {
                TimeSpan diffBetweenClicks = now.Subtract(lastClick);
                if (diffBetweenClicks.TotalMilliseconds > millisBetweenClicks)
                {
                    currentClickCount = 0;
                }
            }

            lastClick = now;
            currentClickCount++;

            if (currentClickCount == amountClicksForDebug)
            {
                const string debugPostfix = " [Debug]";

                if (debug)
                {
                    Text = Text.Substring(0, Text.LastIndexOf(debugPostfix));
                }
                else
                {
                    Text += debugPostfix;
                }

                debug = !debug;
                currentClickCount = 0;
            }
        }
        #endregion
    }
}

namespace Bildminimierer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_selectFolder = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.btn_startCancel = new System.Windows.Forms.Button();
            this.tb_filesize = new System.Windows.Forms.TrackBar();
            this.lbl_filesizePreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_filesize)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_folder
            // 
            this.txt_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_folder.Enabled = false;
            this.txt_folder.Location = new System.Drawing.Point(60, 12);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(285, 20);
            this.txt_folder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ordner:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToggleDebug);
            // 
            // btn_selectFolder
            // 
            this.btn_selectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectFolder.Location = new System.Drawing.Point(351, 10);
            this.btn_selectFolder.Name = "btn_selectFolder";
            this.btn_selectFolder.Size = new System.Drawing.Size(57, 23);
            this.btn_selectFolder.TabIndex = 2;
            this.btn_selectFolder.Text = "...";
            this.btn_selectFolder.UseVisualStyleBackColor = true;
            this.btn_selectFolder.Click += new System.EventHandler(this.btn_selectFolder_Click);
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(15, 95);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(305, 55);
            this.progress.Step = 1;
            this.progress.TabIndex = 3;
            // 
            // btn_startCancel
            // 
            this.btn_startCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_startCancel.Enabled = false;
            this.btn_startCancel.Location = new System.Drawing.Point(326, 95);
            this.btn_startCancel.Name = "btn_startCancel";
            this.btn_startCancel.Size = new System.Drawing.Size(82, 55);
            this.btn_startCancel.TabIndex = 4;
            this.btn_startCancel.Text = "Start";
            this.btn_startCancel.UseVisualStyleBackColor = true;
            this.btn_startCancel.Click += new System.EventHandler(this.btn_startCancel_Click);
            // 
            // tb_filesize
            // 
            this.tb_filesize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_filesize.Location = new System.Drawing.Point(85, 44);
            this.tb_filesize.Maximum = 3096;
            this.tb_filesize.Minimum = 10;
            this.tb_filesize.Name = "tb_filesize";
            this.tb_filesize.Size = new System.Drawing.Size(323, 45);
            this.tb_filesize.TabIndex = 5;
            this.tb_filesize.Value = 512;
            this.tb_filesize.Scroll += new System.EventHandler(this.tb_filesize_Scroll);
            // 
            // lbl_filesizePreview
            // 
            this.lbl_filesizePreview.AutoSize = true;
            this.lbl_filesizePreview.Location = new System.Drawing.Point(12, 62);
            this.lbl_filesizePreview.Name = "lbl_filesizePreview";
            this.lbl_filesizePreview.Size = new System.Drawing.Size(51, 13);
            this.lbl_filesizePreview.TabIndex = 6;
            this.lbl_filesizePreview.Text = "~ 512 kB";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 164);
            this.Controls.Add(this.lbl_filesizePreview);
            this.Controls.Add(this.tb_filesize);
            this.Controls.Add(this.btn_startCancel);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.btn_selectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_folder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bildminimierer";
            ((System.ComponentModel.ISupportInitialize)(this.tb_filesize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_selectFolder;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button btn_startCancel;
        private System.Windows.Forms.TrackBar tb_filesize;
        private System.Windows.Forms.Label lbl_filesizePreview;
    }
}


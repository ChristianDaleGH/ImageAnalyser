namespace ImageAnalyser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IR_Image = new System.Windows.Forms.PictureBox();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Label_ImageSZ = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Button_Folder = new System.Windows.Forms.Button();
            this.Button_File = new System.Windows.Forms.Button();
            this.Button_Read_Logs = new System.Windows.Forms.Button();
            this.FolderLoadingBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.IR_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // IR_Image
            // 
            this.IR_Image.Dock = System.Windows.Forms.DockStyle.Right;
            this.IR_Image.Location = new System.Drawing.Point(184, 0);
            this.IR_Image.Name = "IR_Image";
            this.IR_Image.Size = new System.Drawing.Size(1220, 711);
            this.IR_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IR_Image.TabIndex = 0;
            this.IR_Image.TabStop = false;
            // 
            // Button_Load
            // 
            this.Button_Load.Location = new System.Drawing.Point(12, 12);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(152, 31);
            this.Button_Load.TabIndex = 1;
            this.Button_Load.Text = "Load Image";
            this.Button_Load.UseVisualStyleBackColor = true;
            this.Button_Load.Click += new System.EventHandler(this.ImageLoad_Click);
            // 
            // Label_ImageSZ
            // 
            this.Label_ImageSZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_ImageSZ.AutoSize = true;
            this.Label_ImageSZ.Location = new System.Drawing.Point(62, 66);
            this.Label_ImageSZ.Name = "Label_ImageSZ";
            this.Label_ImageSZ.Size = new System.Drawing.Size(53, 13);
            this.Label_ImageSZ.TabIndex = 2;
            this.Label_ImageSZ.Text = "x= ?, y= ?";
            this.Label_ImageSZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_ImageSZ.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(178, 711);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Button_Folder
            // 
            this.Button_Folder.Location = new System.Drawing.Point(12, 97);
            this.Button_Folder.Name = "Button_Folder";
            this.Button_Folder.Size = new System.Drawing.Size(152, 31);
            this.Button_Folder.TabIndex = 4;
            this.Button_Folder.Text = "Load Log Folder";
            this.Button_Folder.UseVisualStyleBackColor = true;
            this.Button_Folder.Visible = false;
            this.Button_Folder.Click += new System.EventHandler(this.LoadFolder_Click);
            // 
            // Button_File
            // 
            this.Button_File.Location = new System.Drawing.Point(12, 134);
            this.Button_File.Name = "Button_File";
            this.Button_File.Size = new System.Drawing.Size(152, 31);
            this.Button_File.TabIndex = 5;
            this.Button_File.Text = "Load Log File";
            this.Button_File.UseVisualStyleBackColor = true;
            this.Button_File.Visible = false;
            this.Button_File.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // Button_Read_Logs
            // 
            this.Button_Read_Logs.Location = new System.Drawing.Point(12, 49);
            this.Button_Read_Logs.Name = "Button_Read_Logs";
            this.Button_Read_Logs.Size = new System.Drawing.Size(152, 31);
            this.Button_Read_Logs.TabIndex = 6;
            this.Button_Read_Logs.Text = "Read Logs";
            this.Button_Read_Logs.UseVisualStyleBackColor = true;
            this.Button_Read_Logs.Click += new System.EventHandler(this.Button_Read_Logs_Click);
            // 
            // FolderLoadingBar
            // 
            this.FolderLoadingBar.Location = new System.Drawing.Point(15, 188);
            this.FolderLoadingBar.Maximum = 10000;
            this.FolderLoadingBar.Name = "FolderLoadingBar";
            this.FolderLoadingBar.Size = new System.Drawing.Size(149, 23);
            this.FolderLoadingBar.Step = 1;
            this.FolderLoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.FolderLoadingBar.TabIndex = 7;
            this.FolderLoadingBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1404, 711);
            this.Controls.Add(this.FolderLoadingBar);
            this.Controls.Add(this.Button_Read_Logs);
            this.Controls.Add(this.Button_File);
            this.Controls.Add(this.Button_Folder);
            this.Controls.Add(this.Label_ImageSZ);
            this.Controls.Add(this.Button_Load);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.IR_Image);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.IR_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IR_Image;
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.Label Label_ImageSZ;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button Button_Folder;
        private System.Windows.Forms.Button Button_File;
        private System.Windows.Forms.Button Button_Read_Logs;
        private System.Windows.Forms.ProgressBar FolderLoadingBar;
    }
}


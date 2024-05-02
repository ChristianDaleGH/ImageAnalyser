using CsvHelper;
using ImageAnalyser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ImageAnalyser.Utilities;

namespace ImageAnalyser
{
    public partial class MainForm : Form
    {
        public Match fire;
        public Bitmap image;
        internal List<FireInfo> record = new List<FireInfo>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ImageLoad_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog
            {
                // image filters
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Load and display the image
                Image image = new Bitmap(open.FileName);
                Size imagesize = image.Size;

                // Get image size
                IR_Image.Image = new Bitmap(open.FileName);
                Label_ImageSZ.Visible = true;
                Label_ImageSZ.Text = "x= " + imagesize.Width + ", y= " + imagesize.Height;

                // Store file-related variables
                Variables.FileName = open.SafeFileName;
                Text = open.FileName;

                // Extract IP information from file name
                Match IP = Regex.Match(Variables.FileName, Pattern.IPAddressPattern);
                Variables.IP = IP.Value;
                Variables.Oct1 = IP.Groups["Oct1"].Value;
                Variables.Oct2 = IP.Groups["Oct2"].Value;
                Variables.Oct3 = IP.Groups["Oct3"].Value;
                Variables.Oct4 = IP.Groups["Oct4"].Value;
                MessageBox.Show(Variables.IP);

                // Update visibility of buttons
                Button_File.Visible = true;
                Button_Folder.Visible = true;
                Button_Read_Logs.Visible = false;

            }
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Log Files (C0*.txt)|C0*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageProcessLogFile(openFileDialog.FileName);
                }
            }
        }
        private void ImageProcessLogFile(string filePath)
        {
            string alarmPattern = @"(?<Time>[0-9]+-[0-9]+-[0-9]+ [0-9]+:[0-9]+:[0-9]+\.[0-9]+) .*" +
                                  Variables.Oct1 + @"\." + Variables.Oct2 + @"\." + Variables.Oct3 + @"\." + Variables.Oct4 +
                                  @" .*(?<AlarmNum>[0-9+])[\s]+" +
                                  @".*x = -?(?<X0>[0-9\.]+)[\s]+\.y = -?(?<Y0>[0-9\.]+)\s+\.sz = (?<Size0>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X1>[0-9\.]+)[\s]+\.y = -?(?<Y1>[0-9\.]+)\s+\.sz = (?<Size1>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X2>[0-9\.]+)[\s]+\.y = -?(?<Y2>[0-9\.]+)\s+\.sz = (?<Size2>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X3>[0-9\.]+)[\s]+\.y = -?(?<Y3>[0-9\.]+)\s+\.sz = (?<Size3>[0-9]+)";

            // Search for matches in the alarm log
            foreach (Match fire in Regex.Matches(File.ReadAllText(filePath), alarmPattern, RegexOptions.Multiline))
            {
                LogSearch(fire);
            }
        }
        private void LoadFolder_Click(object sender, EventArgs e)
        {
            string selectedPath = SelectFolder();
            if (selectedPath != null)
            {
                string[] files = Directory.GetFiles(selectedPath);
                int totalFiles = files.Length;
                int currentProgress = 0;
                DisplayProgressBar(currentProgress, totalFiles);
                FolderLoadingBar.Visible = true;
                string[] FileEntries = Directory.GetFiles(selectedPath, "C*.txt");
                foreach (string FileEntry in FileEntries)
                {
                    ImageProcessLogFile(FileEntry);
                    currentProgress++;
                    FolderLoadingBar.Value = DisplayProgressBar(currentProgress, totalFiles);
                }

                MessageBox.Show("Complete");
            }
        }

        private string SelectFolder()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    return folderDialog.SelectedPath;
                }
            }
            return null;
        }
        internal void FireWrite(Match Fire, List<FireInfo> record)
        {
            var fireInfo = new FireInfo
            {
                Time = Fire.Groups["Time"].Value,
                ActivationType = "fire",
                IP = Fire.Groups["IP"].Value,
                AlarmNum = Fire.Groups["AlarmNum"].Value,
                X0 = Fire.Groups["X0"].Value,
                Y0 = Fire.Groups["Y0"].Value,
                Size0 = Fire.Groups["Size0"].Value
            };

            switch (int.Parse(Fire.Groups["AlarmNum"].Value))
            {
                case 2:
                    fireInfo.X1 = Fire.Groups["X1"].Value;
                    fireInfo.Y1 = Fire.Groups["Y1"].Value;
                    fireInfo.Size1 = Fire.Groups["Size1"].Value;
                    break;
                case 3:
                    fireInfo.X1 = Fire.Groups["X1"].Value;
                    fireInfo.Y1 = Fire.Groups["Y1"].Value;
                    fireInfo.Size1 = Fire.Groups["Size1"].Value;
                    fireInfo.X2 = Fire.Groups["X2"].Value;
                    fireInfo.Y2 = Fire.Groups["Y2"].Value;
                    fireInfo.Size2 = Fire.Groups["Size2"].Value;
                    break;
                case 4:
                    fireInfo.X1 = Fire.Groups["X1"].Value;
                    fireInfo.Y1 = Fire.Groups["Y1"].Value;
                    fireInfo.Size1 = Fire.Groups["Size1"].Value;
                    fireInfo.X2 = Fire.Groups["X2"].Value;
                    fireInfo.Y2 = Fire.Groups["Y2"].Value;
                    fireInfo.Size2 = Fire.Groups["Size2"].Value;
                    fireInfo.X3 = Fire.Groups["X3"].Value;
                    fireInfo.Y3 = Fire.Groups["Y3"].Value;
                    fireInfo.Size3 = Fire.Groups["Size3"].Value;
                    break;
            }

            record.Add(fireInfo);
        }
        internal void ResetWrite(Match Reset, List<FireInfo> record)
        {
            record.Add(new FireInfo { Time = Reset.Groups["Time"].Value, ActivationType = "Reset", IP = Reset.Groups["IP"].Value });
        }
        public void LogSearch(Match fire)
        {
            int alarmNum = int.Parse(fire.Groups["AlarmNum"].Value);

            // Determine the number of fires and draw each one accordingly
            for (int i = 0; i < alarmNum; i++)
            {
                DrawFire(fire, $"X{i}", $"Y{i}");
            }
        }
        public void DrawFire(Match fire, string XGroupName, string YGroupName)
        {
            int X = int.Parse(fire.Groups[XGroupName].Value.Substring(0, fire.Groups[XGroupName].Value.IndexOf('.')));
            int Y = int.Parse(fire.Groups[YGroupName].Value.Substring(0, fire.Groups[YGroupName].Value.IndexOf('.')));
            using (Graphics g = Graphics.FromImage(IR_Image.Image))
            {
                PaintCross(g, X, Y);
            }
            IR_Image.Refresh();
        }

        //Draw the cross
        public void PaintCross(Graphics g, int X, int Y)
        {
            //Half length of the line.
            const int HALF_LEN = 5;
            const int X_Offset = -20;
            const int Y_Offset = 55;

            int centerX = X / 2 + X_Offset;
            int centerY = Y / 2 + Y_Offset;

            //Draw horizontal line.
            Point horizontalP1 = new Point(centerX - HALF_LEN, centerY);
            Point horizontalP2 = new Point(centerX + HALF_LEN, centerY);
            g.DrawLine(Pens.Red, horizontalP1, horizontalP2);

            //Draw the vertical line.
            Point verticalP1 = new Point(centerX, centerY - HALF_LEN);
            Point verticalP2 = new Point(centerX, centerY + HALF_LEN);
            g.DrawLine(Pens.Red, verticalP1, verticalP2);
        }

        private void Button_Read_Logs_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // Get all files in the selected folder
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    MessageBox.Show($"Files Found: {files.Length}", "Message");

                    // Filter files with names starting with 'C' and ending with '.txt'
                    string[] FileEntries = Directory.GetFiles(fbd.SelectedPath, "C*.txt");
                    foreach (string fileEntry in FileEntries)
                    {
                        ProcessLogFile(fileEntry, fbd.SelectedPath);
                    }

                    MessageBox.Show("Complete");
                }
            }
        }

        private void ProcessLogFile(string filePath, string SelectedPath)
        {
            // Read the entire log file
            using (StreamReader sr = new StreamReader(filePath))
            {
                string alarmLog = sr.ReadToEnd();

                // Process fire-related matches
                foreach (Match fireMatch in Regex.Matches(alarmLog, LogAnalysis.LogPattern, RegexOptions.Multiline))
                {
                    FireWrite(fireMatch, record);
                }

                // Process reset-related matches
                foreach (Match resetMatch in Regex.Matches(alarmLog, LogAnalysis.ResetPattern, RegexOptions.Multiline))
                {
                    ResetWrite(resetMatch, record);
                }

                // Write results to CSV
                WriteResultsCsv(SelectedPath, record);

            }
        }

        private void WriteResultsCsv(string SelectedPath, List<FireInfo> records)
        {
            string csvFilePath = Path.Combine(SelectedPath, "Results.csv");
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write CSV header
                csv.WriteHeader<FireInfo>();
                csv.NextRecord();

                // Write each record to CSV
                foreach (FireInfo record in records)
                {
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }
            }
        }

        public static int DisplayProgressBar(int progress, int total)
        {
            const int totalBlocks = 10000; // Total number of blocks in the progress bar
            double fractionDone = (double)progress / total;
            int blocksDone = (int)Math.Round(fractionDone * totalBlocks);
            return blocksDone;
        }
    }
}
using System.Text.RegularExpressions;

namespace ImageAnalyser.Utilities
{
    internal class Coords
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
    }

    internal class Variables
    {
        public static string IP { get; set; }
        public static string Oct1 { get; set; }
        public static string Oct2 { get; set; }
        public static string Oct3 { get; set; }
        public static string Oct4 { get; set; }
        public static string FileName { get; set; }
    }

    internal class FireInfo
    {
        public string Time { get; set; }
        public string ActivationType { get; set; }
        public string IP { get; set; }
        public string AlarmNum { get; set; }
        public string X0 { get; set; }
        public string Y0 { get; set; }
        public string Size0 { get; set; }
        public string X1 { get; set; }
        public string Y1 { get; set; }
        public string Size1 { get; set; }
        public string X2 { get; set; }
        public string Y2 { get; set; }
        public string Size2 { get; set; }
        public string X3 { get; set; }
        public string Y3 { get; set; }
        public string Size3 { get; set; }
    }

    internal class Pattern
    {
        // Regular expression pattern for IP address
        public const string IPAddressPattern = @"(?<Oct1>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[1-9])\.(?<Oct2>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct3>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct4>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])";
        public string AlarmPattern = @"(?<Time>[0-9]+-[0-9]+-[0-9]+ [0-9]+:[0-9]+:[0-9]+\.[0-9]+) .*" +
                                  Variables.Oct1 + @"\." + Variables.Oct2 + @"\." + Variables.Oct3 + @"\." + Variables.Oct4 +
                                  @" .*(?<AlarmNum>[0-9+])[\s]+" +
                                  @".*x = -?(?<X0>[0-9\.]+)[\s]+\.y = -?(?<Y0>[0-9\.]+)\s+\.sz = (?<Size0>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X1>[0-9\.]+)[\s]+\.y = -?(?<Y1>[0-9\.]+)\s+\.sz = (?<Size1>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X2>[0-9\.]+)[\s]+\.y = -?(?<Y2>[0-9\.]+)\s+\.sz = (?<Size2>[0-9]+)[\s]+" +
                                  @".*x = -?(?<X3>[0-9\.]+)[\s]+\.y = -?(?<Y3>[0-9\.]+)\s+\.sz = (?<Size3>[0-9]+)";


    }

    internal class LogAnalysis
    {
        // Regular expression pattern for log analysis
        public const string LogPattern = @"(?<Time>[0-9]+-[0-9]+-[0-9]+ [0-9]+:[0-9]+:[0-9]+\.[0-9]+) .*(?<IP>(?<Oct1>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[1-9])\.(?<Oct2>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct3>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct4>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])) .*(?<AlarmNum>[0-9+])[\s]+.*x = (?<X0>[0-9\.]+)[\s]+\.y = (?<Y0>[0-9\.]+)\s+\.sz = (?<Size0>[0-9]+)[\s]+.*x = (?<X1>[0-9\.]+)[\s]+\.y = (?<Y1>[0-9\.]+)\s+\.sz = (?<Size1>[0-9]+)[\s]+.*x = (?<X2>[0-9\.]+)[\s]+\.y = (?<Y2>[0-9\.]+)\s+\.sz = (?<Size2>[0-9]+)[\s]+.*x = (?<X3>[0-9\.]+)[\s]+\.y = (?<Y3>[0-9\.]+)\s+\.sz = (?<Size3>[0-9]+)";

        // Regular expression pattern for reset
        public const string ResetPattern = @"(?<Time>[0-9]+-[0-9]+-[0-9]+ [0-9]+:[0-9]+:[0-9]+\.[0-9]+).*ResetAlarm .*(?<IP>(?<Oct1>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[1-9])\.(?<Oct2>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct3>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9])\.(?<Oct4>25[0-4]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]|[0-9]))";
    }
}
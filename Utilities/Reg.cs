using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageAnalyser.Utilities
{
    internal class Reg
    {
        public static String ExtractIPAddress(string fileName)
        {
            Match IP = Regex.Match(fileName, Pattern.IPAddressPattern);
            Variables.IP = IP.Value;
            Variables.Oct1 = IP.Groups["Oct1"].Value;
            Variables.Oct2 = IP.Groups["Oct2"].Value;
            Variables.Oct3 = IP.Groups["Oct3"].Value;
            Variables.Oct4 = IP.Groups["Oct4"].Value;
            return Variables.IP;
        }
    }
}

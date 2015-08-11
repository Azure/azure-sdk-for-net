namespace AzureLogTool
{
    using System;
    using System.Globalization;
    using System.IO;

    internal static class Utils
    {
        //see http://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.aspx

        internal static void CreateLocalFolderIfNotExists(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        internal static double ByteToMbit(long bytes)
        {
            return ((double)bytes) * 8 / (1024 * 1024);
        }

        internal static string DateTimeToStandardizedStringFormat(DateTime dt)
        {
            return "\"" + dt.ToUniversalTime().ToString("yyyy'-'MM'-'dd HH':'mm':'ss'Z'", CultureInfo.InvariantCulture) + "\"";
        }

        internal static void DateUsage()
        {
            Stdout.WriteLine();
            Stdout.WriteLine("Dates should be specified in format understandable to DateTime.Parse().");
            Stdout.WriteLine("Examples:");
            Stdout.WriteLine("     \"2013-11-22\" -- midnight of Nov22 in Local Time");
            Stdout.WriteLine("     \"2013-11-22Z\" -- midnight of Nov22 in UTC Time");
            Stdout.WriteLine("     \"2013-11-22 01:00:00Z\" -- 1AM Nov22 UTC");
            Stdout.WriteLine("     \"2013-07-25T01:00:00Z\" -- 1AM Nov22 UTC");
        }
    }
}

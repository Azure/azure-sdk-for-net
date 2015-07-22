namespace AzureLogTool
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    // Note on date handling.
    //  -- all DateTime objects use UTC Time for internal representation.
    //  -- DateTime.Parse( "utc datetime string" ) auto converts to local time.  It is necessary to use .ToUTC() to revert this.
    //  -- all output should be in UTC.

    // Example usage:
    // lat.exe download -account mikelidwestus1 -key "/+rgnxiQFRHiNYzXGQWZtLE/b0FLhz/QNZpdqsUVxwDDSmwCJsAsFCEFqyZKCpuhbtgjymJ5Jsi3o8/p6lNmwQ==" -f -logCache d:\wasLogs\
    // lat.exe throttlinganalysis -account mikelidwestus2 -logCache d:\wasLogs\ -start "2013-11-22 19:12:03Z" -end "2013-11-22 19:12:43Z"
    internal class Program
    {
        private static void GeneralUsage()
        {
            Stdout.WriteLine();
            Stdout.WriteLine("USAGE:");
            Stdout.WriteLine("lat.exe [throttlinganalysis <args>] [download <args>]");
            Stdout.WriteLine("run with empty <args> to get help on specific function");
            Environment.Exit(1);
        }

        private static void Main(string[] args)
        {
            if (args.Contains("-debug"))
            {
                Debugger.Launch();
            }

            if (args.Length >= 1 && args[0].ToUpperInvariant() == "DOWNLOAD")
            {
                var downloader = new LogDownloader();
                downloader.ReadArgsDownload(args);
                downloader.DoDownload();
            }
            else if (args.Length >= 1 && args[0].ToUpperInvariant() == "THROTTLINGANALYSIS")
            {
                using (var analyser = new ThrottlingAnalyszer())
                {
                    analyser.ReadArgsThrottlingAnalysis(args);
                    analyser.DoAnalysis();
                }
            }
            else
            {
                GeneralUsage();
                return;
            }
        }
    }
}

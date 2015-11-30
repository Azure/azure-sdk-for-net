namespace AzureLogTool
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal class ThrottlingAnalyszer : IDisposable
    {
        private string accountName = string.Empty;
        private string detailsFilename = @"details.csv";
        private TextWriter detailsWriter;
        private DateTime endTimeUTC = DateTime.MaxValue;
        private string fullCmdLine;
        private string jobName = "UnknownJobName";
        private string jobNote = "No job note";
        private string logCacheRootfolder = null; // logs cache area.
        private string logFolder; // this is the actual root folder for the analysis.
        private DateTime startTimeUTC = DateTime.MinValue;
        private string summaryFilename = @"summary.csv";
        private TextWriter summaryWriter;

        public void Dispose()
        {
            if (this.summaryWriter != null)
            {
                this.summaryWriter.Dispose();
                this.summaryWriter = null;
            }

            if (this.detailsWriter != null)
            {
                this.detailsWriter.Dispose();
                this.detailsWriter = null;
            }
        }

        internal void DoAnalysis()
        {
            Stdout.VerboseWriteLine("Reading log data from: " + this.logFolder);

            try
            {
                this.summaryWriter = new StreamWriter(this.summaryFilename);
            }
            catch (IOException ioe)
            {
                Stdout.WriteLine("ERROR: can't open output file for writing:" + this.summaryFilename + ". " + ioe.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException uae)
            {
                Stdout.WriteLine("ERROR: can't open output file for writing:" + this.summaryFilename + ". " + uae.Message);
                Environment.Exit(1);
            }
            try
            {
                this.detailsWriter = new StreamWriter(this.detailsFilename);
            }
            catch (IOException ioe)
            {
                Stdout.WriteLine("ERROR: can't open output file for writing:" + this.detailsFilename + ". " + ioe.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException uae)
            {
                Stdout.WriteLine("ERROR: can't open output file for writing:" + this.detailsFilename + ". " + uae.Message);
                Environment.Exit(1);
            }

            this.OutputSettings(this.summaryWriter);

            // -- !! determine input files

            List<string> logFilePaths = Directory.EnumerateFiles(this.logFolder, "*", SearchOption.AllDirectories).ToList();
            int logFilesTotalCount = logFilePaths.Count;

            // filter out paths that have datestamps that do not match.
            if (logFilePaths[0].IndexOf("$logs\\20", StringComparison.Ordinal) >= 0)
            {
                int c = 0;
                bool skipped;
                while (c < logFilePaths.Count)
                {
                    skipped = false;
                    int idx = logFilePaths[c].IndexOf("$logs\\20", StringComparison.Ordinal) + 6;
                    // set idx to point to first digit of the year component.
                    if (idx >= 0)
                    {
                        try
                        {
                            int year = int.Parse(logFilePaths[c].Substring(idx, 4), CultureInfo.InvariantCulture);
                            int month = int.Parse(logFilePaths[c].Substring(idx + 5, 2), CultureInfo.InvariantCulture);
                            int day = int.Parse(logFilePaths[c].Substring(idx + 8, 2), CultureInfo.InvariantCulture);
                            int hour = int.Parse(logFilePaths[c].Substring(idx + 11, 2), CultureInfo.InvariantCulture);

                            DateTime logfileDateMinUTC = new DateTime(year, month, day, hour, 0, 0, DateTimeKind.Utc).ToUniversalTime();
                            DateTime logfileDateMaxUTC = logfileDateMinUTC.AddHours(1);

                            if (this.endTimeUTC < logfileDateMinUTC || this.startTimeUTC > logfileDateMaxUTC)
                            {
                                Stdout.VerboseWriteLine("skipping: " + logFilePaths[c]);
                                logFilePaths.RemoveAt(c);
                                skipped = true;
                            }
                        }
                        catch (FormatException)
                        {
                            //parsing the date failed. we will include the file in the processing list
                        }
                    }
                    if (!skipped)
                    {
                        c++;
                    }
                }
            }

            Stdout.WriteLine("Log files found: " + logFilesTotalCount);
            Stdout.WriteLine("Log files after date-filtering: " + logFilePaths.Count());
            if (logFilePaths.Count() == 0)
            {
                Stdout.WriteLine("No log files.");
                Environment.Exit(1);
            }

            Stdout.VerboseWriteLine("Reading:  ");

            var records = new List<AzureBlobLogRecordV1>();
            int filesWithError = 0;
            foreach (string filename in logFilePaths)
            {
                Stdout.VerboseWriteLine("Reading:  " + filename);
                try
                {
                    this.ParseLogFile(filename, this.startTimeUTC, this.endTimeUTC, records);
                }
                catch (IndexOutOfRangeException e)
                {
                    filesWithError++;
                    Stdout.VerboseWriteLine(string.Format(CultureInfo.CurrentCulture, "File:  {0}. Parsing exception:{1},", filename, e.Message));
                }
                catch (IOException e)
                {
                    filesWithError++;
                    Stdout.VerboseWriteLine(string.Format(CultureInfo.CurrentCulture, "File:  {0}. Parsing exception:{1},", filename, e.Message));
                }
                catch (FormatException e)
                {
                    filesWithError++;
                    Stdout.VerboseWriteLine(string.Format(CultureInfo.CurrentCulture, "File:  {0}. Parsing exception:{1},", filename, e.Message));
                }
            }
            if (filesWithError > 0)
            {
                Stdout.WriteLine(string.Format(CultureInfo.CurrentCulture, "WARN: {0} logs files had errors. Was logcache set correctly? Use -verbose to see parsing exception messages", filesWithError));
            }

            Stdout.WriteLine();

            // -- !! do the analysis.
            this.Process(records);

            this.summaryWriter.Close();
            this.detailsWriter.Close();
            Stdout.WriteLine("Results written to: " + this.summaryFilename + " and " + this.detailsFilename);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Needed for interface.")]
        internal void ReadArgsThrottlingAnalysis(string[] args)
        {
            Stdout.WriteLine();
            this.fullCmdLine = string.Join(" ", args);
            Exception e = null;
            bool unknownArg = false;
            int curr = 1;
            try
            {
                while (curr < args.Length)
                {
                    if (args[curr].ToUpperInvariant() == "-LOGCACHE" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.logCacheRootfolder = args[curr];
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-ACCOUNT" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.accountName = args[curr];
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-START" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.startTimeUTC = DateTime.Parse(args[curr], CultureInfo.CurrentCulture).ToUniversalTime();
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-END" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.endTimeUTC = DateTime.Parse(args[curr], CultureInfo.CurrentCulture).ToUniversalTime();
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-NAME" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.jobName = args[curr];
                        curr++;

                        this.summaryFilename = this.jobName + ".summary.csv";
                        this.detailsFilename = this.jobName + ".details.csv";
                    }
                    else if (args[curr].ToUpperInvariant() == "-NOTE" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.jobNote = args[curr];
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-DEBUG")
                    {
                        curr++;
                        //ignore
                    }
                    else if (args[curr].ToUpperInvariant() == "-VERBOSE" || args[curr].ToUpperInvariant() == "-V")
                    {
                        curr++;
                        Stdout.Verbose = true;
                    }
                    else
                    {
                        unknownArg = true;
                        break;
                    }
                }
            }
            catch (FormatException ex)
            {
                e = ex;
            }

            if (e != null)
            {
                Stdout.WriteLine("Exception during arg processing:" + e.Message);
                this.AnalyserUsage();
            }
            if (unknownArg)
            {
                Stdout.WriteLine("Unknown arg:" + args[curr]);
                this.AnalyserUsage();
            }

            // input checks
            if (this.logCacheRootfolder == null)
            {
                Stdout.WriteLine("WARN: logcache defaulting to current directory.  Use -logcache to target a specific directory for caching log files.");
                this.logCacheRootfolder = Environment.CurrentDirectory;
            }

            if (string.IsNullOrEmpty(this.accountName))
            {
                Stdout.WriteLine("WARN: account not specified. Analysis will include all storage accounts in logcache directory.");
            }

            string path = Path.Combine(this.logCacheRootfolder, this.accountName);
            if (!Directory.Exists(this.logCacheRootfolder))
            {
                Stdout.WriteLine("ERROR: logcache folder does not exist:" + path);
            }
            if (Directory.Exists(path))
            {
                this.logFolder = path;
            }
            else
            {
                Stdout.WriteLine("WARN: account specific folder does not exist:" + path);
                Stdout.WriteLine("      using bare logcache folder:" + this.logCacheRootfolder);
                this.logFolder = this.logCacheRootfolder;
            }

            if (this.startTimeUTC == DateTime.MinValue)
            {
                Stdout.WriteLine("WARN: startTime not specified. Defaulting to MinValue. Some summary statistics will be affected.");
            }
            if (this.endTimeUTC == DateTime.MaxValue)
            {
                Stdout.WriteLine("WARN: endTime not specified. Defaulting to MaxValue. Some summary statistics will be affected.");
            }

            Stdout.WriteLine();
            Stdout.WriteLine("Configuration:");
            Stdout.WriteLine("-start    " + Utils.DateTimeToStandardizedStringFormat(this.startTimeUTC));
            Stdout.WriteLine("-end      " + Utils.DateTimeToStandardizedStringFormat(this.endTimeUTC));

            Stdout.VerboseWriteLine("-logCache  " + this.logCacheRootfolder);
            Stdout.VerboseWriteLine("-account   " + this.accountName);
            Stdout.WriteLine();
        }

        private void AnalyserUsage()
        {
            Stdout.WriteLine();
            Stdout.WriteLine();
            Stdout.WriteLine("USAGE:");
            Stdout.WriteLine("AzureLogAnalysis.exe analyse <args>");
            Stdout.WriteLine("  -logcache  <folderPath>");
            Stdout.WriteLine("  -account   <storageAccountName>");
            Stdout.WriteLine("  -start <datetime>");
            Stdout.WriteLine("  -end   <datetime>");
            Stdout.WriteLine("  -name  <analysisName>   Used to name output files");
            Stdout.WriteLine("  -note  <noteText>       A note to store in summary output");
            Stdout.WriteLine("  -debug                  Launch debugger at process start");
            Stdout.WriteLine("  -v,-verbose             Verbose output");
            Utils.DateUsage();
            Environment.Exit(1);
        }

        private List<PerSecondAggregate> CalculatePerSecondAggregates(List<AzureBlobLogRecordV1> records)
        {
            var perSecondAggregates = new List<PerSecondAggregate>();
            DateTime start = records[0].RequestStartTimeUTC;
            long currentSecond = 0;
            long successBytes = 0;
            long throttleBytes = 0;
            long failBytes = 0;
            long totalBytes = 0;
            long readBytes = 0;
            long writeBytes = 0;
            long requestCount = 0;
            long maxLatencyTotalMilliseconds = 0;

            for (int i = 0; i < records.Count; i++)
            {
                AzureBlobLogRecordV1 r = records[i];
                TimeSpan ts = r.RequestStartTimeUTC.Subtract(start);
                var sec = (long)ts.TotalSeconds;

                //if we have entered a new accumulation period
                if (sec != currentSecond)
                {
                    perSecondAggregates.Add(
                        new PerSecondAggregate(
                            currentSecond,
                            Utils.ByteToMbit(successBytes),
                            Utils.ByteToMbit(readBytes),
                            Utils.ByteToMbit(writeBytes),
                            Utils.ByteToMbit(throttleBytes),
                            Utils.ByteToMbit(failBytes),
                            Utils.ByteToMbit(totalBytes),
                            maxLatencyTotalMilliseconds));

                    currentSecond = sec;
                    successBytes = 0;
                    readBytes = 0;
                    writeBytes = 0;
                    throttleBytes = 0;
                    failBytes = 0;
                    totalBytes = 0;
                    requestCount = 0;
                    maxLatencyTotalMilliseconds = 0;
                }

                if (r.IsRead)
                {
                    readBytes += r.DataSize;
                }
                if (r.OperationType == AzureOperationTypeV1.PutBlob || r.OperationType == AzureOperationTypeV1.PutBlock)
                {
                    writeBytes += r.DataSize;
                }

                if (r.IsSuccess)
                {
                    successBytes += r.DataSize;
                }
                else if (r.IsThrottle)
                {
                    throttleBytes += r.DataSize;
                }
                else
                {
                    failBytes += r.DataSize;
                }
                totalBytes += r.DataSize;
                requestCount++;
                if (r.EndToEndLatencyMilliseconds > maxLatencyTotalMilliseconds)
                {
                    maxLatencyTotalMilliseconds = r.EndToEndLatencyMilliseconds;
                }
            }

            // and emit the last period..
            perSecondAggregates.Add(
                new PerSecondAggregate(
                    currentSecond,
                    Utils.ByteToMbit(successBytes),
                    Utils.ByteToMbit(readBytes),
                    Utils.ByteToMbit(writeBytes),
                    Utils.ByteToMbit(throttleBytes),
                    Utils.ByteToMbit(failBytes),
                    Utils.ByteToMbit(totalBytes),
                    maxLatencyTotalMilliseconds));
            return perSecondAggregates;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Needed for interface.")]
        private void EmitGlobalAggregates(List<AzureBlobLogRecordV1> records, List<PerSecondAggregate> perSecondAggregates, TextWriter w)
        {
            long totalDataBytes = records.Sum(r => r.DataSize);
            TimeSpan jobDuration = this.endTimeUTC.Subtract(this.startTimeUTC);
            var jobDurationSeconds = (long)jobDuration.TotalSeconds;
            long jobMbps = totalDataBytes * 8 / (1024 * 1024) / jobDurationSeconds;
            long throttleErrorCount = records.Count(r => r.IsThrottle);
            long throttleErrorBytes = records.Where(r => r.IsThrottle).Sum(r => r.DataSize);
            long failErrorCount = records.Count(r => r.IsError);
            long failErrorBytes = records.Where(r => r.IsError).Sum(r => r.DataSize);

            Stdout.TeeWriteLine(w, string.Format(CultureInfo.CurrentCulture, "Records,{0}", records.Count));
            Stdout.TeeWriteLine(
                w,
                string.Format(CultureInfo.CurrentCulture, "JobDuration,{0}h {1}m {2}s", jobDuration.Hours, jobDuration.Minutes, jobDuration.Seconds));
            Stdout.TeeWriteLine(w, string.Format(CultureInfo.CurrentCulture, "JobDuration(sec),{0}", +jobDurationSeconds));
            Stdout.TeeWriteLine(w, string.Format(CultureInfo.CurrentCulture, "JobTotalGB,{0}", totalDataBytes / (1024 * 1024 * 1024)));
            Stdout.TeeWriteLine(w, string.Format(CultureInfo.CurrentCulture, "JobMbps,{0}", jobMbps));
            Stdout.TeeWriteLine(
                w, string.Format(CultureInfo.CurrentCulture, "ThrottledPackets/TotalBytes,{0} / {1}", throttleErrorCount, throttleErrorBytes));
            Stdout.TeeWriteLine(w, string.Format(CultureInfo.CurrentCulture, "FailedPackets/TotalBytes,{0} / {1}", failErrorCount, failErrorBytes));
            Stdout.TeeWriteLine(
                w, string.Format(CultureInfo.CurrentCulture, "Peak ReadMbps (Instantaneous),{0}", (long)perSecondAggregates.Max(r => r.ReadMbps)));
            Stdout.TeeWriteLine(
                w,
                string.Format(
                    CultureInfo.CurrentCulture, "Peak ReadMbps (Moving30SecAv),{0}", (long)perSecondAggregates.Max(r => r.ReadMbpsMovingAv30Secs)));
            Stdout.TeeWriteLine(
                w,
                string.Format(
                    CultureInfo.CurrentCulture, "Peak ReadMbps (Moving60SecAv),{0}", (long)perSecondAggregates.Max(r => r.ReadMbpsMovingAv60Secs)));
            Stdout.TeeWriteLine(
                w, string.Format(CultureInfo.CurrentCulture, "Peak WriteMbps (Instantaneous),{0}", (long)perSecondAggregates.Max(r => r.WriteMbps)));
            Stdout.TeeWriteLine(
                w,
                string.Format(
                    CultureInfo.CurrentCulture, "Peak WriteMbps (Moving30SecAv),{0}", (long)perSecondAggregates.Max(r => r.WriteMbpsMovingAv30Secs)));
            Stdout.TeeWriteLine(
                w,
                string.Format(
                    CultureInfo.CurrentCulture, "Peak WriteMbps (Moving60SecAv),{0}", (long)perSecondAggregates.Max(r => r.WriteMbpsMovingAv60Secs)));
            Stdout.TeeWriteLine(
                w, string.Format(CultureInfo.CurrentCulture, "Peak E2E latency (ms),{0}", (long)perSecondAggregates.Max(r => r.MaxE2ELatency)));
            Stdout.TeeWriteLine(
                w,
                string.Format(
                    CultureInfo.CurrentCulture, "Count E2E latency > 1000ms,{0}", (long)perSecondAggregates.Count(r => r.MaxE2ELatency > 1000)));
            Stdout.WriteLine();
        }

        private void EmitPerSecondResults(List<PerSecondAggregate> perSecondAggregates, TextWriter writer)
        {
            writer.WriteLine(
                string.Format(
                    CultureInfo.CurrentCulture,
                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                    "timeOffset(sec)",
                    "successMbps",
                    "throttleMbps",
                    "failMbps",
                    "totalMbps",
                    "readMbps",
                    "writeMbps",
                    "readMvAv30",
                    "readMvAv60",
                    "writeMvAv30",
                    "writeMvAv60",
                    "Max E2E latency (ms)"));

            foreach (PerSecondAggregate agg in perSecondAggregates)
            {
                writer.WriteLine(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                        agg.SecondsSinceJobStart,
                        agg.SuccessMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.ThrottleMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.FailMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.TotalMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.ReadMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.WriteMbps.ToString("F2", CultureInfo.CurrentCulture),
                        agg.ReadMbpsMovingAv30Secs.ToString("F2", CultureInfo.CurrentCulture),
                        agg.ReadMbpsMovingAv60Secs.ToString("F2", CultureInfo.CurrentCulture),
                        agg.WriteMbpsMovingAv30Secs.ToString("F2", CultureInfo.CurrentCulture),
                        agg.WriteMbpsMovingAv60Secs.ToString("F2", CultureInfo.CurrentCulture),
                        agg.MaxE2ELatency.ToString("F2", CultureInfo.CurrentCulture)));
            }
        }

        private void GenerateMovingAverages(List<PerSecondAggregate> aggregates)
        {
            var last30 = new List<PerSecondAggregate>();
            for (int i = 0; i < 30; i++)
            {
                last30.Add(new PerSecondAggregate());
            }
            var last60 = new List<PerSecondAggregate>();
            for (int i = 0; i < 60; i++)
            {
                last60.Add(new PerSecondAggregate());
            }

            for (int i = 0; i < aggregates.Count; i++)
            {
                PerSecondAggregate row = aggregates[i];
                //kick out old:
                last30.RemoveAt(0); //this is O(n) which isn't ideal.  but net effect is minimal.
                last60.RemoveAt(0);

                //put in new
                last30.Add(row);
                last60.Add(row);

                row.ReadMbpsMovingAv30Secs = last30.Average(r => r.ReadMbps);
                row.ReadMbpsMovingAv60Secs = last60.Average(r => r.ReadMbps);

                row.WriteMbpsMovingAv30Secs = last30.Average(r => r.WriteMbps);
                row.WriteMbpsMovingAv60Secs = last60.Average(r => r.WriteMbps);
            }
        }

        private void OutputSettings(TextWriter writer)
        {
            writer.WriteLine("Cmdline," + this.fullCmdLine);
            writer.WriteLine("Start,'" + Utils.DateTimeToStandardizedStringFormat(this.startTimeUTC));
            writer.WriteLine("End,'" + Utils.DateTimeToStandardizedStringFormat(this.endTimeUTC));
            writer.WriteLine("logFolder," + Path.GetFullPath(this.logCacheRootfolder));
            writer.WriteLine("summaryFile," + Path.GetFullPath(this.summaryFilename));
            writer.WriteLine("detailsFile," + Path.GetFullPath(this.detailsFilename));
            writer.WriteLine("jobName," + this.jobName);
            writer.WriteLine("jobNote," + this.jobNote);
        }

        private void ParseLogFile(string filename, DateTime startTimeUTC, DateTime endTimeUTC, List<AzureBlobLogRecordV1> records)
        {
            string line1;

            using (StreamReader reader = File.OpenText(filename))
            {
                while ((line1 = reader.ReadLine()) != null)
                {
                    string line = line1.Replace("&amp;", "&");
                    string[] fields = line.Split(';');
                    var record = new AzureBlobLogRecordV1();
                    record.RequestStartTimeUTC = DateTime.Parse(fields[1], CultureInfo.InvariantCulture).ToUniversalTime();
                    record.OperationType = (AzureOperationTypeV1)Enum.Parse(typeof(AzureOperationTypeV1), fields[2]);
                    record.RequestStatus = (AzureRequestStatusV1)Enum.Parse(typeof(AzureRequestStatusV1), fields[3]);
                    record.HttpStatusCode = int.Parse(fields[4], CultureInfo.InvariantCulture);
                    record.EndToEndLatencyMilliseconds = int.Parse(fields[5], CultureInfo.InvariantCulture);
                    record.ServerLatencyMilliseconds = int.Parse(fields[6], CultureInfo.InvariantCulture);
                    record.RequestPacketSize = int.Parse(fields[18], CultureInfo.InvariantCulture);
                    record.ResponsePacketSize = int.Parse(fields[20], CultureInfo.InvariantCulture);
                    record.RequestContentLength = int.Parse(fields[21], CultureInfo.InvariantCulture);

                    if (record.RequestStartTimeUTC.CompareTo(startTimeUTC) >= 0 && record.RequestStartTimeUTC.CompareTo(endTimeUTC) <= 0)
                    {
                        records.Add(record);
                    }
                }
            }
        }

        private void Process(List<AzureBlobLogRecordV1> records)
        {
            //w.WriteLine("Records," + records.Count);
            if (records.Count() == 0)
            {
                Stdout.WriteLine("WARN: no records match.");
                return;
            }
            records.Sort((AzureBlobLogRecordV1 r1, AzureBlobLogRecordV1 r2) => r1.RequestStartTimeUTC.CompareTo(r2.RequestStartTimeUTC));

            List<PerSecondAggregate> perSecondAggregates = this.CalculatePerSecondAggregates(records);
            this.GenerateMovingAverages(perSecondAggregates);

            this.EmitGlobalAggregates(records, perSecondAggregates, this.summaryWriter);
            this.EmitPerSecondResults(perSecondAggregates, this.detailsWriter);
        }
    }
}

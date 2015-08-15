namespace AzureLogTool
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Pulls down azure storage logs into a local filesystem cache.
    /// General structure of log area =   
    ///   rootFolder/storageAccounts/$logs/blob/2012/12/01/0000/*.log.
    /// </summary>
    internal class LogDownloader
    {
        private string accountKey; //full key or SAS key
        private string accountName;
        private DateTime endTime = DateTime.MaxValue;
        private bool forceFolderCreation;
        private string logCacheRootfolder;
        private DateTime startTime = DateTime.MinValue;

        internal void DoDownload()
        {
            string blobBaseUriString = null;
            string containerName = "$logs";
            string blobPrefix = "blob/";
            if (this.accountName.Contains("."))
            {
                Stdout.WriteLine("ERROR: Fully qualifed account names are not supported. {name}.blob.core.windows.net is assumed");
                this.DownloaderUsage();
            }
            else
            {
                blobBaseUriString = string.Format(CultureInfo.CurrentCulture, "http://{0}.blob.core.windows.net/", this.accountName);
            }

            StorageCredentials creds = null;
            if (this.accountKey.StartsWith("?sv", StringComparison.Ordinal))
            {
                Stdout.WriteLine("ERROR: SAS key is not supported. Use full key instead.");
                //incidentally, AzureManagementStudio doesn't want to create SAS keys for $logs container.. not sure if there is a WAS limitation.
                //need a way to create SAS keys to test it out.
                //creds = new StorageCredentials(accountKey);
                this.DownloaderUsage();
            }
            else
            {
                creds = new StorageCredentials(this.accountName, this.accountKey); //It't not clear what to provide here if accountName is FQDN
            }

            var blobClient = new CloudBlobClient(new Uri(blobBaseUriString), creds);
            CloudBlobContainer logsContainer = blobClient.GetContainerReference(containerName);
            //CloudBlobDirectory rootDir = logsContainer.GetDirectoryReference("/");
            List<string> blobList = this.EnumerateBlobsInContainer(logsContainer, blobPrefix);
            Stdout.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} files total in $log container", blobList.Count));
            string cachefolder = Path.Combine(this.logCacheRootfolder, this.accountName + "\\" + containerName);

            List<DownloadListItem> downloadList = this.CalculateDownloadList(logsContainer, this.logCacheRootfolder, cachefolder, blobList);
            this.DownloadFiles(logsContainer, downloadList);
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Needed for interface.")]
        internal void ReadArgsDownload(string[] args)
        {
            Console.WriteLine();
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
                    else if (args[curr].ToUpperInvariant() == "-START" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.startTime = DateTime.Parse(args[curr], CultureInfo.CurrentCulture).ToUniversalTime();
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-END" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.endTime = DateTime.Parse(args[curr], CultureInfo.CurrentCulture).ToUniversalTime();
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-DEBUG")
                    {
                        curr++;
                        //ignore
                    }
                    else if (args[curr].ToUpperInvariant() == "-FORCE" || args[curr].ToUpperInvariant() == "-F")
                    {
                        curr++;
                        this.forceFolderCreation = true;
                    }
                    else if (args[curr].ToUpperInvariant() == "-VERBOSE" || args[curr].ToUpperInvariant() == "-V")
                    {
                        curr++;
                        Stdout.Verbose = true;
                    }
                    else if (args[curr].ToUpperInvariant() == "-ACCOUNT" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.accountName = args[curr];
                        curr++;
                    }
                    else if (args[curr].ToUpperInvariant() == "-KEY" && curr + 1 < args.Length)
                    {
                        curr++;
                        this.accountKey = args[curr];
                        curr++;
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
                this.DownloaderUsage();
            }
            if (unknownArg)
            {
                Stdout.WriteLine("Unknown arg:" + args[curr]);
                this.DownloaderUsage();
            }

            //sanity checks.
            bool fail = false;
            if (this.accountName == null)
            {
                Stdout.WriteLine("ERROR: account name not specified. Use -account");
                fail = true;
            }
            if (this.accountKey == null)
            {
                Stdout.WriteLine("ERROR: account key not specified. Use -key.");
                fail = true;
            }

            if (this.startTime == DateTime.MinValue)
            {
                Stdout.WriteLine("WARN:  startTime not specified. Defaulting to MinValue.");
            }
            if (this.endTime == DateTime.MaxValue)
            {
                Stdout.WriteLine("WARN:  endTime not specified. Defaulting to MaxValue");
            }

            if (this.logCacheRootfolder == null)
            {
                Stdout.WriteLine("WARN:  logcache defaulting to current directory.  Use -logcache to target a specific directory for caching log files.");
                this.logCacheRootfolder = Environment.CurrentDirectory;
            }

            if (fail)
            {
                this.DownloaderUsage();
            }

            if (!Directory.Exists(Path.Combine(this.logCacheRootfolder, this.accountName)) && !this.forceFolderCreation)
            {
                Stdout.WriteLine(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "ERROR: root folder {0} does not yet contain a folder for {1}. Either target existing log cache folder or use -f to force creation.",
                        this.logCacheRootfolder,
                        this.accountName));
                this.DownloaderUsage();
            }

            Stdout.WriteLine();
            Stdout.WriteLine("Configuration:");
            Stdout.WriteLine("-start:     " + Utils.DateTimeToStandardizedStringFormat(this.startTime));
            Stdout.WriteLine("-end:       " + Utils.DateTimeToStandardizedStringFormat(this.endTime));
            Stdout.VerboseWriteLine("-logCache:  " + this.logCacheRootfolder);
            Stdout.VerboseWriteLine("-account:   " + this.accountName);
            Stdout.VerboseWriteLine("-key:       " + this.accountKey);
            Stdout.WriteLine();
        }

        private List<DownloadListItem> CalculateDownloadList(
            CloudBlobContainer logsContainer, string rootfolder, string cachefolder, List<string> blobList)
        {
            var downloadList = new List<DownloadListItem>();
            long countFilesMatchingTimeRange = 0;
            Utils.CreateLocalFolderIfNotExists(rootfolder);
            foreach (string blobName in blobList)
            {
                int idx = 0;
                int year = int.Parse(blobName.Substring(idx, 4), CultureInfo.InvariantCulture);
                int month = int.Parse(blobName.Substring(idx + 5, 2), CultureInfo.InvariantCulture);
                int day = int.Parse(blobName.Substring(idx + 8, 2), CultureInfo.InvariantCulture);
                int hour = int.Parse(blobName.Substring(idx + 11, 2), CultureInfo.InvariantCulture);
                string fileName = blobName.Substring(idx + 16);

                var logfileDateMin = new DateTime(year, month, day, hour, 0, 0, DateTimeKind.Utc); // TODO: review UTC/Local conversions.
                DateTime logfileDateMax = logfileDateMin.AddHours(1);

                string pathComponents = string.Format(
                    CultureInfo.InvariantCulture, "{0:00}\\{1:00}\\{2:00}\\{3:00}00\\{4}", year, month, day, hour, fileName);
                string localPath = Path.Combine(cachefolder, pathComponents);

                string uriComponents = string.Format(
                    CultureInfo.InvariantCulture, "{0:00}/{1:00}/{2:00}/{3:00}00/{4}", year, month, day, hour, fileName);
                string blobPath = "blob/" + uriComponents;

                Stdout.VerboseWrite(blobPath + " .. ");

                ICloudBlob blobRef = null;
                try
                {
                    blobRef = logsContainer.GetBlobReferenceFromServer(blobPath);
                }
                catch (StorageException se)
                {
                    Stdout.WriteLine("Error accessing blob on server. skipping. Exception=" + se.Message);
                    continue;
                }

                bool needsDownload = true;
                if (this.startTime < logfileDateMax && this.endTime > logfileDateMin)
                {
                    countFilesMatchingTimeRange++;
                    if (File.Exists(localPath))
                    {
                        var info = new FileInfo(localPath);
                        if (blobRef.Properties.Length == info.Length)
                        {
                            Stdout.VerboseWrite("cached OK.  ");

                            needsDownload = false;
                        }
                        else
                        {
                            Stdout.VerboseWrite("cached but doesn't match.  ");
                        }
                    }

                    if (needsDownload)
                    {
                        Stdout.VerboseWrite("requires download..");
                        downloadList.Add(new DownloadListItem(blobPath, localPath, blobRef.Properties.Length));
                    }
                }
                else
                {
                    Stdout.VerboseWrite("not required");
                }
                Stdout.VerboseWriteLine();
            }

            Stdout.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} files in specified time range", countFilesMatchingTimeRange));
            Stdout.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0} files require download", downloadList.Count));
            return downloadList;
        }

        private void DownloadFiles(CloudBlobContainer logsContainer, List<DownloadListItem> downloadList)
        {
            if (downloadList.Count == 0)
            {
                return;
            }

            long bytes = downloadList.Sum(x => x.Length);
            Stdout.WriteLine(string.Format(CultureInfo.CurrentCulture, "Downloading {0} files, {1} MB..", downloadList.Count, bytes / (1024 * 1024)));

            foreach (DownloadListItem item in downloadList)
            {
                ICloudBlob blobRef = null;
                try
                {
                    blobRef = logsContainer.GetBlobReferenceFromServer(item.RemoteBlobPath);
                }
                catch (StorageException se)
                {
                    Stdout.WriteLine("Error accessing blob on server. skipping. Exception=" + se.Message);
                }

                Utils.CreateLocalFolderIfNotExists(Path.GetDirectoryName(item.LocalFullPath));
                Stdout.Write(string.Format(CultureInfo.CurrentCulture, item.RemoteBlobPath + " ({0} MB)..", item.Length / (1024 * 1024)));
                try
                {
                    blobRef.DownloadToFile(item.LocalFullPath, FileMode.Create);
                    Stdout.WriteLine("done.");
                }
                catch (StorageException se)
                {
                    Stdout.WriteLine("Error: " + se.Message);
                }
            }
        }

        private void DownloaderUsage()
        {
            Stdout.WriteLine();
            Stdout.WriteLine();
            Stdout.WriteLine("USAGE:");
            Stdout.WriteLine("AzureLogAnalysis.exe download <args>");
            Stdout.WriteLine("  -start <datetime>");
            Stdout.WriteLine("  -end   <datetime>");
            Stdout.WriteLine("  -logcache <folderPath>");
            Stdout.WriteLine("  -account <storageAccountName>");
            Stdout.WriteLine("  -key <storageKey>");
            Stdout.WriteLine("  -f,-force               Force creation of logcache folder area");
            Stdout.WriteLine("  -debug                  Launches debugger at process start");
            Stdout.WriteLine("  -v,-verbose             Verbose output");

            Utils.DateUsage();

            Environment.Exit(1);
        }

        private List<string> EnumerateBlobsInContainer(CloudBlobContainer logsContainer, string blobPrefix)
        {
            var blobNames = new List<string>();
            int pagingCount = 1000;

            var continuationToken = new BlobContinuationToken();
            var context = new OperationContext();
            context.ClientRequestID = "LogAnalysisTool";
            BlobResultSegment resultSegment;

            //Check whether there are more results and list them in pages of 1000. 
            do
            {
                resultSegment = logsContainer.ListBlobsSegmented(
                    blobPrefix, true, BlobListingDetails.Snapshots, pagingCount, continuationToken, null, context);
                foreach (IListBlobItem blobItem in resultSegment.Results)
                {
                    string blobName;
                    blobName = blobItem.Uri.AbsolutePath.Remove(0, "/$logs/blob/".Length);
                    blobNames.Add(blobName);
                }

                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);

            return blobNames;
        }

        //Represents {blobPath -> localPath} that require downloading.
        private struct DownloadListItem
        {
            internal readonly long Length;
            internal readonly string LocalFullPath;
            internal readonly string RemoteBlobPath; //relative to container.

            internal DownloadListItem(string remoteBlobPath, string localFullPath, long length)
            {
                this.RemoteBlobPath = remoteBlobPath;
                this.LocalFullPath = localFullPath;
                this.Length = length;
            }
        }
    }
}

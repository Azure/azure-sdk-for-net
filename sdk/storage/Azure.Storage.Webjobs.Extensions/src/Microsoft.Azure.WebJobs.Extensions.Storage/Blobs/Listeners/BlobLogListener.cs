// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Shared.Protocol;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // Scans storage logs for blob writes
    internal class BlobLogListener
    {
        internal const int DefaultScanHoursWindow = 2;

        private const string LogType = "LogType";

        private readonly CloudBlobClient _blobClient;
        private readonly HashSet<string> _scannedBlobNames = new HashSet<string>();
        private readonly StorageAnalyticsLogParser _parser;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly ILogger<BlobListener> _logger;

        private BlobLogListener(CloudBlobClient blobClient, IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger)
        {
            _blobClient = blobClient;
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _parser = new StorageAnalyticsLogParser(logger);
        }

        public CloudBlobClient Client
        {
            get { return _blobClient; }
        }

        // This will throw if the client credentials are not valid. 
        public static async Task<BlobLogListener> CreateAsync(CloudBlobClient blobClient,
           IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger, CancellationToken cancellationToken)
        {
            await EnableLoggingAsync(blobClient, cancellationToken);
            return new BlobLogListener(blobClient, exceptionHandler, logger);
        }

        public async Task<IEnumerable<ICloudBlob>> GetRecentBlobWritesAsync(CancellationToken cancellationToken,
            int hoursWindow = DefaultScanHoursWindow)
        {
            List<ICloudBlob> blobs = new List<ICloudBlob>();

            var time = DateTime.UtcNow; // will scan back 2 hours, which is enough to deal with clock sqew
            foreach (var blob in await ListRecentLogFilesAsync(_blobClient, time, cancellationToken, hoursWindow, _exceptionHandler, _logger))
            {
                bool isAdded = _scannedBlobNames.Add(blob.Name);
                if (!isAdded)
                {
                    continue;
                }

                // Need to clear out cache. 
                if (_scannedBlobNames.Count > 100 * 1000)
                {
                    _scannedBlobNames.Clear();
                }

                IEnumerable<StorageAnalyticsLogEntry> entries = await _parser.ParseLogAsync(blob, cancellationToken);
                IEnumerable<BlobPath> filteredBlobs = GetPathsForValidBlobWrites(entries);

                foreach (BlobPath path in filteredBlobs)
                {
                    var container = _blobClient.GetContainerReference(path.ContainerName);
                    blobs.Add(container.GetBlockBlobReference(path.BlobName));
                }
            }

            return blobs;
        }

        internal static IEnumerable<BlobPath> GetPathsForValidBlobWrites(IEnumerable<StorageAnalyticsLogEntry> entries)
        {
            IEnumerable<BlobPath> parsedBlobPaths = from entry in entries
                                                    where entry.IsBlobWrite
                                                    select entry.ToBlobPath();

            return parsedBlobPaths.Where(p => p != null);
        }

        // Return a search prefix for the given start,end time. 
        //  $logs/YYYY/MM/DD/HH00
        private static string GetSearchPrefix(string service, DateTime startTime, DateTime endTime)
        {
            StringBuilder prefix = new StringBuilder("$logs/");

            prefix.AppendFormat("{0}/", service);

            // if year is same then add the year
            if (startTime.Year == endTime.Year)
            {
                prefix.AppendFormat("{0}/", startTime.Year);
            }
            else
            {
                return prefix.ToString();
            }

            // if month is same then add the month
            if (startTime.Month == endTime.Month)
            {
                prefix.AppendFormat("{0:D2}/", startTime.Month);
            }
            else
            {
                return prefix.ToString();
            }

            // if day is same then add the day
            if (startTime.Day == endTime.Day)
            {
                prefix.AppendFormat("{0:D2}/", startTime.Day);
            }
            else
            {
                return prefix.ToString();
            }

            // if hour is same then add the hour
            if (startTime.Hour == endTime.Hour)
            {
                prefix.AppendFormat("{0:D2}00", startTime.Hour);
            }

            return prefix.ToString();
        }

        // Scan this hour and last hour
        // This lets us use prefix scans. $logs/Blob/YYYY/MM/DD/HH00/nnnnnn.log
        // Logs are about 6 an hour, so we're only scanning about 12 logs total. 
        // $$$ If logs are large, we can even have a cache of "already scanned" logs that we skip. 
        private static async Task<List<ICloudBlob>> ListRecentLogFilesAsync(CloudBlobClient blobClient, DateTime startTimeForSearch,
            CancellationToken cancellationToken, int hoursWindow, IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger)
        {
            string serviceName = "blob";

            List<ICloudBlob> selectedLogs = new List<ICloudBlob>();

            var lastHour = startTimeForSearch;
            for (int i = 0; i < hoursWindow; i++)
            {
                var prefix = GetSearchPrefix(serviceName, lastHour, lastHour);
                await GetLogsWithPrefixAsync(selectedLogs, blobClient, prefix, exceptionHandler, logger, cancellationToken);
                lastHour = lastHour.AddHours(-1);
            }

            return selectedLogs;
        }

        // Populate the List<> with blob logs for the given prefix. 
        // http://blogs.msdn.com/b/windowsazurestorage/archive/2011/08/03/windows-azure-storage-logging-using-logs-to-track-storage-requests.aspx
        private static async Task GetLogsWithPrefixAsync(List<ICloudBlob> selectedLogs, CloudBlobClient blobClient,
            string prefix, IWebJobsExceptionHandler exceptionHandler, ILogger<BlobListener> logger, CancellationToken cancellationToken)
        {
            // List the blobs using the prefix            
            IEnumerable<IListBlobItem> blobs = await blobClient.ListBlobsAsync(prefix,
                    useFlatBlobListing: true, blobListingDetails: BlobListingDetails.Metadata,
                    operationName: "ScanLogs", exceptionHandler: exceptionHandler, logger: logger, cancellationToken: cancellationToken);

            if (blobs == null)
            {
                return;
            }

            // iterate through each blob and figure the start and end times in the metadata
            // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
            foreach (var item in blobs)
            {
                ICloudBlob log = item as ICloudBlob;
                if (log != null && log.Metadata.ContainsKey(LogType))
                {
                    // we will exclude the file if the file does not have log entries in the interested time range.
                    string logType = log.Metadata[LogType];
                    bool hasWrites = logType.Contains("write");

                    if (hasWrites)
                    {
                        selectedLogs.Add(log);
                    }
                }
            }
        }

        public static async Task EnableLoggingAsync(CloudBlobClient blobClient, CancellationToken cancellationToken)
        {
            ServiceProperties serviceProperties = await blobClient.GetServicePropertiesAsync(cancellationToken);

            // Merge write onto it. 
            LoggingProperties loggingProperties = serviceProperties.Logging;

            if (loggingProperties.LoggingOperations == LoggingOperations.None)
            {
                // First activating. Be sure to set a retention policy if there isn't one. 
                loggingProperties.RetentionDays = 7;
                loggingProperties.LoggingOperations |= LoggingOperations.Write;

                // Leave metrics untouched           

                await blobClient.SetServicePropertiesAsync(serviceProperties, cancellationToken);
            }
        }
    }
}

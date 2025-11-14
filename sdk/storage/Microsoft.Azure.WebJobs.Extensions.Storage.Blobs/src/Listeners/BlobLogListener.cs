// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    // Scans storage logs for blob writes
    internal class BlobLogListener
    {
        internal const int DefaultScanHoursWindow = 2;

        private const string LogType = "LogType";
        private const string LogContainer = "$logs";

        private readonly BlobServiceClient _blobClient;
        private readonly HashSet<string> _scannedBlobNames = new HashSet<string>();
        private readonly StorageAnalyticsLogParser _parser;
        private readonly ILogger<BlobListener> _logger;

        private BlobLogListener(BlobServiceClient blobClient, ILogger<BlobListener> logger)
        {
            _blobClient = blobClient;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _parser = new StorageAnalyticsLogParser(logger);
        }

        // This will throw if the client credentials are not valid.
        public static async Task<BlobLogListener> CreateAsync(BlobServiceClient blobClient, ILogger<BlobListener> logger, CancellationToken cancellationToken)
        {
            await EnableLoggingAsync(blobClient, cancellationToken).ConfigureAwait(false);
            return new BlobLogListener(blobClient, logger);
        }

        public async Task<IEnumerable<BlobWithContainer<BlobBaseClient>>> GetRecentBlobWritesAsync(CancellationToken cancellationToken,
            int hoursWindow = DefaultScanHoursWindow)
        {
            List<BlobWithContainer<BlobBaseClient>> blobs = new List<BlobWithContainer<BlobBaseClient>>();

            var time = DateTime.UtcNow; // will scan back 2 hours, which is enough to deal with clock sqew
            foreach (var blob in await ListRecentLogFilesAsync(_blobClient, time, hoursWindow, cancellationToken).ConfigureAwait(false))
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

                IEnumerable<StorageAnalyticsLogEntry> entries = await _parser.ParseLogAsync(blob, cancellationToken).ConfigureAwait(false);
                IEnumerable<BlobPath> filteredBlobs = GetPathsForValidBlobWrites(entries);

                foreach (BlobPath path in filteredBlobs)
                {
                    var container = _blobClient.GetBlobContainerClient(path.ContainerName);
                    blobs.Add(new BlobWithContainer<BlobBaseClient>(container, container.GetBlockBlobClient(path.BlobName)));
                }
            }

            return blobs;
        }

        public async Task<StorageAnalyticsLogEntry> GetFirstLogEntryWithWritesAsync(string containerName, CancellationToken cancellationToken, int hoursWindow = DefaultScanHoursWindow)
        {
            if (hoursWindow <= 0)
            {
                return null;
            }

            DateTime hourCursor = DateTime.UtcNow;
            BlobContainerClient containerClient = _blobClient.GetBlobContainerClient(LogContainer);

            for (int hourIndex = 0; hourIndex < hoursWindow; hourIndex++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string prefix = GetSearchPrefix("blob", hourCursor, hourCursor);

                await foreach (BlobItem blob in containerClient
                    .GetBlobsAsync(traits: BlobTraits.Metadata, prefix: prefix, states: BlobStates.None, cancellationToken: cancellationToken)
                    .ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (blob.Metadata is not null &&
                        blob.Metadata.TryGetValue(LogType, out string logType) &&
                        !string.IsNullOrEmpty(logType) &&
                        logType.IndexOf("write", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        BlobClient logBlobClient = containerClient.GetBlobClient(blob.Name);

                        using (Stream stream = await logBlobClient.OpenReadAsync(options: default, cancellationToken: cancellationToken).ConfigureAwait(false))
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                int lineNumber = 0;
                                while (!reader.EndOfStream)
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
                                    string line = await reader.ReadLineAsync().ConfigureAwait(false);
                                    lineNumber++;

                                    if (line != null)
                                    {
                                        var entry = _parser.ParseLine(line, logBlobClient.Name, lineNumber.ToString(CultureInfo.InvariantCulture));
                                        if (entry != null && entry.IsBlobWrite)
                                        {
                                            var path = entry.ToBlobPath();
                                            if (path != null &&
                                                string.Equals(path.ContainerName, containerName, StringComparison.OrdinalIgnoreCase))
                                            {
                                                // If we found a valid write entry, we can stop searching.
                                                return entry;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                hourCursor = hourCursor.AddHours(-1);
            }

            return null;
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
            StringBuilder prefix = new StringBuilder();

            prefix.AppendFormat(CultureInfo.InvariantCulture, "{0}/", service);

            // if year is same then add the year
            if (startTime.Year == endTime.Year)
            {
                prefix.AppendFormat(CultureInfo.InvariantCulture, "{0}/", startTime.Year);
            }
            else
            {
                return prefix.ToString();
            }

            // if month is same then add the month
            if (startTime.Month == endTime.Month)
            {
                prefix.AppendFormat(CultureInfo.InvariantCulture, "{0:D2}/", startTime.Month);
            }
            else
            {
                return prefix.ToString();
            }

            // if day is same then add the day
            if (startTime.Day == endTime.Day)
            {
                prefix.AppendFormat(CultureInfo.InvariantCulture, "{0:D2}/", startTime.Day);
            }
            else
            {
                return prefix.ToString();
            }

            // if hour is same then add the hour
            if (startTime.Hour == endTime.Hour)
            {
                prefix.AppendFormat(CultureInfo.InvariantCulture, "{0:D2}00", startTime.Hour);
            }

            return prefix.ToString();
        }

        // Scan this hour and last hour
        // This lets us use prefix scans. $logs/Blob/YYYY/MM/DD/HH00/nnnnnn.log
        // Logs are about 6 an hour, so we're only scanning about 12 logs total.
        // $$$ If logs are large, we can even have a cache of "already scanned" logs that we skip.
        private static async Task<List<BlobBaseClient>> ListRecentLogFilesAsync(BlobServiceClient blobClient, DateTime startTimeForSearch,
            int hoursWindow, CancellationToken cancellationToken)
        {
            string serviceName = "blob";

            List<BlobBaseClient> selectedLogs = new List<BlobBaseClient>();

            var lastHour = startTimeForSearch;
            for (int i = 0; i < hoursWindow; i++)
            {
                var prefix = GetSearchPrefix(serviceName, lastHour, lastHour);
                await GetLogsWithPrefixAsync(selectedLogs, blobClient, prefix, cancellationToken).ConfigureAwait(false);
                lastHour = lastHour.AddHours(-1);
            }

            return selectedLogs;
        }

        // Populate the List<> with blob logs for the given prefix.
        // http://blogs.msdn.com/b/windowsazurestorage/archive/2011/08/03/windows-azure-storage-logging-using-logs-to-track-storage-requests.aspx
        private static async Task GetLogsWithPrefixAsync(List<BlobBaseClient> selectedLogs, BlobServiceClient blobClient,
            string prefix, CancellationToken cancellationToken)
        {
            // List the blobs using the prefix
            BlobContainerClient container = blobClient.GetBlobContainerClient(LogContainer);
            var blobs = container.GetBlobsAsync(
                traits: BlobTraits.Metadata,
                states: BlobStates.None,
                prefix: prefix,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            // iterate through each blob and figure the start and end times in the metadata
            // Type cast to IStorageBlob is safe due to useFlatBlobListing: true above.
            await foreach (var item in blobs.ConfigureAwait(false))
            {
                if (item.Metadata.ContainsKey(LogType))
                {
                    // we will exclude the file if the file does not have log entries in the interested time range.
                    string logType = item.Metadata[LogType];
                    bool hasWrites = logType.Contains("write");

                    if (hasWrites)
                    {
                        selectedLogs.Add(container.GetBlobClient(item.Name));
                    }
                }
            }
        }

        public static async Task EnableLoggingAsync(BlobServiceClient blobClient, CancellationToken cancellationToken)
        {
            BlobServiceProperties serviceProperties = await blobClient.GetPropertiesAsync(cancellationToken).ConfigureAwait(false);

            // Merge write onto it.
            BlobAnalyticsLogging loggingProperties = serviceProperties.Logging;

            if (!loggingProperties.Write)
            {
                // First activating. Be sure to set a retention policy if there isn't one.
                loggingProperties.Write = true;
                loggingProperties.RetentionPolicy = new BlobRetentionPolicy()
                {
                    Enabled = true,
                    Days = 7,
                };

                // Leave metrics untouched
                await blobClient.SetPropertiesAsync(serviceProperties, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

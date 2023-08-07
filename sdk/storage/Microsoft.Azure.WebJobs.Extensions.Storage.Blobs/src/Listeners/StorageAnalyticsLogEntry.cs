// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Represents an entry of the Storage Analytics Log.
    /// </summary>
    /// <remarks>
    /// Storage Analytics Log Format defined at <a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh343259.aspx"/>
    /// </remarks>
    internal class StorageAnalyticsLogEntry
    {
        /// <summary>
        /// The time in UTC when the request was received by Storage Analytics.
        /// </summary>
        public DateTime RequestStartTime { get; set; }

        /// <summary>
        /// The type of REST operation performed. May be omitted if not recognized.
        /// </summary>
        /// <remarks>
        /// See full list of possible operations at <a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh343260.aspx"/>
        /// </remarks>
        public StorageServiceOperationType? OperationType { get; set; }

        /// <summary>
        /// The requested storage service: blob, table, or queue. May be omitted if not recognized.
        /// </summary>
        public StorageServiceType? ServiceType { get; set; }

        /// <summary>
        /// The key of the requested object. This field will always use the account name, even if a custom domain name
        /// has been configured.
        /// </summary>
        /// <remarks>
        /// The key may be in one of the following formats:
        /// <list type="bullet">
        /// <item>
        /// [<![CDATA[https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt]]>
        /// </item>
        /// <item>
        /// [<![CDATA[/account/container/blob]]>
        /// </item>
        /// </list>
        /// </remarks>
        public string RequestedObjectKey { get; set; }

        public bool IsBlobWrite
        {
            get
            {
                return
                    ServiceType.HasValue &&
                    ServiceType == StorageServiceType.Blob &&
                    OperationType.HasValue &&
                    ((OperationType == StorageServiceOperationType.ClearPage) ||
                    (OperationType == StorageServiceOperationType.CopyBlob) ||
                    (OperationType == StorageServiceOperationType.CopyBlobDestination) ||
                    (OperationType == StorageServiceOperationType.PutBlob) ||
                    (OperationType == StorageServiceOperationType.PutBlockList) ||
                    (OperationType == StorageServiceOperationType.PutPage) ||
                    (OperationType == StorageServiceOperationType.SetBlobMetadata) ||
                    (OperationType == StorageServiceOperationType.SetBlobProperties));
            }
        }

        /// <summary>
        /// A factory method attempting to create an instance of entry out of array of fields as extracted from
        /// a single line in Storage Analytics Log file.
        /// </summary>
        /// <param name="fields">
        /// Array of string values of fields as extracted from a single line in a log file.
        /// It must not be null and should contain exactly 30 items.
        /// </param>
        /// <returns>A valid instance of <see cref="StorageAnalyticsLogEntry"/> if given fields match expected format,
        /// or null otherwise.</returns>
        public static StorageAnalyticsLogEntry TryParse(string[] fields)
        {
            Debug.Assert(fields != null);
            Debug.Assert(fields.Length == (int)StorageAnalyticsLogColumnId.LastColumn + 1);

            var entry = new StorageAnalyticsLogEntry();

            DateTime requestStartTime;
            if (!DateTime.TryParseExact(fields[(int)StorageAnalyticsLogColumnId.RequestStartTime], "o",
                CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out requestStartTime))
            {
                return null;
            }
            entry.RequestStartTime = requestStartTime;

            StorageServiceType serviceType;
            if (Enum.TryParse<StorageServiceType>(fields[(int)StorageAnalyticsLogColumnId.ServiceType], true,
                out serviceType))
            {
                entry.ServiceType = serviceType;

                StorageServiceOperationType operationType;
                if (Enum.TryParse<StorageServiceOperationType>(fields[(int)StorageAnalyticsLogColumnId.OperationType],
                out operationType))
                {
                    entry.OperationType = operationType;
                }

                entry.RequestedObjectKey = fields[(int)StorageAnalyticsLogColumnId.RequestedObjectKey];
            }

            return entry;
        }

        /// <summary>
        /// Attempts to retrieve a blob path out of log entry's RequestedObjectKey.
        /// </summary>
        /// <returns>
        /// A valid instance of <see cref="BlobPath"/>, or null if log entry is not associated with a blob.
        /// </returns>
        public BlobPath ToBlobPath()
        {
            if (!ServiceType.HasValue || ServiceType != StorageServiceType.Blob)
            {
                return null;
            }

            string path;

            Uri keyAsUri = new Uri(RequestedObjectKey, UriKind.RelativeOrAbsolute);
            if (keyAsUri.IsAbsoluteUri)
            {
                // assuming key is "https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt"
                path = keyAsUri.Segments.Length > 1 ? keyAsUri.LocalPath.Substring(1) : String.Empty;
            }
            else
            {
                // assuming key is "/account/container/blob"
                int startPos = RequestedObjectKey.Length > 1 ? RequestedObjectKey.IndexOf('/', 1) : -1;
                path = startPos != -1 ? RequestedObjectKey.Substring(startPos + 1) : String.Empty;
            }

            if (String.IsNullOrEmpty(path))
            {
                return null;
            }

            BlobPath blobPath;
            if (!BlobPath.TryParse(path, false, false, out blobPath))
            {
                return null;
            }

            return blobPath;
        }
    }
}

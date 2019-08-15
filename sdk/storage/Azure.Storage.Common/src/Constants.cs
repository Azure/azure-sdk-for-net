// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Dynamic;
using System.Threading;

namespace Azure.Storage
{
    internal static class Constants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public const int GB = MB * 1024;
        public const long TB = GB * 1024L;

        public const int MaxReliabilityRetries = 5;

        /// <summary>
        /// Gets the default service version to use when building shared access
        /// signatures.
        /// </summary>
        public const string DefaultSasVersion = "2018-11-09";

        public const int DefaultBufferSize = 4 * Constants.MB;
        public const int DefaultMaxTotalBufferAllowed = 100 * Constants.MB;

        public const string CloseAllHandles = "*";

        /// <summary>
        /// The default format we use for block names.  There are 50,000
        /// maximum blocks so we pad the size with up to 4 leading zeros.
        /// </summary>
        public const string BlockNameFormat = "Block_{0:D5}";

        // SASTimeFormat represents the format of a SAS start or expiry time. Use it when formatting/parsing a time.Time.
        // ISO 8601 uses "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
        public const string TimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        public const string SnapshotParameterName = "snapshot";

        /// <summary>
        /// Storage Connection Strings 
        /// </summary>
        internal static class ConnectionStrings
        {
            /// <summary>
            /// The default port numbers for development storage credentials
            /// </summary>
            internal const int BlobEndpointPortNumber = 10000;
            internal const int QueueEndpointPortNumber = 10001;
            internal const int TableEndpointPortNumber = 10002;

            internal const string UseDevelopmentSetting = "UseDevelopmentStorage";
            internal const string DevelopmentProxyUriSetting = "DevelopmentStorageProxyUri";
            internal const string DefaultEndpointsProtocolSetting = "DefaultEndpointsProtocol";
            internal const string AccountNameSetting = "AccountName";
            internal const string AccountKeyNameSetting = "AccountKeyName";
            internal const string AccountKeySetting = "AccountKey";
            internal const string BlobEndpointSetting = "BlobEndpoint";
            internal const string QueueEndpointSetting = "QueueEndpoint";
            internal const string TableEndpointSetting = "TableEndpoint";
            internal const string FileEndpointSetting = "FileEndpoint";
            internal const string BlobSecondaryEndpointSetting = "BlobSecondaryEndpoint";
            internal const string QueueSecondaryEndpointSetting = "QueueSecondaryEndpoint";
            internal const string TableSecondaryEndpointSetting = "TableSecondaryEndpoint";
            internal const string FileSecondaryEndpointSetting = "FileSecondaryEndpoint";
            internal const string EndpointSuffixSetting = "EndpointSuffix";
            internal const string SharedAccessSignatureSetting = "SharedAccessSignature";
            internal const string DevStoreAccountName = "devstoreaccount1";
            internal const string DevStoreAccountKey =
                "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
            internal const string SecondaryLocationAccountSuffix = "-secondary";
            internal const string DefaultEndpointSuffix = "core.windows.net";
            internal const string DefaultBlobHostnamePrefix = "blob";
            internal const string DefaultQueueHostnamePrefix = "queue";
            internal const string DefaultTableHostnamePrefix = "table";
            internal const string DefaultFileHostnamePrefix = "file";
        }

        /// <summary>
        /// Header Request Names
        /// </summary>
        internal static class HeaderNames
        {
            public const string XMsPrefix = "x-ms-";
            public const string ErrorCode = "x-ms-error-code";
            public const string RequestId = "x-ms-request-id";
            public const string Date = "x-ms-date";
            public const string SharedKey = "SharedKey";
            public const string Authorization = "Authorization";
            public const string ContentEncoding = "Content-Encoding";
            public const string ContentLanguage = "Content-Language";
            public const string ContentLength = "Content-Length";
            public const string ContentMD5 = "Content-MD5";
            public const string ContentType = "Content-Type";
            public const string IfModifiedSince = "If-Modified-Since";
            public const string IfMatch = "If-Match";
            public const string IfNoneMatch = "If-None-Match";
            public const string IfUnmodifiedSince = "If-Unmodified-Since";
            public const string Range = "Range";
        }

        /// <summary>
        /// Blob constant values
        /// </summary>
        internal static class Blob
        {
            internal static class Append
            {
                public const int MaxAppendBlockBytes = 4 * Constants.MB; // 4MB
                public const int MaxBlocks = 50000;
            }

            internal static class Block
            {
                public const int MaxUploadBytes = 256 * Constants.MB; // 256MB
                public const int MaxStageBytes = 100 * Constants.MB; // 100MB
                public const int MaxBlocks = 50000;

                /// <summary>
                /// The Azure Storage Operation Names for Block Blob Client.
                /// </summary>
                public const string UploadOperationName =
                    "Azure.Storage.Blobs.Specialized.BlockBlobClient.Upload";
                public const string StageBlockOperationName =
                    "Azure.Storage.Blobs.Specialized.BlockBlobClient.StageBlock";
                public const string StageBlockFromUriOperationName =
                    "Azure.Storage.Blobs.Specialized.BlockBlobClient.StageBlockFromUri";
                public const string CommitBlockListOperationName =
                    "Azure.Storage.Blobs.Specialized.BlockBlobClient.CommitBlockList";
                public const string GetBlockListOperationName =
                    "Azure.Storage.Blobs.Specialized.BlockBlobClient.GetBlockList";
            }

            internal static class Container
            {
                /// <summary>
                /// The Azure Storage name used to identify a storage account's root container.
                /// </summary>
                public const string RootName = "$root";

                /// <summary>
                /// The Azure Storage name used to identify a storage account's logs container.
                /// </summary>
                public const string LogsName = "$logs";

                /// <summary>
                /// The Azure Storage Operation Names for Blob Container Client.
                /// </summary>
                public const string CreateOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.Create";
                public const string DeleteOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.Delete";
                public const string GetPropertiesOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.GetProperties";
                public const string SetMetaDataOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.SetMetadata";
                public const string GetAccessPolicyOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.GetAccessPolicy";
                public const string SetAccessPolicyOperationName =
                    "Azure.Storage.Blobs.BlobContainerClient.SetAccessPolicy";
            }

            internal static class Lease
            {
                /// <summary>
                /// Lease Duration is set as infinite when passed -1
                /// </summary>
                public const int InfiniteLeaseDuration = -1;
                /// <summary>
                /// The Azure Storage Operation Names for Blob Lease Client.
                /// </summary>
                public const string AcquireOperationName =
                    "Azure.Storage.Blobs.Specialized.LeaseClient.Acquire";
                public const string RenewOperationName =
                    "Azure.Storage.Blobs.Specialized.LeaseClient.Renew";
                public const string ReleaseOperationName =
                    "Azure.Storage.Blobs.Specialized.LeaseClient.Release";
                public const string ChangeOperationName =
                    "Azure.Storage.Blobs.Specialized.LeaseClient.Change";
                public const string BreakOperationName =
                    "Azure.Storage.Blobs.Specialized.LeaseClient.Break";
            }

            internal static class Page
            {
                public const string CreateOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.Create";
                public const string UploadOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.UploadPages";
                public const string ClearOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.ClearPages";
                public const string GetPageRangesOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.GetPageRanges";
                public const string GetPageRangesDiffOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.GetPageRangesDiff";
                public const string ResizeOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.Resize";
                public const string UpdateSequenceNumberOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.UpdateSequenceNumber";
                public const string StartCopyIncrementalOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.StartCopyIncremental";
                public const string UploadPagesFromUriOperationName =
                    "Azure.Storage.Blobs.Specialized.PageBlobClient.UploadPagesFromUri";
            }

            internal static class Service
            {
                /// <summary>
                /// The Azure Storage Operation Names for Blob Service Client.
                /// </summary>
                public const string GetAccountInfoOperationName =
                    "Azure.Storage.Blobs.BlobServiceClient.GetAccountInfo";
                public const string GetPropertiesOperationName =
                    "Azure.Storage.Blobs.BlobServiceClient.GetProperties";
                public const string SetPropertiesOperationName =
                    "Azure.Storage.Blobs.BlobServiceClient.SetProperties";
                public const string GetStatisticsOperationName =
                    "Azure.Storage.Blobs.BlobServiceClient.GetStatistics";
                public const string GetUserDelegationKeyOperationName =
                    "Azure.Storage.Blobs.BlobServiceClient.GetUserDelegationKey";
            }

        }

        /// <summary>
        /// File constant values
        /// </summary>
        internal static class File
        {
            public const string SetHttpHeadersOperationName =
                "Azure.Storage.Files.FileClient.SetHttpHeaders";
            internal static class Directory
            {
                public const string CreateOperationName =
                    "Azure.Storage.Files.DirectoryClient.Create";
                public const string DeleteOperationName =
                    "Azure.Storage.Files.DirectoryClient.Delete";
                public const string GetPropertiesOperationName =
                    "Azure.Storage.Files.DirectoryClient.GetProperties";
                public const string SetMetadataOperationName =
                    "Azure.Storage.Files.DirectoryClient.SetMetadata";
                public const string ListFilesAndDirectoriesSegmentOperationName =
                    "Azure.Storage.Files.DirectoryClient.ListFilesAndDirectoriesSegment";
                public const string GetHandlesOperationName =
                    "Azure.Storage.Files.DirectoryClient.ListHandles";
                public const string ForceCloseHandlesOperationName =
                    "Azure.Storage.Files.DirectoryClient.ForceCloseHandles";
            }

            internal static class Service
            {
                public const string GetPropertiesOperationName =
                    "Azure.Storage.Files.FileServiceClient.GetProperties";
                public const string SetPropertiesOperationName =
                    "Azure.Storage.Files.FileServiceClient.SetProperties";
            }

            internal static class Share
            {
                public const string CreateOperationName =
                    "Azure.Storage.Files.ShareClient.Create";
                public const string CreateSnapshotOperationName =
                    "Azure.Storage.Files.ShareClient.CreateSnapshot";
                public const string DeleteOperationName =
                    "Azure.Storage.Files.ShareClient.Delete";
                public const string GetPropertiesOperationName =
                    "Azure.Storage.Files.ShareClient.GetProperties";
                public const string SetQuotaOperationName =
                    "Azure.Storage.Files.ShareClient.SetQuota";
                public const string SetMetadataOperationName =
                    "Azure.Storage.Files.ShareClient.SetMetadata";
                public const string GetAccessPolicyOperationName =
                    "Azure.Storage.Files.ShareClient.GetAccessPolicy";
                public const string SetAccessPolicyOperationName =
                    "Azure.Storage.Files.ShareClient.SetAccessPolicy";
                public const string GetStatisticsOperationName =
                    "Azure.Storage.Files.ShareClient.GetStatistics";
            }
        }

        /// <summary>
        /// Queue constant values
        /// </summary>
        internal static class Queue
        {
            /// <summary>
            /// QueueMaxMessagesDequeue indicates the maximum number of messages
            /// you can retrieve with each call to Dequeue.
            /// </summary>
            public const int MaxMessagesDequeue = 32;

            /// <summary>
            /// QueueMessageMaxBytes indicates the maximum number of bytes allowed for a message's UTF-8 text.
            /// </summary>
            public const int QueueMessageMaxBytes = 64 * Constants.KB;

            public const string messagesUri = "messages";

            public const string ClearMessagesOperationName =
                "Azure.Storage.Queues.QueueClient.ClearMessages";
            public const string EnqueueMessageOperationName =
                "Azure.Storage.Queues.QueueClient.EnqueueMessage";
            public const string DequeueMessageOperationName =
                "Azure.Storage.Queues.QueueClient.DequeueMessages";
            public const string PeekMessagesOperationName =
                "Azure.Storage.Queues.QueueClient.PeekMessages";
            public const string DeleteMessageOperationName =
                "Azure.Storage.Queues.QueueClient.DeleteMessage";
            public const string UpdateMessageOperationName =
                 "Azure.Storage.Queues.QueueClient.UpdateMessage";
        }

        /// <summary>
        /// Sas constant values
        /// </summary>
        internal static class Sas
        {
            internal static class Permissions
            {
                public const char Read = 'r';
                public const char Write = 'w';
                public const char Delete = 'd';
                public const char List = 'l';
                public const char Add = 'a';
                public const char Update = 'u';
                public const char Process = 'p';
                public const char Create = 'c';
            }

            internal static class Parameters
            {
                public const string Version = "sv";
                public const string VersionUpper = "SV";
                public const string Services = "ss";
                public const string ServicesUpper = "SS";
                public const string ResourceTypes = "srt";
                public const string ResourceTypesUpper = "SRT";
                public const string Protocol = "spr";
                public const string ProtocolUpper = "SPR";
                public const string StartTime = "st";
                public const string StartTimeUpper = "ST";
                public const string ExpiryTime = "se";
                public const string ExpiryTimeUpper = "SE";
                public const string IPRange = "sip";
                public const string IPRangeUpper = "SIP";
                public const string Identifier = "si";
                public const string IdentifierUpper = "SI";
                public const string Resource = "sr";
                public const string ResourceUpper = "SR";
                public const string Permissions = "sp";
                public const string PermissionsUpper = "SP";
                public const string Signature = "sig";
                public const string SignatureUpper = "SIG";
                public const string KeyOid = "skoid";
                public const string KeyOidUpper = "SKOID";
                public const string KeyTid = "sktid";
                public const string KeyTidUpper = "SKTID";
                public const string KeyStart = "skt";
                public const string KeyStartUpper = "SKT";
                public const string KeyExpiry = "ske";
                public const string KeyExpiryUpper = "SKE";
                public const string KeyService = "sks";
                public const string KeyServiceUpper = "SKS";
                public const string KeyVersion = "skv";
                public const string KeyVersionUpper = "SKV";
            }

            internal static class Resource
            {
                public const string BlobSnapshot = "bs";
                public const string Blob = "b";
                public const string Container = "c";
                public const string File = "f";
                public const string Share = "s";
            }

            internal static class AccountServices
            {
                public const char Blob = 'b';
                public const char Queue = 'q';
                public const char File = 'f';
            }

            internal static class AccountResources
            {
                public const char Service = 's';
                public const char Container = 'c';
                public const char Object = 'o';
            }
        }

        /// <summary>
        /// XML strings to parse for elements
        /// </summary>
        internal static class Xml
        {
            internal const string Code = "Code";
            internal const string Message = "Message";
        }
    }
}

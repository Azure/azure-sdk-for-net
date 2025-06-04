// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    internal class DataMovementBlobStressConstants
    {
        public const int DefaultObjectSize = Constants.KB * 4;
        public const int DefaultObjectCount = 50;

        public static partial class EnvironmentVariables
        {
            // Shared Resources

            /// <summary>
            ///   The name of the environment variable that holds the instrumentation key for the
            ///   Application Insights resource for the test runs.
            /// </summary>
            ///
            public const string ApplicationInsightsKey = "APPINSIGHTS_INSTRUMENTATIONKEY";

            /// <summary>
            ///   The name of the environment variable that holds the connection string for the
            ///   Storage Blob Namespace resource for the test runs.
            /// </summary>
            ///
            public const string StorageSourceBlobEndpoint = "STRESS_STORAGE_SRC_BLOB_ENDPOINT";

            /// <summary>
            ///   The name of the environment variable that holds the connection string for the
            ///   Storage Blob Namespace resource for the test runs.
            /// </summary>
            ///
            public const string StorageDestinationBlobEndpoint = "STRESS_STORAGE_DEST_BLOB_ENDPOINT";

            // Job Index Information

            /// <summary>
            ///   The name of the environment variable that holds the index of the Kubernetes pod. This variable should
            ///   only be set when deploying tests to the Kubernetes cluster, and it allows each test to run all of its roles
            ///   in separate pods. For more information see
            ///   <see href="https://kubernetes.io/docs/tasks/job/indexed-parallel-processing-static/">Kubernetes Documentation on Indexed Jobs</see>
            /// </summary>
            ///
            public const string JobCompletionIndex = "JOB_COMPLETION_INDEX";
        }

        public static partial class TestScenarioNameStr
        {
            public const string UploadSingleBlockBlob = "uploadsingleblockblob";
            public const string UploadDirectoryBlockBlob = "uploaddirectoryblockBlob";
            public const string DownloadSingleBlockBlob = "downloadsingleblockblob";
            public const string DownloadDirectoryBlockBlob = "downloaddirectoryblockblob";
            public const string CopySingleBlockBlob = "copysingleblockblob";
            public const string CopyDirectoryBlockBlob = "copydirectoryblockblob";
            public const string UploadSingleAppendBlob = "uploadsingleappendblob";
            public const string UploadDirectoryAppendBlob = "uploaddirectoryappendblob";
            public const string DownloadSingleAppendBlob = "downloadsingleappendblob";
            public const string DownloadDirectoryAppendBlob = "downloaddirectoryappendblob";
            public const string CopySingleAppendBlob = "copysingleappendblob";
            public const string CopyDirectoryAppendBlob = "copydirectoryappendblob";
            public const string UploadSinglePageBlob = "uploadsinglepageblob";
            public const string UploadDirectoryPageBlob = "uploaddirectorypageblob";
            public const string DownloadSinglePageBlob = "downloadsinglepageblob";
            public const string DownloadDirectoryPageBlob = "downloaddirectorypageblob";
            public const string CopySinglePageBlob = "copysinglepageblob";
            public const string CopyDirectoryPageBlob = "copydirectorypageblob";
        }
    }
}

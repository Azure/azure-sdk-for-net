// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    internal class DataMovementBlobStressConstants
    {
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
            ///   Event Hubs Namespace resource for the test runs.
            /// </summary>
            ///
            public const string StorageBlobEndpoint = "STRESS_STORAGE_BLOB_ENDPOINT";

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
        }
    }
}

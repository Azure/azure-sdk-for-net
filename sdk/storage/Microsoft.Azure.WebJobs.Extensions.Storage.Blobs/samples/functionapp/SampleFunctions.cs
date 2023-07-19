// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Samples.Function.App
{
    /// <summary>
    /// A pair of sample functions. First that updates a blob on schedule and second that listens to blob changes.
    /// </summary>
    public static class SampleFunctions
    {
        /// <summary>
        /// This function executes on schedule, produces a new content and udpates the blob.
        /// </summary>
        [FunctionName("SampleBlobContentUpdater")]
        [return: Blob("sample-container/sample-blob")]
        public static string UpdateSampleBlobContent([TimerTrigger("*/30 * * * * *")] TimerInfo timerInfo, ILogger logger)
        {
            if (timerInfo.IsPastDue)
            {
                logger.LogInformation("Timer is running late!");
            }
            var now = DateTime.Now;
            logger.LogInformation($"C# Timer trigger function executed at: {now}");

            return $"Sample blob content produced at: {now}";
        }

        /// <summary>
        /// This functions is executed when blob is modified.
        /// </summary>
        [FunctionName("SampleBlobUpdateListener")]
        public static void OnBlobUpdate([BlobTrigger("sample-container/sample-blob")] string content, ILogger logger)
        {
            logger.LogInformation("Blob has been updated, content: {content}", content);
        }
    }
}

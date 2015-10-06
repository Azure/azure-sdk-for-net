// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    public partial class JobOperationsExtensions
    {
        /// <summary>
        /// Gets the task log summary from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="targetDirectory">
        /// Required. The directory in which to download the logs to.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account
        /// </param>
        /// <param name="storageAccountKey">
        /// The default storage account key.
        /// </param>
        /// <param name="defaultContainer">
        /// The default container.
        /// </param>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static void DownloadJobTaskLogs(this IJobOperations operations, string jobId, string targetDirectory,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            Task.Factory.StartNew(
                (object s) =>
                    ((IJobOperations) s).DownloadJobTaskLogsAsync(jobId, targetDirectory, storageAccountName,
                        storageAccountKey, defaultContainer), operations, CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the task log summary from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="targetDirectory">
        /// Required. The directory in which to download the logs to.
        /// </param>
        /// <param name="storageAccountName">
        /// The name of the storage account.
        /// </param>
        /// <param name="storageAccountKey">
        /// The default storage account key.
        /// </param>
        /// <param name="defaultContainer">
        /// The default container.
        /// </param>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static Task DownloadJobTaskLogsAsync(this IJobOperations operations, string jobId, string targetDirectory,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return operations.DownloadJobTaskLogsAsync(jobId, targetDirectory, storageAccountName, storageAccountKey,
                defaultContainer, CancellationToken.None);
        }

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="defaultContainer">
        /// Required. The default container.
        /// </param>
        /// <param name="storageAccountName">
        /// Required. The storage account the container lives on.
        /// </param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        public static Stream GetJobOutput(this IJobOperations operations, string jobId, string storageAccountName,
            string storageAccountKey, string defaultContainer)
        {
            return Task.Factory.StartNew(
                (object s) =>
                    ((IJobOperations) s).GetJobOutputAsync(jobId, storageAccountName, storageAccountKey,
                        defaultContainer), operations,
                CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="jobId">
        ///     Required. The id of the job.
        /// </param>
        /// <param name="storageAccountName">
        ///     Required. The storage account the container lives on.
        /// </param>
        /// <param name="storageAccountKey"></param>
        /// <param name="defaultContainer">
        ///     Required. The default container.
        /// </param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        public static Task<Stream> GetJobOutputAsync(this IJobOperations operations, string jobId,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return operations.GetJobOutputAsync(jobId, storageAccountName, storageAccountKey,
                        defaultContainer, CancellationToken.None);
        }

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="defaultContainer">
        /// Required. The default container.
        /// </param>
        /// <param name="storageAccountName">
        /// Required. The storage account the container lives on.
        /// </param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        public static Stream GetJobErrorLogs(this IJobOperations operations, string jobId,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return Task.Factory.StartNew(
                (object s) =>
                    ((IJobOperations)s).GetJobErrorLogsAsync(jobId, storageAccountName, storageAccountKey,
                        defaultContainer), operations,
                CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="defaultContainer">
        /// Required. The default container.
        /// </param>
        /// <param name="storageAccountName">
        /// Required. The storage account the container lives on.
        /// </param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        public static Task<Stream> GetJobErrorLogsAsync(this IJobOperations operations, string jobId,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return operations.GetJobErrorLogsAsync(jobId, storageAccountName, storageAccountKey,
                        defaultContainer, CancellationToken.None);
        }

        /// <summary>
        /// Gets the task logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="defaultContainer">
        /// Required. The default container.
        /// </param>
        /// <param name="storageAccountName">
        /// Required. The storage account the container lives on.
        /// </param>
        /// <returns>
        /// The task logs of an individual jobDetails by jobId.
        /// </returns>
        public static Stream GetJobTaskLogSummary(this IJobOperations operations, string jobId,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return Task.Factory.StartNew(
                (object s) =>
                    ((IJobOperations)s).GetJobTaskLogSummaryAsync(jobId, storageAccountName, storageAccountKey,
                        defaultContainer), operations, CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the task logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="defaultContainer">
        /// Required. The default container.
        /// </param>
        /// <param name="storageAccountName">
        /// Required. The storage account the container lives on.
        /// </param>
        /// <returns>
        /// The task logs of an individual jobDetails by jobId.
        /// </returns>
        public static Task<Stream> GetJobTaskLogSummaryAsync(this IJobOperations operations, string jobId,
            string storageAccountName, string storageAccountKey, string defaultContainer)
        {
            return operations.GetJobTaskLogSummaryAsync(jobId, storageAccountName, storageAccountKey,
                defaultContainer, CancellationToken.None);
        }

    }
}

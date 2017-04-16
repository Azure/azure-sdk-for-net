// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.DataLake.Store
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// FileSystemOperations operations.
    /// </summary>
    public partial interface IFileSystemOperations
    {
        /// <summary>
        /// Test the existence of a file or directory object specified by the file path.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure Data Lake Store account to execute filesystem operations on.
        /// </param>
        /// <param name='getFilePath'>
        /// The Data Lake Store path (starting with '/') of the file or directory for
        /// which to test.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AdlsErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        Task<AzureOperationResponse<bool>> PathExistsWithHttpMessagesAsync(string accountName, string getFilePath, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        void UploadFolder(
            string accountName,
            string sourcePath,
            string destinationPath,
            int perFileThreadCount = -1,
            int concurrentFileCount = -1,
            bool resume = false,
            bool overwrite = false,
            bool uploadAsBinary = false,
            bool recurse = false,
            IProgress<TransferFolderProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken));

        void DownloadFolder(
            string accountName,
            string sourcePath,
            string destinationPath,
            int perFileThreadCount = -1,
            int concurrentFileCount = -1,
            bool resume = false,
            bool overwrite = false,
            bool recurse = false,
            IProgress<TransferFolderProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken));

        void UploadFile(
            string accountName,
            string sourcePath,
            string destinationPath,
            int threadCount = -1,
            bool resume = false,
            bool overwrite = false,
            bool uploadAsBinary = false,
            IProgress<TransferProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken));

        void DownloadFile(
            string accountName,
            string sourcePath,
            string destinationPath,
            int threadCount = -1,
            bool resume = false,
            bool overwrite = false,
            IProgress<TransferProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}

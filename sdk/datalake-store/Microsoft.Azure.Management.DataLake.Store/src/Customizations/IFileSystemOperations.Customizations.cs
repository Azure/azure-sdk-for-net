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
    using System.IO;

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

        /// <summary>
        /// Uploads a folder to the specified Data Lake Store account.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure Data Lake Store account to execute filesystem operations on.
        /// </param>
        /// <param name='sourcePath'>
        /// The local source folder to upload to the Data Lake Store account.
        /// </param>
        /// <param name='destinationPath'>
        /// The Data Lake Store path (starting with '/') of the directory to upload to.
        /// </param>
        /// <param name='perFileThreadCount'>
        /// The maximum number of threads to use per file during the upload. By default, this number will be computed based on folder structure and average file size.
        /// </param>
        /// <param name='concurrentFileCount'>
        /// The maximum number of files to upload at once. By default, this number will be computed based on folder structure and number of files.
        /// </param>
        /// <param name='resume'>
        /// A switch indicating if this upload is a continuation of a previous, failed upload. Default is false.
        /// </param>
        /// <param name='overwrite'>
        /// A switch indicating this upload should overwrite the contents of the target directory if it exists. Default is false, and the upload will fast fail if the target location exists.
        /// </param>
        /// <param name='uploadAsBinary'>
        /// A switch indicating this upload should treat all data as binary, which is slightly more performant but does not ensure record boundary integrity. This is recommended for large folders of mixed binary and text files or binary only directories. Default is false
        /// </param>
        /// <param name='recurse'>
        /// A switch indicating this upload should upload the source directory recursively or just the top level. Default is false, only the top level will be uploaded.
        /// </param>
        /// <param name='progressTracker'>
        /// An optional delegate that can be used to track the progress of the upload operation asynchronously.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AdlsErrorException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="TaskCanceledException">
        /// Thrown when the operation takes too long to complete or if the user explicitly cancels it.
        /// </exception>
        /// <exception cref="InvalidMetadataException">
        /// Thrown when resume metadata is corrupt or not associated with the current operation.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the source path cannot be found.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an invalid upload is attempted or a file/folder is modified externally during the operation.
        /// </exception>
        /// <exception cref="TransferFailedException">
        /// Thrown if the transfer operation fails.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
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

        /// <summary>
        /// Downloads a folder from the specified Data Lake Store account.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure Data Lake Store account to execute filesystem operations on.
        /// </param>
        /// <param name='sourcePath'>
        /// The Data Lake Store path (starting with '/') of the directory to download.
        /// </param>
        /// <param name='destinationPath'>
        /// The local path to download the folder to.
        /// </param>
        /// <param name='perFileThreadCount'>
        /// The maximum number of threads to use per file during the download. By default, this number will be computed based on folder structure and average file size.
        /// </param>
        /// <param name='concurrentFileCount'>
        /// The maximum number of files to download at once. By default, this number will be computed based on folder structure and number of files.
        /// </param>
        /// <param name='resume'>
        /// A switch indicating if this download is a continuation of a previous, failed download. Default is false.
        /// </param>
        /// <param name='overwrite'>
        /// A switch indicating this download should overwrite the contents of the target directory if it exists. Default is false, and the download will fast fail if the target location exists.
        /// </param>
        /// <param name='recurse'>
        /// A switch indicating this download should download the source directory recursively or just the top level. Default is false, only the top level will be downloaded.
        /// </param>
        /// <param name='progressTracker'>
        /// An optional delegate that can be used to track the progress of the download operation asynchronously.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AdlsErrorException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="TaskCanceledException">
        /// Thrown when the operation takes too long to complete or if the user explicitly cancels it.
        /// </exception>
        /// <exception cref="InvalidMetadataException">
        /// Thrown when resume metadata is corrupt or not associated with the current operation.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the source path cannot be found.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an invalid download is attempted or a file/folder is modified externally during the operation.
        /// </exception>
        /// <exception cref="TransferFailedException">
        /// Thrown if the transfer operation fails.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
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

        /// <summary>
        /// Uploads a file to the specified Data Lake Store account.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure Data Lake Store account to execute filesystem operations on.
        /// </param>
        /// <param name='sourcePath'>
        /// The local source file to upload to the Data Lake Store account.
        /// </param>
        /// <param name='destinationPath'>
        /// The Data Lake Store path (starting with '/') of the directory or directory and filename to upload to.
        /// </param>
        /// <param name='threadCount'>
        /// The maximum number of threads to use during the upload. By default, this number will be computed based on file size.
        /// </param>
        /// <param name='resume'>
        /// A switch indicating if this upload is a continuation of a previous, failed upload. Default is false.
        /// </param>
        /// <param name='overwrite'>
        /// A switch indicating this upload should overwrite the target file if it exists. Default is false, and the upload will fast fail if the target file exists.
        /// </param>
        /// <param name='uploadAsBinary'>
        /// A switch indicating this upload should treat the file as binary, which is slightly more performant but does not ensure record boundary integrity.
        /// </param>
        /// <param name='progressTracker'>
        /// An optional delegate that can be used to track the progress of the upload operation asynchronously.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AdlsErrorException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="TaskCanceledException">
        /// Thrown when the operation takes too long to complete or if the user explicitly cancels it.
        /// </exception>
        /// <exception cref="InvalidMetadataException">
        /// Thrown when resume metadata is corrupt or not associated with the current operation.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the source path cannot be found.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an invalid upload is attempted or the file is modified externally during the operation.
        /// </exception>
        /// <exception cref="TransferFailedException">
        /// Thrown if the transfer operation fails.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
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

        /// <summary>
        /// Downloads a file from the specified Data Lake Store account.
        /// </summary>
        /// <param name='accountName'>
        /// The Azure Data Lake Store account to execute filesystem operations on.
        /// </param>
        /// <param name='sourcePath'>
        /// The Data Lake Store path (starting with '/') of the file to download.
        /// </param>
        /// <param name='destinationPath'>
        /// The local path to download the file to. If a directory is specified, the file name will be the same as the source file name
        /// </param>
        /// <param name='threadCount'>
        /// The maximum number of threads to use during the download. By default, this number will be computed based on file size.
        /// </param>
        /// <param name='resume'>
        /// A switch indicating if this download is a continuation of a previous, failed download. Default is false.
        /// </param>
        /// <param name='overwrite'>
        /// A switch indicating this download should overwrite the the target file if it exists. Default is false, and the download will fast fail if the target file exists.
        /// </param>
        /// <param name='progressTracker'>
        /// An optional delegate that can be used to track the progress of the download operation asynchronously.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="AdlsErrorException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="TaskCanceledException">
        /// Thrown when the operation takes too long to complete or if the user explicitly cancels it.
        /// </exception>
        /// <exception cref="InvalidMetadataException">
        /// Thrown when resume metadata is corrupt or not associated with the current operation.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the source path cannot be found.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if an invalid download is attempted or a file is modified externally during the operation.
        /// </exception>
        /// <exception cref="TransferFailedException">
        /// Thrown if the transfer operation fails.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
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

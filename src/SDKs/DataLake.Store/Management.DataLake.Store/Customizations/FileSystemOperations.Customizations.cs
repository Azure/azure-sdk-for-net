// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.DataLake.Store
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Microsoft.Rest.Azure;
    using Models;
    using System.IO;

    /// <summary>
    /// FileSystemOperations operations.
    /// </summary>
    internal partial class FileSystemOperations : IServiceOperations<DataLakeStoreFileSystemManagementClient>, IFileSystemOperations
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
        public async Task<AzureOperationResponse<bool>> PathExistsWithHttpMessagesAsync(string accountName, string getFilePath, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (accountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "accountName");
            }
            if (this.Client.AdlsFileSystemDnsSuffix == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.AdlsFileSystemDnsSuffix");
            }
            if (getFilePath == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "getFilePath");
            }
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            string op = "GETFILESTATUS";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("getFilePath", getFilePath);
                tracingParameters.Add("op", op);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetFileStatus", tracingParameters);
            }
            // Construct URL
            var _baseUrl = this.Client.BaseUri;
            var _url = _baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + "webhdfs/v1/{getFilePath}";
            _url = _url.Replace("{accountName}", accountName);
            _url = _url.Replace("{adlsFileSystemDnsSuffix}", this.Client.AdlsFileSystemDnsSuffix);
            _url = _url.Replace("{getFilePath}", Uri.EscapeDataString(getFilePath));
            List<string> _queryParameters = new List<string>();
            if (op != null)
            {
                _queryParameters.Add(string.Format("op={0}", Uri.EscapeDataString(op)));
            }
            if (this.Client.ApiVersion != null)
            {
                _queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new Uri(_url);
            // Set Headers
            if (this.Client.GenerateClientRequestId != null && this.Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            }
            if (this.Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", this.Client.AcceptLanguage);
            }
            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new AdlsErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    AdlsError _errorBody = SafeJsonConvert.DeserializeObject<AdlsError>(_responseContent, this.Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                        
                        // there is only one exception in case in which we will return false and not throw,
                        // which is when the exception returned is a FileNotFoundException
                        if(ex.Body.RemoteException is AdlsFileNotFoundException)
                        {
                            var _toReturn = new AzureOperationResponse<bool>();
                            _toReturn.Request = _httpRequest;
                            _toReturn.Response = _httpResponse;
                            if (_httpResponse.Headers.Contains("x-ms-request-id"))
                            {
                                _toReturn.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                            }

                            // the file or folder does not exist
                            _toReturn.Body = false;

                            if (_shouldTrace)
                            {
                                ServiceClientTracing.Exit(_invocationId, _toReturn);
                            }

                            return _toReturn;
                        }
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception if the response can't be parsed, 
                    // to ensure the original error is thrown with request/response information
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }

            // Create Result
            var _result = new AzureOperationResponse<bool>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = true;
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

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
        public void DownloadFile(
            string accountName,
            string sourcePath,
            string destinationPath,
            int threadCount = -1,
            bool resume = false,
            bool overwrite = false,
            IProgress<TransferProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("sourcePath", sourcePath);
                tracingParameters.Add("destinationPath", destinationPath);
                tracingParameters.Add("threadCount", threadCount);
                tracingParameters.Add("resume", resume);
                tracingParameters.Add("overwrite", overwrite);
                tracingParameters.Add("progressTracker", progressTracker);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "DownloadFile", tracingParameters);
            }

            try
            {
                var parameters = new TransferParameters(
                    inputFilePath: sourcePath,
                    targetStreamPath: destinationPath,
                    accountName: accountName,
                    perFileThreadCount: threadCount,
                    isOverwrite: overwrite,
                    isResume: resume,
                    isDownload: true
                    );

                var transferAdapter = new DataLakeStoreFrontEndAdapter(accountName, this.Client);
                var transferClient = new DataLakeStoreTransferClient(
                    parameters,
                    transferAdapter,
                    cancellationToken,
                    progressTracker);

                transferClient.Execute();

                if (_shouldTrace)
                {
                    ServiceClientTracing.Exit(
                        _invocationId,
                        string.Format(
                            "Download of stream in account: {0} from source location: {1} to destination: {2} completed successfully.",
                            accountName,
                            sourcePath,
                            destinationPath));
                }
            }
            catch (Exception ex)
            {
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }

                throw ex;
            }
        }

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
        public void UploadFile(
            string accountName,
            string sourcePath,
            string destinationPath,
            int threadCount = -1,
            bool resume = false,
            bool overwrite = false,
            bool uploadAsBinary = false,
            IProgress<TransferProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("sourcePath", sourcePath);
                tracingParameters.Add("destinationPath", destinationPath);
                tracingParameters.Add("threadCount", threadCount);
                tracingParameters.Add("resume", resume);
                tracingParameters.Add("overwrite", overwrite);
                tracingParameters.Add("uploadAsBinary", uploadAsBinary);
                tracingParameters.Add("progressTracker", progressTracker);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadFile", tracingParameters);
            }

            try
            {
                var parameters = new TransferParameters(
                    inputFilePath: sourcePath,
                    targetStreamPath: destinationPath,
                    accountName: accountName,
                    perFileThreadCount: threadCount,
                    isOverwrite: overwrite,
                    isResume: resume,
                    isBinary: uploadAsBinary
                    );

                var transferAdapter = new DataLakeStoreFrontEndAdapter(accountName, this.Client);
                var transferClient = new DataLakeStoreTransferClient(
                    parameters,
                    transferAdapter,
                    cancellationToken,
                    progressTracker);

                transferClient.Execute();

                if (_shouldTrace)
                {
                    ServiceClientTracing.Exit(
                        _invocationId,
                        string.Format(
                            "Upload of stream to account: {0} from source location: {1} to destination: {2} completed successfully.",
                            accountName,
                            sourcePath,
                            destinationPath));
                }
            }
            catch (Exception ex)
            {
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }

                throw ex;
            }
        }

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
        public void DownloadFolder(
            string accountName,
            string sourcePath,
            string destinationPath,
            int perFileThreadCount = -1,
            int concurrentFileCount = -1,
            bool resume = false,
            bool overwrite = false,
            bool recurse = false,
            IProgress<TransferFolderProgress> progressTracker = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("sourcePath", sourcePath);
                tracingParameters.Add("destinationPath", destinationPath);
                tracingParameters.Add("perFileThreadCount", perFileThreadCount);
                tracingParameters.Add("concurrentFileCount", concurrentFileCount);
                tracingParameters.Add("resume", resume);
                tracingParameters.Add("overwrite", overwrite);
                tracingParameters.Add("recurse", recurse);
                tracingParameters.Add("progressTracker", progressTracker);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "DownloadFolder", tracingParameters);
            }

            try
            {
                var parameters = new TransferParameters(
                    inputFilePath: sourcePath,
                    targetStreamPath: destinationPath,
                    accountName: accountName,
                    perFileThreadCount: perFileThreadCount,
                    concurrentFileCount: concurrentFileCount,
                    isOverwrite: overwrite,
                    isResume: resume,
                    isRecursive: recurse,
                    isDownload: true
                    );

                var transferAdapter = new DataLakeStoreFrontEndAdapter(accountName, this.Client);
                var transferClient = new DataLakeStoreTransferClient(
                    parameters,
                    transferAdapter,
                    token: cancellationToken,
                    folderProgressTracker: progressTracker);

                transferClient.Execute();

                if (_shouldTrace)
                {
                    ServiceClientTracing.Exit(
                        _invocationId,
                        string.Format(
                            "Download of folder in account: {0} from source location: {1}{2} to destination: {3} completed successfully.",
                            accountName,
                            sourcePath,
                            recurse ? ", recursively," : string.Empty,
                            destinationPath));
                }
            }
            catch (Exception ex)
            {
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }

                throw ex;
            }
        }

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
        public void UploadFolder(
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
            CancellationToken cancellationToken = default(CancellationToken))
        {
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("accountName", accountName);
                tracingParameters.Add("sourcePath", sourcePath);
                tracingParameters.Add("destinationPath", destinationPath);
                tracingParameters.Add("perFileThreadCount", perFileThreadCount);
                tracingParameters.Add("concurrentFileCount", concurrentFileCount);
                tracingParameters.Add("resume", resume);
                tracingParameters.Add("overwrite", overwrite);
                tracingParameters.Add("recurse", recurse);
                tracingParameters.Add("uploadAsBinary", uploadAsBinary);
                tracingParameters.Add("progressTracker", progressTracker);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadFolder", tracingParameters);
            }

            try
            {
                var parameters = new TransferParameters(
                    inputFilePath: sourcePath,
                    targetStreamPath: destinationPath,
                    accountName: accountName,
                    perFileThreadCount: perFileThreadCount,
                    concurrentFileCount: concurrentFileCount,
                    isOverwrite: overwrite,
                    isResume: resume,
                    isRecursive: recurse,
                    isBinary: uploadAsBinary
                    );

                var transferAdapter = new DataLakeStoreFrontEndAdapter(accountName, this.Client);
                var transferClient = new DataLakeStoreTransferClient(
                    parameters,
                    transferAdapter,
                    token: cancellationToken,
                    folderProgressTracker: progressTracker);

                transferClient.Execute();

                if (_shouldTrace)
                {
                    ServiceClientTracing.Exit(
                        _invocationId,
                        string.Format(
                            "Upload of folder to account: {0} from source location: {1}{2} to destination: {3} completed successfully.",
                            accountName,
                            sourcePath,
                            recurse ? ", recursively," : string.Empty,
                            destinationPath));
                }
            }
            catch (Exception ex)
            {
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }

                throw ex;
            }
        }
    }
}

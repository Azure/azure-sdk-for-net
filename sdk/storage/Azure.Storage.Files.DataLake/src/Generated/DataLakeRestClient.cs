// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file was automatically generated.  Do not edit.

#pragma warning disable IDE0016 // Null check can be simplified
#pragma warning disable IDE0017 // Variable declaration can be inlined
#pragma warning disable IDE0018 // Object initialization can be simplified
#pragma warning disable SA1402  // File may only contain a single type

#region Service
namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// Azure Data Lake Storage REST API
    /// Azure Data Lake Storage provides storage for Hadoop and other big data workloads.
    /// </summary>
    internal static partial class DataLakeRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure Data Lake Storage REST API
        /// </summary>
        public static partial class Service
        {
            #region Service.ListFileSystemsAsync
            /// <summary>
            /// List filesystems and their properties in given account.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters results to filesystems within the specified prefix.</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="maxResults">An optional value that specifies the maximum number of items to return. If omitted or greater than 5,000, the response will include up to 5,000 items.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult>> ListFileSystemsAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string continuation = default,
                int? maxResults = default,
                string requestId = default,
                int? timeout = default,
                bool async = true,
                string operationName = "ServiceClient.ListFileSystems",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListFileSystemsAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        prefix,
                        continuation,
                        maxResults,
                        requestId,
                        timeout))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListFileSystemsAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Service.ListFileSystemsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters results to filesystems within the specified prefix.</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="maxResults">An optional value that specifies the maximum number of items to return. If omitted or greater than 5,000, the response will include up to 5,000 items.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <returns>The Service.ListFileSystemsAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListFileSystemsAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string continuation = default,
                int? maxResults = default,
                string requestId = default,
                int? timeout = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "account", escapeValue: false);
                if (prefix != null) { _request.Uri.AppendQuery("prefix", prefix); }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }
                if (maxResults != null) { _request.Uri.AppendQuery("maxResults", maxResults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Service.ListFileSystemsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListFileSystemsAsync Azure.Response{Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult> ListFileSystemsAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult _value = new Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult();
                        _value.Body = Azure.Storage.Files.DataLake.Models.FileSystemList.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.Continuation = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.DataLake.Models.ServiceListFileSystemsResult>(response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.ListFileSystemsAsync
        }
        #endregion Service operations

        #region FileSystem operations
        /// <summary>
        /// FileSystem operations for Azure Data Lake Storage REST API
        /// </summary>
        public static partial class FileSystem
        {
            #region FileSystem.CreateAsync
            /// <summary>
            /// Create a FileSystem rooted at the specified location. If the FileSystem already exists, the operation fails.  This operation does not support conditional HTTP requests.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemCreateResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemCreateResult>> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string properties = default,
                bool async = true,
                string operationName = "FileSystemClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = CreateAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        properties))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the FileSystem.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <returns>The FileSystem.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string properties = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "filesystem", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (properties != null) { _request.Headers.SetValue("x-ms-properties", properties); }

                return _message;
            }

            /// <summary>
            /// Create the FileSystem.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The FileSystem.CreateAsync Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemCreateResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemCreateResult> CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.FileSystemCreateResult _value = new Azure.Storage.Files.DataLake.Models.FileSystemCreateResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-namespace-enabled", out _header))
                        {
                            _value.NamespaceEnabled = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion FileSystem.CreateAsync

            #region FileSystem.SetPropertiesAsync
            /// <summary>
            /// Set properties for the FileSystem.  This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult>> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string properties = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "FileSystemClient.SetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetPropertiesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        properties,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetPropertiesAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the FileSystem.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The FileSystem.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string properties = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "filesystem", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (properties != null) { _request.Headers.SetValue("x-ms-properties", properties); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the FileSystem.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The FileSystem.SetPropertiesAsync Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult> SetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult _value = new Azure.Storage.Files.DataLake.Models.FileSystemSetPropertiesResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion FileSystem.SetPropertiesAsync

            #region FileSystem.GetPropertiesAsync
            /// <summary>
            /// All system and user-defined filesystem properties are specified in the response headers.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                bool async = true,
                string operationName = "FileSystemClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetPropertiesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the FileSystem.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <returns>The FileSystem.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Head;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "filesystem", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the FileSystem.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The FileSystem.GetPropertiesAsync Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult _value = new Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-properties", out _header))
                        {
                            _value.Properties = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-namespace-enabled", out _header))
                        {
                            _value.NamespaceEnabled = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.DataLake.Models.FileSystemGetPropertiesResult>(response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion FileSystem.GetPropertiesAsync

            #region FileSystem.DeleteAsync
            /// <summary>
            /// Marks the FileSystem for deletion.  When a FileSystem is deleted, a FileSystem with the same identifier cannot be created for at least 30 seconds. While the filesystem is being deleted, attempts to create a filesystem with the same identifier will fail with status code 409 (Conflict), with the service returning additional error information indicating that the filesystem is being deleted. All other operations, including operations on any files or directories within the filesystem, will fail with status code 404 (Not Found) while the filesystem is being deleted. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "FileSystemClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = DeleteAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the FileSystem.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The FileSystem.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "filesystem", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the FileSystem.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The FileSystem.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion FileSystem.DeleteAsync

            #region FileSystem.ListPathsAsync
            /// <summary>
            /// List FileSystem paths and their properties.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="recursive">Required</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="path">Optional.  Filters results to paths within the specified directory. An error occurs if the directory does not exist.</param>
            /// <param name="maxResults">An optional value that specifies the maximum number of items to return. If omitted or greater than 5,000, the response will include up to 5,000 items.</param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false. Note that group and application Object IDs are not translated because they do not have unique friendly names.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult>> ListPathsAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                bool recursive,
                string requestId = default,
                int? timeout = default,
                string continuation = default,
                string path = default,
                int? maxResults = default,
                bool? upn = default,
                bool async = true,
                string operationName = "FileSystemClient.ListPaths",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListPathsAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        recursive,
                        requestId,
                        timeout,
                        continuation,
                        path,
                        maxResults,
                        upn))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListPathsAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the FileSystem.ListPathsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="recursive">Required</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="path">Optional.  Filters results to paths within the specified directory. An error occurs if the directory does not exist.</param>
            /// <param name="maxResults">An optional value that specifies the maximum number of items to return. If omitted or greater than 5,000, the response will include up to 5,000 items.</param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false. Note that group and application Object IDs are not translated because they do not have unique friendly names.</param>
            /// <returns>The FileSystem.ListPathsAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListPathsAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                bool recursive,
                string requestId = default,
                int? timeout = default,
                string continuation = default,
                string path = default,
                int? maxResults = default,
                bool? upn = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("resource", "filesystem", escapeValue: false);

                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("recursive", recursive.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase

                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }
                if (path != null) { _request.Uri.AppendQuery("directory", path); }
                if (maxResults != null) { _request.Uri.AppendQuery("maxResults", maxResults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("upn", upn.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the FileSystem.ListPathsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The FileSystem.ListPathsAsync Azure.Response{Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult> ListPathsAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult _value = new Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult();
                        _value.Body = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.Continuation = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.DataLake.Models.FileSystemListPathsResult>(response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion FileSystem.ListPathsAsync
        }
        #endregion FileSystem operations

        #region Path operations
        /// <summary>
        /// Path operations for Azure Data Lake Storage REST API
        /// </summary>
        public static partial class Path
        {
            #region Path.CreateAsync
            /// <summary>
            /// Create or rename a file or directory.    By default, the destination is overwritten and if the destination already exists and has a lease the lease is broken.  This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).  To fail if the destination already exists, use a conditional request with If-None-Match: "*".
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="resource">Required only for Create File and Create Directory. The value must be "file" or "directory".</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="mode">Optional. Valid only when namespace is enabled. This parameter determines the behavior of the rename operation. The value must be "legacy" or "posix", and the default value will be "posix".</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="renameSource">An optional file or directory to be renamed.  The value must have the following format: "/{filesystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved. This value must be a URL percent-encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the lease ID must match.</param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="umask">Optional and only valid if Hierarchical Namespace is enabled for the account. When creating a file or directory and the parent folder does not have a default ACL, the umask restricts the permissions of the file or directory to be created.  The resulting permission is given by p bitwise and not u, where p is the permission and u is the umask.  For example, if p is 0777 and u is 0057, then the resulting permission is 0720.  The default permission is 0777 for a directory and 0666 for a file.  The default umask is 0027.  The umask must be specified in 4-digit octal notation (e.g. 0766).</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathCreateResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathCreateResult>> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                Azure.Storage.Files.DataLake.Models.PathResourceType? resource = default,
                string continuation = default,
                Azure.Storage.Files.DataLake.Models.PathRenameMode? mode = default,
                string cacheControl = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string contentType = default,
                string renameSource = default,
                string leaseId = default,
                string sourceLeaseId = default,
                string properties = default,
                string permissions = default,
                string umask = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.ETag? sourceIfMatch = default,
                Azure.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = CreateAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        resource,
                        continuation,
                        mode,
                        cacheControl,
                        contentEncoding,
                        contentLanguage,
                        contentDisposition,
                        contentType,
                        renameSource,
                        leaseId,
                        sourceLeaseId,
                        properties,
                        permissions,
                        umask,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="resource">Required only for Create File and Create Directory. The value must be "file" or "directory".</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="mode">Optional. Valid only when namespace is enabled. This parameter determines the behavior of the rename operation. The value must be "legacy" or "posix", and the default value will be "posix".</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="renameSource">An optional file or directory to be renamed.  The value must have the following format: "/{filesystem}/{path}".  If "x-ms-properties" is specified, the properties will overwrite the existing properties; otherwise, the existing properties will be preserved. This value must be a URL percent-encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceLeaseId">A lease ID for the source path. If specified, the source path must have an active lease and the lease ID must match.</param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="umask">Optional and only valid if Hierarchical Namespace is enabled for the account. When creating a file or directory and the parent folder does not have a default ACL, the umask restricts the permissions of the file or directory to be created.  The resulting permission is given by p bitwise and not u, where p is the permission and u is the umask.  For example, if p is 0777 and u is 0057, then the resulting permission is 0720.  The default permission is 0777 for a directory and 0666 for a file.  The default umask is 0027.  The umask must be specified in 4-digit octal notation (e.g. 0766).</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                Azure.Storage.Files.DataLake.Models.PathResourceType? resource = default,
                string continuation = default,
                Azure.Storage.Files.DataLake.Models.PathRenameMode? mode = default,
                string cacheControl = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string contentDisposition = default,
                string contentType = default,
                string renameSource = default,
                string leaseId = default,
                string sourceLeaseId = default,
                string properties = default,
                string permissions = default,
                string umask = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.ETag? sourceIfMatch = default,
                Azure.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (resource != null) { _request.Uri.AppendQuery("resource", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(resource.Value)); }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }
                if (mode != null) { _request.Uri.AppendQuery("mode", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(mode.Value)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (cacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", cacheControl); }
                if (contentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", contentEncoding); }
                if (contentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", contentLanguage); }
                if (contentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", contentDisposition); }
                if (contentType != null) { _request.Headers.SetValue("x-ms-content-type", contentType); }
                if (renameSource != null) { _request.Headers.SetValue("x-ms-rename-source", renameSource); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (sourceLeaseId != null) { _request.Headers.SetValue("x-ms-source-lease-id", sourceLeaseId); }
                if (properties != null) { _request.Headers.SetValue("x-ms-properties", properties); }
                if (permissions != null) { _request.Headers.SetValue("x-ms-permissions", permissions); }
                if (umask != null) { _request.Headers.SetValue("x-ms-umask", umask); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the Path.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.CreateAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathCreateResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathCreateResult> CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathCreateResult _value = new Azure.Storage.Files.DataLake.Models.PathCreateResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.Continuation = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.CreateAsync

            #region Path.UpdateAsync
            /// <summary>
            /// Uploads data to be appended to a file, flushes (writes) previously uploaded data to a file, sets properties for a file or directory, or sets access control for a file or directory. Data can only be appended to a file. This operation supports conditional HTTP requests. For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="action">The action must be "append" to upload data to be appended to a file, "flush" to flush previously uploaded data to a file, "setProperties" to set the properties of a file or directory, "setAccessControl" to set the owner, group, permissions, or access control list for a file or directory, or  "setAccessControlRecursive" to set the access control list for a directory recursively. Note that Hierarchical Namespace must be enabled for the account in order to use access control.  Also note that the Access Control List (ACL) includes permissions for the owner, owning group, and others, so the x-ms-permissions and x-ms-acl request headers are mutually exclusive.</param>
            /// <param name="mode">Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights  that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories</param>
            /// <param name="body">Initial data</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="maxRecords">Optional. Valid for "SetAccessControlRecursive" operation. It specifies the maximum number of files or directories on which the acl change will be applied. If omitted or greater than 2,000, the request will process up to 2,000 items</param>
            /// <param name="continuation">Optional. The number of paths processed with each invocation is limited. If the number of paths to be processed exceeds this limit, a continuation token is returned in the response header x-ms-continuation. When a continuation token is  returned in the response, it must be percent-encoded and specified in a subsequent invocation of setAcessControlRecursive operation.</param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="retainUncommittedData">Valid only for flush operations.  If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted after the flush operation.  The default is false.  Data at offsets less than the specified position are written to the file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future flush operation.</param>
            /// <param name="close">Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled, a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the flush operation completes successfully, the service raises a file change notification with a property indicating that this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that the file stream has been closed."</param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="contentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathUpdateResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathUpdateResult>> UpdateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathUpdateAction action,
                Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode mode,
                System.IO.Stream body,
                string requestId = default,
                int? timeout = default,
                int? maxRecords = default,
                string continuation = default,
                long? position = default,
                bool? retainUncommittedData = default,
                bool? close = default,
                long? contentLength = default,
                byte[] contentHash = default,
                string leaseId = default,
                string cacheControl = default,
                string contentType = default,
                string contentDisposition = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string properties = default,
                string owner = default,
                string group = default,
                string permissions = default,
                string acl = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.Update",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = UpdateAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        action,
                        mode,
                        body,
                        requestId,
                        timeout,
                        maxRecords,
                        continuation,
                        position,
                        retainUncommittedData,
                        close,
                        contentLength,
                        contentHash,
                        leaseId,
                        cacheControl,
                        contentType,
                        contentDisposition,
                        contentEncoding,
                        contentLanguage,
                        properties,
                        owner,
                        group,
                        permissions,
                        acl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return UpdateAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.UpdateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="action">The action must be "append" to upload data to be appended to a file, "flush" to flush previously uploaded data to a file, "setProperties" to set the properties of a file or directory, "setAccessControl" to set the owner, group, permissions, or access control list for a file or directory, or  "setAccessControlRecursive" to set the access control list for a directory recursively. Note that Hierarchical Namespace must be enabled for the account in order to use access control.  Also note that the Access Control List (ACL) includes permissions for the owner, owning group, and others, so the x-ms-permissions and x-ms-acl request headers are mutually exclusive.</param>
            /// <param name="mode">Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights  that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories</param>
            /// <param name="body">Initial data</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="maxRecords">Optional. Valid for "SetAccessControlRecursive" operation. It specifies the maximum number of files or directories on which the acl change will be applied. If omitted or greater than 2,000, the request will process up to 2,000 items</param>
            /// <param name="continuation">Optional. The number of paths processed with each invocation is limited. If the number of paths to be processed exceeds this limit, a continuation token is returned in the response header x-ms-continuation. When a continuation token is  returned in the response, it must be percent-encoded and specified in a subsequent invocation of setAcessControlRecursive operation.</param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="retainUncommittedData">Valid only for flush operations.  If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted after the flush operation.  The default is false.  Data at offsets less than the specified position are written to the file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future flush operation.</param>
            /// <param name="close">Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled, a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the flush operation completes successfully, the service raises a file change notification with a property indicating that this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that the file stream has been closed."</param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="contentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="properties">Optional. User-defined properties to be stored with the filesystem, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.  If the filesystem exists, any properties not included in the list will be removed.  All properties are removed if the header is omitted.  To merge new and existing properties, first get all existing properties and the current E-Tag, then make a conditional request with the E-Tag and include values for all properties.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.UpdateAsync Message.</returns>
            internal static Azure.Core.HttpMessage UpdateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathUpdateAction action,
                Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode mode,
                System.IO.Stream body,
                string requestId = default,
                int? timeout = default,
                int? maxRecords = default,
                string continuation = default,
                long? position = default,
                bool? retainUncommittedData = default,
                bool? close = default,
                long? contentLength = default,
                byte[] contentHash = default,
                string leaseId = default,
                string cacheControl = default,
                string contentType = default,
                string contentDisposition = default,
                string contentEncoding = default,
                string contentLanguage = default,
                string properties = default,
                string owner = default,
                string group = default,
                string permissions = default,
                string acl = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }
                if (body == null)
                {
                    throw new System.ArgumentNullException(nameof(body));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("action", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(action));
                _request.Uri.AppendQuery("mode", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(mode));
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (maxRecords != null) { _request.Uri.AppendQuery("maxRecords", maxRecords.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }
                if (position != null) { _request.Uri.AppendQuery("position", position.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (retainUncommittedData != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("retainUncommittedData", retainUncommittedData.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (close != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("close", close.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (contentLength != null) { _request.Headers.SetValue("Content-Length", contentLength.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (contentHash != null) { _request.Headers.SetValue("x-ms-content-md5", System.Convert.ToBase64String(contentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (cacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", cacheControl); }
                if (contentType != null) { _request.Headers.SetValue("x-ms-content-type", contentType); }
                if (contentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", contentDisposition); }
                if (contentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", contentEncoding); }
                if (contentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", contentLanguage); }
                if (properties != null) { _request.Headers.SetValue("x-ms-properties", properties); }
                if (owner != null) { _request.Headers.SetValue("x-ms-owner", owner); }
                if (group != null) { _request.Headers.SetValue("x-ms-group", group); }
                if (permissions != null) { _request.Headers.SetValue("x-ms-permissions", permissions); }
                if (acl != null) { _request.Headers.SetValue("x-ms-acl", acl); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                // Create the body
                _request.Content = Azure.Core.RequestContent.Create(body);

                return _message;
            }

            /// <summary>
            /// Create the Path.UpdateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.UpdateAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathUpdateResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathUpdateResult> UpdateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.DataLake.Models.PathUpdateResult _value = new Azure.Storage.Files.DataLake.Models.PathUpdateResult();
                        _value.Body = Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-properties", out _header))
                        {
                            _value.Properties = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.XMSContinuation = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathUpdateResult _value = new Azure.Storage.Files.DataLake.Models.PathUpdateResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.UpdateAsync

            #region Path.LeaseAsync
            /// <summary>
            /// Create and manage a lease to restrict write and delete access to the path. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSLeaseAction">There are five lease actions: "acquire", "break", "change", "renew", and "release". Use "acquire" and specify the "x-ms-proposed-lease-id" and "x-ms-lease-duration" to acquire a new lease. Use "break" to break an existing lease. When a lease is broken, the lease break period is allowed to elapse, during which time no lease operation except break and release can be performed on the file. When a lease is successfully broken, the response indicates the interval in seconds until a new lease can be acquired. Use "change" and specify the current lease ID in "x-ms-lease-id" and the new lease ID in "x-ms-proposed-lease-id" to change the lease ID of an active lease. Use "renew" and specify the "x-ms-lease-id" to renew an existing lease. Use "release" and specify the "x-ms-lease-id" to release a lease.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">The lease duration is required to acquire a lease, and specifies the duration of the lease in seconds.  The lease duration must be between 15 and 60 seconds or -1 for infinite lease.</param>
            /// <param name="xMSLeaseBreakPeriod">The lease break period duration is optional to break a lease, and  specifies the break period of the lease in seconds.  The lease break  duration must be between 0 and 60 seconds.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathLeaseResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathLeaseResult>> LeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathLeaseAction xMSLeaseAction,
                string requestId = default,
                int? timeout = default,
                int? xMSLeaseDuration = default,
                int? xMSLeaseBreakPeriod = default,
                string leaseId = default,
                string proposedLeaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.Lease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = LeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        xMSLeaseAction,
                        requestId,
                        timeout,
                        xMSLeaseDuration,
                        xMSLeaseBreakPeriod,
                        leaseId,
                        proposedLeaseId,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return LeaseAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.LeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="xMSLeaseAction">There are five lease actions: "acquire", "break", "change", "renew", and "release". Use "acquire" and specify the "x-ms-proposed-lease-id" and "x-ms-lease-duration" to acquire a new lease. Use "break" to break an existing lease. When a lease is broken, the lease break period is allowed to elapse, during which time no lease operation except break and release can be performed on the file. When a lease is successfully broken, the response indicates the interval in seconds until a new lease can be acquired. Use "change" and specify the current lease ID in "x-ms-lease-id" and the new lease ID in "x-ms-proposed-lease-id" to change the lease ID of an active lease. Use "renew" and specify the "x-ms-lease-id" to renew an existing lease. Use "release" and specify the "x-ms-lease-id" to release a lease.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="xMSLeaseDuration">The lease duration is required to acquire a lease, and specifies the duration of the lease in seconds.  The lease duration must be between 15 and 60 seconds or -1 for infinite lease.</param>
            /// <param name="xMSLeaseBreakPeriod">The lease break period duration is optional to break a lease, and  specifies the break period of the lease in seconds.  The lease break  duration must be between 0 and 60 seconds.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.LeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage LeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathLeaseAction xMSLeaseAction,
                string requestId = default,
                int? timeout = default,
                int? xMSLeaseDuration = default,
                int? xMSLeaseBreakPeriod = default,
                string leaseId = default,
                string proposedLeaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Post;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-lease-action", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(xMSLeaseAction));
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (xMSLeaseDuration != null) { _request.Headers.SetValue("x-ms-lease-duration", xMSLeaseDuration.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (xMSLeaseBreakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", xMSLeaseBreakPeriod.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the Path.LeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.LeaseAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathLeaseResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathLeaseResult> LeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathLeaseResult _value = new Azure.Storage.Files.DataLake.Models.PathLeaseResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-id", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathLeaseResult _value = new Azure.Storage.Files.DataLake.Models.PathLeaseResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-id", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathLeaseResult _value = new Azure.Storage.Files.DataLake.Models.PathLeaseResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-time", out _header))
                        {
                            _value.LeaseTime = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.LeaseAsync

            #region Path.ReadAsync
            /// <summary>
            /// Read the contents of a file.  For read operations, range requests are supported. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">The HTTP Range request header specifies one or more byte ranges of the resource to be retrieved.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSRangeGetContentMd5">Optional. When this header is set to "true" and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4MB in size. If this header is specified without the Range header, the service returns status code 400 (Bad Request). If this header is set to true when the range exceeds 4 MB in size, the service returns status code 400 (Bad Request).</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathReadResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathReadResult>> ReadAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? xMSRangeGetContentMd5 = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.Read",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ReadAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        range,
                        leaseId,
                        xMSRangeGetContentMd5,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return ReadAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.ReadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">The HTTP Range request header specifies one or more byte ranges of the resource to be retrieved.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="xMSRangeGetContentMd5">Optional. When this header is set to "true" and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4MB in size. If this header is specified without the Range header, the service returns status code 400 (Bad Request). If this header is set to true when the range exceeds 4 MB in size, the service returns status code 400 (Bad Request).</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.ReadAsync Message.</returns>
            internal static Azure.Core.HttpMessage ReadAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? xMSRangeGetContentMd5 = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (range != null) { _request.Headers.SetValue("Range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (xMSRangeGetContentMd5 != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-range-get-content-md5", xMSRangeGetContentMd5.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the Path.ReadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.ReadAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathReadResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathReadResult> ReadAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathReadResult _value = new Azure.Storage.Files.DataLake.Models.PathReadResult();
                        _value.Body = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-resource-type", out _header))
                        {
                            _value.ResourceType = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-properties", out _header))
                        {
                            _value.Properties = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 206:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathReadResult _value = new Azure.Storage.Files.DataLake.Models.PathReadResult();
                        _value.Body = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-content-md5", out _header))
                        {
                            _value.XMSContentMd5 = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-resource-type", out _header))
                        {
                            _value.ResourceType = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-properties", out _header))
                        {
                            _value.Properties = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.DataLake.Models.PathReadResult>(response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.ReadAsync

            #region Path.GetPropertiesAsync
            /// <summary>
            /// Get Properties returns all system and user defined properties for a path. Get Status returns all system defined properties for a path. Get Access Control List returns the access control list for a path. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="action">Optional. If the value is "getStatus" only the system defined properties for the path are returned. If the value is "getAccessControl" the access control list is returned in the response headers (Hierarchical Namespace must be enabled for the account), otherwise the properties are returned.</param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false. Note that group and application Object IDs are not translated because they do not have unique friendly names.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction? action = default,
                bool? upn = default,
                string leaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetPropertiesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        action,
                        upn,
                        leaseId,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="action">Optional. If the value is "getStatus" only the system defined properties for the path are returned. If the value is "getAccessControl" the access control list is returned in the response headers (Hierarchical Namespace must be enabled for the account), otherwise the properties are returned.</param>
            /// <param name="upn">Optional. Valid only when Hierarchical Namespace is enabled for the account. If "true", the user identity values returned in the x-ms-owner, x-ms-group, and x-ms-acl response headers will be transformed from Azure Active Directory Object IDs to User Principal Names.  If "false", the values will be returned as Azure Active Directory Object IDs. The default value is false. Note that group and application Object IDs are not translated because they do not have unique friendly names.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction? action = default,
                bool? upn = default,
                string leaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Head;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (action != null) { _request.Uri.AppendQuery("action", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(action.Value)); }
                if (upn != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("upn", upn.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the Path.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.GetPropertiesAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult _value = new Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentMD5 = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-resource-type", out _header))
                        {
                            _value.ResourceType = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-properties", out _header))
                        {
                            _value.Properties = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-owner", out _header))
                        {
                            _value.Owner = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-group", out _header))
                        {
                            _value.Group = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-permissions", out _header))
                        {
                            _value.Permissions = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-acl", out _header))
                        {
                            _value.ACL = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.DataLake.Models.PathGetPropertiesResult>(response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.GetPropertiesAsync

            #region Path.DeleteAsync
            /// <summary>
            /// Delete the file or directory. This operation supports conditional HTTP requests.  For more information, see [Specifying Conditional Headers for Blob Service Operations](https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursive">Required</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathDeleteResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathDeleteResult>> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                bool? recursive = default,
                string continuation = default,
                string leaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                bool async = true,
                string operationName = "PathClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = DeleteAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        requestId,
                        timeout,
                        recursive,
                        continuation,
                        leaseId,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="recursive">Required</param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <returns>The Path.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string requestId = default,
                int? timeout = default,
                bool? recursive = default,
                string continuation = default,
                string leaseId = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (recursive != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("recursive", recursive.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }

                return _message;
            }

            /// <summary>
            /// Create the Path.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.DeleteAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathDeleteResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathDeleteResult> DeleteAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathDeleteResult _value = new Azure.Storage.Files.DataLake.Models.PathDeleteResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.Continuation = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.DeleteAsync

            #region Path.SetAccessControlAsync
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a path.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult>> SetAccessControlAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string permissions = default,
                string acl = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "PathClient.SetAccessControl",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetAccessControlAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        leaseId,
                        owner,
                        group,
                        permissions,
                        acl,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessControlAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.SetAccessControlAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="owner">Optional. The owner of the blob or directory.</param>
            /// <param name="group">Optional. The owning group of the blob or directory.</param>
            /// <param name="permissions">Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission.  The sticky bit is also supported.  Both symbolic (rwxrw-rw-) and 4-digit octal notation (e.g. 0766) are supported.</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Path.SetAccessControlAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetAccessControlAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                string owner = default,
                string group = default,
                string permissions = default,
                string acl = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("action", "setAccessControl", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (owner != null) { _request.Headers.SetValue("x-ms-owner", owner); }
                if (group != null) { _request.Headers.SetValue("x-ms-group", group); }
                if (permissions != null) { _request.Headers.SetValue("x-ms-permissions", permissions); }
                if (acl != null) { _request.Headers.SetValue("x-ms-acl", acl); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Path.SetAccessControlAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.SetAccessControlAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult> SetAccessControlAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult _value = new Azure.Storage.Files.DataLake.Models.PathSetAccessControlResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-client-request-id", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.SetAccessControlAsync

            #region Path.SetAccessControlRecursiveAsync
            /// <summary>
            /// Set the access control list for a path and subpaths.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="mode">Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights  that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="maxRecords">Optional. It specifies the maximum number of files or directories on which the acl change will be applied. If omitted or greater than 2,000, the request will process up to 2,000 items</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult>> SetAccessControlRecursiveAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode mode,
                string version,
                int? timeout = default,
                string continuation = default,
                int? maxRecords = default,
                string acl = default,
                string requestId = default,
                bool async = true,
                string operationName = "PathClient.SetAccessControlRecursive",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetAccessControlRecursiveAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        mode,
                        version,
                        timeout,
                        continuation,
                        maxRecords,
                        acl,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessControlRecursiveAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.SetAccessControlRecursiveAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="mode">Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights  that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="continuation">Optional.  When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.</param>
            /// <param name="maxRecords">Optional. It specifies the maximum number of files or directories on which the acl change will be applied. If omitted or greater than 2,000, the request will process up to 2,000 items</param>
            /// <param name="acl">Sets POSIX access control rights on files and directories. The value is a comma-separated list of access control entries. Each access control entry (ACE) consists of a scope, a type, a user or group identifier, and permissions in the format "[scope:][type]:[id]:[permissions]".</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Path.SetAccessControlRecursiveAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetAccessControlRecursiveAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode mode,
                string version,
                int? timeout = default,
                string continuation = default,
                int? maxRecords = default,
                string acl = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("action", "setAccessControlRecursive", escapeValue: false);
                _request.Uri.AppendQuery("mode", Azure.Storage.Files.DataLake.DataLakeRestClient.Serialization.ToString(mode));
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (continuation != null) { _request.Uri.AppendQuery("continuation", continuation); }
                if (maxRecords != null) { _request.Uri.AppendQuery("maxRecords", maxRecords.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (acl != null) { _request.Headers.SetValue("x-ms-acl", acl); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Path.SetAccessControlRecursiveAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.SetAccessControlRecursiveAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult> SetAccessControlRecursiveAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult _value = new Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveResult();
                        _value.Body = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-client-request-id", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-continuation", out _header))
                        {
                            _value.Continuation = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.SetAccessControlRecursiveAsync

            #region Path.FlushDataAsync
            /// <summary>
            /// Set the owner, group, permissions, or access control list for a path.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="retainUncommittedData">Valid only for flush operations.  If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted after the flush operation.  The default is false.  Data at offsets less than the specified position are written to the file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future flush operation.</param>
            /// <param name="close">Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled, a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the flush operation completes successfully, the service raises a file change notification with a property indicating that this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that the file stream has been closed."</param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="contentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathFlushDataResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathFlushDataResult>> FlushDataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? position = default,
                bool? retainUncommittedData = default,
                bool? close = default,
                long? contentLength = default,
                byte[] contentHash = default,
                string leaseId = default,
                string cacheControl = default,
                string contentType = default,
                string contentDisposition = default,
                string contentEncoding = default,
                string contentLanguage = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "PathClient.FlushData",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = FlushDataAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        position,
                        retainUncommittedData,
                        close,
                        contentLength,
                        contentHash,
                        leaseId,
                        cacheControl,
                        contentType,
                        contentDisposition,
                        contentEncoding,
                        contentLanguage,
                        ifMatch,
                        ifNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return FlushDataAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.FlushDataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="retainUncommittedData">Valid only for flush operations.  If "true", uncommitted data is retained after the flush operation completes; otherwise, the uncommitted data is deleted after the flush operation.  The default is false.  Data at offsets less than the specified position are written to the file when flush succeeds, but this optional parameter allows data after the flush position to be retained for a future flush operation.</param>
            /// <param name="close">Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled, a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the flush operation completes successfully, the service raises a file change notification with a property indicating that this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that the file stream has been closed."</param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="contentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="cacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="contentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="contentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Path.FlushDataAsync Message.</returns>
            internal static Azure.Core.HttpMessage FlushDataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? position = default,
                bool? retainUncommittedData = default,
                bool? close = default,
                long? contentLength = default,
                byte[] contentHash = default,
                string leaseId = default,
                string cacheControl = default,
                string contentType = default,
                string contentDisposition = default,
                string contentEncoding = default,
                string contentLanguage = default,
                Azure.ETag? ifMatch = default,
                Azure.ETag? ifNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("action", "flush", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (position != null) { _request.Uri.AppendQuery("position", position.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (retainUncommittedData != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("retainUncommittedData", retainUncommittedData.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (close != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Uri.AppendQuery("close", close.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (contentLength != null) { _request.Headers.SetValue("Content-Length", contentLength.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (contentHash != null) { _request.Headers.SetValue("x-ms-content-md5", System.Convert.ToBase64String(contentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (cacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", cacheControl); }
                if (contentType != null) { _request.Headers.SetValue("x-ms-content-type", contentType); }
                if (contentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", contentDisposition); }
                if (contentEncoding != null) { _request.Headers.SetValue("x-ms-content-encoding", contentEncoding); }
                if (contentLanguage != null) { _request.Headers.SetValue("x-ms-content-language", contentLanguage); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Path.FlushDataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.FlushDataAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathFlushDataResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathFlushDataResult> FlushDataAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathFlushDataResult _value = new Azure.Storage.Files.DataLake.Models.PathFlushDataResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-client-request-id", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.FlushDataAsync

            #region Path.AppendDataAsync
            /// <summary>
            /// Append data to the file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathAppendDataResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathAppendDataResult>> AppendDataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                string version,
                long? position = default,
                int? timeout = default,
                long? contentLength = default,
                byte[] transactionalContentHash = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "PathClient.AppendData",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = AppendDataAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        body,
                        version,
                        position,
                        timeout,
                        contentLength,
                        transactionalContentHash,
                        leaseId,
                        requestId))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendDataAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.AppendDataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="position">This parameter allows the caller to upload data in parallel and control the order in which it is appended to the file.  It is required when uploading data to be appended to the file and when flushing previously uploaded data to the file.  The value must be the position where the data is to be appended.  Uploaded data is not immediately flushed, or written, to the file.  To flush, the previously uploaded data must be contiguous, the position parameter must be specified and equal to the length of the file after all data has been written, and there must not be a request entity body included with the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="contentLength">Required for "Append Data" and "Flush Data".  Must be 0 for "Flush Data".  Must be the length of the request content in bytes for "Append Data".</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Path.AppendDataAsync Message.</returns>
            internal static Azure.Core.HttpMessage AppendDataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                string version,
                long? position = default,
                int? timeout = default,
                long? contentLength = default,
                byte[] transactionalContentHash = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (body == null)
                {
                    throw new System.ArgumentNullException(nameof(body));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Patch;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("action", "append", escapeValue: false);
                if (position != null) { _request.Uri.AppendQuery("position", position.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (contentLength != null) { _request.Headers.SetValue("Content-Length", contentLength.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (transactionalContentHash != null) { _request.Headers.SetValue("Content-MD5", System.Convert.ToBase64String(transactionalContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.RequestContent.Create(body);

                return _message;
            }

            /// <summary>
            /// Create the Path.AppendDataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.AppendDataAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathAppendDataResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathAppendDataResult> AppendDataAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathAppendDataResult _value = new Azure.Storage.Files.DataLake.Models.PathAppendDataResult();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-client-request-id", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.AppendDataAsync

            #region Path.SetExpiryAsync
            /// <summary>
            /// Sets the time a blob will expire and be deleted.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="expiryOptions">Required. Indicates mode of the expiry time</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="expiresOn">The time to set the blob to expiry</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal>> SetExpiryAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathExpiryOptions expiryOptions,
                int? timeout = default,
                string requestId = default,
                string expiresOn = default,
                bool async = true,
                string operationName = "PathClient.SetExpiry",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetExpiryAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        expiryOptions,
                        timeout,
                        requestId,
                        expiresOn))
                    {
                        if (async)
                        {
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.Send(_message, cancellationToken);
                        }
                        Azure.Response _response = _message.Response;
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetExpiryAsync_CreateResponse(clientDiagnostics, _response);
                    }
                }
                catch (System.Exception ex)
                {
                    _scope.Failed(ex);
                    throw;
                }
                finally
                {
                    _scope.Dispose();
                }
            }

            /// <summary>
            /// Create the Path.SetExpiryAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="expiryOptions">Required. Indicates mode of the expiry time</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="expiresOn">The time to set the blob to expiry</param>
            /// <returns>The Path.SetExpiryAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetExpiryAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                Azure.Storage.Files.DataLake.Models.PathExpiryOptions expiryOptions,
                int? timeout = default,
                string requestId = default,
                string expiresOn = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (version == null)
                {
                    throw new System.ArgumentNullException(nameof(version));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "expiry", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-expiry-option", expiryOptions.ToString());
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (expiresOn != null) { _request.Headers.SetValue("x-ms-expiry-time", expiresOn); }

                return _message;
            }

            /// <summary>
            /// Create the Path.SetExpiryAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Path.SetExpiryAsync Azure.Response{Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal}.</returns>
            internal static Azure.Response<Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal> SetExpiryAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal _value = new Azure.Storage.Files.DataLake.Models.PathSetExpiryInternal();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-client-request-id", out _header))
                        {
                            _value.ClientRequestId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Path.SetExpiryAsync
        }
        #endregion Path operations
    }
}
#endregion Service

#region Models
#region class AclFailedEntry
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AclFailedEntry
    /// </summary>
    internal partial class AclFailedEntry
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// type
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// errorMessage
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of AclFailedEntry instances.
        /// You can use DataLakeModelFactory.AclFailedEntry instead.
        /// </summary>
        internal AclFailedEntry() { }

        /// <summary>
        /// Deserializes XML into a new AclFailedEntry instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized AclFailedEntry instance.</returns>
        internal static Azure.Storage.Files.DataLake.Models.AclFailedEntry FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.DataLake.Models.AclFailedEntry _value = new Azure.Storage.Files.DataLake.Models.AclFailedEntry();
            _child = element.Element(System.Xml.Linq.XName.Get("name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("type", ""));
            if (_child != null)
            {
                _value.Type = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("errorMessage", ""));
            if (_child != null)
            {
                _value.ErrorMessage = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.DataLake.Models.AclFailedEntry value);
    }
}
#endregion class AclFailedEntry

#region class FileSystem
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystem
    /// </summary>
    internal partial class FileSystem
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// lastModified
        /// </summary>
        public string LastModified { get; internal set; }

        /// <summary>
        /// eTag
        /// </summary>
        public string ETag { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystem instances.
        /// You can use DataLakeModelFactory.FileSystem instead.
        /// </summary>
        internal FileSystem() { }

        /// <summary>
        /// Deserializes XML into a new FileSystem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FileSystem instance.</returns>
        internal static Azure.Storage.Files.DataLake.Models.FileSystem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.DataLake.Models.FileSystem _value = new Azure.Storage.Files.DataLake.Models.FileSystem();
            _child = element.Element(System.Xml.Linq.XName.Get("name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("lastModified", ""));
            if (_child != null)
            {
                _value.LastModified = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("eTag", ""));
            if (_child != null)
            {
                _value.ETag = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.DataLake.Models.FileSystem value);
    }
}
#endregion class FileSystem

#region class FileSystemCreateResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystem CreateResult
    /// </summary>
    internal partial class FileSystemCreateResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the FileSystem.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the filesystem was last modified.  Operations on files and directories do not affect the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A bool string indicates whether the namespace feature is enabled. If "true", the namespace is enabled for the filesystem.
        /// </summary>
        public string NamespaceEnabled { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemCreateResult instances.
        /// You can use DataLakeModelFactory.FileSystemCreateResult instead.
        /// </summary>
        internal FileSystemCreateResult() { }
    }
}
#endregion class FileSystemCreateResult

#region class FileSystemGetPropertiesResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystem GetPropertiesResult
    /// </summary>
    internal partial class FileSystemGetPropertiesResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the filesystem.  Changes to filesystem properties affect the entity tag, but operations on files and directories do not.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the filesystem was last modified.  Changes to filesystem properties update the last modified time, but operations on files and directories do not.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The user-defined properties associated with the filesystem.  A comma-separated list of name and value pairs in the format "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.
        /// </summary>
        public string Properties { get; internal set; }

        /// <summary>
        /// A bool string indicates whether the namespace feature is enabled. If "true", the namespace is enabled for the filesystem.
        /// </summary>
        public string NamespaceEnabled { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemGetPropertiesResult instances.
        /// You can use DataLakeModelFactory.FileSystemGetPropertiesResult instead.
        /// </summary>
        internal FileSystemGetPropertiesResult() { }
    }
}
#endregion class FileSystemGetPropertiesResult

#region class FileSystemListPathsResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystem ListPathsResult
    /// </summary>
    internal partial class FileSystemListPathsResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the filesystem.  Changes to filesystem properties affect the entity tag, but operations on files and directories do not.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the filesystem was last modified.  Changes to filesystem properties update the last modified time, but operations on files and directories do not.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If the number of paths to be listed exceeds the maxResults limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the list operation to continue listing the paths.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public System.IO.Stream Body { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemListPathsResult instances.
        /// You can use DataLakeModelFactory.FileSystemListPathsResult instead.
        /// </summary>
        internal FileSystemListPathsResult() { }
    }
}
#endregion class FileSystemListPathsResult

#region class FileSystemSetPropertiesResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystem SetPropertiesResult
    /// </summary>
    internal partial class FileSystemSetPropertiesResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the filesystem.  Changes to filesystem properties affect the entity tag, but operations on files and directories do not.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the filesystem was last modified.  Changes to filesystem properties update the last modified time, but operations on files and directories do not.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileSystemSetPropertiesResult instances.
        /// You can use DataLakeModelFactory.FileSystemSetPropertiesResult instead.
        /// </summary>
        internal FileSystemSetPropertiesResult() { }
    }
}
#endregion class FileSystemSetPropertiesResult

#region class FileSystemList
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystemList
    /// </summary>
    internal partial class FileSystemList
    {
        /// <summary>
        /// filesystems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.DataLake.Models.FileSystem> Filesystems { get; internal set; }

        /// <summary>
        /// Creates a new FileSystemList instance
        /// </summary>
        public FileSystemList()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new FileSystemList instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal FileSystemList(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Filesystems = new System.Collections.Generic.List<Azure.Storage.Files.DataLake.Models.FileSystem>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new FileSystemList instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FileSystemList instance.</returns>
        internal static Azure.Storage.Files.DataLake.Models.FileSystemList FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Files.DataLake.Models.FileSystemList _value = new Azure.Storage.Files.DataLake.Models.FileSystemList(true);
            _value.Filesystems = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("FileSystem", "")),
                    e => Azure.Storage.Files.DataLake.Models.FileSystem.FromXml(e)));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.DataLake.Models.FileSystemList value);
    }
}
#endregion class FileSystemList

#region class Path
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path
    /// </summary>
    internal partial class Path
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// isDirectory
        /// </summary>
        public bool? IsDirectory { get; internal set; }

        /// <summary>
        /// lastModified
        /// </summary>
        public string LastModified { get; internal set; }

        /// <summary>
        /// eTag
        /// </summary>
        public string ETag { get; internal set; }

        /// <summary>
        /// contentLength
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// owner
        /// </summary>
        public string Owner { get; internal set; }

        /// <summary>
        /// group
        /// </summary>
        public string Group { get; internal set; }

        /// <summary>
        /// permissions
        /// </summary>
        public string Permissions { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of Path instances.
        /// You can use DataLakeModelFactory.Path instead.
        /// </summary>
        internal Path() { }
    }
}
#endregion class Path

#region class PathAppendDataResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path AppendDataResult
    /// </summary>
    internal partial class PathAppendDataResult
    {
        /// <summary>
        /// If a client request id header is sent in the request, this header will be present in the response with the same value.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathAppendDataResult instances.
        /// You can use DataLakeModelFactory.PathAppendDataResult instead.
        /// </summary>
        internal PathAppendDataResult() { }
    }
}
#endregion class PathAppendDataResult

#region class PathCreateResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path CreateResult
    /// </summary>
    internal partial class PathCreateResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// When renaming a directory, the number of paths that are renamed with each invocation is limited.  If the number of paths to be renamed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the rename operation to continue renaming the directory.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathCreateResult instances.
        /// You can use DataLakeModelFactory.PathCreateResult instead.
        /// </summary>
        internal PathCreateResult() { }
    }
}
#endregion class PathCreateResult

#region class PathDeleteResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path DeleteResult
    /// </summary>
    internal partial class PathDeleteResult
    {
        /// <summary>
        /// When deleting a directory, the number of paths that are deleted with each invocation is limited.  If the number of paths to be deleted exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the delete operation to continue deleting the directory.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathDeleteResult instances.
        /// You can use DataLakeModelFactory.PathDeleteResult instead.
        /// </summary>
        internal PathDeleteResult() { }
    }
}
#endregion class PathDeleteResult

#region class PathFlushDataResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path FlushDataResult
    /// </summary>
    internal partial class PathFlushDataResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// If a client request id header is sent in the request, this header will be present in the response with the same value.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathFlushDataResult instances.
        /// You can use DataLakeModelFactory.PathFlushDataResult instead.
        /// </summary>
        internal PathFlushDataResult() { }
    }
}
#endregion class PathFlushDataResult

#region class PathGetPropertiesResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path GetPropertiesResult
    /// </summary>
    internal partial class PathGetPropertiesResult
    {
        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// If the Content-Disposition request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Content-Language request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the file by setting the Range request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The content type specified for the resource. If no content type was specified, the default content type is application/octet-stream.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The MD5 hash of complete file stored in storage. This header is returned only for "GetProperties" operation. If the Content-MD5 header has been set for the file, this response header is returned for GetProperties call so that the client can check for message content integrity.
        /// </summary>
        public string ContentMD5 { get; internal set; }

        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The type of the resource.  The value may be "file" or "directory".  If not set, the value is "file".
        /// </summary>
        public string ResourceType { get; internal set; }

        /// <summary>
        /// The user-defined properties associated with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.
        /// </summary>
        public string Properties { get; internal set; }

        /// <summary>
        /// The owner of the file or directory. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Owner { get; internal set; }

        /// <summary>
        /// The owning group of the file or directory. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Group { get; internal set; }

        /// <summary>
        /// The POSIX access permissions for the file owner, the file owning group, and others. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Permissions { get; internal set; }

        /// <summary>
        /// The POSIX access control list for the file or directory.  Included in the response only if the action is "getAccessControl" and Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string ACL { get; internal set; }

        /// <summary>
        /// When a resource is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public string LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the resource.
        /// </summary>
        public string LeaseState { get; internal set; }

        /// <summary>
        /// The lease status of the resource.
        /// </summary>
        public string LeaseStatus { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathGetPropertiesResult instances.
        /// You can use DataLakeModelFactory.PathGetPropertiesResult instead.
        /// </summary>
        internal PathGetPropertiesResult() { }
    }
}
#endregion class PathGetPropertiesResult

#region class PathLeaseResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path LeaseResult
    /// </summary>
    internal partial class PathLeaseResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the file.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file was last modified.  Write operations on the file update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The time remaining in the lease period in seconds.
        /// </summary>
        public string LeaseTime { get; internal set; }

        /// <summary>
        /// A successful "renew" action returns the lease ID.
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathLeaseResult instances.
        /// You can use DataLakeModelFactory.PathLeaseResult instead.
        /// </summary>
        internal PathLeaseResult() { }
    }
}
#endregion class PathLeaseResult

#region class PathReadResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path ReadResult
    /// </summary>
    internal partial class PathReadResult
    {
        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// If the Content-Disposition request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Content-Language request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the file by setting the Range request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The content type specified for the resource. If no content type was specified, the default content type is application/octet-stream.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The MD5 hash of complete file. If the file has an MD5 hash and this read operation is to read the complete file, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        public string ContentMD5 { get; internal set; }

        /// <summary>
        /// The MD5 hash of complete file stored in storage. If the file has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the complete file's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range.
        /// </summary>
        public string XMSContentMd5 { get; internal set; }

        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The type of the resource.  The value may be "file" or "directory".  If not set, the value is "file".
        /// </summary>
        public string ResourceType { get; internal set; }

        /// <summary>
        /// The user-defined properties associated with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.
        /// </summary>
        public string Properties { get; internal set; }

        /// <summary>
        /// When a resource is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public string LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the resource.
        /// </summary>
        public string LeaseState { get; internal set; }

        /// <summary>
        /// The lease status of the resource.
        /// </summary>
        public string LeaseStatus { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public System.IO.Stream Body { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathReadResult instances.
        /// You can use DataLakeModelFactory.PathReadResult instead.
        /// </summary>
        internal PathReadResult() { }
    }
}
#endregion class PathReadResult

#region class PathSetAccessControlRecursiveResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path SetAccessControlRecursiveResult
    /// </summary>
    internal partial class PathSetAccessControlRecursiveResult
    {
        /// <summary>
        /// If a client request id header is sent in the request, this header will be present in the response with the same value.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// When performing setAccessControlRecursive on a directory, the number of paths that are processed with each invocation is limited.  If the number of paths to be processed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the setAccessControlRecursive operation to continue the setAccessControlRecursive operation on the directory.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public System.IO.Stream Body { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathSetAccessControlRecursiveResult instances.
        /// You can use DataLakeModelFactory.PathSetAccessControlRecursiveResult instead.
        /// </summary>
        internal PathSetAccessControlRecursiveResult() { }
    }
}
#endregion class PathSetAccessControlRecursiveResult

#region class PathSetAccessControlResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path SetAccessControlResult
    /// </summary>
    internal partial class PathSetAccessControlResult
    {
        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified. Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If a client request id header is sent in the request, this header will be present in the response with the same value.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathSetAccessControlResult instances.
        /// You can use DataLakeModelFactory.PathSetAccessControlResult instead.
        /// </summary>
        internal PathSetAccessControlResult() { }
    }
}
#endregion class PathSetAccessControlResult

#region class PathUpdateResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Path UpdateResult
    /// </summary>
    internal partial class PathUpdateResult
    {
        /// <summary>
        /// An MD5 hash of the request content. This header is only returned for "Flush" operation. This header is returned so that the client can check for message content integrity. This header refers to the content of the request, not actual file content.
        /// </summary>
        public string ContentMD5 { get; internal set; }

        /// <summary>
        /// An HTTP entity tag associated with the file or directory.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The data and time the file or directory was last modified.  Write operations on the file or directory update the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// If the Content-Disposition request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Content-Language request header has previously been set for the resource, that value is returned in this header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// The size of the resource in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the file by setting the Range request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The content type specified for the resource. If no content type was specified, the default content type is application/octet-stream.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// User-defined properties associated with the file or directory, in the format of a comma-separated list of name and value pairs "n1=v1, n2=v2, ...", where each value is a base64 encoded string. Note that the string may only contain ASCII characters in the ISO-8859-1 character set.
        /// </summary>
        public string Properties { get; internal set; }

        /// <summary>
        /// When performing setAccessControlRecursive on a directory, the number of paths that are processed with each invocation is limited.  If the number of paths to be processed exceeds this limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the setAccessControlRecursive operation to continue the setAccessControlRecursive operation on the directory.
        /// </summary>
        public string XMSContinuation { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse Body { get; internal set; }

        /// <summary>
        /// Creates a new PathUpdateResult instance
        /// </summary>
        public PathUpdateResult()
        {
            Body = new Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse();
        }
    }
}
#endregion class PathUpdateResult

#region enum strings PathExpiryOptions
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Required. Indicates mode of the expiry time
    /// </summary>
    internal readonly struct PathExpiryOptions : System.IEquatable<PathExpiryOptions>
    {
        /// <summary>
        /// The PathExpiryOptions value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathExpiryOptions"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public PathExpiryOptions(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }

        /// <summary>
        /// NeverExpire
        /// </summary>
        public static Azure.Storage.Files.DataLake.Models.PathExpiryOptions NeverExpire { get; } = new PathExpiryOptions(@"NeverExpire");

        /// <summary>
        /// RelativeToCreation
        /// </summary>
        public static Azure.Storage.Files.DataLake.Models.PathExpiryOptions RelativeToCreation { get; } = new PathExpiryOptions(@"RelativeToCreation");

        /// <summary>
        /// RelativeToNow
        /// </summary>
        public static Azure.Storage.Files.DataLake.Models.PathExpiryOptions RelativeToNow { get; } = new PathExpiryOptions(@"RelativeToNow");

        /// <summary>
        /// Absolute
        /// </summary>
        public static Azure.Storage.Files.DataLake.Models.PathExpiryOptions Absolute { get; } = new PathExpiryOptions(@"Absolute");

        /// <summary>
        /// Determines if two <see cref="PathExpiryOptions"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="PathExpiryOptions"/> to compare.</param>
        /// <param name="right">The second <see cref="PathExpiryOptions"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(Azure.Storage.Files.DataLake.Models.PathExpiryOptions left, Azure.Storage.Files.DataLake.Models.PathExpiryOptions right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="PathExpiryOptions"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="PathExpiryOptions"/> to compare.</param>
        /// <param name="right">The second <see cref="PathExpiryOptions"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(Azure.Storage.Files.DataLake.Models.PathExpiryOptions left, Azure.Storage.Files.DataLake.Models.PathExpiryOptions right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="PathExpiryOptions"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The PathExpiryOptions value.</returns>
        public static implicit operator PathExpiryOptions(string value) => new Azure.Storage.Files.DataLake.Models.PathExpiryOptions(value);

        /// <summary>
        /// Check if two <see cref="PathExpiryOptions"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Azure.Storage.Files.DataLake.Models.PathExpiryOptions other && Equals(other);

        /// <summary>
        /// Check if two <see cref="PathExpiryOptions"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Files.DataLake.Models.PathExpiryOptions other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

        /// <summary>
        /// Get a hash code for the <see cref="PathExpiryOptions"/>.
        /// </summary>
        /// <returns>Hash code for the PathExpiryOptions.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// Convert the <see cref="PathExpiryOptions"/> to a string.
        /// </summary>
        /// <returns>String representation of the PathExpiryOptions.</returns>
        public override string ToString() => _value;
    }
}
#endregion enum strings PathExpiryOptions

#region enum PathGetPropertiesAction
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional. If the value is "getStatus" only the system defined properties for the path are returned. If the value is "getAccessControl" the access control list is returned in the response headers (Hierarchical Namespace must be enabled for the account), otherwise the properties are returned.
    /// </summary>
    public enum PathGetPropertiesAction
    {
        /// <summary>
        /// getAccessControl
        /// </summary>
        GetAccessControl,

        /// <summary>
        /// getStatus
        /// </summary>
        GetStatus
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction.GetAccessControl => "getAccessControl",
                    Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction.GetStatus => "getStatus",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction ParsePathGetPropertiesAction(string value)
            {
                return value switch
                {
                    "getAccessControl" => Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction.GetAccessControl,
                    "getStatus" => Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction.GetStatus,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathGetPropertiesAction value.")
                };
            }
        }
    }
}
#endregion enum PathGetPropertiesAction

#region enum PathLeaseAction
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// There are five lease actions: "acquire", "break", "change", "renew", and "release". Use "acquire" and specify the "x-ms-proposed-lease-id" and "x-ms-lease-duration" to acquire a new lease. Use "break" to break an existing lease. When a lease is broken, the lease break period is allowed to elapse, during which time no lease operation except break and release can be performed on the file. When a lease is successfully broken, the response indicates the interval in seconds until a new lease can be acquired. Use "change" and specify the current lease ID in "x-ms-lease-id" and the new lease ID in "x-ms-proposed-lease-id" to change the lease ID of an active lease. Use "renew" and specify the "x-ms-lease-id" to renew an existing lease. Use "release" and specify the "x-ms-lease-id" to release a lease.
    /// </summary>
    public enum PathLeaseAction
    {
        /// <summary>
        /// acquire
        /// </summary>
        Acquire,

        /// <summary>
        /// break
        /// </summary>
        Break,

        /// <summary>
        /// change
        /// </summary>
        Change,

        /// <summary>
        /// renew
        /// </summary>
        Renew,

        /// <summary>
        /// release
        /// </summary>
        Release
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathLeaseAction value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathLeaseAction.Acquire => "acquire",
                    Azure.Storage.Files.DataLake.Models.PathLeaseAction.Break => "break",
                    Azure.Storage.Files.DataLake.Models.PathLeaseAction.Change => "change",
                    Azure.Storage.Files.DataLake.Models.PathLeaseAction.Renew => "renew",
                    Azure.Storage.Files.DataLake.Models.PathLeaseAction.Release => "release",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathLeaseAction value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathLeaseAction ParsePathLeaseAction(string value)
            {
                return value switch
                {
                    "acquire" => Azure.Storage.Files.DataLake.Models.PathLeaseAction.Acquire,
                    "break" => Azure.Storage.Files.DataLake.Models.PathLeaseAction.Break,
                    "change" => Azure.Storage.Files.DataLake.Models.PathLeaseAction.Change,
                    "renew" => Azure.Storage.Files.DataLake.Models.PathLeaseAction.Renew,
                    "release" => Azure.Storage.Files.DataLake.Models.PathLeaseAction.Release,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathLeaseAction value.")
                };
            }
        }
    }
}
#endregion enum PathLeaseAction

#region class PathList
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// PathList
    /// </summary>
    internal partial class PathList
    {
        /// <summary>
        /// paths
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.DataLake.Models.Path> Paths { get; internal set; }

        /// <summary>
        /// Creates a new PathList instance
        /// </summary>
        public PathList()
        {
            Paths = new System.Collections.Generic.List<Azure.Storage.Files.DataLake.Models.Path>();
        }
    }
}
#endregion class PathList

#region enum PathRenameMode
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional. Valid only when namespace is enabled. This parameter determines the behavior of the rename operation. The value must be "legacy" or "posix", and the default value will be "posix".
    /// </summary>
    public enum PathRenameMode
    {
        /// <summary>
        /// legacy
        /// </summary>
        Legacy,

        /// <summary>
        /// posix
        /// </summary>
        Posix
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathRenameMode value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathRenameMode.Legacy => "legacy",
                    Azure.Storage.Files.DataLake.Models.PathRenameMode.Posix => "posix",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathRenameMode value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathRenameMode ParsePathRenameMode(string value)
            {
                return value switch
                {
                    "legacy" => Azure.Storage.Files.DataLake.Models.PathRenameMode.Legacy,
                    "posix" => Azure.Storage.Files.DataLake.Models.PathRenameMode.Posix,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathRenameMode value.")
                };
            }
        }
    }
}
#endregion enum PathRenameMode

#region enum PathResourceType
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Required only for Create File and Create Directory. The value must be "file" or "directory".
    /// </summary>
    public enum PathResourceType
    {
        /// <summary>
        /// directory
        /// </summary>
        Directory,

        /// <summary>
        /// file
        /// </summary>
        File
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathResourceType value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathResourceType.Directory => "directory",
                    Azure.Storage.Files.DataLake.Models.PathResourceType.File => "file",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathResourceType value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathResourceType ParsePathResourceType(string value)
            {
                return value switch
                {
                    "directory" => Azure.Storage.Files.DataLake.Models.PathResourceType.Directory,
                    "file" => Azure.Storage.Files.DataLake.Models.PathResourceType.File,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathResourceType value.")
                };
            }
        }
    }
}
#endregion enum PathResourceType

#region enum PathSetAccessControlRecursiveMode
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Mode "set" sets POSIX access control rights on files and directories, "modify" modifies one or more POSIX access control rights  that pre-exist on files and directories, "remove" removes one or more POSIX access control rights  that were present earlier on files and directories
    /// </summary>
    internal enum PathSetAccessControlRecursiveMode
    {
        /// <summary>
        /// set
        /// </summary>
        Set,

        /// <summary>
        /// modify
        /// </summary>
        Modify,

        /// <summary>
        /// remove
        /// </summary>
        Remove
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Set => "set",
                    Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Modify => "modify",
                    Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Remove => "remove",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode ParsePathSetAccessControlRecursiveMode(string value)
            {
                return value switch
                {
                    "set" => Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Set,
                    "modify" => Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Modify,
                    "remove" => Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode.Remove,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathSetAccessControlRecursiveMode value.")
                };
            }
        }
    }
}
#endregion enum PathSetAccessControlRecursiveMode

#region class PathSetExpiryInternal
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// PathSetExpiryInternal
    /// </summary>
    internal partial class PathSetExpiryInternal
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If a client request id header is sent in the request, this header will be present in the response with the same value.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathSetExpiryInternal instances.
        /// You can use DataLakeModelFactory.PathSetExpiryInternal instead.
        /// </summary>
        internal PathSetExpiryInternal() { }
    }
}
#endregion class PathSetExpiryInternal

#region enum PathUpdateAction
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The action must be "append" to upload data to be appended to a file, "flush" to flush previously uploaded data to a file, "setProperties" to set the properties of a file or directory, "setAccessControl" to set the owner, group, permissions, or access control list for a file or directory, or  "setAccessControlRecursive" to set the access control list for a directory recursively. Note that Hierarchical Namespace must be enabled for the account in order to use access control.  Also note that the Access Control List (ACL) includes permissions for the owner, owning group, and others, so the x-ms-permissions and x-ms-acl request headers are mutually exclusive.
    /// </summary>
    public enum PathUpdateAction
    {
        /// <summary>
        /// append
        /// </summary>
        Append,

        /// <summary>
        /// flush
        /// </summary>
        Flush,

        /// <summary>
        /// setProperties
        /// </summary>
        SetProperties,

        /// <summary>
        /// setAccessControl
        /// </summary>
        SetAccessControl,

        /// <summary>
        /// setAccessControlRecursive
        /// </summary>
        SetAccessControlRecursive
    }
}

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.DataLake.Models.PathUpdateAction value)
            {
                return value switch
                {
                    Azure.Storage.Files.DataLake.Models.PathUpdateAction.Append => "append",
                    Azure.Storage.Files.DataLake.Models.PathUpdateAction.Flush => "flush",
                    Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetProperties => "setProperties",
                    Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetAccessControl => "setAccessControl",
                    Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetAccessControlRecursive => "setAccessControlRecursive",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathUpdateAction value.")
                };
            }

            public static Azure.Storage.Files.DataLake.Models.PathUpdateAction ParsePathUpdateAction(string value)
            {
                return value switch
                {
                    "append" => Azure.Storage.Files.DataLake.Models.PathUpdateAction.Append,
                    "flush" => Azure.Storage.Files.DataLake.Models.PathUpdateAction.Flush,
                    "setProperties" => Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetProperties,
                    "setAccessControl" => Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetAccessControl,
                    "setAccessControlRecursive" => Azure.Storage.Files.DataLake.Models.PathUpdateAction.SetAccessControlRecursive,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.DataLake.Models.PathUpdateAction value.")
                };
            }
        }
    }
}
#endregion enum PathUpdateAction

#region class ServiceListFileSystemsResult
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Service ListFileSystemsResult
    /// </summary>
    internal partial class ServiceListFileSystemsResult
    {
        /// <summary>
        /// If the number of filesystems to be listed exceeds the maxResults limit, a continuation token is returned in this response header.  When a continuation token is returned in the response, it must be specified in a subsequent invocation of the list operation to continue listing the filesystems.
        /// </summary>
        public string Continuation { get; internal set; }

        /// <summary>
        /// The content type of list filesystem response. The default content type is application/json.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public Azure.Storage.Files.DataLake.Models.FileSystemList Body { get; internal set; }

        /// <summary>
        /// Creates a new ServiceListFileSystemsResult instance
        /// </summary>
        public ServiceListFileSystemsResult()
        {
            Body = new Azure.Storage.Files.DataLake.Models.FileSystemList();
        }
    }
}
#endregion class ServiceListFileSystemsResult

#region class SetAccessControlRecursiveResponse
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// SetAccessControlRecursiveResponse
    /// </summary>
    internal partial class SetAccessControlRecursiveResponse
    {
        /// <summary>
        /// directoriesSuccessful
        /// </summary>
        public int? DirectoriesSuccessful { get; internal set; }

        /// <summary>
        /// filesSuccessful
        /// </summary>
        public int? FilesSuccessful { get; internal set; }

        /// <summary>
        /// failureCount
        /// </summary>
        public int? FailureCount { get; internal set; }

        /// <summary>
        /// failedEntries
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.DataLake.Models.AclFailedEntry> FailedEntries { get; internal set; }

        /// <summary>
        /// Creates a new SetAccessControlRecursiveResponse instance
        /// </summary>
        public SetAccessControlRecursiveResponse()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new SetAccessControlRecursiveResponse instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal SetAccessControlRecursiveResponse(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                FailedEntries = new System.Collections.Generic.List<Azure.Storage.Files.DataLake.Models.AclFailedEntry>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new SetAccessControlRecursiveResponse instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SetAccessControlRecursiveResponse instance.</returns>
        internal static Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse _value = new Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse(true);
            _child = element.Element(System.Xml.Linq.XName.Get("directoriesSuccessful", ""));
            if (_child != null)
            {
                _value.DirectoriesSuccessful = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("filesSuccessful", ""));
            if (_child != null)
            {
                _value.FilesSuccessful = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("failureCount", ""));
            if (_child != null)
            {
                _value.FailureCount = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _value.FailedEntries = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("AclFailedEntry", "")),
                    e => Azure.Storage.Files.DataLake.Models.AclFailedEntry.FromXml(e)));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.DataLake.Models.SetAccessControlRecursiveResponse value);
    }
}
#endregion class SetAccessControlRecursiveResponse
#endregion Models


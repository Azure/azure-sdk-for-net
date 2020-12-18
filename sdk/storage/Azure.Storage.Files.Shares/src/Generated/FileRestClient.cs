// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file was automatically generated.  Do not edit.

#pragma warning disable IDE0016 // Null check can be simplified
#pragma warning disable IDE0017 // Variable declaration can be inlined
#pragma warning disable IDE0018 // Object initialization can be simplified
#pragma warning disable SA1402  // File may only contain a single type

#region Service
namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// Azure File Storage
    /// </summary>
    internal static partial class FileRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure File Storage
        /// </summary>
        public static partial class Service
        {
            #region Service.SetPropertiesAsync
            /// <summary>
            /// Sets properties for a storage account's File service endpoint, including properties for Storage Analytics metrics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Files.Shares.Models.ShareServiceProperties properties,
                string version,
                int? timeout = default,
                bool async = true,
                string operationName = "ServiceClient.SetProperties",
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
                        properties,
                        version,
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
            /// Create the Service.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Service.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Files.Shares.Models.ShareServiceProperties properties,
                string version,
                int? timeout = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (properties == null)
                {
                    throw new System.ArgumentNullException(nameof(properties));
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
                _request.Uri.AppendQuery("restype", "service", escapeValue: false);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Files.Shares.Models.ShareServiceProperties.ToXml(properties, "StorageServiceProperties", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _message;
            }

            /// <summary>
            /// Create the Service.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.SetPropertiesAsync Azure.Response.</returns>
            internal static Azure.Response SetPropertiesAsync_CreateResponse(
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.SetPropertiesAsync

            #region Service.GetPropertiesAsync
            /// <summary>
            /// Gets the properties of a storage account's File service, including properties for Storage Analytics metrics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Storage service properties.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareServiceProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                bool async = true,
                string operationName = "ServiceClient.GetProperties",
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
            /// Create the Service.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Service.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
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
                _request.Uri.AppendQuery("restype", "service", escapeValue: false);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Service.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareServiceProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareServiceProperties> GetPropertiesAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.ShareServiceProperties _value = Azure.Storage.Files.Shares.Models.ShareServiceProperties.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.ShareServiceProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.GetPropertiesAsync

            #region Service.ListSharesSegmentAsync
            /// <summary>
            /// The List Shares Segment operation returns a list of the shares and share snapshots under the specified account.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only entries whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of shares.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.SharesSegment>> ListSharesSegmentAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ListSharesIncludeType> include = default,
                int? timeout = default,
                bool async = true,
                string operationName = "ServiceClient.ListSharesSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListSharesSegmentAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        prefix,
                        marker,
                        maxresults,
                        include,
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
                        return ListSharesSegmentAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Service.ListSharesSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only entries whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Service.ListSharesSegmentAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListSharesSegmentAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ListSharesIncludeType> include = default,
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
                _request.Uri.AppendQuery("comp", "list", escapeValue: false);
                if (prefix != null) { _request.Uri.AppendQuery("prefix", prefix); }
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (maxresults != null) { _request.Uri.AppendQuery("maxresults", maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (include != null) { _request.Uri.AppendQuery("include", string.Join(",", System.Linq.Enumerable.Select(include, item => Azure.Storage.Files.Shares.FileRestClient.Serialization.ToString(item)))); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Service.ListSharesSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListSharesSegmentAsync Azure.Response{Azure.Storage.Files.Shares.Models.SharesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.SharesSegment> ListSharesSegmentAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.SharesSegment _value = Azure.Storage.Files.Shares.Models.SharesSegment.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.SharesSegment>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.ListSharesSegmentAsync
        }
        #endregion Service operations

        #region Share operations
        /// <summary>
        /// Share operations for Azure File Storage
        /// </summary>
        public static partial class Share
        {
            #region Share.CreateAsync
            /// <summary>
            /// Creates a new share under the specified account. If the share with the same name already exists, the operation fails.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="quotaInGB">Specifies the maximum size of the share, in gigabytes.</param>
            /// <param name="accessTier">Specifies the access tier of the share.</param>
            /// <param name="enabledProtocols">Protocols to enable on the share.</param>
            /// <param name="rootSquash">Root squash to set on the share.  Only valid for NFS shares.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                int? quotaInGB = default,
                Azure.Storage.Files.Shares.Models.ShareAccessTier? accessTier = default,
                string enabledProtocols = default,
                Azure.Storage.Files.Shares.Models.ShareRootSquash? rootSquash = default,
                bool async = true,
                string operationName = "ShareClient.Create",
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
                        timeout,
                        metadata,
                        quotaInGB,
                        accessTier,
                        enabledProtocols,
                        rootSquash))
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
            /// Create the Share.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="quotaInGB">Specifies the maximum size of the share, in gigabytes.</param>
            /// <param name="accessTier">Specifies the access tier of the share.</param>
            /// <param name="enabledProtocols">Protocols to enable on the share.</param>
            /// <param name="rootSquash">Root squash to set on the share.  Only valid for NFS shares.</param>
            /// <returns>The Share.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                int? quotaInGB = default,
                Azure.Storage.Files.Shares.Models.ShareAccessTier? accessTier = default,
                string enabledProtocols = default,
                Azure.Storage.Files.Shares.Models.ShareRootSquash? rootSquash = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (quotaInGB != null) { _request.Headers.SetValue("x-ms-share-quota", quotaInGB.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (accessTier != null) { _request.Headers.SetValue("x-ms-access-tier", accessTier.ToString()); }
                if (enabledProtocols != null) { _request.Headers.SetValue("x-ms-enabled-protocols", enabledProtocols); }
                if (rootSquash != null) { _request.Headers.SetValue("x-ms-root-squash", rootSquash.Value.ToString()); }

                return _message;
            }

            /// <summary>
            /// Create the Share.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.CreateAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareInfo _value = new Azure.Storage.Files.Shares.Models.ShareInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.CreateAsync

            #region Share.GetPropertiesAsync
            /// <summary>
            /// Returns all user-defined metadata and system properties for the specified share or share snapshot. The data returned does not include the share's list of files.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Properties of a share.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.SharePropertiesInternal>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.GetProperties",
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
                        sharesnapshot,
                        timeout,
                        leaseId))
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
            /// Create the Share.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.GetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.SharePropertiesInternal}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.SharePropertiesInternal> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.SharePropertiesInternal _value = new Azure.Storage.Files.Shares.Models.SharePropertiesInternal();

                        // Get response headers
                        string _header;
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-share-quota", out _header))
                        {
                            _value.QuotaInGB = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-share-provisioned-iops", out _header))
                        {
                            _value.ProvisionedIops = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-share-provisioned-ingress-mbps", out _header))
                        {
                            _value.ProvisionedIngressMBps = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-share-provisioned-egress-mbps", out _header))
                        {
                            _value.ProvisionedEgressMBps = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-share-next-allowed-quota-downgrade-time", out _header))
                        {
                            _value.NextAllowedQuotaDowngradeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseDuration(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier", out _header))
                        {
                            _value.AccessTier = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier-change-time", out _header))
                        {
                            _value.AccessTierChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier-transition-state", out _header))
                        {
                            _value.AccessTierTransitionState = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-enabled-protocols", out _header))
                        {
                            _value.EnabledProtocols = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-root-squash", out _header))
                        {
                            _value.RootSquash = (Azure.Storage.Files.Shares.Models.ShareRootSquash)System.Enum.Parse(typeof(Azure.Storage.Files.Shares.Models.ShareRootSquash), _header, false);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.SharePropertiesInternal>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.GetPropertiesAsync

            #region Share.DeleteAsync
            /// <summary>
            /// Operation marks the specified share or share snapshot for deletion. The share or share snapshot and any files contained within it are later deleted during garbage collection.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="deleteSnapshots">Specifies the option include to delete the base share and all of its snapshots.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal? deleteSnapshots = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.Delete",
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
                        sharesnapshot,
                        timeout,
                        deleteSnapshots,
                        leaseId))
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
            /// Create the Share.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="deleteSnapshots">Specifies the option include to delete the base share and all of its snapshots.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal? deleteSnapshots = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (deleteSnapshots != null) { _request.Headers.SetValue("x-ms-delete-snapshots", Azure.Storage.Files.Shares.FileRestClient.Serialization.ToString(deleteSnapshots.Value)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.DeleteAsync Azure.Response.</returns>
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.DeleteAsync

            #region Share.AcquireLeaseAsync
            /// <summary>
            /// The Lease Share operation establishes and manages a lock on a share, or the specified snapshot for set and delete share operations.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> AcquireLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                string sharesnapshot = default,
                string requestId = default,
                bool async = true,
                string operationName = "ShareClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = AcquireLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        duration,
                        proposedLeaseId,
                        sharesnapshot,
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
                        return AcquireLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Share.AcquireLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage AcquireLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                string sharesnapshot = default,
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
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                _request.Headers.SetValue("x-ms-version", version);
                if (duration != null) { _request.Headers.SetValue("x-ms-lease-duration", duration.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.AcquireLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> AcquireLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileLease _value = new Azure.Storage.Files.Shares.Models.ShareFileLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.AcquireLeaseAsync

            #region Share.ReleaseLeaseAsync
            /// <summary>
            /// The Lease Share operation establishes and manages a lock on a share, or the specified snapshot for set and delete share operations.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo>> ReleaseLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string sharesnapshot = default,
                string requestId = default,
                bool async = true,
                string operationName = "ShareClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ReleaseLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        leaseId,
                        version,
                        timeout,
                        sharesnapshot,
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
                        return ReleaseLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Share.ReleaseLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage ReleaseLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string sharesnapshot = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (leaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(leaseId));
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.ReleaseLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo> ReleaseLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo _value = new Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.ReleaseLeaseAsync

            #region Share.ChangeLeaseAsync
            /// <summary>
            /// The Lease Share operation establishes and manages a lock on a share, or the specified snapshot for set and delete share operations.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> ChangeLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string proposedLeaseId = default,
                string sharesnapshot = default,
                string requestId = default,
                bool async = true,
                string operationName = "ShareClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ChangeLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        leaseId,
                        version,
                        timeout,
                        proposedLeaseId,
                        sharesnapshot,
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
                        return ChangeLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Share.ChangeLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage ChangeLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string proposedLeaseId = default,
                string sharesnapshot = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (leaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(leaseId));
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", version);
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.ChangeLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> ChangeLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileLease _value = new Azure.Storage.Files.Shares.Models.ShareFileLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.ChangeLeaseAsync

            #region Share.RenewLeaseAsync
            /// <summary>
            /// The Lease Share operation establishes and manages a lock on a share, or the specified snapshot for set and delete share operations.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> RenewLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string sharesnapshot = default,
                string requestId = default,
                bool async = true,
                string operationName = "ShareClient.RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = RenewLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        leaseId,
                        version,
                        timeout,
                        sharesnapshot,
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
                        return RenewLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.RenewLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Share.RenewLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage RenewLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string sharesnapshot = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (leaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(leaseId));
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.RenewLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.RenewLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> RenewLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileLease _value = new Azure.Storage.Files.Shares.Models.ShareFileLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.RenewLeaseAsync

            #region Share.BreakLeaseAsync
            /// <summary>
            /// The Lease Share operation establishes and manages a lock on a share, or the specified snapshot for set and delete share operations.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.BrokenLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.BrokenLease>> BreakLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? breakPeriod = default,
                string leaseId = default,
                string requestId = default,
                string sharesnapshot = default,
                bool async = true,
                string operationName = "ShareClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = BreakLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        breakPeriod,
                        leaseId,
                        requestId,
                        sharesnapshot))
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
                        return BreakLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <returns>The Share.BreakLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage BreakLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? breakPeriod = default,
                string leaseId = default,
                string requestId = default,
                string sharesnapshot = default)
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                _request.Headers.SetValue("x-ms-version", version);
                if (breakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", breakPeriod.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.BreakLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.BrokenLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.BrokenLease> BreakLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.BrokenLease _value = new Azure.Storage.Files.Shares.Models.BrokenLease();

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
                            _value.LeaseTime = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-id", out _header))
                        {
                            _value.LeaseId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.BreakLeaseAsync

            #region Share.CreateSnapshotAsync
            /// <summary>
            /// Creates a read-only snapshot of a share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareSnapshotInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareSnapshotInfo>> CreateSnapshotAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                bool async = true,
                string operationName = "ShareClient.CreateSnapshot",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = CreateSnapshotAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        metadata))
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
                        return CreateSnapshotAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.CreateSnapshotAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <returns>The Share.CreateSnapshotAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateSnapshotAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "snapshot", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }

                return _message;
            }

            /// <summary>
            /// Create the Share.CreateSnapshotAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.CreateSnapshotAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareSnapshotInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareSnapshotInfo> CreateSnapshotAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareSnapshotInfo _value = new Azure.Storage.Files.Shares.Models.ShareSnapshotInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-snapshot", out _header))
                        {
                            _value.Snapshot = _header;
                        }
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.CreateSnapshotAsync

            #region Share.CreatePermissionAsync
            /// <summary>
            /// Create a permission (a security descriptor).
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharePermissionJson">A permission (a security descriptor) at the share level.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.PermissionInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.PermissionInfo>> CreatePermissionAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharePermissionJson,
                int? timeout = default,
                bool async = true,
                string operationName = "ShareClient.CreatePermission",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = CreatePermissionAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        sharePermissionJson,
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
                        return CreatePermissionAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.CreatePermissionAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharePermissionJson">A permission (a security descriptor) at the share level.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Share.CreatePermissionAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreatePermissionAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharePermissionJson,
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
                if (sharePermissionJson == null)
                {
                    throw new System.ArgumentNullException(nameof(sharePermissionJson));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "filepermission", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                // Create the body
                string _text = sharePermissionJson;
                _request.Headers.SetValue("Content-Type", "application/json");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _message;
            }

            /// <summary>
            /// Create the Share.CreatePermissionAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.CreatePermissionAsync Azure.Response{Azure.Storage.Files.Shares.Models.PermissionInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.PermissionInfo> CreatePermissionAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.PermissionInfo _value = new Azure.Storage.Files.Shares.Models.PermissionInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.CreatePermissionAsync

            #region Share.GetPermissionAsync
            /// <summary>
            /// Returns the permission (security descriptor) for a given key
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>A permission (a security descriptor) at the share level.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<string>> GetPermissionAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string filePermissionKey,
                string version,
                int? timeout = default,
                bool async = true,
                string operationName = "ShareClient.GetPermission",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetPermissionAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        filePermissionKey,
                        version,
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
                        return GetPermissionAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.GetPermissionAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Share.GetPermissionAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPermissionAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string filePermissionKey,
                string version,
                int? timeout = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (filePermissionKey == null)
                {
                    throw new System.ArgumentNullException(nameof(filePermissionKey));
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "filepermission", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey);
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Share.GetPermissionAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.GetPermissionAsync Azure.Response{string}.</returns>
            internal static Azure.Response<string> GetPermissionAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        string _value;
                        using (System.IO.StreamReader _streamReader = new System.IO.StreamReader(response.ContentStream))
                        {
                            _value = _streamReader.ReadToEnd();
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<string>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.GetPermissionAsync

            #region Share.SetPropertiesAsync
            /// <summary>
            /// Sets properties for the specified share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="quotaInGB">Specifies the maximum size of the share, in gigabytes.</param>
            /// <param name="accessTier">Specifies the access tier of the share.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rootSquash">Root squash to set on the share.  Only valid for NFS shares.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                int? quotaInGB = default,
                Azure.Storage.Files.Shares.Models.ShareAccessTier? accessTier = default,
                string leaseId = default,
                Azure.Storage.Files.Shares.Models.ShareRootSquash? rootSquash = default,
                bool async = true,
                string operationName = "ShareClient.SetProperties",
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
                        timeout,
                        quotaInGB,
                        accessTier,
                        leaseId,
                        rootSquash))
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
            /// Create the Share.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="quotaInGB">Specifies the maximum size of the share, in gigabytes.</param>
            /// <param name="accessTier">Specifies the access tier of the share.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rootSquash">Root squash to set on the share.  Only valid for NFS shares.</param>
            /// <returns>The Share.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                int? quotaInGB = default,
                Azure.Storage.Files.Shares.Models.ShareAccessTier? accessTier = default,
                string leaseId = default,
                Azure.Storage.Files.Shares.Models.ShareRootSquash? rootSquash = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (quotaInGB != null) { _request.Headers.SetValue("x-ms-share-quota", quotaInGB.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (accessTier != null) { _request.Headers.SetValue("x-ms-access-tier", accessTier.ToString()); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (rootSquash != null) { _request.Headers.SetValue("x-ms-root-squash", rootSquash.Value.ToString()); }

                return _message;
            }

            /// <summary>
            /// Create the Share.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.SetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareInfo _value = new Azure.Storage.Files.Shares.Models.ShareInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.SetPropertiesAsync

            #region Share.SetMetadataAsync
            /// <summary>
            /// Sets one or more user-defined name-value pairs for the specified share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetMetadataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetMetadataAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        metadata,
                        leaseId))
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
                        return SetMetadataAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.SetMetadataAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetMetadataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "metadata", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.SetMetadataAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetMetadataAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareInfo _value = new Azure.Storage.Files.Shares.Models.ShareInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.SetMetadataAsync

            #region Share.GetAccessPolicyAsync
            /// <summary>
            /// Returns information about stored access policies specified on the share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>A collection of signed identifiers.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier>>> GetAccessPolicyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.GetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetAccessPolicyAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        leaseId))
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
                        return GetAccessPolicyAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.GetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.GetAccessPolicyAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetAccessPolicyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "acl", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.GetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.GetAccessPolicyAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Files.Shares.Models.ShareSignedIdentifier}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier>> GetAccessPolicyAsync_CreateResponse(
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
                        System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("SignedIdentifiers", "")).Elements(System.Xml.Linq.XName.Get("SignedIdentifier", "")),
                                    Azure.Storage.Files.Shares.Models.ShareSignedIdentifier.FromXml));

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier>>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.GetAccessPolicyAsync

            #region Share.SetAccessPolicyAsync
            /// <summary>
            /// Sets a stored access policy for use with shared access signatures.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="permissions">The ACL for the share.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetAccessPolicyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier> permissions = default,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.SetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetAccessPolicyAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        permissions,
                        timeout,
                        leaseId))
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
                        return SetAccessPolicyAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.SetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="permissions">The ACL for the share.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.SetAccessPolicyAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetAccessPolicyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier> permissions = default,
                int? timeout = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "acl", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                // Create the body
                System.Xml.Linq.XElement _body = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("SignedIdentifiers", ""));
                if (permissions != null)
                {
                    foreach (Azure.Storage.Files.Shares.Models.ShareSignedIdentifier _child in permissions)
                    {
                        _body.Add(Azure.Storage.Files.Shares.Models.ShareSignedIdentifier.ToXml(_child));
                    }
                }
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _message;
            }

            /// <summary>
            /// Create the Share.SetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.SetAccessPolicyAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetAccessPolicyAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareInfo _value = new Azure.Storage.Files.Shares.Models.ShareInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.SetAccessPolicyAsync

            #region Share.GetStatisticsAsync
            /// <summary>
            /// Retrieves statistics related to the share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Stats for the share.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareStatistics>> GetStatisticsAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "ShareClient.GetStatistics",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetStatisticsAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        leaseId))
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
                        return GetStatisticsAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.GetStatisticsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Share.GetStatisticsAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetStatisticsAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "stats", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the Share.GetStatisticsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.GetStatisticsAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareStatistics}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareStatistics> GetStatisticsAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.ShareStatistics _value = Azure.Storage.Files.Shares.Models.ShareStatistics.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.ShareStatistics>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.GetStatisticsAsync

            #region Share.RestoreAsync
            /// <summary>
            /// Restores a previously deleted Share.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="deletedShareName">Specifies the name of the preivously-deleted share.</param>
            /// <param name="deletedShareVersion">Specifies the version of the preivously-deleted share.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> RestoreAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                string deletedShareName = default,
                string deletedShareVersion = default,
                bool async = true,
                string operationName = "ShareClient.Restore",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = RestoreAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        requestId,
                        deletedShareName,
                        deletedShareVersion))
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
                        return RestoreAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Share.RestoreAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="deletedShareName">Specifies the name of the preivously-deleted share.</param>
            /// <param name="deletedShareVersion">Specifies the version of the preivously-deleted share.</param>
            /// <returns>The Share.RestoreAsync Message.</returns>
            internal static Azure.Core.HttpMessage RestoreAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                string deletedShareName = default,
                string deletedShareVersion = default)
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
                _request.Uri.AppendQuery("restype", "share", escapeValue: false);
                _request.Uri.AppendQuery("comp", "undelete", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (deletedShareName != null) { _request.Headers.SetValue("x-ms-deleted-share-name", deletedShareName); }
                if (deletedShareVersion != null) { _request.Headers.SetValue("x-ms-deleted-share-version", deletedShareVersion); }

                return _message;
            }

            /// <summary>
            /// Create the Share.RestoreAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Share.RestoreAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> RestoreAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareInfo _value = new Azure.Storage.Files.Shares.Models.ShareInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Share.RestoreAsync
        }
        #endregion Share operations

        #region Directory operations
        /// <summary>
        /// Directory operations for Azure File Storage
        /// </summary>
        public static partial class Directory
        {
            #region Directory.CreateAsync
            /// <summary>
            /// Creates a new directory under the specified share or parent directory.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo>> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default,
                bool async = true,
                string operationName = "DirectoryClient.Create",
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
                        fileAttributes,
                        fileCreationTime,
                        fileLastWriteTime,
                        timeout,
                        metadata,
                        filePermission,
                        filePermissionKey))
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
            /// Create the Directory.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <returns>The Directory.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default)
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
                if (fileAttributes == null)
                {
                    throw new System.ArgumentNullException(nameof(fileAttributes));
                }
                if (fileCreationTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileCreationTime));
                }
                if (fileLastWriteTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileLastWriteTime));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-file-attributes", fileAttributes);
                _request.Headers.SetValue("x-ms-file-creation-time", fileCreationTime);
                _request.Headers.SetValue("x-ms-file-last-write-time", fileLastWriteTime);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (filePermission != null) { _request.Headers.SetValue("x-ms-file-permission", filePermission); }
                if (filePermissionKey != null) { _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey); }

                return _message;
            }

            /// <summary>
            /// Create the Directory.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.CreateAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo> CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo();

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
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.CreateAsync

            #region Directory.GetPropertiesAsync
            /// <summary>
            /// Returns all system properties for the specified directory, and can also be used to check the existence of a directory. The data returned does not include the files in the directory or any subdirectories.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                bool async = true,
                string operationName = "DirectoryClient.GetProperties",
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
                        sharesnapshot,
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
            /// Create the Directory.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Directory.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
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
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Directory.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.GetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties _value = new Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties();

                        // Get response headers
                        string _header;
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.RawStorageDirectoryProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.GetPropertiesAsync

            #region Directory.DeleteAsync
            /// <summary>
            /// Removes the specified empty directory. Note that the directory must be empty before it can be deleted.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                bool async = true,
                string operationName = "DirectoryClient.Delete",
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
            /// Create the Directory.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Directory.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
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
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Directory.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.DeleteAsync Azure.Response.</returns>
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.DeleteAsync

            #region Directory.SetPropertiesAsync
            /// <summary>
            /// Sets properties on the directory.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo>> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                string filePermission = default,
                string filePermissionKey = default,
                bool async = true,
                string operationName = "DirectoryClient.SetProperties",
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
                        fileAttributes,
                        fileCreationTime,
                        fileLastWriteTime,
                        timeout,
                        filePermission,
                        filePermissionKey))
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
            /// Create the Directory.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <returns>The Directory.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                string filePermission = default,
                string filePermissionKey = default)
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
                if (fileAttributes == null)
                {
                    throw new System.ArgumentNullException(nameof(fileAttributes));
                }
                if (fileCreationTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileCreationTime));
                }
                if (fileLastWriteTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileLastWriteTime));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-file-attributes", fileAttributes);
                _request.Headers.SetValue("x-ms-file-creation-time", fileCreationTime);
                _request.Headers.SetValue("x-ms-file-last-write-time", fileLastWriteTime);
                if (filePermission != null) { _request.Headers.SetValue("x-ms-file-permission", filePermission); }
                if (filePermissionKey != null) { _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey); }

                return _message;
            }

            /// <summary>
            /// Create the Directory.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.SetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo> SetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo();

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
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.SetPropertiesAsync

            #region Directory.SetMetadataAsync
            /// <summary>
            /// Updates user defined metadata for the specified directory.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo>> SetMetadataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                bool async = true,
                string operationName = "DirectoryClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetMetadataAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        metadata))
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
                        return SetMetadataAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Directory.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <returns>The Directory.SetMetadataAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetMetadataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default)
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
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                _request.Uri.AppendQuery("comp", "metadata", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }

                return _message;
            }

            /// <summary>
            /// Create the Directory.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.SetMetadataAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo> SetMetadataAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageDirectoryInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.SetMetadataAsync

            #region Directory.ListFilesAndDirectoriesSegmentAsync
            /// <summary>
            /// Returns a list of files or directories under the specified share or directory. It lists the contents only for a single level of the directory hierarchy.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only entries whose name begins with the specified prefix.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of directories and files.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment>> ListFilesAndDirectoriesSegmentAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string sharesnapshot = default,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                bool async = true,
                string operationName = "DirectoryClient.ListFilesAndDirectoriesSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListFilesAndDirectoriesSegmentAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        prefix,
                        sharesnapshot,
                        marker,
                        maxresults,
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
                        return ListFilesAndDirectoriesSegmentAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Directory.ListFilesAndDirectoriesSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only entries whose name begins with the specified prefix.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <returns>The Directory.ListFilesAndDirectoriesSegmentAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListFilesAndDirectoriesSegmentAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string sharesnapshot = default,
                string marker = default,
                int? maxresults = default,
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
                _request.Uri.AppendQuery("restype", "directory", escapeValue: false);
                _request.Uri.AppendQuery("comp", "list", escapeValue: false);
                if (prefix != null) { _request.Uri.AppendQuery("prefix", prefix); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (maxresults != null) { _request.Uri.AppendQuery("maxresults", maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the Directory.ListFilesAndDirectoriesSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.ListFilesAndDirectoriesSegmentAsync Azure.Response{Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment> ListFilesAndDirectoriesSegmentAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment _value = Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.ListFilesAndDirectoriesSegmentAsync

            #region Directory.ListHandlesAsync
            /// <summary>
            /// Lists handles for directory.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="recursive">Specifies operation should apply to the directory specified in the URI, its files, its subdirectories and their files.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of handles.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.StorageHandlesSegment>> ListHandlesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string sharesnapshot = default,
                bool? recursive = default,
                bool async = true,
                string operationName = "DirectoryClient.ListHandles",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListHandlesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        marker,
                        maxresults,
                        timeout,
                        sharesnapshot,
                        recursive))
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
                        return ListHandlesAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Directory.ListHandlesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="recursive">Specifies operation should apply to the directory specified in the URI, its files, its subdirectories and their files.</param>
            /// <returns>The Directory.ListHandlesAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListHandlesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string sharesnapshot = default,
                bool? recursive = default)
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
                _request.Uri.AppendQuery("comp", "listhandles", escapeValue: false);
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (maxresults != null) { _request.Uri.AppendQuery("maxresults", maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (recursive != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-recursive", recursive.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                return _message;
            }

            /// <summary>
            /// Create the Directory.ListHandlesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.ListHandlesAsync Azure.Response{Azure.Storage.Files.Shares.Models.StorageHandlesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.StorageHandlesSegment> ListHandlesAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.StorageHandlesSegment _value = Azure.Storage.Files.Shares.Models.StorageHandlesSegment.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.StorageHandlesSegment>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.ListHandlesAsync

            #region Directory.ForceCloseHandlesAsync
            /// <summary>
            /// Closes all handles open for given directory.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="handleId">Specifies handle ID opened on the file or directory to be closed. Asterisk (‘*’) is a wildcard that specifies all handles.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="recursive">Specifies operation should apply to the directory specified in the URI, its files, its subdirectories and their files.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment>> ForceCloseHandlesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string handleId,
                string version,
                int? timeout = default,
                string marker = default,
                string sharesnapshot = default,
                bool? recursive = default,
                bool async = true,
                string operationName = "DirectoryClient.ForceCloseHandles",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ForceCloseHandlesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        handleId,
                        version,
                        timeout,
                        marker,
                        sharesnapshot,
                        recursive))
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
                        return ForceCloseHandlesAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the Directory.ForceCloseHandlesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="handleId">Specifies handle ID opened on the file or directory to be closed. Asterisk (‘*’) is a wildcard that specifies all handles.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="recursive">Specifies operation should apply to the directory specified in the URI, its files, its subdirectories and their files.</param>
            /// <returns>The Directory.ForceCloseHandlesAsync Message.</returns>
            internal static Azure.Core.HttpMessage ForceCloseHandlesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string handleId,
                string version,
                int? timeout = default,
                string marker = default,
                string sharesnapshot = default,
                bool? recursive = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (handleId == null)
                {
                    throw new System.ArgumentNullException(nameof(handleId));
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
                _request.Uri.AppendQuery("comp", "forceclosehandles", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-handle-id", handleId);
                _request.Headers.SetValue("x-ms-version", version);
                if (recursive != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-recursive", recursive.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }

                return _message;
            }

            /// <summary>
            /// Create the Directory.ForceCloseHandlesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Directory.ForceCloseHandlesAsync Azure.Response{Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment> ForceCloseHandlesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment _value = new Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-marker", out _header))
                        {
                            _value.Marker = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-number-of-handles-closed", out _header))
                        {
                            _value.NumberOfHandlesClosed = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-number-of-handles-failed", out _header))
                        {
                            _value.NumberOfHandlesFailedToClose = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Directory.ForceCloseHandlesAsync
        }
        #endregion Directory operations

        #region File operations
        /// <summary>
        /// File operations for Azure File Storage
        /// </summary>
        public static partial class File
        {
            #region File.CreateAsync
            /// <summary>
            /// Creates a new file or replaces a file. Note it only initializes the file with no content.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileContentLength">Specifies the maximum size for the file, up to 4 TB.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="fileContentType">Sets the MIME content type of the file. The default type is 'application/octet-stream'.</param>
            /// <param name="fileContentEncoding">Specifies which content encodings have been applied to the file.</param>
            /// <param name="fileContentLanguage">Specifies the natural languages used by this resource.</param>
            /// <param name="fileCacheControl">Sets the file's cache control. The File service stores this value but does not use or modify it.</param>
            /// <param name="fileContentHash">Sets the file's MD5 hash.</param>
            /// <param name="fileContentDisposition">Sets the file's Content-Disposition header.</param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo>> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                long fileContentLength,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                string fileContentType = default,
                System.Collections.Generic.IEnumerable<string> fileContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> fileContentLanguage = default,
                string fileCacheControl = default,
                byte[] fileContentHash = default,
                string fileContentDisposition = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.Create",
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
                        fileContentLength,
                        fileAttributes,
                        fileCreationTime,
                        fileLastWriteTime,
                        timeout,
                        fileContentType,
                        fileContentEncoding,
                        fileContentLanguage,
                        fileCacheControl,
                        fileContentHash,
                        fileContentDisposition,
                        metadata,
                        filePermission,
                        filePermissionKey,
                        leaseId))
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
            /// Create the File.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileContentLength">Specifies the maximum size for the file, up to 4 TB.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="fileContentType">Sets the MIME content type of the file. The default type is 'application/octet-stream'.</param>
            /// <param name="fileContentEncoding">Specifies which content encodings have been applied to the file.</param>
            /// <param name="fileContentLanguage">Specifies the natural languages used by this resource.</param>
            /// <param name="fileCacheControl">Sets the file's cache control. The File service stores this value but does not use or modify it.</param>
            /// <param name="fileContentHash">Sets the file's MD5 hash.</param>
            /// <param name="fileContentDisposition">Sets the file's Content-Disposition header.</param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                long fileContentLength,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                string fileContentType = default,
                System.Collections.Generic.IEnumerable<string> fileContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> fileContentLanguage = default,
                string fileCacheControl = default,
                byte[] fileContentHash = default,
                string fileContentDisposition = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default,
                string leaseId = default)
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
                if (fileAttributes == null)
                {
                    throw new System.ArgumentNullException(nameof(fileAttributes));
                }
                if (fileCreationTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileCreationTime));
                }
                if (fileLastWriteTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileLastWriteTime));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-content-length", fileContentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-type", "file");
                _request.Headers.SetValue("x-ms-file-attributes", fileAttributes);
                _request.Headers.SetValue("x-ms-file-creation-time", fileCreationTime);
                _request.Headers.SetValue("x-ms-file-last-write-time", fileLastWriteTime);
                if (fileContentType != null) { _request.Headers.SetValue("x-ms-content-type", fileContentType); }
                if (fileContentEncoding != null) {
                    foreach (string _item in fileContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-content-encoding", _item);
                    }
                }
                if (fileContentLanguage != null) {
                    foreach (string _item in fileContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-content-language", _item);
                    }
                }
                if (fileCacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", fileCacheControl); }
                if (fileContentHash != null) { _request.Headers.SetValue("x-ms-content-md5", System.Convert.ToBase64String(fileContentHash)); }
                if (fileContentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", fileContentDisposition); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (filePermission != null) { _request.Headers.SetValue("x-ms-file-permission", filePermission); }
                if (filePermissionKey != null) { _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.CreateAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo> CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageFileInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageFileInfo();

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
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.CreateAsync

            #region File.DownloadAsync
            /// <summary>
            /// Reads or downloads a file from the system, including its metadata and properties.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="range">Return file data only from the specified byte range.</param>
            /// <param name="rangeGetContentHash">When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties}</returns>
            public static async System.Threading.Tasks.ValueTask<(Azure.Response<Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties>, System.IO.Stream)> DownloadAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string range = default,
                bool? rangeGetContentHash = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.Download",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = DownloadAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        range,
                        rangeGetContentHash,
                        leaseId))
                    {
                        // Avoid buffering if stream is going to be returned to the caller
                        _message.BufferResponse = false;
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
                        return (DownloadAsync_CreateResponse(clientDiagnostics, _response), _message.ExtractResponseContent());
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
            /// Create the File.DownloadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="range">Return file data only from the specified byte range.</param>
            /// <param name="rangeGetContentHash">When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.DownloadAsync Message.</returns>
            internal static Azure.Core.HttpMessage DownloadAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string range = default,
                bool? rangeGetContentHash = default,
                string leaseId = default)
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
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (rangeGetContentHash != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-range-get-content-md5", rangeGetContentHash.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.DownloadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.DownloadAsync Azure.Response{Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties> DownloadAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties _value = new Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties();
                        _value.Content = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-completion-time", out _header))
                        {
                            _value.CopyCompletionTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status-description", out _header))
                        {
                            _value.CopyStatusDescription = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-id", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-progress", out _header))
                        {
                            _value.CopyProgress = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-source", out _header))
                        {
                            _value.CopySource = new System.Uri(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status", out _header))
                        {
                            _value.CopyStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-content-md5", out _header))
                        {
                            _value.FileContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseDuration(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseStatus(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 206:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties _value = new Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties();
                        _value.Content = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Range", out _header))
                        {
                            _value.ContentRange = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-completion-time", out _header))
                        {
                            _value.CopyCompletionTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status-description", out _header))
                        {
                            _value.CopyStatusDescription = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-id", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-progress", out _header))
                        {
                            _value.CopyProgress = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-source", out _header))
                        {
                            _value.CopySource = new System.Uri(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status", out _header))
                        {
                            _value.CopyStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-content-md5", out _header))
                        {
                            _value.FileContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseDuration(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseStatus(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.FlattenedStorageFileProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.DownloadAsync

            #region File.GetPropertiesAsync
            /// <summary>
            /// Returns all user-defined metadata, standard HTTP properties, and system properties for the file. It does not return the content of the file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileProperties}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.GetProperties",
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
                        sharesnapshot,
                        timeout,
                        leaseId))
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
            /// Create the File.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                int? timeout = default,
                string leaseId = default)
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
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.GetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileProperties> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageFileProperties _value = new Azure.Storage.Files.Shares.Models.RawStorageFileProperties();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("Content-Length", out _header))
                        {
                            _value.ContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-completion-time", out _header))
                        {
                            _value.CopyCompletionTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status-description", out _header))
                        {
                            _value.CopyStatusDescription = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-id", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-progress", out _header))
                        {
                            _value.CopyProgress = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-source", out _header))
                        {
                            _value.CopySource = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status", out _header))
                        {
                            _value.CopyStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseDuration(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseStatus(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.RawStorageFileProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FailureNoContent _value = new Azure.Storage.Files.Shares.Models.FailureNoContent();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.GetPropertiesAsync

            #region File.DeleteAsync
            /// <summary>
            /// removes the file from the storage account.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.Delete",
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
                        timeout,
                        leaseId))
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
            /// Create the File.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default)
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

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.DeleteAsync Azure.Response.</returns>
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.DeleteAsync

            #region File.SetPropertiesAsync
            /// <summary>
            /// Sets HTTP headers on the file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="fileContentLength">Resizes a file to the specified size. If the specified byte value is less than the current size of the file, then all ranges above the specified byte value are cleared.</param>
            /// <param name="fileContentType">Sets the MIME content type of the file. The default type is 'application/octet-stream'.</param>
            /// <param name="fileContentEncoding">Specifies which content encodings have been applied to the file.</param>
            /// <param name="fileContentLanguage">Specifies the natural languages used by this resource.</param>
            /// <param name="fileCacheControl">Sets the file's cache control. The File service stores this value but does not use or modify it.</param>
            /// <param name="fileContentHash">Sets the file's MD5 hash.</param>
            /// <param name="fileContentDisposition">Sets the file's Content-Disposition header.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo>> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                long? fileContentLength = default,
                string fileContentType = default,
                System.Collections.Generic.IEnumerable<string> fileContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> fileContentLanguage = default,
                string fileCacheControl = default,
                byte[] fileContentHash = default,
                string fileContentDisposition = default,
                string filePermission = default,
                string filePermissionKey = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.SetProperties",
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
                        fileAttributes,
                        fileCreationTime,
                        fileLastWriteTime,
                        timeout,
                        fileContentLength,
                        fileContentType,
                        fileContentEncoding,
                        fileContentLanguage,
                        fileCacheControl,
                        fileContentHash,
                        fileContentDisposition,
                        filePermission,
                        filePermissionKey,
                        leaseId))
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
            /// Create the File.SetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="fileAttributes">If specified, the provided file attributes shall be set. Default value: ‘Archive’ for file and ‘Directory’ for directory. ‘None’ can also be specified as default.</param>
            /// <param name="fileCreationTime">Creation time for the file/directory. Default value: Now.</param>
            /// <param name="fileLastWriteTime">Last write time for the file/directory. Default value: Now.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="fileContentLength">Resizes a file to the specified size. If the specified byte value is less than the current size of the file, then all ranges above the specified byte value are cleared.</param>
            /// <param name="fileContentType">Sets the MIME content type of the file. The default type is 'application/octet-stream'.</param>
            /// <param name="fileContentEncoding">Specifies which content encodings have been applied to the file.</param>
            /// <param name="fileContentLanguage">Specifies the natural languages used by this resource.</param>
            /// <param name="fileCacheControl">Sets the file's cache control. The File service stores this value but does not use or modify it.</param>
            /// <param name="fileContentHash">Sets the file's MD5 hash.</param>
            /// <param name="fileContentDisposition">Sets the file's Content-Disposition header.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string fileAttributes,
                string fileCreationTime,
                string fileLastWriteTime,
                int? timeout = default,
                long? fileContentLength = default,
                string fileContentType = default,
                System.Collections.Generic.IEnumerable<string> fileContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> fileContentLanguage = default,
                string fileCacheControl = default,
                byte[] fileContentHash = default,
                string fileContentDisposition = default,
                string filePermission = default,
                string filePermissionKey = default,
                string leaseId = default)
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
                if (fileAttributes == null)
                {
                    throw new System.ArgumentNullException(nameof(fileAttributes));
                }
                if (fileCreationTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileCreationTime));
                }
                if (fileLastWriteTime == null)
                {
                    throw new System.ArgumentNullException(nameof(fileLastWriteTime));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-file-attributes", fileAttributes);
                _request.Headers.SetValue("x-ms-file-creation-time", fileCreationTime);
                _request.Headers.SetValue("x-ms-file-last-write-time", fileLastWriteTime);
                if (fileContentLength != null) { _request.Headers.SetValue("x-ms-content-length", fileContentLength.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (fileContentType != null) { _request.Headers.SetValue("x-ms-content-type", fileContentType); }
                if (fileContentEncoding != null) {
                    foreach (string _item in fileContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-content-encoding", _item);
                    }
                }
                if (fileContentLanguage != null) {
                    foreach (string _item in fileContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-content-language", _item);
                    }
                }
                if (fileCacheControl != null) { _request.Headers.SetValue("x-ms-cache-control", fileCacheControl); }
                if (fileContentHash != null) { _request.Headers.SetValue("x-ms-content-md5", System.Convert.ToBase64String(fileContentHash)); }
                if (fileContentDisposition != null) { _request.Headers.SetValue("x-ms-content-disposition", fileContentDisposition); }
                if (filePermission != null) { _request.Headers.SetValue("x-ms-file-permission", filePermission); }
                if (filePermissionKey != null) { _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.SetPropertiesAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo> SetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageFileInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageFileInfo();

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
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-permission-key", out _header))
                        {
                            _value.FilePermissionKey = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-attributes", out _header))
                        {
                            _value.FileAttributes = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-creation-time", out _header))
                        {
                            _value.FileCreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-last-write-time", out _header))
                        {
                            _value.FileLastWriteTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-change-time", out _header))
                        {
                            _value.FileChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-file-id", out _header))
                        {
                            _value.FileId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-file-parent-id", out _header))
                        {
                            _value.FileParentId = _header;
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.SetPropertiesAsync

            #region File.SetMetadataAsync
            /// <summary>
            /// Updates user-defined metadata for the specified file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo>> SetMetadataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = SetMetadataAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        metadata,
                        leaseId))
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
                        return SetMetadataAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.SetMetadataAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetMetadataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("comp", "metadata", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.SetMetadataAsync Azure.Response{Azure.Storage.Files.Shares.Models.RawStorageFileInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.RawStorageFileInfo> SetMetadataAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.RawStorageFileInfo _value = new Azure.Storage.Files.Shares.Models.RawStorageFileInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.SetMetadataAsync

            #region File.AcquireLeaseAsync
            /// <summary>
            /// [Update] The Lease File operation establishes and manages a lock on a file for write and delete operations
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> AcquireLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "FileClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = AcquireLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
                        duration,
                        proposedLeaseId,
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
                        return AcquireLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The File.AcquireLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage AcquireLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                long? duration = default,
                string proposedLeaseId = default,
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
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                _request.Headers.SetValue("x-ms-version", version);
                if (duration != null) { _request.Headers.SetValue("x-ms-lease-duration", duration.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the File.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.AcquireLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> AcquireLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileLease _value = new Azure.Storage.Files.Shares.Models.ShareFileLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.AcquireLeaseAsync

            #region File.ReleaseLeaseAsync
            /// <summary>
            /// [Update] The Lease File operation establishes and manages a lock on a file for write and delete operations
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo>> ReleaseLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "FileClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ReleaseLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        leaseId,
                        version,
                        timeout,
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
                        return ReleaseLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The File.ReleaseLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage ReleaseLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (leaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(leaseId));
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the File.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.ReleaseLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo> ReleaseLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo _value = new Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo();

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
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.ReleaseLeaseAsync

            #region File.ChangeLeaseAsync
            /// <summary>
            /// [Update] The Lease File operation establishes and manages a lock on a file for write and delete operations
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> ChangeLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string proposedLeaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "FileClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ChangeLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        leaseId,
                        version,
                        timeout,
                        proposedLeaseId,
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
                        return ChangeLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The File service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The File.ChangeLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage ChangeLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string version,
                int? timeout = default,
                string proposedLeaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (leaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(leaseId));
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
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", version);
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the File.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.ChangeLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> ChangeLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileLease _value = new Azure.Storage.Files.Shares.Models.ShareFileLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.ChangeLeaseAsync

            #region File.BreakLeaseAsync
            /// <summary>
            /// [Update] The Lease File operation establishes and manages a lock on a file for write and delete operations
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.BrokenLease}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.BrokenLease>> BreakLeaseAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "FileClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = BreakLeaseAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        timeout,
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
                        return BreakLeaseAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The File.BreakLeaseAsync Message.</returns>
            internal static Azure.Core.HttpMessage BreakLeaseAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string leaseId = default,
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
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "lease", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the File.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.BreakLeaseAsync Azure.Response{Azure.Storage.Files.Shares.Models.BrokenLease}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.BrokenLease> BreakLeaseAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.BrokenLease _value = new Azure.Storage.Files.Shares.Models.BrokenLease();

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
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.BreakLeaseAsync

            #region File.UploadRangeAsync
            /// <summary>
            /// Upload a range of bytes to a file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="range">Specifies the range of bytes to be written. Both the start and end of the range must be specified. For an update operation, the range can be up to 4 MB in size. For a clear operation, the range can be up to the value of the file's full size. The File service accepts only a single byte range for the Range and 'x-ms-range' headers, and the byte range must be specified in the following format: bytes=startByte-endByte.</param>
            /// <param name="fileRangeWrite">Specify one of the following options: - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update. - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and set the Range header to a value that indicates the range to clear, up to maximum file size.</param>
            /// <param name="contentLength">Specifies the number of bytes being transmitted in the request body. When the x-ms-write header is set to clear, the value of this header must be set to zero.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="optionalbody">Initial data.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="contentHash">An MD5 hash of the content. This hash is used to verify the integrity of the data during transport. When the Content-MD5 header is specified, the File service compares the hash of the content that has arrived with the header value that was sent. If the two hashes do not match, the operation will fail with error code 400 (Bad Request).</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileUploadInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadRangeAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string range,
                Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType fileRangeWrite,
                long contentLength,
                string version,
                System.IO.Stream optionalbody = default,
                int? timeout = default,
                byte[] contentHash = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.UploadRange",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = UploadRangeAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        range,
                        fileRangeWrite,
                        contentLength,
                        version,
                        optionalbody,
                        timeout,
                        contentHash,
                        leaseId))
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
                        return UploadRangeAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.UploadRangeAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="range">Specifies the range of bytes to be written. Both the start and end of the range must be specified. For an update operation, the range can be up to 4 MB in size. For a clear operation, the range can be up to the value of the file's full size. The File service accepts only a single byte range for the Range and 'x-ms-range' headers, and the byte range must be specified in the following format: bytes=startByte-endByte.</param>
            /// <param name="fileRangeWrite">Specify one of the following options: - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update. - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and set the Range header to a value that indicates the range to clear, up to maximum file size.</param>
            /// <param name="contentLength">Specifies the number of bytes being transmitted in the request body. When the x-ms-write header is set to clear, the value of this header must be set to zero.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="optionalbody">Initial data.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="contentHash">An MD5 hash of the content. This hash is used to verify the integrity of the data during transport. When the Content-MD5 header is specified, the File service compares the hash of the content that has arrived with the header value that was sent. If the two hashes do not match, the operation will fail with error code 400 (Bad Request).</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.UploadRangeAsync Message.</returns>
            internal static Azure.Core.HttpMessage UploadRangeAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string range,
                Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType fileRangeWrite,
                long contentLength,
                string version,
                System.IO.Stream optionalbody = default,
                int? timeout = default,
                byte[] contentHash = default,
                string leaseId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (range == null)
                {
                    throw new System.ArgumentNullException(nameof(range));
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
                _request.Uri.AppendQuery("comp", "range", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-range", range);
                _request.Headers.SetValue("x-ms-write", Azure.Storage.Files.Shares.FileRestClient.Serialization.ToString(fileRangeWrite));
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", version);
                if (contentHash != null) { _request.Headers.SetValue("Content-MD5", System.Convert.ToBase64String(contentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                // Create the body
                if (optionalbody != null)
                {
                    _request.Content = Azure.Core.RequestContent.Create(optionalbody);
                }

                return _message;
            }

            /// <summary>
            /// Create the File.UploadRangeAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.UploadRangeAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileUploadInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> UploadRangeAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileUploadInfo _value = new Azure.Storage.Files.Shares.Models.ShareFileUploadInfo();

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
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.UploadRangeAsync

            #region File.UploadRangeFromURLAsync
            /// <summary>
            /// Upload a range of bytes to a file where the contents are read from a URL.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="range">Writes data to the specified byte range in the file.</param>
            /// <param name="copySource">Specifies the URL of the source file or blob, up to 2 KB in length. To copy a file to another file within the same storage account, you may use Shared Key to authenticate the source file. If you are copying a file from another storage account, or if you are copying a blob from the same storage account or another storage account, then you must authenticate the source file or blob using a shared access signature. If the source is a public blob, no authentication is required to perform the copy operation. A file in a share snapshot can also be specified as a copy source.</param>
            /// <param name="contentLength">Specifies the number of bytes being transmitted in the request body. When the x-ms-write header is set to clear, the value of this header must be set to zero.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceIfMatchCrc64">Specify the crc64 value to operate only on range with a matching crc64 checksum.</param>
            /// <param name="sourceIfNoneMatchCrc64">Specify the crc64 value to operate only on range without a matching crc64 checksum.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult>> UploadRangeFromURLAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string range,
                System.Uri copySource,
                long contentLength,
                string version,
                int? timeout = default,
                string sourceRange = default,
                byte[] sourceContentCrc64 = default,
                byte[] sourceIfMatchCrc64 = default,
                byte[] sourceIfNoneMatchCrc64 = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.UploadRangeFromURL",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = UploadRangeFromURLAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        range,
                        copySource,
                        contentLength,
                        version,
                        timeout,
                        sourceRange,
                        sourceContentCrc64,
                        sourceIfMatchCrc64,
                        sourceIfNoneMatchCrc64,
                        leaseId))
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
                        return UploadRangeFromURLAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.UploadRangeFromURLAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="range">Writes data to the specified byte range in the file.</param>
            /// <param name="copySource">Specifies the URL of the source file or blob, up to 2 KB in length. To copy a file to another file within the same storage account, you may use Shared Key to authenticate the source file. If you are copying a file from another storage account, or if you are copying a blob from the same storage account or another storage account, then you must authenticate the source file or blob using a shared access signature. If the source is a public blob, no authentication is required to perform the copy operation. A file in a share snapshot can also be specified as a copy source.</param>
            /// <param name="contentLength">Specifies the number of bytes being transmitted in the request body. When the x-ms-write header is set to clear, the value of this header must be set to zero.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentCrc64">Specify the crc64 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="sourceIfMatchCrc64">Specify the crc64 value to operate only on range with a matching crc64 checksum.</param>
            /// <param name="sourceIfNoneMatchCrc64">Specify the crc64 value to operate only on range without a matching crc64 checksum.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.UploadRangeFromURLAsync Message.</returns>
            internal static Azure.Core.HttpMessage UploadRangeFromURLAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string range,
                System.Uri copySource,
                long contentLength,
                string version,
                int? timeout = default,
                string sourceRange = default,
                byte[] sourceContentCrc64 = default,
                byte[] sourceIfMatchCrc64 = default,
                byte[] sourceIfNoneMatchCrc64 = default,
                string leaseId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (range == null)
                {
                    throw new System.ArgumentNullException(nameof(range));
                }
                if (copySource == null)
                {
                    throw new System.ArgumentNullException(nameof(copySource));
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
                _request.Uri.AppendQuery("comp", "range", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-range", range);
                _request.Headers.SetValue("x-ms-copy-source", copySource.AbsoluteUri);
                _request.Headers.SetValue("x-ms-write", "update");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", version);
                if (sourceRange != null) { _request.Headers.SetValue("x-ms-source-range", sourceRange); }
                if (sourceContentCrc64 != null) { _request.Headers.SetValue("x-ms-source-content-crc64", System.Convert.ToBase64String(sourceContentCrc64)); }
                if (sourceIfMatchCrc64 != null) { _request.Headers.SetValue("x-ms-source-if-match-crc64", System.Convert.ToBase64String(sourceIfMatchCrc64)); }
                if (sourceIfNoneMatchCrc64 != null) { _request.Headers.SetValue("x-ms-source-if-none-match-crc64", System.Convert.ToBase64String(sourceIfNoneMatchCrc64)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.UploadRangeFromURLAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.UploadRangeFromURLAsync Azure.Response{Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult> UploadRangeFromURLAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult _value = new Azure.Storage.Files.Shares.Models.FileUploadRangeFromURLResult();

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
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out _header))
                        {
                            _value.XMSContentCrc64 = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.UploadRangeFromURLAsync

            #region File.GetRangeListAsync
            /// <summary>
            /// Returns the list of valid ranges for a file.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="prevsharesnapshot">The previous snapshot parameter is an opaque DateTime value that, when present, specifies the previous snapshot.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="range">Specifies the range of bytes over which to list ranges, inclusively.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal>> GetRangeListAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                string prevsharesnapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.GetRangeList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = GetRangeListAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        sharesnapshot,
                        prevsharesnapshot,
                        timeout,
                        range,
                        leaseId))
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
                        return GetRangeListAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.GetRangeListAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="prevsharesnapshot">The previous snapshot parameter is an opaque DateTime value that, when present, specifies the previous snapshot.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="range">Specifies the range of bytes over which to list ranges, inclusively.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.GetRangeListAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetRangeListAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string sharesnapshot = default,
                string prevsharesnapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default)
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
                _request.Uri.AppendQuery("comp", "rangelist", escapeValue: false);
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }
                if (prevsharesnapshot != null) { _request.Uri.AppendQuery("prevsharesnapshot", prevsharesnapshot); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.GetRangeListAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.GetRangeListAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal> GetRangeListAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal _value = new Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal();
                        _value.Body = Azure.Storage.Files.Shares.Models.ShareFileRangeList.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-content-length", out _header))
                        {
                            _value.FileContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.ShareFileRangeInfoInternal>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.GetRangeListAsync

            #region File.StartCopyAsync
            /// <summary>
            /// Copies a blob or file to a destination file within the storage account.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="copySource">Specifies the URL of the source file or blob, up to 2 KB in length. To copy a file to another file within the same storage account, you may use Shared Key to authenticate the source file. If you are copying a file from another storage account, or if you are copying a blob from the same storage account or another storage account, then you must authenticate the source file or blob using a shared access signature. If the source is a public blob, no authentication is required to perform the copy operation. A file in a share snapshot can also be specified as a copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionCopyMode">Specifies the option to copy file security descriptor from source file or to set it using the value which is defined by the header value of x-ms-file-permission or x-ms-file-permission-key.</param>
            /// <param name="ignoreReadOnly">Specifies the option to overwrite the target file if it already exists and has read-only attribute set.</param>
            /// <param name="fileAttributes">Specifies either the option to copy file attributes from a source file(source) to a target file or a list of attributes to set on a target file.</param>
            /// <param name="fileCreationTime">Specifies either the option to copy file creation time from a source file(source) to a target file or a time value in ISO 8601 format to set as creation time on a target file.</param>
            /// <param name="fileLastWriteTime">Specifies either the option to copy file last write time from a source file(source) to a target file or a time value in ISO 8601 format to set as last write time on a target file.</param>
            /// <param name="setArchiveAttribute">Specifies the option to set archive attribute on a target file. True means archive attribute will be set on a target file despite attribute overrides or a source file state.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileCopyInfo}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo>> StartCopyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default,
                Azure.Storage.Files.Shares.Models.PermissionCopyMode? filePermissionCopyMode = default,
                bool? ignoreReadOnly = default,
                string fileAttributes = default,
                string fileCreationTime = default,
                string fileLastWriteTime = default,
                bool? setArchiveAttribute = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.StartCopy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = StartCopyAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        copySource,
                        timeout,
                        metadata,
                        filePermission,
                        filePermissionKey,
                        filePermissionCopyMode,
                        ignoreReadOnly,
                        fileAttributes,
                        fileCreationTime,
                        fileLastWriteTime,
                        setArchiveAttribute,
                        leaseId))
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
                        return StartCopyAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.StartCopyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="copySource">Specifies the URL of the source file or blob, up to 2 KB in length. To copy a file to another file within the same storage account, you may use Shared Key to authenticate the source file. If you are copying a file from another storage account, or if you are copying a blob from the same storage account or another storage account, then you must authenticate the source file or blob using a shared access signature. If the source is a public blob, no authentication is required to perform the copy operation. A file in a share snapshot can also be specified as a copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="metadata">A name-value pair to associate with a file storage object.</param>
            /// <param name="filePermission">If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionKey">Key of the permission to be set for the directory/file. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.</param>
            /// <param name="filePermissionCopyMode">Specifies the option to copy file security descriptor from source file or to set it using the value which is defined by the header value of x-ms-file-permission or x-ms-file-permission-key.</param>
            /// <param name="ignoreReadOnly">Specifies the option to overwrite the target file if it already exists and has read-only attribute set.</param>
            /// <param name="fileAttributes">Specifies either the option to copy file attributes from a source file(source) to a target file or a list of attributes to set on a target file.</param>
            /// <param name="fileCreationTime">Specifies either the option to copy file creation time from a source file(source) to a target file or a time value in ISO 8601 format to set as creation time on a target file.</param>
            /// <param name="fileLastWriteTime">Specifies either the option to copy file last write time from a source file(source) to a target file or a time value in ISO 8601 format to set as last write time on a target file.</param>
            /// <param name="setArchiveAttribute">Specifies the option to set archive attribute on a target file. True means archive attribute will be set on a target file despite attribute overrides or a source file state.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.StartCopyAsync Message.</returns>
            internal static Azure.Core.HttpMessage StartCopyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string filePermission = default,
                string filePermissionKey = default,
                Azure.Storage.Files.Shares.Models.PermissionCopyMode? filePermissionCopyMode = default,
                bool? ignoreReadOnly = default,
                string fileAttributes = default,
                string fileCreationTime = default,
                string fileLastWriteTime = default,
                bool? setArchiveAttribute = default,
                string leaseId = default)
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
                if (copySource == null)
                {
                    throw new System.ArgumentNullException(nameof(copySource));
                }

                // Create the request
                Azure.Core.HttpMessage _message = pipeline.CreateMessage();
                Azure.Core.Request _request = _message.Request;

                // Set the endpoint
                _request.Method = Azure.Core.RequestMethod.Put;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                _request.Headers.SetValue("x-ms-copy-source", copySource.AbsoluteUri);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (filePermission != null) { _request.Headers.SetValue("x-ms-file-permission", filePermission); }
                if (filePermissionKey != null) { _request.Headers.SetValue("x-ms-file-permission-key", filePermissionKey); }
                if (filePermissionCopyMode != null) { _request.Headers.SetValue("x-ms-file-permission-copy-mode", Azure.Storage.Files.Shares.FileRestClient.Serialization.ToString(filePermissionCopyMode.Value)); }
                if (ignoreReadOnly != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-file-copy-ignore-read-only", ignoreReadOnly.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (fileAttributes != null) { _request.Headers.SetValue("x-ms-file-attributes", fileAttributes); }
                if (fileCreationTime != null) { _request.Headers.SetValue("x-ms-file-creation-time", fileCreationTime); }
                if (fileLastWriteTime != null) { _request.Headers.SetValue("x-ms-file-last-write-time", fileLastWriteTime); }
                if (setArchiveAttribute != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-file-copy-set-archive", setArchiveAttribute.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.StartCopyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.StartCopyAsync Azure.Response{Azure.Storage.Files.Shares.Models.ShareFileCopyInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo> StartCopyAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.ShareFileCopyInfo _value = new Azure.Storage.Files.Shares.Models.ShareFileCopyInfo();

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
                        if (response.Headers.TryGetValue("x-ms-copy-id", out _header))
                        {
                            _value.CopyId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-status", out _header))
                        {
                            _value.CopyStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseCopyStatus(_header);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.StartCopyAsync

            #region File.AbortCopyAsync
            /// <summary>
            /// Aborts a pending Copy File operation, and leaves a destination file with zero length and full metadata.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy File operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> AbortCopyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string copyId,
                string version,
                int? timeout = default,
                string leaseId = default,
                bool async = true,
                string operationName = "FileClient.AbortCopy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = AbortCopyAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        copyId,
                        version,
                        timeout,
                        leaseId))
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
                        return AbortCopyAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.AbortCopyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy File operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The File.AbortCopyAsync Message.</returns>
            internal static Azure.Core.HttpMessage AbortCopyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string copyId,
                string version,
                int? timeout = default,
                string leaseId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (copyId == null)
                {
                    throw new System.ArgumentNullException(nameof(copyId));
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
                _request.Uri.AppendQuery("comp", "copy", escapeValue: false);
                _request.Uri.AppendQuery("copyid", copyId);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-action", "abort");
                _request.Headers.SetValue("x-ms-version", version);
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _message;
            }

            /// <summary>
            /// Create the File.AbortCopyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.AbortCopyAsync Azure.Response.</returns>
            internal static Azure.Response AbortCopyAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 204:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.AbortCopyAsync

            #region File.ListHandlesAsync
            /// <summary>
            /// Lists handles for file
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of handles.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.StorageHandlesSegment>> ListHandlesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string sharesnapshot = default,
                bool async = true,
                string operationName = "FileClient.ListHandles",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListHandlesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        marker,
                        maxresults,
                        timeout,
                        sharesnapshot))
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
                        return ListHandlesAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.ListHandlesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of entries to return. If the request does not specify maxresults, or specifies a value greater than 5,000, the server will return up to 5,000 items.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <returns>The File.ListHandlesAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListHandlesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string marker = default,
                int? maxresults = default,
                int? timeout = default,
                string sharesnapshot = default)
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
                _request.Uri.AppendQuery("comp", "listhandles", escapeValue: false);
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (maxresults != null) { _request.Uri.AppendQuery("maxresults", maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the File.ListHandlesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.ListHandlesAsync Azure.Response{Azure.Storage.Files.Shares.Models.StorageHandlesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.StorageHandlesSegment> ListHandlesAsync_CreateResponse(
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
                        Azure.Storage.Files.Shares.Models.StorageHandlesSegment _value = Azure.Storage.Files.Shares.Models.StorageHandlesSegment.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Files.Shares.Models.StorageHandlesSegment>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.ListHandlesAsync

            #region File.ForceCloseHandlesAsync
            /// <summary>
            /// Closes all handles open for given file
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="handleId">Specifies handle ID opened on the file or directory to be closed. Asterisk (‘*’) is a wildcard that specifies all handles.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment>> ForceCloseHandlesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string handleId,
                string version,
                int? timeout = default,
                string marker = default,
                string sharesnapshot = default,
                bool async = true,
                string operationName = "FileClient.ForceCloseHandles",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ForceCloseHandlesAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        handleId,
                        version,
                        timeout,
                        marker,
                        sharesnapshot))
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
                        return ForceCloseHandlesAsync_CreateResponse(clientDiagnostics, _response);
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
            /// Create the File.ForceCloseHandlesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, share, directory or file that is the target of the desired operation.</param>
            /// <param name="handleId">Specifies handle ID opened on the file or directory to be closed. Asterisk (‘*’) is a wildcard that specifies all handles.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/Setting-Timeouts-for-File-Service-Operations?redirectedfrom=MSDN">Setting Timeouts for File Service Operations.</a></param>
            /// <param name="marker">A string value that identifies the portion of the list to be returned with the next list operation. The operation returns a marker value within the response body if the list returned was not complete. The marker value may then be used in a subsequent call to request the next set of list items. The marker value is opaque to the client.</param>
            /// <param name="sharesnapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the share snapshot to query.</param>
            /// <returns>The File.ForceCloseHandlesAsync Message.</returns>
            internal static Azure.Core.HttpMessage ForceCloseHandlesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string handleId,
                string version,
                int? timeout = default,
                string marker = default,
                string sharesnapshot = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (handleId == null)
                {
                    throw new System.ArgumentNullException(nameof(handleId));
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
                _request.Uri.AppendQuery("comp", "forceclosehandles", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (marker != null) { _request.Uri.AppendQuery("marker", marker); }
                if (sharesnapshot != null) { _request.Uri.AppendQuery("sharesnapshot", sharesnapshot); }

                // Add request headers
                _request.Headers.SetValue("x-ms-handle-id", handleId);
                _request.Headers.SetValue("x-ms-version", version);

                return _message;
            }

            /// <summary>
            /// Create the File.ForceCloseHandlesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The File.ForceCloseHandlesAsync Azure.Response{Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment> ForceCloseHandlesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment _value = new Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-marker", out _header))
                        {
                            _value.Marker = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-number-of-handles-closed", out _header))
                        {
                            _value.NumberOfHandlesClosed = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-number-of-handles-failed", out _header))
                        {
                            _value.NumberOfHandlesFailedToClose = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Files.Shares.Models.StorageError _value = Azure.Storage.Files.Shares.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion File.ForceCloseHandlesAsync
        }
        #endregion File operations
    }
}
#endregion Service

#region Models
#region class BrokenLease
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// BrokenLease
    /// </summary>
    internal partial class BrokenLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Approximate time remaining in the lease period, in seconds.
        /// </summary>
        public int LeaseTime { get; internal set; }

        /// <summary>
        /// Uniquely identifies a share's lease
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BrokenLease instances.
        /// You can use ShareModelFactory.BrokenLease instead.
        /// </summary>
        internal BrokenLease() { }
    }
}
#endregion class BrokenLease

#region class ClearRange
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ClearRange
    /// </summary>
    internal partial class ClearRange
    {
        /// <summary>
        /// Start
        /// </summary>
        public long Start { get; internal set; }

        /// <summary>
        /// End
        /// </summary>
        public long End { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ClearRange instances.
        /// You can use ShareModelFactory.ClearRange instead.
        /// </summary>
        internal ClearRange() { }

        /// <summary>
        /// Deserializes XML into a new ClearRange instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ClearRange instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ClearRange FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ClearRange _value = new Azure.Storage.Files.Shares.Models.ClearRange();
            _child = element.Element(System.Xml.Linq.XName.Get("Start", ""));
            if (_child != null)
            {
                _value.Start = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("End", ""));
            if (_child != null)
            {
                _value.End = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ClearRange value);
    }
}
#endregion class ClearRange

#region enum CopyStatus
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// State of the copy operation identified by 'x-ms-copy-id'.
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum CopyStatus
    #pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// pending
        /// </summary>
        Pending,

        /// <summary>
        /// success
        /// </summary>
        Success,

        /// <summary>
        /// aborted
        /// </summary>
        Aborted,

        /// <summary>
        /// failed
        /// </summary>
        Failed
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.CopyStatus value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.CopyStatus.Pending => "pending",
                    Azure.Storage.Files.Shares.Models.CopyStatus.Success => "success",
                    Azure.Storage.Files.Shares.Models.CopyStatus.Aborted => "aborted",
                    Azure.Storage.Files.Shares.Models.CopyStatus.Failed => "failed",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.CopyStatus value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.CopyStatus ParseCopyStatus(string value)
            {
                return value switch
                {
                    "pending" => Azure.Storage.Files.Shares.Models.CopyStatus.Pending,
                    "success" => Azure.Storage.Files.Shares.Models.CopyStatus.Success,
                    "aborted" => Azure.Storage.Files.Shares.Models.CopyStatus.Aborted,
                    "failed" => Azure.Storage.Files.Shares.Models.CopyStatus.Failed,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.CopyStatus value.")
                };
            }
        }
    }
}
#endregion enum CopyStatus

#region class DirectoryItem
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed directory item.
    /// </summary>
    internal partial class DirectoryItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of DirectoryItem instances.
        /// You can use ShareModelFactory.DirectoryItem instead.
        /// </summary>
        internal DirectoryItem() { }

        /// <summary>
        /// Deserializes XML into a new DirectoryItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized DirectoryItem instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.DirectoryItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.DirectoryItem _value = new Azure.Storage.Files.Shares.Models.DirectoryItem();
            _child = element.Element(System.Xml.Linq.XName.Get("Name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.DirectoryItem value);
    }
}
#endregion class DirectoryItem

#region class FailureNoContent
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// FailureNoContent
    /// </summary>
    internal partial class FailureNoContent
    {
        /// <summary>
        /// x-ms-error-code
        /// </summary>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FailureNoContent instances.
        /// You can use ShareModelFactory.FailureNoContent instead.
        /// </summary>
        internal FailureNoContent() { }
    }
}
#endregion class FailureNoContent

#region class FileUploadRangeFromURLResult
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// File UploadRangeFromURLResult
    /// </summary>
    internal partial class FileUploadRangeFromURLResult
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the directory was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// This header is returned so that the client can check for message content integrity. The value of this header is computed by the File service; it is not necessarily the same value as may have been specified in the request headers.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] XMSContentCrc64 { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileUploadRangeFromURLResult instances.
        /// You can use ShareModelFactory.FileUploadRangeFromURLResult instead.
        /// </summary>
        internal FileUploadRangeFromURLResult() { }
    }
}
#endregion class FileUploadRangeFromURLResult

#region class FileItem
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed file item.
    /// </summary>
    internal partial class FileItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// File properties.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.FileProperty Properties { get; internal set; }

        /// <summary>
        /// Creates a new FileItem instance
        /// </summary>
        public FileItem()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new FileItem instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal FileItem(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Properties = new Azure.Storage.Files.Shares.Models.FileProperty();
            }
        }

        /// <summary>
        /// Deserializes XML into a new FileItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FileItem instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.FileItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.FileItem _value = new Azure.Storage.Files.Shares.Models.FileItem(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Properties", ""));
            if (_child != null)
            {
                _value.Properties = Azure.Storage.Files.Shares.Models.FileProperty.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.FileItem value);
    }
}
#endregion class FileItem

#region class FileLeaseReleaseInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// FileLeaseReleaseInfo
    /// </summary>
    public partial class FileLeaseReleaseInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileLeaseReleaseInfo instances.
        /// You can use ShareModelFactory.FileLeaseReleaseInfo instead.
        /// </summary>
        internal FileLeaseReleaseInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new FileLeaseReleaseInfo instance for mocking.
        /// </summary>
        public static FileLeaseReleaseInfo FileLeaseReleaseInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new FileLeaseReleaseInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }
    }
}
#endregion class FileLeaseReleaseInfo

#region class FileProperty
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// File properties.
    /// </summary>
    internal partial class FileProperty
    {
        /// <summary>
        /// Content length of the file. This value may not be up-to-date since an SMB client may have modified the file locally. The value of Content-Length may not reflect that fact until the handle is closed or the op-lock is broken. To retrieve current property values, call Get File Properties.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileProperty instances.
        /// You can use ShareModelFactory.FileProperty instead.
        /// </summary>
        internal FileProperty() { }

        /// <summary>
        /// Deserializes XML into a new FileProperty instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FileProperty instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.FileProperty FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.FileProperty _value = new Azure.Storage.Files.Shares.Models.FileProperty();
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Length", ""));
            if (_child != null)
            {
                _value.ContentLength = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.FileProperty value);
    }
}
#endregion class FileProperty

#region class FileRange
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An Azure Storage file range.
    /// </summary>
    internal partial class FileRange
    {
        /// <summary>
        /// Start of the range.
        /// </summary>
        public long Start { get; internal set; }

        /// <summary>
        /// End of the range.
        /// </summary>
        public long End { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileRange instances.
        /// You can use ShareModelFactory.FileRange instead.
        /// </summary>
        internal FileRange() { }

        /// <summary>
        /// Deserializes XML into a new FileRange instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FileRange instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.FileRange FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.FileRange _value = new Azure.Storage.Files.Shares.Models.FileRange();
            _child = element.Element(System.Xml.Linq.XName.Get("Start", ""));
            if (_child != null)
            {
                _value.Start = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("End", ""));
            if (_child != null)
            {
                _value.End = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.FileRange value);
    }
}
#endregion class FileRange

#region class FilesAndDirectoriesSegment
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An enumeration of directories and files.
    /// </summary>
    internal partial class FilesAndDirectoriesSegment
    {
        /// <summary>
        /// ServiceEndpoint
        /// </summary>
        public string ServiceEndpoint { get; internal set; }

        /// <summary>
        /// ShareName
        /// </summary>
        public string ShareName { get; internal set; }

        /// <summary>
        /// ShareSnapshot
        /// </summary>
        public string ShareSnapshot { get; internal set; }

        /// <summary>
        /// DirectoryPath
        /// </summary>
        public string DirectoryPath { get; internal set; }

        /// <summary>
        /// Prefix
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        /// Marker
        /// </summary>
        public string Marker { get; internal set; }

        /// <summary>
        /// MaxResults
        /// </summary>
        public int? MaxResults { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// DirectoryItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.DirectoryItem> DirectoryItems { get; internal set; }

        /// <summary>
        /// FileItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.FileItem> FileItems { get; internal set; }

        /// <summary>
        /// Creates a new FilesAndDirectoriesSegment instance
        /// </summary>
        public FilesAndDirectoriesSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new FilesAndDirectoriesSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal FilesAndDirectoriesSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                DirectoryItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.DirectoryItem>();
                FileItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.FileItem>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new FilesAndDirectoriesSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized FilesAndDirectoriesSegment instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            System.Xml.Linq.XAttribute _attribute;
            Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment _value = new Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment(true);
            _attribute = element.Attribute(System.Xml.Linq.XName.Get("ServiceEndpoint", ""));
            if (_attribute != null)
            {
                _value.ServiceEndpoint = _attribute.Value;
            }
            _attribute = element.Attribute(System.Xml.Linq.XName.Get("ShareName", ""));
            if (_attribute != null)
            {
                _value.ShareName = _attribute.Value;
            }
            _attribute = element.Attribute(System.Xml.Linq.XName.Get("ShareSnapshot", ""));
            if (_attribute != null)
            {
                _value.ShareSnapshot = _attribute.Value;
            }
            _attribute = element.Attribute(System.Xml.Linq.XName.Get("DirectoryPath", ""));
            if (_attribute != null)
            {
                _value.DirectoryPath = _attribute.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Prefix", ""));
            if (_child != null)
            {
                _value.Prefix = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Marker", ""));
            if (_child != null)
            {
                _value.Marker = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MaxResults", ""));
            if (_child != null)
            {
                _value.MaxResults = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("NextMarker", ""));
            if (_child != null)
            {
                _value.NextMarker = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Entries", ""));
            if (_child != null)
            {
                _value.DirectoryItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Directory", "")),
                        e => Azure.Storage.Files.Shares.Models.DirectoryItem.FromXml(e)));
            }
            else
            {
                _value.DirectoryItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.DirectoryItem>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Entries", ""));
            if (_child != null)
            {
                _value.FileItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("File", "")),
                        e => Azure.Storage.Files.Shares.Models.FileItem.FromXml(e)));
            }
            else
            {
                _value.FileItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.FileItem>();
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.FilesAndDirectoriesSegment value);
    }
}
#endregion class FilesAndDirectoriesSegment

#region class FlattenedStorageFileProperties
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// FlattenedStorageFileProperties
    /// </summary>
    internal partial class FlattenedStorageFileProperties
    {
        /// <summary>
        /// Returns the date and time the file was last modified. Any operation that modifies the file or its properties updates the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned if the client requested a subset of the file by setting the Range request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// If the file has an MD5 hash and the request is to read the full file, this response header is returned so that the client can check for message content integrity. If the request is to read a specified range and the 'x-ms-range-get-content-md5' is set to true, then the request returns an MD5 hash for the range, as long as the range size is less than or equal to 4 MB. If neither of these sets of conditions is true, then no value is returned for the 'Content-MD5' header.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentEncoding { get; internal set; }

        /// <summary>
        /// Returned if it was previously specified for the file.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the 'x-ms-content-disposition' header and specifies how to process the response.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the Content-Language request header.
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentLanguage { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy File operation where this file was the destination file. This value can specify the time of a completed, aborted, or failed copy attempt.
        /// </summary>
        public System.DateTimeOffset CopyCompletionTime { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes cause of fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy File operation where this file was the destination file. Can show between 0 and Content-Length bytes copied.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2KB in length that specifies the source file used in the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public System.Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// If the file has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole file's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] FileContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Attributes set for the file.
        /// </summary>
        public string FileAttributes { get; internal set; }

        /// <summary>
        /// Creation time for the file.
        /// </summary>
        public System.DateTimeOffset FileCreationTime { get; internal set; }

        /// <summary>
        /// Last write time for the file.
        /// </summary>
        public System.DateTimeOffset FileLastWriteTime { get; internal set; }

        /// <summary>
        /// Change time for the file.
        /// </summary>
        public System.DateTimeOffset FileChangeTime { get; internal set; }

        /// <summary>
        /// Key of the permission set for the file.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// The fileId of the file.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parent fileId of the file.
        /// </summary>
        public string FileParentId { get; internal set; }

        /// <summary>
        /// When a file is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseDuration LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the file.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the file.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public System.IO.Stream Content { get; internal set; }

        /// <summary>
        /// Creates a new FlattenedStorageFileProperties instance
        /// </summary>
        public FlattenedStorageFileProperties()
        {
            Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            ContentEncoding = new System.Collections.Generic.List<string>();
            ContentLanguage = new System.Collections.Generic.List<string>();
        }
    }
}
#endregion class FlattenedStorageFileProperties

#region enum ListSharesIncludeType
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ListSharesIncludeType values
    /// </summary>
    internal enum ListSharesIncludeType
    {
        /// <summary>
        /// snapshots
        /// </summary>
        Snapshots,

        /// <summary>
        /// metadata
        /// </summary>
        Metadata,

        /// <summary>
        /// deleted
        /// </summary>
        Deleted
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ListSharesIncludeType value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Snapshots => "snapshots",
                    Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Metadata => "metadata",
                    Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Deleted => "deleted",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ListSharesIncludeType value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ListSharesIncludeType ParseListSharesIncludeType(string value)
            {
                return value switch
                {
                    "snapshots" => Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Snapshots,
                    "metadata" => Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Metadata,
                    "deleted" => Azure.Storage.Files.Shares.Models.ListSharesIncludeType.Deleted,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ListSharesIncludeType value.")
                };
            }
        }
    }
}
#endregion enum ListSharesIncludeType

#region enum PermissionCopyMode
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies the option to copy file security descriptor from source file or to set it using the value which is defined by the header value of x-ms-file-permission or x-ms-file-permission-key.
    /// </summary>
    public enum PermissionCopyMode
    {
        /// <summary>
        /// source
        /// </summary>
        Source,

        /// <summary>
        /// override
        /// </summary>
        Override
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.PermissionCopyMode value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.PermissionCopyMode.Source => "source",
                    Azure.Storage.Files.Shares.Models.PermissionCopyMode.Override => "override",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.PermissionCopyMode value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.PermissionCopyMode ParsePermissionCopyMode(string value)
            {
                return value switch
                {
                    "source" => Azure.Storage.Files.Shares.Models.PermissionCopyMode.Source,
                    "override" => Azure.Storage.Files.Shares.Models.PermissionCopyMode.Override,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.PermissionCopyMode value.")
                };
            }
        }
    }
}
#endregion enum PermissionCopyMode

#region class PermissionInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// PermissionInfo
    /// </summary>
    public partial class PermissionInfo
    {
        /// <summary>
        /// Key of the permission set for the directory/file.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PermissionInfo instances.
        /// You can use ShareModelFactory.PermissionInfo instead.
        /// </summary>
        internal PermissionInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new PermissionInfo instance for mocking.
        /// </summary>
        public static PermissionInfo PermissionInfo(
            string filePermissionKey)
        {
            return new PermissionInfo()
            {
                FilePermissionKey = filePermissionKey,
            };
        }
    }
}
#endregion class PermissionInfo

#region class RawStorageDirectoryInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// RawStorageDirectoryInfo
    /// </summary>
    internal partial class RawStorageDirectoryInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the directory, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Key of the permission set for the directory.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// Attributes set for the directory.
        /// </summary>
        public string FileAttributes { get; internal set; }

        /// <summary>
        /// Creation time for the directory.
        /// </summary>
        public System.DateTimeOffset FileCreationTime { get; internal set; }

        /// <summary>
        /// Last write time for the directory.
        /// </summary>
        public System.DateTimeOffset FileLastWriteTime { get; internal set; }

        /// <summary>
        /// Change time for the directory.
        /// </summary>
        public System.DateTimeOffset FileChangeTime { get; internal set; }

        /// <summary>
        /// The fileId of the directory.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parent fileId of the directory.
        /// </summary>
        public string FileParentId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of RawStorageDirectoryInfo instances.
        /// You can use ShareModelFactory.RawStorageDirectoryInfo instead.
        /// </summary>
        internal RawStorageDirectoryInfo() { }
    }
}
#endregion class RawStorageDirectoryInfo

#region class RawStorageDirectoryProperties
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// RawStorageDirectoryProperties
    /// </summary>
    internal partial class RawStorageDirectoryProperties
    {
        /// <summary>
        /// A set of name-value pairs that contain metadata for the directory.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the Directory was last modified. Operations on files within the directory do not affect the last modified time of the directory.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the directory metadata is completely encrypted using the specified algorithm. Otherwise, the value is set to false.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Attributes set for the directory.
        /// </summary>
        public string FileAttributes { get; internal set; }

        /// <summary>
        /// Creation time for the directory.
        /// </summary>
        public System.DateTimeOffset FileCreationTime { get; internal set; }

        /// <summary>
        /// Last write time for the directory.
        /// </summary>
        public System.DateTimeOffset FileLastWriteTime { get; internal set; }

        /// <summary>
        /// Change time for the directory.
        /// </summary>
        public System.DateTimeOffset FileChangeTime { get; internal set; }

        /// <summary>
        /// Key of the permission set for the directory.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// The fileId of the directory.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parent fileId of the directory.
        /// </summary>
        public string FileParentId { get; internal set; }

        /// <summary>
        /// Creates a new RawStorageDirectoryProperties instance
        /// </summary>
        public RawStorageDirectoryProperties()
        {
            Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }
    }
}
#endregion class RawStorageDirectoryProperties

#region class RawStorageFileInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// RawStorageFileInfo
    /// </summary>
    internal partial class RawStorageFileInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Key of the permission set for the file.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// Attributes set for the file.
        /// </summary>
        public string FileAttributes { get; internal set; }

        /// <summary>
        /// Creation time for the file.
        /// </summary>
        public System.DateTimeOffset FileCreationTime { get; internal set; }

        /// <summary>
        /// Last write time for the file.
        /// </summary>
        public System.DateTimeOffset FileLastWriteTime { get; internal set; }

        /// <summary>
        /// Change time for the file.
        /// </summary>
        public System.DateTimeOffset FileChangeTime { get; internal set; }

        /// <summary>
        /// The fileId of the file.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parent fileId of the file.
        /// </summary>
        public string FileParentId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of RawStorageFileInfo instances.
        /// You can use ShareModelFactory.RawStorageFileInfo instead.
        /// </summary>
        internal RawStorageFileInfo() { }
    }
}
#endregion class RawStorageFileInfo

#region class RawStorageFileProperties
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// RawStorageFileProperties
    /// </summary>
    internal partial class RawStorageFileProperties
    {
        /// <summary>
        /// Returns the date and time the file was last modified. The date format follows RFC 1123. Any operation that modifies the file or its properties updates the last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The size of the file in bytes. This header returns the value of the 'x-ms-content-length' header that is stored with the file.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// If the Content-MD5 header has been set for the file, the Content-MD5 response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the file, the Content-Encoding value is returned in this header.
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the file, the Cache-Control value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the 'x-ms-content-disposition' header and specifies how to process the response.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the Content-Language request header.
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentLanguage { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy File operation where this file was the destination file. This value can specify the time of a completed, aborted, or failed copy attempt.
        /// </summary>
        public System.DateTimeOffset CopyCompletionTime { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes cause of fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy File operation where this file was the destination file. Can show between 0 and Content-Length bytes copied.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2KB in length that specifies the source file used in the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Attributes set for the file.
        /// </summary>
        public string FileAttributes { get; internal set; }

        /// <summary>
        /// Creation time for the file.
        /// </summary>
        public System.DateTimeOffset FileCreationTime { get; internal set; }

        /// <summary>
        /// Last write time for the file.
        /// </summary>
        public System.DateTimeOffset FileLastWriteTime { get; internal set; }

        /// <summary>
        /// Change time for the file.
        /// </summary>
        public System.DateTimeOffset FileChangeTime { get; internal set; }

        /// <summary>
        /// Key of the permission set for the file.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// The fileId of the file.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The parent fileId of the file.
        /// </summary>
        public string FileParentId { get; internal set; }

        /// <summary>
        /// When a file is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseDuration LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the file.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the file.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// Creates a new RawStorageFileProperties instance
        /// </summary>
        public RawStorageFileProperties()
        {
            Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            ContentEncoding = new System.Collections.Generic.List<string>();
            ContentLanguage = new System.Collections.Generic.List<string>();
        }
    }
}
#endregion class RawStorageFileProperties

#region class ShareAccessPolicy
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An Access policy.
    /// </summary>
    public partial class ShareAccessPolicy
    {
        /// <summary>
        /// The date-time the policy is active.
        /// </summary>
        public System.DateTimeOffset? PolicyStartsOn { get; set; }

        /// <summary>
        /// The date-time the policy expires.
        /// </summary>
        public System.DateTimeOffset? PolicyExpiresOn { get; set; }

        /// <summary>
        /// The permissions for the ACL policy.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Creates a new ShareAccessPolicy instance
        /// </summary>
        public ShareAccessPolicy() { }

        /// <summary>
        /// Serialize a ShareAccessPolicy instance as XML.
        /// </summary>
        /// <param name="value">The ShareAccessPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "AccessPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareAccessPolicy value, string name = "AccessPolicy", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.PolicyStartsOn != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Start", ""),
                    value.PolicyStartsOn.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
            }
            if (value.PolicyExpiresOn != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Expiry", ""),
                    value.PolicyExpiresOn.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
            }
            if (value.Permissions != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Permission", ""),
                    value.Permissions));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareAccessPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareAccessPolicy instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareAccessPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareAccessPolicy _value = new Azure.Storage.Files.Shares.Models.ShareAccessPolicy();
            _child = element.Element(System.Xml.Linq.XName.Get("Start", ""));
            if (_child != null)
            {
                _value.PolicyStartsOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Expiry", ""));
            if (_child != null)
            {
                _value.PolicyExpiresOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Permission", ""));
            if (_child != null)
            {
                _value.Permissions = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareAccessPolicy value);
    }
}
#endregion class ShareAccessPolicy

#region enum strings ShareAccessTier
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies the access tier of the share.
    /// </summary>
    public readonly struct ShareAccessTier : System.IEquatable<ShareAccessTier>
    {
        /// <summary>
        /// The ShareAccessTier value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareAccessTier"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public ShareAccessTier(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }

        /// <summary>
        /// TransactionOptimized
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareAccessTier TransactionOptimized { get; } = new ShareAccessTier(@"TransactionOptimized");

        /// <summary>
        /// Hot
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareAccessTier Hot { get; } = new ShareAccessTier(@"Hot");

        /// <summary>
        /// Cool
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareAccessTier Cool { get; } = new ShareAccessTier(@"Cool");

        /// <summary>
        /// Determines if two <see cref="ShareAccessTier"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ShareAccessTier"/> to compare.</param>
        /// <param name="right">The second <see cref="ShareAccessTier"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(Azure.Storage.Files.Shares.Models.ShareAccessTier left, Azure.Storage.Files.Shares.Models.ShareAccessTier right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ShareAccessTier"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ShareAccessTier"/> to compare.</param>
        /// <param name="right">The second <see cref="ShareAccessTier"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(Azure.Storage.Files.Shares.Models.ShareAccessTier left, Azure.Storage.Files.Shares.Models.ShareAccessTier right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="ShareAccessTier"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The ShareAccessTier value.</returns>
        public static implicit operator ShareAccessTier(string value) => new Azure.Storage.Files.Shares.Models.ShareAccessTier(value);

        /// <summary>
        /// Check if two <see cref="ShareAccessTier"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Azure.Storage.Files.Shares.Models.ShareAccessTier other && Equals(other);

        /// <summary>
        /// Check if two <see cref="ShareAccessTier"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Files.Shares.Models.ShareAccessTier other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

        /// <summary>
        /// Get a hash code for the <see cref="ShareAccessTier"/>.
        /// </summary>
        /// <returns>Hash code for the ShareAccessTier.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// Convert the <see cref="ShareAccessTier"/> to a string.
        /// </summary>
        /// <returns>String representation of the ShareAccessTier.</returns>
        public override string ToString() => _value;
    }
}
#endregion enum strings ShareAccessTier

#region class ShareCorsRule
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// CORS is an HTTP feature that enables a web application running under one domain to access resources in another domain. Web browsers implement a security restriction known as same-origin policy that prevents a web page from calling APIs in a different domain; CORS provides a secure way to allow one domain (the origin domain) to call APIs in another domain.
    /// </summary>
    public partial class ShareCorsRule
    {
        /// <summary>
        /// The origin domains that are permitted to make a request against the storage service via CORS. The origin domain is the domain from which the request originates. Note that the origin must be an exact case-sensitive match with the origin that the user age sends to the service. You can also use the wildcard character '*' to allow all origin domains to make requests via CORS.
        /// </summary>
        public string AllowedOrigins { get; set; }

        /// <summary>
        /// The methods (HTTP request verbs) that the origin domain may use for a CORS request. (comma separated)
        /// </summary>
        public string AllowedMethods { get; set; }

        /// <summary>
        /// The request headers that the origin domain may specify on the CORS request.
        /// </summary>
        public string AllowedHeaders { get; set; }

        /// <summary>
        /// The response headers that may be sent in the response to the CORS request and exposed by the browser to the request issuer.
        /// </summary>
        public string ExposedHeaders { get; set; }

        /// <summary>
        /// The maximum amount time that a browser should cache the preflight OPTIONS request.
        /// </summary>
        public int MaxAgeInSeconds { get; set; }

        /// <summary>
        /// Creates a new ShareCorsRule instance
        /// </summary>
        public ShareCorsRule() { }

        /// <summary>
        /// Serialize a ShareCorsRule instance as XML.
        /// </summary>
        /// <param name="value">The ShareCorsRule instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "CorsRule".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareCorsRule value, string name = "CorsRule", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("AllowedOrigins", ""),
                value.AllowedOrigins));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("AllowedMethods", ""),
                value.AllowedMethods));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("AllowedHeaders", ""),
                value.AllowedHeaders));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("ExposedHeaders", ""),
                value.ExposedHeaders));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("MaxAgeInSeconds", ""),
                value.MaxAgeInSeconds.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareCorsRule instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareCorsRule instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareCorsRule FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareCorsRule _value = new Azure.Storage.Files.Shares.Models.ShareCorsRule();
            _child = element.Element(System.Xml.Linq.XName.Get("AllowedOrigins", ""));
            if (_child != null)
            {
                _value.AllowedOrigins = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AllowedMethods", ""));
            if (_child != null)
            {
                _value.AllowedMethods = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AllowedHeaders", ""));
            if (_child != null)
            {
                _value.AllowedHeaders = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ExposedHeaders", ""));
            if (_child != null)
            {
                _value.ExposedHeaders = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MaxAgeInSeconds", ""));
            if (_child != null)
            {
                _value.MaxAgeInSeconds = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareCorsRule value);
    }
}
#endregion class ShareCorsRule

#region enum strings ShareErrorCode
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Error codes returned by the service
    /// </summary>
    public readonly struct ShareErrorCode : System.IEquatable<ShareErrorCode>
    {
        /// <summary>
        /// The ShareErrorCode value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareErrorCode"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public ShareErrorCode(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }

        /// <summary>
        /// AccountAlreadyExists
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountAlreadyExists { get; } = new ShareErrorCode(@"AccountAlreadyExists");

        /// <summary>
        /// AccountBeingCreated
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountBeingCreated { get; } = new ShareErrorCode(@"AccountBeingCreated");

        /// <summary>
        /// AccountIsDisabled
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountIsDisabled { get; } = new ShareErrorCode(@"AccountIsDisabled");

        /// <summary>
        /// AuthenticationFailed
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthenticationFailed { get; } = new ShareErrorCode(@"AuthenticationFailed");

        /// <summary>
        /// AuthorizationFailure
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationFailure { get; } = new ShareErrorCode(@"AuthorizationFailure");

        /// <summary>
        /// ConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ConditionHeadersNotSupported { get; } = new ShareErrorCode(@"ConditionHeadersNotSupported");

        /// <summary>
        /// ConditionNotMet
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ConditionNotMet { get; } = new ShareErrorCode(@"ConditionNotMet");

        /// <summary>
        /// EmptyMetadataKey
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode EmptyMetadataKey { get; } = new ShareErrorCode(@"EmptyMetadataKey");

        /// <summary>
        /// InsufficientAccountPermissions
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InsufficientAccountPermissions { get; } = new ShareErrorCode(@"InsufficientAccountPermissions");

        /// <summary>
        /// InternalError
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InternalError { get; } = new ShareErrorCode(@"InternalError");

        /// <summary>
        /// InvalidAuthenticationInfo
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidAuthenticationInfo { get; } = new ShareErrorCode(@"InvalidAuthenticationInfo");

        /// <summary>
        /// InvalidHeaderValue
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidHeaderValue { get; } = new ShareErrorCode(@"InvalidHeaderValue");

        /// <summary>
        /// InvalidHttpVerb
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidHttpVerb { get; } = new ShareErrorCode(@"InvalidHttpVerb");

        /// <summary>
        /// InvalidInput
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidInput { get; } = new ShareErrorCode(@"InvalidInput");

        /// <summary>
        /// InvalidMd5
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidMd5 { get; } = new ShareErrorCode(@"InvalidMd5");

        /// <summary>
        /// InvalidMetadata
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidMetadata { get; } = new ShareErrorCode(@"InvalidMetadata");

        /// <summary>
        /// InvalidQueryParameterValue
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidQueryParameterValue { get; } = new ShareErrorCode(@"InvalidQueryParameterValue");

        /// <summary>
        /// InvalidRange
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidRange { get; } = new ShareErrorCode(@"InvalidRange");

        /// <summary>
        /// InvalidResourceName
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidResourceName { get; } = new ShareErrorCode(@"InvalidResourceName");

        /// <summary>
        /// InvalidUri
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidUri { get; } = new ShareErrorCode(@"InvalidUri");

        /// <summary>
        /// InvalidXmlDocument
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidXmlDocument { get; } = new ShareErrorCode(@"InvalidXmlDocument");

        /// <summary>
        /// InvalidXmlNodeValue
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidXmlNodeValue { get; } = new ShareErrorCode(@"InvalidXmlNodeValue");

        /// <summary>
        /// Md5Mismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode Md5Mismatch { get; } = new ShareErrorCode(@"Md5Mismatch");

        /// <summary>
        /// MetadataTooLarge
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MetadataTooLarge { get; } = new ShareErrorCode(@"MetadataTooLarge");

        /// <summary>
        /// MissingContentLengthHeader
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingContentLengthHeader { get; } = new ShareErrorCode(@"MissingContentLengthHeader");

        /// <summary>
        /// MissingRequiredQueryParameter
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredQueryParameter { get; } = new ShareErrorCode(@"MissingRequiredQueryParameter");

        /// <summary>
        /// MissingRequiredHeader
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredHeader { get; } = new ShareErrorCode(@"MissingRequiredHeader");

        /// <summary>
        /// MissingRequiredXmlNode
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredXmlNode { get; } = new ShareErrorCode(@"MissingRequiredXmlNode");

        /// <summary>
        /// MultipleConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MultipleConditionHeadersNotSupported { get; } = new ShareErrorCode(@"MultipleConditionHeadersNotSupported");

        /// <summary>
        /// OperationTimedOut
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OperationTimedOut { get; } = new ShareErrorCode(@"OperationTimedOut");

        /// <summary>
        /// OutOfRangeInput
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OutOfRangeInput { get; } = new ShareErrorCode(@"OutOfRangeInput");

        /// <summary>
        /// OutOfRangeQueryParameterValue
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OutOfRangeQueryParameterValue { get; } = new ShareErrorCode(@"OutOfRangeQueryParameterValue");

        /// <summary>
        /// RequestBodyTooLarge
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode RequestBodyTooLarge { get; } = new ShareErrorCode(@"RequestBodyTooLarge");

        /// <summary>
        /// ResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceTypeMismatch { get; } = new ShareErrorCode(@"ResourceTypeMismatch");

        /// <summary>
        /// RequestUrlFailedToParse
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode RequestUrlFailedToParse { get; } = new ShareErrorCode(@"RequestUrlFailedToParse");

        /// <summary>
        /// ResourceAlreadyExists
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceAlreadyExists { get; } = new ShareErrorCode(@"ResourceAlreadyExists");

        /// <summary>
        /// ResourceNotFound
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceNotFound { get; } = new ShareErrorCode(@"ResourceNotFound");

        /// <summary>
        /// ServerBusy
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ServerBusy { get; } = new ShareErrorCode(@"ServerBusy");

        /// <summary>
        /// UnsupportedHeader
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedHeader { get; } = new ShareErrorCode(@"UnsupportedHeader");

        /// <summary>
        /// UnsupportedXmlNode
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedXmlNode { get; } = new ShareErrorCode(@"UnsupportedXmlNode");

        /// <summary>
        /// UnsupportedQueryParameter
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedQueryParameter { get; } = new ShareErrorCode(@"UnsupportedQueryParameter");

        /// <summary>
        /// UnsupportedHttpVerb
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedHttpVerb { get; } = new ShareErrorCode(@"UnsupportedHttpVerb");

        /// <summary>
        /// CannotDeleteFileOrDirectory
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode CannotDeleteFileOrDirectory { get; } = new ShareErrorCode(@"CannotDeleteFileOrDirectory");

        /// <summary>
        /// ClientCacheFlushDelay
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ClientCacheFlushDelay { get; } = new ShareErrorCode(@"ClientCacheFlushDelay");

        /// <summary>
        /// DeletePending
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode DeletePending { get; } = new ShareErrorCode(@"DeletePending");

        /// <summary>
        /// DirectoryNotEmpty
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode DirectoryNotEmpty { get; } = new ShareErrorCode(@"DirectoryNotEmpty");

        /// <summary>
        /// FileLockConflict
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode FileLockConflict { get; } = new ShareErrorCode(@"FileLockConflict");

        /// <summary>
        /// InvalidFileOrDirectoryPathName
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidFileOrDirectoryPathName { get; } = new ShareErrorCode(@"InvalidFileOrDirectoryPathName");

        /// <summary>
        /// ParentNotFound
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ParentNotFound { get; } = new ShareErrorCode(@"ParentNotFound");

        /// <summary>
        /// ReadOnlyAttribute
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ReadOnlyAttribute { get; } = new ShareErrorCode(@"ReadOnlyAttribute");

        /// <summary>
        /// ShareAlreadyExists
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareAlreadyExists { get; } = new ShareErrorCode(@"ShareAlreadyExists");

        /// <summary>
        /// ShareBeingDeleted
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareBeingDeleted { get; } = new ShareErrorCode(@"ShareBeingDeleted");

        /// <summary>
        /// ShareDisabled
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareDisabled { get; } = new ShareErrorCode(@"ShareDisabled");

        /// <summary>
        /// ShareNotFound
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareNotFound { get; } = new ShareErrorCode(@"ShareNotFound");

        /// <summary>
        /// SharingViolation
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode SharingViolation { get; } = new ShareErrorCode(@"SharingViolation");

        /// <summary>
        /// ShareSnapshotInProgress
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotInProgress { get; } = new ShareErrorCode(@"ShareSnapshotInProgress");

        /// <summary>
        /// ShareSnapshotCountExceeded
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotCountExceeded { get; } = new ShareErrorCode(@"ShareSnapshotCountExceeded");

        /// <summary>
        /// ShareSnapshotOperationNotSupported
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotOperationNotSupported { get; } = new ShareErrorCode(@"ShareSnapshotOperationNotSupported");

        /// <summary>
        /// ShareHasSnapshots
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareHasSnapshots { get; } = new ShareErrorCode(@"ShareHasSnapshots");

        /// <summary>
        /// ContainerQuotaDowngradeNotAllowed
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ContainerQuotaDowngradeNotAllowed { get; } = new ShareErrorCode(@"ContainerQuotaDowngradeNotAllowed");

        /// <summary>
        /// AuthorizationSourceIPMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationSourceIPMismatch { get; } = new ShareErrorCode(@"AuthorizationSourceIPMismatch");

        /// <summary>
        /// AuthorizationProtocolMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationProtocolMismatch { get; } = new ShareErrorCode(@"AuthorizationProtocolMismatch");

        /// <summary>
        /// AuthorizationPermissionMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationPermissionMismatch { get; } = new ShareErrorCode(@"AuthorizationPermissionMismatch");

        /// <summary>
        /// AuthorizationServiceMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationServiceMismatch { get; } = new ShareErrorCode(@"AuthorizationServiceMismatch");

        /// <summary>
        /// AuthorizationResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationResourceTypeMismatch { get; } = new ShareErrorCode(@"AuthorizationResourceTypeMismatch");

        /// <summary>
        /// FeatureVersionMismatch
        /// </summary>
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode FeatureVersionMismatch { get; } = new ShareErrorCode(@"FeatureVersionMismatch");

        /// <summary>
        /// Determines if two <see cref="ShareErrorCode"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ShareErrorCode"/> to compare.</param>
        /// <param name="right">The second <see cref="ShareErrorCode"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(Azure.Storage.Files.Shares.Models.ShareErrorCode left, Azure.Storage.Files.Shares.Models.ShareErrorCode right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ShareErrorCode"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ShareErrorCode"/> to compare.</param>
        /// <param name="right">The second <see cref="ShareErrorCode"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(Azure.Storage.Files.Shares.Models.ShareErrorCode left, Azure.Storage.Files.Shares.Models.ShareErrorCode right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="ShareErrorCode"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The ShareErrorCode value.</returns>
        public static implicit operator ShareErrorCode(string value) => new Azure.Storage.Files.Shares.Models.ShareErrorCode(value);

        /// <summary>
        /// Check if two <see cref="ShareErrorCode"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Azure.Storage.Files.Shares.Models.ShareErrorCode other && Equals(other);

        /// <summary>
        /// Check if two <see cref="ShareErrorCode"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Files.Shares.Models.ShareErrorCode other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

        /// <summary>
        /// Get a hash code for the <see cref="ShareErrorCode"/>.
        /// </summary>
        /// <returns>Hash code for the ShareErrorCode.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// Convert the <see cref="ShareErrorCode"/> to a string.
        /// </summary>
        /// <returns>String representation of the ShareErrorCode.</returns>
        public override string ToString() => _value;
    }
}
#endregion enum strings ShareErrorCode

#region class ShareFileCopyInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileCopyInfo
    /// </summary>
    public partial class ShareFileCopyInfo
    {
        /// <summary>
        /// If the copy is completed, contains the ETag of the destination file. If the copy is not complete, contains the ETag of the empty file created at the start of the copy.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date/time that the copy operation to the destination file completed.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get File or Get File Properties to check the status of this copy operation, or pass to Abort Copy File to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileCopyInfo instances.
        /// You can use ShareModelFactory.ShareFileCopyInfo instead.
        /// </summary>
        internal ShareFileCopyInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileCopyInfo instance for mocking.
        /// </summary>
        public static ShareFileCopyInfo ShareFileCopyInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            string copyId,
            Azure.Storage.Files.Shares.Models.CopyStatus copyStatus)
        {
            return new ShareFileCopyInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                CopyId = copyId,
                CopyStatus = copyStatus,
            };
        }
    }
}
#endregion class ShareFileCopyInfo

#region class ShareFileHandle
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed Azure Storage handle item.
    /// </summary>
    public partial class ShareFileHandle
    {
        /// <summary>
        /// XSMB service handle ID
        /// </summary>
        public string HandleId { get; internal set; }

        /// <summary>
        /// File or directory name including full path starting from share root
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// FileId uniquely identifies the file or directory.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// ParentId uniquely identifies the parent directory of the object.
        /// </summary>
        public string ParentId { get; internal set; }

        /// <summary>
        /// SMB session ID in context of which the file handle was opened
        /// </summary>
        public string SessionId { get; internal set; }

        /// <summary>
        /// Client IP that opened the handle
        /// </summary>
        public string ClientIp { get; internal set; }

        /// <summary>
        /// Time when the session that previously opened the handle has last been reconnected. (UTC)
        /// </summary>
        public System.DateTimeOffset? OpenedOn { get; internal set; }

        /// <summary>
        /// Time handle was last connected to (UTC)
        /// </summary>
        public System.DateTimeOffset? LastReconnectedOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileHandle instances.
        /// You can use ShareModelFactory.ShareFileHandle instead.
        /// </summary>
        internal ShareFileHandle() { }

        /// <summary>
        /// Deserializes XML into a new ShareFileHandle instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareFileHandle instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareFileHandle FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareFileHandle _value = new Azure.Storage.Files.Shares.Models.ShareFileHandle();
            _child = element.Element(System.Xml.Linq.XName.Get("HandleId", ""));
            if (_child != null)
            {
                _value.HandleId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Path", ""));
            if (_child != null)
            {
                _value.Path = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("FileId", ""));
            if (_child != null)
            {
                _value.FileId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ParentId", ""));
            if (_child != null)
            {
                _value.ParentId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("SessionId", ""));
            if (_child != null)
            {
                _value.SessionId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ClientIp", ""));
            if (_child != null)
            {
                _value.ClientIp = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("OpenTime", ""));
            if (_child != null)
            {
                _value.OpenedOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LastReconnectTime", ""));
            if (_child != null)
            {
                _value.LastReconnectedOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareFileHandle value);
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileHandle instance for mocking.
        /// </summary>
        public static ShareFileHandle ShareFileHandle(
            string handleId,
            string path,
            string fileId,
            string sessionId,
            string clientIp,
            string parentId = default,
            System.DateTimeOffset? openedOn = default,
            System.DateTimeOffset? lastReconnectedOn = default)
        {
            return new ShareFileHandle()
            {
                HandleId = handleId,
                Path = path,
                FileId = fileId,
                SessionId = sessionId,
                ClientIp = clientIp,
                ParentId = parentId,
                OpenedOn = openedOn,
                LastReconnectedOn = lastReconnectedOn,
            };
        }
    }
}
#endregion class ShareFileHandle

#region class ShareFileLease
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileLease
    /// </summary>
    public partial class ShareFileLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Uniquely identifies a file's lease
        /// </summary>
        public string LeaseId { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileLease instances.
        /// You can use ShareModelFactory.ShareFileLease instead.
        /// </summary>
        internal ShareFileLease() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileLease instance for mocking.
        /// </summary>
        public static ShareFileLease ShareFileLease(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            string leaseId)
        {
            return new ShareFileLease()
            {
                ETag = eTag,
                LastModified = lastModified,
                LeaseId = leaseId,
            };
        }
    }
}
#endregion class ShareFileLease

#region class ShareFileRangeInfoInternal
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileRangeInfoInternal
    /// </summary>
    internal partial class ShareFileRangeInfoInternal
    {
        /// <summary>
        /// The date/time that the file was last modified. Any operation that modifies the file, including an update of the file's metadata or properties, changes the file's last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long FileContentLength { get; internal set; }

        /// <summary>
        /// The list of file ranges
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareFileRangeList Body { get; internal set; }

        /// <summary>
        /// Creates a new ShareFileRangeInfoInternal instance
        /// </summary>
        public ShareFileRangeInfoInternal()
        {
            Body = new Azure.Storage.Files.Shares.Models.ShareFileRangeList();
        }
    }
}
#endregion class ShareFileRangeInfoInternal

#region class ShareFileRangeList
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The list of file ranges
    /// </summary>
    internal partial class ShareFileRangeList
    {
        /// <summary>
        /// Ranges
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.FileRange> Ranges { get; internal set; }

        /// <summary>
        /// ClearRanges
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ClearRange> ClearRanges { get; internal set; }

        /// <summary>
        /// Creates a new ShareFileRangeList instance
        /// </summary>
        public ShareFileRangeList()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareFileRangeList instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareFileRangeList(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Ranges = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.FileRange>();
                ClearRanges = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ClearRange>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new ShareFileRangeList instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareFileRangeList instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareFileRangeList FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Files.Shares.Models.ShareFileRangeList _value = new Azure.Storage.Files.Shares.Models.ShareFileRangeList(true);
            _value.Ranges = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("Range", "")),
                    e => Azure.Storage.Files.Shares.Models.FileRange.FromXml(e)));
            _value.ClearRanges = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("ClearRange", "")),
                    e => Azure.Storage.Files.Shares.Models.ClearRange.FromXml(e)));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareFileRangeList value);
    }
}
#endregion class ShareFileRangeList

#region enum ShareFileRangeWriteType
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specify one of the following options: - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update. - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and set the Range header to a value that indicates the range to clear, up to maximum file size.
    /// </summary>
    public enum ShareFileRangeWriteType
    {
        /// <summary>
        /// update
        /// </summary>
        Update,

        /// <summary>
        /// clear
        /// </summary>
        Clear
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType.Update => "update",
                    Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType.Clear => "clear",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType ParseShareFileRangeWriteType(string value)
            {
                return value switch
                {
                    "update" => Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType.Update,
                    "clear" => Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType.Clear,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType value.")
                };
            }
        }
    }
}
#endregion enum ShareFileRangeWriteType

#region class ShareFileUploadInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileUploadInfo
    /// </summary>
    public partial class ShareFileUploadInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the directory was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// This header is returned so that the client can check for message content integrity. The value of this header is computed by the File service; it is not necessarily the same value as may have been specified in the request headers.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileUploadInfo instances.
        /// You can use ShareModelFactory.ShareFileUploadInfo instead.
        /// </summary>
        internal ShareFileUploadInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileUploadInfo instance for mocking.
        /// </summary>
        public static ShareFileUploadInfo ShareFileUploadInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            bool isServerEncrypted)
        {
            return new ShareFileUploadInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                IsServerEncrypted = isServerEncrypted,
            };
        }
    }
}
#endregion class ShareFileUploadInfo

#region class ShareInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareInfo
    /// </summary>
    public partial class ShareInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the share, in quotes.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareInfo instances.
        /// You can use ShareModelFactory.ShareInfo instead.
        /// </summary>
        internal ShareInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareInfo instance for mocking.
        /// </summary>
        public static ShareInfo ShareInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new ShareInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }
    }
}
#endregion class ShareInfo

#region class ShareItemInternal
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed Azure Storage share item.
    /// </summary>
    internal partial class ShareItemInternal
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Snapshot
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// Deleted
        /// </summary>
        public bool? IsDeleted { get; internal set; }

        /// <summary>
        /// Version
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// Properties of a share.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.SharePropertiesInternal Properties { get; internal set; }

        /// <summary>
        /// Creates a new ShareItemInternal instance
        /// </summary>
        public ShareItemInternal()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareItemInternal instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareItemInternal(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Properties = new Azure.Storage.Files.Shares.Models.SharePropertiesInternal();
            }
        }

        /// <summary>
        /// Deserializes XML into a new ShareItemInternal instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareItemInternal instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareItemInternal FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareItemInternal _value = new Azure.Storage.Files.Shares.Models.ShareItemInternal(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Snapshot", ""));
            if (_child != null)
            {
                _value.Snapshot = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Deleted", ""));
            if (_child != null)
            {
                _value.IsDeleted = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Version", ""));
            if (_child != null)
            {
                _value.VersionId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Properties", ""));
            if (_child != null)
            {
                _value.Properties = Azure.Storage.Files.Shares.Models.SharePropertiesInternal.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareItemInternal value);
    }
}
#endregion class ShareItemInternal

#region enum ShareLeaseDuration
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// When a share is leased, specifies whether the lease is of infinite or fixed duration.
    /// </summary>
    public enum ShareLeaseDuration
    {
        /// <summary>
        /// infinite
        /// </summary>
        Infinite,

        /// <summary>
        /// fixed
        /// </summary>
        Fixed
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ShareLeaseDuration value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ShareLeaseDuration.Infinite => "infinite",
                    Azure.Storage.Files.Shares.Models.ShareLeaseDuration.Fixed => "fixed",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseDuration value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ShareLeaseDuration ParseShareLeaseDuration(string value)
            {
                return value switch
                {
                    "infinite" => Azure.Storage.Files.Shares.Models.ShareLeaseDuration.Infinite,
                    "fixed" => Azure.Storage.Files.Shares.Models.ShareLeaseDuration.Fixed,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseDuration value.")
                };
            }
        }
    }
}
#endregion enum ShareLeaseDuration

#region enum ShareLeaseState
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Lease state of the share.
    /// </summary>
    public enum ShareLeaseState
    {
        /// <summary>
        /// available
        /// </summary>
        Available,

        /// <summary>
        /// leased
        /// </summary>
        Leased,

        /// <summary>
        /// expired
        /// </summary>
        Expired,

        /// <summary>
        /// breaking
        /// </summary>
        Breaking,

        /// <summary>
        /// broken
        /// </summary>
        Broken
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ShareLeaseState value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ShareLeaseState.Available => "available",
                    Azure.Storage.Files.Shares.Models.ShareLeaseState.Leased => "leased",
                    Azure.Storage.Files.Shares.Models.ShareLeaseState.Expired => "expired",
                    Azure.Storage.Files.Shares.Models.ShareLeaseState.Breaking => "breaking",
                    Azure.Storage.Files.Shares.Models.ShareLeaseState.Broken => "broken",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseState value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ShareLeaseState ParseShareLeaseState(string value)
            {
                return value switch
                {
                    "available" => Azure.Storage.Files.Shares.Models.ShareLeaseState.Available,
                    "leased" => Azure.Storage.Files.Shares.Models.ShareLeaseState.Leased,
                    "expired" => Azure.Storage.Files.Shares.Models.ShareLeaseState.Expired,
                    "breaking" => Azure.Storage.Files.Shares.Models.ShareLeaseState.Breaking,
                    "broken" => Azure.Storage.Files.Shares.Models.ShareLeaseState.Broken,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseState value.")
                };
            }
        }
    }
}
#endregion enum ShareLeaseState

#region enum ShareLeaseStatus
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The current lease status of the share.
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum ShareLeaseStatus
    #pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// locked
        /// </summary>
        Locked,

        /// <summary>
        /// unlocked
        /// </summary>
        Unlocked
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ShareLeaseStatus value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ShareLeaseStatus.Locked => "locked",
                    Azure.Storage.Files.Shares.Models.ShareLeaseStatus.Unlocked => "unlocked",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseStatus value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ShareLeaseStatus ParseShareLeaseStatus(string value)
            {
                return value switch
                {
                    "locked" => Azure.Storage.Files.Shares.Models.ShareLeaseStatus.Locked,
                    "unlocked" => Azure.Storage.Files.Shares.Models.ShareLeaseStatus.Unlocked,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareLeaseStatus value.")
                };
            }
        }
    }
}
#endregion enum ShareLeaseStatus

#region class ShareMetrics
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Storage Analytics metrics for file service.
    /// </summary>
    public partial class ShareMetrics
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether metrics are enabled for the File service.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The retention policy.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareRetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        public bool? IncludeApis { get; set; }

        /// <summary>
        /// Creates a new ShareMetrics instance
        /// </summary>
        public ShareMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareMetrics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Files.Shares.Models.ShareRetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a ShareMetrics instance as XML.
        /// </summary>
        /// <param name="value">The ShareMetrics instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Metrics".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareMetrics value, string name = "Metrics", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Version", ""),
                value.Version));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Enabled", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Enabled.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            if (value.RetentionPolicy != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareRetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            }
            if (value.IncludeApis != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("IncludeAPIs", ""),
                    #pragma warning disable CA1308 // Normalize strings to uppercase
                    value.IncludeApis.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                    #pragma warning restore CA1308 // Normalize strings to uppercase
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareMetrics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareMetrics instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareMetrics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareMetrics _value = new Azure.Storage.Files.Shares.Models.ShareMetrics(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Version", ""));
            if (_child != null)
            {
                _value.Version = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Enabled", ""));
            if (_child != null)
            {
                _value.Enabled = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RetentionPolicy", ""));
            if (_child != null)
            {
                _value.RetentionPolicy = Azure.Storage.Files.Shares.Models.ShareRetentionPolicy.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("IncludeAPIs", ""));
            if (_child != null)
            {
                _value.IncludeApis = bool.Parse(_child.Value);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareMetrics value);
    }
}
#endregion class ShareMetrics

#region class SharePropertiesInternal
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Properties of a share.
    /// </summary>
    internal partial class SharePropertiesInternal
    {
        /// <summary>
        /// Last-Modified
        /// </summary>
        public System.DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Etag
        /// </summary>
        public Azure.ETag? ETag { get; internal set; }

        /// <summary>
        /// ProvisionedIops
        /// </summary>
        public int? ProvisionedIops { get; internal set; }

        /// <summary>
        /// ProvisionedIngressMBps
        /// </summary>
        public int? ProvisionedIngressMBps { get; internal set; }

        /// <summary>
        /// ProvisionedEgressMBps
        /// </summary>
        public int? ProvisionedEgressMBps { get; internal set; }

        /// <summary>
        /// NextAllowedQuotaDowngradeTime
        /// </summary>
        public System.DateTimeOffset? NextAllowedQuotaDowngradeTime { get; internal set; }

        /// <summary>
        /// DeletedTime
        /// </summary>
        public System.DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// AccessTier
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// AccessTierChangeTime
        /// </summary>
        public System.DateTimeOffset? AccessTierChangeTime { get; internal set; }

        /// <summary>
        /// AccessTierTransitionState
        /// </summary>
        public string AccessTierTransitionState { get; internal set; }

        /// <summary>
        /// The current lease status of the share.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// Lease state of the share.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// When a share is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareLeaseDuration? LeaseDuration { get; internal set; }

        /// <summary>
        /// EnabledProtocols
        /// </summary>
        public string EnabledProtocols { get; internal set; }

        /// <summary>
        /// RootSquash
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareRootSquash? RootSquash { get; internal set; }

        /// <summary>
        /// QuotaInGB
        /// </summary>
        public int? QuotaInGB { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Creates a new SharePropertiesInternal instance
        /// </summary>
        public SharePropertiesInternal()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new SharePropertiesInternal instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal SharePropertiesInternal(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Deserializes XML into a new SharePropertiesInternal instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SharePropertiesInternal instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.SharePropertiesInternal FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.SharePropertiesInternal _value = new Azure.Storage.Files.Shares.Models.SharePropertiesInternal(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Last-Modified", ""));
            if (_child != null)
            {
                _value.LastModified = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Etag", ""));
            if (_child != null)
            {
                _value.ETag = new Azure.ETag(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ProvisionedIops", ""));
            if (_child != null)
            {
                _value.ProvisionedIops = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ProvisionedIngressMBps", ""));
            if (_child != null)
            {
                _value.ProvisionedIngressMBps = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ProvisionedEgressMBps", ""));
            if (_child != null)
            {
                _value.ProvisionedEgressMBps = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("NextAllowedQuotaDowngradeTime", ""));
            if (_child != null)
            {
                _value.NextAllowedQuotaDowngradeTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DeletedTime", ""));
            if (_child != null)
            {
                _value.DeletedOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RemainingRetentionDays", ""));
            if (_child != null)
            {
                _value.RemainingRetentionDays = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTier", ""));
            if (_child != null)
            {
                _value.AccessTier = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTierChangeTime", ""));
            if (_child != null)
            {
                _value.AccessTierChangeTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTierTransitionState", ""));
            if (_child != null)
            {
                _value.AccessTierTransitionState = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseStatus", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseStatus = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseStatus(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseState", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseState = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseState(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseDuration", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseDuration = Azure.Storage.Files.Shares.FileRestClient.Serialization.ParseShareLeaseDuration(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("EnabledProtocols", ""));
            if (_child != null)
            {
                _value.EnabledProtocols = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RootSquash", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.RootSquash = (Azure.Storage.Files.Shares.Models.ShareRootSquash)System.Enum.Parse(typeof(Azure.Storage.Files.Shares.Models.ShareRootSquash), _child.Value, false);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Quota", ""));
            if (_child != null)
            {
                _value.QuotaInGB = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            _child = element.Element(System.Xml.Linq.XName.Get("Metadata", ""));
            if (_child != null)
            {
                foreach (System.Xml.Linq.XElement _pair in _child.Elements())
                {
                    _value.Metadata[_pair.Name.LocalName] = _pair.Value;
                }
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.SharePropertiesInternal value);
    }
}
#endregion class SharePropertiesInternal

#region class ShareProtocolSettings
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Protocol settings
    /// </summary>
    public partial class ShareProtocolSettings
    {
        /// <summary>
        /// Settings for SMB protocol.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareSmbSettings Smb { get; set; }

        /// <summary>
        /// Creates a new ShareProtocolSettings instance
        /// </summary>
        public ShareProtocolSettings()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareProtocolSettings instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareProtocolSettings(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Smb = new Azure.Storage.Files.Shares.Models.ShareSmbSettings();
            }
        }

        /// <summary>
        /// Serialize a ShareProtocolSettings instance as XML.
        /// </summary>
        /// <param name="value">The ShareProtocolSettings instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "ShareProtocolSettings".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareProtocolSettings value, string name = "ShareProtocolSettings", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Smb != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareSmbSettings.ToXml(value.Smb, "SMB", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareProtocolSettings instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareProtocolSettings instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareProtocolSettings FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareProtocolSettings _value = new Azure.Storage.Files.Shares.Models.ShareProtocolSettings(true);
            _child = element.Element(System.Xml.Linq.XName.Get("SMB", ""));
            if (_child != null)
            {
                _value.Smb = Azure.Storage.Files.Shares.Models.ShareSmbSettings.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareProtocolSettings value);
    }
}
#endregion class ShareProtocolSettings

#region class ShareRetentionPolicy
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The retention policy.
    /// </summary>
    public partial class ShareRetentionPolicy
    {
        /// <summary>
        /// Indicates whether a retention policy is enabled for the File service. If false, metrics data is retained, and the user is responsible for deleting it.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates the number of days that metrics data should be retained. All data older than this value will be deleted. Metrics data is deleted on a best-effort basis after the retention period expires.
        /// </summary>
        public int? Days { get; set; }

        /// <summary>
        /// Creates a new ShareRetentionPolicy instance
        /// </summary>
        public ShareRetentionPolicy() { }

        /// <summary>
        /// Serialize a ShareRetentionPolicy instance as XML.
        /// </summary>
        /// <param name="value">The ShareRetentionPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "RetentionPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareRetentionPolicy value, string name = "RetentionPolicy", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Enabled", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Enabled.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            if (value.Days != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Days", ""),
                    value.Days.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareRetentionPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareRetentionPolicy instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareRetentionPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareRetentionPolicy _value = new Azure.Storage.Files.Shares.Models.ShareRetentionPolicy();
            _child = element.Element(System.Xml.Linq.XName.Get("Enabled", ""));
            if (_child != null)
            {
                _value.Enabled = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Days", ""));
            if (_child != null)
            {
                _value.Days = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareRetentionPolicy value);
    }
}
#endregion class ShareRetentionPolicy

#region enum ShareRootSquash
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Root squash to set on the share.  Only valid for NFS shares.
    /// </summary>
    public enum ShareRootSquash
    {
        /// <summary>
        /// NoRootSquash
        /// </summary>
        NoRootSquash,

        /// <summary>
        /// RootSquash
        /// </summary>
        RootSquash,

        /// <summary>
        /// AllSquash
        /// </summary>
        AllSquash
    }
}
#endregion enum ShareRootSquash

#region class ShareServiceProperties
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Storage service properties.
    /// </summary>
    public partial class ShareServiceProperties
    {
        /// <summary>
        /// A summary of request statistics grouped by API in hourly aggregates for files.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareMetrics HourMetrics { get; set; }

        /// <summary>
        /// A summary of request statistics grouped by API in minute aggregates for files.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareMetrics MinuteMetrics { get; set; }

        /// <summary>
        /// The set of CORS rules.
        /// </summary>
        #pragma warning disable CA2227 // Collection properties should be readonly
        public System.Collections.Generic.IList<Azure.Storage.Files.Shares.Models.ShareCorsRule> Cors { get; set; }
        #pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Protocol settings
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareProtocolSettings Protocol { get; set; }

        /// <summary>
        /// Creates a new ShareServiceProperties instance
        /// </summary>
        public ShareServiceProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareServiceProperties instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                HourMetrics = new Azure.Storage.Files.Shares.Models.ShareMetrics();
                MinuteMetrics = new Azure.Storage.Files.Shares.Models.ShareMetrics();
                Protocol = new Azure.Storage.Files.Shares.Models.ShareProtocolSettings();
            }
        }

        /// <summary>
        /// Serialize a ShareServiceProperties instance as XML.
        /// </summary>
        /// <param name="value">The ShareServiceProperties instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "StorageServiceProperties".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareServiceProperties value, string name = "StorageServiceProperties", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.HourMetrics != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareMetrics.ToXml(value.HourMetrics, "HourMetrics", ""));
            }
            if (value.MinuteMetrics != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareMetrics.ToXml(value.MinuteMetrics, "MinuteMetrics", ""));
            }
            if (value.Cors != null)
            {
                System.Xml.Linq.XElement _elements = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Cors", ""));
                foreach (Azure.Storage.Files.Shares.Models.ShareCorsRule _child in value.Cors)
                {
                    _elements.Add(Azure.Storage.Files.Shares.Models.ShareCorsRule.ToXml(_child));
                }
                _element.Add(_elements);
            }
            if (value.Protocol != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareProtocolSettings.ToXml(value.Protocol, "ProtocolSettings", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareServiceProperties instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareServiceProperties instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareServiceProperties FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareServiceProperties _value = new Azure.Storage.Files.Shares.Models.ShareServiceProperties(true);
            _child = element.Element(System.Xml.Linq.XName.Get("HourMetrics", ""));
            if (_child != null)
            {
                _value.HourMetrics = Azure.Storage.Files.Shares.Models.ShareMetrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MinuteMetrics", ""));
            if (_child != null)
            {
                _value.MinuteMetrics = Azure.Storage.Files.Shares.Models.ShareMetrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Cors", ""));
            if (_child != null)
            {
                _value.Cors = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("CorsRule", "")),
                        e => Azure.Storage.Files.Shares.Models.ShareCorsRule.FromXml(e)));
            }
            else
            {
                _value.Cors = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ShareCorsRule>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ProtocolSettings", ""));
            if (_child != null)
            {
                _value.Protocol = Azure.Storage.Files.Shares.Models.ShareProtocolSettings.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareServiceProperties value);
    }
}
#endregion class ShareServiceProperties

#region class ShareSignedIdentifier
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Signed identifier.
    /// </summary>
    public partial class ShareSignedIdentifier
    {
        /// <summary>
        /// A unique id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The access policy.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.ShareAccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Creates a new ShareSignedIdentifier instance
        /// </summary>
        public ShareSignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareSignedIdentifier instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareSignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                AccessPolicy = new Azure.Storage.Files.Shares.Models.ShareAccessPolicy();
            }
        }

        /// <summary>
        /// Serialize a ShareSignedIdentifier instance as XML.
        /// </summary>
        /// <param name="value">The ShareSignedIdentifier instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "SignedIdentifier".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareSignedIdentifier value, string name = "SignedIdentifier", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Id", ""),
                value.Id));
            if (value.AccessPolicy != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.ShareAccessPolicy.ToXml(value.AccessPolicy, "AccessPolicy", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareSignedIdentifier instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareSignedIdentifier instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareSignedIdentifier FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareSignedIdentifier _value = new Azure.Storage.Files.Shares.Models.ShareSignedIdentifier(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Id", ""));
            if (_child != null)
            {
                _value.Id = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessPolicy", ""));
            if (_child != null)
            {
                _value.AccessPolicy = Azure.Storage.Files.Shares.Models.ShareAccessPolicy.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareSignedIdentifier value);
    }
}
#endregion class ShareSignedIdentifier

#region class ShareSmbSettings
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Settings for SMB protocol.
    /// </summary>
    public partial class ShareSmbSettings
    {
        /// <summary>
        /// Settings for SMB Multichannel.
        /// </summary>
        public Azure.Storage.Files.Shares.Models.SmbMultichannel Multichannel { get; set; }

        /// <summary>
        /// Creates a new ShareSmbSettings instance
        /// </summary>
        public ShareSmbSettings()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareSmbSettings instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareSmbSettings(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Multichannel = new Azure.Storage.Files.Shares.Models.SmbMultichannel();
            }
        }

        /// <summary>
        /// Serialize a ShareSmbSettings instance as XML.
        /// </summary>
        /// <param name="value">The ShareSmbSettings instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "ShareSmbSettings".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.ShareSmbSettings value, string name = "ShareSmbSettings", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Multichannel != null)
            {
                _element.Add(Azure.Storage.Files.Shares.Models.SmbMultichannel.ToXml(value.Multichannel, "Multichannel", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new ShareSmbSettings instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareSmbSettings instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareSmbSettings FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareSmbSettings _value = new Azure.Storage.Files.Shares.Models.ShareSmbSettings(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Multichannel", ""));
            if (_child != null)
            {
                _value.Multichannel = Azure.Storage.Files.Shares.Models.SmbMultichannel.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareSmbSettings value);
    }
}
#endregion class ShareSmbSettings

#region class ShareSnapshotInfo
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareSnapshotInfo
    /// </summary>
    public partial class ShareSnapshotInfo
    {
        /// <summary>
        /// This header is a DateTime value that uniquely identifies the share snapshot. The value of this header may be used in subsequent requests to access the share snapshot. This value is opaque.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// The ETag contains a value which represents the version of the share snapshot, in quotes. A share snapshot cannot be modified, so the ETag of a given share snapshot never changes. However, if new metadata was supplied with the Snapshot Share request then the ETag of the share snapshot differs from that of the base share. If no metadata was specified with the request, the ETag of the share snapshot is identical to that of the base share at the time the share snapshot was taken.
        /// </summary>
        public Azure.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. A share snapshot cannot be modified, so the last modified time of a given share snapshot never changes. However, if new metadata was supplied with the Snapshot Share request then the last modified time of the share snapshot differs from that of the base share. If no metadata was specified with the request, the last modified time of the share snapshot is identical to that of the base share at the time the share snapshot was taken.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareSnapshotInfo instances.
        /// You can use ShareModelFactory.ShareSnapshotInfo instead.
        /// </summary>
        internal ShareSnapshotInfo() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareSnapshotInfo instance for mocking.
        /// </summary>
        public static ShareSnapshotInfo ShareSnapshotInfo(
            string snapshot,
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new ShareSnapshotInfo()
            {
                Snapshot = snapshot,
                ETag = eTag,
                LastModified = lastModified,
            };
        }
    }
}
#endregion class ShareSnapshotInfo

#region enum ShareSnapshotsDeleteOptionInternal
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies the option include to delete the base share and all of its snapshots.
    /// </summary>
    internal enum ShareSnapshotsDeleteOptionInternal
    {
        /// <summary>
        /// include
        /// </summary>
        Include,

        /// <summary>
        /// include-leased
        /// </summary>
        IncludeLeased
    }
}

namespace Azure.Storage.Files.Shares
{
    internal static partial class FileRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal value)
            {
                return value switch
                {
                    Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal.Include => "include",
                    Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal.IncludeLeased => "include-leased",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal value.")
                };
            }

            public static Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal ParseShareSnapshotsDeleteOptionInternal(string value)
            {
                return value switch
                {
                    "include" => Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal.Include,
                    "include-leased" => Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal.IncludeLeased,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Files.Shares.Models.ShareSnapshotsDeleteOptionInternal value.")
                };
            }
        }
    }
}
#endregion enum ShareSnapshotsDeleteOptionInternal

#region class ShareStatistics
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Stats for the share.
    /// </summary>
    public partial class ShareStatistics
    {
        /// <summary>
        /// The approximate size of the data stored in bytes, rounded up to the nearest gigabyte. Note that this value may not include all recently created or recently resized files.
        /// </summary>
        public long ShareUsageInBytes { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareStatistics instances.
        /// You can use ShareModelFactory.ShareStatistics instead.
        /// </summary>
        internal ShareStatistics() { }

        /// <summary>
        /// Deserializes XML into a new ShareStatistics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ShareStatistics instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.ShareStatistics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.ShareStatistics _value = new Azure.Storage.Files.Shares.Models.ShareStatistics();
            _child = element.Element(System.Xml.Linq.XName.Get("ShareUsageBytes", ""));
            if (_child != null)
            {
                _value.ShareUsageInBytes = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.ShareStatistics value);
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareStatistics instance for mocking.
        /// </summary>
        public static ShareStatistics ShareStatistics(
            long shareUsageInBytes)
        {
            return new ShareStatistics()
            {
                ShareUsageInBytes = shareUsageInBytes,
            };
        }
    }
}
#endregion class ShareStatistics

#region class SharesSegment
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An enumeration of shares.
    /// </summary>
    internal partial class SharesSegment
    {
        /// <summary>
        /// ServiceEndpoint
        /// </summary>
        public string ServiceEndpoint { get; internal set; }

        /// <summary>
        /// Prefix
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        /// Marker
        /// </summary>
        public string Marker { get; internal set; }

        /// <summary>
        /// MaxResults
        /// </summary>
        public int? MaxResults { get; internal set; }

        /// <summary>
        /// ShareItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareItemInternal> ShareItems { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Creates a new SharesSegment instance
        /// </summary>
        public SharesSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new SharesSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal SharesSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                ShareItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ShareItemInternal>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new SharesSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SharesSegment instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.SharesSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            System.Xml.Linq.XAttribute _attribute;
            Azure.Storage.Files.Shares.Models.SharesSegment _value = new Azure.Storage.Files.Shares.Models.SharesSegment(true);
            _attribute = element.Attribute(System.Xml.Linq.XName.Get("ServiceEndpoint", ""));
            if (_attribute != null)
            {
                _value.ServiceEndpoint = _attribute.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Prefix", ""));
            if (_child != null)
            {
                _value.Prefix = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Marker", ""));
            if (_child != null)
            {
                _value.Marker = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MaxResults", ""));
            if (_child != null)
            {
                _value.MaxResults = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Shares", ""));
            if (_child != null)
            {
                _value.ShareItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Share", "")),
                        e => Azure.Storage.Files.Shares.Models.ShareItemInternal.FromXml(e)));
            }
            else
            {
                _value.ShareItems = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ShareItemInternal>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("NextMarker", ""));
            if (_child != null)
            {
                _value.NextMarker = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.SharesSegment value);
    }
}
#endregion class SharesSegment

#region class SmbMultichannel
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Settings for SMB multichannel
    /// </summary>
    public partial class SmbMultichannel
    {
        /// <summary>
        /// If SMB multichannel is enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Creates a new SmbMultichannel instance
        /// </summary>
        public SmbMultichannel() { }

        /// <summary>
        /// Serialize a SmbMultichannel instance as XML.
        /// </summary>
        /// <param name="value">The SmbMultichannel instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Multichannel".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Files.Shares.Models.SmbMultichannel value, string name = "Multichannel", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Enabled != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Enabled", ""),
                    #pragma warning disable CA1308 // Normalize strings to uppercase
                    value.Enabled.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                    #pragma warning restore CA1308 // Normalize strings to uppercase
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new SmbMultichannel instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SmbMultichannel instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.SmbMultichannel FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.SmbMultichannel _value = new Azure.Storage.Files.Shares.Models.SmbMultichannel();
            _child = element.Element(System.Xml.Linq.XName.Get("Enabled", ""));
            if (_child != null)
            {
                _value.Enabled = bool.Parse(_child.Value);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.SmbMultichannel value);
    }
}
#endregion class SmbMultichannel

#region class StorageClosedHandlesSegment
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// StorageClosedHandlesSegment
    /// </summary>
    public partial class StorageClosedHandlesSegment
    {
        /// <summary>
        /// A string describing next handle to be closed. It is returned when more handles need to be closed to complete the request.
        /// </summary>
        public string Marker { get; internal set; }

        /// <summary>
        /// Contains count of number of handles closed.
        /// </summary>
        public int NumberOfHandlesClosed { get; internal set; }

        /// <summary>
        /// Contains count of number of handles that failed to close.
        /// </summary>
        public int NumberOfHandlesFailedToClose { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of StorageClosedHandlesSegment instances.
        /// You can use ShareModelFactory.StorageClosedHandlesSegment instead.
        /// </summary>
        internal StorageClosedHandlesSegment() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new StorageClosedHandlesSegment instance for mocking.
        /// </summary>
        public static StorageClosedHandlesSegment StorageClosedHandlesSegment(
            string marker,
            int numberOfHandlesClosed,
            int numberOfHandlesFailedToClose)
        {
            return new StorageClosedHandlesSegment()
            {
                Marker = marker,
                NumberOfHandlesClosed = numberOfHandlesClosed,
                NumberOfHandlesFailedToClose = numberOfHandlesFailedToClose,
            };
        }
    }
}
#endregion class StorageClosedHandlesSegment

#region class StorageError
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// StorageError
    /// </summary>
    internal partial class StorageError
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of StorageError instances.
        /// You can use ShareModelFactory.StorageError instead.
        /// </summary>
        internal StorageError() { }

        /// <summary>
        /// Deserializes XML into a new StorageError instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized StorageError instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.StorageError FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.StorageError _value = new Azure.Storage.Files.Shares.Models.StorageError();
            _child = element.Element(System.Xml.Linq.XName.Get("Message", ""));
            if (_child != null)
            {
                _value.Message = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Code", ""));
            if (_child != null)
            {
                _value.Code = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.StorageError value);
    }
}
#endregion class StorageError

#region class StorageHandlesSegment
namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// An enumeration of handles.
    /// </summary>
    internal partial class StorageHandlesSegment
    {
        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Handles
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareFileHandle> Handles { get; internal set; }

        /// <summary>
        /// Creates a new StorageHandlesSegment instance
        /// </summary>
        public StorageHandlesSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new StorageHandlesSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal StorageHandlesSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Handles = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ShareFileHandle>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new StorageHandlesSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized StorageHandlesSegment instance.</returns>
        internal static Azure.Storage.Files.Shares.Models.StorageHandlesSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Files.Shares.Models.StorageHandlesSegment _value = new Azure.Storage.Files.Shares.Models.StorageHandlesSegment(true);
            _child = element.Element(System.Xml.Linq.XName.Get("NextMarker", ""));
            if (_child != null)
            {
                _value.NextMarker = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Entries", ""));
            if (_child != null)
            {
                _value.Handles = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Handle", "")),
                        e => Azure.Storage.Files.Shares.Models.ShareFileHandle.FromXml(e)));
            }
            else
            {
                _value.Handles = new System.Collections.Generic.List<Azure.Storage.Files.Shares.Models.ShareFileHandle>();
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Files.Shares.Models.StorageHandlesSegment value);
    }
}
#endregion class StorageHandlesSegment
#endregion Models


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// This file was automatically generated.  Do not edit.

#region Service
namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Azure Blob Storage
    /// </summary>
    internal static partial class BlobRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure Blob Storage
        /// </summary>
        public static partial class Service
        {
            #region Service.SetPropertiesAsync
            /// <summary>
            /// Sets properties for a storage account's Blob service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blobServiceProperties">The StorageService properties.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlobServiceProperties blobServiceProperties,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.SetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetPropertiesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        blobServiceProperties,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetPropertiesAsync_CreateResponse(_response);
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
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blobServiceProperties">The StorageService properties.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request SetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlobServiceProperties blobServiceProperties,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (blobServiceProperties == null)
                {
                    throw new System.ArgumentNullException(nameof(blobServiceProperties));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Blobs.Models.BlobServiceProperties.ToXml(blobServiceProperties, "StorageServiceProperties", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.SetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.SetPropertiesAsync Azure.Response.</returns>
            internal static Azure.Response SetPropertiesAsync_CreateResponse(
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
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.SetPropertiesAsync

            #region Service.GetPropertiesAsync
            /// <summary>
            /// gets the properties of a storage account's Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Storage Service Properties.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Service.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetPropertiesAsync Azure.Response{Azure.Storage.Blobs.Models.BlobServiceProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.BlobServiceProperties _value = Azure.Storage.Blobs.Models.BlobServiceProperties.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetPropertiesAsync

            #region Service.GetStatisticsAsync
            /// <summary>
            /// Retrieves statistics related to replication for the Blob service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Statistics for the storage service.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics>> GetStatisticsAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetStatistics",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetStatisticsAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetStatisticsAsync_CreateResponse(_response);
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
            /// Create the Service.GetStatisticsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetStatisticsAsync Request.</returns>
            internal static Azure.Core.Http.Request GetStatisticsAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "stats");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Service.GetStatisticsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetStatisticsAsync Azure.Response{Azure.Storage.Blobs.Models.BlobServiceStatistics}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics> GetStatisticsAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.BlobServiceStatistics _value = Azure.Storage.Blobs.Models.BlobServiceStatistics.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetStatisticsAsync

            #region Service.ListContainersSegmentAsync
            /// <summary>
            /// The List Containers Segment operation returns a list of the containers under the specified account
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the container's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of containers</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainersSegment>> ListContainersSegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                Azure.Storage.Blobs.Models.ListContainersIncludeType? include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.ListContainersSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListContainersSegmentAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        prefix,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListContainersSegmentAsync_CreateResponse(_response);
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
            /// Create the Service.ListContainersSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the container's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.ListContainersSegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListContainersSegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                Azure.Storage.Blobs.Models.ListContainersIncludeType? include = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(include.Value))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Service.ListContainersSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListContainersSegmentAsync Azure.Response{Azure.Storage.Blobs.Models.ContainersSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainersSegment> ListContainersSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.ContainersSegment _value = Azure.Storage.Blobs.Models.ContainersSegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainersSegment> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainersSegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.ListContainersSegmentAsync

            #region Service.GetUserDelegationKeyAsync
            /// <summary>
            /// Retrieves a user delgation key for the Blob service. This is only a valid operation when using bearer token authentication.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="keyInfo">Key information</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>A user delegation key</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey>> GetUserDelegationKeyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.KeyInfo keyInfo,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetUserDelegationKey",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetUserDelegationKeyAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        keyInfo,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetUserDelegationKeyAsync_CreateResponse(_response);
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
            /// Create the Service.GetUserDelegationKeyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="keyInfo">Key information</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetUserDelegationKeyAsync Request.</returns>
            internal static Azure.Core.Http.Request GetUserDelegationKeyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.KeyInfo keyInfo,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (keyInfo == null)
                {
                    throw new System.ArgumentNullException(nameof(keyInfo));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "service");
                _request.UriBuilder.AppendQuery("comp", "userdelegationkey");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Blobs.Models.KeyInfo.ToXml(keyInfo, "KeyInfo", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Service.GetUserDelegationKeyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetUserDelegationKeyAsync Azure.Response{Azure.Storage.Blobs.Models.UserDelegationKey}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey> GetUserDelegationKeyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.UserDelegationKey _value = Azure.Storage.Blobs.Models.UserDelegationKey.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetUserDelegationKeyAsync

            #region Service.GetAccountInfoAsync
            /// <summary>
            /// Returns the sku name and account kind
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.AccountInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>> GetAccountInfoAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ServiceClient.GetAccountInfo",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccountInfoAsync_CreateRequest(
                        pipeline,
                        resourceUri))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccountInfoAsync_CreateResponse(_response);
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
            /// Create the Service.GetAccountInfoAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <returns>The Service.GetAccountInfoAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccountInfoAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "account");
                _request.UriBuilder.AppendQuery("comp", "properties");

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");

                return _request;
            }

            /// <summary>
            /// Create the Service.GetAccountInfoAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetAccountInfoAsync Azure.Response{Azure.Storage.Blobs.Models.AccountInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> GetAccountInfoAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.AccountInfo _value = new Azure.Storage.Blobs.Models.AccountInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-sku-name", out _header))
                        {
                            _value.SkuName = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseSkuName(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-account-kind", out _header))
                        {
                            _value.AccountKind = (Azure.Storage.Blobs.Models.AccountKind)System.Enum.Parse(typeof(Azure.Storage.Blobs.Models.AccountKind), _header, false);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetAccountInfoAsync
        }
        #endregion Service operations

        #region Container operations
        /// <summary>
        /// Container operations for Azure Blob Storage
        /// </summary>
        public static partial class Container
        {
            #region Container.CreateAsync
            /// <summary>
            /// creates a new container under the specified account. If the container with the same name already exists, the operation fails
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="access">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                Azure.Storage.Blobs.Models.PublicAccessType? access = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        metadata,
                        access,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the Container.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="access">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                Azure.Storage.Blobs.Models.PublicAccessType? access = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (access != null) { _request.Headers.SetValue("x-ms-blob-public-access", Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(access.Value)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.CreateAsync Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ContainerInfo _value = new Azure.Storage.Blobs.Models.ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.CreateAsync

            #region Container.GetPropertiesAsync
            /// <summary>
            /// returns all user-defined metadata and system properties for the specified container. The data returned does not include the container's list of blobs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.FlattenedContainerItem}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.FlattenedContainerItem>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Container.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.GetPropertiesAsync Azure.Response{Azure.Storage.Blobs.Models.FlattenedContainerItem}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.FlattenedContainerItem> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.FlattenedContainerItem _value = new Azure.Storage.Blobs.Models.FlattenedContainerItem();

                        // Get response headers
                        string _header;
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.Http.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-public-access", out _header))
                        {
                            _value.BlobPublicAccess = Azure.Storage.Blobs.BlobRestClient.Serialization.ParsePublicAccessType(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-has-immutability-policy", out _header))
                        {
                            _value.HasImmutabilityPolicy = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-has-legal-hold", out _header))
                        {
                            _value.HasLegalHold = bool.Parse(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.FlattenedContainerItem> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.FlattenedContainerItem>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.GetPropertiesAsync

            #region Container.DeleteAsync
            /// <summary>
            /// operation marks the specified container for deletion. The container and any blobs contained within it are later deleted during garbage collection
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DeleteAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(_response);
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
            /// Create the Container.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.DeleteAsync

            #region Container.SetMetadataAsync
            /// <summary>
            /// operation sets one or more user-defined name-value pairs for the specified container.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>> SetMetadataAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? ifModifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetMetadataAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        leaseId,
                        metadata,
                        ifModifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetMetadataAsync_CreateResponse(_response);
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
            /// Create the Container.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.SetMetadataAsync Request.</returns>
            internal static Azure.Core.Http.Request SetMetadataAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? ifModifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.SetMetadataAsync Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> SetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ContainerInfo _value = new Azure.Storage.Blobs.Models.ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.SetMetadataAsync

            #region Container.GetAccessPolicyAsync
            /// <summary>
            /// gets the permissions for the specified container. The permissions indicate whether container data may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.ContainerAccessPolicy}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainerAccessPolicy>> GetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.GetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetAccessPolicyAsync_CreateResponse(_response);
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
            /// Create the Container.GetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.GetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccessPolicyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.GetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.GetAccessPolicyAsync Azure.Response{Azure.Storage.Blobs.Models.ContainerAccessPolicy}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainerAccessPolicy> GetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.ContainerAccessPolicy _value = new Azure.Storage.Blobs.Models.ContainerAccessPolicy();
                        _value.SignedIdentifiers =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("SignedIdentifiers", "")).Elements(System.Xml.Linq.XName.Get("SignedIdentifier", "")),
                                    Azure.Storage.Blobs.Models.SignedIdentifier.FromXml));

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-blob-public-access", out _header))
                        {
                            _value.BlobPublicAccess = Azure.Storage.Blobs.BlobRestClient.Serialization.ParsePublicAccessType(_header);
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainerAccessPolicy> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainerAccessPolicy>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.GetAccessPolicyAsync

            #region Container.SetAccessPolicyAsync
            /// <summary>
            /// sets the permissions for the specified container. The permissions indicate whether blobs in a container may be accessed publicly.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="permissions">the acls for the container</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="access">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>> SetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.SignedIdentifier> permissions = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.PublicAccessType? access = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.SetAccessPolicy",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetAccessPolicyAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        permissions,
                        timeout,
                        leaseId,
                        access,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetAccessPolicyAsync_CreateResponse(_response);
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
            /// Create the Container.SetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="permissions">the acls for the container</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="access">Specifies whether data in the container may be accessed publicly and the level of access</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.SetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request SetAccessPolicyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.SignedIdentifier> permissions = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.PublicAccessType? access = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (access != null) { _request.Headers.SetValue("x-ms-blob-public-access", Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(access.Value)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("SignedIdentifiers", ""));
                if (permissions != null)
                {
                    foreach (Azure.Storage.Blobs.Models.SignedIdentifier _child in permissions)
                    {
                        _body.Add(Azure.Storage.Blobs.Models.SignedIdentifier.ToXml(_child));
                    }
                }
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Container.SetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.SetAccessPolicyAsync Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> SetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ContainerInfo _value = new Azure.Storage.Blobs.Models.ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.SetAccessPolicyAsync

            #region Container.AcquireLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> AcquireLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AcquireLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        duration,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AcquireLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.AcquireLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request AcquireLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (duration != null) { _request.Headers.SetValue("x-ms-lease-duration", duration.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.AcquireLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> AcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.AcquireLeaseAsync

            #region Container.ReleaseLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>> ReleaseLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ReleaseLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ReleaseLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ReleaseLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ReleaseLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.ContainerInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> ReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ContainerInfo _value = new Azure.Storage.Blobs.Models.ContainerInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.ContainerInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ReleaseLeaseAsync

            #region Container.RenewLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> RenewLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenewLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenewLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.RenewLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.RenewLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request RenewLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.RenewLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.RenewLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> RenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.RenewLeaseAsync

            #region Container.BreakLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BrokenLease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BrokenLease>> BreakLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BreakLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        breakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BreakLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.BreakLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request BreakLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (breakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", breakPeriod.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.BreakLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.BrokenLease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BrokenLease> BreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BrokenLease _value = new Azure.Storage.Blobs.Models.BrokenLease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-time", out _header))
                        {
                            _value.LeaseTime = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BrokenLease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BrokenLease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.BreakLeaseAsync

            #region Container.ChangeLeaseAsync
            /// <summary>
            /// [Update] establishes and manages a lock on a container for delete operations. The lock duration can be 15 to 60 seconds, or can be infinite
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> ChangeLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string proposedLeaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ChangeLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        proposedLeaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ChangeLeaseAsync_CreateResponse(_response);
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
            /// Create the Container.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ChangeLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ChangeLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string proposedLeaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
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
                if (proposedLeaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(proposedLeaseId));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                _request.UriBuilder.AppendQuery("restype", "container");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ChangeLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> ChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ChangeLeaseAsync

            #region Container.ListBlobsFlatSegmentAsync
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of blobs</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobsFlatSegment>> ListBlobsFlatSegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ListBlobsIncludeItem> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ListBlobsFlatSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListBlobsFlatSegmentAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        prefix,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListBlobsFlatSegmentAsync_CreateResponse(_response);
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
            /// Create the Container.ListBlobsFlatSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ListBlobsFlatSegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListBlobsFlatSegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ListBlobsIncludeItem> include = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(string.Join(",", System.Linq.Enumerable.Select(include, item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.ListBlobsFlatSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ListBlobsFlatSegmentAsync Azure.Response{Azure.Storage.Blobs.Models.BlobsFlatSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobsFlatSegment> ListBlobsFlatSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.BlobsFlatSegment _value = Azure.Storage.Blobs.Models.BlobsFlatSegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobsFlatSegment> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobsFlatSegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ListBlobsFlatSegmentAsync

            #region Container.ListBlobsHierarchySegmentAsync
            /// <summary>
            /// [Update] The List Blobs operation returns a list of the blobs under the specified container
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>An enumeration of blobs</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobsHierarchySegment>> ListBlobsHierarchySegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string delimiter = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ListBlobsIncludeItem> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.ContainerClient.ListBlobsHierarchySegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListBlobsHierarchySegmentAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        prefix,
                        delimiter,
                        marker,
                        maxresults,
                        include,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ListBlobsHierarchySegmentAsync_CreateResponse(_response);
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
            /// Create the Container.ListBlobsHierarchySegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only containers whose name begins with the specified prefix.</param>
            /// <param name="delimiter">When the request includes this parameter, the operation returns a BlobPrefix element in the response body that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string.</param>
            /// <param name="marker">A string value that identifies the portion of the list of containers to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all containers remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of containers to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify one or more datasets to include in the response.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Container.ListBlobsHierarchySegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListBlobsHierarchySegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string delimiter = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ListBlobsIncludeItem> include = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("restype", "container");
                _request.UriBuilder.AppendQuery("comp", "list");
                if (prefix != null) { _request.UriBuilder.AppendQuery("prefix", System.Uri.EscapeDataString(prefix)); }
                if (delimiter != null) { _request.UriBuilder.AppendQuery("delimiter", System.Uri.EscapeDataString(delimiter)); }
                if (marker != null) { _request.UriBuilder.AppendQuery("marker", System.Uri.EscapeDataString(marker)); }
                if (maxresults != null) { _request.UriBuilder.AppendQuery("maxresults", System.Uri.EscapeDataString(maxresults.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(string.Join(",", System.Linq.Enumerable.Select(include, item => Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(item))))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Container.ListBlobsHierarchySegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Container.ListBlobsHierarchySegmentAsync Azure.Response{Azure.Storage.Blobs.Models.BlobsHierarchySegment}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobsHierarchySegment> ListBlobsHierarchySegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.BlobsHierarchySegment _value = Azure.Storage.Blobs.Models.BlobsHierarchySegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobsHierarchySegment> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobsHierarchySegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Container.ListBlobsHierarchySegmentAsync
        }
        #endregion Container operations

        #region Blob operations
        /// <summary>
        /// Blob operations for Azure Blob Storage
        /// </summary>
        public static partial class Blob
        {
            #region Blob.DownloadAsync
            /// <summary>
            /// The Download operation reads or downloads a blob from the system, including its metadata and properties. You can also call Download to read a snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rangeGetContentHash">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.FlattenedDownloadProperties}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties>> DownloadAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? rangeGetContentHash = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Download",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DownloadAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        snapshot,
                        timeout,
                        range,
                        leaseId,
                        rangeGetContentHash,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DownloadAsync_CreateResponse(_response);
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
            /// Create the Blob.DownloadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="rangeGetContentHash">When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.DownloadAsync Request.</returns>
            internal static Azure.Core.Http.Request DownloadAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                bool? rangeGetContentHash = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (rangeGetContentHash != null) {
                #pragma warning disable CA1308 // Normalize strings to uppercase
                _request.Headers.SetValue("x-ms-range-get-content-md5", rangeGetContentHash.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant());
                #pragma warning restore CA1308 // Normalize strings to uppercase
                }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.DownloadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.DownloadAsync Azure.Response{Azure.Storage.Blobs.Models.FlattenedDownloadProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties> DownloadAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.FlattenedDownloadProperties _value = new Azure.Storage.Blobs.Models.FlattenedDownloadProperties();
                        _value.Content = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.Http.HttpHeader _headerPair in response.Headers)
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
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
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
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-type", out _header))
                        {
                            _value.BlobType = (Azure.Storage.Blobs.Models.BlobType)System.Enum.Parse(typeof(Azure.Storage.Blobs.Models.BlobType), _header, false);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-committed-block-count", out _header))
                        {
                            _value.BlobCommittedBlockCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-content-md5", out _header))
                        {
                            _value.BlobContentHash = System.Convert.FromBase64String(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    case 206:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.FlattenedDownloadProperties _value = new Azure.Storage.Blobs.Models.FlattenedDownloadProperties();
                        _value.Content = response.ContentStream; // You should manually wrap with RetriableStream!

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.Http.HttpHeader _headerPair in response.Headers)
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
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = _header;
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
                            _value.ContentLanguage = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-type", out _header))
                        {
                            _value.BlobType = (Azure.Storage.Blobs.Models.BlobType)System.Enum.Parse(typeof(Azure.Storage.Blobs.Models.BlobType), _header, false);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-committed-block-count", out _header))
                        {
                            _value.BlobCommittedBlockCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-content-md5", out _header))
                        {
                            _value.BlobContentHash = System.Convert.FromBase64String(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.FlattenedDownloadProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.DownloadAsync

            #region Blob.GetPropertiesAsync
            /// <summary>
            /// The Get Properties operation returns all user-defined metadata, standard HTTP properties, and system properties for the blob. It does not return the content of the blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobProperties}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.GetProperties",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPropertiesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        snapshot,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPropertiesAsync_CreateResponse(_response);
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
            /// Create the Blob.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.GetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Head;
                _request.UriBuilder.Uri = resourceUri;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.GetPropertiesAsync Azure.Response{Azure.Storage.Blobs.Models.BlobProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobProperties> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobProperties _value = new Azure.Storage.Blobs.Models.BlobProperties();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-creation-time", out _header))
                        {
                            _value.CreationTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        _value.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
                        foreach (Azure.Core.Http.HttpHeader _headerPair in response.Headers)
                        {
                            if (_headerPair.Name.StartsWith("x-ms-meta-", System.StringComparison.InvariantCulture))
                            {
                                _value.Metadata[_headerPair.Name.Substring(10)] = _headerPair.Value;
                            }
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-type", out _header))
                        {
                            _value.BlobType = (Azure.Storage.Blobs.Models.BlobType)System.Enum.Parse(typeof(Azure.Storage.Blobs.Models.BlobType), _header, false);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-incremental-copy", out _header))
                        {
                            _value.IsIncrementalCopy = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-copy-destination-snapshot", out _header))
                        {
                            _value.DestinationSnapshot = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-duration", out _header))
                        {
                            _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-state", out _header))
                        {
                            _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-status", out _header))
                        {
                            _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_header);
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
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Encoding", out _header))
                        {
                            _value.ContentEncoding = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Content-Disposition", out _header))
                        {
                            _value.ContentDisposition = _header;
                        }
                        if (response.Headers.TryGetValue("Content-Language", out _header))
                        {
                            _value.ContentLanguage = (_header ?? "").Split(',');
                        }
                        if (response.Headers.TryGetValue("Cache-Control", out _header))
                        {
                            _value.CacheControl = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Accept-Ranges", out _header))
                        {
                            _value.AcceptRanges = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-committed-block-count", out _header))
                        {
                            _value.BlobCommittedBlockCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier", out _header))
                        {
                            _value.AccessTier = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier-inferred", out _header))
                        {
                            _value.AccessTierInferred = bool.Parse(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-archive-status", out _header))
                        {
                            _value.ArchiveStatus = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-access-tier-change-time", out _header))
                        {
                            _value.AccessTierChangeTime = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobProperties> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.GetPropertiesAsync

            #region Blob.DeleteAsync
            /// <summary>
            /// If the storage account's soft delete feature is disabled then, when a blob is deleted, it is permanently removed from the storage account. If the storage account's soft delete feature is enabled, then, when a blob is deleted, it is marked for deletion and becomes inaccessible immediately. However, the blob service retains the blob or snapshot for the number of days specified by the DeleteRetentionPolicy section of [Storage service properties] (Set-Blob-Service-Properties.md). After the specified number of days has passed, the blob's data is permanently removed from the storage account. Note that you continue to be charged for the soft-deleted blob's storage until it is permanently removed. Use the List Blobs API and specify the "include=deleted" query parameter to discover which blobs and snapshots have been soft deleted. You can then use the Undelete Blob API to restore a soft-deleted blob. All other operations on a soft-deleted blob or snapshot causes the service to return an HTTP status code of 404 (ResourceNotFound).
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="deleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.DeleteSnapshotsOption? deleteSnapshots = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Delete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DeleteAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        snapshot,
                        timeout,
                        leaseId,
                        deleteSnapshots,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return DeleteAsync_CreateResponse(_response);
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
            /// Create the Blob.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="deleteSnapshots">Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                Azure.Storage.Blobs.Models.DeleteSnapshotsOption? deleteSnapshots = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = resourceUri;
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (deleteSnapshots != null) { _request.Headers.SetValue("x-ms-delete-snapshots", Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(deleteSnapshots.Value)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.DeleteAsync

            #region Blob.UndeleteAsync
            /// <summary>
            /// Undelete a blob that was previously soft deleted
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> UndeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.Undelete",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UndeleteAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UndeleteAsync_CreateResponse(_response);
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
            /// Create the Blob.UndeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.UndeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request UndeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "undelete");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.UndeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.UndeleteAsync Azure.Response.</returns>
            internal static Azure.Response UndeleteAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.UndeleteAsync

            #region Blob.SetHttpHeadersAsync
            /// <summary>
            /// The Set HTTP Headers operation sets system properties on the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.SetHttpHeadersOperation}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.SetHttpHeadersOperation>> SetHttpHeadersAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string blobContentDisposition = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetHttpHeaders",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetHttpHeadersAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        blobCacheControl,
                        blobContentType,
                        blobContentHash,
                        blobContentEncoding,
                        blobContentLanguage,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobContentDisposition,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetHttpHeadersAsync_CreateResponse(_response);
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
            /// Create the Blob.SetHttpHeadersAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.SetHttpHeadersAsync Request.</returns>
            internal static Azure.Core.Http.Request SetHttpHeadersAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string blobContentDisposition = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (blobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", blobCacheControl); }
                if (blobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", blobContentType); }
                if (blobContentHash != null) { _request.Headers.SetValue("x-ms-blob-content-md5", System.Convert.ToBase64String(blobContentHash)); }
                if (blobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (blobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (blobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", blobContentDisposition); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetHttpHeadersAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetHttpHeadersAsync Azure.Response{Azure.Storage.Blobs.Models.SetHttpHeadersOperation}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.SetHttpHeadersOperation> SetHttpHeadersAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.SetHttpHeadersOperation _value = new Azure.Storage.Blobs.Models.SetHttpHeadersOperation();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.SetHttpHeadersOperation> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.SetHttpHeadersOperation>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetHttpHeadersAsync

            #region Blob.SetMetadataAsync
            /// <summary>
            /// The Set Blob Metadata operation sets user-defined metadata for the specified blob as one or more name-value pairs
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.SetMetadataOperation}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.SetMetadataOperation>> SetMetadataAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetMetadata",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetMetadataAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        metadata,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetMetadataAsync_CreateResponse(_response);
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
            /// Create the Blob.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.SetMetadataAsync Request.</returns>
            internal static Azure.Core.Http.Request SetMetadataAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetMetadataAsync Azure.Response{Azure.Storage.Blobs.Models.SetMetadataOperation}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.SetMetadataOperation> SetMetadataAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.SetMetadataOperation _value = new Azure.Storage.Blobs.Models.SetMetadataOperation();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.SetMetadataOperation> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.SetMetadataOperation>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetMetadataAsync

            #region Blob.AcquireLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> AcquireLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.AcquireLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AcquireLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        duration,
                        proposedLeaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AcquireLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.AcquireLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="duration">Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. A lease duration cannot be changed using renew or change.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.AcquireLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request AcquireLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? duration = default,
                string proposedLeaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "acquire");
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (duration != null) { _request.Headers.SetValue("x-ms-lease-duration", duration.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (proposedLeaseId != null) { _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.AcquireLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.AcquireLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> AcquireLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.AcquireLeaseAsync

            #region Blob.ReleaseLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> ReleaseLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.ReleaseLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ReleaseLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ReleaseLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.ReleaseLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.ReleaseLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ReleaseLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "release");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.ReleaseLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.ReleaseLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.BlobInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> ReleaseLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobInfo _value = new Azure.Storage.Blobs.Models.BlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.ReleaseLeaseAsync

            #region Blob.RenewLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> RenewLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.RenewLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = RenewLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return RenewLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.RenewLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.RenewLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request RenewLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "renew");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.RenewLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.RenewLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> RenewLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.RenewLeaseAsync

            #region Blob.ChangeLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.Lease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.Lease>> ChangeLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string proposedLeaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.ChangeLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ChangeLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        leaseId,
                        proposedLeaseId,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ChangeLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.ChangeLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="leaseId">Specifies the current lease ID on the resource.</param>
            /// <param name="proposedLeaseId">Proposed lease ID, in a GUID string format. The Blob service returns 400 (Invalid request) if the proposed lease ID is not in the correct format. See Guid Constructor (String) for a list of valid GUID string formats.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.ChangeLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request ChangeLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string leaseId,
                string proposedLeaseId,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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
                if (proposedLeaseId == null)
                {
                    throw new System.ArgumentNullException(nameof(proposedLeaseId));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "change");
                _request.Headers.SetValue("x-ms-lease-id", leaseId);
                _request.Headers.SetValue("x-ms-proposed-lease-id", proposedLeaseId);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.ChangeLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.ChangeLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.Lease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.Lease> ChangeLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.Lease _value = new Azure.Storage.Blobs.Models.Lease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                        Azure.Response<Azure.Storage.Blobs.Models.Lease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.Lease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.ChangeLeaseAsync

            #region Blob.BreakLeaseAsync
            /// <summary>
            /// [Update] The Lease Blob operation establishes and manages a lock on a blob for write and delete operations
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BrokenLease}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BrokenLease>> BreakLeaseAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.BreakLease",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = BreakLeaseAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        breakPeriod,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return BreakLeaseAsync_CreateResponse(_response);
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
            /// Create the Blob.BreakLeaseAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="breakPeriod">For a break operation, proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. A new lease will not be available before the break period has expired, but the lease may be held for longer than the break period. If this header does not appear with a break operation, a fixed-duration lease breaks after the remaining lease period elapses, and an infinite lease breaks immediately.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.BreakLeaseAsync Request.</returns>
            internal static Azure.Core.Http.Request BreakLeaseAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                int? breakPeriod = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "lease");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-lease-action", "break");
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (breakPeriod != null) { _request.Headers.SetValue("x-ms-lease-break-period", breakPeriod.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.BreakLeaseAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.BreakLeaseAsync Azure.Response{Azure.Storage.Blobs.Models.BrokenLease}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BrokenLease> BreakLeaseAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BrokenLease _value = new Azure.Storage.Blobs.Models.BrokenLease();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-lease-time", out _header))
                        {
                            _value.LeaseTime = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BrokenLease> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BrokenLease>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.BreakLeaseAsync

            #region Blob.CreateSnapshotAsync
            /// <summary>
            /// The Create Snapshot operation creates a read-only snapshot of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobSnapshotInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo>> CreateSnapshotAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.CreateSnapshot",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateSnapshotAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        timeout,
                        metadata,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateSnapshotAsync_CreateResponse(_response);
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
            /// Create the Blob.CreateSnapshotAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.CreateSnapshotAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateSnapshotAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "snapshot");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.CreateSnapshotAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.CreateSnapshotAsync Azure.Response{Azure.Storage.Blobs.Models.BlobSnapshotInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo> CreateSnapshotAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobSnapshotInfo _value = new Azure.Storage.Blobs.Models.BlobSnapshotInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-snapshot", out _header))
                        {
                            _value.Snapshot = _header;
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.CreateSnapshotAsync

            #region Blob.StartCopyFromUriAsync
            /// <summary>
            /// The Start Copy From URL operation copies a blob or an internet resource to a new blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>> StartCopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.StartCopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StartCopyFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        copySource,
                        timeout,
                        metadata,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StartCopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.StartCopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.StartCopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request StartCopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (copySource == null)
                {
                    throw new System.ArgumentNullException(nameof(copySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-source", copySource.ToString());
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.StartCopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.StartCopyFromUriAsync Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> StartCopyFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobCopyInfo _value = new Azure.Storage.Blobs.Models.BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.StartCopyFromUriAsync

            #region Blob.CopyFromUriAsync
            /// <summary>
            /// The Copy From URL operation copies a blob or an internet resource to a new blob. It will not return a response until the copy is complete.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>> CopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.CopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CopyFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        copySource,
                        timeout,
                        metadata,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.CopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.CopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request CopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (copySource == null)
                {
                    throw new System.ArgumentNullException(nameof(copySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-requires-sync", "true");
                _request.Headers.SetValue("x-ms-copy-source", copySource.ToString());
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.CopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.CopyFromUriAsync Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> CopyFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobCopyInfo _value = new Azure.Storage.Blobs.Models.BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.CopyFromUriAsync

            #region Blob.AbortCopyFromUriAsync
            /// <summary>
            /// The Abort Copy From URL operation aborts a pending Copy From URL operation, and leaves a destination blob with zero length and full metadata.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> AbortCopyFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string copyId,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.AbortCopyFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AbortCopyFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        copyId,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AbortCopyFromUriAsync_CreateResponse(_response);
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
            /// Create the Blob.AbortCopyFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copyId">The copy identifier provided in the x-ms-copy-id header of the original Copy Blob operation.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Blob.AbortCopyFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request AbortCopyFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string copyId,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "copy");
                _request.UriBuilder.AppendQuery("copyid", System.Uri.EscapeDataString(copyId));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-action", "abort");
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.AbortCopyFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.AbortCopyFromUriAsync Azure.Response.</returns>
            internal static Azure.Response AbortCopyFromUriAsync_CreateResponse(
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
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.AbortCopyFromUriAsync

            #region Blob.SetTierAsync
            /// <summary>
            /// The Set Tier operation sets the tier on a blob. The operation is allowed on a page blob in a premium storage account and on a block blob in a blob storage account (locally redundant storage only). A premium page blob's tier determines the allowed size, IOPS, and bandwidth of the blob. A block blob's tier determines Hot/Cool/Archive storage type. This operation does not update the blob's ETag.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="tier">Indicates the tier to be set on the blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetTierAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.AccessTier tier,
                int? timeout = default,
                string requestId = default,
                string leaseId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlobClient.SetTier",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = SetTierAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        tier,
                        timeout,
                        requestId,
                        leaseId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return SetTierAsync_CreateResponse(_response);
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
            /// Create the Blob.SetTierAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="tier">Indicates the tier to be set on the blob.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <returns>The Blob.SetTierAsync Request.</returns>
            internal static Azure.Core.Http.Request SetTierAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.AccessTier tier,
                int? timeout = default,
                string requestId = default,
                string leaseId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (tier == null)
                {
                    throw new System.ArgumentNullException(nameof(tier));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "tier");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-access-tier", tier);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }

                return _request;
            }

            /// <summary>
            /// Create the Blob.SetTierAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Blob.SetTierAsync Azure.Response.</returns>
            internal static Azure.Response SetTierAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        return response;
                    }
                    case 202:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Blob.SetTierAsync
        }
        #endregion Blob operations

        #region PageBlob operations
        /// <summary>
        /// PageBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class PageBlob
        {
            #region PageBlob.CreateAsync
            /// <summary>
            /// The Create operation creates a new page blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                long blobContentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        contentLength,
                        blobContentLength,
                        timeout,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobSequenceNumber,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the PageBlob.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                long blobContentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "PageBlob");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-blob-content-length", blobContentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (blobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", blobContentType); }
                if (blobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (blobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (blobContentHash != null) { _request.Headers.SetValue("x-ms-blob-content-md5", System.Convert.ToBase64String(blobContentHash)); }
                if (blobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", blobCacheControl); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (blobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", blobContentDisposition); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (blobSequenceNumber != null) { _request.Headers.SetValue("x-ms-blob-sequence-number", blobSequenceNumber.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.CreateAsync Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobContentInfo _value = new Azure.Storage.Blobs.Models.BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.CreateAsync

            #region PageBlob.UploadPagesAsync
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                byte[] transactionalContentHash = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UploadPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadPagesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        body,
                        contentLength,
                        transactionalContentHash,
                        timeout,
                        range,
                        leaseId,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadPagesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UploadPagesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UploadPagesAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadPagesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                byte[] transactionalContentHash = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (transactionalContentHash != null) { _request.Headers.SetValue("Content-MD5", System.Convert.ToBase64String(transactionalContentHash)); }
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifSequenceNumberLessThanOrEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", ifSequenceNumberLessThanOrEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberLessThan != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", ifSequenceNumberLessThan.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", ifSequenceNumberEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UploadPagesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UploadPagesAsync Azure.Response{Azure.Storage.Blobs.Models.PageInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.PageInfo _value = new Azure.Storage.Blobs.Models.PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UploadPagesAsync

            #region PageBlob.ClearPagesAsync
            /// <summary>
            /// The Clear Pages operation clears a set of pages from a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> ClearPagesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.ClearPages",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ClearPagesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        contentLength,
                        timeout,
                        range,
                        leaseId,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ClearPagesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.ClearPagesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.ClearPagesAsync Request.</returns>
            internal static Azure.Core.Http.Request ClearPagesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "clear");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifSequenceNumberLessThanOrEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", ifSequenceNumberLessThanOrEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberLessThan != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", ifSequenceNumberLessThan.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", ifSequenceNumberEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.ClearPagesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.ClearPagesAsync Azure.Response{Azure.Storage.Blobs.Models.PageInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageInfo> ClearPagesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.PageInfo _value = new Azure.Storage.Blobs.Models.PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.ClearPagesAsync

            #region PageBlob.UploadPagesFromUriAsync
            /// <summary>
            /// The Upload Pages operation writes a range of pages to a page blob where the contents are read from a URL
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="range">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri sourceUri,
                string sourceRange,
                long contentLength,
                string range,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UploadPagesFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadPagesFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        sourceUri,
                        sourceRange,
                        contentLength,
                        range,
                        sourceContentHash,
                        timeout,
                        leaseId,
                        ifSequenceNumberLessThanOrEqualTo,
                        ifSequenceNumberLessThan,
                        ifSequenceNumberEqualTo,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadPagesFromUriAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UploadPagesFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range. The length of this range should match the ContentLength header and x-ms-range/Range destination range header.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="range">The range of bytes to which the source range would be written. The range should be 512 aligned and range-end is required.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifSequenceNumberLessThanOrEqualTo">Specify this header value to operate only on a blob if it has a sequence number less than or equal to the specified.</param>
            /// <param name="ifSequenceNumberLessThan">Specify this header value to operate only on a blob if it has a sequence number less than the specified.</param>
            /// <param name="ifSequenceNumberEqualTo">Specify this header value to operate only on a blob if it has the specified sequence number.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UploadPagesFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadPagesFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri sourceUri,
                string sourceRange,
                long contentLength,
                string range,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                long? ifSequenceNumberLessThanOrEqualTo = default,
                long? ifSequenceNumberLessThan = default,
                long? ifSequenceNumberEqualTo = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (sourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(sourceUri));
                }
                if (sourceRange == null)
                {
                    throw new System.ArgumentNullException(nameof(sourceRange));
                }
                if (range == null)
                {
                    throw new System.ArgumentNullException(nameof(range));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "page");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-page-write", "update");
                _request.Headers.SetValue("x-ms-copy-source", sourceUri.ToString());
                _request.Headers.SetValue("x-ms-source-range", sourceRange);
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-range", range);
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (sourceContentHash != null) { _request.Headers.SetValue("x-ms-source-content-md5", System.Convert.ToBase64String(sourceContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifSequenceNumberLessThanOrEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-le", ifSequenceNumberLessThanOrEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberLessThan != null) { _request.Headers.SetValue("x-ms-if-sequence-number-lt", ifSequenceNumberLessThan.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifSequenceNumberEqualTo != null) { _request.Headers.SetValue("x-ms-if-sequence-number-eq", ifSequenceNumberEqualTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UploadPagesFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UploadPagesFromUriAsync Azure.Response{Azure.Storage.Blobs.Models.PageInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPagesFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.PageInfo _value = new Azure.Storage.Blobs.Models.PageInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UploadPagesFromUriAsync

            #region PageBlob.GetPageRangesAsync
            /// <summary>
            /// The Get Page Ranges operation returns the list of valid page ranges for a page blob or snapshot of a page blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageRangesInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.GetPageRanges",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPageRangesAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        snapshot,
                        timeout,
                        range,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPageRangesAsync_CreateResponse(_response);
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
            /// Create the PageBlob.GetPageRangesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.GetPageRangesAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPageRangesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.GetPageRangesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.GetPageRangesAsync Azure.Response{Azure.Storage.Blobs.Models.PageRangesInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRangesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.PageRangesInfo _value = new Azure.Storage.Blobs.Models.PageRangesInfo();
                        _value.Body = Azure.Storage.Blobs.Models.PageList.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-content-length", out _header))
                        {
                            _value.BlobContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.GetPageRangesAsync

            #region PageBlob.GetPageRangesDiffAsync
            /// <summary>
            /// The Get Page Ranges Diff operation returns the list of valid page ranges for a page blob that were changed between target blob and previous snapshot.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageRangesInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesDiffAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string prevsnapshot = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.GetPageRangesDiff",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetPageRangesDiffAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        snapshot,
                        timeout,
                        prevsnapshot,
                        range,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetPageRangesDiffAsync_CreateResponse(_response);
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
            /// Create the PageBlob.GetPageRangesDiffAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="prevsnapshot">Optional in version 2015-07-08 and newer. The prevsnapshot parameter is a DateTime value that specifies that the response will contain only pages that were changed between target blob and previous snapshot. Changed pages include both updated and cleared pages. The target blob may be a snapshot, as long as the snapshot specified by prevsnapshot is the older of the two. Note that incremental snapshots are currently supported only for blobs created on or after January 1, 2016.</param>
            /// <param name="range">Return only the bytes of the blob in the specified range.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.GetPageRangesDiffAsync Request.</returns>
            internal static Azure.Core.Http.Request GetPageRangesDiffAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string snapshot = default,
                int? timeout = default,
                string prevsnapshot = default,
                string range = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "pagelist");
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (prevsnapshot != null) { _request.UriBuilder.AppendQuery("prevsnapshot", System.Uri.EscapeDataString(prevsnapshot)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (range != null) { _request.Headers.SetValue("x-ms-range", range); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.GetPageRangesDiffAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.GetPageRangesDiffAsync Azure.Response{Azure.Storage.Blobs.Models.PageRangesInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRangesDiffAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.PageRangesInfo _value = new Azure.Storage.Blobs.Models.PageRangesInfo();
                        _value.Body = Azure.Storage.Blobs.Models.PageList.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-content-length", out _header))
                        {
                            _value.BlobContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.GetPageRangesDiffAsync

            #region PageBlob.ResizeAsync
            /// <summary>
            /// Resize the Blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageBlobInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> ResizeAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long blobContentLength,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.Resize",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ResizeAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        blobContentLength,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return ResizeAsync_CreateResponse(_response);
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
            /// Create the PageBlob.ResizeAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blobContentLength">This header specifies the maximum size for the page blob, up to 1 TB. The page blob size must be aligned to a 512-byte boundary.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.ResizeAsync Request.</returns>
            internal static Azure.Core.Http.Request ResizeAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long blobContentLength,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-content-length", blobContentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.ResizeAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.ResizeAsync Azure.Response{Azure.Storage.Blobs.Models.PageBlobInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> ResizeAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.PageBlobInfo _value = new Azure.Storage.Blobs.Models.PageBlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.ResizeAsync

            #region PageBlob.UpdateSequenceNumberAsync
            /// <summary>
            /// Update the sequence number of the blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sequenceNumberAction">Required if the x-ms-blob-sequence-number header is set for the request. This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.PageBlobInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> UpdateSequenceNumberAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.SequenceNumberAction sequenceNumberAction,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.UpdateSequenceNumber",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UpdateSequenceNumberAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        sequenceNumberAction,
                        timeout,
                        leaseId,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        blobSequenceNumber,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UpdateSequenceNumberAsync_CreateResponse(_response);
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
            /// Create the PageBlob.UpdateSequenceNumberAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sequenceNumberAction">Required if the x-ms-blob-sequence-number header is set for the request. This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="blobSequenceNumber">Set for page blobs only. The sequence number is a user-controlled value that you can use to track requests. The value of the sequence number must be between 0 and 2^63 - 1.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.UpdateSequenceNumberAsync Request.</returns>
            internal static Azure.Core.Http.Request UpdateSequenceNumberAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.SequenceNumberAction sequenceNumberAction,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                long? blobSequenceNumber = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "properties");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-sequence-number-action", Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(sequenceNumberAction));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (blobSequenceNumber != null) { _request.Headers.SetValue("x-ms-blob-sequence-number", blobSequenceNumber.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.UpdateSequenceNumberAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.UpdateSequenceNumberAsync Azure.Response{Azure.Storage.Blobs.Models.PageBlobInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> UpdateSequenceNumberAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.PageBlobInfo _value = new Azure.Storage.Blobs.Models.PageBlobInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.UpdateSequenceNumberAsync

            #region PageBlob.CopyIncrementalAsync
            /// <summary>
            /// The Copy Incremental operation copies a snapshot of the source page blob to a destination page blob. The snapshot is copied such that only the differential changes between the previously copied snapshot are transferred to the destination. The copied snapshots are complete copies of the original snapshot and can be read or copied from as usual. This API is supported since REST version 2016-05-31.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>> CopyIncrementalAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.PageBlobClient.CopyIncremental",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CopyIncrementalAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        copySource,
                        timeout,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CopyIncrementalAsync_CreateResponse(_response);
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
            /// Create the PageBlob.CopyIncrementalAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="copySource">Specifies the name of the source page blob snapshot. This value is a URL of up to 2 KB in length that specifies a page blob snapshot. The value should be URL-encoded as it would appear in a request URI. The source blob must either be public or must be authenticated via a shared access signature.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The PageBlob.CopyIncrementalAsync Request.</returns>
            internal static Azure.Core.Http.Request CopyIncrementalAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri copySource,
                int? timeout = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (copySource == null)
                {
                    throw new System.ArgumentNullException(nameof(copySource));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "incrementalcopy");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-source", copySource.ToString());
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the PageBlob.CopyIncrementalAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The PageBlob.CopyIncrementalAsync Azure.Response{Azure.Storage.Blobs.Models.BlobCopyInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> CopyIncrementalAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 202:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobCopyInfo _value = new Azure.Storage.Blobs.Models.BlobCopyInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
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
                            _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion PageBlob.CopyIncrementalAsync
        }
        #endregion PageBlob operations

        #region AppendBlob operations
        /// <summary>
        /// AppendBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class AppendBlob
        {
            #region AppendBlob.CreateAsync
            /// <summary>
            /// The Create Append Blob operation creates a new append blob.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.Create",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CreateAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        contentLength,
                        timeout,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CreateAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                long contentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "AppendBlob");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (blobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", blobContentType); }
                if (blobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (blobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (blobContentHash != null) { _request.Headers.SetValue("x-ms-blob-content-md5", System.Convert.ToBase64String(blobContentHash)); }
                if (blobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", blobCacheControl); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (blobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", blobContentDisposition); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.CreateAsync Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobContentInfo _value = new Azure.Storage.Blobs.Models.BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.CreateAsync

            #region AppendBlob.AppendBlockAsync
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobAppendInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                int? timeout = default,
                byte[] transactionalContentHash = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.AppendBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlockAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        body,
                        contentLength,
                        timeout,
                        transactionalContentHash,
                        leaseId,
                        maxSize,
                        appendPosition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlockAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.AppendBlockAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlockAsync Request.</returns>
            internal static Azure.Core.Http.Request AppendBlockAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                int? timeout = default,
                byte[] transactionalContentHash = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (transactionalContentHash != null) { _request.Headers.SetValue("Content-MD5", System.Convert.ToBase64String(transactionalContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (maxSize != null) { _request.Headers.SetValue("x-ms-blob-condition-maxsize", maxSize.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (appendPosition != null) { _request.Headers.SetValue("x-ms-blob-condition-appendpos", appendPosition.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlockAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlockAsync Azure.Response{Azure.Storage.Blobs.Models.BlobAppendInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobAppendInfo _value = new Azure.Storage.Blobs.Models.BlobAppendInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-append-offset", out _header))
                        {
                            _value.BlobAppendOffset = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-committed-block-count", out _header))
                        {
                            _value.BlobCommittedBlockCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlockAsync

            #region AppendBlob.AppendBlockFromUriAsync
            /// <summary>
            /// The Append Block operation commits a new block of data to the end of an existing append blob where the contents are read from a source url. The Append Block operation is permitted only if the blob was created with x-ms-blob-type set to AppendBlob. Append Block is supported only on version 2015-02-21 version or later.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobAppendInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri sourceUri,
                long contentLength,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.AppendBlobClient.AppendBlockFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = AppendBlockFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        sourceUri,
                        contentLength,
                        sourceRange,
                        sourceContentHash,
                        timeout,
                        leaseId,
                        maxSize,
                        appendPosition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return AppendBlockFromUriAsync_CreateResponse(_response);
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
            /// Create the AppendBlob.AppendBlockFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="maxSize">Optional conditional header. The max length in bytes permitted for the append blob. If the Append Block operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified in this header, the request will fail with MaxBlobSizeConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="appendPosition">Optional conditional header, used only for the Append Block operation. A number indicating the byte offset to compare. Append Block will succeed only if the append position is equal to this number. If it is not, the request will fail with the AppendPositionConditionNotMet error (HTTP status code 412 - Precondition Failed).</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The AppendBlob.AppendBlockFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request AppendBlockFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Uri sourceUri,
                long contentLength,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                long? maxSize = default,
                long? appendPosition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (sourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(sourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "appendblock");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-copy-source", sourceUri.ToString());
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (sourceRange != null) { _request.Headers.SetValue("x-ms-source-range", sourceRange); }
                if (sourceContentHash != null) { _request.Headers.SetValue("x-ms-source-content-md5", System.Convert.ToBase64String(sourceContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (maxSize != null) { _request.Headers.SetValue("x-ms-blob-condition-maxsize", maxSize.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (appendPosition != null) { _request.Headers.SetValue("x-ms-blob-condition-appendpos", appendPosition.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the AppendBlob.AppendBlockFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The AppendBlob.AppendBlockFromUriAsync Azure.Response{Azure.Storage.Blobs.Models.BlobAppendInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlockFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobAppendInfo _value = new Azure.Storage.Blobs.Models.BlobAppendInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-append-offset", out _header))
                        {
                            _value.BlobAppendOffset = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-committed-block-count", out _header))
                        {
                            _value.BlobCommittedBlockCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-server-encrypted", out _header))
                        {
                            _value.IsServerEncrypted = bool.Parse(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion AppendBlob.AppendBlockFromUriAsync
        }
        #endregion AppendBlob operations

        #region BlockBlob operations
        /// <summary>
        /// BlockBlob operations for Azure Blob Storage
        /// </summary>
        public static partial class BlockBlob
        {
            #region BlockBlob.UploadAsync
            /// <summary>
            /// The Upload Block Blob operation updates the content of an existing block blob. Updating an existing block blob overwrites any existing metadata on the blob. Partial updates are not supported with Put Blob; the content of the existing blob is overwritten with the content of the new blob. To perform a partial update of the content of a block blob, use the Put Block List operation.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.Upload",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UploadAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        body,
                        contentLength,
                        timeout,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        blobCacheControl,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return UploadAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.UploadAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="body">Initial data</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.UploadAsync Request.</returns>
            internal static Azure.Core.Http.Request UploadAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.IO.Stream body,
                long contentLength,
                int? timeout = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                string blobCacheControl = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
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

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-blob-type", "BlockBlob");
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (blobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", blobContentType); }
                if (blobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (blobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (blobContentHash != null) { _request.Headers.SetValue("x-ms-blob-content-md5", System.Convert.ToBase64String(blobContentHash)); }
                if (blobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", blobCacheControl); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (blobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", blobContentDisposition); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.UploadAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.UploadAsync Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> UploadAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobContentInfo _value = new Azure.Storage.Blobs.Models.BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.UploadAsync

            #region BlockBlob.StageBlockAsync
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="body">Initial data</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlockInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string blockId,
                long contentLength,
                System.IO.Stream body,
                byte[] transactionalContentHash = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.StageBlock",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StageBlockAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        blockId,
                        contentLength,
                        body,
                        transactionalContentHash,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StageBlockAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.StageBlockAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="body">Initial data</param>
            /// <param name="transactionalContentHash">Specify the transactional md5 for the body, to be validated by the service.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.StageBlockAsync Request.</returns>
            internal static Azure.Core.Http.Request StageBlockAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string blockId,
                long contentLength,
                System.IO.Stream body,
                byte[] transactionalContentHash = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (blockId == null)
                {
                    throw new System.ArgumentNullException(nameof(blockId));
                }
                if (body == null)
                {
                    throw new System.ArgumentNullException(nameof(body));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockId));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (transactionalContentHash != null) { _request.Headers.SetValue("Content-MD5", System.Convert.ToBase64String(transactionalContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(body);

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.StageBlockAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.StageBlockAsync Azure.Response{Azure.Storage.Blobs.Models.BlockInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlockAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlockInfo _value = new Azure.Storage.Blobs.Models.BlockInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.StageBlockAsync

            #region BlockBlob.StageBlockFromUriAsync
            /// <summary>
            /// The Stage Block operation creates a new block to be committed as part of a blob where the contents are read from a URL.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlockInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockFromUriAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string blockId,
                long contentLength,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.StageBlockFromUri",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = StageBlockFromUriAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        blockId,
                        contentLength,
                        sourceUri,
                        sourceRange,
                        sourceContentHash,
                        timeout,
                        leaseId,
                        sourceIfModifiedSince,
                        sourceIfUnmodifiedSince,
                        sourceIfMatch,
                        sourceIfNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return StageBlockFromUriAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.StageBlockFromUriAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blockId">A valid Base64 string value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block.</param>
            /// <param name="contentLength">The length of the request.</param>
            /// <param name="sourceUri">Specify a URL to the copy source.</param>
            /// <param name="sourceRange">Bytes of source data in the specified range.</param>
            /// <param name="sourceContentHash">Specify the md5 calculated for the range of bytes that must be read from the copy source.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="sourceIfModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="sourceIfUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="sourceIfMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="sourceIfNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.StageBlockFromUriAsync Request.</returns>
            internal static Azure.Core.Http.Request StageBlockFromUriAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string blockId,
                long contentLength,
                System.Uri sourceUri,
                string sourceRange = default,
                byte[] sourceContentHash = default,
                int? timeout = default,
                string leaseId = default,
                System.DateTimeOffset? sourceIfModifiedSince = default,
                System.DateTimeOffset? sourceIfUnmodifiedSince = default,
                Azure.Core.Http.ETag? sourceIfMatch = default,
                Azure.Core.Http.ETag? sourceIfNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (blockId == null)
                {
                    throw new System.ArgumentNullException(nameof(blockId));
                }
                if (sourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(sourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "block");
                _request.UriBuilder.AppendQuery("blockid", System.Uri.EscapeDataString(blockId));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("Content-Length", contentLength.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Headers.SetValue("x-ms-copy-source", sourceUri.ToString());
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (sourceRange != null) { _request.Headers.SetValue("x-ms-source-range", sourceRange); }
                if (sourceContentHash != null) { _request.Headers.SetValue("x-ms-source-content-md5", System.Convert.ToBase64String(sourceContentHash)); }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (sourceIfModifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-modified-since", sourceIfModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfUnmodifiedSince != null) { _request.Headers.SetValue("x-ms-source-if-unmodified-since", sourceIfUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (sourceIfMatch != null) { _request.Headers.SetValue("x-ms-source-if-match", sourceIfMatch.Value.ToString()); }
                if (sourceIfNoneMatch != null) { _request.Headers.SetValue("x-ms-source-if-none-match", sourceIfNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.StageBlockFromUriAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.StageBlockFromUriAsync Azure.Response{Azure.Storage.Blobs.Models.BlockInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlockFromUriAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlockInfo _value = new Azure.Storage.Blobs.Models.BlockInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    case 304:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.ConditionNotMetError _value = new Azure.Storage.Blobs.Models.ConditionNotMetError();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-error-code", out _header))
                        {
                            _value.ErrorCode = _header;
                        }

                        throw _value.CreateException(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.StageBlockFromUriAsync

            #region BlockBlob.CommitBlockListAsync
            /// <summary>
            /// The Commit Block List operation writes a blob by specifying the list of block IDs that make up the blob. In order to be written as part of a blob, a block must have been successfully written to the server in a prior Put Block operation. You can call Put Block List to update a blob by uploading only those blocks that have changed, then committing the new and existing blocks together. You can do this by specifying whether to commit a block from the committed block list or from the uncommitted block list, or to commit the most recently uploaded version of the block, whichever list it may belong to.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blocks">A list of block IDs split between the committed block list, in the uncommitted block list, or in the uncommitted block list first and then in the committed block list.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CommitBlockListAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlockLookupList blocks,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.CommitBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = CommitBlockListAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        blocks,
                        timeout,
                        blobCacheControl,
                        blobContentType,
                        blobContentEncoding,
                        blobContentLanguage,
                        blobContentHash,
                        metadata,
                        leaseId,
                        blobContentDisposition,
                        ifModifiedSince,
                        ifUnmodifiedSince,
                        ifMatch,
                        ifNoneMatch,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return CommitBlockListAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.CommitBlockListAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="blocks">A list of block IDs split between the committed block list, in the uncommitted block list, or in the uncommitted block list first and then in the committed block list.</param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="blobCacheControl">Optional. Sets the blob's cache control. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentType">Optional. Sets the blob's content type. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentEncoding">Optional. Sets the blob's content encoding. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentLanguage">Optional. Set the blob's content language. If specified, this property is stored with the blob and returned with a read request.</param>
            /// <param name="blobContentHash">Optional. An MD5 hash of the blob content. Note that this hash is not validated, as the hashes for the individual blocks were validated when each was uploaded.</param>
            /// <param name="metadata">Optional. Specifies a user-defined name-value pair associated with the blob. If no name-value pairs are specified, the operation will copy the metadata from the source blob or file to the destination blob. If one or more name-value pairs are specified, the destination blob is created with the specified metadata, and metadata is not copied from the source blob or file. Note that beginning with version 2009-09-19, metadata names must adhere to the naming rules for C# identifiers. See Naming and Referencing Containers, Blobs, and Metadata for more information.</param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="blobContentDisposition">Optional. Sets the blob's Content-Disposition header.</param>
            /// <param name="ifModifiedSince">Specify this header value to operate only on a blob if it has been modified since the specified date/time.</param>
            /// <param name="ifUnmodifiedSince">Specify this header value to operate only on a blob if it has not been modified since the specified date/time.</param>
            /// <param name="ifMatch">Specify an ETag value to operate only on blobs with a matching value.</param>
            /// <param name="ifNoneMatch">Specify an ETag value to operate only on blobs without a matching value.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.CommitBlockListAsync Request.</returns>
            internal static Azure.Core.Http.Request CommitBlockListAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlockLookupList blocks,
                int? timeout = default,
                string blobCacheControl = default,
                string blobContentType = default,
                System.Collections.Generic.IEnumerable<string> blobContentEncoding = default,
                System.Collections.Generic.IEnumerable<string> blobContentLanguage = default,
                byte[] blobContentHash = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string leaseId = default,
                string blobContentDisposition = default,
                System.DateTimeOffset? ifModifiedSince = default,
                System.DateTimeOffset? ifUnmodifiedSince = default,
                Azure.Core.Http.ETag? ifMatch = default,
                Azure.Core.Http.ETag? ifNoneMatch = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (blocks == null)
                {
                    throw new System.ArgumentNullException(nameof(blocks));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (blobCacheControl != null) { _request.Headers.SetValue("x-ms-blob-cache-control", blobCacheControl); }
                if (blobContentType != null) { _request.Headers.SetValue("x-ms-blob-content-type", blobContentType); }
                if (blobContentEncoding != null) {
                    foreach (string _item in blobContentEncoding)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-encoding", _item);
                    }
                }
                if (blobContentLanguage != null) {
                    foreach (string _item in blobContentLanguage)
                    {
                        _request.Headers.SetValue("x-ms-blob-content-language", _item);
                    }
                }
                if (blobContentHash != null) { _request.Headers.SetValue("x-ms-blob-content-md5", System.Convert.ToBase64String(blobContentHash)); }
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (blobContentDisposition != null) { _request.Headers.SetValue("x-ms-blob-content-disposition", blobContentDisposition); }
                if (ifModifiedSince != null) { _request.Headers.SetValue("If-Modified-Since", ifModifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifUnmodifiedSince != null) { _request.Headers.SetValue("If-Unmodified-Since", ifUnmodifiedSince.Value.ToString("R", System.Globalization.CultureInfo.InvariantCulture)); }
                if (ifMatch != null) { _request.Headers.SetValue("If-Match", ifMatch.Value.ToString()); }
                if (ifNoneMatch != null) { _request.Headers.SetValue("If-None-Match", ifNoneMatch.Value.ToString()); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Blobs.Models.BlockLookupList.ToXml(blocks, "BlockList", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.CommitBlockListAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.CommitBlockListAsync Azure.Response{Azure.Storage.Blobs.Models.BlobContentInfo}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CommitBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        Azure.Storage.Blobs.Models.BlobContentInfo _value = new Azure.Storage.Blobs.Models.BlobContentInfo();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("Content-MD5", out _header))
                        {
                            _value.ContentHash = System.Convert.FromBase64String(_header);
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-sequence-number", out _header))
                        {
                            _value.BlobSequenceNumber = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.CommitBlockListAsync

            #region BlockBlob.GetBlockListAsync
            /// <summary>
            /// The Get Block List operation retrieves the list of blocks that have been uploaded as part of a block blob
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="listType">Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Blobs.Models.GetBlockListOperation}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.GetBlockListOperation>> GetBlockListAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlockListType listType,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Blobs.BlockBlobClient.GetBlockList",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = GetBlockListAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        listType,
                        snapshot,
                        timeout,
                        leaseId,
                        requestId))
                    {
                        Azure.Response _response = async ?
                            // Send the request asynchronously if we're being called via an async path
                            await pipeline.SendRequestAsync(_request, cancellationToken).ConfigureAwait(false) :
                            // Send the request synchronously through the API that blocks if we're being called via a sync path
                            // (this is safe because the Task will complete before the user can call Wait)
                            pipeline.SendRequest(_request, cancellationToken);
                        cancellationToken.ThrowIfCancellationRequested();
                        return GetBlockListAsync_CreateResponse(_response);
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
            /// Create the BlockBlob.GetBlockListAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, container, or blob that is the targe of the desired operation.</param>
            /// <param name="listType">Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.</param>
            /// <param name="snapshot">The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob">Creating a Snapshot of a Blob.</a></param>
            /// <param name="timeout">The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations">Setting Timeouts for Blob Service Operations.</a></param>
            /// <param name="leaseId">If specified, the operation only succeeds if the resource's lease is active and matches this ID.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The BlockBlob.GetBlockListAsync Request.</returns>
            internal static Azure.Core.Http.Request GetBlockListAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Blobs.Models.BlockListType listType,
                string snapshot = default,
                int? timeout = default,
                string leaseId = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Get;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("comp", "blocklist");
                _request.UriBuilder.AppendQuery("blocklisttype", System.Uri.EscapeDataString(Azure.Storage.Blobs.BlobRestClient.Serialization.ToString(listType)));
                if (snapshot != null) { _request.UriBuilder.AppendQuery("snapshot", System.Uri.EscapeDataString(snapshot)); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (leaseId != null) { _request.Headers.SetValue("x-ms-lease-id", leaseId); }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the BlockBlob.GetBlockListAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The BlockBlob.GetBlockListAsync Azure.Response{Azure.Storage.Blobs.Models.GetBlockListOperation}.</returns>
            internal static Azure.Response<Azure.Storage.Blobs.Models.GetBlockListOperation> GetBlockListAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.GetBlockListOperation _value = new Azure.Storage.Blobs.Models.GetBlockListOperation();
                        _value.Body = Azure.Storage.Blobs.Models.BlockList.FromXml(_xml.Root);

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("Last-Modified", out _header))
                        {
                            _value.LastModified = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("ETag", out _header))
                        {
                            _value.ETag = new Azure.Core.Http.ETag(_header);
                        }
                        if (response.Headers.TryGetValue("Content-Type", out _header))
                        {
                            _value.ContentType = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-blob-content-length", out _header))
                        {
                            _value.BlobContentLength = long.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        if (response.Headers.TryGetValue("x-ms-request-id", out _header))
                        {
                            _value.RequestId = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-version", out _header))
                        {
                            _value.Version = _header;
                        }
                        if (response.Headers.TryGetValue("Date", out _header))
                        {
                            _value.Date = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Blobs.Models.GetBlockListOperation> _result =
                            new Azure.Response<Azure.Storage.Blobs.Models.GetBlockListOperation>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Blobs.Models.StorageError _value = Azure.Storage.Blobs.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion BlockBlob.GetBlockListAsync
        }
        #endregion BlockBlob operations
    }
}
#endregion Service

#region Models
#region enum PublicAccessType
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies whether data in the container may be accessed publicly and the level of access
    /// </summary>
    public enum PublicAccessType
    {
        /// <summary>
        /// container
        /// </summary>
        Container,

        /// <summary>
        /// blob
        /// </summary>
        Blob
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.PublicAccessType value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.PublicAccessType.Container:
                        return "container";
                    case Azure.Storage.Blobs.Models.PublicAccessType.Blob:
                        return "blob";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.PublicAccessType value.");
                }
            }

            public static Azure.Storage.Blobs.Models.PublicAccessType ParsePublicAccessType(string value)
            {
                switch (value)
                {
                    case "container":
                        return Azure.Storage.Blobs.Models.PublicAccessType.Container;
                    case "blob":
                        return Azure.Storage.Blobs.Models.PublicAccessType.Blob;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.PublicAccessType value.");
                }
            }
        }
    }
}
#endregion enum PublicAccessType

#region enum strings AccessTier
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Indicates the tier to be set on the blob.
    /// </summary>
    public partial struct AccessTier : System.IEquatable<AccessTier>
    {
        #pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// P4
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P4 = @"P4";

        /// <summary>
        /// P6
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P6 = @"P6";

        /// <summary>
        /// P10
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P10 = @"P10";

        /// <summary>
        /// P20
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P20 = @"P20";

        /// <summary>
        /// P30
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P30 = @"P30";

        /// <summary>
        /// P40
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P40 = @"P40";

        /// <summary>
        /// P50
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier P50 = @"P50";

        /// <summary>
        /// Hot
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier Hot = @"Hot";

        /// <summary>
        /// Cool
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier Cool = @"Cool";

        /// <summary>
        /// Archive
        /// </summary>
        public static Azure.Storage.Blobs.Models.AccessTier Archive = @"Archive";
        #pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// The AccessTier value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Creates a new AccessTier instance.
        /// </summary>
        /// <param name="value">The AccessTier value.</param>
        private AccessTier(string value) { this._value = value; }

        /// <summary>
        /// Check if two AccessTier instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Blobs.Models.AccessTier other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);

        /// <summary>
        /// Check if two AccessTier instances are equal.
        /// </summary>
        /// <param name="o">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object o) => o is Azure.Storage.Blobs.Models.AccessTier other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the AccessTier.
        /// </summary>
        /// <returns>Hash code for the AccessTier.</returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// Convert the AccessTier to a string.
        /// </summary>
        /// <returns>String representation of the AccessTier.</returns>
        public override string ToString() => this._value;

        #pragma warning disable CA2225 // Operator overloads have named alternates
        /// <summary>
        /// Convert a string a AccessTier.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The AccessTier value.</returns>
        public static implicit operator AccessTier(string value) => new Azure.Storage.Blobs.Models.AccessTier(value);
        #pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Convert an AccessTier to a string.
        /// </summary>
        /// <param name="o">The AccessTier value.</param>
        /// <returns>String representation of the AccessTier value.</returns>
        public static implicit operator string(Azure.Storage.Blobs.Models.AccessTier o) => o._value;

        /// <summary>
        /// Check if two AccessTier instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(Azure.Storage.Blobs.Models.AccessTier a, Azure.Storage.Blobs.Models.AccessTier b) => a.Equals(b);

        /// <summary>
        /// Check if two AccessTier instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(Azure.Storage.Blobs.Models.AccessTier a, Azure.Storage.Blobs.Models.AccessTier b) => !a.Equals(b);
    }
}
#endregion enum strings AccessTier

#region enum BlockListType
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.
    /// </summary>
    public enum BlockListType
    {
        /// <summary>
        /// committed
        /// </summary>
        Committed,

        /// <summary>
        /// uncommitted
        /// </summary>
        Uncommitted,

        /// <summary>
        /// all
        /// </summary>
        All
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.BlockListType value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.BlockListType.Committed:
                        return "committed";
                    case Azure.Storage.Blobs.Models.BlockListType.Uncommitted:
                        return "uncommitted";
                    case Azure.Storage.Blobs.Models.BlockListType.All:
                        return "all";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.BlockListType value.");
                }
            }

            public static Azure.Storage.Blobs.Models.BlockListType ParseBlockListType(string value)
            {
                switch (value)
                {
                    case "committed":
                        return Azure.Storage.Blobs.Models.BlockListType.Committed;
                    case "uncommitted":
                        return Azure.Storage.Blobs.Models.BlockListType.Uncommitted;
                    case "all":
                        return Azure.Storage.Blobs.Models.BlockListType.All;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.BlockListType value.");
                }
            }
        }
    }
}
#endregion enum BlockListType

#region class AccessPolicy
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An Access policy
    /// </summary>
    public partial class AccessPolicy
    {
        /// <summary>
        /// the date-time the policy is active
        /// </summary>
        public System.DateTimeOffset Start { get; set; }

        /// <summary>
        /// the date-time the policy expires
        /// </summary>
        public System.DateTimeOffset Expiry { get; set; }

        /// <summary>
        /// the permissions for the acl policy
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// Serialize a AccessPolicy instance as XML.
        /// </summary>
        /// <param name="value">The AccessPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "AccessPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.AccessPolicy value, string name = "AccessPolicy", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Start", ""),
                value.Start.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Expiry", ""),
                value.Expiry.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Permission", ""),
                value.Permission));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new AccessPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized AccessPolicy instance.</returns>
        internal static Azure.Storage.Blobs.Models.AccessPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.AccessPolicy _value = new Azure.Storage.Blobs.Models.AccessPolicy();
            _value.Start = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("Start", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.Expiry = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("Expiry", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.Permission = element.Element(System.Xml.Linq.XName.Get("Permission", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.AccessPolicy value);
    }
}
#endregion class AccessPolicy

#region class SignedIdentifier
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// signed identifier
    /// </summary>
    public partial class SignedIdentifier
    {
        /// <summary>
        /// a unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An Access policy
        /// </summary>
        public Azure.Storage.Blobs.Models.AccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Creates a new SignedIdentifier instance
        /// </summary>
        public SignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new SignedIdentifier instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal SignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.AccessPolicy = new Azure.Storage.Blobs.Models.AccessPolicy();
            }
        }

        /// <summary>
        /// Serialize a SignedIdentifier instance as XML.
        /// </summary>
        /// <param name="value">The SignedIdentifier instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "SignedIdentifier".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.SignedIdentifier value, string name = "SignedIdentifier", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Id", ""),
                value.Id));
            _element.Add(Azure.Storage.Blobs.Models.AccessPolicy.ToXml(value.AccessPolicy, "AccessPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new SignedIdentifier instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SignedIdentifier instance.</returns>
        internal static Azure.Storage.Blobs.Models.SignedIdentifier FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.SignedIdentifier _value = new Azure.Storage.Blobs.Models.SignedIdentifier(true);
            _value.Id = element.Element(System.Xml.Linq.XName.Get("Id", "")).Value;
            _value.AccessPolicy = Azure.Storage.Blobs.Models.AccessPolicy.FromXml(element.Element(System.Xml.Linq.XName.Get("AccessPolicy", "")));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.SignedIdentifier value);
    }
}
#endregion class SignedIdentifier

#region enum DeleteSnapshotsOption
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Required if the blob has associated snapshots. Specify one of the following two options: include: Delete the base blob and all of its snapshots. only: Delete only the blob's snapshots and not the blob itself
    /// </summary>
    public enum DeleteSnapshotsOption
    {
        /// <summary>
        /// include
        /// </summary>
        Include,

        /// <summary>
        /// only
        /// </summary>
        Only
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.DeleteSnapshotsOption value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.DeleteSnapshotsOption.Include:
                        return "include";
                    case Azure.Storage.Blobs.Models.DeleteSnapshotsOption.Only:
                        return "only";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.DeleteSnapshotsOption value.");
                }
            }

            public static Azure.Storage.Blobs.Models.DeleteSnapshotsOption ParseDeleteSnapshotsOption(string value)
            {
                switch (value)
                {
                    case "include":
                        return Azure.Storage.Blobs.Models.DeleteSnapshotsOption.Include;
                    case "only":
                        return Azure.Storage.Blobs.Models.DeleteSnapshotsOption.Only;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.DeleteSnapshotsOption value.");
                }
            }
        }
    }
}
#endregion enum DeleteSnapshotsOption

#region class KeyInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Key information
    /// </summary>
    internal partial class KeyInfo
    {
        /// <summary>
        /// The date-time the key is active in ISO 8601 UTC time
        /// </summary>
        public System.DateTimeOffset? Start { get; set; }

        /// <summary>
        /// The date-time the key expires in ISO 8601 UTC time
        /// </summary>
        public System.DateTimeOffset Expiry { get; set; }

        /// <summary>
        /// Serialize a KeyInfo instance as XML.
        /// </summary>
        /// <param name="value">The KeyInfo instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "KeyInfo".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.KeyInfo value, string name = "KeyInfo", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Start != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Start", ""),
                    value.Start.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ", System.Globalization.CultureInfo.InvariantCulture)));
            }
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Expiry", ""),
                value.Expiry.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ", System.Globalization.CultureInfo.InvariantCulture)));
            return _element;
        }
    }
}
#endregion class KeyInfo

#region enum ListBlobsIncludeItem
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ListBlobsIncludeItem values
    /// </summary>
    internal enum ListBlobsIncludeItem
    {
        /// <summary>
        /// copy
        /// </summary>
        Copy,

        /// <summary>
        /// deleted
        /// </summary>
        Deleted,

        /// <summary>
        /// metadata
        /// </summary>
        Metadata,

        /// <summary>
        /// snapshots
        /// </summary>
        Snapshots,

        /// <summary>
        /// uncommittedblobs
        /// </summary>
        Uncommittedblobs
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.ListBlobsIncludeItem value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Copy:
                        return "copy";
                    case Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Deleted:
                        return "deleted";
                    case Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Metadata:
                        return "metadata";
                    case Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Snapshots:
                        return "snapshots";
                    case Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Uncommittedblobs:
                        return "uncommittedblobs";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ListBlobsIncludeItem value.");
                }
            }

            public static Azure.Storage.Blobs.Models.ListBlobsIncludeItem ParseListBlobsIncludeItem(string value)
            {
                switch (value)
                {
                    case "copy":
                        return Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Copy;
                    case "deleted":
                        return Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Deleted;
                    case "metadata":
                        return Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Metadata;
                    case "snapshots":
                        return Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Snapshots;
                    case "uncommittedblobs":
                        return Azure.Storage.Blobs.Models.ListBlobsIncludeItem.Uncommittedblobs;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ListBlobsIncludeItem value.");
                }
            }
        }
    }
}
#endregion enum ListBlobsIncludeItem

#region enum ListContainersIncludeType
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Include this parameter to specify that the container's metadata be returned as part of the response body.
    /// </summary>
    internal enum ListContainersIncludeType
    {
        /// <summary>
        /// metadata
        /// </summary>
        Metadata
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.ListContainersIncludeType value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.ListContainersIncludeType.Metadata:
                        return "metadata";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ListContainersIncludeType value.");
                }
            }

            public static Azure.Storage.Blobs.Models.ListContainersIncludeType ParseListContainersIncludeType(string value)
            {
                switch (value)
                {
                    case "metadata":
                        return Azure.Storage.Blobs.Models.ListContainersIncludeType.Metadata;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.ListContainersIncludeType value.");
                }
            }
        }
    }
}
#endregion enum ListContainersIncludeType

#region enum SequenceNumberAction
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Required if the x-ms-blob-sequence-number header is set for the request. This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number
    /// </summary>
    public enum SequenceNumberAction
    {
        /// <summary>
        /// max
        /// </summary>
        Max,

        /// <summary>
        /// update
        /// </summary>
        Update,

        /// <summary>
        /// increment
        /// </summary>
        Increment
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.SequenceNumberAction value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.SequenceNumberAction.Max:
                        return "max";
                    case Azure.Storage.Blobs.Models.SequenceNumberAction.Update:
                        return "update";
                    case Azure.Storage.Blobs.Models.SequenceNumberAction.Increment:
                        return "increment";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.SequenceNumberAction value.");
                }
            }

            public static Azure.Storage.Blobs.Models.SequenceNumberAction ParseSequenceNumberAction(string value)
            {
                switch (value)
                {
                    case "max":
                        return Azure.Storage.Blobs.Models.SequenceNumberAction.Max;
                    case "update":
                        return Azure.Storage.Blobs.Models.SequenceNumberAction.Update;
                    case "increment":
                        return Azure.Storage.Blobs.Models.SequenceNumberAction.Increment;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.SequenceNumberAction value.");
                }
            }
        }
    }
}
#endregion enum SequenceNumberAction

#region class RetentionPolicy
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// the retention policy which determines how long the associated data should persist
    /// </summary>
    public partial class RetentionPolicy
    {
        /// <summary>
        /// Indicates whether a retention policy is enabled for the storage service
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates the number of days that metrics or logging or soft-deleted data should be retained. All data older than this value will be deleted
        /// </summary>
        public int? Days { get; set; }

        /// <summary>
        /// Serialize a RetentionPolicy instance as XML.
        /// </summary>
        /// <param name="value">The RetentionPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "RetentionPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.RetentionPolicy value, string name = "RetentionPolicy", string ns = "")
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
        /// Deserializes XML into a new RetentionPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized RetentionPolicy instance.</returns>
        internal static Azure.Storage.Blobs.Models.RetentionPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.RetentionPolicy _value = new Azure.Storage.Blobs.Models.RetentionPolicy();
            _value.Enabled = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Enabled", "")).Value);
            _child = element.Element(System.Xml.Linq.XName.Get("Days", ""));
            if (_child != null)
            {
                _value.Days = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.RetentionPolicy value);
    }
}
#endregion class RetentionPolicy

#region class Logging
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Azure Analytics Logging settings.
    /// </summary>
    #pragma warning disable CA1724
    public partial class Logging
    #pragma warning restore CA1724
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether all delete requests should be logged.
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// Indicates whether all read requests should be logged.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Indicates whether all write requests should be logged.
        /// </summary>
        public bool Write { get; set; }

        /// <summary>
        /// the retention policy which determines how long the associated data should persist
        /// </summary>
        public Azure.Storage.Blobs.Models.RetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Creates a new Logging instance
        /// </summary>
        public Logging()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new Logging instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal Logging(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.RetentionPolicy = new Azure.Storage.Blobs.Models.RetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a Logging instance as XML.
        /// </summary>
        /// <param name="value">The Logging instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Logging".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.Logging value, string name = "Logging", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Version", ""),
                value.Version));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Delete", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Delete.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Read", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Read.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Write", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Write.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            _element.Add(Azure.Storage.Blobs.Models.RetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new Logging instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Logging instance.</returns>
        internal static Azure.Storage.Blobs.Models.Logging FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.Logging _value = new Azure.Storage.Blobs.Models.Logging(true);
            _value.Version = element.Element(System.Xml.Linq.XName.Get("Version", "")).Value;
            _value.Delete = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Delete", "")).Value);
            _value.Read = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Read", "")).Value);
            _value.Write = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Write", "")).Value);
            _value.RetentionPolicy = Azure.Storage.Blobs.Models.RetentionPolicy.FromXml(element.Element(System.Xml.Linq.XName.Get("RetentionPolicy", "")));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.Logging value);
    }
}
#endregion class Logging

#region class Metrics
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// a summary of request statistics grouped by API in hour or minute aggregates for blobs
    /// </summary>
    public partial class Metrics
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether metrics are enabled for the Blob service.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        public bool? IncludeAPIs { get; set; }

        /// <summary>
        /// the retention policy which determines how long the associated data should persist
        /// </summary>
        public Azure.Storage.Blobs.Models.RetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Creates a new Metrics instance
        /// </summary>
        public Metrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new Metrics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal Metrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.RetentionPolicy = new Azure.Storage.Blobs.Models.RetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a Metrics instance as XML.
        /// </summary>
        /// <param name="value">The Metrics instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Metrics".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.Metrics value, string name = "Metrics", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Version != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Version", ""),
                    value.Version));
            }
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Enabled", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Enabled.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            if (value.IncludeAPIs != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("IncludeAPIs", ""),
                    #pragma warning disable CA1308 // Normalize strings to uppercase
                    value.IncludeAPIs.Value.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                    #pragma warning restore CA1308 // Normalize strings to uppercase
            }
            if (value.RetentionPolicy != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.RetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new Metrics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Metrics instance.</returns>
        internal static Azure.Storage.Blobs.Models.Metrics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.Metrics _value = new Azure.Storage.Blobs.Models.Metrics(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Version", ""));
            if (_child != null)
            {
                _value.Version = _child.Value;
            }
            _value.Enabled = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Enabled", "")).Value);
            _child = element.Element(System.Xml.Linq.XName.Get("IncludeAPIs", ""));
            if (_child != null)
            {
                _value.IncludeAPIs = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RetentionPolicy", ""));
            if (_child != null)
            {
                _value.RetentionPolicy = Azure.Storage.Blobs.Models.RetentionPolicy.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.Metrics value);
    }
}
#endregion class Metrics

#region class CorsRule
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// CORS is an HTTP feature that enables a web application running under one domain to access resources in another domain. Web browsers implement a security restriction known as same-origin policy that prevents a web page from calling APIs in a different domain; CORS provides a secure way to allow one domain (the origin domain) to call APIs in another domain
    /// </summary>
    public partial class CorsRule
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
        /// the request headers that the origin domain may specify on the CORS request.
        /// </summary>
        public string AllowedHeaders { get; set; }

        /// <summary>
        /// The response headers that may be sent in the response to the CORS request and exposed by the browser to the request issuer
        /// </summary>
        public string ExposedHeaders { get; set; }

        /// <summary>
        /// The maximum amount time that a browser should cache the preflight OPTIONS request.
        /// </summary>
        public int MaxAgeInSeconds { get; set; }

        /// <summary>
        /// Serialize a CorsRule instance as XML.
        /// </summary>
        /// <param name="value">The CorsRule instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "CorsRule".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.CorsRule value, string name = "CorsRule", string ns = "")
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
        /// Deserializes XML into a new CorsRule instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized CorsRule instance.</returns>
        internal static Azure.Storage.Blobs.Models.CorsRule FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.CorsRule _value = new Azure.Storage.Blobs.Models.CorsRule();
            _value.AllowedOrigins = element.Element(System.Xml.Linq.XName.Get("AllowedOrigins", "")).Value;
            _value.AllowedMethods = element.Element(System.Xml.Linq.XName.Get("AllowedMethods", "")).Value;
            _value.AllowedHeaders = element.Element(System.Xml.Linq.XName.Get("AllowedHeaders", "")).Value;
            _value.ExposedHeaders = element.Element(System.Xml.Linq.XName.Get("ExposedHeaders", "")).Value;
            _value.MaxAgeInSeconds = int.Parse(element.Element(System.Xml.Linq.XName.Get("MaxAgeInSeconds", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.CorsRule value);
    }
}
#endregion class CorsRule

#region class StaticWebsite
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The properties that enable an account to host a static website
    /// </summary>
    public partial class StaticWebsite
    {
        /// <summary>
        /// Indicates whether this account is hosting a static website
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The default name of the index page under each directory
        /// </summary>
        public string IndexDocument { get; set; }

        /// <summary>
        /// The absolute path of the custom 404 page
        /// </summary>
        public string ErrorDocument404Path { get; set; }

        /// <summary>
        /// Serialize a StaticWebsite instance as XML.
        /// </summary>
        /// <param name="value">The StaticWebsite instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "StaticWebsite".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.StaticWebsite value, string name = "StaticWebsite", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Enabled", ""),
                #pragma warning disable CA1308 // Normalize strings to uppercase
                value.Enabled.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLowerInvariant()));
                #pragma warning restore CA1308 // Normalize strings to uppercase
            if (value.IndexDocument != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("IndexDocument", ""),
                    value.IndexDocument));
            }
            if (value.ErrorDocument404Path != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("ErrorDocument404Path", ""),
                    value.ErrorDocument404Path));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new StaticWebsite instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized StaticWebsite instance.</returns>
        internal static Azure.Storage.Blobs.Models.StaticWebsite FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.StaticWebsite _value = new Azure.Storage.Blobs.Models.StaticWebsite();
            _value.Enabled = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Enabled", "")).Value);
            _child = element.Element(System.Xml.Linq.XName.Get("IndexDocument", ""));
            if (_child != null)
            {
                _value.IndexDocument = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ErrorDocument404Path", ""));
            if (_child != null)
            {
                _value.ErrorDocument404Path = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.StaticWebsite value);
    }
}
#endregion class StaticWebsite

#region class BlobServiceProperties
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Storage Service Properties.
    /// </summary>
    public partial class BlobServiceProperties
    {
        /// <summary>
        /// Azure Analytics Logging settings.
        /// </summary>
        public Azure.Storage.Blobs.Models.Logging Logging { get; set; }

        /// <summary>
        /// a summary of request statistics grouped by API in hour or minute aggregates for blobs
        /// </summary>
        public Azure.Storage.Blobs.Models.Metrics HourMetrics { get; set; }

        /// <summary>
        /// a summary of request statistics grouped by API in hour or minute aggregates for blobs
        /// </summary>
        public Azure.Storage.Blobs.Models.Metrics MinuteMetrics { get; set; }

        /// <summary>
        /// The set of CORS rules.
        /// </summary>
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.CorsRule> Cors { get; internal set; }

        /// <summary>
        /// The default version to use for requests to the Blob service if an incoming request's version is not specified. Possible values include version 2008-10-27 and all more recent versions
        /// </summary>
        public string DefaultServiceVersion { get; set; }

        /// <summary>
        /// the retention policy which determines how long the associated data should persist
        /// </summary>
        public Azure.Storage.Blobs.Models.RetentionPolicy DeleteRetentionPolicy { get; set; }

        /// <summary>
        /// The properties that enable an account to host a static website
        /// </summary>
        public Azure.Storage.Blobs.Models.StaticWebsite StaticWebsite { get; set; }

        /// <summary>
        /// Creates a new BlobServiceProperties instance
        /// </summary>
        public BlobServiceProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobServiceProperties instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.Logging = new Azure.Storage.Blobs.Models.Logging();
                this.HourMetrics = new Azure.Storage.Blobs.Models.Metrics();
                this.MinuteMetrics = new Azure.Storage.Blobs.Models.Metrics();
                this.Cors = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.CorsRule>();
                this.DeleteRetentionPolicy = new Azure.Storage.Blobs.Models.RetentionPolicy();
                this.StaticWebsite = new Azure.Storage.Blobs.Models.StaticWebsite();
            }
        }

        /// <summary>
        /// Serialize a BlobServiceProperties instance as XML.
        /// </summary>
        /// <param name="value">The BlobServiceProperties instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "StorageServiceProperties".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.BlobServiceProperties value, string name = "StorageServiceProperties", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Logging != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.Logging.ToXml(value.Logging, "Logging", ""));
            }
            if (value.HourMetrics != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.Metrics.ToXml(value.HourMetrics, "HourMetrics", ""));
            }
            if (value.MinuteMetrics != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.Metrics.ToXml(value.MinuteMetrics, "MinuteMetrics", ""));
            }
            if (value.Cors != null)
            {
                System.Xml.Linq.XElement _elements = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Cors", ""));
                foreach (Azure.Storage.Blobs.Models.CorsRule _child in value.Cors)
                {
                    _elements.Add(Azure.Storage.Blobs.Models.CorsRule.ToXml(_child));
                }
                _element.Add(_elements);
            }
            if (value.DefaultServiceVersion != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("DefaultServiceVersion", ""),
                    value.DefaultServiceVersion));
            }
            if (value.DeleteRetentionPolicy != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.RetentionPolicy.ToXml(value.DeleteRetentionPolicy, "DeleteRetentionPolicy", ""));
            }
            if (value.StaticWebsite != null)
            {
                _element.Add(Azure.Storage.Blobs.Models.StaticWebsite.ToXml(value.StaticWebsite, "StaticWebsite", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new BlobServiceProperties instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobServiceProperties instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobServiceProperties FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobServiceProperties _value = new Azure.Storage.Blobs.Models.BlobServiceProperties(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Logging", ""));
            if (_child != null)
            {
                _value.Logging = Azure.Storage.Blobs.Models.Logging.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("HourMetrics", ""));
            if (_child != null)
            {
                _value.HourMetrics = Azure.Storage.Blobs.Models.Metrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MinuteMetrics", ""));
            if (_child != null)
            {
                _value.MinuteMetrics = Azure.Storage.Blobs.Models.Metrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Cors", ""));
            if (_child != null)
            {
                _value.Cors = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("CorsRule", "")),
                        e => Azure.Storage.Blobs.Models.CorsRule.FromXml(e)));
            }
            else
            {
                _value.Cors = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.CorsRule>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DefaultServiceVersion", ""));
            if (_child != null)
            {
                _value.DefaultServiceVersion = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DeleteRetentionPolicy", ""));
            if (_child != null)
            {
                _value.DeleteRetentionPolicy = Azure.Storage.Blobs.Models.RetentionPolicy.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("StaticWebsite", ""));
            if (_child != null)
            {
                _value.StaticWebsite = Azure.Storage.Blobs.Models.StaticWebsite.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobServiceProperties value);
    }
}
#endregion class BlobServiceProperties

#region class UserDelegationKey
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A user delegation key
    /// </summary>
    public partial class UserDelegationKey
    {
        /// <summary>
        /// The Azure Active Directory object ID in GUID format.
        /// </summary>
        public string SignedOid { get; internal set; }

        /// <summary>
        /// The Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string SignedTid { get; internal set; }

        /// <summary>
        /// The date-time the key is active
        /// </summary>
        public System.DateTimeOffset SignedStart { get; internal set; }

        /// <summary>
        /// The date-time the key expires
        /// </summary>
        public System.DateTimeOffset SignedExpiry { get; internal set; }

        /// <summary>
        /// Abbreviation of the Azure Storage service that accepts the key
        /// </summary>
        public string SignedService { get; internal set; }

        /// <summary>
        /// The service version that created the key
        /// </summary>
        public string SignedVersion { get; internal set; }

        /// <summary>
        /// The key as a base64 string
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new UserDelegationKey instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized UserDelegationKey instance.</returns>
        internal static Azure.Storage.Blobs.Models.UserDelegationKey FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.UserDelegationKey _value = new Azure.Storage.Blobs.Models.UserDelegationKey();
            _value.SignedOid = element.Element(System.Xml.Linq.XName.Get("SignedOid", "")).Value;
            _value.SignedTid = element.Element(System.Xml.Linq.XName.Get("SignedTid", "")).Value;
            _value.SignedStart = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("SignedStart", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.SignedExpiry = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("SignedExpiry", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.SignedService = element.Element(System.Xml.Linq.XName.Get("SignedService", "")).Value;
            _value.SignedVersion = element.Element(System.Xml.Linq.XName.Get("SignedVersion", "")).Value;
            _value.Value = element.Element(System.Xml.Linq.XName.Get("Value", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.UserDelegationKey value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new UserDelegationKey instance for mocking.
        /// </summary>
        public static UserDelegationKey UserDelegationKey(
            string signedOid,
            string signedTid,
            System.DateTimeOffset signedStart,
            System.DateTimeOffset signedExpiry,
            string signedService,
            string signedVersion,
            string value)
        {
            var _model = new UserDelegationKey();
            _model.SignedOid = signedOid;
            _model.SignedTid = signedTid;
            _model.SignedStart = signedStart;
            _model.SignedExpiry = signedExpiry;
            _model.SignedService = signedService;
            _model.SignedVersion = signedVersion;
            _model.Value = value;
            return _model;
        }
    }
}
#endregion class UserDelegationKey

#region enum CopyStatus
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// CopyStatus values
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

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.CopyStatus value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.CopyStatus.Pending:
                        return "pending";
                    case Azure.Storage.Blobs.Models.CopyStatus.Success:
                        return "success";
                    case Azure.Storage.Blobs.Models.CopyStatus.Aborted:
                        return "aborted";
                    case Azure.Storage.Blobs.Models.CopyStatus.Failed:
                        return "failed";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.CopyStatus value.");
                }
            }

            public static Azure.Storage.Blobs.Models.CopyStatus ParseCopyStatus(string value)
            {
                switch (value)
                {
                    case "pending":
                        return Azure.Storage.Blobs.Models.CopyStatus.Pending;
                    case "success":
                        return Azure.Storage.Blobs.Models.CopyStatus.Success;
                    case "aborted":
                        return Azure.Storage.Blobs.Models.CopyStatus.Aborted;
                    case "failed":
                        return Azure.Storage.Blobs.Models.CopyStatus.Failed;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.CopyStatus value.");
                }
            }
        }
    }
}
#endregion enum CopyStatus

#region enum LeaseDurationType
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// LeaseDurationType values
    /// </summary>
    public enum LeaseDurationType
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

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.LeaseDurationType value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.LeaseDurationType.Infinite:
                        return "infinite";
                    case Azure.Storage.Blobs.Models.LeaseDurationType.Fixed:
                        return "fixed";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseDurationType value.");
                }
            }

            public static Azure.Storage.Blobs.Models.LeaseDurationType ParseLeaseDurationType(string value)
            {
                switch (value)
                {
                    case "infinite":
                        return Azure.Storage.Blobs.Models.LeaseDurationType.Infinite;
                    case "fixed":
                        return Azure.Storage.Blobs.Models.LeaseDurationType.Fixed;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseDurationType value.");
                }
            }
        }
    }
}
#endregion enum LeaseDurationType

#region enum LeaseState
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// LeaseState values
    /// </summary>
    public enum LeaseState
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

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.LeaseState value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.LeaseState.Available:
                        return "available";
                    case Azure.Storage.Blobs.Models.LeaseState.Leased:
                        return "leased";
                    case Azure.Storage.Blobs.Models.LeaseState.Expired:
                        return "expired";
                    case Azure.Storage.Blobs.Models.LeaseState.Breaking:
                        return "breaking";
                    case Azure.Storage.Blobs.Models.LeaseState.Broken:
                        return "broken";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseState value.");
                }
            }

            public static Azure.Storage.Blobs.Models.LeaseState ParseLeaseState(string value)
            {
                switch (value)
                {
                    case "available":
                        return Azure.Storage.Blobs.Models.LeaseState.Available;
                    case "leased":
                        return Azure.Storage.Blobs.Models.LeaseState.Leased;
                    case "expired":
                        return Azure.Storage.Blobs.Models.LeaseState.Expired;
                    case "breaking":
                        return Azure.Storage.Blobs.Models.LeaseState.Breaking;
                    case "broken":
                        return Azure.Storage.Blobs.Models.LeaseState.Broken;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseState value.");
                }
            }
        }
    }
}
#endregion enum LeaseState

#region enum LeaseStatus
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// LeaseStatus values
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum LeaseStatus
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

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.LeaseStatus value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.LeaseStatus.Locked:
                        return "locked";
                    case Azure.Storage.Blobs.Models.LeaseStatus.Unlocked:
                        return "unlocked";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseStatus value.");
                }
            }

            public static Azure.Storage.Blobs.Models.LeaseStatus ParseLeaseStatus(string value)
            {
                switch (value)
                {
                    case "locked":
                        return Azure.Storage.Blobs.Models.LeaseStatus.Locked;
                    case "unlocked":
                        return Azure.Storage.Blobs.Models.LeaseStatus.Unlocked;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.LeaseStatus value.");
                }
            }
        }
    }
}
#endregion enum LeaseStatus

#region class StorageError
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// StorageError
    /// </summary>
    internal partial class StorageError
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new StorageError instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized StorageError instance.</returns>
        internal static Azure.Storage.Blobs.Models.StorageError FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.StorageError _value = new Azure.Storage.Blobs.Models.StorageError();
            _child = element.Element(System.Xml.Linq.XName.Get("Code", ""));
            if (_child != null)
            {
                _value.Code = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Message", ""));
            if (_child != null)
            {
                _value.Message = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.StorageError value);
    }
}
#endregion class StorageError

#region enum strings ArchiveStatus
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ArchiveStatus values
    /// </summary>
    public partial struct ArchiveStatus : System.IEquatable<ArchiveStatus>
    {
        #pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// rehydrate-pending-to-hot
        /// </summary>
        public static Azure.Storage.Blobs.Models.ArchiveStatus RehydratePendingToHot = @"rehydrate-pending-to-hot";

        /// <summary>
        /// rehydrate-pending-to-cool
        /// </summary>
        public static Azure.Storage.Blobs.Models.ArchiveStatus RehydratePendingToCool = @"rehydrate-pending-to-cool";
        #pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// The ArchiveStatus value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Creates a new ArchiveStatus instance.
        /// </summary>
        /// <param name="value">The ArchiveStatus value.</param>
        private ArchiveStatus(string value) { this._value = value; }

        /// <summary>
        /// Check if two ArchiveStatus instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Blobs.Models.ArchiveStatus other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);

        /// <summary>
        /// Check if two ArchiveStatus instances are equal.
        /// </summary>
        /// <param name="o">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object o) => o is Azure.Storage.Blobs.Models.ArchiveStatus other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the ArchiveStatus.
        /// </summary>
        /// <returns>Hash code for the ArchiveStatus.</returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// Convert the ArchiveStatus to a string.
        /// </summary>
        /// <returns>String representation of the ArchiveStatus.</returns>
        public override string ToString() => this._value;

        #pragma warning disable CA2225 // Operator overloads have named alternates
        /// <summary>
        /// Convert a string a ArchiveStatus.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The ArchiveStatus value.</returns>
        public static implicit operator ArchiveStatus(string value) => new Azure.Storage.Blobs.Models.ArchiveStatus(value);
        #pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Convert an ArchiveStatus to a string.
        /// </summary>
        /// <param name="o">The ArchiveStatus value.</param>
        /// <returns>String representation of the ArchiveStatus value.</returns>
        public static implicit operator string(Azure.Storage.Blobs.Models.ArchiveStatus o) => o._value;

        /// <summary>
        /// Check if two ArchiveStatus instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(Azure.Storage.Blobs.Models.ArchiveStatus a, Azure.Storage.Blobs.Models.ArchiveStatus b) => a.Equals(b);

        /// <summary>
        /// Check if two ArchiveStatus instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(Azure.Storage.Blobs.Models.ArchiveStatus a, Azure.Storage.Blobs.Models.ArchiveStatus b) => !a.Equals(b);
    }
}
#endregion enum strings ArchiveStatus

#region enum BlobType
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobType values
    /// </summary>
    public enum BlobType
    {
        /// <summary>
        /// BlockBlob
        /// </summary>
        BlockBlob,

        /// <summary>
        /// PageBlob
        /// </summary>
        PageBlob,

        /// <summary>
        /// AppendBlob
        /// </summary>
        AppendBlob
    }
}
#endregion enum BlobType

#region class BlobItemProperties
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Properties of a blob
    /// </summary>
    public partial class BlobItemProperties
    {
        /// <summary>
        /// Creation-Time
        /// </summary>
        public System.DateTimeOffset? CreationTime { get; internal set; }

        /// <summary>
        /// Last-Modified
        /// </summary>
        public System.DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// ETag
        /// </summary>
        public Azure.Core.Http.ETag? ETag { get; internal set; }

        /// <summary>
        /// Size in bytes
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// Content-Type
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Content-Encoding
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// Content-Language
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// Content-MD5
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Content-Disposition
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// Cache-Control
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// x-ms-blob-sequence-number
        /// </summary>
        public long? BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// BlobType
        /// </summary>
        public Azure.Storage.Blobs.Models.BlobType? BlobType { get; internal set; }

        /// <summary>
        /// LeaseStatus
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// LeaseState
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// LeaseDuration
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get; internal set; }

        /// <summary>
        /// CopyId
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// CopyStatus
        /// </summary>
        public Azure.Storage.Blobs.Models.CopyStatus? CopyStatus { get; internal set; }

        /// <summary>
        /// CopySource
        /// </summary>
        public System.Uri CopySource { get; internal set; }

        /// <summary>
        /// CopyProgress
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// CopyCompletionTime
        /// </summary>
        public System.DateTimeOffset? CopyCompletionTime { get; internal set; }

        /// <summary>
        /// CopyStatusDescription
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// ServerEncrypted
        /// </summary>
        public bool? ServerEncrypted { get; internal set; }

        /// <summary>
        /// IncrementalCopy
        /// </summary>
        public bool? IncrementalCopy { get; internal set; }

        /// <summary>
        /// DestinationSnapshot
        /// </summary>
        public string DestinationSnapshot { get; internal set; }

        /// <summary>
        /// DeletedTime
        /// </summary>
        public System.DateTimeOffset? DeletedTime { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// AccessTier
        /// </summary>
        public Azure.Storage.Blobs.Models.AccessTier AccessTier { get; internal set; }

        /// <summary>
        /// AccessTierInferred
        /// </summary>
        public bool? AccessTierInferred { get; internal set; }

        /// <summary>
        /// ArchiveStatus
        /// </summary>
        public Azure.Storage.Blobs.Models.ArchiveStatus ArchiveStatus { get; internal set; }

        /// <summary>
        /// AccessTierChangeTime
        /// </summary>
        public System.DateTimeOffset? AccessTierChangeTime { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new BlobItemProperties instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobItemProperties instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobItemProperties FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobItemProperties _value = new Azure.Storage.Blobs.Models.BlobItemProperties();
            _child = element.Element(System.Xml.Linq.XName.Get("Creation-Time", ""));
            if (_child != null)
            {
                _value.CreationTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Last-Modified", ""));
            if (_child != null)
            {
                _value.LastModified = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Etag", ""));
            if (_child != null)
            {
                _value.ETag = new Azure.Core.Http.ETag(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Length", ""));
            if (_child != null)
            {
                _value.ContentLength = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Type", ""));
            if (_child != null)
            {
                _value.ContentType = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Encoding", ""));
            if (_child != null)
            {
                _value.ContentEncoding = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Language", ""));
            if (_child != null)
            {
                _value.ContentLanguage = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-MD5", ""));
            if (_child != null)
            {
                _value.ContentHash = System.Convert.FromBase64String(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Content-Disposition", ""));
            if (_child != null)
            {
                _value.ContentDisposition = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Cache-Control", ""));
            if (_child != null)
            {
                _value.CacheControl = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("x-ms-blob-sequence-number", ""));
            if (_child != null)
            {
                _value.BlobSequenceNumber = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("BlobType", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.BlobType = (Azure.Storage.Blobs.Models.BlobType)System.Enum.Parse(typeof(Azure.Storage.Blobs.Models.BlobType), _child.Value, false);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseStatus", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseState", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseDuration", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopyId", ""));
            if (_child != null)
            {
                _value.CopyId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopyStatus", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.CopyStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseCopyStatus(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopySource", ""));
            if (_child != null)
            {
                _value.CopySource = new System.Uri(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopyProgress", ""));
            if (_child != null)
            {
                _value.CopyProgress = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopyCompletionTime", ""));
            if (_child != null)
            {
                _value.CopyCompletionTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("CopyStatusDescription", ""));
            if (_child != null)
            {
                _value.CopyStatusDescription = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ServerEncrypted", ""));
            if (_child != null)
            {
                _value.ServerEncrypted = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("IncrementalCopy", ""));
            if (_child != null)
            {
                _value.IncrementalCopy = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DestinationSnapshot", ""));
            if (_child != null)
            {
                _value.DestinationSnapshot = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DeletedTime", ""));
            if (_child != null)
            {
                _value.DeletedTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RemainingRetentionDays", ""));
            if (_child != null)
            {
                _value.RemainingRetentionDays = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTier", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.AccessTier = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTierInferred", ""));
            if (_child != null)
            {
                _value.AccessTierInferred = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ArchiveStatus", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.ArchiveStatus = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessTierChangeTime", ""));
            if (_child != null)
            {
                _value.AccessTierChangeTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobItemProperties value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobItemProperties instance for mocking.
        /// </summary>
        public static BlobItemProperties BlobItemProperties(
            string copyId = default,
            System.DateTimeOffset? creationTime = default,
            Azure.Core.Http.ETag? eTag = default,
            long? contentLength = default,
            string contentType = default,
            string contentEncoding = default,
            string contentLanguage = default,
            byte[] contentHash = default,
            string contentDisposition = default,
            string cacheControl = default,
            long? blobSequenceNumber = default,
            Azure.Storage.Blobs.Models.BlobType? blobType = default,
            Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default,
            Azure.Storage.Blobs.Models.LeaseState? leaseState = default,
            Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default,
            System.DateTimeOffset? lastModified = default,
            Azure.Storage.Blobs.Models.CopyStatus? copyStatus = default,
            System.Uri copySource = default,
            string copyProgress = default,
            System.DateTimeOffset? copyCompletionTime = default,
            string copyStatusDescription = default,
            bool? serverEncrypted = default,
            bool? incrementalCopy = default,
            string destinationSnapshot = default,
            System.DateTimeOffset? deletedTime = default,
            int? remainingRetentionDays = default,
            Azure.Storage.Blobs.Models.AccessTier accessTier = default,
            bool? accessTierInferred = default,
            Azure.Storage.Blobs.Models.ArchiveStatus archiveStatus = default,
            System.DateTimeOffset? accessTierChangeTime = default)
        {
            var _model = new BlobItemProperties();
            _model.CopyId = copyId;
            _model.CreationTime = creationTime;
            _model.ETag = eTag;
            _model.ContentLength = contentLength;
            _model.ContentType = contentType;
            _model.ContentEncoding = contentEncoding;
            _model.ContentLanguage = contentLanguage;
            _model.ContentHash = contentHash;
            _model.ContentDisposition = contentDisposition;
            _model.CacheControl = cacheControl;
            _model.BlobSequenceNumber = blobSequenceNumber;
            _model.BlobType = blobType;
            _model.LeaseStatus = leaseStatus;
            _model.LeaseState = leaseState;
            _model.LeaseDuration = leaseDuration;
            _model.LastModified = lastModified;
            _model.CopyStatus = copyStatus;
            _model.CopySource = copySource;
            _model.CopyProgress = copyProgress;
            _model.CopyCompletionTime = copyCompletionTime;
            _model.CopyStatusDescription = copyStatusDescription;
            _model.ServerEncrypted = serverEncrypted;
            _model.IncrementalCopy = incrementalCopy;
            _model.DestinationSnapshot = destinationSnapshot;
            _model.DeletedTime = deletedTime;
            _model.RemainingRetentionDays = remainingRetentionDays;
            _model.AccessTier = accessTier;
            _model.AccessTierInferred = accessTierInferred;
            _model.ArchiveStatus = archiveStatus;
            _model.AccessTierChangeTime = accessTierChangeTime;
            return _model;
        }
    }
}
#endregion class BlobItemProperties

#region class BlobItem
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An Azure Storage blob
    /// </summary>
    public partial class BlobItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Deleted
        /// </summary>
        public bool? Deleted { get; internal set; }

        /// <summary>
        /// Snapshot
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// Properties of a blob
        /// </summary>
        public Azure.Storage.Blobs.Models.BlobItemProperties Properties { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Creates a new BlobItem instance
        /// </summary>
        public BlobItem()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobItem instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobItem(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.Properties = new Azure.Storage.Blobs.Models.BlobItemProperties();
                this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Deserializes XML into a new BlobItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobItem instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobItem _value = new Azure.Storage.Blobs.Models.BlobItem(true);
            _value.Name = element.Element(System.Xml.Linq.XName.Get("Name", "")).Value;
            _child = element.Element(System.Xml.Linq.XName.Get("Deleted", ""));
            if (_child != null)
            {
                _value.Deleted = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Snapshot", ""));
            if (_child != null)
            {
                _value.Snapshot = _child.Value;
            }
            _value.Properties = Azure.Storage.Blobs.Models.BlobItemProperties.FromXml(element.Element(System.Xml.Linq.XName.Get("Properties", "")));
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobItem value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobItem instance for mocking.
        /// </summary>
        public static BlobItem BlobItem(
            string name,
            Azure.Storage.Blobs.Models.BlobItemProperties properties,
            bool? deleted = default,
            string snapshot = default,
            System.Collections.Generic.IDictionary<string, string> metadata = default)
        {
            var _model = new BlobItem();
            _model.Name = name;
            _model.Properties = properties;
            _model.Deleted = deleted;
            _model.Snapshot = snapshot;
            _model.Metadata = metadata;
            return _model;
        }
    }
}
#endregion class BlobItem

#region class BlobsFlatSegment
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An enumeration of blobs
    /// </summary>
    internal partial class BlobsFlatSegment
    {
        /// <summary>
        /// ServiceEndpoint
        /// </summary>
        public string ServiceEndpoint { get; internal set; }

        /// <summary>
        /// ContainerName
        /// </summary>
        public string ContainerName { get; internal set; }

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
        /// Delimiter
        /// </summary>
        public string Delimiter { get; internal set; }

        /// <summary>
        /// BlobItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobItem> BlobItems { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Creates a new BlobsFlatSegment instance
        /// </summary>
        public BlobsFlatSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobsFlatSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobsFlatSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.BlobItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobItem>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new BlobsFlatSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobsFlatSegment instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobsFlatSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobsFlatSegment _value = new Azure.Storage.Blobs.Models.BlobsFlatSegment(true);
            _value.ServiceEndpoint = element.Attribute(System.Xml.Linq.XName.Get("ServiceEndpoint", "")).Value;
            _value.ContainerName = element.Attribute(System.Xml.Linq.XName.Get("ContainerName", "")).Value;
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
            _child = element.Element(System.Xml.Linq.XName.Get("Delimiter", ""));
            if (_child != null)
            {
                _value.Delimiter = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Blobs", ""));
            if (_child != null)
            {
                _value.BlobItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Blob", "")),
                        e => Azure.Storage.Blobs.Models.BlobItem.FromXml(e)));
            }
            else
            {
                _value.BlobItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobItem>();
            }
            _value.NextMarker = element.Element(System.Xml.Linq.XName.Get("NextMarker", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobsFlatSegment value);
    }
}
#endregion class BlobsFlatSegment

#region class BlobPrefix
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobPrefix
    /// </summary>
    internal partial class BlobPrefix
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new BlobPrefix instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobPrefix instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobPrefix FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.BlobPrefix _value = new Azure.Storage.Blobs.Models.BlobPrefix();
            _value.Name = element.Element(System.Xml.Linq.XName.Get("Name", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobPrefix value);
    }
}
#endregion class BlobPrefix

#region class BlobsHierarchySegment
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An enumeration of blobs
    /// </summary>
    internal partial class BlobsHierarchySegment
    {
        /// <summary>
        /// ServiceEndpoint
        /// </summary>
        public string ServiceEndpoint { get; internal set; }

        /// <summary>
        /// ContainerName
        /// </summary>
        public string ContainerName { get; internal set; }

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
        /// Delimiter
        /// </summary>
        public string Delimiter { get; internal set; }

        /// <summary>
        /// BlobItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobItem> BlobItems { get; internal set; }

        /// <summary>
        /// BlobPrefixes
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobPrefix> BlobPrefixes { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Creates a new BlobsHierarchySegment instance
        /// </summary>
        public BlobsHierarchySegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobsHierarchySegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobsHierarchySegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.BlobItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobItem>();
                this.BlobPrefixes = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobPrefix>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new BlobsHierarchySegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobsHierarchySegment instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobsHierarchySegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobsHierarchySegment _value = new Azure.Storage.Blobs.Models.BlobsHierarchySegment(true);
            _value.ServiceEndpoint = element.Attribute(System.Xml.Linq.XName.Get("ServiceEndpoint", "")).Value;
            _value.ContainerName = element.Attribute(System.Xml.Linq.XName.Get("ContainerName", "")).Value;
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
            _child = element.Element(System.Xml.Linq.XName.Get("Delimiter", ""));
            if (_child != null)
            {
                _value.Delimiter = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Blobs", ""));
            if (_child != null)
            {
                _value.BlobItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Blob", "")),
                        e => Azure.Storage.Blobs.Models.BlobItem.FromXml(e)));
            }
            else
            {
                _value.BlobItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobItem>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Blobs", ""));
            if (_child != null)
            {
                _value.BlobPrefixes = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("BlobPrefix", "")),
                        e => Azure.Storage.Blobs.Models.BlobPrefix.FromXml(e)));
            }
            else
            {
                _value.BlobPrefixes = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.BlobPrefix>();
            }
            _value.NextMarker = element.Element(System.Xml.Linq.XName.Get("NextMarker", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobsHierarchySegment value);
    }
}
#endregion class BlobsHierarchySegment

#region class Block
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Represents a single block in a block blob.  It describes the block's ID and size.
    /// </summary>
    public partial class Block
    {
        /// <summary>
        /// The base64 encoded block ID.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The block size in bytes.
        /// </summary>
        public int Size { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new Block instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Block instance.</returns>
        internal static Azure.Storage.Blobs.Models.Block FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.Block _value = new Azure.Storage.Blobs.Models.Block();
            _value.Name = element.Element(System.Xml.Linq.XName.Get("Name", "")).Value;
            _value.Size = int.Parse(element.Element(System.Xml.Linq.XName.Get("Size", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.Block value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new Block instance for mocking.
        /// </summary>
        public static Block Block(
            string name,
            int size)
        {
            var _model = new Block();
            _model.Name = name;
            _model.Size = size;
            return _model;
        }
    }
}
#endregion class Block

#region class BlockList
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlockList
    /// </summary>
    public partial class BlockList
    {
        /// <summary>
        /// CommittedBlocks
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.Block> CommittedBlocks { get; internal set; }

        /// <summary>
        /// UncommittedBlocks
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.Block> UncommittedBlocks { get; internal set; }

        /// <summary>
        /// Creates a new BlockList instance
        /// </summary>
        public BlockList()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlockList instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlockList(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.CommittedBlocks = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.Block>();
                this.UncommittedBlocks = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.Block>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new BlockList instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlockList instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlockList FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlockList _value = new Azure.Storage.Blobs.Models.BlockList(true);
            _child = element.Element(System.Xml.Linq.XName.Get("CommittedBlocks", ""));
            if (_child != null)
            {
                _value.CommittedBlocks = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Block", "")),
                        e => Azure.Storage.Blobs.Models.Block.FromXml(e)));
            }
            else
            {
                _value.CommittedBlocks = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.Block>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("UncommittedBlocks", ""));
            if (_child != null)
            {
                _value.UncommittedBlocks = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Block", "")),
                        e => Azure.Storage.Blobs.Models.Block.FromXml(e)));
            }
            else
            {
                _value.UncommittedBlocks = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.Block>();
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlockList value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlockList instance for mocking.
        /// </summary>
        public static BlockList BlockList(
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.Block> committedBlocks = default,
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.Block> uncommittedBlocks = default)
        {
            var _model = new BlockList();
            _model.CommittedBlocks = committedBlocks;
            _model.UncommittedBlocks = uncommittedBlocks;
            return _model;
        }
    }
}
#endregion class BlockList

#region class BlockLookupList
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A list of block IDs split between the committed block list, in the uncommitted block list, or in the uncommitted block list first and then in the committed block list.
    /// </summary>
    internal partial class BlockLookupList
    {
        /// <summary>
        /// Committed
        /// </summary>
        public System.Collections.Generic.IList<string> Committed { get; internal set; }

        /// <summary>
        /// Uncommitted
        /// </summary>
        public System.Collections.Generic.IList<string> Uncommitted { get; internal set; }

        /// <summary>
        /// Latest
        /// </summary>
        public System.Collections.Generic.IList<string> Latest { get; internal set; }

        /// <summary>
        /// Creates a new BlockLookupList instance
        /// </summary>
        public BlockLookupList()
        {
            this.Committed = new System.Collections.Generic.List<string>();
            this.Uncommitted = new System.Collections.Generic.List<string>();
            this.Latest = new System.Collections.Generic.List<string>();
        }

        /// <summary>
        /// Serialize a BlockLookupList instance as XML.
        /// </summary>
        /// <param name="value">The BlockLookupList instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "BlockList".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Blobs.Models.BlockLookupList value, string name = "BlockList", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Committed != null)
            {
                foreach (string _child in value.Committed)
                {
                    _element.Add(new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Committed", ""), _child));
                }
            }
            if (value.Uncommitted != null)
            {
                foreach (string _child in value.Uncommitted)
                {
                    _element.Add(new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Uncommitted", ""), _child));
                }
            }
            if (value.Latest != null)
            {
                foreach (string _child in value.Latest)
                {
                    _element.Add(new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Latest", ""), _child));
                }
            }
            return _element;
        }
    }
}
#endregion class BlockLookupList

#region class ContainerProperties
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Properties of a container
    /// </summary>
    public partial class ContainerProperties
    {
        /// <summary>
        /// Last-Modified
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// ETag
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// LeaseStatus
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// LeaseState
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// LeaseDuration
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get; internal set; }

        /// <summary>
        /// PublicAccess
        /// </summary>
        public Azure.Storage.Blobs.Models.PublicAccessType? PublicAccess { get; internal set; }

        /// <summary>
        /// HasImmutabilityPolicy
        /// </summary>
        public bool? HasImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// HasLegalHold
        /// </summary>
        public bool? HasLegalHold { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new ContainerProperties instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ContainerProperties instance.</returns>
        internal static Azure.Storage.Blobs.Models.ContainerProperties FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.ContainerProperties _value = new Azure.Storage.Blobs.Models.ContainerProperties();
            _value.LastModified = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("Last-Modified", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.ETag = new Azure.Core.Http.ETag(element.Element(System.Xml.Linq.XName.Get("Etag", "")).Value);
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseStatus", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseStatus = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseStatus(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseState", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseState = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseState(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LeaseDuration", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.LeaseDuration = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseLeaseDurationType(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("PublicAccess", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.PublicAccess = Azure.Storage.Blobs.BlobRestClient.Serialization.ParsePublicAccessType(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("HasImmutabilityPolicy", ""));
            if (_child != null)
            {
                _value.HasImmutabilityPolicy = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("HasLegalHold", ""));
            if (_child != null)
            {
                _value.HasLegalHold = bool.Parse(_child.Value);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.ContainerProperties value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new ContainerProperties instance for mocking.
        /// </summary>
        public static ContainerProperties ContainerProperties(
            System.DateTimeOffset lastModified,
            Azure.Core.Http.ETag eTag,
            Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default,
            Azure.Storage.Blobs.Models.LeaseState? leaseState = default,
            Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default,
            Azure.Storage.Blobs.Models.PublicAccessType? publicAccess = default,
            bool? hasImmutabilityPolicy = default,
            bool? hasLegalHold = default)
        {
            var _model = new ContainerProperties();
            _model.LastModified = lastModified;
            _model.ETag = eTag;
            _model.LeaseStatus = leaseStatus;
            _model.LeaseState = leaseState;
            _model.LeaseDuration = leaseDuration;
            _model.PublicAccess = publicAccess;
            _model.HasImmutabilityPolicy = hasImmutabilityPolicy;
            _model.HasLegalHold = hasLegalHold;
            return _model;
        }
    }
}
#endregion class ContainerProperties

#region class ContainerItem
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An Azure Storage container
    /// </summary>
    public partial class ContainerItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Properties of a container
        /// </summary>
        public Azure.Storage.Blobs.Models.ContainerProperties Properties { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Creates a new ContainerItem instance
        /// </summary>
        public ContainerItem()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ContainerItem instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ContainerItem(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.Properties = new Azure.Storage.Blobs.Models.ContainerProperties();
                this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Deserializes XML into a new ContainerItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ContainerItem instance.</returns>
        internal static Azure.Storage.Blobs.Models.ContainerItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.ContainerItem _value = new Azure.Storage.Blobs.Models.ContainerItem(true);
            _value.Name = element.Element(System.Xml.Linq.XName.Get("Name", "")).Value;
            _value.Properties = Azure.Storage.Blobs.Models.ContainerProperties.FromXml(element.Element(System.Xml.Linq.XName.Get("Properties", "")));
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.ContainerItem value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new ContainerItem instance for mocking.
        /// </summary>
        public static ContainerItem ContainerItem(
            string name,
            Azure.Storage.Blobs.Models.ContainerProperties properties,
            System.Collections.Generic.IDictionary<string, string> metadata = default)
        {
            var _model = new ContainerItem();
            _model.Name = name;
            _model.Properties = properties;
            _model.Metadata = metadata;
            return _model;
        }
    }
}
#endregion class ContainerItem

#region class ContainersSegment
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An enumeration of containers
    /// </summary>
    internal partial class ContainersSegment
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
        /// ContainerItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ContainerItem> ContainerItems { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Creates a new ContainersSegment instance
        /// </summary>
        public ContainersSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ContainersSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ContainersSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.ContainerItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.ContainerItem>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new ContainersSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ContainersSegment instance.</returns>
        internal static Azure.Storage.Blobs.Models.ContainersSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.ContainersSegment _value = new Azure.Storage.Blobs.Models.ContainersSegment(true);
            _value.ServiceEndpoint = element.Attribute(System.Xml.Linq.XName.Get("ServiceEndpoint", "")).Value;
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
            _child = element.Element(System.Xml.Linq.XName.Get("Containers", ""));
            if (_child != null)
            {
                _value.ContainerItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Container", "")),
                        e => Azure.Storage.Blobs.Models.ContainerItem.FromXml(e)));
            }
            else
            {
                _value.ContainerItems = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.ContainerItem>();
            }
            _value.NextMarker = element.Element(System.Xml.Linq.XName.Get("NextMarker", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.ContainersSegment value);
    }
}
#endregion class ContainersSegment

#region enum strings BlobErrorCode
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Error codes returned by the service
    /// </summary>
    public partial struct BlobErrorCode : System.IEquatable<BlobErrorCode>
    {
        #pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// AccountAlreadyExists
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountAlreadyExists = @"AccountAlreadyExists";

        /// <summary>
        /// AccountBeingCreated
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountBeingCreated = @"AccountBeingCreated";

        /// <summary>
        /// AccountIsDisabled
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountIsDisabled = @"AccountIsDisabled";

        /// <summary>
        /// AuthenticationFailed
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthenticationFailed = @"AuthenticationFailed";

        /// <summary>
        /// AuthorizationFailure
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationFailure = @"AuthorizationFailure";

        /// <summary>
        /// ConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ConditionHeadersNotSupported = @"ConditionHeadersNotSupported";

        /// <summary>
        /// ConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ConditionNotMet = @"ConditionNotMet";

        /// <summary>
        /// EmptyMetadataKey
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode EmptyMetadataKey = @"EmptyMetadataKey";

        /// <summary>
        /// InsufficientAccountPermissions
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InsufficientAccountPermissions = @"InsufficientAccountPermissions";

        /// <summary>
        /// InternalError
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InternalError = @"InternalError";

        /// <summary>
        /// InvalidAuthenticationInfo
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidAuthenticationInfo = @"InvalidAuthenticationInfo";

        /// <summary>
        /// InvalidHeaderValue
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidHeaderValue = @"InvalidHeaderValue";

        /// <summary>
        /// InvalidHttpVerb
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidHttpVerb = @"InvalidHttpVerb";

        /// <summary>
        /// InvalidInput
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidInput = @"InvalidInput";

        /// <summary>
        /// InvalidMd5
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidMd5 = @"InvalidMd5";

        /// <summary>
        /// InvalidMetadata
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidMetadata = @"InvalidMetadata";

        /// <summary>
        /// InvalidQueryParameterValue
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidQueryParameterValue = @"InvalidQueryParameterValue";

        /// <summary>
        /// InvalidRange
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidRange = @"InvalidRange";

        /// <summary>
        /// InvalidResourceName
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidResourceName = @"InvalidResourceName";

        /// <summary>
        /// InvalidUri
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidUri = @"InvalidUri";

        /// <summary>
        /// InvalidXmlDocument
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidXmlDocument = @"InvalidXmlDocument";

        /// <summary>
        /// InvalidXmlNodeValue
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidXmlNodeValue = @"InvalidXmlNodeValue";

        /// <summary>
        /// Md5Mismatch
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode Md5Mismatch = @"Md5Mismatch";

        /// <summary>
        /// MetadataTooLarge
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MetadataTooLarge = @"MetadataTooLarge";

        /// <summary>
        /// MissingContentLengthHeader
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingContentLengthHeader = @"MissingContentLengthHeader";

        /// <summary>
        /// MissingRequiredQueryParameter
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredQueryParameter = @"MissingRequiredQueryParameter";

        /// <summary>
        /// MissingRequiredHeader
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredHeader = @"MissingRequiredHeader";

        /// <summary>
        /// MissingRequiredXmlNode
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredXmlNode = @"MissingRequiredXmlNode";

        /// <summary>
        /// MultipleConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MultipleConditionHeadersNotSupported = @"MultipleConditionHeadersNotSupported";

        /// <summary>
        /// OperationTimedOut
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode OperationTimedOut = @"OperationTimedOut";

        /// <summary>
        /// OutOfRangeInput
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode OutOfRangeInput = @"OutOfRangeInput";

        /// <summary>
        /// OutOfRangeQueryParameterValue
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode OutOfRangeQueryParameterValue = @"OutOfRangeQueryParameterValue";

        /// <summary>
        /// RequestBodyTooLarge
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode RequestBodyTooLarge = @"RequestBodyTooLarge";

        /// <summary>
        /// ResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceTypeMismatch = @"ResourceTypeMismatch";

        /// <summary>
        /// RequestUrlFailedToParse
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode RequestUrlFailedToParse = @"RequestUrlFailedToParse";

        /// <summary>
        /// ResourceAlreadyExists
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceAlreadyExists = @"ResourceAlreadyExists";

        /// <summary>
        /// ResourceNotFound
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceNotFound = @"ResourceNotFound";

        /// <summary>
        /// ServerBusy
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ServerBusy = @"ServerBusy";

        /// <summary>
        /// UnsupportedHeader
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedHeader = @"UnsupportedHeader";

        /// <summary>
        /// UnsupportedXmlNode
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedXmlNode = @"UnsupportedXmlNode";

        /// <summary>
        /// UnsupportedQueryParameter
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedQueryParameter = @"UnsupportedQueryParameter";

        /// <summary>
        /// UnsupportedHttpVerb
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedHttpVerb = @"UnsupportedHttpVerb";

        /// <summary>
        /// AppendPositionConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode AppendPositionConditionNotMet = @"AppendPositionConditionNotMet";

        /// <summary>
        /// BlobAlreadyExists
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobAlreadyExists = @"BlobAlreadyExists";

        /// <summary>
        /// BlobNotFound
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotFound = @"BlobNotFound";

        /// <summary>
        /// BlobOverwritten
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobOverwritten = @"BlobOverwritten";

        /// <summary>
        /// BlobTierInadequateForContentLength
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobTierInadequateForContentLength = @"BlobTierInadequateForContentLength";

        /// <summary>
        /// BlockCountExceedsLimit
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlockCountExceedsLimit = @"BlockCountExceedsLimit";

        /// <summary>
        /// BlockListTooLong
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlockListTooLong = @"BlockListTooLong";

        /// <summary>
        /// CannotChangeToLowerTier
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode CannotChangeToLowerTier = @"CannotChangeToLowerTier";

        /// <summary>
        /// CannotVerifyCopySource
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode CannotVerifyCopySource = @"CannotVerifyCopySource";

        /// <summary>
        /// ContainerAlreadyExists
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerAlreadyExists = @"ContainerAlreadyExists";

        /// <summary>
        /// ContainerBeingDeleted
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerBeingDeleted = @"ContainerBeingDeleted";

        /// <summary>
        /// ContainerDisabled
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerDisabled = @"ContainerDisabled";

        /// <summary>
        /// ContainerNotFound
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerNotFound = @"ContainerNotFound";

        /// <summary>
        /// ContentLengthLargerThanTierLimit
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContentLengthLargerThanTierLimit = @"ContentLengthLargerThanTierLimit";

        /// <summary>
        /// CopyAcrossAccountsNotSupported
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode CopyAcrossAccountsNotSupported = @"CopyAcrossAccountsNotSupported";

        /// <summary>
        /// CopyIdMismatch
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode CopyIdMismatch = @"CopyIdMismatch";

        /// <summary>
        /// FeatureVersionMismatch
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode FeatureVersionMismatch = @"FeatureVersionMismatch";

        /// <summary>
        /// IncrementalCopyBlobMismatch
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopyBlobMismatch = @"IncrementalCopyBlobMismatch";

        /// <summary>
        /// IncrementalCopyOfEralierVersionSnapshotNotAllowed
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopyOfEralierVersionSnapshotNotAllowed = @"IncrementalCopyOfEralierVersionSnapshotNotAllowed";

        /// <summary>
        /// IncrementalCopySourceMustBeSnapshot
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopySourceMustBeSnapshot = @"IncrementalCopySourceMustBeSnapshot";

        /// <summary>
        /// InfiniteLeaseDurationRequired
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InfiniteLeaseDurationRequired = @"InfiniteLeaseDurationRequired";

        /// <summary>
        /// InvalidBlobOrBlock
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobOrBlock = @"InvalidBlobOrBlock";

        /// <summary>
        /// InvalidBlobTier
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobTier = @"InvalidBlobTier";

        /// <summary>
        /// InvalidBlobType
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobType = @"InvalidBlobType";

        /// <summary>
        /// InvalidBlockId
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlockId = @"InvalidBlockId";

        /// <summary>
        /// InvalidBlockList
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlockList = @"InvalidBlockList";

        /// <summary>
        /// InvalidOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidOperation = @"InvalidOperation";

        /// <summary>
        /// InvalidPageRange
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidPageRange = @"InvalidPageRange";

        /// <summary>
        /// InvalidSourceBlobType
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidSourceBlobType = @"InvalidSourceBlobType";

        /// <summary>
        /// InvalidSourceBlobUrl
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidSourceBlobUrl = @"InvalidSourceBlobUrl";

        /// <summary>
        /// InvalidVersionForPageBlobOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidVersionForPageBlobOperation = @"InvalidVersionForPageBlobOperation";

        /// <summary>
        /// LeaseAlreadyPresent
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseAlreadyPresent = @"LeaseAlreadyPresent";

        /// <summary>
        /// LeaseAlreadyBroken
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseAlreadyBroken = @"LeaseAlreadyBroken";

        /// <summary>
        /// LeaseIdMismatchWithBlobOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithBlobOperation = @"LeaseIdMismatchWithBlobOperation";

        /// <summary>
        /// LeaseIdMismatchWithContainerOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithContainerOperation = @"LeaseIdMismatchWithContainerOperation";

        /// <summary>
        /// LeaseIdMismatchWithLeaseOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithLeaseOperation = @"LeaseIdMismatchWithLeaseOperation";

        /// <summary>
        /// LeaseIdMissing
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMissing = @"LeaseIdMissing";

        /// <summary>
        /// LeaseIsBreakingAndCannotBeAcquired
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBreakingAndCannotBeAcquired = @"LeaseIsBreakingAndCannotBeAcquired";

        /// <summary>
        /// LeaseIsBreakingAndCannotBeChanged
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBreakingAndCannotBeChanged = @"LeaseIsBreakingAndCannotBeChanged";

        /// <summary>
        /// LeaseIsBrokenAndCannotBeRenewed
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBrokenAndCannotBeRenewed = @"LeaseIsBrokenAndCannotBeRenewed";

        /// <summary>
        /// LeaseLost
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseLost = @"LeaseLost";

        /// <summary>
        /// LeaseNotPresentWithBlobOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithBlobOperation = @"LeaseNotPresentWithBlobOperation";

        /// <summary>
        /// LeaseNotPresentWithContainerOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithContainerOperation = @"LeaseNotPresentWithContainerOperation";

        /// <summary>
        /// LeaseNotPresentWithLeaseOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithLeaseOperation = @"LeaseNotPresentWithLeaseOperation";

        /// <summary>
        /// MaxBlobSizeConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode MaxBlobSizeConditionNotMet = @"MaxBlobSizeConditionNotMet";

        /// <summary>
        /// NoPendingCopyOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode NoPendingCopyOperation = @"NoPendingCopyOperation";

        /// <summary>
        /// OperationNotAllowedOnIncrementalCopyBlob
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode OperationNotAllowedOnIncrementalCopyBlob = @"OperationNotAllowedOnIncrementalCopyBlob";

        /// <summary>
        /// PendingCopyOperation
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode PendingCopyOperation = @"PendingCopyOperation";

        /// <summary>
        /// PreviousSnapshotCannotBeNewer
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotCannotBeNewer = @"PreviousSnapshotCannotBeNewer";

        /// <summary>
        /// PreviousSnapshotNotFound
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotNotFound = @"PreviousSnapshotNotFound";

        /// <summary>
        /// PreviousSnapshotOperationNotSupported
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotOperationNotSupported = @"PreviousSnapshotOperationNotSupported";

        /// <summary>
        /// SequenceNumberConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SequenceNumberConditionNotMet = @"SequenceNumberConditionNotMet";

        /// <summary>
        /// SequenceNumberIncrementTooLarge
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SequenceNumberIncrementTooLarge = @"SequenceNumberIncrementTooLarge";

        /// <summary>
        /// SnapshotCountExceeded
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotCountExceeded = @"SnapshotCountExceeded";

        /// <summary>
        /// SnaphotOperationRateExceeded
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnaphotOperationRateExceeded = @"SnaphotOperationRateExceeded";

        /// <summary>
        /// SnapshotsPresent
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotsPresent = @"SnapshotsPresent";

        /// <summary>
        /// SourceConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SourceConditionNotMet = @"SourceConditionNotMet";

        /// <summary>
        /// SystemInUse
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode SystemInUse = @"SystemInUse";

        /// <summary>
        /// TargetConditionNotMet
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode TargetConditionNotMet = @"TargetConditionNotMet";

        /// <summary>
        /// UnauthorizedBlobOverwrite
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnauthorizedBlobOverwrite = @"UnauthorizedBlobOverwrite";

        /// <summary>
        /// BlobBeingRehydrated
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobBeingRehydrated = @"BlobBeingRehydrated";

        /// <summary>
        /// BlobArchived
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobArchived = @"BlobArchived";

        /// <summary>
        /// BlobNotArchived
        /// </summary>
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotArchived = @"BlobNotArchived";
        #pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// The BlobErrorCode value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Creates a new BlobErrorCode instance.
        /// </summary>
        /// <param name="value">The BlobErrorCode value.</param>
        private BlobErrorCode(string value) { this._value = value; }

        /// <summary>
        /// Check if two BlobErrorCode instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Blobs.Models.BlobErrorCode other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);

        /// <summary>
        /// Check if two BlobErrorCode instances are equal.
        /// </summary>
        /// <param name="o">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object o) => o is Azure.Storage.Blobs.Models.BlobErrorCode other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobErrorCode.
        /// </summary>
        /// <returns>Hash code for the BlobErrorCode.</returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// Convert the BlobErrorCode to a string.
        /// </summary>
        /// <returns>String representation of the BlobErrorCode.</returns>
        public override string ToString() => this._value;

        #pragma warning disable CA2225 // Operator overloads have named alternates
        /// <summary>
        /// Convert a string a BlobErrorCode.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The BlobErrorCode value.</returns>
        public static implicit operator BlobErrorCode(string value) => new Azure.Storage.Blobs.Models.BlobErrorCode(value);
        #pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Convert an BlobErrorCode to a string.
        /// </summary>
        /// <param name="o">The BlobErrorCode value.</param>
        /// <returns>String representation of the BlobErrorCode value.</returns>
        public static implicit operator string(Azure.Storage.Blobs.Models.BlobErrorCode o) => o._value;

        /// <summary>
        /// Check if two BlobErrorCode instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(Azure.Storage.Blobs.Models.BlobErrorCode a, Azure.Storage.Blobs.Models.BlobErrorCode b) => a.Equals(b);

        /// <summary>
        /// Check if two BlobErrorCode instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(Azure.Storage.Blobs.Models.BlobErrorCode a, Azure.Storage.Blobs.Models.BlobErrorCode b) => !a.Equals(b);
    }
}
#endregion enum strings BlobErrorCode

#region enum GeoReplicationStatus
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The status of the secondary location
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum GeoReplicationStatus
    #pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// live
        /// </summary>
        Live,

        /// <summary>
        /// bootstrap
        /// </summary>
        Bootstrap,

        /// <summary>
        /// unavailable
        /// </summary>
        Unavailable
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.GeoReplicationStatus value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.GeoReplicationStatus.Live:
                        return "live";
                    case Azure.Storage.Blobs.Models.GeoReplicationStatus.Bootstrap:
                        return "bootstrap";
                    case Azure.Storage.Blobs.Models.GeoReplicationStatus.Unavailable:
                        return "unavailable";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.GeoReplicationStatus value.");
                }
            }

            public static Azure.Storage.Blobs.Models.GeoReplicationStatus ParseGeoReplicationStatus(string value)
            {
                switch (value)
                {
                    case "live":
                        return Azure.Storage.Blobs.Models.GeoReplicationStatus.Live;
                    case "bootstrap":
                        return Azure.Storage.Blobs.Models.GeoReplicationStatus.Bootstrap;
                    case "unavailable":
                        return Azure.Storage.Blobs.Models.GeoReplicationStatus.Unavailable;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.GeoReplicationStatus value.");
                }
            }
        }
    }
}
#endregion enum GeoReplicationStatus

#region class GeoReplication
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Geo-Replication information for the Secondary Storage Service
    /// </summary>
    public partial class GeoReplication
    {
        /// <summary>
        /// The status of the secondary location
        /// </summary>
        public Azure.Storage.Blobs.Models.GeoReplicationStatus Status { get; internal set; }

        /// <summary>
        /// A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads.
        /// </summary>
        public System.DateTimeOffset LastSyncTime { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new GeoReplication instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized GeoReplication instance.</returns>
        internal static Azure.Storage.Blobs.Models.GeoReplication FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.GeoReplication _value = new Azure.Storage.Blobs.Models.GeoReplication();
            _value.Status = Azure.Storage.Blobs.BlobRestClient.Serialization.ParseGeoReplicationStatus(element.Element(System.Xml.Linq.XName.Get("Status", "")).Value);
            _value.LastSyncTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("LastSyncTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.GeoReplication value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new GeoReplication instance for mocking.
        /// </summary>
        public static GeoReplication GeoReplication(
            Azure.Storage.Blobs.Models.GeoReplicationStatus status,
            System.DateTimeOffset lastSyncTime)
        {
            var _model = new GeoReplication();
            _model.Status = status;
            _model.LastSyncTime = lastSyncTime;
            return _model;
        }
    }
}
#endregion class GeoReplication

#region class PageRange
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// PageRange
    /// </summary>
    public partial class PageRange
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
        /// Deserializes XML into a new PageRange instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized PageRange instance.</returns>
        internal static Azure.Storage.Blobs.Models.PageRange FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.PageRange _value = new Azure.Storage.Blobs.Models.PageRange();
            _value.Start = long.Parse(element.Element(System.Xml.Linq.XName.Get("Start", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.End = long.Parse(element.Element(System.Xml.Linq.XName.Get("End", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.PageRange value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageRange instance for mocking.
        /// </summary>
        public static PageRange PageRange(
            long start,
            long end)
        {
            var _model = new PageRange();
            _model.Start = start;
            _model.End = end;
            return _model;
        }
    }
}
#endregion class PageRange

#region class ClearRange
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ClearRange
    /// </summary>
    public partial class ClearRange
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
        /// Deserializes XML into a new ClearRange instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized ClearRange instance.</returns>
        internal static Azure.Storage.Blobs.Models.ClearRange FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.ClearRange _value = new Azure.Storage.Blobs.Models.ClearRange();
            _value.Start = long.Parse(element.Element(System.Xml.Linq.XName.Get("Start", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.End = long.Parse(element.Element(System.Xml.Linq.XName.Get("End", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.ClearRange value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new ClearRange instance for mocking.
        /// </summary>
        public static ClearRange ClearRange(
            long start,
            long end)
        {
            var _model = new ClearRange();
            _model.Start = start;
            _model.End = end;
            return _model;
        }
    }
}
#endregion class ClearRange

#region class PageList
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// the list of pages
    /// </summary>
    public partial class PageList
    {
        /// <summary>
        /// PageRange
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.PageRange> PageRange { get; internal set; }

        /// <summary>
        /// ClearRange
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ClearRange> ClearRange { get; internal set; }

        /// <summary>
        /// Creates a new PageList instance
        /// </summary>
        public PageList()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new PageList instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal PageList(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.PageRange = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.PageRange>();
                this.ClearRange = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.ClearRange>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new PageList instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized PageList instance.</returns>
        internal static Azure.Storage.Blobs.Models.PageList FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Blobs.Models.PageList _value = new Azure.Storage.Blobs.Models.PageList(true);
            _value.PageRange = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("PageRange", "")),
                    e => Azure.Storage.Blobs.Models.PageRange.FromXml(e)));
            _value.ClearRange = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Select(
                    element.Elements(System.Xml.Linq.XName.Get("ClearRange", "")),
                    e => Azure.Storage.Blobs.Models.ClearRange.FromXml(e)));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.PageList value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageList instance for mocking.
        /// </summary>
        public static PageList PageList(
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.PageRange> pageRange = default,
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.ClearRange> clearRange = default)
        {
            var _model = new PageList();
            _model.PageRange = pageRange;
            _model.ClearRange = clearRange;
            return _model;
        }
    }
}
#endregion class PageList

#region class BlobServiceStatistics
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Statistics for the storage service.
    /// </summary>
    public partial class BlobServiceStatistics
    {
        /// <summary>
        /// Geo-Replication information for the Secondary Storage Service
        /// </summary>
        public Azure.Storage.Blobs.Models.GeoReplication GeoReplication { get; internal set; }

        /// <summary>
        /// Creates a new BlobServiceStatistics instance
        /// </summary>
        public BlobServiceStatistics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobServiceStatistics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobServiceStatistics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.GeoReplication = new Azure.Storage.Blobs.Models.GeoReplication();
            }
        }

        /// <summary>
        /// Deserializes XML into a new BlobServiceStatistics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized BlobServiceStatistics instance.</returns>
        internal static Azure.Storage.Blobs.Models.BlobServiceStatistics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Blobs.Models.BlobServiceStatistics _value = new Azure.Storage.Blobs.Models.BlobServiceStatistics(true);
            _child = element.Element(System.Xml.Linq.XName.Get("GeoReplication", ""));
            if (_child != null)
            {
                _value.GeoReplication = Azure.Storage.Blobs.Models.GeoReplication.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Blobs.Models.BlobServiceStatistics value);
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobServiceStatistics instance for mocking.
        /// </summary>
        public static BlobServiceStatistics BlobServiceStatistics(
            Azure.Storage.Blobs.Models.GeoReplication geoReplication = default)
        {
            var _model = new BlobServiceStatistics();
            _model.GeoReplication = geoReplication;
            return _model;
        }
    }
}
#endregion class BlobServiceStatistics

#region enum SkuName
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Identifies the sku name of the account
    /// </summary>
    public enum SkuName
    {
        /// <summary>
        /// Standard_LRS
        /// </summary>
        StandardLRS,

        /// <summary>
        /// Standard_GRS
        /// </summary>
        StandardGRS,

        /// <summary>
        /// Standard_RAGRS
        /// </summary>
        StandardRAGRS,

        /// <summary>
        /// Standard_ZRS
        /// </summary>
        StandardZRS,

        /// <summary>
        /// Premium_LRS
        /// </summary>
        PremiumLRS
    }
}

namespace Azure.Storage.Blobs
{
    internal static partial class BlobRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Blobs.Models.SkuName value)
            {
                switch (value)
                {
                    case Azure.Storage.Blobs.Models.SkuName.StandardLRS:
                        return "Standard_LRS";
                    case Azure.Storage.Blobs.Models.SkuName.StandardGRS:
                        return "Standard_GRS";
                    case Azure.Storage.Blobs.Models.SkuName.StandardRAGRS:
                        return "Standard_RAGRS";
                    case Azure.Storage.Blobs.Models.SkuName.StandardZRS:
                        return "Standard_ZRS";
                    case Azure.Storage.Blobs.Models.SkuName.PremiumLRS:
                        return "Premium_LRS";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.SkuName value.");
                }
            }

            public static Azure.Storage.Blobs.Models.SkuName ParseSkuName(string value)
            {
                switch (value)
                {
                    case "Standard_LRS":
                        return Azure.Storage.Blobs.Models.SkuName.StandardLRS;
                    case "Standard_GRS":
                        return Azure.Storage.Blobs.Models.SkuName.StandardGRS;
                    case "Standard_RAGRS":
                        return Azure.Storage.Blobs.Models.SkuName.StandardRAGRS;
                    case "Standard_ZRS":
                        return Azure.Storage.Blobs.Models.SkuName.StandardZRS;
                    case "Premium_LRS":
                        return Azure.Storage.Blobs.Models.SkuName.PremiumLRS;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Blobs.Models.SkuName value.");
                }
            }
        }
    }
}
#endregion enum SkuName

#region enum AccountKind
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Identifies the account kind
    /// </summary>
    public enum AccountKind
    {
        /// <summary>
        /// Storage
        /// </summary>
        Storage,

        /// <summary>
        /// BlobStorage
        /// </summary>
        BlobStorage,

        /// <summary>
        /// StorageV2
        /// </summary>
        StorageV2
    }
}
#endregion enum AccountKind

#region class AccountInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// AccountInfo
    /// </summary>
    public partial class AccountInfo
    {
        /// <summary>
        /// Identifies the sku name of the account
        /// </summary>
        public Azure.Storage.Blobs.Models.SkuName SkuName { get; internal set; }

        /// <summary>
        /// Identifies the account kind
        /// </summary>
        public Azure.Storage.Blobs.Models.AccountKind AccountKind { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new AccountInfo instance for mocking.
        /// </summary>
        public static AccountInfo AccountInfo(
            Azure.Storage.Blobs.Models.SkuName skuName,
            Azure.Storage.Blobs.Models.AccountKind accountKind)
        {
            var _model = new AccountInfo();
            _model.SkuName = skuName;
            _model.AccountKind = accountKind;
            return _model;
        }
    }
}
#endregion class AccountInfo

#region class ContainerInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ContainerInfo
    /// </summary>
    public partial class ContainerInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new ContainerInfo instance for mocking.
        /// </summary>
        public static ContainerInfo ContainerInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            var _model = new ContainerInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            return _model;
        }
    }
}
#endregion class ContainerInfo

#region class FlattenedContainerItem
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// FlattenedContainerItem
    /// </summary>
    internal partial class FlattenedContainerItem
    {
        /// <summary>
        /// x-ms-meta
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }

        /// <summary>
        /// Indicated whether data in the container may be accessed publicly and the level of access
        /// </summary>
        public Azure.Storage.Blobs.Models.PublicAccessType BlobPublicAccess { get; internal set; }

        /// <summary>
        /// Indicates whether the container has an immutability policy set on it.
        /// </summary>
        public bool HasImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// Indicates whether the container has a legal hold.
        /// </summary>
        public bool HasLegalHold { get; internal set; }

        /// <summary>
        /// Creates a new FlattenedContainerItem instance
        /// </summary>
        public FlattenedContainerItem()
        {
            this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }
    }
}
#endregion class FlattenedContainerItem

#region class ContainerAccessPolicy
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ContainerAccessPolicy
    /// </summary>
    public partial class ContainerAccessPolicy
    {
        /// <summary>
        /// Indicated whether data in the container may be accessed publicly and the level of access
        /// </summary>
        public Azure.Storage.Blobs.Models.PublicAccessType BlobPublicAccess { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// a collection of signed identifiers
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.SignedIdentifier> SignedIdentifiers { get; internal set; }

        /// <summary>
        /// Creates a new ContainerAccessPolicy instance
        /// </summary>
        public ContainerAccessPolicy()
        {
            this.SignedIdentifiers = new System.Collections.Generic.List<Azure.Storage.Blobs.Models.SignedIdentifier>();
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new ContainerAccessPolicy instance for mocking.
        /// </summary>
        public static ContainerAccessPolicy ContainerAccessPolicy(
            Azure.Storage.Blobs.Models.PublicAccessType blobPublicAccess,
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.SignedIdentifier> signedIdentifiers)
        {
            var _model = new ContainerAccessPolicy();
            _model.BlobPublicAccess = blobPublicAccess;
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.SignedIdentifiers = signedIdentifiers;
            return _model;
        }
    }
}
#endregion class ContainerAccessPolicy

#region class Lease
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Lease
    /// </summary>
    public partial class Lease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Uniquely identifies a container or blob's lease
        /// </summary>
        public string LeaseId { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new Lease instance for mocking.
        /// </summary>
        public static Lease Lease(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            string leaseId)
        {
            var _model = new Lease();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.LeaseId = leaseId;
            return _model;
        }
    }
}
#endregion class Lease

#region class BrokenLease
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BrokenLease
    /// </summary>
    internal partial class BrokenLease
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Approximate time remaining in the lease period, in seconds.
        /// </summary>
        public int LeaseTime { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }
    }
}
#endregion class BrokenLease

#region class ConditionNotMetError
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// ConditionNotMetError
    /// </summary>
    internal partial class ConditionNotMetError
    {
        /// <summary>
        /// x-ms-error-code
        /// </summary>
        public string ErrorCode { get; internal set; }
    }
}
#endregion class ConditionNotMetError

#region class FlattenedDownloadProperties
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// FlattenedDownloadProperties
    /// </summary>
    internal partial class FlattenedDownloadProperties
    {
        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// x-ms-meta
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the blob by setting the 'Range' request header.
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header. The Content-Disposition response header field conveys additional information about how to process the response payload, and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent should not display the response, but instead show a Save As dialog with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// The blob's type.
        /// </summary>
        public Azure.Storage.Blobs.Models.BlobType BlobType { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob. This value can specify the time of a completed, aborted, or failed copy attempt. This header does not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public System.DateTimeOffset CopyCompletionTime { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or non-fatal copy operation failure. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob operation where this blob was the destination blob. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public System.Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// If the blob has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole blob's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] BlobContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Content
        /// </summary>
        public System.IO.Stream Content { get; internal set; }

        /// <summary>
        /// Creates a new FlattenedDownloadProperties instance
        /// </summary>
        public FlattenedDownloadProperties()
        {
            this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }
    }
}
#endregion class FlattenedDownloadProperties

#region class BlobProperties
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobProperties
    /// </summary>
    public partial class BlobProperties
    {
        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was created.
        /// </summary>
        public System.DateTimeOffset CreationTime { get; internal set; }

        /// <summary>
        /// x-ms-meta
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The blob's type.
        /// </summary>
        public Azure.Storage.Blobs.Models.BlobType BlobType { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob. This value can specify the time of a completed, aborted, or failed copy attempt. This header does not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public System.DateTimeOffset CopyCompletionTime { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or non-fatal copy operation failure. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob operation where this blob was the destination blob. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public System.Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// Included if the blob is incremental copy blob.
        /// </summary>
        public bool IsIncrementalCopy { get; internal set; }

        /// <summary>
        /// Included if the blob is incremental copy blob or incremental copy snapshot, if x-ms-copy-status is success. Snapshot time of the last successful incremental copy snapshot for this blob.
        /// </summary>
        public string DestinationSnapshot { get; internal set; }

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the blob. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// If the blob has an Hash hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentEncoding { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header. The Content-Disposition response header field conveys additional information about how to process the response payload, and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent should not display the response, but instead show a Save As dialog with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ContentLanguage { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The tier of page blob on a premium storage account or tier of block blob on blob storage LRS accounts. For a list of allowed premium page blob tiers, see https://docs.microsoft.com/en-us/azure/virtual-machines/windows/premium-storage#features. For blob storage LRS accounts, valid values are Hot/Cool/Archive.
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// For page blobs on a premium storage account only. If the access tier is not explicitly set on the blob, the tier is inferred based on its content length and this header will be returned with true value.
        /// </summary>
        public bool AccessTierInferred { get; internal set; }

        /// <summary>
        /// For blob storage LRS accounts, valid values are rehydrate-pending-to-hot/rehydrate-pending-to-cool. If the blob is being rehydrated and is not complete then this header is returned indicating that rehydrate is pending and also tells the destination tier.
        /// </summary>
        public string ArchiveStatus { get; internal set; }

        /// <summary>
        /// The time the tier was changed on the object. This is only returned if the tier on the block blob was ever set.
        /// </summary>
        public System.DateTimeOffset AccessTierChangeTime { get; internal set; }

        /// <summary>
        /// Creates a new BlobProperties instance
        /// </summary>
        public BlobProperties()
        {
            this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            this.ContentEncoding = new System.Collections.Generic.List<string>();
            this.ContentLanguage = new System.Collections.Generic.List<string>();
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobProperties instance for mocking.
        /// </summary>
        public static BlobProperties BlobProperties(
            System.DateTimeOffset lastModified,
            Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration,
            Azure.Storage.Blobs.Models.LeaseState leaseState,
            Azure.Storage.Blobs.Models.LeaseStatus leaseStatus,
            string destinationSnapshot,
            string contentType,
            Azure.Core.Http.ETag eTag,
            byte[] contentHash,
            System.Collections.Generic.IEnumerable<string> contentEncoding,
            string contentDisposition,
            bool isIncrementalCopy,
            System.Collections.Generic.IEnumerable<string> contentLanguage,
            Azure.Storage.Blobs.Models.CopyStatus copyStatus,
            string cacheControl,
            System.Uri copySource,
            long blobSequenceNumber,
            string copyProgress,
            string acceptRanges,
            string copyId,
            int blobCommittedBlockCount,
            string copyStatusDescription,
            bool isServerEncrypted,
            System.DateTimeOffset copyCompletionTime,
            string accessTier,
            Azure.Storage.Blobs.Models.BlobType blobType,
            bool accessTierInferred,
            System.Collections.Generic.IDictionary<string, string> metadata,
            string archiveStatus,
            System.DateTimeOffset creationTime,
            System.DateTimeOffset accessTierChangeTime,
            long contentLength)
        {
            var _model = new BlobProperties();
            _model.LastModified = lastModified;
            _model.LeaseDuration = leaseDuration;
            _model.LeaseState = leaseState;
            _model.LeaseStatus = leaseStatus;
            _model.DestinationSnapshot = destinationSnapshot;
            _model.ContentType = contentType;
            _model.ETag = eTag;
            _model.ContentHash = contentHash;
            _model.ContentEncoding = contentEncoding;
            _model.ContentDisposition = contentDisposition;
            _model.IsIncrementalCopy = isIncrementalCopy;
            _model.ContentLanguage = contentLanguage;
            _model.CopyStatus = copyStatus;
            _model.CacheControl = cacheControl;
            _model.CopySource = copySource;
            _model.BlobSequenceNumber = blobSequenceNumber;
            _model.CopyProgress = copyProgress;
            _model.AcceptRanges = acceptRanges;
            _model.CopyId = copyId;
            _model.BlobCommittedBlockCount = blobCommittedBlockCount;
            _model.CopyStatusDescription = copyStatusDescription;
            _model.IsServerEncrypted = isServerEncrypted;
            _model.CopyCompletionTime = copyCompletionTime;
            _model.AccessTier = accessTier;
            _model.BlobType = blobType;
            _model.AccessTierInferred = accessTierInferred;
            _model.Metadata = metadata;
            _model.ArchiveStatus = archiveStatus;
            _model.CreationTime = creationTime;
            _model.AccessTierChangeTime = accessTierChangeTime;
            _model.ContentLength = contentLength;
            return _model;
        }
    }
}
#endregion class BlobProperties

#region class BlobContentInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobContentInfo
    /// </summary>
    public partial class BlobContentInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The current sequence number for the page blob.  This is only returned for page blobs.
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobContentInfo instance for mocking.
        /// </summary>
        public static BlobContentInfo BlobContentInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            long blobSequenceNumber)
        {
            var _model = new BlobContentInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.ContentHash = contentHash;
            _model.BlobSequenceNumber = blobSequenceNumber;
            return _model;
        }
    }
}
#endregion class BlobContentInfo

#region class SetHttpHeadersOperation
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// SetHttpHeadersOperation
    /// </summary>
    internal partial class SetHttpHeadersOperation
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }
    }
}
#endregion class SetHttpHeadersOperation

#region class SetMetadataOperation
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// SetMetadataOperation
    /// </summary>
    internal partial class SetMetadataOperation
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }
    }
}
#endregion class SetMetadataOperation

#region class BlobInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobInfo
    /// </summary>
    public partial class BlobInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobInfo instance for mocking.
        /// </summary>
        public static BlobInfo BlobInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            var _model = new BlobInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            return _model;
        }
    }
}
#endregion class BlobInfo

#region class BlobSnapshotInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobSnapshotInfo
    /// </summary>
    public partial class BlobSnapshotInfo
    {
        /// <summary>
        /// Uniquely identifies the snapshot and indicates the snapshot version. It may be used in subsequent requests to access the snapshot
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobSnapshotInfo instance for mocking.
        /// </summary>
        public static BlobSnapshotInfo BlobSnapshotInfo(
            string snapshot,
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            var _model = new BlobSnapshotInfo();
            _model.Snapshot = snapshot;
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            return _model;
        }
    }
}
#endregion class BlobSnapshotInfo

#region class BlobCopyInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobCopyInfo
    /// </summary>
    public partial class BlobCopyInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobCopyInfo instance for mocking.
        /// </summary>
        public static BlobCopyInfo BlobCopyInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            string copyId,
            Azure.Storage.Blobs.Models.CopyStatus copyStatus)
        {
            var _model = new BlobCopyInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.CopyId = copyId;
            _model.CopyStatus = copyStatus;
            return _model;
        }
    }
}
#endregion class BlobCopyInfo

#region class BlockInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlockInfo
    /// </summary>
    public partial class BlockInfo
    {
        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlockInfo instance for mocking.
        /// </summary>
        public static BlockInfo BlockInfo(
            byte[] contentHash)
        {
            var _model = new BlockInfo();
            _model.ContentHash = contentHash;
            return _model;
        }
    }
}
#endregion class BlockInfo

#region class GetBlockListOperation
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// GetBlockListOperation
    /// </summary>
    internal partial class GetBlockListOperation
    {
        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For Get Block List this is 'application/xml'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The size of the blob in bytes.
        /// </summary>
        public long BlobContentLength { get; internal set; }

        /// <summary>
        /// This header uniquely identifies the request that was made and can be used for troubleshooting the request.
        /// </summary>
        public string RequestId { get; internal set; }

        /// <summary>
        /// Indicates the version of the Blob service used to execute the request. This header is returned for requests made against version 2009-09-19 and above.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// UTC date/time value generated by the service that indicates the time at which the response was initiated
        /// </summary>
        public System.DateTimeOffset Date { get; internal set; }

        /// <summary>
        /// Body
        /// </summary>
        public Azure.Storage.Blobs.Models.BlockList Body { get; internal set; }

        /// <summary>
        /// Creates a new GetBlockListOperation instance
        /// </summary>
        public GetBlockListOperation()
        {
            this.Body = new Azure.Storage.Blobs.Models.BlockList();
        }
    }
}
#endregion class GetBlockListOperation

#region class PageInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// PageInfo
    /// </summary>
    public partial class PageInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The current sequence number for the page blob.  This is only returned for page blobs.
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageInfo instance for mocking.
        /// </summary>
        public static PageInfo PageInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            long blobSequenceNumber)
        {
            var _model = new PageInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.ContentHash = contentHash;
            _model.BlobSequenceNumber = blobSequenceNumber;
            return _model;
        }
    }
}
#endregion class PageInfo

#region class PageRangesInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// PageRangesInfo
    /// </summary>
    public partial class PageRangesInfo
    {
        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// The size of the blob in bytes.
        /// </summary>
        public long BlobContentLength { get; internal set; }

        /// <summary>
        /// the list of pages
        /// </summary>
        public Azure.Storage.Blobs.Models.PageList Body { get; internal set; }

        /// <summary>
        /// Creates a new PageRangesInfo instance
        /// </summary>
        public PageRangesInfo()
        {
            this.Body = new Azure.Storage.Blobs.Models.PageList();
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageRangesInfo instance for mocking.
        /// </summary>
        public static PageRangesInfo PageRangesInfo(
            System.DateTimeOffset lastModified,
            Azure.Core.Http.ETag eTag,
            long blobContentLength,
            Azure.Storage.Blobs.Models.PageList body)
        {
            var _model = new PageRangesInfo();
            _model.LastModified = lastModified;
            _model.ETag = eTag;
            _model.BlobContentLength = blobContentLength;
            _model.Body = body;
            return _model;
        }
    }
}
#endregion class PageRangesInfo

#region class PageBlobInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// PageBlobInfo
    /// </summary>
    public partial class PageBlobInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The current sequence number for the page blob.  This is only returned for page blobs.
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageBlobInfo instance for mocking.
        /// </summary>
        public static PageBlobInfo PageBlobInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            long blobSequenceNumber)
        {
            var _model = new PageBlobInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.BlobSequenceNumber = blobSequenceNumber;
            return _model;
        }
    }
}
#endregion class PageBlobInfo

#region class BlobAppendInfo
namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobAppendInfo
    /// </summary>
    public partial class BlobAppendInfo
    {
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public Azure.Core.Http.ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
        #pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This response header is returned only for append operations. It returns the offset at which the block was committed, in bytes.
        /// </summary>
        public string BlobAppendOffset { get; internal set; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobAppendInfo instance for mocking.
        /// </summary>
        public static BlobAppendInfo BlobAppendInfo(
            Azure.Core.Http.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            string blobAppendOffset,
            int blobCommittedBlockCount,
            bool isServerEncrypted)
        {
            var _model = new BlobAppendInfo();
            _model.ETag = eTag;
            _model.LastModified = lastModified;
            _model.ContentHash = contentHash;
            _model.BlobAppendOffset = blobAppendOffset;
            _model.BlobCommittedBlockCount = blobCommittedBlockCount;
            _model.IsServerEncrypted = isServerEncrypted;
            return _model;
        }
    }
}
#endregion class BlobAppendInfo
#endregion Models


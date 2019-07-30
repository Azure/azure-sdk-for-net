// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// This file was automatically generated.  Do not edit.

#region Service
namespace Azure.Storage.Queues
{
    /// <summary>
    /// Azure Queue Storage
    /// </summary>
    internal static partial class QueueRestClient
    {
        #region Service operations
        /// <summary>
        /// Service operations for Azure Queue Storage
        /// </summary>
        public static partial class Service
        {
            #region Service.SetPropertiesAsync
            /// <summary>
            /// Sets properties for a storage account's Queue service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueServiceProperties properties,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.ServiceClient.SetProperties",
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
                        properties,
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
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SetPropertiesAsync Request.</returns>
            internal static Azure.Core.Http.Request SetPropertiesAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueServiceProperties properties,
                int? timeout = default,
                string requestId = default)
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
                System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueServiceProperties.ToXml(properties, "StorageServiceProperties", "");
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.SetPropertiesAsync

            #region Service.GetPropertiesAsync
            /// <summary>
            /// gets the properties of a storage account's Queue service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Storage Service Properties.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.ServiceClient.GetProperties",
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
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
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
            /// <returns>The Service.GetPropertiesAsync Azure.Response{Azure.Storage.Queues.Models.QueueServiceProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.QueueServiceProperties _value = Azure.Storage.Queues.Models.QueueServiceProperties.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties> _result =
                            new Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetPropertiesAsync

            #region Service.GetStatisticsAsync
            /// <summary>
            /// Retrieves statistics related to replication for the Queue service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Statistics for the storage service.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics>> GetStatisticsAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.ServiceClient.GetStatistics",
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
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
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
            /// <returns>The Service.GetStatisticsAsync Azure.Response{Azure.Storage.Queues.Models.QueueServiceStatistics}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics> GetStatisticsAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.QueueServiceStatistics _value = Azure.Storage.Queues.Models.QueueServiceStatistics.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics> _result =
                            new Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.GetStatisticsAsync

            #region Service.ListQueuesSegmentAsync
            /// <summary>
            /// The List Queues Segment operation returns a list of the queues under the specified account
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only queues whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of queues to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all queues remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of queues to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the queues's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling List Queues on a Queue Service.</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueuesSegment>> ListQueuesSegmentAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.ListQueuesIncludeType> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.ServiceClient.ListQueuesSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ListQueuesSegmentAsync_CreateRequest(
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
                        return ListQueuesSegmentAsync_CreateResponse(_response);
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
            /// Create the Service.ListQueuesSegmentAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="prefix">Filters the results to return only queues whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of queues to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all queues remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of queues to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the queues's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.ListQueuesSegmentAsync Request.</returns>
            internal static Azure.Core.Http.Request ListQueuesSegmentAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.ListQueuesIncludeType> include = default,
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
                if (include != null) { _request.UriBuilder.AppendQuery("include", System.Uri.EscapeDataString(string.Join(",", System.Linq.Enumerable.Select(include, item => Azure.Storage.Queues.QueueRestClient.Serialization.ToString(item))))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Service.ListQueuesSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListQueuesSegmentAsync Azure.Response{Azure.Storage.Queues.Models.QueuesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueuesSegment> ListQueuesSegmentAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.QueuesSegment _value = Azure.Storage.Queues.Models.QueuesSegment.FromXml(_xml.Root);

                        // Create the response
                        Azure.Response<Azure.Storage.Queues.Models.QueuesSegment> _result =
                            new Azure.Response<Azure.Storage.Queues.Models.QueuesSegment>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Service.ListQueuesSegmentAsync
        }
        #endregion Service operations

        #region Queue operations
        /// <summary>
        /// Queue operations for Azure Queue Storage
        /// </summary>
        public static partial class Queue
        {
            #region Queue.CreateAsync
            /// <summary>
            /// creates a new queue under the given account.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.Create",
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
            /// Create the Queue.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.CreateAsync Request.</returns>
            internal static Azure.Core.Http.Request CreateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
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
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Queue.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        return response;
                    }
                    case 204:
                    {
                        return response;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.CreateAsync

            #region Queue.DeleteAsync
            /// <summary>
            /// operation permanently deletes the specified queue
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.Delete",
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
            /// Create the Queue.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
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
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Queue.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.DeleteAsync

            #region Queue.GetPropertiesAsync
            /// <summary>
            /// Retrieves user-defined metadata and queue properties on the specified queue. Metadata is associated with the queue as name-values pairs.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Queues.Models.QueueProperties}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.QueueProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.GetProperties",
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
            /// Create the Queue.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.GetPropertiesAsync Request.</returns>
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
                _request.UriBuilder.AppendQuery("comp", "metadata");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Queue.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.GetPropertiesAsync Azure.Response{Azure.Storage.Queues.Models.QueueProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueProperties> GetPropertiesAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        Azure.Storage.Queues.Models.QueueProperties _value = new Azure.Storage.Queues.Models.QueueProperties();

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
                        if (response.Headers.TryGetValue("x-ms-approximate-messages-count", out _header))
                        {
                            _value.ApproximateMessagesCount = int.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Queues.Models.QueueProperties> _result =
                            new Azure.Response<Azure.Storage.Queues.Models.QueueProperties>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.GetPropertiesAsync

            #region Queue.SetMetadataAsync
            /// <summary>
            /// sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetMetadataAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.SetMetadata",
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
            /// Create the Queue.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.SetMetadataAsync Request.</returns>
            internal static Azure.Core.Http.Request SetMetadataAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
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
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Queue.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.SetMetadataAsync Azure.Response.</returns>
            internal static Azure.Response SetMetadataAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.SetMetadataAsync

            #region Queue.GetAccessPolicyAsync
            /// <summary>
            /// returns details about any stored access policies specified on the queue that may be used with Shared Access Signatures.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>a collection of signed identifiers</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier>>> GetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.GetAccessPolicy",
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
            /// Create the Queue.GetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.GetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request GetAccessPolicyAsync_CreateRequest(
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
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Queue.GetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.GetAccessPolicyAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.SignedIdentifier}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier>> GetAccessPolicyAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("SignedIdentifiers", "")).Elements(System.Xml.Linq.XName.Get("SignedIdentifier", "")),
                                    Azure.Storage.Queues.Models.SignedIdentifier.FromXml));

                        // Create the response
                        Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier>> _result =
                            new Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier>>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.GetAccessPolicyAsync

            #region Queue.SetAccessPolicyAsync
            /// <summary>
            /// sets stored access policies for the queue that may be used with Shared Access Signatures
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="permissions">the acls for the queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> SetAccessPolicyAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier> permissions = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.QueueClient.SetAccessPolicy",
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
            /// Create the Queue.SetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="permissions">the acls for the queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.SetAccessPolicyAsync Request.</returns>
            internal static Azure.Core.Http.Request SetAccessPolicyAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SignedIdentifier> permissions = default,
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
                _request.UriBuilder.AppendQuery("comp", "acl");
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("SignedIdentifiers", ""));
                if (permissions != null)
                {
                    foreach (Azure.Storage.Queues.Models.SignedIdentifier _child in permissions)
                    {
                        _body.Add(Azure.Storage.Queues.Models.SignedIdentifier.ToXml(_child));
                    }
                }
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Queue.SetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.SetAccessPolicyAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessPolicyAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Queue.SetAccessPolicyAsync
        }
        #endregion Queue operations

        #region Messages operations
        /// <summary>
        /// Messages operations for Azure Queue Storage
        /// </summary>
        public static partial class Messages
        {
            #region Messages.DequeueAsync
            /// <summary>
            /// The Dequeue operation retrieves one or more messages from the front of the queue.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Get Messages on a Queue</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessage>>> DequeueAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? numberOfMessages = default,
                int? visibilitytimeout = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessagesClient.Dequeue",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = DequeueAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        numberOfMessages,
                        visibilitytimeout,
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
                        return DequeueAsync_CreateResponse(_response);
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
            /// Create the Messages.DequeueAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.DequeueAsync Request.</returns>
            internal static Azure.Core.Http.Request DequeueAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? numberOfMessages = default,
                int? visibilitytimeout = default,
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
                if (numberOfMessages != null) { _request.UriBuilder.AppendQuery("numofmessages", System.Uri.EscapeDataString(numberOfMessages.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (visibilitytimeout != null) { _request.UriBuilder.AppendQuery("visibilitytimeout", System.Uri.EscapeDataString(visibilitytimeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Messages.DequeueAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.DequeueAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.DequeuedMessage}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessage>> DequeueAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessage> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.DequeuedMessage.FromXml));

                        // Create the response
                        Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessage>> _result =
                            new Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessage>>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Messages.DequeueAsync

            #region Messages.ClearAsync
            /// <summary>
            /// The Clear operation deletes all messages from the specified queue.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> ClearAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessagesClient.Clear",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = ClearAsync_CreateRequest(
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
                        return ClearAsync_CreateResponse(_response);
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
            /// Create the Messages.ClearAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.ClearAsync Request.</returns>
            internal static Azure.Core.Http.Request ClearAsync_CreateRequest(
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
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = resourceUri;
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Messages.ClearAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.ClearAsync Azure.Response.</returns>
            internal static Azure.Response ClearAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Messages.ClearAsync

            #region Messages.EnqueueAsync
            /// <summary>
            /// The Enqueue operation adds a new message to the back of the message queue. A visibility timeout can also be specified to make the message invisible until the visibility timeout expires. A message must be in a format that can be included in an XML request with UTF-8 encoding. The encoded message can be up to 64 KB in size for versions 2011-08-18 and newer, or 8 KB in size for previous versions.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="messageTimeToLive">Optional. Specifies the time-to-live interval for the message, in seconds. Prior to version 2017-07-29, the maximum time-to-live allowed is 7 days. For version 2017-07-29 or later, the maximum time-to-live can be any positive number, as well as -1 indicating that the message does not expire. If this parameter is omitted, the default time-to-live is 7 days.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Put Message on a Queue</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.EnqueuedMessage>>> EnqueueAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueMessage message,
                int? visibilitytimeout = default,
                int? messageTimeToLive = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessagesClient.Enqueue",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = EnqueueAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        message,
                        visibilitytimeout,
                        messageTimeToLive,
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
                        return EnqueueAsync_CreateResponse(_response);
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
            /// Create the Messages.EnqueueAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="messageTimeToLive">Optional. Specifies the time-to-live interval for the message, in seconds. Prior to version 2017-07-29, the maximum time-to-live allowed is 7 days. For version 2017-07-29 or later, the maximum time-to-live can be any positive number, as well as -1 indicating that the message does not expire. If this parameter is omitted, the default time-to-live is 7 days.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.EnqueueAsync Request.</returns>
            internal static Azure.Core.Http.Request EnqueueAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueMessage message,
                int? visibilitytimeout = default,
                int? messageTimeToLive = default,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (message == null)
                {
                    throw new System.ArgumentNullException(nameof(message));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Post;
                _request.UriBuilder.Uri = resourceUri;
                if (visibilitytimeout != null) { _request.UriBuilder.AppendQuery("visibilitytimeout", System.Uri.EscapeDataString(visibilitytimeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (messageTimeToLive != null) { _request.UriBuilder.AppendQuery("messagettl", System.Uri.EscapeDataString(messageTimeToLive.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueMessage.ToXml(message, "QueueMessage", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the Messages.EnqueueAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.EnqueueAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.EnqueuedMessage}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.EnqueuedMessage>> EnqueueAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.EnqueuedMessage> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.EnqueuedMessage.FromXml));

                        // Create the response
                        Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.EnqueuedMessage>> _result =
                            new Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.EnqueuedMessage>>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Messages.EnqueueAsync

            #region Messages.PeekAsync
            /// <summary>
            /// The Peek operation retrieves one or more messages from the front of the queue, but does not alter the visibility of the message.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Peek Messages on a Queue</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessage>>> PeekAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? numberOfMessages = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessagesClient.Peek",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = PeekAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        numberOfMessages,
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
                        return PeekAsync_CreateResponse(_response);
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
            /// Create the Messages.PeekAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.PeekAsync Request.</returns>
            internal static Azure.Core.Http.Request PeekAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                int? numberOfMessages = default,
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
                _request.UriBuilder.AppendQuery("peekonly", "true");
                if (numberOfMessages != null) { _request.UriBuilder.AppendQuery("numofmessages", System.Uri.EscapeDataString(numberOfMessages.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the Messages.PeekAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.PeekAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.PeekedMessage}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessage>> PeekAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 200:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessage> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.PeekedMessage.FromXml));

                        // Create the response
                        Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessage>> _result =
                            new Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessage>>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion Messages.PeekAsync
        }
        #endregion Messages operations

        #region MessageId operations
        /// <summary>
        /// MessageId operations for Azure Queue Storage
        /// </summary>
        public static partial class MessageId
        {
            #region MessageId.UpdateAsync
            /// <summary>
            /// The Update operation was introduced with version 2011-08-18 of the Queue service API. The Update Message operation updates the visibility timeout of a message. You can also use this operation to update the contents of a message. A message must be in a format that can be included in an XML request with UTF-8 encoding, and the encoded message can be up to 64KB in size.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Queues.Models.UpdatedMessage}</returns>
            public static async System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Queues.Models.UpdatedMessage>> UpdateAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueMessage message,
                string popReceipt,
                int visibilitytimeout,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessageIdClient.Update",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = pipeline.Diagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.Http.Request _request = UpdateAsync_CreateRequest(
                        pipeline,
                        resourceUri,
                        message,
                        popReceipt,
                        visibilitytimeout,
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
                        return UpdateAsync_CreateResponse(_response);
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
            /// Create the MessageId.UpdateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The MessageId.UpdateAsync Request.</returns>
            internal static Azure.Core.Http.Request UpdateAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueMessage message,
                string popReceipt,
                int visibilitytimeout,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (message == null)
                {
                    throw new System.ArgumentNullException(nameof(message));
                }
                if (popReceipt == null)
                {
                    throw new System.ArgumentNullException(nameof(popReceipt));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Put;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("popreceipt", System.Uri.EscapeDataString(popReceipt));
                _request.UriBuilder.AppendQuery("visibilitytimeout", System.Uri.EscapeDataString(visibilitytimeout.ToString(System.Globalization.CultureInfo.InvariantCulture)));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueMessage.ToXml(message, "QueueMessage", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.Pipeline.HttpPipelineRequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _request;
            }

            /// <summary>
            /// Create the MessageId.UpdateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The MessageId.UpdateAsync Azure.Response{Azure.Storage.Queues.Models.UpdatedMessage}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.UpdatedMessage> UpdateAsync_CreateResponse(
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 204:
                    {
                        // Create the result
                        Azure.Storage.Queues.Models.UpdatedMessage _value = new Azure.Storage.Queues.Models.UpdatedMessage();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-popreceipt", out _header))
                        {
                            _value.PopReceipt = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-time-next-visible", out _header))
                        {
                            _value.TimeNextVisible = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        Azure.Response<Azure.Storage.Queues.Models.UpdatedMessage> _result =
                            new Azure.Response<Azure.Storage.Queues.Models.UpdatedMessage>(
                                response,
                                _value);

                        return _result;
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion MessageId.UpdateAsync

            #region MessageId.DeleteAsync
            /// <summary>
            /// The Delete operation deletes the specified message.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.Task<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "Azure.Storage.Queues.MessageIdClient.Delete",
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
                        popReceipt,
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
            /// Create the MessageId.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The MessageId.DeleteAsync Request.</returns>
            internal static Azure.Core.Http.Request DeleteAsync_CreateRequest(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                int? timeout = default,
                string requestId = default)
            {
                // Validation
                if (resourceUri == null)
                {
                    throw new System.ArgumentNullException(nameof(resourceUri));
                }
                if (popReceipt == null)
                {
                    throw new System.ArgumentNullException(nameof(popReceipt));
                }

                // Create the request
                Azure.Core.Http.Request _request = pipeline.CreateRequest();

                // Set the endpoint
                _request.Method = Azure.Core.Pipeline.RequestMethod.Delete;
                _request.UriBuilder.Uri = resourceUri;
                _request.UriBuilder.AppendQuery("popreceipt", System.Uri.EscapeDataString(popReceipt));
                if (timeout != null) { _request.UriBuilder.AppendQuery("timeout", System.Uri.EscapeDataString(timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture))); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", "2018-11-09");
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _request;
            }

            /// <summary>
            /// Create the MessageId.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="response">The raw Response.</param>
            /// <returns>The MessageId.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(response);
                    }
                }
            }
            #endregion MessageId.DeleteAsync
        }
        #endregion MessageId operations
    }
}
#endregion Service

#region Models
#region class AccessPolicy
namespace Azure.Storage.Queues.Models
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
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.AccessPolicy value, string name = "AccessPolicy", string ns = "")
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
        internal static Azure.Storage.Queues.Models.AccessPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.AccessPolicy _value = new Azure.Storage.Queues.Models.AccessPolicy();
            _value.Start = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("Start", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.Expiry = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("Expiry", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.Permission = element.Element(System.Xml.Linq.XName.Get("Permission", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.AccessPolicy value);
    }
}
#endregion class AccessPolicy

#region class SignedIdentifier
namespace Azure.Storage.Queues.Models
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
        public Azure.Storage.Queues.Models.AccessPolicy AccessPolicy { get; set; }

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
                this.AccessPolicy = new Azure.Storage.Queues.Models.AccessPolicy();
            }
        }

        /// <summary>
        /// Serialize a SignedIdentifier instance as XML.
        /// </summary>
        /// <param name="value">The SignedIdentifier instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "SignedIdentifier".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.SignedIdentifier value, string name = "SignedIdentifier", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Id", ""),
                value.Id));
            _element.Add(Azure.Storage.Queues.Models.AccessPolicy.ToXml(value.AccessPolicy, "AccessPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new SignedIdentifier instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SignedIdentifier instance.</returns>
        internal static Azure.Storage.Queues.Models.SignedIdentifier FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.SignedIdentifier _value = new Azure.Storage.Queues.Models.SignedIdentifier(true);
            _value.Id = element.Element(System.Xml.Linq.XName.Get("Id", "")).Value;
            _value.AccessPolicy = Azure.Storage.Queues.Models.AccessPolicy.FromXml(element.Element(System.Xml.Linq.XName.Get("AccessPolicy", "")));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.SignedIdentifier value);
    }
}
#endregion class SignedIdentifier

#region enum ListQueuesIncludeType
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// ListQueuesIncludeType values
    /// </summary>
    internal enum ListQueuesIncludeType
    {
        /// <summary>
        /// metadata
        /// </summary>
        Metadata
    }
}

namespace Azure.Storage.Queues
{
    internal static partial class QueueRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Queues.Models.ListQueuesIncludeType value)
            {
                switch (value)
                {
                    case Azure.Storage.Queues.Models.ListQueuesIncludeType.Metadata:
                        return "metadata";
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.ListQueuesIncludeType value.");
                }
            }

            public static Azure.Storage.Queues.Models.ListQueuesIncludeType ParseListQueuesIncludeType(string value)
            {
                switch (value)
                {
                    case "metadata":
                        return Azure.Storage.Queues.Models.ListQueuesIncludeType.Metadata;
                    default:
                        throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.ListQueuesIncludeType value.");
                }
            }
        }
    }
}
#endregion enum ListQueuesIncludeType

#region class QueueMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// A Message object which can be stored in a Queue
    /// </summary>
    internal partial class QueueMessage
    {
        /// <summary>
        /// The content of the message
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Serialize a QueueMessage instance as XML.
        /// </summary>
        /// <param name="value">The QueueMessage instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "QueueMessage".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueMessage value, string name = "QueueMessage", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("MessageText", ""),
                value.MessageText));
            return _element;
        }
    }
}
#endregion class QueueMessage

#region class RetentionPolicy
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// the retention policy
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
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.RetentionPolicy value, string name = "RetentionPolicy", string ns = "")
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
        internal static Azure.Storage.Queues.Models.RetentionPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.RetentionPolicy _value = new Azure.Storage.Queues.Models.RetentionPolicy();
            _value.Enabled = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Enabled", "")).Value);
            _child = element.Element(System.Xml.Linq.XName.Get("Days", ""));
            if (_child != null)
            {
                _value.Days = int.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.RetentionPolicy value);
    }
}
#endregion class RetentionPolicy

#region class Logging
namespace Azure.Storage.Queues.Models
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
        /// the retention policy
        /// </summary>
        public Azure.Storage.Queues.Models.RetentionPolicy RetentionPolicy { get; set; }

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
                this.RetentionPolicy = new Azure.Storage.Queues.Models.RetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a Logging instance as XML.
        /// </summary>
        /// <param name="value">The Logging instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Logging".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.Logging value, string name = "Logging", string ns = "")
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
            _element.Add(Azure.Storage.Queues.Models.RetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new Logging instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Logging instance.</returns>
        internal static Azure.Storage.Queues.Models.Logging FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.Logging _value = new Azure.Storage.Queues.Models.Logging(true);
            _value.Version = element.Element(System.Xml.Linq.XName.Get("Version", "")).Value;
            _value.Delete = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Delete", "")).Value);
            _value.Read = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Read", "")).Value);
            _value.Write = bool.Parse(element.Element(System.Xml.Linq.XName.Get("Write", "")).Value);
            _value.RetentionPolicy = Azure.Storage.Queues.Models.RetentionPolicy.FromXml(element.Element(System.Xml.Linq.XName.Get("RetentionPolicy", "")));
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.Logging value);
    }
}
#endregion class Logging

#region class Metrics
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Metrics
    /// </summary>
    public partial class Metrics
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether metrics are enabled for the Queue service.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        public bool? IncludeAPIs { get; set; }

        /// <summary>
        /// the retention policy
        /// </summary>
        public Azure.Storage.Queues.Models.RetentionPolicy RetentionPolicy { get; set; }

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
                this.RetentionPolicy = new Azure.Storage.Queues.Models.RetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a Metrics instance as XML.
        /// </summary>
        /// <param name="value">The Metrics instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Metrics".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.Metrics value, string name = "Metrics", string ns = "")
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
                _element.Add(Azure.Storage.Queues.Models.RetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new Metrics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized Metrics instance.</returns>
        internal static Azure.Storage.Queues.Models.Metrics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.Metrics _value = new Azure.Storage.Queues.Models.Metrics(true);
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
                _value.RetentionPolicy = Azure.Storage.Queues.Models.RetentionPolicy.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.Metrics value);
    }
}
#endregion class Metrics

#region class CorsRule
namespace Azure.Storage.Queues.Models
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
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.CorsRule value, string name = "CorsRule", string ns = "")
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
        internal static Azure.Storage.Queues.Models.CorsRule FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.CorsRule _value = new Azure.Storage.Queues.Models.CorsRule();
            _value.AllowedOrigins = element.Element(System.Xml.Linq.XName.Get("AllowedOrigins", "")).Value;
            _value.AllowedMethods = element.Element(System.Xml.Linq.XName.Get("AllowedMethods", "")).Value;
            _value.AllowedHeaders = element.Element(System.Xml.Linq.XName.Get("AllowedHeaders", "")).Value;
            _value.ExposedHeaders = element.Element(System.Xml.Linq.XName.Get("ExposedHeaders", "")).Value;
            _value.MaxAgeInSeconds = int.Parse(element.Element(System.Xml.Linq.XName.Get("MaxAgeInSeconds", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.CorsRule value);
    }
}
#endregion class CorsRule

#region class QueueServiceProperties
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Storage Service Properties.
    /// </summary>
    public partial class QueueServiceProperties
    {
        /// <summary>
        /// Azure Analytics Logging settings
        /// </summary>
        public Azure.Storage.Queues.Models.Logging Logging { get; set; }

        /// <summary>
        /// A summary of request statistics grouped by API in hourly aggregates for queues
        /// </summary>
        public Azure.Storage.Queues.Models.Metrics HourMetrics { get; set; }

        /// <summary>
        /// a summary of request statistics grouped by API in minute aggregates for queues
        /// </summary>
        public Azure.Storage.Queues.Models.Metrics MinuteMetrics { get; set; }

        /// <summary>
        /// The set of CORS rules.
        /// </summary>
        public System.Collections.Generic.IList<Azure.Storage.Queues.Models.CorsRule> Cors { get; internal set; }

        /// <summary>
        /// Creates a new QueueServiceProperties instance
        /// </summary>
        public QueueServiceProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueServiceProperties instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.Logging = new Azure.Storage.Queues.Models.Logging();
                this.HourMetrics = new Azure.Storage.Queues.Models.Metrics();
                this.MinuteMetrics = new Azure.Storage.Queues.Models.Metrics();
                this.Cors = new System.Collections.Generic.List<Azure.Storage.Queues.Models.CorsRule>();
            }
        }

        /// <summary>
        /// Serialize a QueueServiceProperties instance as XML.
        /// </summary>
        /// <param name="value">The QueueServiceProperties instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "StorageServiceProperties".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueServiceProperties value, string name = "StorageServiceProperties", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.Logging != null)
            {
                _element.Add(Azure.Storage.Queues.Models.Logging.ToXml(value.Logging, "Logging", ""));
            }
            if (value.HourMetrics != null)
            {
                _element.Add(Azure.Storage.Queues.Models.Metrics.ToXml(value.HourMetrics, "HourMetrics", ""));
            }
            if (value.MinuteMetrics != null)
            {
                _element.Add(Azure.Storage.Queues.Models.Metrics.ToXml(value.MinuteMetrics, "MinuteMetrics", ""));
            }
            if (value.Cors != null)
            {
                System.Xml.Linq.XElement _elements = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Cors", ""));
                foreach (Azure.Storage.Queues.Models.CorsRule _child in value.Cors)
                {
                    _elements.Add(Azure.Storage.Queues.Models.CorsRule.ToXml(_child));
                }
                _element.Add(_elements);
            }
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new QueueServiceProperties instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueServiceProperties instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueServiceProperties FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueServiceProperties _value = new Azure.Storage.Queues.Models.QueueServiceProperties(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Logging", ""));
            if (_child != null)
            {
                _value.Logging = Azure.Storage.Queues.Models.Logging.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("HourMetrics", ""));
            if (_child != null)
            {
                _value.HourMetrics = Azure.Storage.Queues.Models.Metrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MinuteMetrics", ""));
            if (_child != null)
            {
                _value.MinuteMetrics = Azure.Storage.Queues.Models.Metrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Cors", ""));
            if (_child != null)
            {
                _value.Cors = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("CorsRule", "")),
                        e => Azure.Storage.Queues.Models.CorsRule.FromXml(e)));
            }
            else
            {
                _value.Cors = new System.Collections.Generic.List<Azure.Storage.Queues.Models.CorsRule>();
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueServiceProperties value);
    }
}
#endregion class QueueServiceProperties

#region class QueueItem
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// An Azure Storage Queue.
    /// </summary>
    public partial class QueueItem
    {
        /// <summary>
        /// The name of the Queue.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Creates a new QueueItem instance
        /// </summary>
        public QueueItem()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueItem instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueItem(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Deserializes XML into a new QueueItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueItem instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueItem _value = new Azure.Storage.Queues.Models.QueueItem(true);
            _value.Name = element.Element(System.Xml.Linq.XName.Get("Name", "")).Value;
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueItem value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new QueueItem instance for mocking.
        /// </summary>
        public static QueueItem QueueItem(
            string name,
            System.Collections.Generic.IDictionary<string, string> metadata = default)
        {
            var _model = new QueueItem();
            _model.Name = name;
            _model.Metadata = metadata;
            return _model;
        }
    }
}
#endregion class QueueItem

#region class QueuesSegment
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned when calling List Queues on a Queue Service.
    /// </summary>
    internal partial class QueuesSegment
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
        /// QueueItems
        /// </summary>
        public System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueItem> QueueItems { get; internal set; }

        /// <summary>
        /// NextMarker
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// Creates a new QueuesSegment instance
        /// </summary>
        public QueuesSegment()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueuesSegment instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueuesSegment(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.QueueItems = new System.Collections.Generic.List<Azure.Storage.Queues.Models.QueueItem>();
            }
        }

        /// <summary>
        /// Deserializes XML into a new QueuesSegment instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueuesSegment instance.</returns>
        internal static Azure.Storage.Queues.Models.QueuesSegment FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueuesSegment _value = new Azure.Storage.Queues.Models.QueuesSegment(true);
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
            _child = element.Element(System.Xml.Linq.XName.Get("Queues", ""));
            if (_child != null)
            {
                _value.QueueItems = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("Queue", "")),
                        e => Azure.Storage.Queues.Models.QueueItem.FromXml(e)));
            }
            else
            {
                _value.QueueItems = new System.Collections.Generic.List<Azure.Storage.Queues.Models.QueueItem>();
            }
            _child = element.Element(System.Xml.Linq.XName.Get("NextMarker", ""));
            if (_child != null)
            {
                _value.NextMarker = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueuesSegment value);
    }
}
#endregion class QueuesSegment

#region enum strings QueueErrorCode
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Error codes returned by the service
    /// </summary>
    public partial struct QueueErrorCode : System.IEquatable<QueueErrorCode>
    {
        #pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// AccountAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountAlreadyExists = @"AccountAlreadyExists";

        /// <summary>
        /// AccountBeingCreated
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountBeingCreated = @"AccountBeingCreated";

        /// <summary>
        /// AccountIsDisabled
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountIsDisabled = @"AccountIsDisabled";

        /// <summary>
        /// AuthenticationFailed
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthenticationFailed = @"AuthenticationFailed";

        /// <summary>
        /// AuthorizationFailure
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationFailure = @"AuthorizationFailure";

        /// <summary>
        /// ConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionHeadersNotSupported = @"ConditionHeadersNotSupported";

        /// <summary>
        /// ConditionNotMet
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionNotMet = @"ConditionNotMet";

        /// <summary>
        /// EmptyMetadataKey
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode EmptyMetadataKey = @"EmptyMetadataKey";

        /// <summary>
        /// InsufficientAccountPermissions
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InsufficientAccountPermissions = @"InsufficientAccountPermissions";

        /// <summary>
        /// InternalError
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InternalError = @"InternalError";

        /// <summary>
        /// InvalidAuthenticationInfo
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidAuthenticationInfo = @"InvalidAuthenticationInfo";

        /// <summary>
        /// InvalidHeaderValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHeaderValue = @"InvalidHeaderValue";

        /// <summary>
        /// InvalidHttpVerb
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHttpVerb = @"InvalidHttpVerb";

        /// <summary>
        /// InvalidInput
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidInput = @"InvalidInput";

        /// <summary>
        /// InvalidMd5
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMd5 = @"InvalidMd5";

        /// <summary>
        /// InvalidMetadata
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMetadata = @"InvalidMetadata";

        /// <summary>
        /// InvalidQueryParameterValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidQueryParameterValue = @"InvalidQueryParameterValue";

        /// <summary>
        /// InvalidRange
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidRange = @"InvalidRange";

        /// <summary>
        /// InvalidResourceName
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidResourceName = @"InvalidResourceName";

        /// <summary>
        /// InvalidUri
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidUri = @"InvalidUri";

        /// <summary>
        /// InvalidXmlDocument
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlDocument = @"InvalidXmlDocument";

        /// <summary>
        /// InvalidXmlNodeValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlNodeValue = @"InvalidXmlNodeValue";

        /// <summary>
        /// Md5Mismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode Md5Mismatch = @"Md5Mismatch";

        /// <summary>
        /// MetadataTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MetadataTooLarge = @"MetadataTooLarge";

        /// <summary>
        /// MissingContentLengthHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingContentLengthHeader = @"MissingContentLengthHeader";

        /// <summary>
        /// MissingRequiredQueryParameter
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredQueryParameter = @"MissingRequiredQueryParameter";

        /// <summary>
        /// MissingRequiredHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredHeader = @"MissingRequiredHeader";

        /// <summary>
        /// MissingRequiredXmlNode
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredXmlNode = @"MissingRequiredXmlNode";

        /// <summary>
        /// MultipleConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MultipleConditionHeadersNotSupported = @"MultipleConditionHeadersNotSupported";

        /// <summary>
        /// OperationTimedOut
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OperationTimedOut = @"OperationTimedOut";

        /// <summary>
        /// OutOfRangeInput
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeInput = @"OutOfRangeInput";

        /// <summary>
        /// OutOfRangeQueryParameterValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeQueryParameterValue = @"OutOfRangeQueryParameterValue";

        /// <summary>
        /// RequestBodyTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestBodyTooLarge = @"RequestBodyTooLarge";

        /// <summary>
        /// ResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceTypeMismatch = @"ResourceTypeMismatch";

        /// <summary>
        /// RequestUrlFailedToParse
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestUrlFailedToParse = @"RequestUrlFailedToParse";

        /// <summary>
        /// ResourceAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceAlreadyExists = @"ResourceAlreadyExists";

        /// <summary>
        /// ResourceNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceNotFound = @"ResourceNotFound";

        /// <summary>
        /// ServerBusy
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ServerBusy = @"ServerBusy";

        /// <summary>
        /// UnsupportedHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHeader = @"UnsupportedHeader";

        /// <summary>
        /// UnsupportedXmlNode
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedXmlNode = @"UnsupportedXmlNode";

        /// <summary>
        /// UnsupportedQueryParameter
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedQueryParameter = @"UnsupportedQueryParameter";

        /// <summary>
        /// UnsupportedHttpVerb
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHttpVerb = @"UnsupportedHttpVerb";

        /// <summary>
        /// InvalidMarker
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMarker = @"InvalidMarker";

        /// <summary>
        /// MessageNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageNotFound = @"MessageNotFound";

        /// <summary>
        /// MessageTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageTooLarge = @"MessageTooLarge";

        /// <summary>
        /// PopReceiptMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode PopReceiptMismatch = @"PopReceiptMismatch";

        /// <summary>
        /// QueueAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueAlreadyExists = @"QueueAlreadyExists";

        /// <summary>
        /// QueueBeingDeleted
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueBeingDeleted = @"QueueBeingDeleted";

        /// <summary>
        /// QueueDisabled
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueDisabled = @"QueueDisabled";

        /// <summary>
        /// QueueNotEmpty
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotEmpty = @"QueueNotEmpty";

        /// <summary>
        /// QueueNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotFound = @"QueueNotFound";
        #pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// The QueueErrorCode value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Creates a new QueueErrorCode instance.
        /// </summary>
        /// <param name="value">The QueueErrorCode value.</param>
        private QueueErrorCode(string value) { this._value = value; }

        /// <summary>
        /// Check if two QueueErrorCode instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Queues.Models.QueueErrorCode other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);

        /// <summary>
        /// Check if two QueueErrorCode instances are equal.
        /// </summary>
        /// <param name="o">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object o) => o is Azure.Storage.Queues.Models.QueueErrorCode other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the QueueErrorCode.
        /// </summary>
        /// <returns>Hash code for the QueueErrorCode.</returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// Convert the QueueErrorCode to a string.
        /// </summary>
        /// <returns>String representation of the QueueErrorCode.</returns>
        public override string ToString() => this._value;

        #pragma warning disable CA2225 // Operator overloads have named alternates
        /// <summary>
        /// Convert a string a QueueErrorCode.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The QueueErrorCode value.</returns>
        public static implicit operator QueueErrorCode(string value) => new Azure.Storage.Queues.Models.QueueErrorCode(value);
        #pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Convert an QueueErrorCode to a string.
        /// </summary>
        /// <param name="o">The QueueErrorCode value.</param>
        /// <returns>String representation of the QueueErrorCode value.</returns>
        public static implicit operator string(Azure.Storage.Queues.Models.QueueErrorCode o) => o._value;

        /// <summary>
        /// Check if two QueueErrorCode instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(Azure.Storage.Queues.Models.QueueErrorCode a, Azure.Storage.Queues.Models.QueueErrorCode b) => a.Equals(b);

        /// <summary>
        /// Check if two QueueErrorCode instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(Azure.Storage.Queues.Models.QueueErrorCode a, Azure.Storage.Queues.Models.QueueErrorCode b) => !a.Equals(b);
    }
}
#endregion enum strings QueueErrorCode

#region enum strings GeoReplicationStatus
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The status of the secondary location
    /// </summary>
    public partial struct GeoReplicationStatus : System.IEquatable<GeoReplicationStatus>
    {
        #pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// live
        /// </summary>
        public static Azure.Storage.Queues.Models.GeoReplicationStatus Live = @"live";

        /// <summary>
        /// bootstrap
        /// </summary>
        public static Azure.Storage.Queues.Models.GeoReplicationStatus Bootstrap = @"bootstrap";

        /// <summary>
        /// unavailable
        /// </summary>
        public static Azure.Storage.Queues.Models.GeoReplicationStatus Unavailable = @"unavailable";
        #pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// The GeoReplicationStatus value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Creates a new GeoReplicationStatus instance.
        /// </summary>
        /// <param name="value">The GeoReplicationStatus value.</param>
        private GeoReplicationStatus(string value) { this._value = value; }

        /// <summary>
        /// Check if two GeoReplicationStatus instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Queues.Models.GeoReplicationStatus other) => this._value.Equals(other._value, System.StringComparison.InvariantCulture);

        /// <summary>
        /// Check if two GeoReplicationStatus instances are equal.
        /// </summary>
        /// <param name="o">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object o) => o is Azure.Storage.Queues.Models.GeoReplicationStatus other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the GeoReplicationStatus.
        /// </summary>
        /// <returns>Hash code for the GeoReplicationStatus.</returns>
        public override int GetHashCode() => this._value.GetHashCode();

        /// <summary>
        /// Convert the GeoReplicationStatus to a string.
        /// </summary>
        /// <returns>String representation of the GeoReplicationStatus.</returns>
        public override string ToString() => this._value;

        #pragma warning disable CA2225 // Operator overloads have named alternates
        /// <summary>
        /// Convert a string a GeoReplicationStatus.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The GeoReplicationStatus value.</returns>
        public static implicit operator GeoReplicationStatus(string value) => new Azure.Storage.Queues.Models.GeoReplicationStatus(value);
        #pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Convert an GeoReplicationStatus to a string.
        /// </summary>
        /// <param name="o">The GeoReplicationStatus value.</param>
        /// <returns>String representation of the GeoReplicationStatus value.</returns>
        public static implicit operator string(Azure.Storage.Queues.Models.GeoReplicationStatus o) => o._value;

        /// <summary>
        /// Check if two GeoReplicationStatus instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(Azure.Storage.Queues.Models.GeoReplicationStatus a, Azure.Storage.Queues.Models.GeoReplicationStatus b) => a.Equals(b);

        /// <summary>
        /// Check if two GeoReplicationStatus instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(Azure.Storage.Queues.Models.GeoReplicationStatus a, Azure.Storage.Queues.Models.GeoReplicationStatus b) => !a.Equals(b);
    }
}
#endregion enum strings GeoReplicationStatus

#region class GeoReplication
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// GeoReplication
    /// </summary>
    public partial class GeoReplication
    {
        /// <summary>
        /// The status of the secondary location
        /// </summary>
        public Azure.Storage.Queues.Models.GeoReplicationStatus Status { get; internal set; }

        /// <summary>
        /// A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads.
        /// </summary>
        public System.DateTimeOffset LastSyncTime { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new GeoReplication instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized GeoReplication instance.</returns>
        internal static Azure.Storage.Queues.Models.GeoReplication FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.GeoReplication _value = new Azure.Storage.Queues.Models.GeoReplication();
            _value.Status = element.Element(System.Xml.Linq.XName.Get("Status", "")).Value;
            _value.LastSyncTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("LastSyncTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.GeoReplication value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new GeoReplication instance for mocking.
        /// </summary>
        public static GeoReplication GeoReplication(
            Azure.Storage.Queues.Models.GeoReplicationStatus status,
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

#region class StorageError
namespace Azure.Storage.Queues.Models
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
        internal static Azure.Storage.Queues.Models.StorageError FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.StorageError _value = new Azure.Storage.Queues.Models.StorageError();
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.StorageError value);
    }
}
#endregion class StorageError

#region class DequeuedMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get Messages on a Queue.
    /// </summary>
    public partial class DequeuedMessage
    {
        /// <summary>
        /// The Id of the Message.
        /// </summary>
        public string MessageId { get; internal set; }

        /// <summary>
        /// The time the Message was inserted into the Queue.
        /// </summary>
        public System.DateTimeOffset InsertionTime { get; internal set; }

        /// <summary>
        /// The time that the Message will expire and be automatically deleted.
        /// </summary>
        public System.DateTimeOffset ExpirationTime { get; internal set; }

        /// <summary>
        /// This value is required to delete the Message. If deletion fails using this popreceipt then the message has been dequeued by another client.
        /// </summary>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// The time that the message will again become visible in the Queue.
        /// </summary>
        public System.DateTimeOffset TimeNextVisible { get; internal set; }

        /// <summary>
        /// The number of times the message has been dequeued.
        /// </summary>
        public long DequeueCount { get; internal set; }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        public string MessageText { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new DequeuedMessage instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized DequeuedMessage instance.</returns>
        internal static Azure.Storage.Queues.Models.DequeuedMessage FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.DequeuedMessage _value = new Azure.Storage.Queues.Models.DequeuedMessage();
            _value.MessageId = element.Element(System.Xml.Linq.XName.Get("MessageId", "")).Value;
            _value.InsertionTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("InsertionTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.ExpirationTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("ExpirationTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.PopReceipt = element.Element(System.Xml.Linq.XName.Get("PopReceipt", "")).Value;
            _value.TimeNextVisible = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("TimeNextVisible", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.DequeueCount = long.Parse(element.Element(System.Xml.Linq.XName.Get("DequeueCount", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.MessageText = element.Element(System.Xml.Linq.XName.Get("MessageText", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.DequeuedMessage value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new DequeuedMessage instance for mocking.
        /// </summary>
        public static DequeuedMessage DequeuedMessage(
            string messageId,
            System.DateTimeOffset insertionTime,
            System.DateTimeOffset expirationTime,
            string popReceipt,
            System.DateTimeOffset timeNextVisible,
            long dequeueCount,
            string messageText)
        {
            var _model = new DequeuedMessage();
            _model.MessageId = messageId;
            _model.InsertionTime = insertionTime;
            _model.ExpirationTime = expirationTime;
            _model.PopReceipt = popReceipt;
            _model.TimeNextVisible = timeNextVisible;
            _model.DequeueCount = dequeueCount;
            _model.MessageText = messageText;
            return _model;
        }
    }
}
#endregion class DequeuedMessage

#region class PeekedMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Peek Messages on a Queue
    /// </summary>
    public partial class PeekedMessage
    {
        /// <summary>
        /// The Id of the Message.
        /// </summary>
        public string MessageId { get; internal set; }

        /// <summary>
        /// The time the Message was inserted into the Queue.
        /// </summary>
        public System.DateTimeOffset InsertionTime { get; internal set; }

        /// <summary>
        /// The time that the Message will expire and be automatically deleted.
        /// </summary>
        public System.DateTimeOffset ExpirationTime { get; internal set; }

        /// <summary>
        /// The number of times the message has been dequeued.
        /// </summary>
        public long DequeueCount { get; internal set; }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        public string MessageText { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new PeekedMessage instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized PeekedMessage instance.</returns>
        internal static Azure.Storage.Queues.Models.PeekedMessage FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.PeekedMessage _value = new Azure.Storage.Queues.Models.PeekedMessage();
            _value.MessageId = element.Element(System.Xml.Linq.XName.Get("MessageId", "")).Value;
            _value.InsertionTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("InsertionTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.ExpirationTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("ExpirationTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.DequeueCount = long.Parse(element.Element(System.Xml.Linq.XName.Get("DequeueCount", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.MessageText = element.Element(System.Xml.Linq.XName.Get("MessageText", "")).Value;
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.PeekedMessage value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new PeekedMessage instance for mocking.
        /// </summary>
        public static PeekedMessage PeekedMessage(
            string messageId,
            System.DateTimeOffset insertionTime,
            System.DateTimeOffset expirationTime,
            long dequeueCount,
            string messageText)
        {
            var _model = new PeekedMessage();
            _model.MessageId = messageId;
            _model.InsertionTime = insertionTime;
            _model.ExpirationTime = expirationTime;
            _model.DequeueCount = dequeueCount;
            _model.MessageText = messageText;
            return _model;
        }
    }
}
#endregion class PeekedMessage

#region class EnqueuedMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Put Message on a Queue
    /// </summary>
    public partial class EnqueuedMessage
    {
        /// <summary>
        /// The Id of the Message.
        /// </summary>
        public string MessageId { get; internal set; }

        /// <summary>
        /// The time the Message was inserted into the Queue.
        /// </summary>
        public System.DateTimeOffset InsertionTime { get; internal set; }

        /// <summary>
        /// The time that the Message will expire and be automatically deleted.
        /// </summary>
        public System.DateTimeOffset ExpirationTime { get; internal set; }

        /// <summary>
        /// This value is required to delete the Message. If deletion fails using this popreceipt then the message has been dequeued by another client.
        /// </summary>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// The time that the message will again become visible in the Queue.
        /// </summary>
        public System.DateTimeOffset TimeNextVisible { get; internal set; }

        /// <summary>
        /// Deserializes XML into a new EnqueuedMessage instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized EnqueuedMessage instance.</returns>
        internal static Azure.Storage.Queues.Models.EnqueuedMessage FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            Azure.Storage.Queues.Models.EnqueuedMessage _value = new Azure.Storage.Queues.Models.EnqueuedMessage();
            _value.MessageId = element.Element(System.Xml.Linq.XName.Get("MessageId", "")).Value;
            _value.InsertionTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("InsertionTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.ExpirationTime = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("ExpirationTime", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            _value.PopReceipt = element.Element(System.Xml.Linq.XName.Get("PopReceipt", "")).Value;
            _value.TimeNextVisible = System.DateTimeOffset.Parse(element.Element(System.Xml.Linq.XName.Get("TimeNextVisible", "")).Value, System.Globalization.CultureInfo.InvariantCulture);
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.EnqueuedMessage value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new EnqueuedMessage instance for mocking.
        /// </summary>
        public static EnqueuedMessage EnqueuedMessage(
            string messageId,
            System.DateTimeOffset insertionTime,
            System.DateTimeOffset expirationTime,
            string popReceipt,
            System.DateTimeOffset timeNextVisible)
        {
            var _model = new EnqueuedMessage();
            _model.MessageId = messageId;
            _model.InsertionTime = insertionTime;
            _model.ExpirationTime = expirationTime;
            _model.PopReceipt = popReceipt;
            _model.TimeNextVisible = timeNextVisible;
            return _model;
        }
    }
}
#endregion class EnqueuedMessage

#region class QueueServiceStatistics
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Statistics for the storage service.
    /// </summary>
    public partial class QueueServiceStatistics
    {
        /// <summary>
        /// Geo-Replication information for the Secondary Storage Service
        /// </summary>
        public Azure.Storage.Queues.Models.GeoReplication GeoReplication { get; internal set; }

        /// <summary>
        /// Creates a new QueueServiceStatistics instance
        /// </summary>
        public QueueServiceStatistics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueServiceStatistics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueServiceStatistics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                this.GeoReplication = new Azure.Storage.Queues.Models.GeoReplication();
            }
        }

        /// <summary>
        /// Deserializes XML into a new QueueServiceStatistics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueServiceStatistics instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueServiceStatistics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueServiceStatistics _value = new Azure.Storage.Queues.Models.QueueServiceStatistics(true);
            _child = element.Element(System.Xml.Linq.XName.Get("GeoReplication", ""));
            if (_child != null)
            {
                _value.GeoReplication = Azure.Storage.Queues.Models.GeoReplication.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueServiceStatistics value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new QueueServiceStatistics instance for mocking.
        /// </summary>
        public static QueueServiceStatistics QueueServiceStatistics(
            Azure.Storage.Queues.Models.GeoReplication geoReplication = default)
        {
            var _model = new QueueServiceStatistics();
            _model.GeoReplication = geoReplication;
            return _model;
        }
    }
}
#endregion class QueueServiceStatistics

#region class QueueProperties
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueProperties
    /// </summary>
    public partial class QueueProperties
    {
        /// <summary>
        /// x-ms-meta
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The approximate number of messages in the queue. This number is not lower than the actual number of messages in the queue, but could be higher.
        /// </summary>
        public int ApproximateMessagesCount { get; internal set; }

        /// <summary>
        /// Creates a new QueueProperties instance
        /// </summary>
        public QueueProperties()
        {
            this.Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new QueueProperties instance for mocking.
        /// </summary>
        public static QueueProperties QueueProperties(
            System.Collections.Generic.IDictionary<string, string> metadata,
            int approximateMessagesCount)
        {
            var _model = new QueueProperties();
            _model.Metadata = metadata;
            _model.ApproximateMessagesCount = approximateMessagesCount;
            return _model;
        }
    }
}
#endregion class QueueProperties

#region class UpdatedMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// UpdatedMessage
    /// </summary>
    public partial class UpdatedMessage
    {
        /// <summary>
        /// The pop receipt of the queue message.
        /// </summary>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// A UTC date/time value that represents when the message will be visible on the queue.
        /// </summary>
        public System.DateTimeOffset TimeNextVisible { get; internal set; }
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new UpdatedMessage instance for mocking.
        /// </summary>
        public static UpdatedMessage UpdatedMessage(
            string popReceipt,
            System.DateTimeOffset timeNextVisible)
        {
            var _model = new UpdatedMessage();
            _model.PopReceipt = popReceipt;
            _model.TimeNextVisible = timeNextVisible;
            return _model;
        }
    }
}
#endregion class UpdatedMessage
#endregion Models


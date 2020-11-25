// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file was automatically generated.  Do not edit.

#pragma warning disable IDE0016 // Null check can be simplified
#pragma warning disable IDE0017 // Variable declaration can be inlined
#pragma warning disable IDE0018 // Object initialization can be simplified
#pragma warning disable SA1402  // File may only contain a single type

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
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> SetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueServiceProperties properties,
                string version,
                int? timeout = default,
                string requestId = default,
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
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="properties">The StorageService properties.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.SetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueServiceProperties properties,
                string version,
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
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueServiceProperties.ToXml(properties, "StorageServiceProperties", "");
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.SetPropertiesAsync

            #region Service.GetPropertiesAsync
            /// <summary>
            /// gets the properties of a storage account's Queue service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Storage Service Properties.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
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
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "service", escapeValue: false);
                _request.Uri.AppendQuery("comp", "properties", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Service.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetPropertiesAsync Azure.Response{Azure.Storage.Queues.Models.QueueServiceProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueServiceProperties> GetPropertiesAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.QueueServiceProperties _value = Azure.Storage.Queues.Models.QueueServiceProperties.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Queues.Models.QueueServiceProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.GetPropertiesAsync

            #region Service.GetStatisticsAsync
            /// <summary>
            /// Retrieves statistics related to replication for the Queue service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Statistics for the storage service.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics>> GetStatisticsAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "ServiceClient.GetStatistics",
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
            /// Create the Service.GetStatisticsAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.GetStatisticsAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetStatisticsAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("restype", "service", escapeValue: false);
                _request.Uri.AppendQuery("comp", "stats", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Service.GetStatisticsAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.GetStatisticsAsync Azure.Response{Azure.Storage.Queues.Models.QueueServiceStatistics}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueServiceStatistics> GetStatisticsAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.QueueServiceStatistics _value = Azure.Storage.Queues.Models.QueueServiceStatistics.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Queues.Models.QueueServiceStatistics>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Service.GetStatisticsAsync

            #region Service.ListQueuesSegmentAsync
            /// <summary>
            /// The List Queues Segment operation returns a list of the queues under the specified account
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only queues whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of queues to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all queues remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of queues to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the queues's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling List Queues on a Queue Service.</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Queues.Models.QueuesSegment>> ListQueuesSegmentAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                string prefix = default,
                string marker = default,
                int? maxresults = default,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.ListQueuesIncludeType> include = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "ServiceClient.ListQueuesSegment",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ListQueuesSegmentAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        prefix,
                        marker,
                        maxresults,
                        include,
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
                        return ListQueuesSegmentAsync_CreateResponse(clientDiagnostics, _response);
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
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="prefix">Filters the results to return only queues whose name begins with the specified prefix.</param>
            /// <param name="marker">A string value that identifies the portion of the list of queues to be returned with the next listing operation. The operation returns the NextMarker value within the response body if the listing operation did not return all queues remaining to be listed with the current page. The NextMarker value can be used as the value for the marker parameter in a subsequent call to request the next page of list items. The marker value is opaque to the client.</param>
            /// <param name="maxresults">Specifies the maximum number of queues to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. Note that if the listing operation crosses a partition boundary, then the service will return a continuation token for retrieving the remainder of the results. For this reason, it is possible that the service will return fewer results than specified by maxresults, or than the default of 5000.</param>
            /// <param name="include">Include this parameter to specify that the queues's metadata be returned as part of the response body.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Service.ListQueuesSegmentAsync Message.</returns>
            internal static Azure.Core.HttpMessage ListQueuesSegmentAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
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
                if (include != null) { _request.Uri.AppendQuery("include", string.Join(",", System.Linq.Enumerable.Select(include, item => Azure.Storage.Queues.QueueRestClient.Serialization.ToString(item)))); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Service.ListQueuesSegmentAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Service.ListQueuesSegmentAsync Azure.Response{Azure.Storage.Queues.Models.QueuesSegment}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueuesSegment> ListQueuesSegmentAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.QueuesSegment _value = Azure.Storage.Queues.Models.QueuesSegment.FromXml(_xml.Root);

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Queues.Models.QueuesSegment>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
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
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> CreateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.Create",
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
            /// Create the Queue.CreateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.CreateAsync Message.</returns>
            internal static Azure.Core.HttpMessage CreateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
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
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (metadata != null) {
                    foreach (System.Collections.Generic.KeyValuePair<string, string> _pair in metadata)
                    {
                        _request.Headers.SetValue("x-ms-meta-" + _pair.Key, _pair.Value);
                    }
                }
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Queue.CreateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.CreateAsync Azure.Response.</returns>
            internal static Azure.Response CreateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
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

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Queue.CreateAsync

            #region Queue.DeleteAsync
            /// <summary>
            /// operation permanently deletes the specified queue
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
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
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.Delete",
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
            /// Create the Queue.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Queue.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Queue.DeleteAsync

            #region Queue.GetPropertiesAsync
            /// <summary>
            /// Retrieves user-defined metadata and queue properties on the specified queue. Metadata is associated with the queue as name-values pairs.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Queues.Models.QueueProperties}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Queues.Models.QueueProperties>> GetPropertiesAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.GetProperties",
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
            /// Create the Queue.GetPropertiesAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.GetPropertiesAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetPropertiesAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "metadata", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Queue.GetPropertiesAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.GetPropertiesAsync Azure.Response{Azure.Storage.Queues.Models.QueueProperties}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.QueueProperties> GetPropertiesAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
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
                        foreach (Azure.Core.HttpHeader _headerPair in response.Headers)
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
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<Azure.Storage.Queues.Models.QueueProperties>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Queue.GetPropertiesAsync

            #region Queue.SetMetadataAsync
            /// <summary>
            /// sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> SetMetadataAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.SetMetadata",
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
            /// Create the Queue.SetMetadataAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="metadata">Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers.</param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.SetMetadataAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetMetadataAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                System.Collections.Generic.IDictionary<string, string> metadata = default,
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
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Queue.SetMetadataAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.SetMetadataAsync Azure.Response.</returns>
            internal static Azure.Response SetMetadataAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Queue.SetMetadataAsync

            #region Queue.GetAccessPolicyAsync
            /// <summary>
            /// returns details about any stored access policies specified on the queue that may be used with Shared Access Signatures.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>a collection of signed identifiers</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>>> GetAccessPolicyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.GetAccessPolicy",
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
            /// Create the Queue.GetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.GetAccessPolicyAsync Message.</returns>
            internal static Azure.Core.HttpMessage GetAccessPolicyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("comp", "acl", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Queue.GetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.GetAccessPolicyAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.QueueSignedIdentifier}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>> GetAccessPolicyAsync_CreateResponse(
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
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("SignedIdentifiers", "")).Elements(System.Xml.Linq.XName.Get("SignedIdentifier", "")),
                                    Azure.Storage.Queues.Models.QueueSignedIdentifier.FromXml));

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier>>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Queue.GetAccessPolicyAsync

            #region Queue.SetAccessPolicyAsync
            /// <summary>
            /// sets stored access policies for the queue that may be used with Shared Access Signatures
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="permissions">the acls for the queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> SetAccessPolicyAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "QueueClient.SetAccessPolicy",
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
            /// Create the Queue.SetAccessPolicyAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="permissions">the acls for the queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Queue.SetAccessPolicyAsync Message.</returns>
            internal static Azure.Core.HttpMessage SetAccessPolicyAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.QueueSignedIdentifier> permissions = default,
                int? timeout = default,
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
                _request.Uri.AppendQuery("comp", "acl", escapeValue: false);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("SignedIdentifiers", ""));
                if (permissions != null)
                {
                    foreach (Azure.Storage.Queues.Models.QueueSignedIdentifier _child in permissions)
                    {
                        _body.Add(Azure.Storage.Queues.Models.QueueSignedIdentifier.ToXml(_child));
                    }
                }
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _message;
            }

            /// <summary>
            /// Create the Queue.SetAccessPolicyAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Queue.SetAccessPolicyAsync Azure.Response.</returns>
            internal static Azure.Response SetAccessPolicyAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
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
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Get Messages on a Queue</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessageItem>>> DequeueAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? numberOfMessages = default,
                int? visibilitytimeout = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessagesClient.Dequeue",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = DequeueAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        numberOfMessages,
                        visibilitytimeout,
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
                        return DequeueAsync_CreateResponse(clientDiagnostics, _response);
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
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.DequeueAsync Message.</returns>
            internal static Azure.Core.HttpMessage DequeueAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
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
                if (numberOfMessages != null) { _request.Uri.AppendQuery("numofmessages", numberOfMessages.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (visibilitytimeout != null) { _request.Uri.AppendQuery("visibilitytimeout", visibilitytimeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Messages.DequeueAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.DequeueAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.DequeuedMessageItem}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessageItem>> DequeueAsync_CreateResponse(
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
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessageItem> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.DequeuedMessageItem.FromXml));

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.DequeuedMessageItem>>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Messages.DequeueAsync

            #region Messages.ClearAsync
            /// <summary>
            /// The Clear operation deletes all messages from the specified queue.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> ClearAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessagesClient.Clear",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = ClearAsync_CreateMessage(
                        pipeline,
                        resourceUri,
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
                        return ClearAsync_CreateResponse(clientDiagnostics, _response);
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
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.ClearAsync Message.</returns>
            internal static Azure.Core.HttpMessage ClearAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Delete;
                _request.Uri.Reset(resourceUri);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Messages.ClearAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.ClearAsync Azure.Response.</returns>
            internal static Azure.Response ClearAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Messages.ClearAsync

            #region Messages.EnqueueAsync
            /// <summary>
            /// The Enqueue operation adds a new message to the back of the message queue. A visibility timeout can also be specified to make the message invisible until the visibility timeout expires. A message must be in a format that can be included in an XML request with UTF-8 encoding. The encoded message can be up to 64 KB in size for versions 2011-08-18 and newer, or 8 KB in size for previous versions.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="visibilitytimeout">Optional. If specified, the request must be made using an x-ms-version of 2011-08-18 or later. If not specified, the default value is 0. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the expiry time. visibilitytimeout should be set to a value smaller than the time-to-live value.</param>
            /// <param name="messageTimeToLive">Optional. Specifies the time-to-live interval for the message, in seconds. Prior to version 2017-07-29, the maximum time-to-live allowed is 7 days. For version 2017-07-29 or later, the maximum time-to-live can be any positive number, as well as -1 indicating that the message does not expire. If this parameter is omitted, the default time-to-live is 7 days.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Put Message on a Queue</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SendReceipt>>> EnqueueAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueSendMessage message,
                string version,
                int? visibilitytimeout = default,
                int? messageTimeToLive = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessagesClient.Enqueue",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = EnqueueAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        message,
                        version,
                        visibilitytimeout,
                        messageTimeToLive,
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
                        return EnqueueAsync_CreateResponse(clientDiagnostics, _response);
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
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="visibilitytimeout">Optional. If specified, the request must be made using an x-ms-version of 2011-08-18 or later. If not specified, the default value is 0. Specifies the new visibility timeout value, in seconds, relative to server time. The new value must be larger than or equal to 0, and cannot be larger than 7 days. The visibility timeout of a message cannot be set to a value later than the expiry time. visibilitytimeout should be set to a value smaller than the time-to-live value.</param>
            /// <param name="messageTimeToLive">Optional. Specifies the time-to-live interval for the message, in seconds. Prior to version 2017-07-29, the maximum time-to-live allowed is 7 days. For version 2017-07-29 or later, the maximum time-to-live can be any positive number, as well as -1 indicating that the message does not expire. If this parameter is omitted, the default time-to-live is 7 days.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.EnqueueAsync Message.</returns>
            internal static Azure.Core.HttpMessage EnqueueAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                Azure.Storage.Queues.Models.QueueSendMessage message,
                string version,
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
                if (visibilitytimeout != null) { _request.Uri.AppendQuery("visibilitytimeout", visibilitytimeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (messageTimeToLive != null) { _request.Uri.AppendQuery("messagettl", messageTimeToLive.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueSendMessage.ToXml(message, "QueueMessage", "");
                string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                _request.Headers.SetValue("Content-Type", "application/xml");
                _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));

                return _message;
            }

            /// <summary>
            /// Create the Messages.EnqueueAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.EnqueueAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.SendReceipt}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SendReceipt>> EnqueueAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 201:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.SendReceipt> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.SendReceipt.FromXml));

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion Messages.EnqueueAsync

            #region Messages.PeekAsync
            /// <summary>
            /// The Peek operation retrieves one or more messages from the front of the queue, but does not alter the visibility of the message.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>The object returned when calling Peek Messages on a Queue</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessageItem>>> PeekAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? numberOfMessages = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessagesClient.Peek",
                System.Threading.CancellationToken cancellationToken = default)
            {
                Azure.Core.Pipeline.DiagnosticScope _scope = clientDiagnostics.CreateScope(operationName);
                try
                {
                    _scope.AddAttribute("url", resourceUri);
                    _scope.Start();
                    using (Azure.Core.HttpMessage _message = PeekAsync_CreateMessage(
                        pipeline,
                        resourceUri,
                        version,
                        numberOfMessages,
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
                        return PeekAsync_CreateResponse(clientDiagnostics, _response);
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
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="numberOfMessages">Optional. A nonzero integer value that specifies the number of messages to retrieve from the queue, up to a maximum of 32. If fewer are visible, the visible messages are returned. By default, a single message is retrieved from the queue with this operation.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The Messages.PeekAsync Message.</returns>
            internal static Azure.Core.HttpMessage PeekAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string version,
                int? numberOfMessages = default,
                int? timeout = default,
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
                _request.Method = Azure.Core.RequestMethod.Get;
                _request.Uri.Reset(resourceUri);
                _request.Uri.AppendQuery("peekonly", "true", escapeValue: false);
                if (numberOfMessages != null) { _request.Uri.AppendQuery("numofmessages", numberOfMessages.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the Messages.PeekAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The Messages.PeekAsync Azure.Response{System.Collections.Generic.IEnumerable{Azure.Storage.Queues.Models.PeekedMessageItem}}.</returns>
            internal static Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessageItem>> PeekAsync_CreateResponse(
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
                        System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessageItem> _value =
                            System.Linq.Enumerable.ToList(
                                System.Linq.Enumerable.Select(
                                    _xml.Element(System.Xml.Linq.XName.Get("QueueMessagesList", "")).Elements(System.Xml.Linq.XName.Get("QueueMessage", "")),
                                    Azure.Storage.Queues.Models.PeekedMessageItem.FromXml));

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    case 304:
                    {
                        return new Azure.NoBodyResponse<System.Collections.Generic.IEnumerable<Azure.Storage.Queues.Models.PeekedMessageItem>>(response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
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
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response{Azure.Storage.Queues.Models.UpdateReceipt}</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt>> UpdateAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                int visibilitytimeout,
                string version,
                Azure.Storage.Queues.Models.QueueSendMessage message = default,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessageIdClient.Update",
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
                        popReceipt,
                        visibilitytimeout,
                        version,
                        message,
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
            /// Create the MessageId.UpdateAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="visibilitytimeout">Optional. Specifies the new visibility timeout value, in seconds, relative to server time. The default value is 30 seconds. A specified value must be larger than or equal to 1 second, and cannot be larger than 7 days, or larger than 2 hours on REST protocol versions prior to version 2011-08-18. The visibility timeout of a message can be set to a value later than the expiry time.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="message">A Message object which can be stored in a Queue</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The MessageId.UpdateAsync Message.</returns>
            internal static Azure.Core.HttpMessage UpdateAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                int visibilitytimeout,
                string version,
                Azure.Storage.Queues.Models.QueueSendMessage message = default,
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
                _request.Uri.AppendQuery("popreceipt", popReceipt);
                _request.Uri.AppendQuery("visibilitytimeout", visibilitytimeout.ToString(System.Globalization.CultureInfo.InvariantCulture));
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                // Create the body
                if (message != null)
                {
                    System.Xml.Linq.XElement _body = Azure.Storage.Queues.Models.QueueSendMessage.ToXml(message, "QueueMessage", "");
                    string _text = _body.ToString(System.Xml.Linq.SaveOptions.DisableFormatting);
                    _request.Headers.SetValue("Content-Type", "application/xml");
                    _request.Headers.SetValue("Content-Length", _text.Length.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    _request.Content = Azure.Core.RequestContent.Create(System.Text.Encoding.UTF8.GetBytes(_text));
                }

                return _message;
            }

            /// <summary>
            /// Create the MessageId.UpdateAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The MessageId.UpdateAsync Azure.Response{Azure.Storage.Queues.Models.UpdateReceipt}.</returns>
            internal static Azure.Response<Azure.Storage.Queues.Models.UpdateReceipt> UpdateAsync_CreateResponse(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Response response)
            {
                // Process the response
                switch (response.Status)
                {
                    case 204:
                    {
                        // Create the result
                        Azure.Storage.Queues.Models.UpdateReceipt _value = new Azure.Storage.Queues.Models.UpdateReceipt();

                        // Get response headers
                        string _header;
                        if (response.Headers.TryGetValue("x-ms-popreceipt", out _header))
                        {
                            _value.PopReceipt = _header;
                        }
                        if (response.Headers.TryGetValue("x-ms-time-next-visible", out _header))
                        {
                            _value.NextVisibleOn = System.DateTimeOffset.Parse(_header, System.Globalization.CultureInfo.InvariantCulture);
                        }

                        // Create the response
                        return Response.FromValue(_value, response);
                    }
                    default:
                    {
                        // Create the result
                        System.Xml.Linq.XDocument _xml = System.Xml.Linq.XDocument.Load(response.ContentStream, System.Xml.Linq.LoadOptions.PreserveWhitespace);
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
                    }
                }
            }
            #endregion MessageId.UpdateAsync

            #region MessageId.DeleteAsync
            /// <summary>
            /// The Delete operation deletes the specified message.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance used for operation reporting.</param>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <param name="async">Whether to invoke the operation asynchronously.  The default value is true.</param>
            /// <param name="operationName">Operation name.</param>
            /// <param name="cancellationToken">Cancellation token.</param>
            /// <returns>Azure.Response</returns>
            public static async System.Threading.Tasks.ValueTask<Azure.Response> DeleteAsync(
                Azure.Core.Pipeline.ClientDiagnostics clientDiagnostics,
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                string version,
                int? timeout = default,
                string requestId = default,
                bool async = true,
                string operationName = "MessageIdClient.Delete",
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
                        popReceipt,
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
            /// Create the MessageId.DeleteAsync request.
            /// </summary>
            /// <param name="pipeline">The pipeline used for sending requests.</param>
            /// <param name="resourceUri">The URL of the service account, queue or message that is the targe of the desired operation.</param>
            /// <param name="popReceipt">Required. Specifies the valid pop receipt value returned from an earlier call to the Get Messages or Update Message operation.</param>
            /// <param name="version">Specifies the version of the operation to use for this request.</param>
            /// <param name="timeout">The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a></param>
            /// <param name="requestId">Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled.</param>
            /// <returns>The MessageId.DeleteAsync Message.</returns>
            internal static Azure.Core.HttpMessage DeleteAsync_CreateMessage(
                Azure.Core.Pipeline.HttpPipeline pipeline,
                System.Uri resourceUri,
                string popReceipt,
                string version,
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
                _request.Uri.AppendQuery("popreceipt", popReceipt);
                if (timeout != null) { _request.Uri.AppendQuery("timeout", timeout.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)); }

                // Add request headers
                _request.Headers.SetValue("x-ms-version", version);
                if (requestId != null) { _request.Headers.SetValue("x-ms-client-request-id", requestId); }

                return _message;
            }

            /// <summary>
            /// Create the MessageId.DeleteAsync response or throw a failure exception.
            /// </summary>
            /// <param name="clientDiagnostics">The ClientDiagnostics instance to use.</param>
            /// <param name="response">The raw Response.</param>
            /// <returns>The MessageId.DeleteAsync Azure.Response.</returns>
            internal static Azure.Response DeleteAsync_CreateResponse(
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
                        Azure.Storage.Queues.Models.StorageError _value = Azure.Storage.Queues.Models.StorageError.FromXml(_xml.Root);

                        throw _value.CreateException(clientDiagnostics, response);
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
#region class DequeuedMessageItem
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get Messages on a Queue.
    /// </summary>
    internal partial class DequeuedMessageItem
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
        /// Prevent direct instantiation of DequeuedMessageItem instances.
        /// You can use QueuesModelFactory.DequeuedMessageItem instead.
        /// </summary>
        internal DequeuedMessageItem() { }

        /// <summary>
        /// Deserializes XML into a new DequeuedMessageItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized DequeuedMessageItem instance.</returns>
        internal static Azure.Storage.Queues.Models.DequeuedMessageItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.DequeuedMessageItem _value = new Azure.Storage.Queues.Models.DequeuedMessageItem();
            _child = element.Element(System.Xml.Linq.XName.Get("MessageId", ""));
            if (_child != null)
            {
                _value.MessageId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("InsertionTime", ""));
            if (_child != null)
            {
                _value.InsertionTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ExpirationTime", ""));
            if (_child != null)
            {
                _value.ExpirationTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("PopReceipt", ""));
            if (_child != null)
            {
                _value.PopReceipt = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("TimeNextVisible", ""));
            if (_child != null)
            {
                _value.TimeNextVisible = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DequeueCount", ""));
            if (_child != null)
            {
                _value.DequeueCount = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MessageText", ""));
            if (_child != null)
            {
                _value.MessageText = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.DequeuedMessageItem value);
    }
}
#endregion class DequeuedMessageItem

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
                return value switch
                {
                    Azure.Storage.Queues.Models.ListQueuesIncludeType.Metadata => "metadata",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.ListQueuesIncludeType value.")
                };
            }

            public static Azure.Storage.Queues.Models.ListQueuesIncludeType ParseListQueuesIncludeType(string value)
            {
                return value switch
                {
                    "metadata" => Azure.Storage.Queues.Models.ListQueuesIncludeType.Metadata,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.ListQueuesIncludeType value.")
                };
            }
        }
    }
}
#endregion enum ListQueuesIncludeType

#region class PeekedMessageItem
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Peek Messages on a Queue
    /// </summary>
    internal partial class PeekedMessageItem
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
        /// Prevent direct instantiation of PeekedMessageItem instances.
        /// You can use QueuesModelFactory.PeekedMessageItem instead.
        /// </summary>
        internal PeekedMessageItem() { }

        /// <summary>
        /// Deserializes XML into a new PeekedMessageItem instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized PeekedMessageItem instance.</returns>
        internal static Azure.Storage.Queues.Models.PeekedMessageItem FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.PeekedMessageItem _value = new Azure.Storage.Queues.Models.PeekedMessageItem();
            _child = element.Element(System.Xml.Linq.XName.Get("MessageId", ""));
            if (_child != null)
            {
                _value.MessageId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("InsertionTime", ""));
            if (_child != null)
            {
                _value.InsertionTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ExpirationTime", ""));
            if (_child != null)
            {
                _value.ExpirationTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("DequeueCount", ""));
            if (_child != null)
            {
                _value.DequeueCount = long.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MessageText", ""));
            if (_child != null)
            {
                _value.MessageText = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.PeekedMessageItem value);
    }
}
#endregion class PeekedMessageItem

#region class QueueAccessPolicy
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// An Access policy
    /// </summary>
    public partial class QueueAccessPolicy
    {
        /// <summary>
        /// the date-time the policy is active
        /// </summary>
        public System.DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// the date-time the policy expires
        /// </summary>
        public System.DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// the permissions for the acl policy
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Creates a new QueueAccessPolicy instance
        /// </summary>
        public QueueAccessPolicy() { }

        /// <summary>
        /// Serialize a QueueAccessPolicy instance as XML.
        /// </summary>
        /// <param name="value">The QueueAccessPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "AccessPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueAccessPolicy value, string name = "AccessPolicy", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            if (value.StartsOn != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Start", ""),
                    value.StartsOn.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
            }
            if (value.ExpiresOn != null)
            {
                _element.Add(new System.Xml.Linq.XElement(
                    System.Xml.Linq.XName.Get("Expiry", ""),
                    value.ExpiresOn.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture)));
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
        /// Deserializes XML into a new QueueAccessPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueAccessPolicy instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueAccessPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueAccessPolicy _value = new Azure.Storage.Queues.Models.QueueAccessPolicy();
            _child = element.Element(System.Xml.Linq.XName.Get("Start", ""));
            if (_child != null)
            {
                _value.StartsOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Expiry", ""));
            if (_child != null)
            {
                _value.ExpiresOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Permission", ""));
            if (_child != null)
            {
                _value.Permissions = _child.Value;
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueAccessPolicy value);
    }
}
#endregion class QueueAccessPolicy

#region class QueueAnalyticsLogging
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Azure Analytics Logging settings.
    /// </summary>
    public partial class QueueAnalyticsLogging
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
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Creates a new QueueAnalyticsLogging instance
        /// </summary>
        public QueueAnalyticsLogging()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueAnalyticsLogging instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueAnalyticsLogging(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Queues.Models.QueueRetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a QueueAnalyticsLogging instance as XML.
        /// </summary>
        /// <param name="value">The QueueAnalyticsLogging instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Logging".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueAnalyticsLogging value, string name = "Logging", string ns = "")
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
            _element.Add(Azure.Storage.Queues.Models.QueueRetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new QueueAnalyticsLogging instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueAnalyticsLogging instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueAnalyticsLogging FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueAnalyticsLogging _value = new Azure.Storage.Queues.Models.QueueAnalyticsLogging(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Version", ""));
            if (_child != null)
            {
                _value.Version = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Delete", ""));
            if (_child != null)
            {
                _value.Delete = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Read", ""));
            if (_child != null)
            {
                _value.Read = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Write", ""));
            if (_child != null)
            {
                _value.Write = bool.Parse(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("RetentionPolicy", ""));
            if (_child != null)
            {
                _value.RetentionPolicy = Azure.Storage.Queues.Models.QueueRetentionPolicy.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueAnalyticsLogging value);
    }
}
#endregion class QueueAnalyticsLogging

#region class QueueCorsRule
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// CORS is an HTTP feature that enables a web application running under one domain to access resources in another domain. Web browsers implement a security restriction known as same-origin policy that prevents a web page from calling APIs in a different domain; CORS provides a secure way to allow one domain (the origin domain) to call APIs in another domain
    /// </summary>
    public partial class QueueCorsRule
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
        /// Creates a new QueueCorsRule instance
        /// </summary>
        public QueueCorsRule() { }

        /// <summary>
        /// Serialize a QueueCorsRule instance as XML.
        /// </summary>
        /// <param name="value">The QueueCorsRule instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "CorsRule".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueCorsRule value, string name = "CorsRule", string ns = "")
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
        /// Deserializes XML into a new QueueCorsRule instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueCorsRule instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueCorsRule FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueCorsRule _value = new Azure.Storage.Queues.Models.QueueCorsRule();
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueCorsRule value);
    }
}
#endregion class QueueCorsRule

#region enum strings QueueErrorCode
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Error codes returned by the service
    /// </summary>
    public readonly struct QueueErrorCode : System.IEquatable<QueueErrorCode>
    {
        /// <summary>
        /// The QueueErrorCode value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueErrorCode"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public QueueErrorCode(string value) { _value = value ?? throw new System.ArgumentNullException(nameof(value)); }

        /// <summary>
        /// AccountAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountAlreadyExists { get; } = new QueueErrorCode(@"AccountAlreadyExists");

        /// <summary>
        /// AccountBeingCreated
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountBeingCreated { get; } = new QueueErrorCode(@"AccountBeingCreated");

        /// <summary>
        /// AccountIsDisabled
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AccountIsDisabled { get; } = new QueueErrorCode(@"AccountIsDisabled");

        /// <summary>
        /// AuthenticationFailed
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthenticationFailed { get; } = new QueueErrorCode(@"AuthenticationFailed");

        /// <summary>
        /// AuthorizationFailure
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationFailure { get; } = new QueueErrorCode(@"AuthorizationFailure");

        /// <summary>
        /// ConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionHeadersNotSupported { get; } = new QueueErrorCode(@"ConditionHeadersNotSupported");

        /// <summary>
        /// ConditionNotMet
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ConditionNotMet { get; } = new QueueErrorCode(@"ConditionNotMet");

        /// <summary>
        /// EmptyMetadataKey
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode EmptyMetadataKey { get; } = new QueueErrorCode(@"EmptyMetadataKey");

        /// <summary>
        /// InsufficientAccountPermissions
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InsufficientAccountPermissions { get; } = new QueueErrorCode(@"InsufficientAccountPermissions");

        /// <summary>
        /// InternalError
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InternalError { get; } = new QueueErrorCode(@"InternalError");

        /// <summary>
        /// InvalidAuthenticationInfo
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidAuthenticationInfo { get; } = new QueueErrorCode(@"InvalidAuthenticationInfo");

        /// <summary>
        /// InvalidHeaderValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHeaderValue { get; } = new QueueErrorCode(@"InvalidHeaderValue");

        /// <summary>
        /// InvalidHttpVerb
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidHttpVerb { get; } = new QueueErrorCode(@"InvalidHttpVerb");

        /// <summary>
        /// InvalidInput
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidInput { get; } = new QueueErrorCode(@"InvalidInput");

        /// <summary>
        /// InvalidMd5
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMd5 { get; } = new QueueErrorCode(@"InvalidMd5");

        /// <summary>
        /// InvalidMetadata
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMetadata { get; } = new QueueErrorCode(@"InvalidMetadata");

        /// <summary>
        /// InvalidQueryParameterValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidQueryParameterValue { get; } = new QueueErrorCode(@"InvalidQueryParameterValue");

        /// <summary>
        /// InvalidRange
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidRange { get; } = new QueueErrorCode(@"InvalidRange");

        /// <summary>
        /// InvalidResourceName
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidResourceName { get; } = new QueueErrorCode(@"InvalidResourceName");

        /// <summary>
        /// InvalidUri
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidUri { get; } = new QueueErrorCode(@"InvalidUri");

        /// <summary>
        /// InvalidXmlDocument
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlDocument { get; } = new QueueErrorCode(@"InvalidXmlDocument");

        /// <summary>
        /// InvalidXmlNodeValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidXmlNodeValue { get; } = new QueueErrorCode(@"InvalidXmlNodeValue");

        /// <summary>
        /// Md5Mismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode Md5Mismatch { get; } = new QueueErrorCode(@"Md5Mismatch");

        /// <summary>
        /// MetadataTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MetadataTooLarge { get; } = new QueueErrorCode(@"MetadataTooLarge");

        /// <summary>
        /// MissingContentLengthHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingContentLengthHeader { get; } = new QueueErrorCode(@"MissingContentLengthHeader");

        /// <summary>
        /// MissingRequiredQueryParameter
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredQueryParameter { get; } = new QueueErrorCode(@"MissingRequiredQueryParameter");

        /// <summary>
        /// MissingRequiredHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredHeader { get; } = new QueueErrorCode(@"MissingRequiredHeader");

        /// <summary>
        /// MissingRequiredXmlNode
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MissingRequiredXmlNode { get; } = new QueueErrorCode(@"MissingRequiredXmlNode");

        /// <summary>
        /// MultipleConditionHeadersNotSupported
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MultipleConditionHeadersNotSupported { get; } = new QueueErrorCode(@"MultipleConditionHeadersNotSupported");

        /// <summary>
        /// OperationTimedOut
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OperationTimedOut { get; } = new QueueErrorCode(@"OperationTimedOut");

        /// <summary>
        /// OutOfRangeInput
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeInput { get; } = new QueueErrorCode(@"OutOfRangeInput");

        /// <summary>
        /// OutOfRangeQueryParameterValue
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode OutOfRangeQueryParameterValue { get; } = new QueueErrorCode(@"OutOfRangeQueryParameterValue");

        /// <summary>
        /// RequestBodyTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestBodyTooLarge { get; } = new QueueErrorCode(@"RequestBodyTooLarge");

        /// <summary>
        /// ResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceTypeMismatch { get; } = new QueueErrorCode(@"ResourceTypeMismatch");

        /// <summary>
        /// RequestUrlFailedToParse
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode RequestUrlFailedToParse { get; } = new QueueErrorCode(@"RequestUrlFailedToParse");

        /// <summary>
        /// ResourceAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceAlreadyExists { get; } = new QueueErrorCode(@"ResourceAlreadyExists");

        /// <summary>
        /// ResourceNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ResourceNotFound { get; } = new QueueErrorCode(@"ResourceNotFound");

        /// <summary>
        /// ServerBusy
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode ServerBusy { get; } = new QueueErrorCode(@"ServerBusy");

        /// <summary>
        /// UnsupportedHeader
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHeader { get; } = new QueueErrorCode(@"UnsupportedHeader");

        /// <summary>
        /// UnsupportedXmlNode
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedXmlNode { get; } = new QueueErrorCode(@"UnsupportedXmlNode");

        /// <summary>
        /// UnsupportedQueryParameter
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedQueryParameter { get; } = new QueueErrorCode(@"UnsupportedQueryParameter");

        /// <summary>
        /// UnsupportedHttpVerb
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode UnsupportedHttpVerb { get; } = new QueueErrorCode(@"UnsupportedHttpVerb");

        /// <summary>
        /// InvalidMarker
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode InvalidMarker { get; } = new QueueErrorCode(@"InvalidMarker");

        /// <summary>
        /// MessageNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageNotFound { get; } = new QueueErrorCode(@"MessageNotFound");

        /// <summary>
        /// MessageTooLarge
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode MessageTooLarge { get; } = new QueueErrorCode(@"MessageTooLarge");

        /// <summary>
        /// PopReceiptMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode PopReceiptMismatch { get; } = new QueueErrorCode(@"PopReceiptMismatch");

        /// <summary>
        /// QueueAlreadyExists
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueAlreadyExists { get; } = new QueueErrorCode(@"QueueAlreadyExists");

        /// <summary>
        /// QueueBeingDeleted
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueBeingDeleted { get; } = new QueueErrorCode(@"QueueBeingDeleted");

        /// <summary>
        /// QueueDisabled
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueDisabled { get; } = new QueueErrorCode(@"QueueDisabled");

        /// <summary>
        /// QueueNotEmpty
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotEmpty { get; } = new QueueErrorCode(@"QueueNotEmpty");

        /// <summary>
        /// QueueNotFound
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode QueueNotFound { get; } = new QueueErrorCode(@"QueueNotFound");

        /// <summary>
        /// AuthorizationSourceIPMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationSourceIPMismatch { get; } = new QueueErrorCode(@"AuthorizationSourceIPMismatch");

        /// <summary>
        /// AuthorizationProtocolMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationProtocolMismatch { get; } = new QueueErrorCode(@"AuthorizationProtocolMismatch");

        /// <summary>
        /// AuthorizationPermissionMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationPermissionMismatch { get; } = new QueueErrorCode(@"AuthorizationPermissionMismatch");

        /// <summary>
        /// AuthorizationServiceMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationServiceMismatch { get; } = new QueueErrorCode(@"AuthorizationServiceMismatch");

        /// <summary>
        /// AuthorizationResourceTypeMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode AuthorizationResourceTypeMismatch { get; } = new QueueErrorCode(@"AuthorizationResourceTypeMismatch");

        /// <summary>
        /// FeatureVersionMismatch
        /// </summary>
        public static Azure.Storage.Queues.Models.QueueErrorCode FeatureVersionMismatch { get; } = new QueueErrorCode(@"FeatureVersionMismatch");

        /// <summary>
        /// Determines if two <see cref="QueueErrorCode"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="QueueErrorCode"/> to compare.</param>
        /// <param name="right">The second <see cref="QueueErrorCode"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="QueueErrorCode"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="QueueErrorCode"/> to compare.</param>
        /// <param name="right">The second <see cref="QueueErrorCode"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(Azure.Storage.Queues.Models.QueueErrorCode left, Azure.Storage.Queues.Models.QueueErrorCode right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="QueueErrorCode"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>The QueueErrorCode value.</returns>
        public static implicit operator QueueErrorCode(string value) => new Azure.Storage.Queues.Models.QueueErrorCode(value);

        /// <summary>
        /// Check if two <see cref="QueueErrorCode"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Azure.Storage.Queues.Models.QueueErrorCode other && Equals(other);

        /// <summary>
        /// Check if two <see cref="QueueErrorCode"/> instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(Azure.Storage.Queues.Models.QueueErrorCode other) => string.Equals(_value, other._value, System.StringComparison.Ordinal);

        /// <summary>
        /// Get a hash code for the <see cref="QueueErrorCode"/>.
        /// </summary>
        /// <returns>Hash code for the QueueErrorCode.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <summary>
        /// Convert the <see cref="QueueErrorCode"/> to a string.
        /// </summary>
        /// <returns>String representation of the QueueErrorCode.</returns>
        public override string ToString() => _value;
    }
}
#endregion enum strings QueueErrorCode

#region class QueueGeoReplication
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueGeoReplication
    /// </summary>
    public partial class QueueGeoReplication
    {
        /// <summary>
        /// The status of the secondary location
        /// </summary>
        public Azure.Storage.Queues.Models.QueueGeoReplicationStatus Status { get; internal set; }

        /// <summary>
        /// A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads.
        /// </summary>
        public System.DateTimeOffset? LastSyncedOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of QueueGeoReplication instances.
        /// You can use QueuesModelFactory.QueueGeoReplication instead.
        /// </summary>
        internal QueueGeoReplication() { }

        /// <summary>
        /// Deserializes XML into a new QueueGeoReplication instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueGeoReplication instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueGeoReplication FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueGeoReplication _value = new Azure.Storage.Queues.Models.QueueGeoReplication();
            _child = element.Element(System.Xml.Linq.XName.Get("Status", ""));
            if (_child != null && !string.IsNullOrEmpty(_child.Value))
            {
                _value.Status = Azure.Storage.Queues.QueueRestClient.Serialization.ParseQueueGeoReplicationStatus(_child.Value);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("LastSyncTime", ""));
            if (_child != null)
            {
                _value.LastSyncedOn = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueGeoReplication value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new QueueGeoReplication instance for mocking.
        /// </summary>
        public static QueueGeoReplication QueueGeoReplication(
            Azure.Storage.Queues.Models.QueueGeoReplicationStatus status,
            System.DateTimeOffset? lastSyncedOn = default)
        {
            return new QueueGeoReplication()
            {
                Status = status,
                LastSyncedOn = lastSyncedOn,
            };
        }
    }
}
#endregion class QueueGeoReplication

#region enum QueueGeoReplicationStatus
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The status of the secondary location
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum QueueGeoReplicationStatus
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

namespace Azure.Storage.Queues
{
    internal static partial class QueueRestClient
    {
        public static partial class Serialization
        {
            public static string ToString(Azure.Storage.Queues.Models.QueueGeoReplicationStatus value)
            {
                return value switch
                {
                    Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Live => "live",
                    Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Bootstrap => "bootstrap",
                    Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Unavailable => "unavailable",
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.QueueGeoReplicationStatus value.")
                };
            }

            public static Azure.Storage.Queues.Models.QueueGeoReplicationStatus ParseQueueGeoReplicationStatus(string value)
            {
                return value switch
                {
                    "live" => Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Live,
                    "bootstrap" => Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Bootstrap,
                    "unavailable" => Azure.Storage.Queues.Models.QueueGeoReplicationStatus.Unavailable,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(value), value, "Unknown Azure.Storage.Queues.Models.QueueGeoReplicationStatus value.")
                };
            }
        }
    }
}
#endregion enum QueueGeoReplicationStatus

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
        internal QueueItem()
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
                Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
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
            _child = element.Element(System.Xml.Linq.XName.Get("Name", ""));
            if (_child != null)
            {
                _value.Name = _child.Value;
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
            return new QueueItem()
            {
                Name = name,
                Metadata = metadata,
            };
        }
    }
}
#endregion class QueueItem

#region class QueueMetrics
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueMetrics
    /// </summary>
    public partial class QueueMetrics
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
        /// the retention policy
        /// </summary>
        public Azure.Storage.Queues.Models.QueueRetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        public bool? IncludeApis { get; set; }

        /// <summary>
        /// Creates a new QueueMetrics instance
        /// </summary>
        public QueueMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueMetrics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Queues.Models.QueueRetentionPolicy();
            }
        }

        /// <summary>
        /// Serialize a QueueMetrics instance as XML.
        /// </summary>
        /// <param name="value">The QueueMetrics instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "Metrics".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueMetrics value, string name = "Metrics", string ns = "")
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
            if (value.RetentionPolicy != null)
            {
                _element.Add(Azure.Storage.Queues.Models.QueueRetentionPolicy.ToXml(value.RetentionPolicy, "RetentionPolicy", ""));
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
        /// Deserializes XML into a new QueueMetrics instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueMetrics instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueMetrics FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueMetrics _value = new Azure.Storage.Queues.Models.QueueMetrics(true);
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
                _value.RetentionPolicy = Azure.Storage.Queues.Models.QueueRetentionPolicy.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("IncludeAPIs", ""));
            if (_child != null)
            {
                _value.IncludeApis = bool.Parse(_child.Value);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueMetrics value);
    }
}
#endregion class QueueMetrics

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
            Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
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
            return new QueueProperties()
            {
                Metadata = metadata,
                ApproximateMessagesCount = approximateMessagesCount,
            };
        }
    }
}
#endregion class QueueProperties

#region class QueueRetentionPolicy
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// the retention policy
    /// </summary>
    public partial class QueueRetentionPolicy
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
        /// Creates a new QueueRetentionPolicy instance
        /// </summary>
        public QueueRetentionPolicy() { }

        /// <summary>
        /// Serialize a QueueRetentionPolicy instance as XML.
        /// </summary>
        /// <param name="value">The QueueRetentionPolicy instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "RetentionPolicy".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueRetentionPolicy value, string name = "RetentionPolicy", string ns = "")
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
        /// Deserializes XML into a new QueueRetentionPolicy instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueRetentionPolicy instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueRetentionPolicy FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueRetentionPolicy _value = new Azure.Storage.Queues.Models.QueueRetentionPolicy();
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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueRetentionPolicy value);
    }
}
#endregion class QueueRetentionPolicy

#region class QueueSendMessage
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// A Message object which can be stored in a Queue
    /// </summary>
    internal partial class QueueSendMessage
    {
        /// <summary>
        /// The content of the message
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Creates a new QueueSendMessage instance
        /// </summary>
        public QueueSendMessage() { }

        /// <summary>
        /// Serialize a QueueSendMessage instance as XML.
        /// </summary>
        /// <param name="value">The QueueSendMessage instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "QueueMessage".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueSendMessage value, string name = "QueueMessage", string ns = "")
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
#endregion class QueueSendMessage

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
        public Azure.Storage.Queues.Models.QueueAnalyticsLogging Logging { get; set; }

        /// <summary>
        /// A summary of request statistics grouped by API in hourly aggregates for queues
        /// </summary>
        public Azure.Storage.Queues.Models.QueueMetrics HourMetrics { get; set; }

        /// <summary>
        /// a summary of request statistics grouped by API in minute aggregates for queues
        /// </summary>
        public Azure.Storage.Queues.Models.QueueMetrics MinuteMetrics { get; set; }

        /// <summary>
        /// The set of CORS rules.
        /// </summary>
        #pragma warning disable CA2227 // Collection properties should be readonly
        public System.Collections.Generic.IList<Azure.Storage.Queues.Models.QueueCorsRule> Cors { get; set; }
        #pragma warning restore CA2227 // Collection properties should be readonly

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
                Logging = new Azure.Storage.Queues.Models.QueueAnalyticsLogging();
                HourMetrics = new Azure.Storage.Queues.Models.QueueMetrics();
                MinuteMetrics = new Azure.Storage.Queues.Models.QueueMetrics();
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
                _element.Add(Azure.Storage.Queues.Models.QueueAnalyticsLogging.ToXml(value.Logging, "Logging", ""));
            }
            if (value.HourMetrics != null)
            {
                _element.Add(Azure.Storage.Queues.Models.QueueMetrics.ToXml(value.HourMetrics, "HourMetrics", ""));
            }
            if (value.MinuteMetrics != null)
            {
                _element.Add(Azure.Storage.Queues.Models.QueueMetrics.ToXml(value.MinuteMetrics, "MinuteMetrics", ""));
            }
            if (value.Cors != null)
            {
                System.Xml.Linq.XElement _elements = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get("Cors", ""));
                foreach (Azure.Storage.Queues.Models.QueueCorsRule _child in value.Cors)
                {
                    _elements.Add(Azure.Storage.Queues.Models.QueueCorsRule.ToXml(_child));
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
                _value.Logging = Azure.Storage.Queues.Models.QueueAnalyticsLogging.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("HourMetrics", ""));
            if (_child != null)
            {
                _value.HourMetrics = Azure.Storage.Queues.Models.QueueMetrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("MinuteMetrics", ""));
            if (_child != null)
            {
                _value.MinuteMetrics = Azure.Storage.Queues.Models.QueueMetrics.FromXml(_child);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("Cors", ""));
            if (_child != null)
            {
                _value.Cors = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        _child.Elements(System.Xml.Linq.XName.Get("CorsRule", "")),
                        e => Azure.Storage.Queues.Models.QueueCorsRule.FromXml(e)));
            }
            else
            {
                _value.Cors = new System.Collections.Generic.List<Azure.Storage.Queues.Models.QueueCorsRule>();
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueServiceProperties value);
    }
}
#endregion class QueueServiceProperties

#region class QueueServiceStatistics
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Statistics for the storage service.
    /// </summary>
    public partial class QueueServiceStatistics
    {
        /// <summary>
        /// GeoReplication
        /// </summary>
        public Azure.Storage.Queues.Models.QueueGeoReplication GeoReplication { get; internal set; }

        /// <summary>
        /// Creates a new QueueServiceStatistics instance
        /// </summary>
        internal QueueServiceStatistics()
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
                GeoReplication = new Azure.Storage.Queues.Models.QueueGeoReplication();
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
                _value.GeoReplication = Azure.Storage.Queues.Models.QueueGeoReplication.FromXml(_child);
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
            Azure.Storage.Queues.Models.QueueGeoReplication geoReplication = default)
        {
            return new QueueServiceStatistics()
            {
                GeoReplication = geoReplication,
            };
        }
    }
}
#endregion class QueueServiceStatistics

#region class QueueSignedIdentifier
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// signed identifier
    /// </summary>
    public partial class QueueSignedIdentifier
    {
        /// <summary>
        /// a unique id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An Access policy
        /// </summary>
        public Azure.Storage.Queues.Models.QueueAccessPolicy AccessPolicy { get; set; }

        /// <summary>
        /// Creates a new QueueSignedIdentifier instance
        /// </summary>
        public QueueSignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueSignedIdentifier instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueSignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                AccessPolicy = new Azure.Storage.Queues.Models.QueueAccessPolicy();
            }
        }

        /// <summary>
        /// Serialize a QueueSignedIdentifier instance as XML.
        /// </summary>
        /// <param name="value">The QueueSignedIdentifier instance to serialize.</param>
        /// <param name="name">An optional name to use for the root element instead of "SignedIdentifier".</param>
        /// <param name="ns">An optional namespace to use for the root element instead of "".</param>
        /// <returns>The serialized XML element.</returns>
        internal static System.Xml.Linq.XElement ToXml(Azure.Storage.Queues.Models.QueueSignedIdentifier value, string name = "SignedIdentifier", string ns = "")
        {
            System.Diagnostics.Debug.Assert(value != null);
            System.Xml.Linq.XElement _element = new System.Xml.Linq.XElement(System.Xml.Linq.XName.Get(name, ns));
            _element.Add(new System.Xml.Linq.XElement(
                System.Xml.Linq.XName.Get("Id", ""),
                value.Id));
            _element.Add(Azure.Storage.Queues.Models.QueueAccessPolicy.ToXml(value.AccessPolicy, "AccessPolicy", ""));
            return _element;
        }

        /// <summary>
        /// Deserializes XML into a new QueueSignedIdentifier instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized QueueSignedIdentifier instance.</returns>
        internal static Azure.Storage.Queues.Models.QueueSignedIdentifier FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.QueueSignedIdentifier _value = new Azure.Storage.Queues.Models.QueueSignedIdentifier(true);
            _child = element.Element(System.Xml.Linq.XName.Get("Id", ""));
            if (_child != null)
            {
                _value.Id = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("AccessPolicy", ""));
            if (_child != null)
            {
                _value.AccessPolicy = Azure.Storage.Queues.Models.QueueAccessPolicy.FromXml(_child);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.QueueSignedIdentifier value);
    }
}
#endregion class QueueSignedIdentifier

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
                QueueItems = new System.Collections.Generic.List<Azure.Storage.Queues.Models.QueueItem>();
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
            System.Xml.Linq.XAttribute _attribute;
            Azure.Storage.Queues.Models.QueuesSegment _value = new Azure.Storage.Queues.Models.QueuesSegment(true);
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

#region class SendReceipt
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Put Message on a Queue
    /// </summary>
    public partial class SendReceipt
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
        /// Prevent direct instantiation of SendReceipt instances.
        /// You can use QueuesModelFactory.SendReceipt instead.
        /// </summary>
        internal SendReceipt() { }

        /// <summary>
        /// Deserializes XML into a new SendReceipt instance.
        /// </summary>
        /// <param name="element">The XML element to deserialize.</param>
        /// <returns>A deserialized SendReceipt instance.</returns>
        internal static Azure.Storage.Queues.Models.SendReceipt FromXml(System.Xml.Linq.XElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);
            System.Xml.Linq.XElement _child;
            Azure.Storage.Queues.Models.SendReceipt _value = new Azure.Storage.Queues.Models.SendReceipt();
            _child = element.Element(System.Xml.Linq.XName.Get("MessageId", ""));
            if (_child != null)
            {
                _value.MessageId = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("InsertionTime", ""));
            if (_child != null)
            {
                _value.InsertionTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("ExpirationTime", ""));
            if (_child != null)
            {
                _value.ExpirationTime = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            _child = element.Element(System.Xml.Linq.XName.Get("PopReceipt", ""));
            if (_child != null)
            {
                _value.PopReceipt = _child.Value;
            }
            _child = element.Element(System.Xml.Linq.XName.Get("TimeNextVisible", ""));
            if (_child != null)
            {
                _value.TimeNextVisible = System.DateTimeOffset.Parse(_child.Value, System.Globalization.CultureInfo.InvariantCulture);
            }
            CustomizeFromXml(element, _value);
            return _value;
        }

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.SendReceipt value);
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new SendReceipt instance for mocking.
        /// </summary>
        public static SendReceipt SendReceipt(
            string messageId,
            System.DateTimeOffset insertionTime,
            System.DateTimeOffset expirationTime,
            string popReceipt,
            System.DateTimeOffset timeNextVisible)
        {
            return new SendReceipt()
            {
                MessageId = messageId,
                InsertionTime = insertionTime,
                ExpirationTime = expirationTime,
                PopReceipt = popReceipt,
                TimeNextVisible = timeNextVisible,
            };
        }
    }
}
#endregion class SendReceipt

#region class StorageError
namespace Azure.Storage.Queues.Models
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
        /// You can use QueuesModelFactory.StorageError instead.
        /// </summary>
        internal StorageError() { }

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

        static partial void CustomizeFromXml(System.Xml.Linq.XElement element, Azure.Storage.Queues.Models.StorageError value);
    }
}
#endregion class StorageError

#region class UpdateReceipt
namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// UpdateReceipt
    /// </summary>
    public partial class UpdateReceipt
    {
        /// <summary>
        /// The pop receipt of the queue message.
        /// </summary>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// A UTC date/time value that represents when the message will be visible on the queue.
        /// </summary>
        public System.DateTimeOffset NextVisibleOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of UpdateReceipt instances.
        /// You can use QueuesModelFactory.UpdateReceipt instead.
        /// </summary>
        internal UpdateReceipt() { }
    }

    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new UpdateReceipt instance for mocking.
        /// </summary>
        public static UpdateReceipt UpdateReceipt(
            string popReceipt,
            System.DateTimeOffset nextVisibleOn)
        {
            return new UpdateReceipt()
            {
                PopReceipt = popReceipt,
                NextVisibleOn = nextVisibleOn,
            };
        }
    }
}
#endregion class UpdateReceipt
#endregion Models


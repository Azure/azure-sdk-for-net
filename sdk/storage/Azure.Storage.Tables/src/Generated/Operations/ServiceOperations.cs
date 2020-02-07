// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    internal partial class ServiceOperations
    {
        private string url;
        private string Version;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ServiceOperations. </summary>
        public ServiceOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, string Version = "2018-10-10")
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (Version == null)
            {
                throw new ArgumentNullException(nameof(Version));
            }

            this.url = url;
            this.Version = Version;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateSetPropertiesRequest(int? timeout, string requestId, StorageServiceProperties storageServiceProperties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", "service", true);
            uri.AppendQuery("comp", "properties", true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(storageServiceProperties, "StorageServiceProperties");
            request.Content = content;
            return message;
        }
        /// <summary> Sets properties for a storage account&apos;s Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<SetPropertiesHeaders>> SetPropertiesAsync(int? timeout, string requestId, StorageServiceProperties storageServiceProperties, CancellationToken cancellationToken = default)
        {
            if (storageServiceProperties == null)
            {
                throw new ArgumentNullException(nameof(storageServiceProperties));
            }

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.SetProperties");
            scope.Start();
            try
            {
                using var message = CreateSetPropertiesRequest(timeout, requestId, storageServiceProperties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new SetPropertiesHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Sets properties for a storage account&apos;s Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<SetPropertiesHeaders> SetProperties(int? timeout, string requestId, StorageServiceProperties storageServiceProperties, CancellationToken cancellationToken = default)
        {
            if (storageServiceProperties == null)
            {
                throw new ArgumentNullException(nameof(storageServiceProperties));
            }

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.SetProperties");
            scope.Start();
            try
            {
                using var message = CreateSetPropertiesRequest(timeout, requestId, storageServiceProperties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new SetPropertiesHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetPropertiesRequest(int? timeout, string requestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", "service", true);
            uri.AppendQuery("comp", "properties", true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            return message;
        }
        /// <summary> gets the properties of a storage account&apos;s Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<StorageServiceProperties, GetPropertiesHeaders>> GetPropertiesAsync(int? timeout, string requestId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.GetProperties");
            scope.Start();
            try
            {
                using var message = CreateGetPropertiesRequest(timeout, requestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceProperties value = default;
                            var storageServiceProperties = document.Element("StorageServiceProperties");
                            if (storageServiceProperties != null)
                            {
                                value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServiceProperties);
                            }
                            var headers = new GetPropertiesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> gets the properties of a storage account&apos;s Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<StorageServiceProperties, GetPropertiesHeaders> GetProperties(int? timeout, string requestId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.GetProperties");
            scope.Start();
            try
            {
                using var message = CreateGetPropertiesRequest(timeout, requestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceProperties value = default;
                            var storageServiceProperties = document.Element("StorageServiceProperties");
                            if (storageServiceProperties != null)
                            {
                                value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServiceProperties);
                            }
                            var headers = new GetPropertiesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetStatisticsRequest(int? timeout, string requestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", "service", true);
            uri.AppendQuery("comp", "stats", true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            return message;
        }
        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<StorageServiceStats, GetStatisticsHeaders>> GetStatisticsAsync(int? timeout, string requestId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.GetStatistics");
            scope.Start();
            try
            {
                using var message = CreateGetStatisticsRequest(timeout, requestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceStats value = default;
                            var storageServiceStats = document.Element("StorageServiceStats");
                            if (storageServiceStats != null)
                            {
                                value = StorageServiceStats.DeserializeStorageServiceStats(storageServiceStats);
                            }
                            var headers = new GetStatisticsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<StorageServiceStats, GetStatisticsHeaders> GetStatistics(int? timeout, string requestId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("ServiceOperations.GetStatistics");
            scope.Start();
            try
            {
                using var message = CreateGetStatisticsRequest(timeout, requestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceStats value = default;
                            var storageServiceStats = document.Element("StorageServiceStats");
                            if (storageServiceStats != null)
                            {
                                value = StorageServiceStats.DeserializeStorageServiceStats(storageServiceStats);
                            }
                            var headers = new GetStatisticsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueClient.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using Microsoft.WindowsAzure.Storage.Auth.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Queue Service. This client is used to configure and execute requests against the Queue Service.
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Queue service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>
    public sealed partial class CloudQueueClient
    {
        /// <summary>
        /// Gets or sets the authentication scheme to use to sign HTTP requests.
        /// </summary>
        public AuthenticationScheme AuthenticationScheme
        {
            get
            {
                return this.authenticationScheme;
            }

            set
            {
                this.authenticationScheme = value;
            }
        }

        /// <summary>
        /// Gets the authentication handler used to sign requests.
        /// </summary>
        /// <value>Authentication handler.</value>
        internal HttpClientHandler AuthenticationHandler
        {
            get
            {
                HttpClientHandler authenticationHandler;
                if (this.Credentials.IsSharedKey)
                {
                    authenticationHandler = new SharedKeyAuthenticationHttpHandler(
                        this.GetCanonicalizer(),
                        this.Credentials,
                        this.Credentials.AccountName);
                }
                else
                {
                    authenticationHandler = new NoOpAuthenticationHttpHandler();
                }

                return authenticationHandler;
            }
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues.
        /// </summary>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> token returned by a previous listing operation.</param>
        /// <returns>A result segment of queues.</returns>
        public IAsyncOperation<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmentedAsync(null, QueueListingDetails.None, null, currentToken, null, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> token returned by a previous listing operation.</param>
        /// <returns>A result segment of queues.</returns>
        public IAsyncOperation<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, null, currentToken, null, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return queue metadata with the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> token returned by a previous listing operation.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment of queues.</returns>
        public IAsyncOperation<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) =>
            {
                ResultSegment<CloudQueue> resultSegment = await Executor.ExecuteAsync(
                    this.ListQueuesImpl(prefix, maxResults, detailsIncluded, modifiedOptions, currentToken),
                    this.RetryPolicy,
                    operationContext,
                    token);

                return new QueueResultSegment(resultSegment.Results, (QueueContinuationToken)resultSegment.ContinuationToken);
            });
        }

        /// <summary>
        /// Core implementation for the ListQueues method.
        /// </summary>
        /// <param name="prefix">The queue prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="currentToken">The continuation token.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the queues.</returns>
        private RESTCommand<ResultSegment<CloudQueue>> ListQueuesImpl(string prefix, int? maxResults, QueueListingDetails detailsIncluded, QueueRequestOptions options, QueueContinuationToken currentToken)
        {
            ListingContext listingContext = new ListingContext(prefix, maxResults)
            {
                Marker = currentToken != null ? currentToken.NextMarker : null
            };

            RESTCommand<ResultSegment<CloudQueue>> getCmd = new RESTCommand<ResultSegment<CloudQueue>>(this.Credentials, this.BaseUri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.Handler = this.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.List(cmd.Uri, cmd.ServerTimeoutInSeconds, listingContext, detailsIncluded, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    ListQueuesResponse listQueuesResponse = new ListQueuesResponse(cmd.ResponseStream);

                    List<CloudQueue> queuesList = new List<CloudQueue>(
                        listQueuesResponse.Queues.Select(item => new CloudQueue(item.Name, this)));

                    QueueContinuationToken continuationToken = null;
                    if (listQueuesResponse.NextMarker != null)
                    {
                        continuationToken = new QueueContinuationToken()
                        {
                            NextMarker = listQueuesResponse.NextMarker,
                        };
                    }

                    return new ResultSegment<CloudQueue>(queuesList)
                    {
                        ContinuationToken = continuationToken,
                    };
                });
            };

            return getCmd;
        }

        #region Analytics

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <returns>The blob service properties.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ServiceProperties> GetServicePropertiesAsync()
        {
            return this.GetServicePropertiesAsync(null, null);
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying <c>null</c> will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The blob service properties.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
              this.GetServicePropertiesImpl(modifiedOptions),
              modifiedOptions.RetryPolicy,
              operationContext,
              token));
        }

        private RESTCommand<ServiceProperties> GetServicePropertiesImpl(QueueRequestOptions requestOptions)
        {
            RESTCommand<ServiceProperties> retCmd = new RESTCommand<ServiceProperties>(this.Credentials, this.BaseUri);
            retCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);

            retCmd.RetrieveResponseStream = true;
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            retCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() => QueueHttpResponseParsers.ReadServiceProperties(cmd.ResponseStream));
            };

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <returns>The blob service properties.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties)
        {
            return this.SetServicePropertiesAsync(properties, null, null);
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying <c>null</c> will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The blob service properties.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                 this.SetServicePropertiesImpl(properties, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        private RESTCommand<NullType> SetServicePropertiesImpl(ServiceProperties properties, QueueRequestOptions requestOptions)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            try
            {
                properties.WriteServiceProperties(memoryStream);
            }
            catch (InvalidOperationException invalidOpException)
            {
                throw new ArgumentException(invalidOpException.Message, "properties");
            }

            RESTCommand<NullType> retCmd = new RESTCommand<NullType>(this.Credentials, this.BaseUri);
            retCmd.ApplyRequestOptions(requestOptions);
            retCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.SetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            retCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null /* md5 */, cmd, ctx);
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.Accepted, resp, null /* retVal */, cmd, ex);
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion
    }
}

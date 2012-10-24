// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobClient.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Auth.Protocol;
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Windows.Foundation;

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Blob Service. This client is used to configure and execute requests against the Blob Service. 
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Blob service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>
    public sealed partial class CloudBlobClient
    {
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
                        SharedKeyCanonicalizer.Instance,
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
        /// Returns a result segment containing a collection of containers.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <returns>A result segment of containers.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ContainerResultSegment> ListContainersSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.ListContainersSegmentedAsync(null /* prefix */, ContainerListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment of containers.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ContainerResultSegment> ListContainersSegmentedAsync(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return AsyncInfo.Run(async (token) =>
            {
                BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this);
                ResultSegment<CloudBlobContainer> resultSegment = await Executor.ExecuteAsync(
                    this.ListContainersImpl(prefix, detailsIncluded, currentToken, maxResults, modifiedOptions),
                    modifiedOptions.RetryPolicy,
                    operationContext,
                    token);

                return new ContainerResultSegment(resultSegment.Results, (BlobContinuationToken)resultSegment.ContinuationToken);
            });
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="currentToken">The continuation token.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmentedAsync(prefix, false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            string containerName;
            string listingPrefix;
            CloudBlobClient.ParseUserPrefix(prefix, out containerName, out listingPrefix);

            CloudBlobContainer container = this.GetContainerReference(containerName);
            return container.ListBlobsSegmentedAsync(listingPrefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext);
        }

        /// <summary>
        /// Gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param>
        /// <returns>A reference to the blob.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ICloudBlob> GetBlobReferenceFromServerAsync(Uri blobUri)
        {
            return this.GetBlobReferenceFromServerAsync(blobUri, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A reference to the blob.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ICloudBlob> GetBlobReferenceFromServerAsync(Uri blobUri, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtils.AssertNotNull("blobUri", blobUri);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.GetBlobReferenceImpl(blobUri, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Core implementation for the ListContainers method.
        /// </summary>
        /// <param name="prefix">The container prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="currentToken">The continuation token.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the containers.</returns>
        private RESTCommand<ResultSegment<CloudBlobContainer>> ListContainersImpl(string prefix, ContainerListingDetails detailsIncluded, BlobContinuationToken currentToken, int? maxResults, BlobRequestOptions options)
        {
            ListingContext listingContext = new ListingContext(prefix, maxResults)
            {
                Marker = currentToken != null ? currentToken.NextMarker : null
            };

            RESTCommand<ResultSegment<CloudBlobContainer>> getCmd = new RESTCommand<ResultSegment<CloudBlobContainer>>(this.Credentials, this.BaseUri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.Handler = this.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => ContainerHttpRequestMessageFactory.List(cmd.Uri, cmd.ServerTimeoutInSeconds, listingContext, detailsIncluded, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);
            getCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    ListContainersResponse listContainersResponse = new ListContainersResponse(cmd.ResponseStream);
                    List<CloudBlobContainer> containersList = new List<CloudBlobContainer>(
                        listContainersResponse.Containers.Select(item => new CloudBlobContainer(item.Properties, item.Metadata, item.Name, this)));
                    BlobContinuationToken continuationToken = null;
                    if (listContainersResponse.NextMarker != null)
                    {
                        continuationToken = new BlobContinuationToken()
                        {
                            NextMarker = listContainersResponse.NextMarker,
                        };
                    }

                    return new ResultSegment<CloudBlobContainer>(containersList)
                    {
                        ContinuationToken = continuationToken,
                    };
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Implements the FetchAttributes method. The attributes are updated immediately.
        /// </summary>
        /// <param name="blobUri">The URI of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that fetches the attributes.</returns>
        private RESTCommand<ICloudBlob> GetBlobReferenceImpl(Uri blobUri, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<ICloudBlob> getCmd = new RESTCommand<ICloudBlob>(this.Credentials, blobUri);

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => BlobHttpRequestMessageFactory.GetProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, null /* snapshot */, accessCondition, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);
                BlobAttributes attributes = new BlobAttributes();
                attributes.Uri = blobUri;
                CloudBlobSharedImpl.UpdateAfterFetchAttributes(attributes, resp, false);
                switch (attributes.Properties.BlobType)
                {
                    case BlobType.BlockBlob:
                        return new CloudBlockBlob(attributes, this);

                    case BlobType.PageBlob:
                        return new CloudPageBlob(attributes, this);

                    default:
                        throw new InvalidOperationException();
                }
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
            return this.GetServicePropertiesAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The blob service properties.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ServiceProperties> GetServicePropertiesAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(
                async (token) => await Executor.ExecuteAsync(
                    this.GetServicePropertiesImpl(modifiedOptions),
                    modifiedOptions.RetryPolicy,
                    operationContext,
                    token));
        }

        private RESTCommand<ServiceProperties> GetServicePropertiesImpl(BlobRequestOptions requestOptions)
        {
            RESTCommand<ServiceProperties> retCmd = new RESTCommand<ServiceProperties>(this.Credentials, this.BaseUri);
            retCmd.BuildRequest = (cmd, cnt, ctx) => BlobHttpRequestMessageFactory.GetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);

            retCmd.RetrieveResponseStream = true;
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);

            retCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                return Task.Factory.StartNew(() => BlobHttpResponseParsers.ReadServiceProperties(cmd.ResponseStream));
            };

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <returns>The properties of the blob service.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties)
        {
            return this.SetServicePropertiesAsync(properties, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The properties of the blob service.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties, BlobRequestOptions requestOptions, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(requestOptions, BlobType.Unspecified, this);
            operationContext = operationContext ?? new OperationContext();
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                 this.SetServicePropertiesImpl(properties, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        private RESTCommand<NullType> SetServicePropertiesImpl(ServiceProperties properties, BlobRequestOptions requestOptions)
        {
            MemoryStream memoryStream = new MemoryStream();
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
            retCmd.BuildRequest = (cmd, cnt, ctx) => BlobHttpRequestMessageFactory.SetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            retCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null /* md5 */, cmd, ctx);
            retCmd.RetrieveResponseStream = true;
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.Accepted, resp, null /* retVal */, cmd, ex, ctx);
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion
    }
}

//-----------------------------------------------------------------------
// <copyright file="CloudBlockBlob.cs" company="Microsoft">
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
// <summary>
//    Contains code for the CloudBlockBlob class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// Represents a blob that is uploaded as a set of blocks.
    /// </summary>
    public class CloudBlockBlob : CloudBlob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlockBlob(string blobAbsoluteUri, StorageCredentials credentials)
            : base(blobAbsoluteUri, credentials)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using a relative URI to the blob.
        /// </summary>
        /// <param name="blobUri">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="client">A client object that specifies the endpoint for the Blob service.</param>
        public CloudBlockBlob(string blobUri, CloudBlobClient client)
            : this(blobUri, null, client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using a relative URI to the blob.
        /// </summary>
        /// <param name="blobUri">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="client">A client object that specifies the endpoint for the Blob service.</param>
        public CloudBlockBlob(string blobUri, DateTime? snapshotTime, CloudBlobClient client)
            : base(blobUri, snapshotTime, client)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        public CloudBlockBlob(string blobAbsoluteUri)
            : base(blobAbsoluteUri)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="credentials">The account credentials.</param>
        /// <param name="usePathStyleUris"><c>True</c> to use path-style URIs; otherwise, <c>false</c>.</param>
        public CloudBlockBlob(string blobAbsoluteUri, StorageCredentials credentials, bool usePathStyleUris)
            : base(blobAbsoluteUri, credentials, usePathStyleUris)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="usePathStyleUris"><c>True</c> to use path-style URIs; otherwise, <c>false</c>.</param>
        public CloudBlockBlob(string blobAbsoluteUri, bool usePathStyleUris)
            : base(blobAbsoluteUri, usePathStyleUris)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class based on an existing blob.
        /// </summary>
        /// <param name="cloudBlob">The blob to clone.</param>
        internal CloudBlockBlob(CloudBlob cloudBlob) : base(cloudBlob)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="snapshotTime">The snapshot time.</param>
        internal CloudBlockBlob(BlobAttributes attributes, CloudBlobClient serviceClient, string snapshotTime)
            : base(attributes, serviceClient, snapshotTime)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using the specified blob Uri.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobUri">Relative Uri to the blob.</param>
        /// <param name="client">Existing Blob service client which provides the base address.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudBlockBlob(string blobUri, CloudBlobClient client, CloudBlobContainer containerReference)
            : this(blobUri, null, client, containerReference)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlockBlob"/> class using the specified blob Uri.
        /// If snapshotTime is not null, the blob instance represents a Snapshot.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobUri">Relative Uri to the blob.</param>
        /// <param name="snapshotTime">Snapshot time in case the blob is a snapshot.</param>
        /// <param name="client">Existing Blob service client which provides the base address.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudBlockBlob(string blobUri, DateTime? snapshotTime, CloudBlobClient client, CloudBlobContainer containerReference)
            : base(blobUri, snapshotTime, client, containerReference)
        {
            this.Properties.BlobType = BlobType.BlockBlob;
        }

        /// <summary>
        /// Returns an enumerable collection of the committed blocks comprising the blob.
        /// </summary>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        public IEnumerable<ListBlockItem> DownloadBlockList()
        {
            return this.DownloadBlockList(null, null);
        }

        /// <summary>
        /// Returns an enumerable collection of the committed blocks comprising the blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        public IEnumerable<ListBlockItem> DownloadBlockList(AccessCondition accessCondition, BlobRequestOptions options)
        {
            return this.DownloadBlockList(BlockListingFilter.Committed, accessCondition, options);
        }

        /// <summary>
        /// Returns an enumerable collection of the blob's blocks, using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        public IEnumerable<ListBlockItem> DownloadBlockList(BlockListingFilter blockListingFilter)
        {
            return this.DownloadBlockList(blockListingFilter, null, null);
        }

        /// <summary>
        /// Returns an enumerable collection of the blob's blocks, using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        public IEnumerable<ListBlockItem> DownloadBlockList(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<IEnumerable<ListBlockItem>>(
                (result) =>
                    {
                        return this.GetDownloadBlockList(blockListingFilter, accessCondition, fullModifier, result);
                    },
                fullModifier.RetryPolicy);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDownloadBlockList(BlockListingFilter blockListingFilter, AsyncCallback callback, object state)
        {
            return this.BeginDownloadBlockList(blockListingFilter, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDownloadBlockList(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<IEnumerable<ListBlockItem>>(
                (result) =>
                    {
                        return this.GetDownloadBlockList(blockListingFilter, accessCondition, fullModifier, result);
                    },
                fullModifier.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public IEnumerable<ListBlockItem> EndDownloadBlockList(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<IEnumerable<ListBlockItem>>(asyncResult);
        }
        
        /// <summary>
        /// Uploads a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        public void PutBlock(string blockId, Stream blockData, string contentMD5)
        {
            this.PutBlock(blockId, blockData, contentMD5, null, null);
        }

        /// <summary>
        /// Uploads a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void PutBlock(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            var position = blockData.Position;
            var retryPolicy = blockData.CanSeek ? fullModifier.RetryPolicy : RetryPolicies.NoRetry();

            TaskImplHelper.ExecuteImplWithRetry(
                () =>
                    {
                        if (blockData.CanSeek)
                        {
                            blockData.Position = position;
                        }

                        return this.UploadBlock(blockData, blockId, contentMD5, accessCondition, fullModifier);
                    },
                retryPolicy);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPutBlock(string blockId, Stream blockData, string contentMD5, AsyncCallback callback, object state)
        {
            return this.BeginPutBlock(blockId, blockData, contentMD5, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPutBlock(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            var position = blockData.Position;
            var retryPolicy = blockData.CanSeek ? fullModifier.RetryPolicy : RetryPolicies.NoRetry();

            return TaskImplHelper.BeginImplWithRetry(
                () =>
                    {
                        if (blockData.CanSeek)
                        {
                            blockData.Position = position;
                        }

                        return this.UploadBlock(blockData, blockId, contentMD5, accessCondition, fullModifier);
                    },
                retryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndPutBlock(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }
        
        /// <summary>
        /// Uploads a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        public void PutBlockList(IEnumerable<string> blockList)
        {
            this.PutBlockList(blockList, null, null);
        }

        /// <summary>
        /// Uploads a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void PutBlockList(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            List<PutBlockListItem> items = blockList.Select(i => { return new PutBlockListItem(i, BlockSearchMode.Latest); }).ToList();

            TaskImplHelper.ExecuteImplWithRetry(() => { return this.UploadBlockList(items, accessCondition, fullModifier); }, fullModifier.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPutBlockList(IEnumerable<string> blockList, AsyncCallback callback, object state)
        {
            return this.BeginPutBlockList(blockList, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPutBlockList(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            List<PutBlockListItem> items = blockList.Select(i => { return new PutBlockListItem(i, BlockSearchMode.Latest); }).ToList();

            return TaskImplHelper.BeginImplWithRetry(() => { return this.UploadBlockList(items, accessCondition, fullModifier); }, fullModifier.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a list of blocks to a new or existing blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndPutBlockList(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Uploads the block list.
        /// </summary>
        /// <param name="blocks">The blocks to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the block list.</returns>
        internal TaskSequence UploadBlockList(List<PutBlockListItem> blocks, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            HttpWebRequest request = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.PutBlockList(
                    this.TransformedAddress,
                    timeout,
                    this.Properties,
                    accessCondition));

            BlobRequest.AddMetadata(request, this.Metadata);

            using (var memoryStream = new SmallBlockMemoryStream(Constants.DefaultBufferSize))
            {
                BlobRequest.WriteBlockListBody(blocks, memoryStream);

                CommonUtils.ApplyRequestOptimizations(request, memoryStream.Length);

                memoryStream.Seek(0, SeekOrigin.Begin);

                // Compute the MD5
                var md5 = System.Security.Cryptography.MD5.Create();

                request.Headers[HttpRequestHeader.ContentMd5] = Convert.ToBase64String(md5.ComputeHash(memoryStream));

                this.ServiceClient.Credentials.SignRequest(request);

                memoryStream.Seek(0, SeekOrigin.Begin);

                // Retrieve the stream
                var requestStreamTask = request.GetRequestStreamAsync();
                yield return requestStreamTask;

                using (Stream requestStream = requestStreamTask.Result)
                {
                    // Copy the data
                    var copyTask = new InvokeTaskSequenceTask(() => { return memoryStream.WriteTo(requestStream); });
                    yield return copyTask;

                    // Materialize any exceptions
                    var scratch = copyTask.Result;
                }
            }

            // Get the response
            var responseTask = request.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return responseTask;

            using (var response = responseTask.Result as HttpWebResponse)
            {
                ParseSizeAndLastModified(response);
                this.Properties.Length = 0;
            }
        }

        /// <summary>
        /// Gets the download block list.
        /// </summary>
        /// <param name="typesOfBlocks">The types of blocks.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the download block list.</returns>
        internal TaskSequence GetDownloadBlockList(BlockListingFilter typesOfBlocks, AccessCondition accessCondition, BlobRequestOptions options, Action<IEnumerable<ListBlockItem>> setResult)
        {
            var request = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => BlobRequest.GetBlockList(this.TransformedAddress, timeout, this.SnapshotTime, typesOfBlocks, accessCondition));
            this.ServiceClient.Credentials.SignRequest(request);

            // Retrieve the stream
            var requestStreamTask = request.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return requestStreamTask;

            // Copy the data
            using (var response = requestStreamTask.Result as HttpWebResponse)
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var blockListResponse = new GetBlockListResponse(responseStream);

                    setResult(ParseResponse(blockListResponse));
                }

                this.ParseSizeAndLastModified(response);
            }
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <param name="blockListResponse">The block list response.</param>
        /// <returns>An enumerable list of <see cref="ListBlockItem"/> objects.</returns>
        private static IEnumerable<ListBlockItem> ParseResponse(GetBlockListResponse blockListResponse)
        {
            List<ListBlockItem> result = new List<ListBlockItem>();

            result.AddRange(blockListResponse.Blocks);

            return result;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="CloudPageBlob.cs" company="Microsoft">
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
//    Contains code for the CloudPageBlob class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a blob made up of a collection of pages.
    /// </summary>
    public class CloudPageBlob : CloudBlob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudPageBlob(string blobAddress, StorageCredentials credentials)
            : base(blobAddress, credentials)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob.</param>
        public CloudPageBlob(string blobAddress)
            : base(blobAddress)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using a relative URI to the blob.
        /// </summary>
        /// <param name="blobAddress">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the Blob service.</param>
        public CloudPageBlob(string blobAddress, CloudBlobClient serviceClient) 
            : this(blobAddress, null, serviceClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using a relative URI to the blob.
        /// </summary>
        /// <param name="blobAddress">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the Blob service.</param>
        public CloudPageBlob(string blobAddress, DateTime? snapshotTime, CloudBlobClient serviceClient)
            : base(blobAddress, snapshotTime, serviceClient)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class based on an existing <see cref="CloudBlob"/> object.
        /// </summary>
        /// <param name="cloudBlob">An object of type <see cref="CloudBlob"/>.</param>
        public CloudPageBlob(CloudBlob cloudBlob)
            : base(cloudBlob)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="snapshotTime">The snapshot time.</param>
        internal CloudPageBlob(BlobAttributes attributes, CloudBlobClient serviceClient, string snapshotTime)
            : base(attributes, serviceClient, snapshotTime)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c>, use path style Uris.</param>
        internal CloudPageBlob(string blobAddress, StorageCredentials credentials, bool usePathStyleUris)
            : base(blobAddress, credentials, usePathStyleUris)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c>, use path style Uris.</param>
        internal CloudPageBlob(string blobAddress, bool usePathStyleUris)
            : base(blobAddress, usePathStyleUris)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using the specified blob Uri.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudPageBlob(string blobAddress, CloudBlobClient serviceClient, CloudBlobContainer containerReference)
            : this(blobAddress, null, serviceClient, containerReference)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using the specified blob Uri.
        /// If snapshotTime is not null, the blob instance represents a Snapshot.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="snapshotTime">Snapshot time in case the blob is a snapshot.</param>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudPageBlob(string blobAddress, DateTime? snapshotTime, CloudBlobClient serviceClient, CloudBlobContainer containerReference)
            : base(blobAddress, snapshotTime, serviceClient, containerReference)
        {
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Creates a page blob.
        /// </summary>
        /// <param name="size">The maximum size of the page blob, in bytes.</param>
        public void Create(long size)
        {
            this.Create(size, null, null);
        }

        /// <summary>
        /// Creates a page blob.
        /// </summary>
        /// <param name="size">The maximum size of the page blob, in bytes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void Create(long size, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.CreateImpl(accessCondition, fullModifiers, size), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a page blob.
        /// </summary>
        /// <param name="size">The maximum size of the page blob, in bytes.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(long size, AsyncCallback callback, object state)
        {
            return this.BeginCreate(size, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a page blob.
        /// </summary>
        /// <param name="size">The maximum size of the blob, in bytes.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(long size, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.CreateImpl(accessCondition, fullModifiers, size), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a page blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreate(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Writes pages to a page blob.
        /// </summary>
        /// <param name="pageData">A stream providing the page data.</param>
        /// <param name="startOffset">The offset at which to begin writing, in bytes. The offset must be a multiple of 512.</param>
        public void WritePages(Stream pageData, long startOffset)
        {
            this.WritePages(pageData, startOffset, null, null);
        }

        /// <summary>
        /// Writes pages to a page blob.
        /// </summary>
        /// <param name="pageData">A stream providing the page data.</param>
        /// <param name="startOffset">The offset at which to begin writing, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void WritePages(Stream pageData, long startOffset, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            long sourcePosition = pageData.CanSeek ? pageData.Position : 0;

            TaskImplHelper.ExecuteImplWithRetry(
                () =>
            {
                if (pageData.CanSeek == false)
                {
                    sourcePosition--;
                }

                return this.WritePageImpl(pageData, startOffset, sourcePosition, accessCondition, fullModifiers);
            },
            fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to write pages to a page blob.
        /// </summary>
        /// <param name="pageData">A stream providing the page data.</param>
        /// <param name="startOffset">The offset at which to begin writing, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginWritePages(Stream pageData, long startOffset, AsyncCallback callback, object state)
        {
            return this.BeginWritePages(pageData, startOffset, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to write pages to a page blob.
        /// </summary>
        /// <param name="pageData">A stream providing the page data.</param>
        /// <param name="startOffset">The offset at which to begin writing, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginWritePages(Stream pageData, long startOffset, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            long sourcePosition = pageData.CanSeek ? pageData.Position : 0;

            return TaskImplHelper.BeginImplWithRetry(
                () =>
                {
                    if (pageData.CanSeek == false)
                    {
                        sourcePosition--;
                    }

                    return this.WritePageImpl(pageData, startOffset, sourcePosition, accessCondition, fullModifiers);
                },
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to write pages to a page blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndWritePages(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Clears pages from a page blob.
        /// </summary>
        /// <param name="startOffset">The offset at which to begin clearing pages, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="length">The length of the data range to be cleared, in bytes. The length must be a multiple of 512.</param>
        public void ClearPages(long startOffset, long length)
        {
            this.ClearPages(startOffset, length, null, null);
        }

        /// <summary>
        /// Clears pages from a page blob.
        /// </summary>
        /// <param name="startOffset">The offset at which to begin clearing pages, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="length">The length of the data range to be cleared, in bytes. The length must be a multiple of 512.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void ClearPages(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.ClearPageImpl(startOffset, length, accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to clear pages from a page blob.
        /// </summary>
        /// <param name="startOffset">The offset at which to begin clearing pages, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="length">The length of the data range to be cleared, in bytes. The length must be a multiple of 512.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginClearPages(long startOffset, long length, AsyncCallback callback, object state)
        {
            return this.BeginClearPages(startOffset, length, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to clear pages from a page blob.
        /// </summary>
        /// <param name="startOffset">The offset at which to begin clearing pages, in bytes. The offset must be a multiple of 512.</param>
        /// <param name="length">The length of the data range to be cleared, in bytes. The length must be a multiple of 512.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginClearPages(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.ClearPageImpl(startOffset, length, accessCondition, fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to clear pages from a page blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndClearPages(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Gets a collection of page ranges and their starting and ending bytes.
        /// </summary>
        /// <returns>An enumerable collection of page ranges.</returns>
        public IEnumerable<PageRange> GetPageRanges()
        {
            return this.GetPageRanges(null, null);
        }

        /// <summary>
        /// Gets a collection of page ranges and their starting and ending bytes.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of page ranges.</returns>
        public IEnumerable<PageRange> GetPageRanges(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<IEnumerable<PageRange>>(
                (setResult) => this.GetPageRangesImpl(accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a collection of page ranges and their starting and ending bytes.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPageRanges(AsyncCallback callback, object state)
        {
            return this.BeginGetPageRanges(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a collection of page ranges and their starting and ending bytes.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPageRanges(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<IEnumerable<PageRange>>(
                (setResult) => this.GetPageRangesImpl(accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a collection of page ranges and their starting and ending bytes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of page ranges.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public IEnumerable<PageRange> EndGetPageRanges(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<IEnumerable<PageRange>>(asyncResult);
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <returns>A stream for writing to the blob.</returns>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override BlobStream OpenWrite()
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A stream for writing to the blob.</returns>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override BlobStream OpenWrite(AccessCondition accessCondition, BlobRequestOptions options)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a blob from a stream.
        /// </summary>
        /// <param name="source">A stream that provides the blob content.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadFromStream(Stream source)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a blob from a stream.
        /// </summary>
        /// <param name="source">A stream that provides the blob content.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadFromStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a blob from a stream.
        /// </summary>
        /// <param name="source">The data stream to upload.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override IAsyncResult BeginUploadFromStream(Stream source, AsyncCallback callback, object state)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a blob from a stream.
        /// </summary>
        /// <param name="source">The data stream to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override IAsyncResult BeginUploadFromStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a blob from a stream.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void EndUploadFromStream(IAsyncResult asyncResult)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload, encoded as a UTF-8 string.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadText(string content)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object indicating the text encoding to use.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadText(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a file from the file system to a blob.
        /// </summary>
        /// <param name="fileName">The path and file name of the file to upload.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadFile(string fileName)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads a file from the file system to a blob.
        /// </summary>
        /// <param name="fileName">The path and file name of the file to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadFile(string fileName, AccessCondition accessCondition, BlobRequestOptions options)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads an array of bytes to a blob.
        /// </summary>
        /// <param name="content">The array of bytes to upload.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadByteArray(byte[] content)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Uploads an array of bytes to a blob.
        /// </summary>
        /// <param name="content">The array of bytes to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <exception cref="NotSupportedException">This operation is not supported on objects of type <see cref="CloudPageBlob"/>.</exception>
        public override void UploadByteArray(byte[] content, AccessCondition accessCondition, BlobRequestOptions options)
        {
            throw ThisCreationMethodNotSupportedException();
        }

        /// <summary>
        /// Creates an exception reporting that the creation method is not supported.
        /// </summary>
        /// <returns>The created exception.</returns>
        private static NotSupportedException ThisCreationMethodNotSupportedException()
        {
            string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.NotSupportedForPageBlob);
            return new NotSupportedException(errorMessage);
        }

        /// <summary>
        /// Implements the Create method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="sizeInBytes">The size in bytes.</param>
        /// <returns>A <see cref="TaskSequence"/> that creates the blob.</returns>
        private TaskSequence CreateImpl(AccessCondition accessCondition, BlobRequestOptions options, long sizeInBytes)
        {
            CommonUtils.AssertNotNull("options", options);

            this.Properties.BlobType = BlobType.PageBlob;

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Put(this.TransformedAddress, timeout, this.Properties, BlobType.PageBlob, sizeInBytes, accessCondition));

            BlobRequest.AddMetadata(webRequest, this.Metadata);

            this.ServiceClient.Credentials.SignRequest(webRequest);

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            // Parse the response
            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                this.ParseSizeAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Gets the page ranges impl.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> for getting the page ranges.</returns>
        private TaskSequence GetPageRangesImpl(AccessCondition accessCondition, BlobRequestOptions options, Action<IEnumerable<PageRange>> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.GetPageRanges(
                    this.TransformedAddress,
                    timeout,
                    this.SnapshotTime,
                    accessCondition));
            BlobRequest.AddMetadata(webRequest, this.Metadata);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                var getPageRangesResponse = BlobResponse.GetPageRanges(webResponse);
                List<PageRange> pageRanges = new List<PageRange>();

                // materialize response as we need to close the webResponse
                pageRanges.AddRange(getPageRangesResponse.PageRanges.ToList());

                setResult(pageRanges);

                this.ParseSizeAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Implementation method for the WritePage methods.
        /// </summary>
        /// <param name="pageData">The page data.</param>
        /// <param name="startOffset">The start offset.</param> 
        /// <param name="sourceStreamPosition">The beginning position of the source stream prior to execution, negative if stream is unseekable.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that writes the pages.</returns>
        private TaskSequence WritePageImpl(Stream pageData, long startOffset, long sourceStreamPosition, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            long length = pageData.Length;

            // Logic to rewind stream on a retry
            // HACK : for non seekable streams we need a way to detect the retry iteration so as to only attempt to execute once.
            // The first attempt will have SourceStreamPosition = -1, which means the first iteration on a non seekable stream.
            // The second attempt will have SourceStreamPosition = -2, anything below -1 is considered an abort. Since the Impl method
            // does not have an executino context to be aware of what iteration is used the SourceStreamPosition is utilized as counter to
            // differentiate between the first attempt and a retry. 
            if (sourceStreamPosition >= 0 && pageData.CanSeek)
            {
                if (sourceStreamPosition != pageData.Position)
                {
                    pageData.Seek(sourceStreamPosition, 0);
                }
            }
            else if (sourceStreamPosition < -1)
            {
                // TODO : Need to rewrite this to support buffering in XSCL2 so that retries can work on non seekable streams              
                throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, SR.CannotRetryNonSeekableStreamError));
            }

            if (startOffset % Protocol.Constants.PageSize != 0)
            {
                CommonUtils.ArgumentOutOfRange("startOffset", startOffset);
            }
           
            // TODO should reuse sourceStreamPoisition when the HACK above is removed, for readability using a new local variable
            long rangeStreamOffset = pageData.CanSeek ? pageData.Position : 0;

            PutPageProperties properties = new PutPageProperties()
            {
                Range = new PageRange(startOffset, startOffset + length - rangeStreamOffset - 1),
                PageWrite = PageWrite.Update,
            };

            if ((1 + properties.Range.EndOffset - properties.Range.StartOffset) % Protocol.Constants.PageSize != 0 ||
                (1 + properties.Range.EndOffset - properties.Range.StartOffset) == 0)
            {
                CommonUtils.ArgumentOutOfRange("pageData", pageData);
            }

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.PutPage(this.TransformedAddress, timeout, properties, accessCondition));

            ////BlobRequest.AddMetadata(webRequest, this.Metadata);

            // Retrieve the stream
            var requestStreamTask = webRequest.GetRequestStreamAsync();
            yield return requestStreamTask;

            // Copy the data
            using (var outputStream = requestStreamTask.Result)
            {
                var copyTask = new InvokeTaskSequenceTask(() => { return pageData.WriteTo(outputStream); });
                yield return copyTask;

                // Materialize any exceptions
                var scratch = copyTask.Result;
            }

            // signing request needs Size to be set
            this.ServiceClient.Credentials.SignRequest(webRequest);

            // Get the response
            var responseTask = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return responseTask;

            // Parse the response
            using (HttpWebResponse webResponse = responseTask.Result as HttpWebResponse)
            {
                this.ParseSizeAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Implementation method for the ClearPage methods.
        /// </summary>
        /// <param name="startOffset">The start offset. Must be multiples of 512.</param>
        /// <param name="length">Length of the data range to be cleared. Must be multiples of 512.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that writes the pages.</returns>
        private TaskSequence ClearPageImpl(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            if (startOffset < 0 || startOffset % Protocol.Constants.PageSize != 0)
            {
                CommonUtils.ArgumentOutOfRange("startOffset", startOffset);
            }

            if (length <= 0 || length % Protocol.Constants.PageSize != 0)
            {
                CommonUtils.ArgumentOutOfRange("length", length);
            }

            PutPageProperties properties = new PutPageProperties()
            {
                Range = new PageRange(startOffset, startOffset + length - 1),
                PageWrite = PageWrite.Clear,
            };

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.PutPage(this.TransformedAddress, timeout, properties, accessCondition));

            webRequest.ContentLength = 0;

            // signing request needs Size to be set
            this.ServiceClient.Credentials.SignRequest(webRequest);

            // Get the response
            var responseTask = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return responseTask;

            // Parse the response
            using (HttpWebResponse webResponse = responseTask.Result as HttpWebResponse)
            {
                this.ParseSizeAndLastModified(webResponse);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS0618

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Batch.Models;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A Class representing a BatchAccountCertificate along with the instance operations that can be performed on it.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BatchAccountCertificateResource : ArmResource, IJsonModel<BatchAccountCertificateData>, IPersistableModel<BatchAccountCertificateData>
    {
        /// <summary> The resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Batch/batchAccounts/certificates";

        /// <summary> Initializes a new instance of the <see cref="BatchAccountCertificateResource"/> class. </summary>
        protected BatchAccountCertificateResource()
        {
        }

        /// <summary> Gets the data representing this resource. </summary>
        public virtual BatchAccountCertificateData Data => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets whether this resource has data. </summary>
        public virtual bool HasData => false;

        /// <summary> Generate the resource identifier of a <see cref="BatchAccountCertificateResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string certificateName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/certificates/{certificateName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Gets the certificate. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> Get(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets the certificate. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Deletes the specified certificate. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Deletes the specified certificate. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Updates the properties of an existing certificate. </summary>
        /// <param name="content"> Certificate entity to update. </param>
        /// <param name="ifMatch"> ETag of the certificate entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> Update(BatchAccountCertificateCreateOrUpdateContent content, ETag? ifMatch = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Updates the properties of an existing certificate. </summary>
        /// <param name="content"> Certificate entity to update. </param>
        /// <param name="ifMatch"> ETag of the certificate entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> UpdateAsync(BatchAccountCertificateCreateOrUpdateContent content, ETag? ifMatch = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Cancels a failed deletion of a certificate from the specified account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> CancelDeletion(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Cancels a failed deletion of a certificate from the specified account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> CancelDeletionAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> RemoveTag(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        BatchAccountCertificateData IJsonModel<BatchAccountCertificateData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

        void IJsonModel<BatchAccountCertificateData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();

        BatchAccountCertificateData IPersistableModel<BatchAccountCertificateData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

        string IPersistableModel<BatchAccountCertificateData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<BatchAccountCertificateData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
    }
}

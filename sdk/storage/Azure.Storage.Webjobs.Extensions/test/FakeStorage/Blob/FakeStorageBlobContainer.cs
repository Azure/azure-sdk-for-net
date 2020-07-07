// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace FakeStorage
{
    public class FakeStorageBlobContainer : CloudBlobContainer
    {
        internal readonly MemoryBlobStore _store;
        internal readonly FakeStorageBlobClient _client;

        public FakeStorageBlobContainer(FakeStorageBlobClient client, string containerName)
             : base(client.GetContainerUri(containerName))
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ArgumentException(nameof(containerName));
            }
            _store = client._store;
            _client = client;

            this.SetInternalProperty(nameof(ServiceClient), client);
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeStorageBlobContainer other)
            {
                return this.Uri == other.Uri;
            }
            return false;
        }

        internal Uri GetBlobUri(string blobName)
        {
            return new Uri(this.Uri.ToString() + "/" + blobName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override CloudPageBlob GetPageBlobReference(string blobName)
        {
            return new FakeStoragePageBlob(blobName, this);
        }

        public override CloudPageBlob GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            return new FakeStoragePageBlob(blobName, this);
        }

        #region GetBlockBlobReference
        public override CloudBlockBlob GetBlockBlobReference(string blobName)
        {
            return base.GetBlockBlobReference(blobName);
        }

        public override CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            try
            {
                // $$$ improve hook
                var blob = _store.GetBlobReferenceFromServer(this, this.Name, blobName);
                if (blob is CloudBlockBlob b)
                {
                    return b;
                }
            }
            catch { }
            return new FakeStorageBlockBlob(blobName, this);
        }
        #endregion

        public override CloudAppendBlob GetAppendBlobReference(string blobName)
        {
            return new FakeStorageAppendBlob(blobName, this);
        }

        public override CloudAppendBlob GetAppendBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            return new FakeStorageAppendBlob(blobName, this);
        }

        public override CloudBlob GetBlobReference(string blobName)
        {
            throw new NotImplementedException();
        }

        public override CloudBlob GetBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            throw new NotImplementedException();
        }

        // $$$ will built-in just work? 
        public override CloudBlobDirectory GetDirectoryReference(string relativeAddress)
        {
            // TestExtensions.NewCloudBlobDirectory()
            return base.GetDirectoryReference(relativeAddress);
        }

        public override Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        public override Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> CreateIfNotExistsAsync()
        {
            return base.CreateIfNotExistsAsync();
        }

        public override Task<bool> CreateIfNotExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateIfNotExistsAsync(options, operationContext);
        }

        public override Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateIfNotExistsAsync(accessType, options, operationContext);
        }

        public override Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            _store.CreateIfNotExists(this.Name);
            return Task.FromResult(true); // $$$ what is this
        }

        public override Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteIfExistsAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName)
        {
            // throw new NotImplementedException();
            // return base.GetBlobReferenceFromServerAsync(blobName);
            var blob = _store.GetBlobReferenceFromServer(this, this.Name, blobName);
            return Task.FromResult<ICloudBlob>(blob);
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            //throw new NotImplementedException();
            // return base.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext);
            var blob = _store.GetBlobReferenceFromServer(this, this.Name, blobName);
            return Task.FromResult<ICloudBlob>(blob);
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            var blob = _store.GetBlobReferenceFromServer(this, this.Name, blobName);
            return Task.FromResult<ICloudBlob>(blob);
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return base.ListBlobsSegmentedAsync(currentToken);
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return base.ListBlobsSegmentedAsync(prefix, currentToken);
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return ListBlobsSegmentedCoreAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, CancellationToken.None);
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return ListBlobsSegmentedCoreAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken);
        }

        private Task<BlobResultSegment> ListBlobsSegmentedCoreAsync(string prefix, bool useFlatBlobListing,
         BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken,
         BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            if (options != null)
            {
                throw new NotImplementedException();
            }           

            string fullPrefix;

            if (!String.IsNullOrEmpty(prefix))
            {
                fullPrefix = this.Name + "/" + prefix;
            }
            else
            {
                fullPrefix = this.Name;
            }

            Func<string, FakeStorageBlobContainer> containerFactory = (name) =>
            {
                if (name != this.Name)
                {
                    throw new InvalidOperationException();
                }

                return this;
            };
            var segment = _store.ListBlobsSegmented(containerFactory, fullPrefix,
                useFlatBlobListing, blobListingDetails, maxResults, currentToken);
            return Task.FromResult(segment);
        }

        public override Task SetPermissionsAsync(BlobContainerPermissions permissions)
        {
            throw new NotImplementedException();
        }

        public override Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<BlobContainerPermissions> GetPermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> ExistsAsync()
        {
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(_store.Exists(this.Name));
        }

        public override Task FetchAttributesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task SetMetadataAsync()
        {
            throw new NotImplementedException();
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            throw new NotImplementedException();
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            throw new NotImplementedException();
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            throw new NotImplementedException();
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            throw new NotImplementedException();
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            throw new NotImplementedException();
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

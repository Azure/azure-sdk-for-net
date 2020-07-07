// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace FakeStorage
{
    internal class FakeStoragePageBlob : CloudPageBlob
    {
        private readonly MemoryBlobStore _store;
        private readonly string _blobName;
        private readonly FakeStorageBlobContainer _parent;
        private readonly string _containerName;
        private readonly IDictionary<string, string> _metadata;
        private readonly FakeStorageBlobProperties _properties;
        
        public FakeStoragePageBlob(string blobName, FakeStorageBlobContainer parent, FakeStorageBlobProperties properties = null) :
            base(parent.GetBlobUri(blobName))
        {
            _store = parent._store;
            _blobName = blobName;
            _parent = parent;
            _containerName = parent.Name;
            _metadata = new Dictionary<string, string>();
            if (properties != null)
            {
                _properties = properties;
                ApplyProperties();
            }
            else
            {
                _properties = new FakeStorageBlobProperties();
            }

            this.SetInternalProperty(nameof(ServiceClient), parent._client);
        }

        private void ApplyProperties()
        {
            if (_properties != null)
            {
                var realProps = _properties.GetRealProperties();
                realProps.SetInternalProperty(nameof(BlobType), BlobType.PageBlob);

                // { return this.attributes.Properties; }
                new Wrapper(this).GetField("attributes").SetInternalField("Properties", realProps);
            }
        }

        public override Task AbortCopyAsync(string copyId)
        {
            return base.AbortCopyAsync(copyId);
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AbortCopyAsync(copyId, accessCondition, options, operationContext);
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AbortCopyAsync(copyId, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            return base.AcquireLeaseAsync(leaseTime, proposedLeaseId);
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext);
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return base.BreakLeaseAsync(breakPeriod);
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext);
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return base.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return base.ChangeLeaseAsync(proposedLeaseId, accessCondition);
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext);
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task ClearPagesAsync(long startOffset, long length)
        {
            return base.ClearPagesAsync(startOffset, length);
        }

        public override Task ClearPagesAsync(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.ClearPagesAsync(startOffset, length, accessCondition, options, operationContext);
        }

        public override Task ClearPagesAsync(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ClearPagesAsync(startOffset, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task CreateAsync(long size)
        {
            return base.CreateAsync(size);
        }

        public override Task CreateAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateAsync(size, accessCondition, options, operationContext);
        }

        public override Task CreateAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.CreateAsync(size, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task CreateAsync(long size, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.CreateAsync(size, premiumBlobTier, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<CloudPageBlob> CreateSnapshotAsync()
        {
            return base.CreateSnapshotAsync();
        }

        public override Task<CloudPageBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateSnapshotAsync(metadata, accessCondition, options, operationContext);
        }

        public override Task<CloudPageBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.CreateSnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task DeleteAsync()
        {
            return base.DeleteAsync();
        }

        public override Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext);
        }

        public override Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<bool> DeleteIfExistsAsync()
        {
            throw new NotImplementedException();
            // return base.DeleteIfExistsAsync();
        }

        public override Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DeleteIfExistsAsync(deleteSnapshotsOption, accessCondition, options, operationContext);
        }

        public override Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DeleteIfExistsAsync(deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length)
        {
            return base.DownloadRangeToByteArrayAsync(target, index, blobOffset, length);
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext);
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); 
            // return base.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length)
        {
            return base.DownloadRangeToStreamAsync(target, offset, length);
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext);
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index)
        {
            return base.DownloadToByteArrayAsync(target, index);
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext);
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task DownloadToFileAsync(string path, FileMode mode)
        {
            return base.DownloadToFileAsync(path, mode);
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadToFileAsync(path, mode, accessCondition, options, operationContext);
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DownloadToFileAsync(path, mode, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task DownloadToStreamAsync(Stream target)
        {
            return base.DownloadToStreamAsync(target);
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadToStreamAsync(target, accessCondition, options, operationContext);
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DownloadToStreamAsync(target, accessCondition, options, operationContext, cancellationToken);
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeStoragePageBlob other) {
                return this.Uri == other.Uri;
            }
            return false;
        }

        public override Task<bool> ExistsAsync()
        {
            return base.ExistsAsync();
        }

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return base.ExistsAsync(options, operationContext);
        }

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return base.ExistsAsync(options, operationContext, cancellationToken);
        }

        public override Task FetchAttributesAsync()
        {
            return base.FetchAttributesAsync();
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.FetchAttributesAsync(accessCondition, options, operationContext);
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task<IEnumerable<PageRange>> GetPageRangesAsync()
        {
            return base.GetPageRangesAsync();
        }

        public override Task<IEnumerable<PageRange>> GetPageRangesAsync(long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.GetPageRangesAsync(offset, length, accessCondition, options, operationContext);
        }

        public override Task<IEnumerable<PageRange>> GetPageRangesAsync(long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.GetPageRangesAsync(offset, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime)
        {
            return base.GetPageRangesDiffAsync(previousSnapshotTime);
        }

        public override Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.GetPageRangesDiffAsync(previousSnapshotTime, offset, length, accessCondition, options, operationContext);
        }

        public override Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.GetPageRangesDiffAsync(previousSnapshotTime, offset, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<Stream> OpenReadAsync()
        {
            return base.OpenReadAsync();
        }

        public override Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.OpenReadAsync(accessCondition, options, operationContext);
        }

        public override Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.OpenReadAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(long? size)
        {
            return base.OpenWriteAsync(size);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(long? size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.OpenWriteAsync(size, accessCondition, options, operationContext);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(long? size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.OpenWriteAsync(size, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(long? size, PremiumPageBlobTier? premiumPageBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            CloudBlobStream stream = _store.OpenWritePage(_containerName, _blobName, size, _metadata);
            return Task.FromResult(stream);
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return base.ReleaseLeaseAsync(accessCondition);
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.ReleaseLeaseAsync(accessCondition, options, operationContext);
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ReleaseLeaseAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            return base.RenewLeaseAsync(accessCondition);
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.RenewLeaseAsync(accessCondition, options, operationContext);
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.RenewLeaseAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task ResizeAsync(long size)
        {
            return base.ResizeAsync(size);
        }

        public override Task ResizeAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.ResizeAsync(size, accessCondition, options, operationContext);
        }

        public override Task ResizeAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ResizeAsync(size, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task SetMetadataAsync()
        {
            return base.SetMetadataAsync();
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.SetMetadataAsync(accessCondition, options, operationContext);
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetMetadataAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier)
        {
            return base.SetPremiumBlobTierAsync(premiumBlobTier);
        }

        public override Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.SetPremiumBlobTierAsync(premiumBlobTier, options, operationContext);
        }

        public override Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetPremiumBlobTierAsync(premiumBlobTier, options, operationContext, cancellationToken);
        }

        public override Task SetPropertiesAsync()
        {
            return base.SetPropertiesAsync();
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.SetPropertiesAsync(accessCondition, options, operationContext);
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetPropertiesAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber)
        {
            return base.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber);
        }

        public override Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber, accessCondition, options, operationContext);
        }

        public override Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<CloudBlob> SnapshotAsync()
        {
            return base.SnapshotAsync();
        }

        public override Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.SnapshotAsync(metadata, accessCondition, options, operationContext);
        }

        public override Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> StartCopyAsync(Uri source)
        {
            return base.StartCopyAsync(source);
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext);
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> StartCopyAsync(CloudPageBlob source)
        {
            return base.StartCopyAsync(source);
        }

        public override Task<string> StartCopyAsync(CloudPageBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext);
        }

        public override Task<string> StartCopyAsync(CloudPageBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> StartCopyAsync(CloudPageBlob source, PremiumPageBlobTier? premiumBlobTier, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.StartCopyAsync(source, premiumBlobTier, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> StartIncrementalCopyAsync(CloudPageBlob sourceSnapshot)
        {
            return base.StartIncrementalCopyAsync(sourceSnapshot);
        }

        public override Task<string> StartIncrementalCopyAsync(CloudPageBlob source, CancellationToken cancellationToken)
        {
            return base.StartIncrementalCopyAsync(source, cancellationToken);
        }

        public override Task<string> StartIncrementalCopyAsync(CloudPageBlob sourceSnapshot, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.StartIncrementalCopyAsync(sourceSnapshot, destAccessCondition, options, operationContext, cancellationToken);
        }

        public override Task<string> StartIncrementalCopyAsync(Uri sourceSnapshot, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.StartIncrementalCopyAsync(sourceSnapshot, destAccessCondition, options, operationContext, cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return base.UploadFromByteArrayAsync(buffer, index, count);
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext);
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.UploadFromByteArrayAsync(buffer, index, count, premiumBlobTier, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromFileAsync(string path)
        {
            return base.UploadFromFileAsync(path);
        }

        public override Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.UploadFromFileAsync(path, accessCondition, options, operationContext);
        }

        public override Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.UploadFromFileAsync(path, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromStreamAsync(Stream source)
        {
            return base.UploadFromStreamAsync(source);
        }

        public override Task UploadFromStreamAsync(Stream source, long length)
        {
            return base.UploadFromStreamAsync(source, length);
        }

        public override Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.UploadFromStreamAsync(source, accessCondition, options, operationContext);
        }

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.UploadFromStreamAsync(source, length, accessCondition, options, operationContext);
        }

        public override Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.UploadFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromStreamAsync(Stream source, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.UploadFromStreamAsync(source, premiumBlobTier, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task UploadFromStreamAsync(Stream source, long length, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.UploadFromStreamAsync(source, length, premiumBlobTier, accessCondition, options, operationContext, cancellationToken);
        }
    }
}

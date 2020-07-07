// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace FakeStorage
{
    internal class FakeStorageAppendBlob : CloudAppendBlob
    {
        private readonly MemoryBlobStore _store;
        private readonly string _blobName;
        private readonly FakeStorageBlobContainer _parent;
        private readonly string _containerName;
        private readonly IDictionary<string, string> _metadata;
        private readonly FakeStorageBlobProperties _properties;

        public FakeStorageAppendBlob(string blobName, FakeStorageBlobContainer parent, FakeStorageBlobProperties properties = null) :
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

            // currentBlob.Properties.LastModified.Value.UtcDateTime;
            // CloudBlob.Properties  {   return this.attributes.Properties }
            //   where attributes is internal BlobAttributes class. 
            // return BlobProperties

            this.SetInternalProperty(nameof(ServiceClient), parent._client);
        }

        private void ApplyProperties()
        {
            if (_properties != null)
            {
                var realProps = _properties.GetRealProperties();
                realProps.SetInternalProperty(nameof(BlobType), BlobType.AppendBlob);

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
            //return base.AbortCopyAsync(copyId, accessCondition, options, operationContext, cancellationToken);
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

        public override Task<long> AppendBlockAsync(Stream blockData, string contentMD5)
        {
            return base.AppendBlockAsync(blockData, contentMD5);
        }

        public override Task<long> AppendBlockAsync(Stream blockData, string contentMD5, AccessCondition accesscondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendBlockAsync(blockData, contentMD5, accesscondition, options, operationContext);
        }

        public override Task<long> AppendBlockAsync(Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AppendBlockAsync(blockData, contentMD5, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task AppendFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return base.AppendFromByteArrayAsync(buffer, index, count);
        }

        public override Task AppendFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext);
        }

        public override Task AppendFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AppendFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task AppendFromFileAsync(string path)
        {
            return base.AppendFromFileAsync(path);
        }

        public override Task AppendFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendFromFileAsync(path, accessCondition, options, operationContext);
        }

        public override Task AppendFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AppendFromFileAsync(path, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task AppendFromStreamAsync(Stream source)
        {
            return base.AppendFromStreamAsync(source);
        }

        public override Task AppendFromStreamAsync(Stream source, long length)
        {
            return base.AppendFromStreamAsync(source, length);
        }

        public override Task AppendFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendFromStreamAsync(source, accessCondition, options, operationContext);
        }

        public override Task AppendFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendFromStreamAsync(source, length, accessCondition, options, operationContext);
        }

        public override Task AppendFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return base.AppendFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task AppendFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AppendFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task AppendTextAsync(string content)
        {
            return base.AppendTextAsync(content);
        }

        public override Task AppendTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.AppendTextAsync(content, encoding, accessCondition, options, operationContext);
        }

        public override Task AppendTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.AppendTextAsync(content, encoding, accessCondition, options, operationContext, cancellationToken);
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
            // return base.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, cancellationToken);
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

        public override Task CreateOrReplaceAsync()
        {
            return base.CreateOrReplaceAsync();
        }

        public override Task CreateOrReplaceAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateOrReplaceAsync(accessCondition, options, operationContext);
        }

        public override Task CreateOrReplaceAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.CreateOrReplaceAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<CloudAppendBlob> CreateSnapshotAsync()
        {
            return base.CreateSnapshotAsync();
        }

        public override Task<CloudAppendBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.CreateSnapshotAsync(metadata, accessCondition, options, operationContext);
        }

        public override Task<CloudAppendBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
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
            throw new NotImplementedException();
            // return base.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken);
        }

        public override Task<bool> DeleteIfExistsAsync()
        {
            return base.DeleteIfExistsAsync();
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

        public override Task<string> DownloadTextAsync()
        {
            return base.DownloadTextAsync();
        }

        public override Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.DownloadTextAsync(encoding, accessCondition, options, operationContext);
        }

        public override Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.DownloadTextAsync(encoding, accessCondition, options, operationContext, cancellationToken);
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
            if (obj is FakeStorageAppendBlob other)
            {
                return other.Uri == this.Uri;
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
            // return base.ExistsAsync(options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
            // return base.OpenReadAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
        }

        public override Task<CloudBlobStream> OpenWriteAsync(bool createNew)
        {
            return base.OpenWriteAsync(createNew);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.OpenWriteAsync(createNew, accessCondition, options, operationContext);
        }

        public override Task<CloudBlobStream> OpenWriteAsync(bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            CloudBlobStream stream = _store.OpenWriteAppend(_containerName, _blobName, _metadata);
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
            // return base.ReleaseLeaseAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.RenewLeaseAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            //return base.SetMetadataAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.SetPropertiesAsync(accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.SnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
        }

        public override Task<string> StartCopyAsync(CloudAppendBlob source)
        {
            return base.StartCopyAsync(source);
        }

        public override Task<string> StartCopyAsync(CloudAppendBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext);
        }

        public override Task<string> StartCopyAsync(CloudAppendBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            // return base.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            // return base.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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
            //return base.UploadFromFileAsync(path, accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
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

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            // return base.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken);
            throw new NotImplementedException();
        }

        public override Task UploadTextAsync(string content)
        {
            return base.UploadTextAsync(content);
        }

        public override Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return base.UploadTextAsync(content, encoding, accessCondition, options, operationContext);
        }

        public override Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            UploadText(content, encoding, accessCondition, options, operationContext);
            return Task.CompletedTask;
        }

        public override void UploadText(string content, Encoding encoding = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            using (CloudBlobStream stream = _store.OpenWriteAppend(_containerName, _blobName, _metadata))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                stream.Write(buffer, 0, buffer.Length);
                stream.CommitAsync().Wait();
            }
        }
    }
}

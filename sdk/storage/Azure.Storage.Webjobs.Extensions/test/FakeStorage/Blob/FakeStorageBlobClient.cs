// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace FakeStorage
{
    public class FakeStorageBlobClient : CloudBlobClient
    {
        public static Uri FakeUri = new Uri("https://fakeaccount.blob.core.windows.net");

        internal readonly MemoryBlobStore _store;

        public FakeStorageBlobClient(FakeAccount account)
            : base(FakeUri)
        {
            _store = account._blobStore;

            this.SetInternalProperty(nameof(Credentials), account._creds);
        }

        internal Uri GetContainerUri(string containerName)
        {
            return new Uri(this.BaseUri.ToString() + containerName); // Uri already has trailing slash 
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeStorageBlobClient other)
            {
                return this.BaseUri == other.BaseUri;
            }
            return false;
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(Uri blobUri)
        {
            throw new NotImplementedException();
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(Uri blobUri, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(StorageUri blobUri, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<ICloudBlob> GetBlobReferenceFromServerAsync(StorageUri blobUri, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override CloudBlobContainer GetContainerReference(string containerName)
        {
            return new FakeStorageBlobContainer(this, containerName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override CloudBlobContainer GetRootContainerReference()
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync(CancellationToken cancellationToken)
        {
            ServiceProperties properties = _store.GetServiceProperties();
            return Task.FromResult(properties);
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync()
        {
            ServiceProperties properties = _store.GetServiceProperties();
            return Task.FromResult(properties);
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            ServiceProperties properties = _store.GetServiceProperties();
            return Task.FromResult(properties);
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            ServiceProperties properties = _store.GetServiceProperties();
            return Task.FromResult(properties);
        }

        public override Task<ServiceStats> GetServiceStatsAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceStats> GetServiceStatsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceStats> GetServiceStatsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return base.ListBlobsSegmentedAsync(prefix, currentToken); // chain
        }

        public override Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            if (options != null)
            {
                throw new NotImplementedException();
            }           

            Func<string, FakeStorageBlobContainer> containerFactory = (n) => new FakeStorageBlobContainer(this, n);
            BlobResultSegment segment = _store.ListBlobsSegmented(containerFactory, prefix, useFlatBlobListing,
                blobListingDetails, maxResults, currentToken);
            return Task.FromResult(segment);
        }

        public override Task<ContainerResultSegment> ListContainersSegmentedAsync(BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public override Task<ContainerResultSegment> ListContainersSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            throw new NotImplementedException();
        }

        public override Task<ContainerResultSegment> ListContainersSegmentedAsync(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public override Task<ContainerResultSegment> ListContainersSegmentedAsync(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties, CancellationToken cancellationToken)
        {
            _store.SetServiceProperties(properties);
            return Task.CompletedTask;
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            _store.SetServiceProperties(properties);
            return Task.CompletedTask;
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties, BlobRequestOptions requestOptions, OperationContext operationContext)
        {
            _store.SetServiceProperties(properties);
            return Task.CompletedTask;
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            _store.SetServiceProperties(properties);
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

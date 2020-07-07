// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace FakeStorage
{
    internal class MemoryBlobStore
    {
        private readonly ConcurrentDictionary<string, Container> _items = new ConcurrentDictionary<string, Container>();
        private ServiceProperties _properties = new ServiceProperties(new LoggingProperties(), new MetricsProperties(), new MetricsProperties(), new CorsProperties());

        public void SetBlob(string containerName, string blobName, ICloudBlob blob)
        {
            CreateIfNotExists(containerName);
            _items[containerName].SetBlob(blobName, blob);
        }

        public string AcquireLease(string containerName, string blobName, TimeSpan? leaseTime)
        {
            return _items[containerName].AcquireLease(blobName, leaseTime);
        }

        public void CreateIfNotExists(string containerName)
        {
            _items.AddOrUpdate(containerName, new Container(), (_, existing) => existing);
        }

        public bool Exists(string containerName)
        {
            return _items.ContainsKey(containerName);
        }

        public bool Exists(string containerName, string blobName)
        {
            if (!_items.ContainsKey(containerName))
            {
                return false;
            }

            return _items[containerName].Exists(blobName);
        }

        public BlobAttributes FetchAttributes(string containerName, string blobName)
        {
            if (!_items.ContainsKey(containerName))
            {
                throw StorageExceptionFactory.Create(404);
            }

            return _items[containerName].FetchAttributes(blobName);
        }

        public ICloudBlob GetBlobReferenceFromServer(FakeStorageBlobContainer parent, string containerName, string blobName)
        {
            if (!_items.ContainsKey(containerName))
            {
                throw StorageExceptionFactory.Create(404);
            }

            return _items[containerName].GetBlobReferenceFromServer(this, parent, blobName);
        }

        public ServiceProperties GetServiceProperties()
        {
            return Clone(_properties);
        }

        public BlobResultSegment ListBlobsSegmented(Func<string, FakeStorageBlobContainer> containerFactory,
            string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults,
            BlobContinuationToken currentToken)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException("prefix");
            }

            if (!useFlatBlobListing)
            {
                throw new NotImplementedException();
            }

            if (blobListingDetails != BlobListingDetails.None && blobListingDetails != BlobListingDetails.Metadata)
            {
                throw new NotImplementedException();
            }

            if (prefix.StartsWith("$logs/"))
            {
                return TestExtensions.NewBlobResultSegment(null, new List<ICloudBlob>());
            }

            if (prefix.Contains("/"))
            {
                throw new NotImplementedException();
            }

            if (!_items.ContainsKey(prefix))
            {
                // if there are no blobs with the criteria, azure storage return empty list not null object
                return TestExtensions.NewBlobResultSegment(null, new List<ICloudBlob>());
            }

            FakeStorageBlobContainer parent = containerFactory.Invoke(prefix);
            List<ICloudBlob> results = _items[prefix].ListBlobs(this, parent, blobListingDetails).ToList();

            // handle token
            // in this mock up token.NextMarker is going to be assumed the last blob returned in the last
            // call, we will remove everything before and send the rest with a new token that is the last
            // element in the new list
            if (currentToken != null)
            {
                var edgeMarker = results.FindIndex(r => r.Name == currentToken.NextMarker);

                // if it is not the last element then filter all before the marker including the marker
                if (!(edgeMarker == results.Count - 1))
                {
                    results.RemoveRange(0, edgeMarker + 1);
                }
            }

            // handle maxResults
            if (maxResults.HasValue && results.ToList().Count > maxResults.Value)
            {
                int realMaxResults = maxResults.Value;
                List<ICloudBlob> filteredResult = (List<ICloudBlob>)results;
                filteredResult.RemoveRange(realMaxResults, (filteredResult.Count - realMaxResults));
                BlobContinuationToken token = new BlobContinuationToken();
                token.NextMarker = filteredResult.Last().Name;
                return TestExtensions.NewBlobResultSegment(token, results);
            }


            return TestExtensions.NewBlobResultSegment(null, results);
        }

        public Stream OpenRead(string containerName, string blobName)
        {
            if (!_items.ContainsKey(containerName))
            {
                throw StorageExceptionFactory.Create(404);
            }

            return _items[containerName].OpenRead(blobName);
        }

        public CloudBlobStream OpenWriteBlock(string containerName, string blobName,
            IDictionary<string, string> metadata)
        {
            if (!_items.ContainsKey(containerName))
            {
                throw StorageExceptionFactory.Create(404, "ContainerNotFound");
            }

            return _items[containerName].OpenWriteBlock(blobName, metadata);
        }

        public CloudBlobStream OpenWritePage(string containerName, string blobName, long? size,
            IDictionary<string, string> metadata)
        {
            return _items[containerName].OpenWritePage(blobName, size, metadata);
        }

        public CloudBlobStream OpenWriteAppend(string containerName, string blobName,
            IDictionary<string, string> metadata)
        {
            return _items[containerName].OpenWriteAppend(blobName, metadata);
        }

        public void ReleaseLease(string containerName, string blobName, string leaseId)
        {
            _items[containerName].ReleaseLease(blobName, leaseId);
        }

        public void SetMetadata(string containerName, string blobName, IDictionary<string, string> metadata,
            string leaseId)
        {
            _items[containerName].SetMetadata(blobName, metadata, leaseId);
        }

        public void SetServiceProperties(ServiceProperties properties)
        {
            _properties = Clone(properties);
        }

        private static ServiceProperties Clone(ServiceProperties properties)
        {
            if (properties == null)
            {
                return null;
            }

            return new ServiceProperties
            {
                Cors = Clone(properties.Cors),
                DefaultServiceVersion = properties.DefaultServiceVersion,
                HourMetrics = Clone(properties.HourMetrics),
                Logging = Clone(properties.Logging),
                MinuteMetrics = Clone(properties.MinuteMetrics)
            };
        }

        private static CorsProperties Clone(CorsProperties cors)
        {
            if (cors == null)
            {
                return null;
            }

            CorsProperties cloned = new CorsProperties();

            foreach (CorsRule rule in cors.CorsRules)
            {
                cloned.CorsRules.Add(Clone(rule));
            }

            return cloned;
        }

        private static CorsRule Clone(CorsRule rule)
        {
            throw new NotImplementedException();
        }

        private static MetricsProperties Clone(MetricsProperties metrics)
        {
            if (metrics == null)
            {
                return null;
            }

            return new MetricsProperties
            {
                MetricsLevel = metrics.MetricsLevel,
                RetentionDays = metrics.RetentionDays,
                Version = metrics.Version
            };
        }

        private static LoggingProperties Clone(LoggingProperties logging)
        {
            if (logging == null)
            {
                return null;
            }

            return new LoggingProperties
            {
                LoggingOperations = logging.LoggingOperations,
                RetentionDays = logging.RetentionDays,
                Version = logging.Version
            };
        }

        private class Container
        {
            private readonly ConcurrentDictionary<string, Blob> _items = new ConcurrentDictionary<string, Blob>();

            public string AcquireLease(string blobName, TimeSpan? leaseTime)
            {
                if (!Exists(blobName))
                {
                    RequestResult result = new RequestResult
                    {
                        HttpStatusCode = 404
                    };
                    throw new StorageException(result, "Blob does not exist", null);
                }

                return _items[blobName].AcquireLease(leaseTime);
            }

            public bool Exists(string blobName)
            {
                return _items.ContainsKey(blobName);
            }

            public BlobAttributes FetchAttributes(string blobName)
            {
                if (!_items.ContainsKey(blobName))
                {
                    throw StorageExceptionFactory.Create(404);
                }

                return _items[blobName].FetchAttributes();
            }

            public ICloudBlob GetBlobReferenceFromServer(MemoryBlobStore store, FakeStorageBlobContainer parent, string blobName)
            {
                if (!_items.ContainsKey(blobName))
                {
                    throw StorageExceptionFactory.Create(404);
                }

                Blob blob = _items[blobName];

                if (blob._hook != null)
                {
                    return blob._hook;
                }

                FakeStorageBlobProperties properties = new FakeStorageBlobProperties()
                {
                    ETag = blob.ETag,
                    LastModified = blob.LastModified,
                };

                switch (blob.BlobType)
                {
                    case BlobType.BlockBlob:
                        return new FakeStorageBlockBlob(blobName, parent, properties);
                    case BlobType.PageBlob:
                        return new FakeStoragePageBlob(blobName, parent, properties);                        
                    case BlobType.AppendBlob:
                        return new FakeStorageAppendBlob(blobName, parent, properties);
                    default:
                        throw new InvalidOperationException(string.Format("Type '{0}' is not supported.", blob.BlobType));
                }
            }

            public IEnumerable<ICloudBlob> ListBlobs(MemoryBlobStore store, FakeStorageBlobContainer parent,
                BlobListingDetails blobListingDetails)
            {
                if (blobListingDetails != BlobListingDetails.None && blobListingDetails != BlobListingDetails.Metadata)
                {
                    throw new NotImplementedException();
                }
                List<ICloudBlob> results = new List<ICloudBlob>();

                foreach (KeyValuePair<string, Blob> item in _items)
                {
                    string blobName = item.Key;

                    // Etag  and LastModifiedTime is always passed in listBlobs
                    FakeStorageBlobProperties properties = new FakeStorageBlobProperties()
                    {
                        ETag = item.Value.ETag,
                        LastModified = item.Value.LastModified,
                    };

                    ICloudBlob blob = new FakeStorageBlockBlob(blobName, parent, properties);
                    if ((blobListingDetails | BlobListingDetails.Metadata) == BlobListingDetails.Metadata)
                    {
                        Blob storeBlob = item.Value;
                        IReadOnlyDictionary<string, string> storeMetadata = storeBlob.Metadata;

                        foreach (KeyValuePair<string, string> pair in storeMetadata)
                        {
                            blob.Metadata.Add(pair.Key, pair.Value);
                        }
                    }

                    results.Add(blob);
                }

                return results;
            }

            public Stream OpenRead(string blobName)
            {
                if (!_items.ContainsKey(blobName))
                {
                    throw StorageExceptionFactory.Create(404, "BlobNotFound");
                }

                return new MemoryStream(_items[blobName].Contents, writable: false);
            }

            public CloudBlobStream OpenWriteBlock(string blobName, IDictionary<string, string> metadata)
            {
                if (_items.ContainsKey(blobName))
                {
                    _items[blobName].ThrowIfLeased();
                }

                return new MemoryCloudBlockBlobStream((bytes) => _items[blobName] =
                    new Blob(BlobType.BlockBlob, bytes, metadata, null, null));
            }

            public CloudBlobStream OpenWritePage(string blobName, long? size, IDictionary<string, string> metadata)
            {
                if (!size.HasValue)
                {
                    throw new NotImplementedException();
                }

                if (size.Value % 512 != 0)
                {
                    throw new InvalidOperationException();
                }

                if (_items.ContainsKey(blobName))
                {
                    _items[blobName].ThrowIfLeased();
                }

                return new MemoryCloudPageBlobStream((bytes) => _items[blobName] =
                    new Blob(BlobType.PageBlob, bytes, metadata, null, null));
            }

            public CloudBlobStream OpenWriteAppend(string blobName, IDictionary<string, string> metadata)
            {
                if (_items.ContainsKey(blobName))
                {
                    _items[blobName].ThrowIfLeased();
                }

                return new MemoryCloudAppendBlobStream((bytes) => _items[blobName] =
                    new Blob(BlobType.AppendBlob, bytes, metadata, null, null));
            }

            public void ReleaseLease(string blobName, string leaseId)
            {
                if (!_items.ContainsKey(blobName))
                {
                    throw StorageExceptionFactory.Create(404, "BlobNotFound");
                }

                _items[blobName].ReleaseLease(leaseId);
            }

            public void SetMetadata(string blobName, IDictionary<string, string> metadata, string leaseId)
            {
                Blob existing;
                if (!_items.TryRemove(blobName, out existing))
                {
                    throw new InvalidOperationException();
                }

                if (leaseId == null)
                {
                    existing.ThrowIfLeased();
                }
                else
                {
                    existing.ThrowIfLeaseMismatch(leaseId);
                }

                _items[blobName] = new Blob(existing.BlobType, existing.Contents, metadata, existing.LeaseId,
                    existing.LeaseExpires);
            }

            public void SetBlob(string blobName, ICloudBlob blob)
            {
                _items[blobName] = new Blob(blob);
            }
        }

        private class Blob
        {
            private readonly BlobType _blobType;
            private readonly byte[] _contents;
            private readonly string _eTag;
            private readonly DateTimeOffset _lastModified;
            private readonly IReadOnlyDictionary<string, string> _metadata;

            public ICloudBlob _hook;

            public Blob(ICloudBlob hook)
            {
                _hook = hook;
            }

            public Blob(BlobType blobType, byte[] contents, IDictionary<string, string> metadata, string leaseId,
                DateTime? leaseExpires)
            {
                if (blobType == BlobType.PageBlob && contents.Length % 512 != 0)
                {
                    throw new InvalidOperationException();
                }

                _blobType = blobType;
                _contents = new byte[contents.LongLength];
                _eTag = Guid.NewGuid().ToString();
                _lastModified = DateTimeOffset.Now;
                Array.Copy(contents, _contents, _contents.LongLength);
                _metadata = new Dictionary<string, string>(metadata);
                LeaseId = leaseId;
                LeaseExpires = leaseExpires;
            }

            public BlobType BlobType
            {
                get { return _blobType; }
            }

            public byte[] Contents
            {
                get { return _contents; }
            }

            public string ETag
            {
                get { return _eTag; }
            }

            public DateTimeOffset LastModified
            {
                get { return _lastModified; }
            }

            public string LeaseId { get; private set; }

            public DateTime? LeaseExpires { get; private set; }

            public IReadOnlyDictionary<string, string> Metadata
            {
                get { return _metadata; }
            }

            public string AcquireLease(TimeSpan? leaseTime)
            {
                ThrowIfLeased();

                string leaseId = Guid.NewGuid().ToString();
                LeaseId = leaseId;

                if (leaseTime.HasValue)
                {
                    LeaseExpires = DateTime.UtcNow.Add(leaseTime.Value);
                }
                else
                {
                    LeaseExpires = null;
                }

                return leaseId;
            }

            public BlobAttributes FetchAttributes()
            {
                return new BlobAttributes(_eTag, _lastModified, _metadata);
            }

            public void ReleaseLease(string leaseId)
            {
                if (LeaseId != leaseId)
                {
                    throw new InvalidOperationException();
                }

                LeaseId = null;
                LeaseExpires = null;
            }

            public void ThrowIfLeased()
            {
                if (LeaseId != null)
                {
                    if (!LeaseExpires.HasValue || LeaseExpires.Value > DateTime.UtcNow)
                    {
                        RequestResult result = new RequestResult
                        {
                            HttpStatusCode = 409
                        };
                        throw new StorageException(result, "Blob is leased", null);
                    }
                }
            }

            public void ThrowIfLeaseMismatch(string leaseId)
            {
                if (leaseId == null)
                {
                    throw new ArgumentNullException("leaseId");
                }

                if (LeaseId != leaseId)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

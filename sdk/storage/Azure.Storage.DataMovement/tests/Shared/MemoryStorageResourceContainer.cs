// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Storage.Tests;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MemoryStorageResourceContainer : StorageResourceContainer
    {
        internal List<StorageResource> Children { get; } = new();

        internal readonly Uri _uri;
        public override Uri Uri => _uri;

        private MemoryStorageResourceContainer(Uri uri)
        {
            _uri = uri;
        }

        public static MemoryStorageResourceContainer MakeContainer(
            Tree<(string Name, bool IsDirectory)> containerStructure,
            Random random = default,
            Uri baseUri = default,
            string basePath = default,
            int childItemSizes = Constants.KB)
        {
            if (containerStructure.Value.IsDirectory)
            {
                throw new ArgumentException("MemoryStorageResourceContainer must be a directory");
            }

            UriBuilder baseUriBuilder = baseUri != default
                ? new UriBuilder(baseUri)
                : new UriBuilder()
                {
                    Scheme = "memory",
                    Host = "localhost",
                };

            baseUriBuilder.Path = string.Join("/", new List<string>()
            {
                baseUriBuilder.Path.Trim('/'),
                basePath.Trim('/'),
                containerStructure.Value.Name
            }.Select(s => !string.IsNullOrWhiteSpace(s)));

            MemoryStorageResourceContainer result = new(baseUriBuilder.Uri);
            foreach (Tree<(string Name, bool IsDirectory)> child in containerStructure)
            {
                if (child.Value.IsDirectory)
                {
                    result.Children.Add(MakeContainer(child, random, result.Uri, basePath: default, childItemSizes));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return result;
        }

        protected internal override StorageResourceItem GetStorageResourceReference(string path)
        {
            throw new NotImplementedException();
        }

        protected internal override IAsyncEnumerable<StorageResource> GetStorageResourcesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

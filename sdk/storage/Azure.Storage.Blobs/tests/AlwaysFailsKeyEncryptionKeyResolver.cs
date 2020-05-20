// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;

namespace Azure.Storage.Blobs.Tests
{
    internal class AlwaysFailsKeyEncryptionKeyResolver : IKeyEncryptionKeyResolver
    {
        /// <summary>
        /// False means the resolver just can't find the key and returns null.
        /// True means the resolver has an internal failure and throws.
        /// </summary>
        public bool ResolverInternalFailure { get; set; } = false;

        public IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken = default)
        {
            if (ResolverInternalFailure)
            {
                throw new Exception();
            }
            return default;
        }

        public Task<IKeyEncryptionKey> ResolveAsync(string keyId, CancellationToken cancellationToken = default)
        {
            if (ResolverInternalFailure)
            {
                throw new Exception();
            }
            return Task.FromResult<IKeyEncryptionKey>(default);
        }
    }
}

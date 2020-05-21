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
        /// False means the resolver returns null.
        /// True means the resolver throws.
        /// </summary>
        public bool ShouldThrow { get; set; } = false;

        public IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken = default)
        {
            if (ShouldThrow)
            {
                throw new Exception();
            }
            return default;
        }

        public Task<IKeyEncryptionKey> ResolveAsync(string keyId, CancellationToken cancellationToken = default)
        {
            if (ShouldThrow)
            {
                throw new Exception();
            }
            return Task.FromResult<IKeyEncryptionKey>(default);
        }
    }
}

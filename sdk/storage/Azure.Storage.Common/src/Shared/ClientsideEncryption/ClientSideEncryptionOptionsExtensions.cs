// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography
{
    internal static class ClientSideEncryptionOptionsExtensions
    {
        public static ClientSideEncryptionOptions Clone(this ClientSideEncryptionOptions options)
            => new ClientSideEncryptionOptions(options.Version)
            {
                KeyEncryptionKey = options.KeyEncryptionKey,
                KeyResolver = options.KeyResolver,
                KeyWrapAlgorithm = options.KeyWrapAlgorithm,
            };
    }
}

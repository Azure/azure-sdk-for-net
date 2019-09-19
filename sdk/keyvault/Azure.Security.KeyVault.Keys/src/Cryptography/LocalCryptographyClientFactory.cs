// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class LocalCryptographyClientFactory
    {
        public static ICryptographyProvider Create(IKeyVaultPipeline pipeline, JsonWebKey key)
        {
            if (key.KeyType == KeyType.Rsa || key.KeyType == KeyType.RsaHsm)
            {
                return new RsaCryptographyClient(pipeline, key);
            }

            if (key.KeyType == KeyType.Ec || key.KeyType == KeyType.EcHsm)
            {
                return new EcCryptographyClient(pipeline, key);
            }

            throw new NotSupportedException();
        }
    }
}

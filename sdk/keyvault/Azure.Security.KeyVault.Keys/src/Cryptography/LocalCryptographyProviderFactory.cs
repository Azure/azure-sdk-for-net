// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class LocalCryptographyProviderFactory
    {
        public static ICryptographyProvider Create(JsonWebKey key)
        {
            if (key.KeyType == KeyType.Rsa || key.KeyType == KeyType.RsaHsm)
            {
                return new RsaCryptographyProvider(key);
            }

            if (key.KeyType == KeyType.Ec || key.KeyType == KeyType.EcHsm)
            {
                return new EcCryptographyProvider(key);
            }

            if (key.KeyType == KeyType.Oct)
            {
                return new AesCryptographyProvider(key);
            }

            throw new NotSupportedException();
        }
    }
}

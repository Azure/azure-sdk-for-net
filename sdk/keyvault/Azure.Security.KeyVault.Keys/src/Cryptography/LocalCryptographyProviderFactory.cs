// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class LocalCryptographyProviderFactory
    {
        public static ICryptographyProvider Create(KeyVaultKey key)
        {
            JsonWebKey keyMaterial = key?.Key;
            if (keyMaterial != null)
            {
                if (keyMaterial.KeyType == KeyType.Rsa || keyMaterial.KeyType == KeyType.RsaHsm)
                {
                    return new RsaCryptographyProvider(key);
                }

                if (keyMaterial.KeyType == KeyType.Ec || keyMaterial.KeyType == KeyType.EcHsm)
                {
                    return new EcCryptographyProvider(key);
                }

                if (keyMaterial.KeyType == KeyType.Oct)
                {
                    return new AesCryptographyProvider(key);
                }
            }

            return null;
        }
    }
}

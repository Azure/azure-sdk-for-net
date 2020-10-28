// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class LocalCryptographyProviderFactory
    {
        public static ICryptographyProvider Create(KeyVaultKey key) => Create(key?.Key, key?.Properties);

        public static ICryptographyProvider Create(JsonWebKey keyMaterial, KeyProperties keyProperties)
        {
            if (keyMaterial != null)
            {
                if (keyMaterial.KeyType == KeyType.Rsa || keyMaterial.KeyType == KeyType.RsaHsm)
                {
                    return new RsaCryptographyProvider(keyMaterial, keyProperties);
                }

                if (keyMaterial.KeyType == KeyType.Ec || keyMaterial.KeyType == KeyType.EcHsm)
                {
                    return new EcCryptographyProvider(keyMaterial, keyProperties);
                }

                if (keyMaterial.KeyType == KeyType.Oct || keyMaterial.KeyType == KeyType.OctHsm)
                {
                    return new AesCryptographyProvider(keyMaterial, keyProperties);
                }
            }

            return null;
        }
    }
}

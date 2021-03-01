// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class LocalCryptographyProviderFactory
    {
        public static ICryptographyProvider Create(KeyVaultKey key, bool localOnly = false) => Create(key?.Key, key?.Properties, localOnly);

        public static ICryptographyProvider Create(JsonWebKey keyMaterial, KeyProperties keyProperties, bool localOnly = false)
        {
            if (keyMaterial != null)
            {
                if (keyMaterial.KeyType == KeyType.Rsa || keyMaterial.KeyType == KeyType.RsaHsm)
                {
                    return new RsaCryptographyProvider(keyMaterial, keyProperties, localOnly);
                }

                if (keyMaterial.KeyType == KeyType.Ec || keyMaterial.KeyType == KeyType.EcHsm)
                {
                    return new EcCryptographyProvider(keyMaterial, keyProperties, localOnly);
                }

                if (keyMaterial.KeyType == KeyType.Oct || keyMaterial.KeyType == KeyType.OctHsm)
                {
                    return new AesCryptographyProvider(keyMaterial, keyProperties, localOnly);
                }
            }

            return null;
        }
    }
}

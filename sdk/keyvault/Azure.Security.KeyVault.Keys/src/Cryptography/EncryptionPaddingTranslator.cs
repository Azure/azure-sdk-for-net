// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class EncryptionPaddingTranslator
    {
        public static EncryptionAlgorithm EncryptionPaddingToJwsAlgId(RSAEncryptionPadding padding)
        {
            switch (padding.Mode)
            {
                case RSAEncryptionPaddingMode.Pkcs1:
                    return EncryptionAlgorithm.Rsa15;
                case RSAEncryptionPaddingMode.Oaep when padding.OaepHashAlgorithm == HashAlgorithmName.SHA1:
                    return EncryptionAlgorithm.RsaOaep;
                case RSAEncryptionPaddingMode.Oaep when padding.OaepHashAlgorithm == HashAlgorithmName.SHA256:
                    return EncryptionAlgorithm.RsaOaep256;
                default:
                    throw new NotSupportedException("The padding specified is not supported.");
            }
        }
    }
}

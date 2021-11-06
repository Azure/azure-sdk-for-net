// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class SignatureAlgorithmTranslator
    {
        public static SignatureAlgorithm SignatureAlgorithmToJwsAlgId(KeyVaultSignatureAlgorithm signatureAlgorithm, HashAlgorithmName hashAlgorithmName)
        {
            if (signatureAlgorithm == KeyVaultSignatureAlgorithm.RSAPkcs15)
            {
                if (hashAlgorithmName == HashAlgorithmName.SHA1)
                    return new SignatureAlgorithm("RSNULL");

                if (hashAlgorithmName == HashAlgorithmName.SHA256)
                    return SignatureAlgorithm.RS256;

                if (hashAlgorithmName == HashAlgorithmName.SHA384)
                    return SignatureAlgorithm.RS384;

                if (hashAlgorithmName == HashAlgorithmName.SHA512)
                    return SignatureAlgorithm.RS512;
            }
            else if (signatureAlgorithm == KeyVaultSignatureAlgorithm.ECDsa)
            {
                if (hashAlgorithmName == HashAlgorithmName.SHA256)
                    return SignatureAlgorithm.ES256;

                if (hashAlgorithmName == HashAlgorithmName.SHA384)
                    return SignatureAlgorithm.ES384;

                if (hashAlgorithmName == HashAlgorithmName.SHA512)
                    return SignatureAlgorithm.ES512;
            }

            throw new NotSupportedException("The algorithm specified is not supported.");
        }
    }
}

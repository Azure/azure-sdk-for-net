// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public static class TestExtensionMethods
    {
        public static SignatureAlgorithm GetSignatureAlgorithm(this CertificateKeyCurveName keyCurveName) => keyCurveName.ToString() switch
        {
            "P-256" => SignatureAlgorithm.ES256,
            "P-256K" => SignatureAlgorithm.ES256K,
            "P-384" => SignatureAlgorithm.ES384,
            "P-521" => SignatureAlgorithm.ES512,
            _ => throw new NotSupportedException($"{keyCurveName} is not supported"),
        };

        public static HashAlgorithmName GetHashAlgorithmName(this CertificateKeyCurveName keyCurveName) => keyCurveName.ToString() switch
        {
            "P-256" => HashAlgorithmName.SHA256,
            "P-256K" => HashAlgorithmName.SHA256,
            "P-384" => HashAlgorithmName.SHA384,
            "P-521" => HashAlgorithmName.SHA512,
            _ => throw new NotSupportedException($"{keyCurveName} is not supported"),
        };

        public static int GetKeySize(this CertificateKeyCurveName keyCurveName) => keyCurveName.ToString() switch
        {
            "P-256" => 256,
            "P-256K" => 256,
            "P-384" => 384,
            "P-521" => 521,
            _ => throw new NotSupportedException($"{keyCurveName} is not supported"),
        };
    }
}

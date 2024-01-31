// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificatePropertiesTests
    {
        [TestCase(@"{""kid"":""https://vault/certificates/certificate-name""}", null)]
        [TestCase(@"{""kid"":""https://vault/certificates/certificate-name"",""attributes"":{""recoverableDays"":0}}", 0)]
        [TestCase(@"{""kid"":""https://vault/certificates/certificate-name"",""attributes"":{""recoverableDays"":90}}", 90)]
        public void DeserializesRecoverableDays(string content, int? expected)
        {
            CertificateProperties properties = new CertificateProperties();
            using (JsonStream json = new JsonStream(content))
            {
                properties.Deserialize(json.AsStream());
            }

            Assert.AreEqual(expected, properties.RecoverableDays);
        }

        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("dGVzdA==", "74657374")]
        public void X509ThumbprintString(string base64source, string expected)
        {
            CertificateProperties properties = new()
            {
                X509Thumbprint = base64source is not null ? Convert.FromBase64String(base64source) : null,
            };

            Assert.AreEqual(expected, properties.X509ThumbprintString);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class EncryptionAlgorithmTests
    {
        [Test]
        public void FromRsaEncryptionPadding()
        {
            EncryptionAlgorithm sut = EncryptionAlgorithm.FromRsaEncryptionPadding(RSAEncryptionPadding.Pkcs1);
            Assert.AreEqual(EncryptionAlgorithm.Rsa15, sut);

            sut = EncryptionAlgorithm.FromRsaEncryptionPadding(RSAEncryptionPadding.OaepSHA1);
            Assert.AreEqual(EncryptionAlgorithm.RsaOaep, sut);

            sut = EncryptionAlgorithm.FromRsaEncryptionPadding(RSAEncryptionPadding.OaepSHA256);
            Assert.AreEqual(EncryptionAlgorithm.RsaOaep256, sut);

            Assert.Throws<NotSupportedException>(() => EncryptionAlgorithm.FromRsaEncryptionPadding(RSAEncryptionPadding.OaepSHA384));
            Assert.Throws<NotSupportedException>(() => EncryptionAlgorithm.FromRsaEncryptionPadding(RSAEncryptionPadding.OaepSHA512));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;
using Azure.Core.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class AzureKeyVaultXmlEncryptorTests
    {
        [Test]
        public void UsesKeyVaultToEncryptKey()
        {
            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.Setup(client => client.WrapKey("RSA-OAEP", It.IsAny<ReadOnlyMemory<byte>>(), default))
                .Returns((string _, ReadOnlyMemory<byte> data, CancellationToken __) => data.ToArray().Reverse().ToArray())
                .Verifiable();

            keyMock.SetupGet(client => client.KeyId).Returns("KeyId");

            var mock = new Mock<IKeyEncryptionKeyResolver>();
            mock.Setup(client => client.Resolve("key", default))
                .Returns((string _, CancellationToken __) => keyMock.Object)
                .Verifiable();

            var encryptor = new AzureKeyVaultXmlEncryptor(mock.Object, "key", new MockNumberGenerator());
            var result = encryptor.Encrypt(new XElement("Element"));

            var encryptedElement = result.EncryptedElement;
            var value = encryptedElement.Element("value");

            mock.VerifyAll();
            Assert.NotNull(result);
            Assert.NotNull(value);
            Assert.AreEqual(typeof(AzureKeyVaultXmlDecryptor), result.DecryptorType);
            Assert.AreEqual("VfLYL2prdymawfucH3Goso0zkPbQ4/GKqUsj2TRtLzsBPz7p7cL1SQaY6I29xSlsPQf6IjxHSz4sDJ427GvlLQ==", encryptedElement.Element("value").Value);
            Assert.AreEqual("AAECAwQFBgcICQoLDA0ODw==", encryptedElement.Element("iv").Value);
            Assert.AreEqual("Dw4NDAsKCQgHBgUEAwIBAA==", encryptedElement.Element("key").Value);
            Assert.AreEqual("KeyId", encryptedElement.Element("kid").Value);
        }

        [Test]
        public void UsesKeyVaultToDecryptKey()
        {
            var keyMock = new Mock<IKeyEncryptionKey>(MockBehavior.Strict);
            keyMock.Setup(client => client.UnwrapKey("RSA-OAEP", It.IsAny<ReadOnlyMemory<byte>>(), default))
                .Returns((string _, ReadOnlyMemory<byte> data, CancellationToken __) => data.ToArray().Reverse().ToArray())
                .Verifiable();

            var mock = new Mock<IKeyEncryptionKeyResolver>();
            mock.Setup(client => client.Resolve("KeyId", default))
                .Returns((string _, CancellationToken __) => keyMock.Object)
                .Verifiable();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(mock.Object);

            var encryptor = new AzureKeyVaultXmlDecryptor(serviceCollection.BuildServiceProvider());

            var result = encryptor.Decrypt(XElement.Parse(
                @"<encryptedKey>
                  <kid>KeyId</kid>
                  <key>Dw4NDAsKCQgHBgUEAwIBAA==</key>
                  <iv>AAECAwQFBgcICQoLDA0ODw==</iv>
                  <value>VfLYL2prdymawfucH3Goso0zkPbQ4/GKqUsj2TRtLzsBPz7p7cL1SQaY6I29xSlsPQf6IjxHSz4sDJ427GvlLQ==</value>
                </encryptedKey>"));

            mock.VerifyAll();
            Assert.NotNull(result);
            Assert.AreEqual("<Element />", result.ToString());
        }

        private class MockNumberGenerator : RandomNumberGenerator
        {
            public override void GetBytes(byte[] data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)i;
                }
            }
        }
    }
}

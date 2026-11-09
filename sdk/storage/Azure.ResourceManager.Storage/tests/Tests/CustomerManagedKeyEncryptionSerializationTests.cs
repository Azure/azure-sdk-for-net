// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class CustomerManagedKeyEncryptionSerializationTests
    {
        private static readonly Uri KeyEncryptionKeyUri = new Uri("https://mykeyvault.vault.azure.net/keys/myEncryptionKey");

        [Test]
        public void SerializeKeyEncryptionKeyUri()
        {
            var model = new CustomerManagedKeyEncryption
            {
                KeyEncryptionKeyUri = KeyEncryptionKeyUri
            };

            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(json);

            Assert.AreEqual(KeyEncryptionKeyUri.AbsoluteUri, document.RootElement.GetProperty("keyEncryptionKeyUrl").GetString());
        }

        [Test]
        public void DeserializeKeyEncryptionKeyUri()
        {
            string json = $"{{ \"keyEncryptionKeyUrl\": \"{KeyEncryptionKeyUri.AbsoluteUri}\" }}";
            using JsonDocument document = JsonDocument.Parse(json);

            CustomerManagedKeyEncryption result =
                CustomerManagedKeyEncryption.DeserializeCustomerManagedKeyEncryption(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.AreEqual(KeyEncryptionKeyUri, result.KeyEncryptionKeyUri);
        }

        [TestCase(null)]
        [TestCase("")]
        public void DeserializeNullOrEmptyKeyEncryptionKeyUri(string value)
        {
            string json = JsonSerializer.Serialize(new { keyEncryptionKeyUrl = value });
            using JsonDocument document = JsonDocument.Parse(json);

            CustomerManagedKeyEncryption result =
                CustomerManagedKeyEncryption.DeserializeCustomerManagedKeyEncryption(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.IsNull(result.KeyEncryptionKeyUri);
        }

        [Test]
        public void SerializeRelativeKeyEncryptionKeyUriThrows()
        {
            var model = new CustomerManagedKeyEncryption
            {
                KeyEncryptionKeyUri = new Uri("keys/myEncryptionKey", UriKind.Relative)
            };

            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json));
        }
    }
}

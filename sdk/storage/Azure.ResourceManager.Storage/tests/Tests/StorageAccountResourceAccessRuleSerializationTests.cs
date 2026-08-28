// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountResourceAccessRuleSerializationTests
    {
        [Test]
        public void DeserializeWithValidTenantId()
        {
            var tenantId = Guid.NewGuid();
            string json = $"{{ \"tenantId\": \"{tenantId}\" }}";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageAccountResourceAccessRule result =
                StorageAccountResourceAccessRule.DeserializeStorageAccountResourceAccessRule(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.AreEqual(tenantId, result.TenantId);
        }

        [Test]
        public void DeserializeWithEmptyTenantId()
        {
            string json = "{ \"tenantId\": \"\" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageAccountResourceAccessRule result =
                StorageAccountResourceAccessRule.DeserializeStorageAccountResourceAccessRule(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.IsNull(result.TenantId);
        }

        [Test]
        public void DeserializeWithWhitespaceTenantId()
        {
            string json = "{ \"tenantId\": \"   \" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageAccountResourceAccessRule result =
                StorageAccountResourceAccessRule.DeserializeStorageAccountResourceAccessRule(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.IsNull(result.TenantId);
        }

        [Test]
        public void DeserializeWithNullTenantId()
        {
            string json = "{ \"tenantId\": null }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageAccountResourceAccessRule result =
                StorageAccountResourceAccessRule.DeserializeStorageAccountResourceAccessRule(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.IsNull(result.TenantId);
        }

        [Test]
        public void DeserializeWithInvalidTenantId()
        {
            string json = "{ \"tenantId\": \"not-a-guid\" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageAccountResourceAccessRule result =
                StorageAccountResourceAccessRule.DeserializeStorageAccountResourceAccessRule(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.IsNull(result.TenantId);
        }
    }
}

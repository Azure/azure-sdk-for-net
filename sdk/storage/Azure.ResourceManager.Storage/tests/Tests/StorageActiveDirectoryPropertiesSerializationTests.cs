// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageActiveDirectoryPropertiesSerializationTests
    {
        [Test]
        public void DeserializeWithValidGuid()
        {
            var guid = Guid.NewGuid();
            string json = $"{{ \"domainGuid\": \"{guid}\" }}";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.AreEqual(guid, result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithEmptyStringGuid()
        {
            string json = "{ \"domainGuid\": \"\" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.IsNull(result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithWhitespaceStringGuid()
        {
            string json = "{ \"domainGuid\": \"   \" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.IsNull(result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithNullGuid()
        {
            string json = "{ \"domainGuid\": null }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.IsNull(result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithMissingGuid()
        {
            string json = "{ \"domainName\": \"example.com\" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.IsNull(result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithInvalidGuidString()
        {
            string json = "{ \"domainGuid\": \"not-a-guid\" }";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.IsNull(result.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void DeserializeWithAllProperties()
        {
            var guid = Guid.NewGuid();
            string json = $@"{{
                ""domainName"": ""example.com"",
                ""netBiosDomainName"": ""EXAMPLE"",
                ""forestName"": ""example.com"",
                ""domainGuid"": ""{guid}"",
                ""domainSid"": ""S-1-5-21-1234567890"",
                ""azureStorageSid"": ""S-1-5-21-0987654321"",
                ""samAccountName"": ""storageacct"",
                ""accountType"": ""User""
            }}";
            using JsonDocument document = JsonDocument.Parse(json);

            StorageActiveDirectoryProperties result =
                StorageActiveDirectoryProperties.DeserializeStorageActiveDirectoryProperties(document.RootElement);

            Assert.AreEqual("example.com", result.DomainName);
            Assert.AreEqual("EXAMPLE", result.NetBiosDomainName);
            Assert.AreEqual("example.com", result.ForestName);
            Assert.AreEqual(guid, result.ActiveDirectoryDomainGuid);
            Assert.AreEqual("S-1-5-21-1234567890", result.DomainSid);
            Assert.AreEqual("S-1-5-21-0987654321", result.AzureStorageSid);
            Assert.AreEqual("storageacct", result.SamAccountName);
            Assert.AreEqual(ActiveDirectoryAccountType.User, result.AccountType);
        }

        [Test]
        public void DomainGuidBackwardCompatProperty_GetReturnsEmptyGuidWhenNull()
        {
            var props = new StorageActiveDirectoryProperties();
            Assert.IsNull(props.ActiveDirectoryDomainGuid);
            Assert.AreEqual(Guid.Empty, props.DomainGuid);
        }

        [Test]
        public void DomainGuidBackwardCompatProperty_SetNonEmptyGuid()
        {
            var guid = Guid.NewGuid();
            var props = new StorageActiveDirectoryProperties();
            props.DomainGuid = guid;

            Assert.AreEqual(guid, props.ActiveDirectoryDomainGuid);
            Assert.AreEqual(guid, props.DomainGuid);
        }

        [Test]
        public void DomainGuidBackwardCompatProperty_SetEmptyGuidClearsValue()
        {
            var guid = Guid.NewGuid();
            var props = new StorageActiveDirectoryProperties();
            props.DomainGuid = guid;
            Assert.AreEqual(guid, props.ActiveDirectoryDomainGuid);

            props.DomainGuid = Guid.Empty;
            Assert.IsNull(props.ActiveDirectoryDomainGuid);
            Assert.AreEqual(Guid.Empty, props.DomainGuid);
        }

        [Test]
        public void BackwardCompatConstructor_SetsProperties()
        {
            var guid = Guid.NewGuid();
#pragma warning disable CS0618 // Type or member is obsolete
            var props = new StorageActiveDirectoryProperties("example.com", guid);
#pragma warning restore CS0618

            Assert.AreEqual("example.com", props.DomainName);
            Assert.AreEqual(guid, props.DomainGuid);
            Assert.AreEqual(guid, props.ActiveDirectoryDomainGuid);
        }

        [Test]
        public void BackwardCompatConstructor_ThrowsOnNullDomainName()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.Throws<ArgumentNullException>(() => new StorageActiveDirectoryProperties(null, Guid.NewGuid()));
#pragma warning restore CS0618
        }
    }
}

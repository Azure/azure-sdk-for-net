// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class SearchResourcesTests
    {
        [TestCase("ResourceId")]
        [TestCase("resourceid")]
        [TestCase(null)]
        public async Task ResourceIdUsesDeveloperCredentialForBlobAccess(string resourceIdKey)
        {
            MockTransport transport = CreateTransport();
            Uri containerUri = new Uri("https://identityaccount.blob.core.windows.net/test-container");
            TokenCredential credential = new MockCredential();
            BlobContainerClient client = SearchResources.CreateBlobContainerClient(
                resourceIdKey == null ? null :
                    $"{resourceIdKey}=/subscriptions/test/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/identityaccount;",
                "test-container",
                containerUri,
                () => credential,
                new BlobClientOptions { Transport = transport });

            await client.GetPropertiesAsync();

            Request request = transport.Requests.Single();
            Assert.That(request.Uri.ToUri().GetLeftPart(UriPartial.Path), Is.EqualTo(containerUri.AbsoluteUri));
            Assert.That(request.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Does.StartWith("Bearer "));
        }

        [Test]
        public async Task AccountKeyPreservesExistingBlobAuthentication()
        {
            MockTransport transport = CreateTransport();
            string key = Convert.ToBase64String(new byte[32]);
            BlobContainerClient client = SearchResources.CreateBlobContainerClient(
                $"DefaultEndpointsProtocol=https;AccountName=keyaccount;AccountKey={key};EndpointSuffix=core.windows.net",
                "test-container",
                new Uri("https://unused.blob.core.windows.net/unused"),
                () => throw new InvalidOperationException("Key-based tests must not request a developer credential."),
                new BlobClientOptions { Transport = transport });

            await client.GetPropertiesAsync();

            Request request = transport.Requests.Single();
            Assert.That(request.Uri.ToUri().Host, Is.EqualTo("keyaccount.blob.core.windows.net"));
            Assert.That(request.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Does.StartWith("SharedKey keyaccount:"));
        }

        [TestCase("SEARCH_STORAGE_RESOURCE_ID", null, "Missing SEARCH_SEARCH_STORAGE_RESOURCE_ID")]
        [TestCase("SEARCH_STORAGE_RESOURCE_ID", "not-an-arm-id", "full ARM resource ID")]
        [TestCase("SEARCH_STORAGE_RESOURCE_ID", "/subscriptions/test/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/otheraccount", "must identify SEARCH_SEARCH_STORAGE_NAME")]
        [TestCase("SEARCH_KEYVAULT_URL", "http://example.vault.azure.net", "absolute HTTPS vault URL")]
        public void InvalidEncryptionConfigurationFailsBeforeResourceCreation(string name, string value, string error)
        {
            Dictionary<string, string> settings = EncryptionSettings();
            settings[name] = value;

            var exception = Assert.Throws<InvalidOperationException>(
                () => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(key => settings[key]));

            Assert.That(exception.Message, Does.Contain(error));
            Assert.That(exception.Message, Does.Contain("No test resources have been created."));
        }

        [Test]
        public void EncryptionConfigurationAcceptsKeylessExistingResources()
        {
            Dictionary<string, string> settings = EncryptionSettings();

            Assert.DoesNotThrow(() => SearchTestEnvironment.ValidateDoubleEncryptedIndexConfiguration(key => settings[key]));
        }

        private static Dictionary<string, string> EncryptionSettings() => new Dictionary<string, string>
        {
            ["SEARCH_SERVICE_NAME"] = "test-search",
            ["SEARCH_STORAGE_NAME"] = "identityaccount",
            ["SEARCH_STORAGE_RESOURCE_ID"] = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/identityaccount",
            ["SEARCH_KEYVAULT_URL"] = "https://example.vault.azure.net"
        };

        private static MockTransport CreateTransport()
        {
            MockResponse response = new MockResponse(200);
            response.AddHeader("ETag", "\"test-etag\"");
            response.AddHeader("Last-Modified", "Fri, 06 Nov 2026 12:00:00 GMT");
            return new MockTransport(response);
        }
    }
}

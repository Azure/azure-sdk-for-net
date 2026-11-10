// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task ResourceIdUsesDeveloperCredentialForBlobAccess(string resourceIdKey)
        {
            MockTransport transport = CreateTransport();
            Uri containerUri = new Uri("https://identityaccount.blob.core.windows.net/test-container");
            TokenCredential credential = new MockCredential();
            BlobContainerClient client = SearchResources.CreateBlobContainerClient(
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

        private static MockTransport CreateTransport()
        {
            MockResponse response = new MockResponse(200);
            response.AddHeader("ETag", "\"test-etag\"");
            response.AddHeader("Last-Modified", "Fri, 06 Nov 2026 12:00:00 GMT");
            return new MockTransport(response);
        }
    }
}

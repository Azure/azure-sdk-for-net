// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Service;
using Specs.Azure.ClientGenerator.Core.ClientInitialization;
using Specs.Azure.ClientGenerator.Core.ClientInitialization._ParentClient;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientInitialization
{
    public class ClientInitializationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_HeaderParam() => Test(async (host) =>
        {
            var client = new HeaderParamClient(host, "test-name-value", null);

            // Test WithQuery - name is elevated to client constructor, only id is passed
            await client.WithQueryAsync("test-id");

            // Test WithBody - name is elevated to client constructor, body has name property
            await client.WithBodyAsync(new Input("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_MultipleParams() => Test(async (host) =>
        {
            var client = new MultipleParamsClient(host, "test-name-value", "us-west", null);

            // Test WithQuery - name and region are elevated to client constructor, only id is passed
            await client.WithQueryAsync("test-id");

            // Test WithBody - name and region are elevated to client constructor, body has name property
            await client.WithBodyAsync(new Input("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_MixedParams() => Test(async (host) =>
        {
            var client = new MixedParamsClient(host, "test-name-value", null);

            // Test WithQuery - name is elevated to client constructor, region and id are method params
            await client.WithQueryAsync("us-west", "test-id");

            // Test WithBody - name is elevated to client constructor, region is method param
            await client.WithBodyAsync("us-west", new WithBodyRequest("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_PathParam() => Test(async (host) =>
        {
            var client = new PathParamClient(host, "sample-blob", null);

            // Test WithQuery - blobName is elevated to client constructor, format is method param
            await client.WithQueryAsync("text");

            // Test GetStandalone - blobName is elevated to client constructor
            var response = await client.GetStandaloneAsync();
            Assert.AreEqual("sample-blob", response.Value.Name);
            Assert.AreEqual(42, response.Value.Size);
            Assert.AreEqual("text/plain", response.Value.ContentType);
            Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

            // Test DeleteStandalone - blobName is elevated to client constructor
            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_ParamAlias() => Test(async (host) =>
        {
            // blobName is used for routes with original name (/blobName/with-original-name)
            // blob is used for routes with aliased name (/blob/with-aliased-name)
            // Both params point to the same path segment value "sample-blob" in this scenario
            var client = new ParamAliasClient(host, "sample-blob", "sample-blob", null);

            // Test WithAliasedName - blob parameter is elevated to client constructor
            await client.WithAliasedNameAsync();

            // Test WithOriginalName - blobName parameter is elevated to client constructor
            await client.WithOriginalNameAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_ParentClient_ChildClient() => Test(async (host) =>
        {
            // Create ParentClient with blobName elevated to client constructor
            var parentClient = new ParentClient(host, "sample-blob", null);

            // Get ChildClient from ParentClient
            var childClient = parentClient.GetChildClient();
            await PerformClientOperations(childClient);

            // Can also create ChildClient directly with blobName elevated to parent client
            var directChildClient = new ChildClient(host, "sample-blob", null);
            await PerformClientOperations(directChildClient);

            // Test WithQuery - blobName is elevated to parent client, format is method param
            async Task PerformClientOperations(ChildClient client)
            {
                await client.WithQueryAsync("text");

                // Test GetStandalone - blobName is elevated to parent client
                var response = await client.GetStandaloneAsync();
                Assert.AreEqual("sample-blob", response.Value.Name);
                Assert.AreEqual(42, response.Value.Size);
                Assert.AreEqual("text/plain", response.Value.ContentType);
                Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

                // Test DeleteStandalone - blobName is elevated to parent client
                await client.DeleteStandaloneAsync();
            }
        });
    }
}

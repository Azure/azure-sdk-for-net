// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientInitialization._IndividuallyParentClient;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientInitialization.IndividuallyParent
{
    public class IndividuallyParentClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithPathClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithPathClient("test-blob");
            await PerformPathOperations(childClient);

            var directClient = new NestedWithPathClient(host, "test-blob", null);
            await PerformPathOperations(directClient);

            async Task PerformPathOperations(NestedWithPathClient client)
            {
                await client.WithQueryAsync("text");

                var response = await client.GetStandaloneAsync();
                Assert.AreEqual("test-blob", response.Value.Name);
                Assert.AreEqual(1024, response.Value.Size);
                Assert.AreEqual("application/octet-stream", response.Value.ContentType);
                Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithQueryClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithQueryClient("test-blob");
            await PerformQueryOperations(childClient);

            var directClient = new NestedWithQueryClient(host, "test-blob", null);
            await PerformQueryOperations(directClient);

            async Task PerformQueryOperations(NestedWithQueryClient client)
            {
                await client.WithQueryAsync("text");

                var response = await client.GetStandaloneAsync();
                Assert.AreEqual("test-blob", response.Value.Name);
                Assert.AreEqual(1024, response.Value.Size);
                Assert.AreEqual("application/octet-stream", response.Value.ContentType);
                Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithHeaderClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithHeaderClient("test-name-value");
            await PerformHeaderOperations(childClient);

            var directClient = new NestedWithHeaderClient(host, "test-name-value", null);
            await PerformHeaderOperations(directClient);

            async Task PerformHeaderOperations(NestedWithHeaderClient client)
            {
                await client.WithQueryAsync("text");

                await client.GetStandaloneAsync();

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithMultipleClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithMultipleClient("test-name-value", "us-west");
            await PerformMultipleOperations(childClient);

            var directClient = new NestedWithMultipleClient(host, "test-name-value", "us-west", null);
            await PerformMultipleOperations(directClient);

            async Task PerformMultipleOperations(NestedWithMultipleClient client)
            {
                await client.WithQueryAsync("text");

                await client.GetStandaloneAsync();

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithMixedClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithMixedClient("test-name-value");
            await PerformMixedOperations(childClient);

            var directClient = new NestedWithMixedClient(host, "test-name-value", null);
            await PerformMixedOperations(directClient);

            async Task PerformMixedOperations(NestedWithMixedClient client)
            {
                await client.WithQueryAsync("us-west", "text");

                await client.GetStandaloneAsync("us-west");

                await client.DeleteStandaloneAsync("us-west");
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_NestedWithParamAliasClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetNestedWithParamAliasClient("sample-blob");
            await PerformParamAliasOperations(childClient);

            var directClient = new NestedWithParamAliasClient(host, "sample-blob", null);
            await PerformParamAliasOperations(directClient);

            async Task PerformParamAliasOperations(NestedWithParamAliasClient client)
            {
                await client.WithAliasedNameAsync();

                await client.WithOriginalNameAsync();
            }
        });
    }
}

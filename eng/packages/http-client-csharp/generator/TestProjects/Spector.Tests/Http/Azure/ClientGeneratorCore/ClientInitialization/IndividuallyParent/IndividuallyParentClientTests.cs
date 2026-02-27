// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientInitialization._IndividuallyParentClient;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientInitialization.IndividuallyParent
{
    [Ignore("https://github.com/microsoft/typespec/issues/9775")]
    public class IndividuallyParentClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithPathClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithPathClient();
            await PerformPathOperations(childClient);

            var directClient = new IndividuallyParentNestedWithPathClient(host, "test-resource", null);
            await PerformPathOperations(directClient);

            async Task PerformPathOperations(IndividuallyParentNestedWithPathClient client)
            {
                await client.WithQueryAsync("text");

                var response = await client.GetStandaloneAsync();
                Assert.AreEqual("test-resource", response.Value.Name);
                Assert.AreEqual(42, response.Value.Size);
                Assert.AreEqual("text/plain", response.Value.ContentType);
                Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithQueryClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithQueryClient();
            await PerformQueryOperations(childClient);

            var directClient = new IndividuallyParentNestedWithQueryClient(host, "test-blob", null);
            await PerformQueryOperations(directClient);

            async Task PerformQueryOperations(IndividuallyParentNestedWithQueryClient client)
            {
                await client.WithQueryAsync("text");

                var response = await client.GetStandaloneAsync();
                Assert.AreEqual("test-blob", response.Value.Name);
                Assert.AreEqual(42, response.Value.Size);
                Assert.AreEqual("text/plain", response.Value.ContentType);
                Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithHeaderClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithHeaderClient();
            await PerformHeaderOperations(childClient);

            var directClient = new IndividuallyParentNestedWithHeaderClient(host, "test-name-value", null);
            await PerformHeaderOperations(directClient);

            async Task PerformHeaderOperations(IndividuallyParentNestedWithHeaderClient client)
            {
                await client.WithQueryAsync("text");

                await client.GetStandaloneAsync();

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithMultipleClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithMultipleClient();
            await PerformMultipleOperations(childClient);

            var directClient = new IndividuallyParentNestedWithMultipleClient(host, "test-name-value", "us-west", null);
            await PerformMultipleOperations(directClient);

            async Task PerformMultipleOperations(IndividuallyParentNestedWithMultipleClient client)
            {
                await client.WithQueryAsync("text");

                await client.GetStandaloneAsync();

                await client.DeleteStandaloneAsync();
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithMixedClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithMixedClient();
            await PerformMixedOperations(childClient);

            var directClient = new IndividuallyParentNestedWithMixedClient(host, "test-name-value", null);
            await PerformMixedOperations(directClient);

            async Task PerformMixedOperations(IndividuallyParentNestedWithMixedClient client)
            {
                await client.WithQueryAsync("us-west", "text");

                await client.GetStandaloneAsync("us-west");

                await client.DeleteStandaloneAsync("us-west");
            }
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyParentClient_IndividuallyParentNestedWithParamAliasClient() => Test(async (host) =>
        {
            var parentClient = new IndividuallyParentClient(host, null);
            var childClient = parentClient.GetIndividuallyParentNestedWithParamAliasClient();
            await PerformParamAliasOperations(childClient);

            var directClient = new IndividuallyParentNestedWithParamAliasClient(host, "sample-blob", "sample-blob", null);
            await PerformParamAliasOperations(directClient);

            async Task PerformParamAliasOperations(IndividuallyParentNestedWithParamAliasClient client)
            {
                await client.WithAliasedNameAsync();

                await client.WithOriginalNameAsync();
            }
        });
    }
}

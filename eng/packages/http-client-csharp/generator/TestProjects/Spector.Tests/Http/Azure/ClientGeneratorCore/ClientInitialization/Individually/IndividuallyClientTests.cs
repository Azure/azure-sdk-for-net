// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientInitialization.IndividuallyClient;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientInitialization.Individually
{
    public class IndividuallyClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithPath() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithPathClient(host, "test-blob", null);

            await client.WithQueryAsync("text");

            var response = await client.GetStandaloneAsync();
            Assert.AreEqual("test-blob", response.Value.Name);
            Assert.AreEqual(1024, response.Value.Size);
            Assert.AreEqual("application/octet-stream", response.Value.ContentType);
            Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithQuery() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithQueryClient(host, "test-blob", null);

            await client.WithQueryAsync("text");

            var response = await client.GetStandaloneAsync();
            Assert.AreEqual("test-blob", response.Value.Name);
            Assert.AreEqual(1024, response.Value.Size);
            Assert.AreEqual("application/octet-stream", response.Value.ContentType);
            Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithHeader() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithHeaderClient(host, "test-name-value", null);

            await client.WithQueryAsync("text");

            await client.GetStandaloneAsync();

            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithMultiple() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithMultipleClient(host, "test-name-value", "us-west", null);

            await client.WithQueryAsync("text");

            await client.GetStandaloneAsync();

            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithMixed() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithMixedClient(host, "test-name-value", null);

            await client.WithQueryAsync("us-west", "text");

            await client.GetStandaloneAsync("us-west");

            await client.DeleteStandaloneAsync("us-west");
        });

        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/9774")]
        public Task Azure_ClientGenerator_Core_ClientInitialization_IndividuallyClient_IndividuallyNestedWithParamAlias() => Test(async (host) =>
        {
            var client = new IndividuallyNestedWithParamAliasClient(host, "sample-blob", "sample-blob", null);

            await client.WithAliasedNameAsync();

            await client.WithOriginalNameAsync();
        });
    }
}

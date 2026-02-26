// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.ClientInitialization.DefaultClient;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientInitialization.Default
{
    public class DefaultClientTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_HeaderParam() => Test(async (host) =>
        {
            var client = new HeaderParamClient(host, "test-name-value", null);

            await client.WithQueryAsync("test-id");

            await client.WithBodyAsync(new Input("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_MultipleParams() => Test(async (host) =>
        {
            var client = new MultipleParamsClient(host, "test-name-value", "us-west", null);

            await client.WithQueryAsync("test-id");

            await client.WithBodyAsync(new Input("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_MixedParams() => Test(async (host) =>
        {
            var client = new MixedParamsClient(host, "test-name-value", null);

            await client.WithQueryAsync("us-west", "test-id");

            await client.WithBodyAsync("us-west", new WithBodyRequest("test-name"));
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_PathParam() => Test(async (host) =>
        {
            var client = new PathParamClient(host, "sample-blob", null);

            await client.WithQueryAsync("text");

            var response = await client.GetStandaloneAsync();
            Assert.AreEqual("sample-blob", response.Value.Name);
            Assert.AreEqual(42, response.Value.Size);
            Assert.AreEqual("text/plain", response.Value.ContentType);
            Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

            await client.DeleteStandaloneAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_ParamAlias() => Test(async (host) =>
        {
            var client = new ParamAliasClient(host, "sample-blob", "sample-blob", null);

            await client.WithAliasedNameAsync();

            await client.WithOriginalNameAsync();
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientInitialization_DefaultClient_QueryParam() => Test(async (host) =>
        {
            var client = new QueryParamClient(host, "test-blob", null);

            await client.WithQueryAsync("text");

            var response = await client.GetStandaloneAsync();
            Assert.AreEqual("test-blob", response.Value.Name);
            Assert.AreEqual(42, response.Value.Size);
            Assert.AreEqual("text/plain", response.Value.ContentType);
            Assert.AreEqual(new DateTimeOffset(2025, 4, 1, 12, 0, 0, TimeSpan.Zero), response.Value.CreatedOn);

            await client.DeleteStandaloneAsync();
        });
    }
}

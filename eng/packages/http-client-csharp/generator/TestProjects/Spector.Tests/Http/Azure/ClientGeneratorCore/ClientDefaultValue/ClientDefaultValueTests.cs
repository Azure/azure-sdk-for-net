// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.ClientDefaultValue;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ClientDefaultValue
{
    public class ClientDefaultValueTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDefaultValue_PutModelProperty() => Test(async (host) =>
        {
            var response = await new ClientDefaultValueClient(host, null).PutModelPropertyAsync(new ModelWithDefaultValues("test"));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("test", response.Value.Name);
            Assert.AreEqual(30, response.Value.Timeout);
            Assert.AreEqual("standard", response.Value.Tier);
            Assert.AreEqual(true, response.Value.Retry);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDefaultValue_GetOperationParameter() => Test(async (host) =>
        {
            var response = await new ClientDefaultValueClient(host, null).GetOperationParameterAsync("test", pageSize: 10, format: "json");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDefaultValue_GetPathParameter() => Test(async (host) =>
        {
            var response = await new ClientDefaultValueClient(host, null).GetPathParameterAsync("default-segment1", "segment2");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ClientDefaultValue_GetHeaderParameter() => Test(async (host) =>
        {
            var response = await new ClientDefaultValueClient(host, null).GetHeaderParameterAsync(accept: "application/json;odata.metadata=none", customHeader: "default-value");
            Assert.AreEqual(204, response.Status);
        });
    }
}

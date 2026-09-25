// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ClientGenerator.Core.ApiVersion.ClientApiVersions;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ApiVersion.ClientApiVersions
{
    public class ClientApiVersionsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ApiVersion_ClientApiVersions_SendApiVersion() => Test(async (host) =>
        {
            var options = new ClientApiVersionsClientOptions(ClientApiVersionsClientOptions.ServiceVersion.V2022_10_01);
            var response = await new ClientApiVersionsClient(host, options).SendApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}

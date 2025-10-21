// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.AlternateApiVersion.Service.Query;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ApiVersion.Query
{
    public class ApiVersionQueryTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ApiVersion_Query() => Test(async (host) =>
        {
            var response = await new QueryClient(host, null).QueryApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}
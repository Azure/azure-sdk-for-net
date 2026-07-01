// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.AlternateApiVersion.Service.Header;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ApiVersion.Header
{
    public class ApiVersionHeaderTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ApiVersion_Header() => Test(async (host) =>
        {
            var response = await new HeaderClient(host, null).HeaderApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}
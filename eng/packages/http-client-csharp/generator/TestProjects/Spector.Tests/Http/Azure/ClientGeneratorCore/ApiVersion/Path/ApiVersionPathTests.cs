// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.AlternateApiVersion.Service.Path;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.ApiVersion.Path
{
    public class ApiVersionPathTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_ApiVersion_Path() => Test(async (host) =>
        {
            var response = await new PathClient(host, null).PathApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}
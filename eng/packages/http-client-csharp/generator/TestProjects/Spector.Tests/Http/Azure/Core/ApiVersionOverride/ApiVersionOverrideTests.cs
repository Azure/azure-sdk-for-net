// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Specs.Azure.Core.ApiVersionOverride;

namespace TestProjects.Spector.Tests.Http.Azure.Core.ApiVersionOverride
{
    public class ApiVersionOverrideTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_ApiVersionOverride_LegacyClient_get() => Test(async (host) =>
        {
            var response = await new ApiVersionOverrideClient(host, null).GetLegacyClient().GetAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}

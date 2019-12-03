// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class RegionTests : TestBase
    {
        [Fact]
        public async Task List()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var regions = await testBase.client.Region.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(regions);
                Assert.Single(regions);
                Assert.Equal(testBase.location.ToLowerInvariant().Replace(" ", ""), regions.First().Name.ToLowerInvariant().Replace(" ", ""));
                Assert.True(regions.First().IsMasterRegion);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantSettingsTest : TestBase
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task ListAndGetSetting()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list tenant access
                var listSettings = testBase.client.TenantSettings.ListByService(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(listSettings);

                // there is only one setting `public`
                var getSetting = await testBase.client.TenantSettings.GetAsync(testBase.rgName, testBase.serviceName);
                Assert.NotNull(getSetting.Settings);
                Assert.True(getSetting.Settings.Count > 1);
            }
        }
    }
}

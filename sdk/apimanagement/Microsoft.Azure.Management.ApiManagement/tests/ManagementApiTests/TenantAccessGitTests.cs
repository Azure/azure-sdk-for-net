// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Xunit;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantAccessGitTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task GetUpdateKeys()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // get settings
                var getResponse = testBase.client.TenantAccessGit.Get(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse);
                Assert.True(getResponse.Enabled); // git access is always enabled
                Assert.NotNull(getResponse.PrimaryKey);
                Assert.NotNull(getResponse.SecondaryKey);

                testBase.client.TenantAccessGit.RegeneratePrimaryKey(
                    testBase.rgName,
                    testBase.serviceName);

                var getResponse2 = testBase.client.TenantAccessGit.Get(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getResponse2);
                Assert.Equal(getResponse.SecondaryKey, getResponse2.SecondaryKey);
                Assert.NotEqual(getResponse.PrimaryKey, getResponse2.PrimaryKey);

                testBase.client.TenantAccessGit.RegenerateSecondaryKey(
                    testBase.rgName,
                    testBase.serviceName);

                var getTenantAccessResponse = await testBase.client.TenantAccessGit.GetWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getTenantAccessResponse);
                Assert.NotNull(getTenantAccessResponse.Body);
                Assert.NotNull(getTenantAccessResponse.Headers.ETag);
                Assert.NotEqual(getResponse.SecondaryKey, getTenantAccessResponse.Body.SecondaryKey);
            }
        }
    }
}

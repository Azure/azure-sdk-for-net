// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantAccessTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task EnableGetAndUpdateKeys()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // get settings
                var getResponse = testBase.client.TenantAccess.Get(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getResponse);
                Assert.False(getResponse.Enabled);
                Assert.Null(getResponse.PrimaryKey);
                Assert.Null(getResponse.SecondaryKey);

                var getSecrets = testBase.client.TenantAccess.ListSecrets(testBase.rgName, testBase.serviceName);
                Assert.NotNull(getSecrets.PrimaryKey);
                Assert.NotNull(getSecrets.SecondaryKey);

                try
                {
                    // add more settings
                    var parameters = new AccessInformationUpdateParameters
                    {
                        Enabled = true
                    };
                    testBase.client.TenantAccess.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        parameters,
                        "*");

                    var getHttpResponse = await testBase.client.TenantAccess.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName);

                    Assert.NotNull(getHttpResponse);
                    Assert.True(getHttpResponse.Body.Enabled);
                    Assert.NotNull(getHttpResponse.Headers.ETag);

                    testBase.client.TenantAccess.RegeneratePrimaryKey(testBase.rgName, testBase.serviceName);

                    var getSecrets2 = testBase.client.TenantAccess.ListSecrets(testBase.rgName, testBase.serviceName);

                    Assert.NotNull(getSecrets2);
                    Assert.Equal(getSecrets.SecondaryKey, getSecrets2.SecondaryKey);
                    Assert.NotEqual(getSecrets.PrimaryKey, getSecrets2.PrimaryKey);

                    testBase.client.TenantAccess.RegenerateSecondaryKey(testBase.rgName, testBase.serviceName);

                    getSecrets2 = testBase.client.TenantAccess.Get(testBase.rgName, testBase.serviceName);

                    Assert.NotNull(getSecrets2);
                    Assert.NotEqual(getSecrets.SecondaryKey, getSecrets2.SecondaryKey);
                }
                finally
                {
                    testBase.client.TenantAccess.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        new AccessInformationUpdateParameters(enabled: false),
                        "*");
                }
            }
        }
    }
}

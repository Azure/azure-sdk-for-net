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
using Microsoft.Azure.Test.HttpRecorder;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantAccessTests : TestBase
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task EnableGetAndUpdateKeys()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list tenant access
                var getResponse = testBase.client.TenantAccess.ListByService(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getResponse);

                var getSecrets = testBase.client.TenantAccess.ListSecrets(testBase.rgName, testBase.serviceName, "access");
                Assert.NotNull(getSecrets.PrimaryKey);
                Assert.NotNull(getSecrets.SecondaryKey);

                try
                {
                    // add more settings
                    var parameters = new AccessInformationUpdateParameters
                    {
                        Enabled = true
                    };
                    var getUpdateResponse = testBase.client.TenantAccess.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        parameters,
                        "access",
                        "*");

                    Assert.NotNull(getUpdateResponse);
                    Assert.True(getUpdateResponse.Enabled);

                    var getHttpResponse = await testBase.client.TenantAccess.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        "access");

                    Assert.NotNull(getHttpResponse);
                    Assert.True(getHttpResponse.Body.Enabled);
                    Assert.NotNull(getHttpResponse.Headers.ETag);

                    var getEtag = testBase.client.TenantAccess.GetEntityTag(
                        testBase.rgName,
                        testBase.serviceName,
                        "access");

                    Assert.NotNull(getEtag);
                    Assert.NotNull(getEtag.ETag);

                    testBase.client.TenantAccess.RegeneratePrimaryKey(testBase.rgName, testBase.serviceName, "access");

                    var getSecrets2 = testBase.client.TenantAccess.ListSecrets(testBase.rgName, testBase.serviceName, "access");

                    Assert.NotNull(getSecrets2);
                    Assert.Equal(getSecrets.SecondaryKey, getSecrets2.SecondaryKey);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                        Assert.NotEqual(getSecrets.PrimaryKey, getSecrets2.PrimaryKey);

                    testBase.client.TenantAccess.RegenerateSecondaryKey(testBase.rgName, testBase.serviceName, "access");

                    var getSecrets3 = testBase.client.TenantAccess.ListSecrets(testBase.rgName, testBase.serviceName, "access");

                    Assert.NotNull(getSecrets3);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotEqual(getSecrets.SecondaryKey, getSecrets3.SecondaryKey);
                    }
                }
                finally
                {
                    testBase.client.TenantAccess.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        new AccessInformationUpdateParameters(enabled: false),
                        "access",
                        "*");
                }
            }
        }
    }
}

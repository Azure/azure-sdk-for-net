// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Xunit;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Test.HttpRecorder;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantAccessGitTests : TestBase
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task GetUpdateKeys()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // git settings
                var head = await testBase.client.TenantAccess.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    "gitAccess");
                Assert.NotNull(head);

                // get settings
                var getResponse = await testBase.client.TenantAccess.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    "gitAccess");

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse);
                Assert.True(getResponse.Enabled); // git access is always enabled
                Assert.Equal("git", getResponse.PrincipalId);

                var secretsResponse = await testBase.client.TenantAccess.ListSecretsAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    "gitAccess");
                Assert.NotNull(secretsResponse.PrimaryKey);
                Assert.NotNull(secretsResponse.SecondaryKey);

                testBase.client.TenantAccessGit.RegeneratePrimaryKey(
                    testBase.rgName,
                    testBase.serviceName,
                    "access");

                var secretsResponse2 = await testBase.client.TenantAccess.ListSecretsAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    "gitAccess");

                Assert.NotNull(secretsResponse2);
                Assert.Equal(secretsResponse.SecondaryKey, secretsResponse2.SecondaryKey);

                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    Assert.NotEqual(secretsResponse.PrimaryKey, secretsResponse2.PrimaryKey);

                testBase.client.TenantAccessGit.RegenerateSecondaryKey(
                    testBase.rgName,
                    testBase.serviceName,
                    "access");

                var getSecretsHttpResponse = await testBase.client.TenantAccess.ListSecretsWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    "gitAccess");

                Assert.NotNull(getSecretsHttpResponse);
                Assert.NotNull(getSecretsHttpResponse.Body);
                Assert.NotNull(getSecretsHttpResponse.Headers.ETag);
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    Assert.NotEqual(secretsResponse.SecondaryKey, getSecretsHttpResponse.Body.SecondaryKey);
                }
            }
        }
    }
}

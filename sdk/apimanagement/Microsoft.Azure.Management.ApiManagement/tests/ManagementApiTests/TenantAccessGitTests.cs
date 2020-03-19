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
                Assert.Null(getResponse.PrimaryKey);
                Assert.Null(getResponse.SecondaryKey);

                var secretsResponse = testBase.client.TenantAccessGit.ListSecrets(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(secretsResponse.PrimaryKey);
                Assert.NotNull(secretsResponse.SecondaryKey);

                testBase.client.TenantAccessGit.RegeneratePrimaryKey(
                    testBase.rgName,
                    testBase.serviceName);

                var secretsResponse2 = testBase.client.TenantAccessGit.ListSecrets(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(secretsResponse2);
                Assert.Equal(secretsResponse.SecondaryKey, secretsResponse2.SecondaryKey);
                Assert.NotEqual(secretsResponse.PrimaryKey, secretsResponse2.PrimaryKey);

                testBase.client.TenantAccessGit.RegenerateSecondaryKey(
                    testBase.rgName,
                    testBase.serviceName);

                var getSecretsHttpResponse = await testBase.client.TenantAccessGit.ListSecretsWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getSecretsHttpResponse);
                Assert.NotNull(getSecretsHttpResponse.Body);
                Assert.NotNull(getSecretsHttpResponse.Headers.ETag);
                Assert.NotEqual(secretsResponse.SecondaryKey, getSecretsHttpResponse.Body.SecondaryKey);
            }
        }
    }
}

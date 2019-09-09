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
    public class SignInSettingTests : TestBase
    {
        [Fact]
        public async Task CreateUpdateReset()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();
                // get the existing settings on the service
                var portalSignInSettings = await testBase.client.SignInSettings.GetAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(portalSignInSettings);

                // disable portal signIn
                portalSignInSettings.Enabled = false;
                portalSignInSettings = testBase.client.SignInSettings.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    portalSignInSettings);

                Assert.NotNull(portalSignInSettings);
                Assert.False(portalSignInSettings.Enabled);

                // check settings
                var signInTag = await testBase.client.SignInSettings.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(signInTag);
                Assert.NotNull(signInTag.ETag);

                // reset the signIn settings
                portalSignInSettings.Enabled = true;
                await testBase.client.SignInSettings.UpdateAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    portalSignInSettings,
                    signInTag.ETag);

                // get the delegation settings
                portalSignInSettings = await testBase.client.SignInSettings.GetAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(portalSignInSettings);
                Assert.True(portalSignInSettings.Enabled);
            }
        }
    }
}

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
    public class SignUpSettingTests : TestBase
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
                PortalSignupSettings defaultSignupSettings = await testBase.client.SignUpSettings.GetAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(defaultSignupSettings);

                // check settings Etag
                var signUpTag = await testBase.client.SignUpSettings.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(signUpTag);
                Assert.NotNull(signUpTag.ETag);

                // disable portal signIn
                var portalSignUpSettingParams = new PortalSignupSettings()
                {
                    Enabled = false,
                    TermsOfService = defaultSignupSettings.TermsOfService
                };
                var portalSignUpSettings = testBase.client.SignUpSettings.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    portalSignUpSettingParams);
                Assert.NotNull(portalSignUpSettings);
                Assert.False(portalSignUpSettings.Enabled);

                signUpTag = await testBase.client.SignUpSettings.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(signUpTag);
                Assert.NotNull(signUpTag.ETag);

                // reset the signIn settings
                portalSignUpSettings.Enabled = defaultSignupSettings.Enabled;
                portalSignUpSettings.TermsOfService = defaultSignupSettings.TermsOfService;
                await testBase.client.SignUpSettings.UpdateAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    portalSignUpSettings,
                    signUpTag.ETag);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class DelegationSettingTests : TestBase
    {
        [Fact]
        public async Task CreateUpdateReset()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var intialPortalDelegationSettings = await testBase.client.DelegationSettings.GetAsync(
                    testBase.rgName,
                    testBase.serviceName);

                try
                {
                    string delegationServer = TestUtilities.GenerateName("delegationServer");
                    string urlParameter = new UriBuilder("https", delegationServer, 443).Uri.ToString();

                    var portalDelegationSettingsParams = new PortalDelegationSettings()
                    {
                        Subscriptions = new SubscriptionsDelegationSettingsProperties(true),
                        UserRegistration = new RegistrationDelegationSettingsProperties(true),
                        Url = urlParameter,
                        ValidationKey = PortalDelegationSettings.GenerateValidationKey()
                    };
                    var portalDelegationSettings = testBase.client.DelegationSettings.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        portalDelegationSettingsParams);
                    Assert.NotNull(portalDelegationSettings);
                    Assert.Equal(urlParameter, portalDelegationSettings.Url);
                    // validation key is generated brand new on playback mode and hence validation fails
                    //Assert.Equal(portalDelegationSettingsParams.ValidationKey, portalDelegationSettings.ValidationKey);
                    Assert.True(portalDelegationSettings.UserRegistration.Enabled);
                    Assert.True(portalDelegationSettings.Subscriptions.Enabled);

                    // check settings
                    var delegationsTag = await testBase.client.DelegationSettings.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(delegationsTag);
                    Assert.NotNull(delegationsTag.ETag);

                    // update the delegation settings
                    portalDelegationSettings.Subscriptions.Enabled = false;
                    portalDelegationSettings.UserRegistration.Enabled = false;
                    portalDelegationSettings.Url = null;
                    portalDelegationSettings.ValidationKey = null;

                    await testBase.client.DelegationSettings.UpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        portalDelegationSettings,
                        delegationsTag.ETag);

                    // get the delegation settings
                    portalDelegationSettings = await testBase.client.DelegationSettings.GetAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(portalDelegationSettings);
                    Assert.Null(portalDelegationSettings.Url);
                    Assert.Null(portalDelegationSettings.ValidationKey);
                    Assert.False(portalDelegationSettings.UserRegistration.Enabled);
                    Assert.False(portalDelegationSettings.Subscriptions.Enabled);
                }
                finally
                {
                    // due to bug in the api
                    intialPortalDelegationSettings.ValidationKey = null;
                    testBase.client.DelegationSettings.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        intialPortalDelegationSettings,
                        "*");

                }
            }
        }
    }
}

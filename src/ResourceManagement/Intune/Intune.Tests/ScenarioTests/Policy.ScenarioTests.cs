//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using Xunit;
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Intune.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    /// <summary>
    /// Test class for Intune Policy operations: Create/get/patch/delete
    /// </summary>
    [Collection("Intune Tests")]
    public class PolicyScenarioTests:TestBase
    {
        static PolicyScenarioTests()
        {
            IntuneClientHelper.InitializeEnvironment();
        }

        /// <summary>
        /// Verifies that Android policy is created with default properties & the get operation returns the policy by policy name
        /// </summary>
        [Fact]
        public void ShouldCreateAndroidPolicyWithDefaults()
        {            
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                var payload = DefaultAndroidPolicy.GetPayload(friendlyName);
                var policyCreated = client.Android.CreateOrUpdateMAMPolicy(
                    IntuneClientHelper.AsuHostName,
                    policyName,
                    payload);

                var policy = client.Android.GetMAMPolicyByName(IntuneClientHelper.AsuHostName, policyName);
                    
                Assert.True(policy.Id.Contains(policyName));
                Assert.Equal(policy.FriendlyName, friendlyName);

                //Verify defaults                
                Assert.Equal(policy.AppSharingToLevel, AppSharingType.none.ToString());
                Assert.Equal(policy.Description, Properties.Resources.AndroidPolicyDescription);
                Assert.Equal(policy.AppSharingFromLevel, AppSharingType.none.ToString());
                Assert.Equal(policy.Authentication, ChoiceType.required.ToString());
                Assert.Equal(policy.ClipboardSharingLevel, ClipboardSharingLevelType.blocked.ToString());
                Assert.Equal(policy.DataBackup, FilterType.allow.ToString());
                Assert.Equal(policy.FileSharingSaveAs, FilterType.allow.ToString());
                Assert.Equal(policy.Pin, ChoiceType.required.ToString());
                Assert.Equal(policy.PinNumRetry, IntuneConstants.DefaultPinRetries);
                Assert.Equal(policy.DeviceCompliance, OptionType.enable.ToString());
                Assert.Equal(policy.ManagedBrowser, ChoiceType.required.ToString());
                Assert.Equal(policy.AccessRecheckOfflineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessOfflineGraceperiodMinutes));
                Assert.Equal(policy.AccessRecheckOnlineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes));
                Assert.Equal(policy.OfflineWipeTimeout, TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeIntervalDays));

                //Verify Android specific defaults
                Assert.Equal(policy.FileEncryption, ChoiceType.required.ToString());
                Assert.Equal(policy.ScreenCapture, FilterType.allow.ToString());

                client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
            }
        }

        /// <summary>
        /// Verifies that iOS policy is created with default properties & the get operation returns the policy by policy name
        /// </summary>
        [Fact]
        public void ShouldCreateiOSPolicyWithDefaults()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneiOSPolicy);
                var payload = DefaultiOSPolicy.GetPayload(friendlyName);
                try
                {
                    var policyCreated = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName,
                        payload);

                    var policy = client.Ios.GetMAMPolicyByName(IntuneClientHelper.AsuHostName, policyName);
                    Assert.True(policy.Id.Contains(policyName));
                    Assert.Equal(policy.FriendlyName, friendlyName);

                    //Verify defaults                
                    Assert.Equal(policy.AppSharingToLevel, AppSharingType.none.ToString());
                    Assert.Equal(policy.Description, Properties.Resources.AndroidPolicyDescription);
                    Assert.Equal(policy.AppSharingFromLevel, AppSharingType.none.ToString());
                    Assert.Equal(policy.Authentication, ChoiceType.required.ToString());
                    Assert.Equal(policy.ClipboardSharingLevel, ClipboardSharingLevelType.blocked.ToString());
                    Assert.Equal(policy.DataBackup, FilterType.allow.ToString());
                    Assert.Equal(policy.FileSharingSaveAs, FilterType.allow.ToString());
                    Assert.Equal(policy.Pin, ChoiceType.required.ToString());
                    Assert.Equal(policy.PinNumRetry, IntuneConstants.DefaultPinRetries);
                    Assert.Equal(policy.DeviceCompliance, OptionType.enable.ToString());
                    Assert.Equal(policy.ManagedBrowser, ChoiceType.required.ToString());
                    Assert.Equal(policy.AccessRecheckOfflineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessOfflineGraceperiodMinutes));
                    Assert.Equal(policy.AccessRecheckOnlineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes));
                    Assert.Equal(policy.OfflineWipeTimeout, TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeIntervalDays));

                    //Verify iOS specific defaults
                    Assert.Equal(policy.FileEncryptionLevel, DeviceLockType.deviceLocked.ToString());
                    Assert.Equal(policy.TouchId, OptionType.enable.ToString());
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
                }
            }
        }

    /// <summary>
    /// Verifies that Android policy is patched for some properties & the get operation returns the policy by policy name
    /// </summary>
        [Fact]
        public void ShouldPatchAndroidPolicy()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                var payload = DefaultAndroidPolicy.GetPayload(friendlyName);
                try
                {
                    var policyCreated = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName,
                        payload);

                    //Modified properties to patch..
                    var appSharingFromLevelUpdated = AppSharingType.allApps.ToString();
                    var accessRecheckOfflineTimeoutUpdated = new TimeSpan(24, 0, 0);
                    int pinNumRetryUpdated = 50;
                    client.Android.PatchMAMPolicy(IntuneClientHelper.AsuHostName,
                        policyName,
                        new Models.AndroidMAMPolicy
                        {
                            AppSharingFromLevel = appSharingFromLevelUpdated,
                            AccessRecheckOfflineTimeout = accessRecheckOfflineTimeoutUpdated,
                            PinNumRetry = pinNumRetryUpdated
                        });

                    var policy = client.Android.GetMAMPolicyByName(IntuneClientHelper.AsuHostName, policyName);

                    Assert.True(policy.Id.Contains(policyName));
                    Assert.Equal(policy.FriendlyName, friendlyName);

                    //Verify updated properties
                    Assert.Equal(policy.AppSharingFromLevel, appSharingFromLevelUpdated);
                    Assert.Equal(policy.AccessRecheckOfflineTimeout, accessRecheckOfflineTimeoutUpdated);
                    Assert.Equal(policy.PinNumRetry, pinNumRetryUpdated);

                    //Verify couple of properties that are not supposed to be updated.
                    Assert.Equal(policy.ScreenCapture, FilterType.allow.ToString());
                    Assert.Equal(policy.AccessRecheckOnlineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes));
                }
                finally
                {
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
                }
                
            }
        }

        /// <summary>
        /// Verifies that IOS policy is patched & the get operation returns the policy by policy name
        /// </summary>
        [Fact]
        public void ShouldPatchiOSPolicy()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneiOSPolicy);
                var payload = DefaultiOSPolicy.GetPayload(friendlyName);
                try
                {
                    var policyCreated = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName,
                        payload);

                    //Modified properties to patch..
                    var appSharingFromLevelUpdated = AppSharingType.allApps.ToString();
                    var accessRecheckOfflineTimeoutUpdated = new TimeSpan(24, 0, 0);
                    int pinNumRetryUpdated = 50;
                    client.Ios.PatchMAMPolicy(IntuneClientHelper.AsuHostName,
                        policyName,
                        new Models.IOSMAMPolicy
                        {
                            AppSharingFromLevel = appSharingFromLevelUpdated,
                            AccessRecheckOfflineTimeout = accessRecheckOfflineTimeoutUpdated,
                            PinNumRetry = pinNumRetryUpdated
                        });

                    var policy = client.Ios.GetMAMPolicyByName(IntuneClientHelper.AsuHostName, policyName);

                    Assert.True(policy.Id.Contains(policyName));
                    Assert.Equal(policy.FriendlyName, friendlyName);

                    //Verify updated properties
                    Assert.Equal(policy.AppSharingFromLevel, appSharingFromLevelUpdated);
                    Assert.Equal(policy.AccessRecheckOfflineTimeout, accessRecheckOfflineTimeoutUpdated);
                    Assert.Equal(policy.PinNumRetry, pinNumRetryUpdated);

                    //Verify couple of properties that are not supposed to be updated.
                    Assert.Equal(policy.ManagedBrowser, ChoiceType.required.ToString());
                    Assert.Equal(policy.AccessRecheckOnlineTimeout, TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes));
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
                }
            }
        }

        /// <summary>
        /// Verifies that multiple Android policies are created & the get operation returns all the policies
        /// </summary>
        [Fact]
        public void ShouldGetMultipleAndroidPolicies()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName1 = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy1").ToString();
                string policyName2 = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy2").ToString();
                try
                {
                    string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);                    
                    var payload1 = DefaultAndroidPolicy.GetPayload(friendlyName1);
                    var policyCreated1 = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName1,
                        payload1);

                    string friendlyName2 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);                    
                    var payload2 = DefaultAndroidPolicy.GetPayload(friendlyName2);
                    var policyCreated2 = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName2,
                        payload2);

                    var policies = client.Android.GetMAMPolicies(IntuneClientHelper.AsuHostName, null).ToList();
                    int cnt = 0;
                    policies.ForEach(p => { if (p.FriendlyName == friendlyName1 || p.FriendlyName == friendlyName2) cnt++; });
                    Assert.True(2 == cnt, "Less than 2 created policies returned");
                }
                finally
                {
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName1);
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName2);
                }
            }
        }
    

        /// <summary>
        /// Verifies that multiple Android policies are created & the get operation returns all the policies
        /// </summary>
        [Fact]
        public void ShouldGetMultipleiOSPolicies()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.PolicyScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyName1 = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy1").ToString();
                string policyName2 = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy2").ToString();
                try
                {                    
                    string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                    string friendlyName2 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                    List<IOSMAMPolicy> policies = new List<IOSMAMPolicy>();
                    var payload1 = DefaultiOSPolicy.GetPayload(friendlyName1);
                    var policyCreated1 = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName1,
                        payload1);

                    policyName2 = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                    
                    var payload2 = DefaultiOSPolicy.GetPayload(friendlyName1);
                    var policyCreated2 = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName2,
                        payload2);

                    policies = client.Ios.GetMAMPolicies(IntuneClientHelper.AsuHostName, null).ToList();
                    int cnt = 0;
                    policies.ForEach(p => { if (p.FriendlyName == friendlyName1 || p.FriendlyName == friendlyName2) cnt++; });
                    Assert.True(2 == cnt, "Less than 2 created policies returned");
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName1);                    
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName2);                    
                }

            }
        }


    }
}

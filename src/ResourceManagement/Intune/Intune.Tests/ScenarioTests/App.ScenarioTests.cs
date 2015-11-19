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
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    /// <summary>
    /// Test class for linking/Unlinking Apps to an Intune Policy
    /// </summary>
    public class AppScenarioTests:TestBase
    {
        static AppScenarioTests()
        {
            IntuneClientHelper.InitializeEnvironment();
        }

        /// <summary>
        /// Verifies that get iOS apps returns positive number of apps
        /// </summary>
        [Fact]
        public void ShouldGetiOSMAMApps()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.iOS.ToString().ToLower());
                var iOSApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                Assert.True(iOSApps.Count > 0);
            }
        }

        /// <summary>
        /// Verifies that get Android apps returns positive number of apps
        /// </summary>
        [Fact]
        public void ShouldGetAndroidMAMApps()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.Android.ToString().ToLower());
                var androidApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                Assert.True(androidApps.Count > 0);
            }
        }

        /// <summary>
        /// Verifies that you can Add an android app to android policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveAndroidMAMAppForPolicy()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                
                //Create a policy              
                string policyId = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();                
                string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                var payload = DefaultAndroidPolicy.GetPayload(friendlyName1);
                try
                {
                    var policyCreated1 = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyId,
                        payload);

                    //Get apps for Android
                    string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.Android.ToString().ToLower());
                    var androidApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                    Assert.True(androidApps.Count >= 2);

                    //Add app for the policy
                    var appPayload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, androidApps[0].Name);
                    client.Android.AddAppForPolicy(IntuneClientHelper.AsuHostName, policyId, androidApps[0].Name, appPayload1);

                    var appPayload2 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, androidApps[1].Name);
                    client.Android.AddAppForPolicy(IntuneClientHelper.AsuHostName, policyId, androidApps[1].Name, appPayload2);

                    //Get Apps for the policy
                    var apps = client.Android.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(apps.Count == 2);

                    //Remove Apps for the policy
                    client.Android.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, androidApps[0].Name);
                    client.Android.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, androidApps[1].Name);

                    //Get Apps for the policy
                    apps = client.Android.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(apps.Count == 0);
                }
                finally
                {
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyId);
                }
            }
        }


        /// <summary>
        /// Verifies that you can Add an ios app to iOS policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveiOSMAMAppForPolicy()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);

                //Create a policy              
                string policyId = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneiOSPolicy);
                var payload = DefaultiOSPolicy.GetPayload(friendlyName1);
                try
                {
                    var policyCreated1 = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyId,
                        payload);

                    //Get apps for iOS
                    string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.iOS.ToString().ToLower());
                    var iosApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                    Assert.True(iosApps.Count >= 2, string.Format("Expected iOSAppsCount>=2 and actual:{0}", iosApps.Count));

                    //Add app for the policy
                    var payload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, iosApps[0].Name);
                    client.Ios.AddAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, iosApps[0].Name, payload1);

                    var payload2 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, iosApps[1].Name);
                    client.Ios.AddAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, iosApps[1].Name, payload2);

                    //Get Apps for the policy
                    var apps = client.Ios.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(apps.Count == 2);

                    //Remove Apps for the policy
                    client.Ios.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, iosApps[0].Name);
                    client.Ios.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, iosApps[1].Name);

                    //Get Apps for the policy
                    apps = client.Ios.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(apps.Count == 0);
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyId);
                }
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    [Collection("Intune Tests")]
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
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.AppScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.iOS.ToString().ToLower());
                var iOSApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                Assert.True(iOSApps.Count >= 1, string.Format("Expected iOSApps.Count>=1 and actual:{0}", iOSApps.Count));
            }
        }

        /// <summary>
        /// Verifies that get Android apps returns positive number of apps
        /// </summary>
        [Fact]
        public void ShouldGetAndroidMAMApps()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.AppScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.Android.ToString().ToLower());
                var androidApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                Assert.True(androidApps.Count >= 1, string.Format("Expected androidApps.Count>=1 and actual:{0}", androidApps.Count));
            }
        }

        /// <summary>
        /// Verifies that you can Add an android app to android policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveAndroidMAMAppForPolicy()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.AppScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                
                //Create a policy              
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();                
                string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                var payload = DefaultAndroidPolicy.GetPayload(friendlyName1);
                try
                {
                    var policyCreated1 = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName,
                        payload);

                    //Get apps for Android
                    string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.Android.ToString().ToLower());
                    var androidApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                    Assert.True(androidApps.Count >= 1, string.Format("Expected androidApps.Count>=1 and actual:{0}", androidApps.Count));

                    //Add app for the policy
                    var appPayload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, androidApps[0].Name);
                    client.Android.AddAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName, androidApps[0].Name, appPayload1);

                    //Get Apps for the policy
                    var apps = client.Android.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName).ToList();
                    Assert.True(apps.Count == 1, string.Format("Expected apps.Count==1 and actual:{0}", apps.Count));

                    //Remove Apps for the policy
                    client.Android.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName, androidApps[0].Name);                    

                    //Get Apps for the policy
                    apps = client.Android.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName).ToList();
                    Assert.True(apps.Count == 0, string.Format("Expected apps.Count==0 and actual:{0}", apps.Count));
                }
                finally
                {
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
                }
            }
        }


        /// <summary>
        /// Verifies that you can Add an ios app to iOS policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveiOSMAMAppForPolicy()
        {
            using (MockContext context = MockContext.Start("Microsoft.Azure.Management.Intune.Tests.ScenarioTests.AppScenarioTests"))
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);

                //Create a policy              
                string policyName = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName1 = TestUtilities.GenerateName(IntuneConstants.IntuneiOSPolicy);
                var payload = DefaultiOSPolicy.GetPayload(friendlyName1);
                try
                {
                    var policyCreated1 = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyName,
                        payload);

                    //Get apps for iOS
                    string filter = string.Format(IntuneConstants.PlatformTypeQuery, PlatformType.iOS.ToString().ToLower());
                    var iosApps = client.GetApps(IntuneClientHelper.AsuHostName, filter).ToList();
                    Assert.True(iosApps.Count >= 1, string.Format("Expected iosApps.Count>=1 and actual:{0}", iosApps.Count));

                    //Add app for the policy
                    var payload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.AppType, iosApps[0].Name);
                    client.Ios.AddAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName, iosApps[0].Name, payload1);

                    //Get Apps for the policy
                    var apps = client.Ios.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName).ToList();
                    Assert.True(apps.Count == 1, string.Format("Expected apps.Count==1 and actual:{0}", apps.Count));

                    //Remove Apps for the policy
                    client.Ios.DeleteAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName, iosApps[0].Name);                    

                    //Get Apps for the policy
                    apps = client.Ios.GetAppForMAMPolicy(IntuneClientHelper.AsuHostName, policyName).ToList();
                    Assert.True(apps.Count == 0, string.Format("Expected apps.Count==0 and actual:{0}", apps.Count));
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyName);
                }
            }
        }
    }
}

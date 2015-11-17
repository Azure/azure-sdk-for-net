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
using System.Collections.Generic;
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    /// <summary>
    /// Test class for linking/Unlinking groups to an Intune Policy
    /// </summary>
    public class GroupScenarioTests : TestBase
    {
        private AADClientHelper aadClient;
        public GroupScenarioTests()
        {
            IntuneClientHelper.InitializeEnvironment();
            var orgIdAuth = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            var parts = orgIdAuth.Split(new char[] { ';' }).ToList();
            var authParams = new Dictionary<string, string>();
            parts.ForEach(a => { var splitVal = a.Split(new char[] { '=' }); authParams.Add(splitVal[0], splitVal[1]); });
            EnvironmentType enType = EnvironmentType.Dogfood;
            if(authParams["Environment"] == "Dogfood")
            {
                enType = EnvironmentType.Dogfood;
            }
            else if(authParams["Environment"] == "Prod")
            {
                enType = EnvironmentType.Prod;
            }

            aadClient = new AADClientHelper(authParams["UserId"], authParams["Password"], enType);            
        }


        /// <summary>
        /// Verifies that you can Add a tenant group to android policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveAndroidMAMGroupsForPolicy()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                
                //Create a policy              
                string policyId = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneAndroidPolicy);
                var payload = DefaultAndroidPolicy.GetPayload(friendlyName);
                try
                {
                    var policyCreated1 = client.Android.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyId,
                        payload);

                    //Get groups for tenant
                    var adGroups = aadClient.GetUserGroups().GetAwaiter().GetResult();
                    var adGroupList = adGroups.Where(x => x.Keys.Contains("ID")).Select(x => x["ID"]).ToList();
                    Assert.True(adGroupList.Count >= 2);

                    //Add group for the policy
                    var groupPayload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.GroupType, adGroupList.ElementAt(0));
                    client.Android.AddGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(0), groupPayload1);

                    var groupPayload2 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.GroupType, adGroupList.ElementAt(1));
                    client.Android.AddGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(1), groupPayload2);

                    //Get groups for the policy
                    var groups = client.Android.GetGroupsForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(groups.Count == 2);

                    //Remove groups from the policy
                    client.Android.DeleteGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(0));
                    client.Android.DeleteGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(1));

                    //Get groups for the policy & verify groups are removed.
                    groups = client.Android.GetGroupsForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(groups.Count == 0);
                }
                finally
                {
                    client.Android.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyId);
                }                
            }
        }

        /// <summary>
        /// Verifies that you can Add a tenant group to ios policy & also query for them, remove them
        /// </summary>
        [Fact]
        public void ShouldAddAndRemoveiOSMAMGroupsForPolicy()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                
                //Create a policy              
                string policyId = TestContextHelper.GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "IntunePolicy").ToString();
                string friendlyName = TestUtilities.GenerateName(IntuneConstants.IntuneiOSPolicy);
                var payload = DefaultiOSPolicy.GetPayload(friendlyName);
                try
                {
                    var policyCreated1 = client.Ios.CreateOrUpdateMAMPolicy(
                        IntuneClientHelper.AsuHostName,
                        policyId,
                        payload);

                    //Get groups for tenant
                    var adGroups = aadClient.GetUserGroups().GetAwaiter().GetResult();
                    var adGroupList = adGroups.Where(x => x.Keys.Contains("ID")).Select(x => x["ID"]).ToList();
                    Assert.True(adGroupList.Count >= 2);

                    //Add group for the policy
                    var groupPayload1 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.GroupType, adGroupList.ElementAt(0));
                    client.Ios.AddGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(0), groupPayload1);

                    var groupPayload2 = AppOrGroupPayloadMaker.PrepareMAMPolicyPayload(client, LinkType.GroupType, adGroupList.ElementAt(1));
                    client.Ios.AddGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(1), groupPayload2);

                    //Get groups for the policy
                    var groups = client.Ios.GetGroupsForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(groups.Count == 2);

                    //Remove groups for the policy
                    client.Ios.DeleteGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(0));
                    client.Ios.DeleteGroupForMAMPolicy(IntuneClientHelper.AsuHostName, policyId, adGroupList.ElementAt(1));

                    //Get groups for the policy & verify unlinking
                    groups = client.Ios.GetGroupsForMAMPolicy(IntuneClientHelper.AsuHostName, policyId).ToList();
                    Assert.True(groups.Count == 0);
                }
                finally
                {
                    client.Ios.DeleteMAMPolicy(IntuneClientHelper.AsuHostName, policyId);
                }
            }
        }
    }
}

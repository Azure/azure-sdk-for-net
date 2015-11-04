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
//

using Microsoft.Azure.Management.Intune;
using Microsoft.Azure.Management.Intune.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;
namespace Microsoft.Azure.Management.Intune.Tests.ScenarioTests
{
    public class PolicyScenarioTests:TestBase
    {
        static PolicyScenarioTests()
        {
            // Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=cfead826-670f-4c45-8f3f-cfee4217d76b;Environment=Dogfood;UserId=admin@aad182.ccsctp.net;Password=Pa$$w0rd");
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
        }

        [Fact]
        public void ShouldCreateAndroidPolicy()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = IntuneClientHelper.GetIntuneResourceManagementClient(context);
                string policyId = Guid.NewGuid().ToString();
                string friendlyName = "testAndroidPolicy";
                var policy = client.Android.CreateOrUpdateMAMPolicy(IntuneClientHelper.AsuHostName, policyId, new Models.AndroidMAMPolicy
                {
                    FriendlyName = friendlyName
                });

                Assert.Equal(policy.Id, policyId);
                Assert.Equal(policy.FriendlyName, friendlyName);
            }
        }

    }
}

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

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class AuthorizationPolicyScenarioTests
    {
        static AuthorizationPolicyScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CreateAndReadAuthorizationPolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var policyName = TestUtilities.GenerateName("testPolicy");

                var policyResourceFormat = new AuthorizationPolicyResourceFormat
                                               {
                                                   Permissions =
                                                       new List<PermissionTypes?>
                                                           {
                                                               PermissionTypes.Read,
                                                               PermissionTypes.Write,
                                                               PermissionTypes.Manage
                                                           },
                                                   PrimaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("primaryTestRead")),
                                                   SecondaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("secondaryTestRead"))
                                               };

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    policyResourceFormat);

                Assert.Equal(policyName, resultPolicy.PolicyName);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    resultPolicy.Type,
                    "Microsoft.CustomerInsights/hubs/AuthorizationPolicies",
                    StringComparer.OrdinalIgnoreCase);

                Thread.Sleep(100);

                var getResultPolicy = aciClient.AuthorizationPolicies.Get(ResourceGroupName, HubName, policyName);
                Assert.Equal(policyName, getResultPolicy.PolicyName);
                Assert.Equal(getResultPolicy.Name, HubName + "/" + policyName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    getResultPolicy.Type,
                    "Microsoft.CustomerInsights/hubs/AuthorizationPolicies",
                    StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void ListAuthorizationPolicies()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var policyName1 = TestUtilities.GenerateName("testPolicy");
                var policyName2 = TestUtilities.GenerateName("testPolicy");

                var policyResourceFormat1 = new AuthorizationPolicyResourceFormat
                                                {
                                                    Permissions =
                                                        new List<PermissionTypes?>
                                                            {
                                                                PermissionTypes.Read,
                                                                PermissionTypes.Write,
                                                                PermissionTypes.Manage
                                                            },
                                                    PrimaryKey =
                                                        Convert.ToBase64String(Encoding.UTF8.GetBytes("primaryTestRead1")),
                                                    SecondaryKey =
                                                        Convert.ToBase64String(Encoding.UTF8.GetBytes("secondaryTestRead1"))
                                                };

                var policyResourceFormat2 = new AuthorizationPolicyResourceFormat
                                                {
                                                    Permissions =
                                                        new List<PermissionTypes?>
                                                            {
                                                                PermissionTypes.Read,
                                                                PermissionTypes.Write,
                                                                PermissionTypes.Manage
                                                            },
                                                    PrimaryKey =
                                                        Convert.ToBase64String(Encoding.UTF8.GetBytes("primaryTestRead2")),
                                                    SecondaryKey =
                                                        Convert.ToBase64String(Encoding.UTF8.GetBytes("secondaryTestRead2"))
                                                };

                aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName1,
                    policyResourceFormat1);
                aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName2,
                    policyResourceFormat2);

                Thread.Sleep(1000);

                var policyList = aciClient.AuthorizationPolicies.ListByHub(ResourceGroupName, HubName);

                Assert.True(policyList.ToList().Count >= 2);
                Assert.True(
                    policyList.ToList().Any(policyReturned => policyName1 == policyReturned.PolicyName)
                    && policyList.ToList().Any(policyReturned => policyName2 == policyReturned.PolicyName));
            }
        }

        [Fact]
        public void RegeneratePrimaryKey()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var policyName = TestUtilities.GenerateName("testPolicy");

                var policyResourceFormat = new AuthorizationPolicyResourceFormat
                                               {
                                                   Permissions =
                                                       new List<PermissionTypes?>
                                                           {
                                                               PermissionTypes.Read,
                                                               PermissionTypes.Write,
                                                               PermissionTypes.Manage
                                                           },
                                                   PrimaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("primaryTestRead")),
                                                   SecondaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("secondaryTestRead"))
                                               };

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    policyResourceFormat);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName);
                Assert.Equal(resultPolicy.Type, "Microsoft.CustomerInsights/hubs/AuthorizationPolicies");

                var policyWithNewKey = aciClient.AuthorizationPolicies.RegeneratePrimaryKey(
                    ResourceGroupName,
                    HubName,
                    policyName);
                Assert.NotEqual(resultPolicy.PrimaryKey, policyWithNewKey.PrimaryKey);
                Assert.NotEmpty(policyWithNewKey.PrimaryKey);
            }
        }

        [Fact]
        public void RegenerateSecondaryKey()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var policyName = TestUtilities.GenerateName("testPolicy");

                var policyResourceFormat = new AuthorizationPolicyResourceFormat
                                               {
                                                   Permissions =
                                                       new List<PermissionTypes?>
                                                           {
                                                               PermissionTypes.Read,
                                                               PermissionTypes.Write,
                                                               PermissionTypes.Manage
                                                           },
                                                   PrimaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("primaryTestRead")),
                                                   SecondaryKey =
                                                       Convert.ToBase64String(Encoding.UTF8.GetBytes("secondaryTestRead"))
                                               };

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    policyResourceFormat);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName);
                Assert.Equal(resultPolicy.Type, "Microsoft.CustomerInsights/hubs/AuthorizationPolicies");
                var policyWithNewKey = aciClient.AuthorizationPolicies.RegenerateSecondaryKey(
                    ResourceGroupName,
                    HubName,
                    policyName);

                Assert.NotEqual(resultPolicy.SecondaryKey, policyWithNewKey.SecondaryKey);
                Assert.NotEmpty(policyWithNewKey.SecondaryKey);
            }
        }
    }
}
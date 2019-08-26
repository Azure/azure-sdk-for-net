// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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

        /// <summary>
        ///     The test policy
        /// </summary>
        private readonly AuthorizationPolicyResourceFormat testPolicy = new AuthorizationPolicyResourceFormat
                                                                            {
                                                                                Permissions =
                                                                                    new List<PermissionTypes?>
                                                                                        {
                                                                                            PermissionTypes.Read,
                                                                                            PermissionTypes.Write,
                                                                                            PermissionTypes.Manage
                                                                                        },
                                                                                PrimaryKey =
                                                                                    Convert.ToBase64String(
                                                                                        Encoding.UTF8.GetBytes(
                                                                                            "primaryTestRead")),
                                                                                SecondaryKey =
                                                                                    Convert.ToBase64String(
                                                                                        Encoding.UTF8.GetBytes(
                                                                                            "secondaryTestRead"))
                                                                            };

        [Fact]
        public void CreateAndReadAuthorizationPolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var policyName = TestUtilities.GenerateName("testPolicy");

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    this.testPolicy);

                Assert.Equal(policyName, resultPolicy.PolicyName);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/AuthorizationPolicies",
                    resultPolicy.Type, StringComparer.OrdinalIgnoreCase);

                TestUtilities.Wait(1000);

                var getResultPolicy = aciClient.AuthorizationPolicies.Get(ResourceGroupName, HubName, policyName);
                Assert.Equal(policyName, getResultPolicy.PolicyName);
                Assert.Equal(getResultPolicy.Name, HubName + "/" + policyName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/AuthorizationPolicies",
                    getResultPolicy.Type, StringComparer.OrdinalIgnoreCase);
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

                aciClient.AuthorizationPolicies.CreateOrUpdate(ResourceGroupName, HubName, policyName1, this.testPolicy);
                aciClient.AuthorizationPolicies.CreateOrUpdate(ResourceGroupName, HubName, policyName2, this.testPolicy);

                TestUtilities.Wait(1000);

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

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    this.testPolicy);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName);
                Assert.Equal("Microsoft.CustomerInsights/hubs/AuthorizationPolicies", resultPolicy.Type);

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

                var resultPolicy = aciClient.AuthorizationPolicies.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    policyName,
                    this.testPolicy);
                Assert.Equal(resultPolicy.Name, HubName + "/" + policyName);
                Assert.Equal("Microsoft.CustomerInsights/hubs/AuthorizationPolicies", resultPolicy.Type);
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
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Cdn.Tests.ScenarioTests
{
    public class ADFSecurityPolicyTest
    {
        [Fact]
        public void AFDOriginCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor security policy
                    string securityPolicyName = TestUtilities.GenerateName("securityPolicy");
                    var policyCreateParameters = new SecurityPolicyWebApplicationFirewallParameters
                    {
                        Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>
                        {
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/*"
                                },
                            }
                        },
                        WafPolicy = new ResourceReference(id: "/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourcegroups/chengll-test3632/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/hellowaf"),
                    };
                    var securityPolicy = cdnMgmtClient.SecurityPolicies.Create(resourceGroupName, profileName, securityPolicyName, policyCreateParameters);
                    Assert.NotNull(securityPolicy);
                    Assert.NotNull(securityPolicy.ProvisioningState);
                    Assert.NotNull(securityPolicy.Parameters);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact(Skip = "Not Ready")]
        public void AFDOriginUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor security policy
                    string securityPolicyName = TestUtilities.GenerateName("securityPolicy");
                    var policyCreateParameters = new SecurityPolicyWebApplicationFirewallParameters
                    {
                        Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>
                        {
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/*"
                                },
                            }
                        },
                        WafPolicy = new ResourceReference(id: "/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourcegroups/chengll-test3632/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/hellowaf"),
                    };
                    var securityPolicy = cdnMgmtClient.SecurityPolicies.Create(resourceGroupName, profileName, securityPolicyName, policyCreateParameters);


                    // Create a standard Azure frontdoor endpoint
                    string endpointName2 = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters2 = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint2 = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName2, endpointCreateParameters2);
                    var policyPatchParameters = new SecurityPolicyWebApplicationFirewallParameters
                    {
                        Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>
                        {
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/a"
                                },
                            },
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint2.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/a"
                                },
                            }
                        },
                        WafPolicy = new ResourceReference(id: "/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourcegroups/chengll-test3632/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/hellowaf"),
                    };
                    var patchedPolicy = cdnMgmtClient.SecurityPolicies.Patch(resourceGroupName, profileName, securityPolicyName, policyPatchParameters);
                    Assert.NotNull(patchedPolicy);
                    Assert.NotNull(patchedPolicy.ProvisioningState);
                    Assert.NotNull(patchedPolicy.Parameters);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }
       

        [Fact]
        public void AFDOriginDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor security policy
                    string securityPolicyName = TestUtilities.GenerateName("securityPolicy");
                    var policyCreateParameters = new SecurityPolicyWebApplicationFirewallParameters
                    {
                        Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>
                        {
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/*"
                                },
                            }
                        },
                        WafPolicy = new ResourceReference(id: "/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourcegroups/chengll-test3632/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/hellowaf"),
                    };
                    var securityPolicy = cdnMgmtClient.SecurityPolicies.Create(resourceGroupName, profileName, securityPolicyName, policyCreateParameters);
                    cdnMgmtClient.SecurityPolicies.Delete(resourceGroupName, profileName, securityPolicyName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void AFDOriginGetListTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor security policy
                    string securityPolicyName = TestUtilities.GenerateName("securityPolicy");
                    var policyCreateParameters = new SecurityPolicyWebApplicationFirewallParameters
                    {
                        Associations = new List<SecurityPolicyWebApplicationFirewallAssociation>
                        {
                            new SecurityPolicyWebApplicationFirewallAssociation
                            {
                                Domains = new List<ResourceReference>{
                                    new ResourceReference(endpoint.Id),
                                },
                                PatternsToMatch = new List<string>
                                {
                                    "/*"
                                },
                            }
                        },
                        WafPolicy = new ResourceReference(id: "/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourcegroups/chengll-test3632/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/hellowaf"),
                    };
                    var securityPolicy = cdnMgmtClient.SecurityPolicies.Create(resourceGroupName, profileName, securityPolicyName, policyCreateParameters);
                    Assert.NotNull(securityPolicy);
                    Assert.NotNull(securityPolicy.ProvisioningState);
                    Assert.NotNull(securityPolicy.Parameters);

                    var getSecurityPolicy = cdnMgmtClient.SecurityPolicies.Get(resourceGroupName, profileName, securityPolicyName);
                    Assert.NotNull(getSecurityPolicy);
                    Assert.NotNull(getSecurityPolicy.ProvisioningState);
                    Assert.NotNull(getSecurityPolicy.Parameters);

                    var listSecurityPolicy = cdnMgmtClient.SecurityPolicies.ListByProfile(resourceGroupName, profileName);
                    Assert.NotNull(listSecurityPolicy);
                    Assert.Single(listSecurityPolicy);

                    cdnMgmtClient.SecurityPolicies.Delete(resourceGroupName, profileName, securityPolicyName);
                    listSecurityPolicy = cdnMgmtClient.SecurityPolicies.ListByProfile(resourceGroupName, profileName);
                    Assert.NotNull(listSecurityPolicy);
                    Assert.Empty(listSecurityPolicy);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }
    }
}

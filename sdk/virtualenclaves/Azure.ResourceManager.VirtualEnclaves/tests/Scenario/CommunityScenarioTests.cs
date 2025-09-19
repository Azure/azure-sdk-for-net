// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.VirtualEnclaves.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.VirtualEnclaves.Tests.Scenario
{
    public class CommunityScenarioTests
    {
        [Test]
        [Ignore("Only validating compilation of scenario")]
        public async Task Create_CommunityWithBasicSettings()
        {
            // Arrange
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            string subscriptionId = "00000000-0000-0000-0000-000000000000"; // Replace with actual subscription in real test
            string resourceGroupName = "TestCommunityRg";
            string communityName = "TestCommunity";

            var communityData = new VirtualEnclaveCommunityData()
            {
                Location = "westus2",
                Properties = new VirtualEnclaveCommunityProperties
                {
                    AddressSpace = "10.0.0.0/16",
                    FirewallSku = VirtualEnclaveFirewallSku.Standard,
                    PolicyOverride = VirtualEnclaveCommunityPolicyOverride.Enclave,
                    ApprovalSettings = new VirtualEnclaveApprovalSettings
                    {
                        EndpointCreation = VirtualEnclaveApprovalPolicy.Required,
                        EndpointUpdate = VirtualEnclaveApprovalPolicy.Required,
                        EndpointDeletion = VirtualEnclaveApprovalPolicy.Required,
                        ConnectionCreation = VirtualEnclaveApprovalPolicy.Required,
                        ConnectionUpdate = VirtualEnclaveApprovalPolicy.Required,
                        ConnectionDeletion = VirtualEnclaveApprovalPolicy.Required
                    }
                },
                Tags =
                {
                    { "Environment", "Test" },
                    { "Department", "Engineering" }
                }
            };

            // Add DNS servers
            communityData.Properties.DnsServers.Add("168.63.129.16");

            // Add governed service
            communityData.Properties.GovernedServiceList.Add(new VirtualEnclaveGovernedService(VirtualEnclaveGovernedServiceIdentifier.MicrosoftSql)
            {
                Option = ServiceGovernanceOptionType.Allow,
                Enforcement = ServiceInitiativeEnforcement.Enabled
            });

            // Add role assignment
            var roleAssignment = new VirtualEnclaveRoleAssignmentItem("/providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635"); // Owner role
            roleAssignment.Principals.Add(new VirtualEnclavePrincipal(Guid.NewGuid().ToString(), VirtualEnclavePrincipalType.User)); // This would be an actual user ID in real test
            communityData.Properties.CommunityRoleAssignments.Add(roleAssignment);

            // Get the subscription resource
            SubscriptionResource subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{subscriptionId}"));

            // Get the resource group
            var operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource resourceGroup = operation.Value;

            // Act
            var collection = resourceGroup.GetVirtualEnclaveCommunities();
            var community = await collection.CreateOrUpdateAsync(WaitUntil.Completed, communityName, communityData);

            // Assert
            Assert.That(community.Value.Data.Name, Is.EqualTo(communityName));
            Assert.That(community.Value.Data.Properties.AddressSpace, Is.EqualTo("10.0.0.0/16"));
            Assert.That(community.Value.Data.Properties.FirewallSku, Is.EqualTo(VirtualEnclaveFirewallSku.Standard));
            Assert.That(community.Value.Data.Properties.PolicyOverride, Is.EqualTo(VirtualEnclaveCommunityPolicyOverride.Enclave));
            Assert.That(community.Value.Data.Properties.ApprovalSettings.EndpointCreation, Is.EqualTo(VirtualEnclaveApprovalPolicy.Required));
            Assert.That(community.Value.Data.Properties.ApprovalSettings.ConnectionCreation, Is.EqualTo(VirtualEnclaveApprovalPolicy.Required));
            Assert.That(community.Value.Data.Properties.DnsServers, Has.Member("168.63.129.16"));
            Assert.That(community.Value.Data.Properties.GovernedServiceList, Has.Count.EqualTo(1));
            Assert.That(community.Value.Data.Properties.CommunityRoleAssignments, Has.Count.EqualTo(1));
        }
    }
}

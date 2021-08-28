#region Snippet:Managing_Policies_Namespaces
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample4_ManagingPolicies
    {
        private ArmClient armClient;
        private ResourceGroup resourceGroup;
        private Subscription subscription;

        private PolicyDefinition policyDefinition;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreatePolicyDefinition()
        {
            #region Snippet:Managing_Policies_CreatePolicyDefinition
            string policyDefinitionName = "myPolicyDef";
            PolicyDefinitionData policyDefinitionData = new PolicyDefinitionData
            {
                DisplayName = $"AutoTest ${policyDefinitionName}",
                PolicyRule = new Dictionary<string, object>
                {
                    {
                        "if", new Dictionary<string, object>
                        {
                            { "source", "action" },
                            { "equals", "ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write"}
                        }
                    },
                    {
                        "then", new Dictionary<string, object>
                        {
                            { "effect", "deny" }
                        }
                    }
                }
            };
            PolicyDefinitionContainer pdContainer = subscription.GetPolicyDefinitions();
            PolicyDefinition policyDefinition = (await pdContainer.CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            #endregion
            this.policyDefinition = policyDefinition;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreatePolicyAssignment()
        {
            await CreatePolicyDefinition();
            #region Snippet:Managing_Policies_CreatePolicyAssignment
            PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
            string policyAssignmentName = "myPolicyAssign";
            PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
            {
                DisplayName = $"AutoTest ${policyAssignmentName}",
                PolicyDefinitionId = policyDefinition.Id
            };
            PolicyAssignment policyAssignment = (await paContainer.CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreatePolicyAssignmentForAnyResource()
        {
            string vnName = "myVnet";
            GenericResourceData vnData = new GenericResourceData(Location.WestUS2)
            {
                Properties = new JsonObject()
                {
                    {"addressSpace", new JsonObject()
                        {
                            {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                        }
                    }
                }
            };
            ResourceIdentifier vnId = resourceGroup.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", vnName);
            GenericResource myVNet = await armClient.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId, vnData);
            #region Snippet:Managing_Policies_CreatePolicyAssignmentForAnyResource
            PolicyAssignmentContainer subscriptionPaContainer = subscription.GetPolicyAssignments();

            var managementGroup = (await armClient.GetManagementGroups().GetAsync("myMgmtGroup")).Value;
            PolicyAssignmentContainer managementGroupPaContainer = managementGroup.GetPolicyAssignments();
            // Suppose you have an existing VirtualNetwork myVNet resource
            PolicyAssignmentContainer vNetPaContainer = myVNet.GetPolicyAssignments();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetAllPolicyAssignments()
        {
            #region Snippet:Managing_Policies_GetAllPolicyAssignments
            string filter = "AtExactScope()";
            PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
            AsyncPageable<PolicyAssignment> policyAssignments = paContainer.GetAllAsync(filter: filter);
            await foreach (var pa in policyAssignments)
            {
                Console.WriteLine(pa.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeletePolicyAssignment()
        {
            #region Snippet:Managing_Policies_DeletePolicyAssignment
            PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
            string policyAssignmentName = "myPolicyAssign";
            PolicyAssignment policyAssignment = (await paContainer.GetAsync(policyAssignmentName)).Value;
            await policyAssignment.DeleteAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeletePolicyDefinition()
        {
            #region Snippet:Managing_Policies_DeletePolicyDefinition
            PolicyDefinitionContainer pdContainer = subscription.GetPolicyDefinitions();
            string policyDefinitionName = "myPolicyDef";
            PolicyDefinition policyDefinition = (await pdContainer.GetAsync(policyDefinitionName)).Value;
            await policyDefinition.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Managing_Policies_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #endregion
            this.armClient = armClient;
            this.subscription = subscription;

            #region Snippet:Managing_Policies_GetResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}

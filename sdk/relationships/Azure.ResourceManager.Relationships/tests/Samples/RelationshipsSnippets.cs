// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Relationships_Namespaces
using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Relationships;
using Azure.ResourceManager.Relationships.Models;
#endregion Snippet:Relationships_Namespaces

using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Samples
{
    public class RelationshipsSnippets
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDependencyOfRelationship()
        {
            #region Snippet:Relationships_CreateDependencyOf
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            // The source resource — the resource that depends on another
            string sourceResourceUri = "subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDb/databaseAccounts/my-db-account";
            DependencyOfRelationshipCollection collection = client.GetDependencyOfRelationships(new ResourceIdentifier(sourceResourceUri));

            // The target resource — the resource that the source depends on
            string targetResourceUri = "/subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Web/staticSites/my-static-site";
            DependencyOfRelationshipData data = new DependencyOfRelationshipData
            {
                Properties = new DependencyOfRelationshipProperties(new ResourceIdentifier(targetResourceUri))
            };

            ArmOperation<DependencyOfRelationshipResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myDependency", data);
            DependencyOfRelationshipResource relationship = lro.Value;
            Console.WriteLine($"Created relationship: {relationship.Data.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetDependencyOfRelationship()
        {
            #region Snippet:Relationships_GetDependencyOf
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            string sourceResourceUri = "subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDb/databaseAccounts/my-db-account";
            DependencyOfRelationshipCollection collection = client.GetDependencyOfRelationships(new ResourceIdentifier(sourceResourceUri));

            DependencyOfRelationshipResource relationship = await collection.GetAsync("myDependency");
            Console.WriteLine($"Relationship target: {relationship.Data.Properties.TargetId}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDependencyOfRelationship()
        {
            #region Snippet:Relationships_DeleteDependencyOf
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            string sourceResourceUri = "subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDb/databaseAccounts/my-db-account";
            DependencyOfRelationshipCollection collection = client.GetDependencyOfRelationships(new ResourceIdentifier(sourceResourceUri));

            DependencyOfRelationshipResource relationship = await collection.GetAsync("myDependency");
            await relationship.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine("Relationship deleted.");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateServiceGroupMemberRelationship()
        {
            #region Snippet:Relationships_CreateServiceGroupMember
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            // The member resource — the resource to add to a service group
            string memberResourceUri = "subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDb/databaseAccounts/my-db-account";
            ServiceGroupMemberRelationshipCollection collection = client.GetServiceGroupMemberRelationships(new ResourceIdentifier(memberResourceUri));

            // The service group to add the resource to
            string serviceGroupId = "/providers/Microsoft.Management/serviceGroups/myServiceGroup";
            ServiceGroupMemberRelationshipData data = new ServiceGroupMemberRelationshipData
            {
                Properties = new ServiceGroupMemberRelationshipProperties(new ResourceIdentifier(serviceGroupId))
            };

            ArmOperation<ServiceGroupMemberRelationshipResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myMembership", data);
            ServiceGroupMemberRelationshipResource membership = lro.Value;
            Console.WriteLine($"Added resource to service group: {membership.Data.Id}");
            #endregion
        }
    }
}

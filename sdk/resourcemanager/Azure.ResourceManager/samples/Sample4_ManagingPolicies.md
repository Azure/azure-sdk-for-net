# Example: Managing Policies

--------------------------------------

For this example, you need the following namespaces:

```C# Snippet:Managing_Policies_Namespaces
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Managing_Policies_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects.

```C# Snippet:Managing_Policies_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = (await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location))).Value;
```

## Create a Policy Definition

We'll create our policy definition in the subscription scope. To do this, we will create a `PolicyDefinitionData` object for the parameters that we want our policy definition to have, then we will get the policy definition container from subscription and we call `CreateOrUpdateAsync()`.

```C# Snippet:Managing_Policies_CreatePolicyDefinition
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
```

## Create a Policy Assignment

Now that we have a resource group and a policy definition, we can create a policy assignment that applies the policy to the resource group.

```C# Snippet:Managing_Policies_CreatePolicyAssignment
PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
string policyAssignmentName = "myPolicyAssign";
PolicyAssignmentData policyAssignmentData = new PolicyAssignmentData
{
    DisplayName = $"AutoTest ${policyAssignmentName}",
    PolicyDefinitionId = policyDefinition.Id
};
PolicyAssignment policyAssignment = (await paContainer.CreateOrUpdateAsync(policyAssignmentName, policyAssignmentData)).Value;
```

You can also create a policy assignment for a subscription, management group or any resource. The only change you need to make is to get the PolicyAssignmentContainer from the corresponding parent.

```C# Snippet:Managing_Policies_CreatePolicyAssignmentForAnyResource
PolicyAssignmentContainer subscriptionPaContainer = subscription.GetPolicyAssignments();

var managementGroup = (await armClient.GetManagementGroups().GetAsync("myMgmtGroup")).Value;
PolicyAssignmentContainer managementGroupPaContainer = managementGroup.GetPolicyAssignments();
// Suppose you have an existing VirtualNetwork myVNet resource
PolicyAssignmentContainer vNetPaContainer = myVNet.GetPolicyAssignments();
```

## List All Policy Assignments for the Resource Group

```C# Snippet:Managing_Policies_GetAllPolicyAssignments
string filter = "AtExactScope()";
PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
AsyncPageable<PolicyAssignment> policyAssignments = paContainer.GetAllAsync(filter: filter);
await foreach (var pa in policyAssignments)
{
    Console.WriteLine(pa.Data.Name);
}
```

See more about filter options: https://docs.microsoft.com/rest/api/policy/policy-assignments/list

## Get and Delete a Policy Assignment

```C# Snippet:Managing_Policies_DeletePolicyAssignment
PolicyAssignmentContainer paContainer = resourceGroup.GetPolicyAssignments();
string policyAssignmentName = "myPolicyAssign";
PolicyAssignment policyAssignment = (await paContainer.GetAsync(policyAssignmentName)).Value;
await policyAssignment.DeleteAsync();
```

## Get and Delete a Policy Definition

```C# Snippet:Managing_Policies_DeletePolicyDefinition
PolicyDefinitionContainer pdContainer = subscription.GetPolicyDefinitions();
string policyDefinitionName = "myPolicyDef";
PolicyDefinition policyDefinition = (await pdContainer.GetAsync(policyDefinitionName)).Value;
await policyDefinition.DeleteAsync();
```

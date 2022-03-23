# Example: Managing the Azure Front Door Rule

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_CdnWebApplicationFirewallPolicies_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with a specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the cdn web application firewall policies inside this resource group.

***Create a web application firewall policy***

```C# Snippet:Managing_CdnWebApplicationFirewallPolicies_CreateAWebApplicationFirewallPolicy
// Get the cdn web application firewall policy collection from the specific resource group and create a firewall policy
string policyName = "myPolicy";
var input = new CdnWebApplicationFirewallPolicyData("Global", new CdnSku
{
    Name = CdnSkuName.StandardMicrosoft
});
ArmOperation<CdnWebApplicationFirewallPolicyResource> lro = await resourceGroup.GetCdnWebApplicationFirewallPolicies().CreateOrUpdateAsync(WaitUntil.Completed, policyName, input);
CdnWebApplicationFirewallPolicyResource policy = lro.Value;
```

***List all web application firewall policies***

```C# Snippet:Managing_CdnWebApplicationFirewallPolicies_ListAllWebApplicationFirewallPolicies
// First we need to get the cdn web application firewall policy collection from the specific resource group
CdnWebApplicationFirewallPolicyCollection policyCollection = resourceGroup.GetCdnWebApplicationFirewallPolicies();
// With GetAllAsync(), we can get a list of the policy in the collection
AsyncPageable<CdnWebApplicationFirewallPolicyResource> response = policyCollection.GetAllAsync();
await foreach (CdnWebApplicationFirewallPolicyResource policy in response)
{
    Console.WriteLine(policy.Data.Name);
}
```

***Delete a web application firewall policy***

```C# Snippet:Managing_CdnWebApplicationFirewallPolicies_DeleteAWebApplicationFirewallPolicy
// First we need to get the cdn web application firewall policy collection from the specific resource group
CdnWebApplicationFirewallPolicyCollection policyCollection = resourceGroup.GetCdnWebApplicationFirewallPolicies();
// Now we can get the policy with GetAsync()
CdnWebApplicationFirewallPolicyResource policy = await policyCollection.GetAsync("myPolicy");
// With DeleteAsync(), we can delete the policy
await policy.DeleteAsync(WaitUntil.Completed);
```

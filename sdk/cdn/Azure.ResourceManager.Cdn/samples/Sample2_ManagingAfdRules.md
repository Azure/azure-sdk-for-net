# Example: Managing the Azure Front Door Rule

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_AfdRules_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
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

Now that we have the resource group created, we can manage the azure front door rules inside this resource group.

***Create an azure front door rule***

```C# Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
// Create a new azure front door profile
string AfdProfileName = "myAfdProfile";
var input1 = new ProfileData("Global", new CdnSku { Name = CdnSkuName.StandardAzureFrontDoor });
ArmOperation<ProfileResource> lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(WaitUntil.Completed, AfdProfileName, input1);
ProfileResource AfdProfileResource = lro1.Value;
// Get the rule set collection from the specific azure front door ProfileResource and create a rule set
string ruleSetName = "myAfdRuleSet";
ArmOperation<AfdRuleSetResource> lro2 = await AfdProfileResource.GetAfdRuleSets().CreateOrUpdateAsync(WaitUntil.Completed, ruleSetName);
AfdRuleSetResource ruleSet = lro2.Value;
// Get the rule collection from the specific rule set and create a rule
string ruleName = "myAfdRule";
AfdRuleData input3 = new AfdRuleData
{
    Order = 1
};
input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersTypeName.DeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = new TimeSpan(0, 0, 20)
}));
ArmOperation<AfdRuleResource> lro3 = await ruleSet.GetAfdRules().CreateOrUpdateAsync(WaitUntil.Completed, ruleName, input3);
AfdRuleResource rule = lro3.Value;
```

***List all  azure front door rules***

```C# Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
// First we need to get the azure front door rule collection from the specific rule set
ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// With GetAllAsync(), we can get a list of the rule in the collection
AsyncPageable<AfdRuleResource> response = ruleCollection.GetAllAsync();
await foreach (AfdRuleResource rule in response)
{
    Console.WriteLine(rule.Data.Name);
}
```

***Update an azure front door rule***

```C# Snippet:Managing_AfdRules_UpdateAnAzureFrontDoorRule
// First we need to get the azure front door rule collection from the specific rule set
ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// Now we can get the rule with GetAsync()
AfdRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
// With UpdateAsync(), we can update the rule
AfdRulePatch input = new AfdRulePatch
{
    Order = 2
};
input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersTypeName.DeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = new TimeSpan(0, 0, 30)
}));
ArmOperation<AfdRuleResource> lro = await rule.UpdateAsync(WaitUntil.Completed, input);
rule = lro.Value;
```

***Delete an azure front door rule***

```C# Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
// First we need to get the azure front door rule collection from the specific rule set
ProfileResource AfdProfileResource = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSetResource ruleSet = await AfdProfileResource.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// Now we can get the rule with GetAsync()
AfdRuleResource rule = await ruleCollection.GetAsync("myAfdRule");
// With DeleteAsync(), we can delete the rule
await rule.DeleteAsync(WaitUntil.Completed);
```

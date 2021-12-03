# Example: Managing the Azure Front Door Rule

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_AfdRules_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with a specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the azure front door rules inside this resource group.

***Create an azure front door rule***

```C# Snippet:Managing_AfdRules_CreateAnAzureFrontDoorRule
// Create a new azure front door profile
string AfdProfileName = "myAfdProfile";
var input1 = new ProfileData("Global", new Sku { Name = SkuName.StandardAzureFrontDoor });
ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(AfdProfileName, input1);
Profile AfdProfile = lro1.Value;
// Get the rule set collection from the specific azure front door profile and create a rule set
string ruleSetName = "myAfdRuleSet";
AfdRuleSetCreateOperation lro2 = await AfdProfile.GetAfdRuleSets().CreateOrUpdateAsync(ruleSetName);
AfdRuleSet ruleSet = lro2.Value;
// Get the rule collection from the specific rule set and create a rule
string ruleName = "myAfdRule";
AfdRuleData input3 = new AfdRuleData
{
    Order = 1
};
input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = "00:00:20"
}));
AfdRuleCreateOperation lro3 = await ruleSet.GetAfdRules().CreateOrUpdateAsync(ruleName, input3);
AfdRule rule = lro3.Value;
```

***List all  azure front door rules***

```C# Snippet:Managing_AfdRules_ListAllAzureFrontDoorRules
// First we need to get the azure front door rule collection from the specific rule set
Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// With GetAllAsync(), we can get a list of the rule in the collection
AsyncPageable<AfdRule> response = ruleCollection.GetAllAsync();
await foreach (AfdRule rule in response)
{
    Console.WriteLine(rule.Data.Name);
}
```

***Update an azure front door rule***

```C# Snippet:Managing_AfdRules_UpdateAnAzureFrontDoorRule
// First we need to get the azure front door rule collection from the specific rule set
Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// Now we can get the rule with GetAsync()
AfdRule rule = await ruleCollection.GetAsync("myAfdRule");
// With UpdateAsync(), we can update the rule
RuleUpdateOptions input = new RuleUpdateOptions
{
    Order = 2
};
input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = "00:00:30"
}));
AfdRuleUpdateOperation lro = await rule.UpdateAsync(input);
rule = lro.Value;
```

***Delete an azure front door rule***

```C# Snippet:Managing_AfdRules_DeleteAnAzureFrontDoorRule
// First we need to get the azure front door rule collection from the specific rule set
Profile AfdProfile = await resourceGroup.GetProfiles().GetAsync("myAfdProfile");
AfdRuleSet ruleSet = await AfdProfile.GetAfdRuleSets().GetAsync("myAfdRuleSet");
AfdRuleCollection ruleCollection = ruleSet.GetAfdRules();
// Now we can get the rule with GetAsync()
AfdRule rule = await ruleCollection.GetAsync("myAfdRule");
// With DeleteAsync(), we can delete the rule
await rule.DeleteAsync();
```

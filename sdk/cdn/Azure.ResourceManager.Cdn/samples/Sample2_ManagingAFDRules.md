# Example: Managing the Azure Front Door Rule

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_AFDRules_Namespaces
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
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with a specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the azure front door rules inside this resource group.

***Create an azure front door rule***

```C# Snippet:Managing_AFDRules_CreateAnAzureFrontDoorRule
// Create a new azure front door profile
string AFDProfileName = "myAFDProfile";
var input1 = new ProfileData("Global", new Sku { Name = SkuName.StandardAzureFrontDoor });
ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(AFDProfileName, input1);
Profile AFDProfile = lro1.Value;
// Get the rule set container from the specific azure front door profile and create a rule set
string ruleSetName = "myAFDRuleSet";
RuleSetCreateOperation lro2 = await AFDProfile.GetRuleSets().CreateOrUpdateAsync(ruleSetName);
RuleSet ruleSet = lro2.Value;
// Get the rule container from the specific rule set and create a rule
string ruleName = "myAFDRule";
RuleData input3 = new RuleData
{
    Order = 1
};
input3.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input3.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = "00:00:20"
}));
RuleCreateOperation lro3 = await ruleSet.GetRules().CreateOrUpdateAsync(ruleName, input3);
Rule rule = lro3.Value;
```

***List all  azure front door rules***

```C# Snippet:Managing_AFDRules_ListAllAzureFrontDoorRules
// First we need to get the rule container from the specific rule set
Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
RuleContainer ruleContainer = ruleSet.GetRules();
// With GetAllAsync(), we can get a list of the rule in the container
AsyncPageable<Rule> response = ruleContainer.GetAllAsync();
await foreach (Rule rule in response)
{
    Console.WriteLine(rule.Data.Name);
}
```

***Update an azure front door rule***

```C# Snippet:Managing_AFDRules_UpdateAnAzureFrontDoorRule
// First we need to get the rule container from the specific rule set
Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
RuleContainer ruleContainer = ruleSet.GetRules();
// Now we can get the rule with GetAsync()
Rule rule = await ruleContainer.GetAsync("myAFDRule");
// With UpdateAsync(), we can update the rule
RuleUpdateParameters input = new RuleUpdateParameters
{
    Order = 2
};
input.Conditions.Add(new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any)));
input.Actions.Add(new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
{
    CacheDuration = "00:00:30"
}));
RuleUpdateOperation lro = await rule.UpdateAsync(input);
rule = lro.Value;
```

***Delete an azure front door rule***

```C# Snippet:Managing_AFDRules_DeleteAnAzureFrontDoorRule
// First we need to get the rule container from the specific rule set
Profile AFDProfile = await resourceGroup.GetProfiles().GetAsync("myAFDProfile");
RuleSet ruleSet = await AFDProfile.GetRuleSets().GetAsync("myAFDRuleSet");
RuleContainer ruleContainer = ruleSet.GetRules();
// Now we can get the rule with GetAsync()
Rule rule = await ruleContainer.GetAsync("myAFDRule");
// With DeleteAsync(), we can delete the rule
await rule.DeleteAsync();
```

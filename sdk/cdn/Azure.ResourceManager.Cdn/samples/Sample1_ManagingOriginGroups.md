# Example: Managing the origin groups

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_OriginGroups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;
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

Now that we have the resource group created, we can manage the origin group inside this resource group.

***Create an origin group***

```C# Snippet:Managing_OriginGroups_CreateAnOriginGroup
// Create a new CDN profile
string profileName = "myProfile";
var input1 = new ProfileData(Location.WestUS, new Sku { Name = SkuName.StandardMicrosoft });
ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(profileName, input1);
Profile profile = lro1.Value;
// Get the endpoint container from the specific profile and create an endpoint
string endpointName = "myEndpoint";
var input2 = new EndpointData(Location.WestUS)
{
    IsHttpAllowed = true,
    IsHttpsAllowed = true,
    OptimizationType = OptimizationType.GeneralWebDelivery
};
DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("myOrigin")
{
    HostName = "testsa4dotnetsdk.blob.core.windows.net",
    Priority = 3,
    Weight = 100
};
input2.Origins.Add(deepCreatedOrigin);
EndpointCreateOperation lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, input2);
Endpoint endpoint = lro2.Value;
// Get the origin group container from the specific endpoint and create an origin group
string originGroupName = "myOriginGroup";
var input3 = new OriginGroupData();
input3.Origins.Add(new ResourceReference
{
    Id = $"{endpoint.Id}/origins/myOrigin"
});
OriginGroupCreateOperation lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, input3);
OriginGroup originGroup = lro3.Value;
```

***List all origin groups***

```C# Snippet:Managing_OriginGroups_ListAllOriginGroups
// First we need to get the origin group container from the specific endpoint
Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
OriginGroupContainer originGroupContainer = endpoint.GetOriginGroups();
// With GetAllAsync(), we can get a list of the origin group in the container
AsyncPageable<OriginGroup> response = originGroupContainer.GetAllAsync();
await foreach (OriginGroup originGroup in response)
{
    Console.WriteLine(originGroup.Data.Name);
}
```

***Update an origin group***

```C# Snippet:Managing_OriginGroups_UpdateAnOriginGroup
// First we need to get the origin group container from the specific endpoint
Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
OriginGroupContainer originGroupContainer = endpoint.GetOriginGroups();
// Now we can get the origin group with GetAsync()
OriginGroup originGroup = await originGroupContainer.GetAsync("myOriginGroup");
// With UpdateAsync(), we can update the origin group
OriginGroupUpdateParameters input = new OriginGroupUpdateParameters()
{
    HealthProbeSettings = new HealthProbeParameters
    {
        ProbePath = "/healthz",
        ProbeRequestType = HealthProbeRequestType.Head,
        ProbeProtocol = ProbeProtocol.Https,
        ProbeIntervalInSeconds = 60
    }
};
OriginGroupUpdateOperation lro = await originGroup.UpdateAsync(input);
originGroup = lro.Value;
```

***Delete an origin group***

```C# Snippet:Managing_OriginGroups_DeleteAnOriginGroup
// First we need to get the origin group container from the specific endpoint
Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
OriginGroupContainer originGroupContainer = endpoint.GetOriginGroups();
// Now we can get the origin group with GetAsync()
OriginGroup originGroup = await originGroupContainer.GetAsync("myOriginGroup");
// With DeleteAsync(), we can delete the origin group
await originGroup.DeleteAsync();
```


## Next steps
Take a look at the [Managing Azure Front Door Rules](https://github.com/Yao725/azure-sdk-for-net/tree/feature/mgmt-track2-cdn/sdk/cdn/Azure.ResourceManager.Cdn/samples/Sample2_ManagingAFDRules.md) samples.

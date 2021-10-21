# Example: Managing the webpubsub

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_WebPubSub_Namespaces
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
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
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the WebPubSub inside this resource group.

***Create a WebPubSub***

```C# Snippet:Managing_WebPubSub_CreateWebPubSub
// First we need to get the WebPubSub container from the resource group
WebPubSubResourceContainer webPubSubResourceContainer = resourceGroup.GetWebPubSubResources();
// Use the same location as the resource group
string webPubSubName = "myWebPubSubName";
IList<LiveTraceCategory> categories = new List<LiveTraceCategory>();
categories.Add(new LiveTraceCategory("category-01", "true"));
ACLAction aCLAction = new ACLAction("Deny");
IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>();
deny.Add(new WebPubSubRequestType("RESTAPI"));
NetworkACL publicNetwork = new NetworkACL(allow, deny);
IList<PrivateEndpointACL> privateEndpoints = new List<PrivateEndpointACL>();
List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
{
    new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
};
WebPubSubResourceData data = new WebPubSubResourceData(Location.WestUS2)
{
    // You can specify many options for the WebPubSub in here
    Sku = new ResourceSku("Standard_S1"),
    LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
    NetworkACLs = new WebPubSubNetworkACLs(aCLAction, publicNetwork, privateEndpoints),
    ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory),
};
WebPubSubCreateOrUpdateOperation webPubSubLro = await webPubSubResourceContainer.CreateOrUpdateAsync(webPubSubName, data);
WebPubSubResource webPubSub = webPubSubLro.Value;
```

***Get a WebPubSub***

```C# Snippet:Managing_WebPubSub_GetWebPubSub
// First we need to get the WebPubSub container from the resource group
WebPubSubResourceContainer webPubSubResourceContainer = resourceGroup.GetWebPubSubResources();
// Now we can get the WebPubSub with GetAsync()
WebPubSubResource webPubSub = await webPubSubResourceContainer.GetAsync("myWebPubSubName");
Console.WriteLine(webPubSub.Data);
```

***List all WebPubSub***

```C# Snippet:Managing_WebPubSub_ListAllWebPubSub

// First we need to get the WebPubSub container from the resource group
WebPubSubResourceContainer webPubSubResourceContainer = resourceGroup.GetWebPubSubResources();
AsyncPageable<WebPubSubResource> response = webPubSubResourceContainer.GetAllAsync();
await foreach (WebPubSubResource WebPubSubResource in response)
{
    Console.WriteLine(WebPubSubResource.Data.Name);
}
```

***Delete an WebPubSub***

```C# Snippet:Managing_WebPubSub_DeleteWebPubSub
// First we need to get the WebPubSub container from the resource group
WebPubSubResourceContainer webPubSubResourceContainer = resourceGroup.GetWebPubSubResources();
// Now we can get the WebPubSub with GetAsync()
WebPubSubResource webPubSub = await webPubSubResourceContainer.GetAsync("myWebPubSubName");
// With DeleteAsync(), we can delete the WebPubSub
await webPubSub.DeleteAsync();
```

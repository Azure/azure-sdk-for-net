# Example: Managing Resource Links

--------------------------------------

For this example, you need the following namespaces:

```C# Snippet:Managing_Policies_Namespaces
using System;
using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

## Create a Resource Link

```C# Snippet:Readme_CreateResourceLink
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();

// Suppose we have 2 existing VirtualNetwork vn1 and vn2
ResourceIdentifier vnId1 = vn1.Id;
ResourceIdentifier vnId2 = vn2.Id;
string resourceLinkName = "myLink";
ResourceIdentifier resourceLinkId = vnId1.AppendProviderResource("Microsoft.Resources", "links", resourceLinkName);
ResourceLinkProperties properties = new ResourceLinkProperties(vnId2);
ResourceLink resourceLink = (await armClient.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId, properties)).Value;
```

## List Resource Links

```C# Snippet:Readme_ListResourceLinks
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();
ResourceIdentifier vnId1 = vn1.Id;
AsyncPageable<ResourceLink> resourceLinks = resourceLinkContainer.GetAllAsync(vnId1);
await foreach (var link in resourceLinks)
{
    Console.WriteLine(link.Data.Name);
}
```

## Get and Delete a ResourceLink

```C# Snippet:Readme_DeleteResourceLink
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();
string resourceLinkName = "myLink";
ResourceIdentifier vnId1 = vn1.Id;
ResourceIdentifier resourceLinkId = vnId1.AppendProviderResource("Microsoft.Resources", "links", resourceLinkName);
ResourceLink resourceLink = (await resourceLinkContainer.GetAsync(resourceLinkId)).Value;
await resourceLink.DeleteAsync();
```

# Example: Managing the deployment extendeds

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_DeploymentExtendeds_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
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

Now that we have the resource group created, we can manage the deployment extendeds inside this resource group.

***Create a deployment extendeds***

```C# Snippet:Managing_DeploymentExtendeds_CreateADeploymentExtended
// First we need to get the deployment extended container from the resource group
DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
// Use the same location as the resource group
string deploymentExtendedName = "myDeployment";
var input = new Deployment(new DeploymentProperties(DeploymentMode.Incremental)
{
    TemplateLink = new TemplateLink()
    {
        Uri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json"
    },
    Parameters = new JsonObject()
    {
        {"storageAccountType", new JsonObject()
            {
                {"value", "Standard_GRS" }
            }
        }
    }
});
DeploymentCreateOrUpdateAtScopeOperation lro = await deploymentExtendedContainer.CreateOrUpdateAsync(deploymentExtendedName, input);
DeploymentExtended deploymentExtended = lro.Value;
```

***List all deployment extendeds***

```C# Snippet:Managing_DeploymentExtendeds_ListAllDeploymentExtendeds
// First we need to get the deployment extended container from the resource group
DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
// With GetAllAsync(), we can get a list of the deployment extendeds in the container
AsyncPageable<DeploymentExtended> response = deploymentExtendedContainer.GetAllAsync();
await foreach (DeploymentExtended deploymentExtended in response)
{
    Console.WriteLine(deploymentExtended.Data.Name);
}
```

***Delete a deployment extendeds***

```C# Snippet:Managing_DeploymentExtendeds_DeleteADeploymentExtended
// First we need to get the deployment extended container from the resource group
DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
// Now we can get the deployment extended with GetAsync()
DeploymentExtended deploymentExtended = await deploymentExtendedContainer.GetAsync("myDeployment");
// With DeleteAsync(), we can delete the deployment extended
await deploymentExtended.DeleteAsync();
```

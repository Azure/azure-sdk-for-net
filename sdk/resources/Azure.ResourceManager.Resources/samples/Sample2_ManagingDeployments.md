# Example: Managing the deployments

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Deployments_Namespaces
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

Now that we have the resource group created, we can manage the deployments inside this resource group.

***Create a deployment***

```C# Snippet:Managing_Deployments_CreateADeployment
// First we need to get the deployment container from the resource group
DeploymentContainer deploymentContainer = resourceGroup.GetDeployments();
// Use the same location as the resource group
string deploymentName = "myDeployment";
var input = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
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
DeploymentCreateOrUpdateAtScopeOperation lro = await deploymentContainer.CreateOrUpdateAsync(deploymentName, input);
Deployment deployment = lro.Value;
```

***List all deployments***

```C# Snippet:Managing_Deployments_ListAllDeployments
// First we need to get the deployment container from the resource group
DeploymentContainer deploymentContainer = resourceGroup.GetDeployments();
// With GetAllAsync(), we can get a list of the deployments in the container
AsyncPageable<Deployment> response = deploymentContainer.GetAllAsync();
await foreach (Deployment deployment in response)
{
    Console.WriteLine(deployment.Data.Name);
}
```

***Delete a deployment***

```C# Snippet:Managing_Deployments_DeleteADeployment
// First we need to get the deployment container from the resource group
DeploymentContainer deploymentContainer = resourceGroup.GetDeployments();
// Now we can get the deployment with GetAsync()
Deployment deployment = await deploymentContainer.GetAsync("myDeployment");
// With DeleteAsync(), we can delete the deployment
await deployment.DeleteAsync();
```


## Learn more
Take a look at the [ARM template documentation](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/).
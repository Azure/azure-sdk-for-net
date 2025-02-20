# Example: Managing the deployments

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_Deployments_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Text.Json;
using System.IO;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using System.Security.Policy;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Now that we have the resource group created, we can manage the deployments inside this resource group. For creating a deployment, we can use dictionary, string, or JsonElement.

***Create a deployment using dictionary***

```C# Snippet:Managing_Deployments_CreateADeployment
// First we need to get the deployment collection from the resource group
ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
// Use the same location as the resource group
string deploymentName = "myDeployment";
var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
{
    TemplateLink = new ArmDeploymentTemplateLink()
    {
        Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
    },
    Parameters = BinaryData.FromObjectAsJson(new JsonObject()
    {
        {"storageAccountType", new JsonObject()
            {
                {"value", "Standard_GRS" }
            }
        }
    })
});
ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
ArmDeploymentResource deployment = lro.Value;
```

***Create a deployment using string***

```C# Snippet:Managing_Deployments_CreateADeploymentUsingString
// First we need to get the deployment collection from the resource group
ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
// Use the same location as the resource group
string deploymentName = "myDeployment";
// Passing string to template and parameters
var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
{
    Template = BinaryData.FromString(File.ReadAllText("storage-template.json")),
    Parameters = BinaryData.FromString(File.ReadAllText("storage-parameters.json"))
});
ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
ArmDeploymentResource deployment = lro.Value;
```

***Create a deployment using JsonElement***

```C# Snippet:Managing_Deployments_CreateADeploymentUsingJsonElement
// First we need to get the deployment collection from the resource group
ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
// Use the same location as the resource group
string deploymentName = "myDeployment";
// Create a parameter object
var parametersObject = new { storageAccountType = new { value = "Standard_GRS" } };
//convert this object to JsonElement
var parametersString = JsonSerializer.Serialize(parametersObject);
using var jsonDocument = JsonDocument.Parse(parametersString);
var parameters = jsonDocument.RootElement;
var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
{
    TemplateLink = new ArmDeploymentTemplateLink()
    {
        Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
    },
    Parameters = BinaryData.FromString(parameters.GetRawText())
});
ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
ArmDeploymentResource deployment = lro.Value;
```

***List all deployments***

```C# Snippet:Managing_Deployments_ListAllDeployments
// First we need to get the deployment collection from the resource group
ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
// With GetAllAsync(), we can get a list of the deployments in the collection
AsyncPageable<ArmDeploymentResource> response = ArmDeploymentCollection.GetAllAsync();
await foreach (ArmDeploymentResource deployment in response)
{
    Console.WriteLine(deployment.Data.Name);
}
```

***Delete a deployment***

```C# Snippet:Managing_Deployments_DeleteADeployment
// First we need to get the deployment collection from the resource group
ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
// Now we can get the deployment with GetAsync()
ArmDeploymentResource deployment = await ArmDeploymentCollection.GetAsync("myDeployment");
// With DeleteAsync(), we can delete the deployment
await deployment.DeleteAsync(WaitUntil.Completed);
```


## Learn more
Take a look at the [ARM template documentation](https://learn.microsoft.com/azure/azure-resource-manager/templates/).

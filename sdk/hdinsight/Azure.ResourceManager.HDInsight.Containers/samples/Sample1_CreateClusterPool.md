# Example: Create Cluster Pool

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Create_ClusterPool_Namespaces
using Azure.ResourceManager;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.Core;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.HDInsight.Containers.Models;
```


When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();
```


***Create Cluster Pool***

```C#
var credential = new DefaultAzureCredential();
var armClient = new ArmClient(credential);

// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group name}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
ClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetClusterPools();

// create the cluster pool
string clusterPoolName = "{your cluster pool name}";
string clusterPoolVmSize = "Standard_E4s_v3"; // the vmsize

// get the available cluster pool version
var availableClusterPoolVersion = subscription.GetAvailableClusterPoolVersionsByLocation(location).FirstOrDefault();

// initialize the ClusterPoolData instance
ClusterPoolData clusterPoolData = new ClusterPoolData(location)
{
    ComputeProfile = new ClusterPoolResourcePropertiesComputeProfile(clusterPoolVmSize),
    ClusterPoolVersion = availableClusterPoolVersion?.ClusterPoolVersionValue,
};

var clusterPoolResult = clusterPoolCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterPoolName, clusterPoolData);
```

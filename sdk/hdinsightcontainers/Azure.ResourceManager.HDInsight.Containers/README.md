# Microsoft Azure HDInsight Containers management client library for .NET

Microsoft Azure HDInsgiht Containers(HDInsight On AKS) simplifies deploying hdinsight cluster based the AKS.

This library supports managing Microsoft Azure HDInsgiht Containers resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package (Since now we are in private preview status, the bellow method doesn't work please send email to Askhilo@microsoft.com to install the nuget from our private nuget feed)

Install the Azure HDInsight On AKS management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.HDInsight.Containers --prerelease
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

Namespaces for this example:
```C# Snippet:Readme_Namespaces
using System;
using System.Linq;
using Azure.ResourceManager;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.Core;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.HDInsight.Containers.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();
```

### Create Cluster Pool

```C# Snippet:Readme_CreateClusterPool
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group name}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster pool
string clusterPoolName = "{your cluster pool name}";
string clusterPoolVmSize = "Standard_E4s_v3"; // the vmsize

// get the available cluster pool version
var availableClusterPoolVersion = subscription.GetAvailableClusterPoolVersionsByLocation(location).FirstOrDefault();

// initialize the ClusterPoolData instance
HDInsightClusterPoolData clusterPoolData = new HDInsightClusterPoolData(location)
{
    Properties = new HDInsightClusterPoolProperties(new ClusterPoolComputeProfile(clusterPoolVmSize))
    {
        ClusterPoolVersion = availableClusterPoolVersion?.Properties.ClusterPoolVersion
    }
};

var clusterPoolResult = clusterPoolCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterPoolName, clusterPoolData);
```

### Create Simple Trino Cluster

```C# Snippet:Readme_CreateSimpleTrinoCluster
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Trino"; // your cluster type

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vms ize
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Simple Spark Cluster

```C# Snippet:Readme_CreateSimpleSparkCluster
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Spark"; // your cluster type here is Spark

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vms ize
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

// set saprk profile
clusterProfile.SparkProfile = new SparkProfile()
{
    DefaultStorageUriString = "abfs://spark@hilostorage.dfs.core.windows.net",
};

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Simple Flink Cluster

```C# Snippet:Readme_CreateSimpleFlinkCluster
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Flink"; // cluster type

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).LastOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vm size
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

// set flink profile
string storageUri = "abfs://{your storage account container name}@{yoru storage account}.dfs.core.windows.net"; // your adlsgen2 storage uri
FlinkStorageProfile flinkStorageProfile = new FlinkStorageProfile(storageUri);

ComputeResourceRequirement jobManager = new ComputeResourceRequirement((float)1.0, 2048);
ComputeResourceRequirement taskManager = new ComputeResourceRequirement((float)1.0, 2048);

clusterData.Properties.ClusterProfile.FlinkProfile = new FlinkProfile(flinkStorageProfile, jobManager, taskManager);

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Trino Cluster With Hms

```C# Snippet:Readme_CreateTrinoClusterHms
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Trino"; // your cluster type

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vms ize
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

// set secret profile
string kvResourceId = "{your key vault resource id}";
string secretName = "{your secret reference name}";
string keyVaultObjectName = "{your key vault secret name}";

var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
clusterData.Properties.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
clusterData.Properties.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

// set trino profile
string metastoreDbConnectionUriString = "jdbc:sqlserver://{your sql server name}.database.windows.net;database={your database name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
string metastoreDbUserName = "{your db user name}";
string metastoreDbPasswordSecret = secretName;
string metastoreWarehouseDir = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net/{sub folder path}";

// set trino profile
clusterProfile.TrinoProfile = new TrinoProfile();

// initialize the ClusterServiceConfigsProfile for HMS
ClusterServiceConfigsProfile clusterServiceConfigsProfile = new ClusterServiceConfigsProfile(serviceName: "trino", new ClusterServiceConfig[] {
    new ClusterServiceConfig(component: "common", new ClusterConfigFile[] { new ClusterConfigFile("config.properties")
        {
            Values = {
                    ["hive.metastore.hdi.metastoreDbConnectionAuthenticationMode"] = "SqlAuth",
                    ["hive.metastore.hdi.metastoreDbConnectionPasswordSecret"] = metastoreDbPasswordSecret,
                    ["hive.metastore.hdi.metastoreDbConnectionURL"] = metastoreDbConnectionUriString,
                    ["hive.metastore.hdi.metastoreDbConnectionUserName"] = metastoreDbUserName,
                    ["hive.metastore.hdi.metastoreWarehouseDir"] = metastoreWarehouseDir
            }
        }
    })
});
clusterProfile.ServiceConfigsProfiles.Add(clusterServiceConfigsProfile);

ClusterSecretsProfile clusterSecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
clusterSecretsProfile.Secrets.Add(new ClusterSecretReference(secretName, KeyVaultObjectType.Secret, keyVaultObjectName));
clusterProfile.SecretsProfile = clusterSecretsProfile;

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Spark Cluster With Hms

```C# Snippet:Readme_CreateSparkClusterHms
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Spark"; // your cluster type here is Spark

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vms ize
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

// set secret profile
string kvResourceId = "{your key vault resource id}";
string secretName = "{your secret reference name}";
string keyVaultObjectName = "{your key vault secret name}";

var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
clusterData.Properties.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
clusterData.Properties.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

// set spark profile
string defaultStorageUriString = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net/";
string dbServerHost = "{your sql server name}.database.windows.net";
string dbUserName = "{your db user name}";
string dbName = "{yoru db name}";
string dbPasswordSecretName = secretName;

SparkMetastoreSpec sparkMetastoreSpec = new SparkMetastoreSpec(dbServerHost: dbServerHost, dbName: dbName);
sparkMetastoreSpec.DBUserName = dbUserName;
sparkMetastoreSpec.DBPasswordSecretName = dbPasswordSecretName;
sparkMetastoreSpec.KeyVaultId = kvResourceId;

SparkProfile sparkProfile = new SparkProfile();
sparkProfile.DefaultStorageUriString = defaultStorageUriString;
sparkProfile.MetastoreSpec = sparkMetastoreSpec;

clusterData.Properties.ClusterProfile.SparkProfile = sparkProfile;

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Flink Cluster With Hms

```C# Snippet:Readme_CreateFlinkClusterHms
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Flink"; // cluster type

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).LastOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vm size
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

// set secret profile
string kvResourceId = "{your key vault resource id}";
string secretName = "{your secret reference name}";
string keyVaultObjectName = "{your key vault secret name}";

var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
clusterData.Properties.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
clusterData.Properties.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

// set flink profile

string storageUri = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net";
FlinkStorageProfile flinkStorageProfile = new FlinkStorageProfile(storageUri);

ComputeResourceRequirement jobManager = new ComputeResourceRequirement((float)1.0, 2048);
ComputeResourceRequirement taskManager = new ComputeResourceRequirement((float)1.0, 2048);

// set flink catalog
string metastoreDbConnectionUriString = "jdbc:sqlserver://{your sql server name}.database.windows.net;database={your database name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
string metastoreDbUserName = "{your db user name}";
string metastoreDbPasswordSecret = secretName;

FlinkHiveCatalogOption flinkHiveCatalogOption = new FlinkHiveCatalogOption(metastoreDBConnectionUriString: metastoreDbConnectionUriString);
flinkHiveCatalogOption.MetastoreDBConnectionUserName = metastoreDbUserName;
flinkHiveCatalogOption.MetastoreDBConnectionPasswordSecret = metastoreDbPasswordSecret;

clusterData.Properties.ClusterProfile.FlinkProfile = new FlinkProfile(storage: flinkStorageProfile, jobManager: jobManager, taskManager: taskManager);
clusterData.Properties.ClusterProfile.FlinkProfile.CatalogOptionsHive = flinkHiveCatalogOption;

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();
var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### Create Trino Cluster With Availability Zone

```C# Snippet:Readme_CreateTrinoClusterAvailabilityZone
// define the prerequisites information: subscription, resource group and location where you want to create the resource
string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
string resourceGroupName = "{your resource group}"; // your resource group name
AzureLocation location = AzureLocation.EastUS; // your location

SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
HDInsightClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetHDInsightClusterPools();

// create the cluster
string clusterPoolName = "{your cluster pool name}";
string clusterName = "{your cluster name}";
string clusterType = "Trino"; // your cluster type

// get the available cluster version
var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.Properties.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

// set the identity profile
string msiResourceId = "{your user msi resource id}";
string msiClientId = "{your user msi client id}";
string msiObjectId = "{your user msi object id}";
var identityProfile = new HDInsightIdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);

// set the authorization profile
var userId = "{your aad user id}";
var authorizationProfile = new AuthorizationProfile();
authorizationProfile.UserIds.Add(userId);

// set the cluster node profile
string vmSize = "Standard_D8s_v3"; // your vms ize
int workerCount = 5;
ClusterComputeProfile nodeProfile = new ClusterComputeProfile(new List<ClusterComputeNodeProfile> { new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount) });
// set availability zones
nodeProfile.AvailabilityZones.Add("1");
nodeProfile.AvailabilityZones.Add("2");

ClusterProfile clusterProfile = new ClusterProfile(availableClusterVersion.Properties.ClusterVersion, availableClusterVersion.Properties.OssVersion, authorizationProfile)
{
    IdentityList = new List<HDInsightManagedIdentitySpec> { new HDInsightManagedIdentitySpec("cluster",new ResourceIdentifier(msiResourceId), msiClientId, msiObjectId) }
};

var clusterData = new HDInsightClusterData(location)
{
    Properties = new HDInsightClusterProperties(clusterType, nodeProfile, clusterProfile)
};

var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

### More examples

More Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

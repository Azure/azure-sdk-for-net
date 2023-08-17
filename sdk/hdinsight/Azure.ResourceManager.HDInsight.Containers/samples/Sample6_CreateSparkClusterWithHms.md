# Example: Create Spark Cluster With Hms

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Create_Cluster_Namespaces
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


***Create Spark Cluster With Hms***

```C#
            // Authenticate the client
            var credential = new AzurePowerShellCredential(); //new DefaultAzureCredential();
            var armClient = new ArmClient(credential);

            // define the prerequisites information: subscription, resource group and location where you want to create the resource
            string subscriptionResourceId = "/subscriptions/{subscription id}"; // your subscription resource id like /subscriptions/{subscription id}
            string resourceGroupName = "{your resource group}"; // your resource group name
            AzureLocation location = AzureLocation.EastUS; // your location

            SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier(resourceId: subscriptionResourceId));
            ResourceGroupResource resourceGroupResource = subscription.GetResourceGroup(resourceGroupName);
            ClusterPoolCollection clusterPoolCollection = resourceGroupResource.GetClusterPools();

            // create the cluster
            string clusterPoolName = "{your cluster pool name}";
            string clusterName = "{your cluster name}";
            string clusterType = "Spark"; // your cluster type here is Spark

            // get the available cluster version
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            // set the identity profile
            string msiResourceId = "{your user msi resource id}";
            string msiClientId = "{your user msi client id}";
            string msiObjectId = "{your user msi object id}";
            var identityProfile = new IdentityProfile(msiResourceId: new ResourceIdentifier(msiResourceId), msiClientId: msiClientId, msiObjectId: msiObjectId);


            // set the authorization profile
            var userId = "{your aad user id}";
            var authorizationProfile = new AuthorizationProfile();
            authorizationProfile.UserIds.Add(userId);

            // set the cluster node profile
            string vmSize = "Standard_D8s_v3"; // your vms ize
            int workerCount = 5;
            NodeProfile nodeProfile = new NodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new ClusterData(location)
            {
                ClusterType = clusterType,
                ComputeNodes = new List<NodeProfile> { nodeProfile },
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersionValue, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile),
            };

            // set secret profile
            string kvResourceId = "{your key vault resource id}";
            string secretName = "{your secret reference name}";
            string keyVaultObjectName = "{your key vault secret name}";

            var secretReference = new SecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
            clusterData.ClusterProfile.SecretsProfile = new SecretsProfile(new ResourceIdentifier(kvResourceId));
            clusterData.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

            // set spark profile
            string defaultStorageUrl = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net/";
            string dbServerHost = "{your sql server name}.database.windows.net";
            string dbUserName = "{your db user name}";
            string dbName = "{yoru db name}";
            string dbPasswordSecretName = secretName;

            SparkProfile sparkProfile = new SparkProfile();
            sparkProfile.DefaultStorageUri = defaultStorageUrl;
            sparkProfile.MetastoreSpec = new SparkMetastoreSpec(dbServerHost: dbServerHost, dbName:dbName, dbUserName: dbUserName, dbPasswordSecretName: dbPasswordSecretName, keyVaultId: kvResourceId);

            clusterData.ClusterProfile.SparkProfile = sparkProfile;

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
```

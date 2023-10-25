// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Readme_Namespaces
using System;
using System.Linq;
using Azure.ResourceManager;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.Core;
using Azure.ResourceManager.HDInsight.Containers;
using Azure.ResourceManager.HDInsight.Containers.Models;
#endregion Snippet:Readme_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests.Samples
{
    public class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
            #region Snippet:Readme_AuthClient
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetDefaultSubscription();
            #endregion Snippet:Readme_AuthClient
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateClusterPool()
        {
            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateClusterPool
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
                ComputeProfile = new ClusterPoolComputeProfile(clusterPoolVmSize),
                ClusterPoolVersion = availableClusterPoolVersion?.ClusterPoolVersionValue,
            };

            var clusterPoolResult = clusterPoolCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterPoolName, clusterPoolData);
            #endregion Snippet:Readme_CreateClusterPool
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateSimpleTrinoCluster()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateSimpleTrinoCluster
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile)
                {
                    TrinoProfile = new TrinoProfile(),  // here is related with cluster type
                },
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateSimpleTrinoCluster
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateSimpleSparkCluster()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateSimpleSparkCluster
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile)
                {
                    SparkProfile = new SparkProfile(),  // here is related with cluster type
                },
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateSimpleSparkCluster
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateSimpleFlinkCluster()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateSimpleFlinkCluster
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).LastOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);
            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile),
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            // set flink profile
            string storageUri = "abfs://{your storage account container name}@{yoru storage account}.dfs.core.windows.net"; // your adlsgen2 storage uri
            FlinkStorageProfile flinkStorageProfile = new FlinkStorageProfile(storageUri);

            ComputeResourceRequirement jobManager = new ComputeResourceRequirement((float)1.0, 2048);
            ComputeResourceRequirement taskManager = new ComputeResourceRequirement((float)1.0, 2048);

            clusterData.ClusterProfile.FlinkProfile = new FlinkProfile(storage: flinkStorageProfile, jobManager: jobManager, taskManager: taskManager);

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateSimpleFlinkCluster
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateTrinoClusterHms()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateTrinoClusterHms
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile),
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            // set secret profile
            string kvResourceId = "{your key vault resource id}";
            string secretName = "{your secret reference name}";
            string keyVaultObjectName = "{your key vault secret name}";

            var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
            clusterData.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
            clusterData.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

            // set trino profile
            string catalogName = "{your catalog name}";
            string metastoreDbConnectionUriString = "jdbc:sqlserver://{your sql server name}.database.windows.net;database={your database name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
            string metastoreDbUserName = "{your db user name}";
            string metastoreDbPasswordSecret = secretName;
            string metastoreWarehouseDir = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net/{sub folder path}";

            TrinoProfile trinoProfile = new TrinoProfile();
            trinoProfile.CatalogOptionsHive.Add(
                new HiveCatalogOption(
                    catalogName: catalogName,
                    metastoreDBConnectionPasswordSecret: metastoreDbPasswordSecret,
                    metastoreDBConnectionUriString: metastoreDbConnectionUriString,
                    metastoreDBConnectionUserName: metastoreDbUserName,
                    metastoreWarehouseDir: metastoreWarehouseDir)
            );

            clusterData.ClusterProfile.TrinoProfile = trinoProfile;

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateTrinoClusterHms
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateSparkClusterHms()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateSparkClusterHms
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile),
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            // set secret profile
            string kvResourceId = "{your key vault resource id}";
            string secretName = "{your secret reference name}";
            string keyVaultObjectName = "{your key vault secret name}";

            var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
            clusterData.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
            clusterData.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

            // set spark profile
            string defaultStorageUriString = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net/";
            string dbServerHost = "{your sql server name}.database.windows.net";
            string dbUserName = "{your db user name}";
            string dbName = "{yoru db name}";
            string dbPasswordSecretName = secretName;

            SparkProfile sparkProfile = new SparkProfile();
            sparkProfile.DefaultStorageUriString = defaultStorageUriString;
            sparkProfile.MetastoreSpec = new SparkMetastoreSpec(dbServerHost: dbServerHost, dbName: dbName, dbUserName: dbUserName, dbPasswordSecretName: dbPasswordSecretName, keyVaultId: kvResourceId);

            clusterData.ClusterProfile.SparkProfile = sparkProfile;

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();

            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateSparkClusterHms
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateFlinkClusterHms()
        {
            // Authenticate the client
            var credential = new AzurePowerShellCredential();
            var armClient = new ArmClient(credential);
            #region Snippet:Readme_CreateFlinkClusterHms
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
            var availableClusterVersion = subscription.GetAvailableClusterVersionsByLocation(location).Where(version => version.ClusterType.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).LastOrDefault();

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
            ClusterComputeNodeProfile nodeProfile = new ClusterComputeNodeProfile(nodeProfileType: "worker", vmSize: vmSize, count: workerCount);

            // initialize the ClusterData instance
            var clusterData = new HDInsightClusterData(location)
            {
                ClusterType = clusterType,
                ClusterProfile = new ClusterProfile(clusterVersion: availableClusterVersion?.ClusterVersion, ossVersion: availableClusterVersion?.OssVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile),
            };
            clusterData.ComputeNodes.Add(nodeProfile);

            // set secret profile
            string kvResourceId = "{your key vault resource id}";
            string secretName = "{your secret reference name}";
            string keyVaultObjectName = "{your key vault secret name}";

            var secretReference = new ClusterSecretReference(referenceName: secretName, KeyVaultObjectType.Secret, keyVaultObjectName: keyVaultObjectName);
            clusterData.ClusterProfile.SecretsProfile = new ClusterSecretsProfile(new ResourceIdentifier(kvResourceId));
            clusterData.ClusterProfile.SecretsProfile.Secrets.Add(secretReference);

            // set flink profile

            string storageUri = "abfs://{your adlsgen2 storage account container}@{your adlsgen2 storage account}.dfs.core.windows.net";
            FlinkStorageProfile flinkStorageProfile = new FlinkStorageProfile(storageUri);

            ComputeResourceRequirement jobManager = new ComputeResourceRequirement((float)1.0, 2048);
            ComputeResourceRequirement taskManager = new ComputeResourceRequirement((float)1.0, 2048);

            // set flink catalog
            string metastoreDbConnectionUriString = "jdbc:sqlserver://{your sql server name}.database.windows.net;database={your database name};encrypt=true;trustServerCertificate=true;loginTimeout=30;";
            string metastoreDbUserName = "{your db user name}";
            string metastoreDbPasswordSecret = secretName;

            FlinkHiveCatalogOption flinkHiveCatalogOption = new FlinkHiveCatalogOption(metastoreDBConnectionPasswordSecret: metastoreDbPasswordSecret, metastoreDBConnectionUriString: metastoreDbConnectionUriString, metastoreDBConnectionUserName: metastoreDbUserName);
            clusterData.ClusterProfile.FlinkProfile = new FlinkProfile(storage: flinkStorageProfile, jobManager: jobManager, taskManager: taskManager);
            clusterData.ClusterProfile.FlinkProfile.CatalogOptionsHive = flinkHiveCatalogOption;

            var clusterCollection = clusterPoolCollection.Get(clusterPoolName).Value.GetHDInsightClusters();
            var clusterResult = clusterCollection.CreateOrUpdate(Azure.WaitUntil.Completed, clusterName, clusterData);
            #endregion Snippet:Readme_CreateFlinkClusterHms
        }
    }
}

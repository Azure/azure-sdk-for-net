## How to use Hilo private .NET SDK

### How to install the private preview sdk Azure.ResourceManager.HDInsight.AKS
1. connect our private nuget feed in your project

Add a nuget.config file to your project, in the same folder as your .csproj or .sln file
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="HDInsight_HiloPrivateSDK" value="https://msdata.pkgs.visualstudio.com/_packaging/HDInsight_HiloPrivateSDK/nuget/v3/index.json" />
  </packageSources>
</configuration>
```
2. Then you can run  the bellow cmdlet to install it
```
PM> Install-Package Azure.ResourceManager.HDInsight.AKS -version 1.0.0-privatepreview.1
```

### How to use the sdk
Please follow the bellow sample about how to use the sdk
``` c#
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.HDInsight.AKS;
using Azure.ResourceManager.HDInsight.AKS.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using MsiIdentity = Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity;

namespace HiloSdkDemo
{
    public class Program
    {
        private static ArmClient ArmClient;
        private static string SubscriptionResourceId;
        private static string ResourceGroupName;
        private static string LocationName;
        private static Subscription Subscription;

        private static ClientSecretCredential ClientSecretCredential;

        public static void Main(string[] args)
        {
            Initiazlie();
            CreateTrinoCluster();
        }

        private static void Initiazlie()
        {
            // Create client secret credentials
            string tenantId = "your tenant id";
            string clientId = "{your client id}";
            string clientSecret = "{your secret}";

            ClientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            // Initialize the Arm Client
            ArmClient = new ArmClient(ClientSecretCredential);
            SubscriptionResourceId = "sub id"; // your subscription resource id like /subscriptions/{subscription id}
            ResourceGroupName = ""; // your resource group name
            LocationName = ""; // your location
            Subscription = ArmClient.GetSubscription(new ResourceIdentifier(SubscriptionResourceId));
        }

        public static void CreateTrinoCluster()
        {
            string clusterPoolName = "your pool name";
            var clusterPool = CreateClusterPool(ResourceGroupName, clusterPoolName);

            string trinoClusterName = "your cluster name";
            var trinoCluster = CreateTrinoClusterUnderExistingClusterPool(ResourceGroupName, clusterPool, trinoClusterName);
        }

        private static ClusterPool CreateClusterPool(string resourceGroupName, string clusterPoolName)
        {

            AzureLocation location = new AzureLocation(LocationName);

            // Find resource group collection and get resource group
            var resourceGroupCollection = Subscription.GetResourceGroups();
            ResourceGroup resourceGroup = resourceGroupCollection.Get(resourceGroupName);

            // get cluster pool collection and create and cluster pool
            ///
            /// The common style is that the class {Resource}Collection contains the CRUD methods of resource.
            /// For example ResourceGroupCollection class contains the resource group CRUD methods, the ClusterPoolCollection class contains the cluster pool CRUD methods.
            ///
            var clusterPoolCollection = resourceGroup.GetClusterPools();
            var clusterPoolData = new ClusterPoolData(location);

            var clusterPoolCreateResult = clusterPoolCollection.CreateOrUpdate(true, clusterPoolName, clusterPoolData);

            return clusterPoolCreateResult.Value;
        }

        public static Cluster CreateTrinoClusterUnderExistingClusterPool(string resourceGroupName, ClusterPool clusterPool, string clusterName)
        {

            var resourceGroupCollection = Subscription.GetResourceGroups();
            ResourceGroup resourceGroup = resourceGroupCollection.Get(resourceGroupName);

            // Call Get ClusterOfferingVersions API to get the supported versions per cluster type
            var clusterOfferingVersionsResult = Subscription.GetClusterOfferingVersionsByLocation(LocationName);
            string clusterType = "Trino";
            string trinoStackVersion = clusterOfferingVersionsResult.Where(offerVersion => offerVersion.Name.Equals(clusterType, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()?.StackVersions.LastOrDefault();


            // Create a msi to prepare the IdentityProfile property, If you already have a msi please skip the create msi step
            string msiName = "your msi name";
            MsiIdentity userMsi = CreateManagedUserAssignedIdentity(resourceGroupName, msiName, LocationName);

            // set the IdentityProfile
            string msiClientId = userMsi.ClientId.ToString();
            string msiResourceId = userMsi.Id.ToString();
            string msiObjectId = userMsi.PrincipalId.ToString();
            var identityProfile = new IdentityProfile(msiResourceId: msiResourceId, msiClientId: msiClientId, msiObjectId: msiObjectId);

            // Important! when creating cluster we need to assign cluster pool's aks agent pool's msi as "Managed Identity Operator" role to user msi
            string roleName = "Managed Identity Operator";
            AssignRoleAssignment(msiResourceId, roleName, clusterPool.Data.AksClusterProfile.AksClusterAgentPoolIdentityProfile.MsiObjectId);


            // authorization profile;
            var authorizationProfile = new ClusterAuthorizationProfile();
            string userId = ""; // your user AAD object id, should be a guid
            authorizationProfile.UserIds.Add(userId);

            var clusterData = new ClusterData(LocationName)
            {
                ClusterType = clusterType,
                ComputeProfile = new ComputeProfile(vmSize: "Standard_D8s_v3", count: 5),
                ClusterProfile = new ClusterProfile(stackVersion: trinoStackVersion, identityProfile: identityProfile, authorizationProfile: authorizationProfile)
            };

            // set trino profile
            clusterData.ClusterProfile.TrinoProfile = new Dictionary<string, object>();

            // Create cluster with ClusterCollection
            var clusterCollection = clusterPool.GetClusters();
            var trinoClusterResult = clusterCollection.CreateOrUpdate(true, clusterName, clusterData);
            return trinoClusterResult.Value;
        }


        private static MsiIdentity CreateManagedUserAssignedIdentity(string resoruceGroupName, string msiName, string location)
        {
            // Initiazlie the ManagedServiceIdentityClient to create msi
            TokenCredentials tokenCreds = CreateTokenCredentialsWithClientSecretCredential();
            ManagedServiceIdentityClient msiClient = new ManagedServiceIdentityClient(tokenCreds)
            {
                SubscriptionId = Subscription.Id.SubscriptionId
            };

            //create msi
            var userIdentity = new MsiIdentity(location);
            var msiCreateResult = msiClient.UserAssignedIdentities.CreateOrUpdate(ResourceGroupName, msiName, userIdentity);
            return msiCreateResult;
        }

        private static void AssignRoleAssignment(string scope, string roleName, string assigneePrincipalId)
        {
            // Initiazlie the AuthorizationManagementClient to assign the role
            TokenCredentials tokenCreds = CreateTokenCredentialsWithClientSecretCredential();
            AuthorizationManagementClient authorizationManagementClient = new AuthorizationManagementClient(tokenCreds);

            var roleDefinition = authorizationManagementClient.RoleDefinitions.List(scope).First(role => role.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase));
            var roleAssignementParameter = new RoleAssignmentCreateParameters()
            {
                RoleDefinitionId = roleDefinition.Id,
                PrincipalId = assigneePrincipalId,
                PrincipalType = "ServicePrincipal"
            };

            string roleAssignmentName = Guid.NewGuid().ToString(); // a random guid as role assignment name
            authorizationManagementClient.RoleAssignments.Create(scope, roleAssignmentName, roleAssignementParameter);
        }

        private static TokenCredentials CreateTokenCredentialsWithClientSecretCredential()
        {

            // Initiazlie the ManagedServiceIdentityClient to create msi
            string scope = "https://management.azure.com/.default";
            var tokenRequestContext = new Azure.Core.TokenRequestContext(new string[] { scope });
            var accessToken = ClientSecretCredential.GetToken(tokenRequestContext, default);
            TokenCredentials tokenCreds = new TokenCredentials(accessToken.Token);  //The class type is Microsoft.Rest.TokenCredentials}

            return tokenCreds;
        }
    }
}

```
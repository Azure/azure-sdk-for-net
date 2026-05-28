//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.HDInsight.Job.Tests
{
    using Microsoft.Azure.HDInsight.Job;
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;

    public class HDInsightManagementHelper
    {
        private ResourceManagementClient resourceManagementClient;
        private StorageManagementClient storageManagementClient;
        private HDInsightManagementClient hdInsightManagementClient;
        private SqlManagementClient sqlManagementClient;

        public HDInsightManagementHelper(CommonTestsFixture testMixture, MockContext context)
        {
            resourceManagementClient = testMixture.GetServiceClient<ResourceManagementClient>(context);
            storageManagementClient = testMixture.GetServiceClient<StorageManagementClient>(context);
            hdInsightManagementClient = testMixture.GetServiceClient<HDInsightManagementClient>(context);
            sqlManagementClient = testMixture.GetServiceClient<SqlManagementClient>(context);
        }

        public void RegisterSubscriptionForResource(string providerName)
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(
                reg == null,
                "resourceManagementClient.Providers.Register returned null."
            );

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(
                resultAfterRegister == null,
                "resourceManagementClient.Providers.Get returned null."
            );
            ThrowIfTrue(
                string.IsNullOrEmpty(resultAfterRegister.Id),
                "Provider.Id is null or empty."
            );
            ThrowIfTrue(
                !providerName.Equals(resultAfterRegister.NamespaceProperty),
                string.Format(
                    "Provider name: {0} is not equal to {1}.",
                    resultAfterRegister.NamespaceProperty,
                    providerName
                )
            );
            ThrowIfTrue(
                !resultAfterRegister.RegistrationState.Equals("Registered") &&
                !resultAfterRegister.RegistrationState.Equals("Registering"),
                string.Format(
                    "Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'",
                    resultAfterRegister.RegistrationState
                )
            );
            ThrowIfTrue(
                resultAfterRegister.ResourceTypes == null || resultAfterRegister.ResourceTypes.Count == 0,
                "Provider.ResourceTypes is empty."
            );
        }

        public void CreateResourceGroup(string resourceGroupName, string location)
        {
            // Get the resource group first
            bool exists = false;
            ResourceGroup newlyCreatedGroup = null;
            try
            {
                newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
                exists = true;
            }
            catch
            {
                // Do nothing because it means it doesn't exist
            }

            if (!exists)
            {
                var result =
                    resourceManagementClient.ResourceGroups.CreateOrUpdate(
                        resourceGroupName,
                        new ResourceGroup { Location = location }
                    );

                newlyCreatedGroup =
                    resourceManagementClient.ResourceGroups.Get(
                        resourceGroupName
                    );
            }

            ThrowIfTrue(
                newlyCreatedGroup == null,
                "resourceManagementClient.ResourceGroups.Get returned null."
            );
            ThrowIfTrue(
                !resourceGroupName.Equals(newlyCreatedGroup.Name),
                string.Format(
                    "resourceGroupName is not equal to {0}",
                    resourceGroupName
                )
            );
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        public string CreateStorageAccount(
            string resourceGroupName,
            string storageAccountName,
            string label,
            string description,
            string location,
            string containerName,
            out string storageAccountSuffix
        )
        {
            var stoInput = new StorageAccountCreateParameters
            {
                Location = location,
                Kind = Kind.Storage,
                Sku = new Microsoft.Azure.Management.Storage.Models.Sku
                {
                    Name = SkuName.StandardGRS
                }
            };

            // Retrieve the storage account
            storageManagementClient.StorageAccounts.Create(
                resourceGroupName,
                storageAccountName,
                stoInput
            );

            // Retrieve the storage account primary access key
            var accessKey =
                storageManagementClient.StorageAccounts.ListKeys(
                    resourceGroupName,
                    storageAccountName
                ).Keys[0].Value;

            ThrowIfTrue(
                string.IsNullOrEmpty(accessKey),
                "storageManagementClient.StorageAccounts.ListKeys returned null."
            );

            // Create container
            // Since this is a data-plane client and not an ARM client it's harder to inject
            // HttpMockServer into it to record/playback, but that's fine because we don't need
            // any of the response data to continue with the test.
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                CloudStorageAccount storageAccountClient = new CloudStorageAccount(
                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                        storageAccountName,
                        accessKey),
                    useHttps: true);
                CloudBlobClient blobClient = storageAccountClient.CreateCloudBlobClient();
                CloudBlobContainer containerReference = blobClient.GetContainerReference(containerName);
                containerReference.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            }

            // Set the storage account suffix
            var getResponse = 
                storageManagementClient.StorageAccounts.GetProperties(
                    resourceGroupName, 
                    storageAccountName
                );
            storageAccountSuffix = getResponse.PrimaryEndpoints.Blob.ToString();
            storageAccountSuffix = storageAccountSuffix.Replace("https://", "").TrimEnd('/');
            storageAccountSuffix = storageAccountSuffix.Replace(storageAccountName, "").TrimStart('.');
            // Remove the opening "blob." if it exists.
            storageAccountSuffix = storageAccountSuffix.Replace("blob.",""); 

            return accessKey;
        }

        public void CreateSqlServer(
            string resourceGroupName,
            string location,
            string loginName,
            string password,
            string serverName,
            string dbName,
            string tableName
        )
        {
            string version12 = "12.0";
            Dictionary<string, string> tags = new Dictionary<string, string>();

            var server = sqlManagementClient.Servers.CreateOrUpdate(resourceGroupName, serverName, new Server()
            {
                AdministratorLogin = loginName,
                AdministratorLoginPassword = password,
                Version = version12,
                Tags = tags,
                Location = location
            });

            ThrowIfTrue(
                server == null,
                "sqlManagementClient.Servers.CreateOrUpdate returned null."
            );

            var database = sqlManagementClient.Databases.CreateOrUpdate(resourceGroupName, server.Name, dbName, new Database()
            {
                Location = server.Location
            });

            ThrowIfTrue(
                database == null,
                "sqlManagementClient.Databases.CreateOrUpdate returned null."
            );

            // Create server firewall rule
            sqlManagementClient.FirewallRules.CreateOrUpdate(resourceGroupName, server.Name, "sqltestrule", new FirewallRule()
            {
                StartIpAddress = "0.0.0.0",
                EndIpAddress = "255.255.255.255"
            });

            // Create test table with columns
            // This is not needed in playback because in playback, there is no actual database to execute against
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
            {
                var builder = new SqlConnectionStringBuilder()
                {
                    DataSource = string.Format(server.FullyQualifiedDomainName, server.Name),
                    UserID = loginName,
                    Password = password,
                    InitialCatalog = dbName
                };

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"create table {tableName} (column1 int, column2 nvarchar(max))", conn);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Cluster CreateHDInsightCluster(
            string resourceGroupName,
            string location,
            string clusterName,
            ClusterCreateParameters createParams
        )
        {
            var cluster = hdInsightManagementClient.Clusters.Create(resourceGroupName, clusterName, createParams);

            cluster =
                hdInsightManagementClient.Clusters.Get(
                    resourceGroupName,
                    clusterName
                );

            // Wait for provisioning state to be Succeeded
            // We will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (cluster.Properties.ProvisioningState != HDInsightClusterProvisioningState.Succeeded &&
                   cluster.Properties.ProvisioningState != HDInsightClusterProvisioningState.Failed &&
                   minutesWaited <= timeToWaitInMinutes)
            {
                // Wait for one minute and then go again.
                TestUtilities.Wait(60000);
                minutesWaited++;
                cluster =
                    hdInsightManagementClient.Clusters.Get(
                        resourceGroupName,
                        clusterName
                    );
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(
                cluster.Properties.ProvisioningState != HDInsightClusterProvisioningState.Succeeded,
                "Cluster Account failed to be provisioned into the success state after " + timeToWaitInMinutes + " minutes."
            );

            return cluster;
        }

        public ClusterCreateParameters GetClusterCreateParameters(CommonTestsFixture commonData)
        {
            return new ClusterCreateParameters
            {
                ClusterSizeInNodes = 3,
                ClusterType = commonData.HDInsightClusterType,
                WorkerNodeSize = commonData.WorkNodeSize,
                DefaultStorageInfo = new AzureStorageInfo(commonData.StorageAccountName.ToLowerInvariant(), commonData.StorageAccountAccessKey, commonData.ContainerName),
                UserName = commonData.HttpUserName,
                Password = commonData.HttpUserPassword,
                Location = commonData.Location,
                SshUserName = commonData.SshUserName,
                SshPassword = commonData.SshUserPassword,
                Version = commonData.HDInsightClusterVersion
            };
        }

        public void SubmitSparkJobFile(string resourceGroupName, string storageAccountName,string containerName, string accessKey)
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                CloudStorageAccount storageAccountClient = new CloudStorageAccount(
                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                        storageAccountName,
                        accessKey),
                    useHttps: true);
                CloudBlobClient blobClient = storageAccountClient.CreateCloudBlobClient();
                CloudBlobContainer containerReference = blobClient.GetContainerReference(containerName);
                containerReference.CreateIfNotExistsAsync().GetAwaiter().GetResult();
                string localPath = "./Jar/";
                string fileName = "spark-examples.jar";
                string localFilePath = Path.Combine(localPath, fileName);
                CloudBlockBlob cloudBlockBlob = containerReference.GetBlockBlobReference(fileName);
                cloudBlockBlob.UploadFromFileAsync(localFilePath).Wait();
            }
        }
    }
}

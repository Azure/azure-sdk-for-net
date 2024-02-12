// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    [NonParallelizable]
    internal class LinkedServiceResourceTests : DataFactoryManagementTestBase
    {
        public LinkedServiceResourceTests(bool isAsync) : base(isAsync)
        {
        }

        private string GetStorageAccountAccessKey(ResourceGroupResource resourceGroup)
        {
            var storageAccountName = Recording.GenerateAssetName("adfstorage");
            return GetStorageAccountAccessKey(resourceGroup, storageAccountName).Result;
        }
        [Test]
        [RecordedTest]
        public async Task LinkedService_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            //Create Linked Service
            string accessKey = GetStorageAccountAccessKey(resourceGroup);
            string linkedServiceName = Recording.GenerateAssetName("adf_linkedservice_");
            var linkedService = await CreateLinkedService(dataFactory, linkedServiceName, accessKey);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedServiceName, linkedService.Data.Name);
            //Exist
            bool flag = await dataFactory.GetDataFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsTrue(flag);
            //Get
            var linkedServiceGet = await dataFactory.GetDataFactoryLinkedServices().GetAsync(linkedServiceName);
            Assert.IsNotNull(linkedServiceGet);
            Assert.AreEqual(linkedServiceName, linkedServiceGet.Value.Data.Name);
            //Get All
            var list = await dataFactory.GetDataFactoryLinkedServices().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            //Delete
            await linkedService.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryDatasets().ExistsAsync(linkedServiceName);
            Assert.IsFalse(flag);
        }

        public async Task LinkedSerivceCreate(string name, Func<DataFactoryResource, string, string, DataFactoryLinkedServiceData> linkedServiceFunc)
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName($"adf-rg-{name}-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName($"adf-{name}-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a IntegrationRuntime
            string integrationRuntimeName = Recording.GenerateAssetName("adf-integrationRuntime-");
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            // Create a LinkedService
            string linkedServiceName = Recording.GenerateAssetName($"adf_linkedservice_{name}_");
            string linkedServiceAKVName = Recording.GenerateAssetName($"adf_linkedservice_akv_");
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceAKVName);
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, linkedServiceFunc(dataFactory, linkedServiceAKVName, integrationRuntimeName));
            Assert.NotNull(result.Value.Id);
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureKeyVaultLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkAzureKeyVault = new DataFactoryLinkedServiceData(new AzureKeyVaultLinkedService("https://Test.vault.azure.net/"));
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkAzureKeyVault);
            return result.Value;
        }

        private async Task<DataFactoryLinkedServiceResource> CreateDefaultAzureBlobStorageLinkedService(DataFactoryResource dataFactory, string linkedServiceName)
        {
            DataFactoryLinkedServiceData lkBlobSource = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=testkey;EndpointSuffix=core.windows.net"
            });
            var result = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, lkBlobSource);
            return result.Value;
        }

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultManagedIntegrationRuntime(DataFactoryResource dataFactory, string integrationRuntimeName)
        {
            ManagedIntegrationRuntime properties = new ManagedIntegrationRuntime()
            {
                ComputeProperties = new IntegrationRuntimeComputeProperties()
                {
                    Location = "eastus2",
                    DataFlowProperties = new IntegrationRuntimeDataFlowProperties()
                    {
                        ComputeType = DataFlowComputeType.General,
                        CoreCount = 4,
                        TimeToLiveInMinutes = 10
                    }
                }
            };
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobFS_ServicePrincipalCredential_Create()
        {
            await LinkedSerivceCreate("blob", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
                {
                    Uri = "https://testblobfs.dfs.core.windows.net",
                    ServicePrincipalId = "9c8b1ab1-a894-4639-8fb9-75f98a36e9ab",
                    ServicePrincipalKey = new DataFactorySecretString("mykey"),
                    Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    AzureCloudType = "AzurePublic",
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalCredential = new DataFactorySecretString("mykey")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobFS_Credential_Create()
        {
            await LinkedSerivceCreate("blob", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                DataFactoryLinkedServiceReference stroe = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName);
                return new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
                {
                    Uri = "https://testblobfs.dfs.core.windows.net",
                    ServicePrincipalId = "9c8b1ab1-a894-4639-8fb9-75f98a36e9ab",
                    ServicePrincipalKey = new DataFactoryKeyVaultSecretReference(stroe, "TestSecret"),
                    Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    AzureCloudType = DataFactoryElement<string>.FromLiteral("AzurePublic")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricksDeltaLake_Create()
        {
            await LinkedSerivceCreate("adls", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDatabricksDeltaLakeLinkedService("https://westeurope.azuredatabricks.net/")
                {
                    ClusterId = "0714-063833-cleat653",
                    AccessToken = new DataFactorySecretString("mykey")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage_Create()
        {
            await LinkedSerivceCreate("storage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\"")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage_SasUrl_Create()
        {
            await LinkedSerivceCreate("storage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
                {
                    SasUri = "fakeSasUri"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage_SasUrl_AzureKeyVault_Create()
        {
            await LinkedSerivceCreate("storage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                DataFactoryLinkedServiceReference stroe = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName);
                return new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
                {
                    SasUri = "fakeSasUri",
                    SasToken = new DataFactoryKeyVaultSecretReference(stroe, "TestSecret")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobStorage_ServicePrincipal_Create()
        {
            await LinkedSerivceCreate("blob", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\""),
                    ServiceEndpoint = "fakeserviceEndpoint",
                    AccountKind = "Storage",
                    ServicePrincipalKey = new DataFactorySecretString("fakeservicePrincipalKey")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobStorage_AzureKeyVault_Create()
        {
            await LinkedSerivceCreate("blob", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\test.com;sslmode=1;usesystemtruststore=0\""),
                    ServiceEndpoint = "fakeserviceEndpoint",
                    AccountKind = "Storage",
                    ServicePrincipalKey = new DataFactorySecretString("fakeservicePrincipalKey")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SqlServer_Create()
        {
            await LinkedSerivceCreate("sqlserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Database=myDataBase;"))
                {
                    UserName = "WindowsAuthUserName",
                    Password = new DataFactorySecretString("fakepassword")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForSqlServer_Credential_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myserverinstance.c9pvwz9h1k8r.us-west-2.rds.amazonaws.com;Database=myDataBase;User Id=myUsername;Password=myPassword;"))
                {
                    AlwaysEncryptedSettings = new SqlAlwaysEncryptedProperties(SqlAlwaysEncryptedAkvAuthType.UserAssignedManagedIdentity)
                    {
                        ServicePrincipalId = "fakeServicePrincipalKey",
                        ServicePrincipalKey = new DataFactorySecretString("fakeServicePrincipalKey")
                    }
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForSqlServer_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonRdsForSqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myserverinstance.c9pvwz9h1k8r.us-west-2.rds.amazonaws.com;Database=myDataBase;User Id=myUsername;Password=myPassword;")))
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    AzureCloudType = "AzurePublic"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase_AzureCloudType_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    AzureCloudType = "AzurePublic"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase_AzureKeyVault_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "TestSecret")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlMI_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlMILinkedService(DataFactoryElement<string>.FromSecretString("integrated security=False;encrypt=True;connection timeout=30;data source=test-sqlmi.public.123456789012.database.windows.net,3342;initial catalog=TestDB;"))
                {
                    ServicePrincipalId = "fakeSPID",
                    ServicePrincipalKey = new DataFactorySecretString("fakeSPKey"),
                    Tenant = "fakeTenant",
                    AzureCloudType = "AzurePublic"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDW_Create()
        {
            await LinkedSerivceCreate("sqldw", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerName.database.windows.net;Database=myDatabaseName;User ID=myUsername@myServerName;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    AzureCloudType = "AzurePublic"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDW_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("sqldw", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML_Create()
        {
            await LinkedSerivceCreate("azureml", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey")));
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMLService_Create()
        {
            await LinkedSerivceCreate("azureml", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMLServiceLinkedService("1e42591f-0000-0000-0000-a268f6105ec5", "MyResourceGroupName", "MyMLWorkspaceName")
                {
                    ServicePrincipalId = "fakeSPID",
                    ServicePrincipalKey = new DataFactorySecretString("fakeSPKey"),
                    Tenant = "fakeTenant"
                })
                {
                    Properties =
                    {
                        ConnectVia =new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML_updateResourceEndpoint_Create()
        {
            await LinkedSerivceCreate("azureml", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey"))
                {
                    UpdateResourceEndpoint = "https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML_servicePrincipalId_Create()
        {
            await LinkedSerivceCreate("azureml", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey"))
                {
                    UpdateResourceEndpoint = "https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2",
                    ServicePrincipalId = "fe273844-c808-40b8-ad85-94a46f737731",
                    ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                    Tenant = "microsoft.com"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataLakeAnalytics_Create()
        {
            await LinkedSerivceCreate("adls", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDataLakeAnalyticsLinkedService("fake", "fake")
                {
                    ServicePrincipalId = "fe273844-c808-40b8-ad85-94a46f737731",
                    ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                    DataLakeAnalyticsUri = "fake.com",
                    SubscriptionId = "fe273844-c808-40b8-ad85-94a46f737731"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsight_Create()
        {
            await LinkedSerivceCreate("hdinsight", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://MyCluster.azurehdinsight.net/")
                {
                    UserName = "MyUserName",
                    Password = new DataFactorySecretString("fakepassword")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsight_hcatalogLinkedServiceName_Create()
        {
            await LinkedSerivceCreate("hdinsight", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                string linkedServiceLogName1 = Recording.GenerateAssetName("adf_linkedservice_");
                string linkedServiceLogName2 = Recording.GenerateAssetName("adf_linkedservice_");
                _ = CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceLogName1);
                _ = CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceLogName2);
                return new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://MyCluster.azurehdinsight.net/")
                {
                    UserName = "MyUserName",
                    Password = new DataFactorySecretString("fakepassword"),
                    LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceLogName1),
                    HcatalogLinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceLogName2)
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsightOnDemand_Create()
        {
            await LinkedSerivceCreate("hdinsight", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                string linkedServiceHDInsightName = Recording.GenerateAssetName("adf_linkedservice_");
                DataFactoryLinkedServiceData lkHDInsight = new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://test.azurehdinsight.net"));
                _ = dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceHDInsightName, lkHDInsight);
                return new DataFactoryLinkedServiceData(new HDInsightOnDemandLinkedService(4, "01:30:00", "3.5", new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceHDInsightName), "hostSubscriptionId", "72f988bf-86f1-41af-91ab-2d7cd011db47", "ADF")
                {
                    ServicePrincipalId = "servicePrincipalId",
                    ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                    ClusterNamePrefix = "OnDemandHdiResource",
                    HeadNodeSize = BinaryData.FromString("\"HeadNode\""),
                    DataNodeSize = BinaryData.FromString("\"DataNode\""),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBatch_Create()
        {
            await LinkedSerivceCreate("azurebatch", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                string linkedServiceAzureBlobName = Recording.GenerateAssetName("adf_linkedservice_");
                var linkedService = dataFactory.GetDataFactoryLinkedServices();
                _ = CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceAzureBlobName);
                return new DataFactoryLinkedServiceData(new AzureBatchLinkedService(DataFactoryElement<string>.FromSecretString("parameters"), "myaccount.region.batch.windows.com", "myPoolname", new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceAzureBlobName))
                {
                    AccessKey = new DataFactorySecretString("fakeAccesskey")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SqlServer_encryptedCredential_Create()
        {
            await LinkedSerivceCreate("sqlserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Database=myDataBase;Uid=myUsername;"))
                {
                    Password = new DataFactorySecretString("fakepassword"),
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Oracle_Create()
        {
            await LinkedSerivceCreate("oracle", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new OracleLinkedService(DataFactoryElement<string>.FromSecretString("Data Source = MyOracleDB; User Id = myUsername; Password = myPassword; Integrated Security = no;"))
                {
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Oracle_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("oracle", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new OracleLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForOracle_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromSecretString("Host=10.10.10.10;Port=1234;Sid=fakeSid;User Id=fakeUsername;Password=fakePassword"))
                {
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForOracle_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_FileServer_Create()
        {
            await LinkedSerivceCreate("fileserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new FileServerLinkedService(DataFactoryElement<string>.FromSecretString("Myhost"))
                {
                    UserId = "MyUserId",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                    EncryptedCredential = "MyEncryptedCredentials"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_Create()
        {
            await LinkedSerivceCreate("cosmosdb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("mongodb://username:password@localhost:27017/?authSource=admin")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_accountEndpoint_Create()
        {
            await LinkedSerivceCreate("cosmosdb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
                {
                    AccountEndpoint = "https://fakecosmosdb.documents.azure.com:443/",
                    Database = "testdb",
                    AccountKey = new DataFactorySecretString("fakeconnectstring")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("cosmosdb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
                {
                    ConnectionString = "fakeConnString",
                    AccountKey = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_servicePrincipalId_Create()
        {
            await LinkedSerivceCreate("cosmosdb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
                {
                    ConnectionString = "mongodb://username:password@localhost:27017/?authSource=admin",
                    ServicePrincipalId = "fakeservicePrincipalId",
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalCredential = new DataFactorySecretString("fakeservicePrincipalCredential"),
                    Tenant = "faketenant",
                    AzureCloudType = "fakeazurecloudtype",
                    ConnectionMode = new CosmosDBConnectionMode()
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Teradata_Create()
        {
            await LinkedSerivceCreate("teradata", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new TeradataLinkedService()
                {
                    Server = "volvo2.teradata.ws",
                    Username = "microsoft",
                    AuthenticationType = TeradataAuthenticationType.Basic,
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Teradata_connectionString_Create()
        {
            await LinkedSerivceCreate("teradata", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new TeradataLinkedService()
                {
                    ConnectionString = "connectstring",
                    Username = "microsoft",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_ODBC_Create()
        {
            await LinkedSerivceCreate("odbc", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new OdbcLinkedService(DataFactoryElement<string>.FromSecretString("Driver={ODBC Driver 17 for SQL Server};Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"))
                {
                    UserName = "MyUserName",
                    Password = new DataFactorySecretString("fakepassword"),
                    Credential = new DataFactorySecretString("fakeCredential"),
                    AuthenticationType = "Basic",
                    EncryptedCredential = "MyEncryptedCredentials",
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Informix_Create()
        {
            await LinkedSerivceCreate("informix", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new InformixLinkedService(DataFactoryElement<string>.FromSecretString("Database=TestDB;Host=192.168.10.10;Server=db_engine_tcp;Service=1492;Protocol=onsoctcp;UID=fakeUsername;Password=fakePassword;"))
                {
                    UserName = "MyUserName",
                    Password = new DataFactorySecretString("fakepassword"),
                    Credential = new DataFactorySecretString("fakeCredential"),
                    AuthenticationType = "Basic",
                    EncryptedCredential = "MyEncryptedCredentials",
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MicrosoftAccess_Create()
        {
            await LinkedSerivceCreate("access", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MicrosoftAccessLinkedService(DataFactoryElement<string>.FromSecretString("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myFolder\\myAccessFile.accdb;Persist Security Info=False;\r\n"))
                {
                    UserName = "MyUserName",
                    Password = new DataFactorySecretString("fakepassword"),
                    Credential = new DataFactorySecretString("fakeCredential"),
                    AuthenticationType = "Basic",
                    EncryptedCredential = "MyEncryptedCredentials",
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hdfs_Create()
        {
            await LinkedSerivceCreate("hdfs", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new HdfsLinkedService("http://myhost:50070/webhdfs/v1")
                {
                    UserName = "Microsoft",
                    Password = new DataFactorySecretString("fakepassword"),
                    AuthenticationType = "Basic",
                    EncryptedCredential = "MyEncryptedCredentials",
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Web_Create()
        {
            await LinkedSerivceCreate("web", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate, null);
                return new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties)
                {
                    LinkedServiceType = "Web",
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Web1_Create()
        {
            await LinkedSerivceCreate("web", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate, null);
                return new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties)
                {
                    LinkedServiceType = "Web",
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Cassandra_Create()
        {
            await LinkedSerivceCreate("cassandra", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CassandraLinkedService("http://localhost/webhdfs/v1/")
                {
                    Description = "test description",
                    AuthenticationType = "Basic",
                    Port = 1234,
                    Username = "admin",
                    Password = new DataFactorySecretString("fakepassword"),
                    EncryptedCredential = "fake credential"
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "Office365")
                {
                    Username = "admin",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_S2S_Key_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "AadServicePrincipal")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_S2S_Cert_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "AadServicePrincipal")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_organizationName_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "Office365")
                {
                    HostName = "hostname.com",
                    Port = 1234,
                    OrganizationName = "contoso",
                    Username = "fakeuser@contoso.com",
                    Password = new DataFactorySecretString("fakepassword"),
                    EncryptedCredential = "fake credential"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
                {
                    HostName = "hostname.com",
                    Port = 1234,
                    OrganizationName = "contoso",
                    Username = "fakeuser@contoso.com",
                    Password = new DataFactorySecretString("fakepassword"),
                    EncryptedCredential = "fake credential"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm_S2S_Key_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm_S2S_Cert_Create()
        {
            await LinkedSerivceCreate("dynamics", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps_S2S_Key_Create()
        {
            await LinkedSerivceCreate("commondataserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "AadServicePrincipal")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps_S2S_Cert_Create()
        {
            await LinkedSerivceCreate("commondataserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "AadServicePrincipal")
                {
                    ServicePrincipalCredentialType = "ServicePrincipalKey",
                    ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                    ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
                })
                {
                    Properties =
                    {
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps_Create()
        {
            await LinkedSerivceCreate("commondataserver", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "Office365")
                {
                    HostName = "hostname.com",
                    Port = 1234,
                    OrganizationName = "contoso",
                    Username = "fakeuser@contoso.com",
                    Password = new DataFactorySecretString("fakepassword"),
                    EncryptedCredential = "fake credential"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce_Token_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceLinkedService()
                {
                    EnvironmentUri = "Uri",
                    Username = "admin",
                    Password = new DataFactorySecretString("fakepassword"),
                    SecurityToken = new DataFactorySecretString("fakeToken"),
                    ApiVersion = "27.0"
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceLinkedService()
                {
                    EnvironmentUri = "Uri",
                    Username = "admin",
                    Password = new DataFactorySecretString("fakepassword"),
                    ApiVersion = "27.0"
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceLinkedService()
                {
                    EnvironmentUri = "Uri",
                    Username = "admin",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                    SecurityToken = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName2"),
                    ApiVersion = "27.0"
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceServiceCloud_Token_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
                {
                    EnvironmentUri = "Uri",
                    Username = "admin",
                    Password = new DataFactorySecretString("fakepassword"),
                    SecurityToken = new DataFactorySecretString("faketoken"),
                    ApiVersion = "27.0"
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceServiceCloud_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
                {
                    EnvironmentUri = "Uri",
                    Username = "admin",
                    Password = new DataFactorySecretString("fakepassword"),
                    ApiVersion = "27.0"
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceMarketingCloud_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceMarketingCloudLinkedService()
                {
                    ClientId = "clientid",
                    ClientSecret = new DataFactorySecretString("fakepassword")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceMarketingCloud_connection_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SalesforceMarketingCloudLinkedService()
                {
                    ClientId = "fakeClientId",
                    ClientSecret = new DataFactorySecretString("fakeClientSecret")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MongoDb_Create()
        {
            await LinkedSerivceCreate("salesforce", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MongoDBLinkedService("fakeserver.com", "fakedb")
                {
                    AuthenticationType = "Basic",
                    Port = 1234,
                    Username = "fakeuser@contoso.com",
                    Password = new DataFactorySecretString("fakepassword"),
                    AuthSource = "fackadmindb",
                    EncryptedCredential = "fake credential"
                })
                {
                    Properties =
                    {
                        Description = "test description",
                        ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRedshift_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonRedshiftLinkedService("fakeserver.com", "fakedb")
                {
                    Port = 1234,
                    Username = "fakeuser@contoso.com",
                    Password = new DataFactorySecretString("fakepassword"),
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
                {
                    AccessKeyId = "fakeaccess",
                    SecretAccessKey = new DataFactorySecretString("fakekey")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3_sessionToken_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
                {
                    AuthenticationType = "TemporarySecurityCredentials",
                    AccessKeyId = "fakeaccess",
                    SecretAccessKey = new DataFactorySecretString("fakekey"),
                    SessionToken = new DataFactorySecretString("fakesessiontoken")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3Compatible_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonS3CompatibleLinkedService()
                {
                    AccessKeyId = "fakeaccess",
                    SecretAccessKey = new DataFactorySecretString("fakekey"),
                    ServiceUri = "fakeserviceurl",
                    ForcePathStyle = true
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataLakeStore_Create()
        {
            await LinkedSerivceCreate("adls", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDataLakeStoreLinkedService("fakeUrl")
                {
                    ServicePrincipalId = "fakeid",
                    ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSearch_Create()
        {
            await LinkedSerivceCreate("azuresearch", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureSearchLinkedService("fakeUrl")
                {
                    Key = new DataFactorySecretString("fakeKey"),
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_FtpServer_Create()
        {
            await LinkedSerivceCreate("ftp", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new FtpServerLinkedService("fakeHost")
                {
                    AuthenticationType = FtpAuthenticationType.Basic,
                    UserName = "fakeName",
                    Password = new DataFactorySecretString("fakePassword")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Sftp_Create()
        {
            await LinkedSerivceCreate("sftp", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SftpServerLinkedService("fakeHost")
                {
                    AuthenticationType = SftpAuthenticationType.Basic,
                    UserName = "fakeName",
                    Password = new DataFactorySecretString("fakePassword"),
                    PrivateKeyPath = "fakeprivateKeyPath",
                    PrivateKeyContent = new DataFactorySecretString("fakeprivateKeyContent")
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapBW_Create()
        {
            await LinkedSerivceCreate("sap", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SapBWLinkedService("fakeServer", "fakeNumber", "fakeId")
                {
                    UserName = "fakeName",
                    Password = new DataFactorySecretString("fakePassword"),
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapHana_Create()
        {
            await LinkedSerivceCreate("sap", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SapHanaLinkedService()
                {
                    Server = "fakeserver",
                    AuthenticationType = SapHanaAuthenticationType.Basic,
                    UserName = "fakeName",
                    Password = new DataFactorySecretString("fakePassword"),
                })
                {
                    Properties =
                    {
                        Description = "test description"
                    }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMySql_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress.mysql.database.azure.com;Port=3306;Database=myDataBase;Uid=myUsername@myServerAddress;Pwd=myPassword;SslMode=Required;")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMySql_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("azuresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("fakestring"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonMWS_Create()
        {
            await LinkedSerivceCreate("amazon", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AmazonMwsLinkedService("mws,amazonservices.com", "A2EUQ1WTGCTBG2", "ACGMZIK6QTD9T", "128393242334")
                {
                    MwsAuthToken = new DataFactorySecretString("fakeMwsAuthToken"),
                    SecretKey = new DataFactorySecretString("fakeSecretKey"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzurePostgreSql_Create()
        {
            await LinkedSerivceCreate("azurepostgre", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromKeyVaultSecretReference(new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"))
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzurePostgreSql_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("azurepostgre", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                    ConnectionString = DataFactoryElement<string>.FromKeyVaultSecretReference(new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"))
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Concur_Create()
        {
            await LinkedSerivceCreate("concur", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ConcurLinkedService("f145kn9Pcyq9pr4lvumdapfl4rive", "jsmith")
                {
                    Password = new DataFactorySecretString("somesecret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Couchbase_Create()
        {
            await LinkedSerivceCreate("couchbase", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Couchbase_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("azurekeyvalue", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                    CredString = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Drill_Create()
        {
            await LinkedSerivceCreate("drill", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DrillLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Drill_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("drill", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DrillLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Eloqua_Create()
        {
            await LinkedSerivceCreate("eloqua", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new EloquaLinkedService("eloqua.example.com", "username")
                {
                    Password = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleAdWords_Create()
        {
            await LinkedSerivceCreate("google", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GoogleAdWordsLinkedService()
                {
                    ClientCustomerId = "myclientcustomerID",
                    DeveloperToken = new DataFactorySecretString("some secret"),
                    AuthenticationType = GoogleAdWordsAuthenticationType.ServiceAuthentication,
                    RefreshToken = new DataFactorySecretString("some secret"),
                    ClientId = "MyclientID",
                    ClientSecret = new DataFactorySecretString("some secret"),
                    Email = "someone@microsoft.com",
                    KeyFilePath = "Mykeyfilepath",
                    TrustedCertPath = "mytrustedCetpath",
                    UseSystemTrustStore = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Greenplum_Create()
        {
            await LinkedSerivceCreate("greeplum", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GreenplumLinkedService()
                {
                    ConnectionString = "SecureString"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Greenplum_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("greeplum", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GreenplumLinkedService()
                {
                    ConnectionString = "SecureString",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HBase_Create()
        {
            await LinkedSerivceCreate("hbase", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new HBaseLinkedService("192.168.12.122", HBaseAuthenticationType.Anonymous)
                {
                    HttpPath = "/gateway/sandbox/hbase/version",
                    EnableSsl = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hive_Create()
        {
            await LinkedSerivceCreate("hive", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new HiveLinkedService("192.168.12.122", HiveAuthenticationType.Anonymous)
                {
                    Port = 1000,
                    ServerType = "Hiveserver",
                    ThriftTransportProtocol = HiveThriftTransportProtocol.Binary,
                    ServiceDiscoveryMode = true,
                    ZooKeeperNameSpace = "",
                    UseNativeQuery = true,
                    Username = "name",
                    Password = new DataFactorySecretString("some secret"),
                    TrustedCertPath = "",
                    HttpPath = "/gateway/sandbox/hbase/version",
                    EnableSsl = true,
                    UseSystemTrustStore = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hubspot_Create()
        {
            await LinkedSerivceCreate("hubspot", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new HubspotLinkedService("11b5516f1322-11e6-9653-93a39db85acf")
                {
                    ClientSecret = new DataFactorySecretString("abCD+E1f2Gxhi3J4klmN/OP5QrSTuvwXYzabcdEF"),
                    AccessToken = new DataFactorySecretString("some secret"),
                    RefreshToken = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Impala_Create()
        {
            await LinkedSerivceCreate("impala", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ImpalaLinkedService("192.168.12.122", ImpalaAuthenticationType.Anonymous)
                {
                    Username = "",
                    Password = new DataFactorySecretString("some secret"),
                    EnableSsl = true,
                    TrustedCertPath = "",
                    UseSystemTrustStore = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Jira_Create()
        {
            await LinkedSerivceCreate("jira", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new JiraLinkedService("192.168.12.122", "skroob")
                {
                    Port = 1000,
                    Password = new DataFactorySecretString("some secret"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Magento_Create()
        {
            await LinkedSerivceCreate("magento", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MagentoLinkedService("192.168.12.122")
                {
                    AccessToken = new DataFactorySecretString("some secret"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Mariadb_Create()
        {
            await LinkedSerivceCreate("mariadb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MariaDBLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("Server=mydemoserver.mariadb.database.azure.com; Port=3306; Database=wpdb; Uid=WPAdmin@mydemoserver; Pwd=mypassword!2; SslMode=Required;\r\n")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MongoDbAtlas_Create()
        {
            await LinkedSerivceCreate("mongodb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MongoDBAtlasLinkedService(DataFactoryElement<string>.FromSecretString("mongodb://username:password@localhost:27017/?authSource=admin"), "database") { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMariadb_Create()
        {
            await LinkedSerivceCreate("azuremariadb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureMariaDBLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("Server=mydemoserver.mariadb.database.azure.com; Port=3306; Database=wpdb; Uid=fakeUsername; Pwd=fakePassword; SslMode=Required;")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Mariadb_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("mongodb", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MariaDBLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connnection secret"),
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Marketo_Create()
        {
            await LinkedSerivceCreate("marketo", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MarketoLinkedService("123-ABC-321.mktorest.com", "fakeClientId")
                {
                    ClientSecret = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Paypal_Create()
        {
            await LinkedSerivceCreate("paypal", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MarketoLinkedService("api.sandbox.paypal.com", "fakeClientId")
                {
                    ClientSecret = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Phoenix_Create()
        {
            await LinkedSerivceCreate("phoenix", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new PhoenixLinkedService("192.168.222.160", PhoenixAuthenticationType.Anonymous)
                {
                    Port = 443,
                    HttpPath = "/gateway/sandbox/phoenix/version",
                    EnableSsl = true,
                    UseSystemTrustStore = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Presto_Create()
        {
            await LinkedSerivceCreate("presto", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new PrestoLinkedService("192.168.222.160", "0.148-t", "test", PrestoAuthenticationType.Anonymous)
                {
                    Username = "test",
                    Password = new DataFactorySecretString("some secret"),
                    EnableSsl = true,
                    TrustedCertPath = "",
                    UseSystemTrustStore = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_QuickBooks_Create()
        {
            await LinkedSerivceCreate("quickbooks", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new QuickBooksLinkedService()
                {
                    Endpoint = "quickbooks.api.intuit.com",
                    CompanyId = "fakeCompanyId",
                    ConsumerKey = "fakeConsumerKey",
                    ConsumerSecret = new DataFactorySecretString("some secret"),
                    AccessToken = new DataFactorySecretString("some secret"),
                    AccessTokenSecret = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_ServiceNow_Create()
        {
            await LinkedSerivceCreate("servicenow", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ServiceNowLinkedService("http://instance.service-now.com", ServiceNowAuthenticationType.Basic)
                {
                    Username = "admin",
                    Password = new DataFactorySecretString("some secret")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Shopify_Create()
        {
            await LinkedSerivceCreate("shopify", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ShopifyLinkedService("mystore.myshopify.com")
                {
                    AccessToken = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Spark_Create()
        {
            await LinkedSerivceCreate("spark", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SparkLinkedService("myserver", 443, SparkAuthenticationType.WindowsAzureHDInsightService)
                {
                    ServerType = SparkServerType.SharkServer,
                    ThriftTransportProtocol = SparkThriftTransportProtocol.Binary,
                    Username = "admin",
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "HuF3pmB3tylfer63MAbxTAGeVFyteGa+YIHFKPc2IguJqXwUOtvFUwMOeeX/ARhsUlt3xhS7b6XmNfGx2HVk5A=="),
                    HttpPath = "/",
                    EnableSsl = true,
                    UseSystemTrustStore = true,
                    AllowHostNameCNMismatch = true,
                    AllowSelfSignedServerCert = true
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Square_Create()
        {
            await LinkedSerivceCreate("square", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SquareLinkedService()
                {
                    Host = "mystore.mysquare.com",
                    ClientId = "clientIdFake",
                    ClientSecret = new DataFactorySecretString("some secret"),
                    RedirectUri = "http://localhost:2500",
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Square_ConnectionProperties_Create()
        {
            await LinkedSerivceCreate("square", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SquareLinkedService()
                {
                    ConnectionProperties = BinaryData.FromString(@"{
                    ""host"": ""mystore.mysquare.com"",
                    ""clientId"": ""clientIdFake"",
                    ""clientSecret"": {
                        ""type"": ""SecureString"",
                        ""value"": ""some secret""
                    },
                    ""redirectUri"": ""http://localhost:2500"",
                    ""useEncryptedEndpoints"": true,
                    ""useHostVerification"": true,
                    ""usePeerVerification"": true
                }")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Xero_Create()
        {
            await LinkedSerivceCreate("xero", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new XeroLinkedService()
                {
                    Host = "api.xero.com",
                    ConsumerKey = new DataFactorySecretString("some secret"),
                    PrivateKey = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Xero_ConnectionProperties_Create()
        {
            await LinkedSerivceCreate("xero", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new XeroLinkedService()
                {
                    ConnectionProperties = BinaryData.FromString(@"{
                    ""host"": ""api.xero.com"",
                    ""consumerKey"": {
                        ""type"": ""SecureString"",
                        ""value"": ""some secret""
                    },
                    ""privateKey"": {
                        ""type"": ""SecureString"",
                        ""value"": ""some secret""
                    },
                    ""useEncryptedEndpoints"": true,
                    ""useHostVerification"": true,
                    ""usePeerVerification"": true
                }")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zoho_Create()
        {
            await LinkedSerivceCreate("zoho", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ZohoLinkedService()
                {
                    Endpoint = "crm.zoho.com/crm/private",
                    AccessToken = new DataFactorySecretString("some secret"),
                    UseEncryptedEndpoints = true,
                    UseHostVerification = true,
                    UsePeerVerification = true
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zoho_ConnectionProperties_Create()
        {
            await LinkedSerivceCreate("zoho", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ZohoLinkedService()
                {
                    ConnectionProperties = BinaryData.FromString(@"{
                    ""endpoint"": ""crm.zoho.com/crm/private"",
                    ""accessToken"": {
                        ""type"": ""SecureString"",
                        ""value"": ""some secret""
                    },
                    ""useEncryptedEndpoints"": true,
                    ""useHostVerification"": true,
                    ""usePeerVerification"": true
                }")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleAdWords_ConnectionProperties_Create()
        {
            await LinkedSerivceCreate("google", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GoogleAdWordsLinkedService()
                {
                    ConnectionProperties = BinaryData.FromString(@"{
                ""connectionProperties"": {
                				""clientCustomerID"": ""fakeClientCustomerID"",
                				""developerToken"": {
                					""type"": ""SecureString"",
                					""value"": ""some secret""
                				}
                			}
                }")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Netezza_Create()
        {
            await LinkedSerivceCreate("netezza", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new NetezzaLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Vertica_Create()
        {
            await LinkedSerivceCreate("vertica", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new VerticaLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Vertica_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("vertica", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new VerticaLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks_Create()
        {
            await LinkedSerivceCreate("adls", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
                {
                    AccessToken = new DataFactorySecretString("some secret"),
                    ExistingClusterId = "1215-091927-stems91",
                });
            });
        }

        [Test]
        [RecordedTest]

        public async Task LinkedService_AzureDatabricks_Script_Create()
        {
            await LinkedSerivceCreate("azuredatabricks", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
                {
                    AccessToken = new DataFactorySecretString("some secret"),
                    NewClusterVersion = "3.4.x-scala2.11",
                    NewClusterNumOfWorker = "1",
                    NewClusterNodeType = "Standard_DS3_v2",
                    NewClusterDriverNodeType = "Standard_DS3_v2",
                    NewClusterLogDestination = "dbfs:/test",
                    NewClusterInitScripts = new List<string>()
                            {
                    "fakeScript"
                            },
                    NewClusterEnableElasticDisk = true
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks_workspaceResourceId_Create()
        {
            await LinkedSerivceCreate("azuredatabricks", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
                {
                    Authentication = "MSI",
                    WorkspaceResourceId = "/subscriptions/1e42591f-1f0c-4c5a-b7f2-a268f6105ec5/resourceGroups/keshADF_test/providers/Microsoft.Databricks/workspaces/keshPremDB",
                    NewClusterVersion = "3.4.x-scala2.11",
                    NewClusterNumOfWorker = "1",
                    NewClusterNodeType = "Standard_DS3_v2",
                    NewClusterDriverNodeType = "Standard_DS3_v2",
                    PolicyId = "DS2K4A1WIEIQDX",
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks_NewClusterSparkEnvVars_Create()
        {
            await LinkedSerivceCreate("azuredatabricks", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
                {
                    AccessToken = new DataFactorySecretString("some secret"),
                    NewClusterVersion = "3.4.x-scala2.11",
                    NewClusterNumOfWorker = "1",
                    NewClusterNodeType = "Standard_DS3_v2"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Db2_Connection_Create()
        {
            await LinkedSerivceCreate("db2", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new Db2LinkedService()
                {
                    ConnectionString = "Server=<server>;Database=<database>;AuthenticationType=Basic;UserName=<username>;PackageCollection=<packageCollection>;CertificateCommonName=<certificateCommonName>",
                })
                {
                    Properties =
                 {
                     ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                 }
                };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapOpenHub_MessageServerService_Create()
        {
            await LinkedSerivceCreate("sap", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SapOpenHubLinkedService()
                {
                    MessageServer = "fakeserver",
                    MessageServerService = "00",
                    SystemId = "ecc",
                    LogonGroup = "fakegroup",
                    ClientId = "800",
                    UserName = "user",
                    Password = new DataFactorySecretString("fakepwd"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_RestService_Create()
        {
            await LinkedSerivceCreate("restservice", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new RestServiceLinkedService("https://fakeurl/", RestServiceAuthenticationType.Basic)
                {
                    UserName = "user",
                    Password = new DataFactorySecretString("fakepwd"),
                    AzureCloudType = "azurepublic"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapTable_Create()
        {
            await LinkedSerivceCreate("sap", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SapTableLinkedService()
                {
                    Server = "fakeserver",
                    SystemNumber = "00",
                    ClientId = "000",
                    UserName = "user",
                    Password = new DataFactorySecretString("fakepwd"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataExplorer_Create()
        {
            await LinkedSerivceCreate("azuredataexplorer", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureDataExplorerLinkedService("https://fakecluster.eastus2.kusto.windows.net", "MyDatabase")
                {
                    ServicePrincipalId = "fakeSPID",
                    ServicePrincipalKey = new DataFactorySecretString("fakepwd"),
                    Tenant = "faketenant"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    Host = "fakehost",
                    UserId = "fakeaccess",
                    Password = new DataFactorySecretString("fakepwd"),
                })
                { Properties = { Description = "test description" } };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_ConnectionString_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("DefaultEndpointsProtocol=https;AccountName=testaccount;EndpointSuffix=core.windows.net;")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_FileShare_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\""),
                    FileShare = "myFileshareName",
                    Snapshot = "2020-06-18T02:35.43"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_AccountKey_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("fakeconnection"),
                    AccountKey = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_SasUri_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    SasUri = DataFactoryElement<string>.FromSecretString("fakeconnection"),
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_SasToken_Create()
        {
            await LinkedSerivceCreate("azurefilestorage", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
                {
                    SasUri = DataFactoryElement<string>.FromSecretString("fakeconnection"),
                    SasToken = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleCloudStorage_Create()
        {
            await LinkedSerivceCreate("google", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GoogleCloudStorageLinkedService()
                {
                    AccessKeyId = "Fakeaccess",
                    SecretAccessKey = new DataFactorySecretString("fakekey")
                })
                { Properties = { Description = "test description" } };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SharePointOnlineList_Create()
        {
            await LinkedSerivceCreate("sharepoint", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SharePointOnlineListLinkedService("http://localhost/webhdfs/v1/", "tenantId", "servicePrincipalId", new DataFactorySecretString("ServicePrincipalKey")) { }) { Properties = { Description = "test description" } };
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDbMongoDbApi_Create()
        {
            await LinkedSerivceCreate("cosmos", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new CosmosDBMongoDBApiLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB")
                {
                    IsServerVersionAbove32 = true,
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_TeamDesk_Create()
        {
            await LinkedSerivceCreate("teamdesk", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new TeamDeskLinkedService(TeamDeskAuthenticationType.Basic, "testUrl")
                {
                    UserName = "username",
                    Password = new DataFactorySecretString("fakePassword")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Quickbase_Create()
        {
            await LinkedSerivceCreate("quickbase", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new QuickbaseLinkedService("testUrl", new DataFactorySecretString("FakeuerToken")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Smartsheet_Create()
        {
            await LinkedSerivceCreate("smartsheet", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new SmartsheetLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zendesk_Create()
        {
            await LinkedSerivceCreate("zendesk", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new ZendeskLinkedService(ZendeskAuthenticationType.Token, "testUri")
                {
                    ApiToken = new DataFactorySecretString("FakeApiToeken")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dataworld_Create()
        {
            await LinkedSerivceCreate("dataworld", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new DataworldLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_RestService_CertificateValidation_Create()
        {
            await LinkedSerivceCreate("restservice", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new RestServiceLinkedService("testUri", RestServiceAuthenticationType.OAuth2ClientCredential)
                {
                    EnableServerCertificateValidation = true,
                    ClientId = "FakeclientID",
                    ClientSecret = new DataFactorySecretString("somesecret"),
                    TokenEndpoint = "fakeTokenEndpoint",
                    Resource = "fakeResource",
                    Scope = "FakeScope"
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleSheets_Create()
        {
            await LinkedSerivceCreate("google", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new GoogleSheetsLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MySql_Create()
        {
            await LinkedSerivceCreate("mysql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new MySqlLinkedService()
                {
                    ConnectionString = DataFactoryElement<string>.FromSecretString("Fakeconnstring"),
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_PostgreSql_Create()
        {
            await LinkedSerivceCreate("postgresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new PostgreSqlLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;\r\n")) { });
            });
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_PostgreSql_AzureKeyValue_Create()
        {
            await LinkedSerivceCreate("postgresql", (dataFactory, linkedServiceKeyVaultName, integrationRuntimeName) =>
            {
                return new DataFactoryLinkedServiceData(new PostgreSqlLinkedService(DataFactoryElement<string>.FromSecretString("Fakeconnstring"))
                {
                    Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
                });
            });
        }
    }
}

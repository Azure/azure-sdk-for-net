// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class LinkedServiceResourceTests : DataFactoryManagementTestBase
    {
        private string _accessKey;
        public LinkedServiceResourceTests(bool isAsync) : base(isAsync)
        {
        }

        public async Task<DataFactoryResource> TestSetup()
        {
            var rgName = Recording.GenerateAssetName("DataFactory-RG-");
            var storageAccountName = Recording.GenerateAssetName("datafactory");
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            var subscription = await Client.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _accessKey = await GetStorageAccountAccessKey(rgLro.Value, storageAccountName);
            return await CreateDataFactory((Client.GetResourceGroupResource(rgLro.Value.Data.Id)), dataFactoryName);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = await CreateLinkedService(dataFactory, linkedServiceName, _accessKey);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedServiceName, linkedService.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            await CreateLinkedService(dataFactory, linkedServiceName, _accessKey);
            bool flag = await dataFactory.GetDataFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            await CreateLinkedService(dataFactory, linkedServiceName, _accessKey);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().GetAsync(linkedServiceName);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(linkedServiceName, linkedService.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            await CreateLinkedService(dataFactory, linkedServiceName, _accessKey);
            var list = await dataFactory.GetDataFactoryLinkedServices().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = await CreateLinkedService(dataFactory, linkedServiceName, _accessKey);
            bool flag = await dataFactory.GetDataFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsTrue(flag);

            await linkedService.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryLinkedServices().ExistsAsync(linkedServiceName);
            Assert.IsFalse(flag);
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
        public async Task LinkedService_AzureBlobFS_ServicePrincipalCredential()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
            {
                Uri = "https://testblobfs.dfs.core.windows.net",
                ServicePrincipalId = "9c8b1ab1-a894-4639-8fb9-75f98a36e9ab",
                ServicePrincipalKey = new DataFactorySecretString("mykey"),
                Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                AzureCloudType = "AzurePublic",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("mykey")
            });

            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobFS_Credential()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceReference stroe = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName);
            ServicePrincipalCredential servicePrincipalCredential = new ServicePrincipalCredential()
            {
                Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                ServicePrincipalId = "9c8b1ab1-a894-4639-8fb9-75f98a36e9ab",
                ServicePrincipalKey = new DataFactoryKeyVaultSecretReference(stroe, "TestSecret")
            };

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureBlobFSLinkedService()
            {
                Uri = "https://testblobfs.dfs.core.windows.net",
                ServicePrincipalId = "9c8b1ab1-a894-4639-8fb9-75f98a36e9ab",
                ServicePrincipalKey = new DataFactoryKeyVaultSecretReference(stroe, "TestSecret"),
                Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                AzureCloudType = DataFactoryElement<string>.FromLiteral("AzurePublic")
            });

            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricksDeltaLake()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDatabricksDeltaLakeLinkedService("https://westeurope.azuredatabricks.net/")
            {
                ClusterId = "0714-063833-cleat653",
                AccessToken = new DataFactorySecretString("mykey")
            });

            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\"")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage_SasUrl()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
            {
                SasUri = "fakeSasUri"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureStorage_SasUrl_AzureKeyVault()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceReference stroe = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureStorageLinkedService()
            {
                SasUri = "fakeSasUri",
                SasToken = new DataFactoryKeyVaultSecretReference(stroe, "TestSecret")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobStorage_ServicePrincipal()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\""),
                ServiceEndpoint = "fakeserviceEndpoint",
                AccountKind = "Storage",
                ServicePrincipalKey = new DataFactorySecretString("fakeservicePrincipalKey")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBlobStorage_AzureKeyVault()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\test.com;sslmode=1;usesystemtruststore=0\""),
                ServiceEndpoint = "fakeserviceEndpoint",
                AccountKind = "Storage",
                ServicePrincipalKey = new DataFactorySecretString("fakeservicePrincipalKey")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Database=myDataBase;"))
            {
                UserName = "WindowsAuthUserName",
                Password = new DataFactorySecretString("fakepassword")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForSqlServer_Credential()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myserverinstance.c9pvwz9h1k8r.us-west-2.rds.amazonaws.com;Database=myDataBase;User Id=myUsername;Password=myPassword;"))
            {
                AlwaysEncryptedSettings = new SqlAlwaysEncryptedProperties(SqlAlwaysEncryptedAkvAuthType.UserAssignedManagedIdentity)
                {
                    ServicePrincipalId = "fakeServicePrincipalKey",
                    ServicePrincipalKey = new DataFactorySecretString("fakeServicePrincipalKey")
                }
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForSqlServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonRdsForSqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myserverinstance.c9pvwz9h1k8r.us-west-2.rds.amazonaws.com;Database=myDataBase;User Id=myUsername;Password=myPassword;")))
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                AzureCloudType = "AzurePublic"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase_AzureCloudType()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("Server=tcp:myServerAddress.database.windows.net,1433;Database=myDataBase;User ID=myUsername;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                AzureCloudType = "AzurePublic"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDatabase_AzureKeyVault()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "TestSecret")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlMI()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlMILinkedService(DataFactoryElement<string>.FromSecretString("integrated security=False;encrypt=True;connection timeout=30;data source=test-sqlmi.public.123456789012.database.windows.net,3342;initial catalog=TestDB;"))
            {
                ServicePrincipalId = "fakeSPID",
                ServicePrincipalKey = new DataFactorySecretString("fakeSPKey"),
                Tenant = "fakeTenant",
                AzureCloudType = "AzurePublic"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDW()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerName.database.windows.net;Database=myDatabaseName;User ID=myUsername@myServerName;Password=myPassword;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                AzureCloudType = "AzurePublic"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSqlDW_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDWLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey")));
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMLService()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMLServiceLinkedService("1e42591f-0000-0000-0000-a268f6105ec5", "MyResourceGroupName", "MyMLWorkspaceName")
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML_updateResourceEndpoint()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey"))
            {
                UpdateResourceEndpoint = "https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureML_servicePrincipalId()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMLLinkedService("https://ussouthcentral.services.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/jobs", new DataFactorySecretString("fakeKey"))
            {
                UpdateResourceEndpoint = "https://management.azureml.net/workspaces/7851b44b5a5e4799997fad223c449acb/services/14d8b9f6b9b64b51a8dcd1117fcdc624/endpoints/endpoint2",
                ServicePrincipalId = "fe273844-c808-40b8-ad85-94a46f737731",
                ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                Tenant = "microsoft.com"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.IsNotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataLakeAnalytics()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDataLakeAnalyticsLinkedService("fake", "fake")
            {
                ServicePrincipalId = "fe273844-c808-40b8-ad85-94a46f737731",
                ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                DataLakeAnalyticsUri = "fake.com",
                SubscriptionId = "fe273844-c808-40b8-ad85-94a46f737731"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsight()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceAzureBlobName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceAzureBlobName);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://MyCluster.azurehdinsight.net/")
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsight_hcatalogLinkedServiceName()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceLogName1 = Recording.GenerateAssetName("LinkedService");
            string linkedServiceLogName2 = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            await CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceLogName1);
            await CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceLogName2);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://MyCluster.azurehdinsight.net/")
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword"),
                LinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceLogName1),
                HcatalogLinkedServiceName = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceLogName2)
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HDInsightOnDemand()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceHDInsightName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            DataFactoryLinkedServiceData lkHDInsight = new DataFactoryLinkedServiceData(new HDInsightLinkedService("https://test.azurehdinsight.net"));
            await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceHDInsightName, lkHDInsight);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HDInsightOnDemandLinkedService("4", "01:30:00", "3.5", new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceHDInsightName), "hostSubscriptionId", "72f988bf-86f1-41af-91ab-2d7cd011db47", "ADF")
            {
                ServicePrincipalId = "servicePrincipalId",
                ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
                ClusterNamePrefix = "OnDemandHdiResource",
                HeadNodeSize = BinaryData.FromString("\"HeadNode\""),
                DataNodeSize = BinaryData.FromString("\"DataNode\""),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureBatch()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceAzureBlobName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureBlobStorageLinkedService(dataFactory, linkedServiceAzureBlobName);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureBatchLinkedService(DataFactoryElement<string>.FromSecretString("parameters"), "myaccount.region.batch.windows.com", "myPoolname", new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceAzureBlobName))
            {
                AccessKey = new DataFactorySecretString("fakeAccesskey")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SqlServer_encryptedCredential()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SqlServerLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Database=myDataBase;Uid=myUsername;"))
            {
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Oracle()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new OracleLinkedService(DataFactoryElement<string>.FromSecretString("Data Source = MyOracleDB; User Id = myUsername; Password = myPassword; Integrated Security = no;"))
            {
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Oracle_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new OracleLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForOracle()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromSecretString("Host=10.10.10.10;Port=1234;Sid=fakeSid;User Id=fakeUsername;Password=fakePassword"))
            {
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRdsForOracle_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonRdsForOracleLinkedService(DataFactoryElement<string>.FromSecretString("fakeConnString"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_FileServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new FileServerLinkedService(DataFactoryElement<string>.FromSecretString("Myhost"))
            {
                UserId = "MyUserId",
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"),
                EncryptedCredential = "MyEncryptedCredentials"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("mongodb://username:password@localhost:27017/?authSource=admin")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_accountEndpoint()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
            {
                AccountEndpoint = "https://fakecosmosdb.documents.azure.com:443/",
                Database = "testdb",
                AccountKey = new DataFactorySecretString("fakeconnectstring")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
            {
                ConnectionString = "fakeConnString",
                AccountKey = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDb_servicePrincipalId()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CosmosDBLinkedService()
            {
                ConnectionString = "mongodb://username:password@localhost:27017/?authSource=admin",
                ServicePrincipalId = "fakeservicePrincipalId",
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalCredential = new DataFactorySecretString("fakeservicePrincipalCredential"),
                Tenant = "faketenant",
                AzureCloudType = "fakeazurecloudtype",
                ConnectionMode = new CosmosDBConnectionMode()
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Teradata()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new TeradataLinkedService()
            {
                Server = "volvo2.teradata.ws",
                Username = "microsoft",
                AuthenticationType = TeradataAuthenticationType.Basic,
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Teradata_connectionString()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new TeradataLinkedService()
            {
                ConnectionString = "connectstring",
                Username = "microsoft",
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_ODBC()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new OdbcLinkedService(DataFactoryElement<string>.FromSecretString("Driver={ODBC Driver 17 for SQL Server};Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"))
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword"),
                Credential = new DataFactorySecretString("fakeCredential"),
                AuthenticationType = "Basic",
                EncryptedCredential = "MyEncryptedCredentials",
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Informix()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new InformixLinkedService(DataFactoryElement<string>.FromSecretString("Database=TestDB;Host=192.168.10.10;Server=db_engine_tcp;Service=1492;Protocol=onsoctcp;UID=fakeUsername;Password=fakePassword;"))
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword"),
                Credential = new DataFactorySecretString("fakeCredential"),
                AuthenticationType = "Basic",
                EncryptedCredential = "MyEncryptedCredentials",
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MicrosoftAccess()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MicrosoftAccessLinkedService(DataFactoryElement<string>.FromSecretString("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\myFolder\\myAccessFile.accdb;Persist Security Info=False;\r\n"))
            {
                UserName = "MyUserName",
                Password = new DataFactorySecretString("fakepassword"),
                Credential = new DataFactorySecretString("fakeCredential"),
                AuthenticationType = "Basic",
                EncryptedCredential = "MyEncryptedCredentials",
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hdfs()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HdfsLinkedService("http://myhost:50070/webhdfs/v1")
            {
                UserName = "Microsoft",
                Password = new DataFactorySecretString("fakepassword"),
                AuthenticationType = "Basic",
                EncryptedCredential = "MyEncryptedCredentials",
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Web()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties)
            {
                LinkedServiceType = "Web",
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Web1()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            WebLinkedServiceTypeProperties webLinkedServiceTypeProperties = new UnknownWebLinkedServiceTypeProperties("http://localhost", WebAuthenticationType.ClientCertificate);
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new WebLinkedService(webLinkedServiceTypeProperties)
            {
                LinkedServiceType = "Web",
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Cassandra()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CassandraLinkedService("http://localhost/webhdfs/v1/")
            {
                Description = "test description",
                AuthenticationType = "Basic",
                Port = 1234,
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "fake credential"
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "Office365")
            {
                Username = "admin",
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_S2S_Key()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "AadServicePrincipal")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_S2S_Cert()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "AadServicePrincipal")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Dynamics_organizationName()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsLinkedService("Online", "Office365")
            {
                HostName = "hostname.com",
                Port = 1234,
                OrganizationName = "contoso",
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "fake credential"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
            {
                HostName = "hostname.com",
                Port = 1234,
                OrganizationName = "contoso",
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "fake credential"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm_S2S_Key()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_DynamicsCrm_S2S_Cert()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DynamicsCrmLinkedService("Online", "Office365")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps_S2S_Key()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "AadServicePrincipal")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactorySecretString("fakepassword")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps_S2S_Cert()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "AadServicePrincipal")
            {
                ServicePrincipalCredentialType = "ServicePrincipalKey",
                ServicePrincipalId = "9bf5d9fd - 5dcd - 46a5 - b99b - 77d69adb2567",
                ServicePrincipalCredential = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName")
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CommonDataServiceForApps()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CommonDataServiceForAppsLinkedService("Online", "Office365")
            {
                HostName = "hostname.com",
                Port = 1234,
                OrganizationName = "contoso",
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
                EncryptedCredential = "fake credential"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce_Token()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                SecurityToken = new DataFactorySecretString("fakeToken"),
                ApiVersion = "27.0"
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                ApiVersion = "27.0"
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Salesforce_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                SecurityToken = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName2"),
                ApiVersion = "27.0"
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceServiceCloud_Token()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                SecurityToken = new DataFactorySecretString("faketoken"),
                ApiVersion = "27.0"
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceServiceCloud()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceServiceCloudLinkedService()
            {
                EnvironmentUri = "Uri",
                Username = "admin",
                Password = new DataFactorySecretString("fakepassword"),
                ApiVersion = "27.0"
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceMarketingCloud()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceMarketingCloudLinkedService()
            {
                ClientId = "clientid",
                ClientSecret = new DataFactorySecretString("fakepassword")
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SalesforceMarketingCloud_connection()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SalesforceMarketingCloudLinkedService()
            {
                ClientId = "fakeClientId",
                ClientSecret = new DataFactorySecretString("fakeClientSecret")
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MongoDb()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MongoDBLinkedService("fakeserver.com", "fakedb")
            {
                AuthenticationType = "Basic",
                Port = 1234,
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
                AuthSource = "fackadmindb",
                EncryptedCredential = "fake credential"
            })
            {
                Properties = {
                    Description = "test description",
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonRedshift()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonRedshiftLinkedService("fakeserver.com", "fakedb")
            {
                Port = 1234,
                Username = "fakeuser@contoso.com",
                Password = new DataFactorySecretString("fakepassword"),
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
            {
                AccessKeyId = "fakeaccess",
                SecretAccessKey = new DataFactorySecretString("fakekey")
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3_sessionToken()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonS3LinkedService()
            {
                AuthenticationType = "TemporarySecurityCredentials",
                AccessKeyId = "fakeaccess",
                SecretAccessKey = new DataFactorySecretString("fakekey"),
                SessionToken = new DataFactorySecretString("fakesessiontoken")
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonS3Compatible()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonS3CompatibleLinkedService()
            {
                AccessKeyId = "fakeaccess",
                SecretAccessKey = new DataFactorySecretString("fakekey"),
                ServiceUri = "fakeserviceurl",
                ForcePathStyle = true
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataLakeStore()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDataLakeStoreLinkedService("fakeUrl")
            {
                ServicePrincipalId = "fakeid",
                ServicePrincipalKey = new DataFactorySecretString("fakeKey"),
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureSearch()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSearchLinkedService("fakeUrl")
            {
                Key = new DataFactorySecretString("fakeKey"),
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_FtpServer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new FtpServerLinkedService("fakeHost")
            {
                AuthenticationType = FtpAuthenticationType.Basic,
                UserName = "fakeName",
                Password = new DataFactorySecretString("fakePassword")
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Sftp()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SftpServerLinkedService("fakeHost")
            {
                AuthenticationType = SftpAuthenticationType.Basic,
                UserName = "fakeName",
                Password = new DataFactorySecretString("fakePassword"),
                PrivateKeyPath = "fakeprivateKeyPath",
                PrivateKeyContent = new DataFactorySecretString("fakeprivateKeyContent")
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapBW()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SapBWLinkedService("fakeServer", "fakeNumber", "fakeId")
            {
                UserName = "fakeName",
                Password = new DataFactorySecretString("fakePassword"),
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapHana()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SapHanaLinkedService()
            {
                Server = "fakeserver",
                AuthenticationType = SapHanaAuthenticationType.Basic,
                UserName = "fakeName",
                Password = new DataFactorySecretString("fakePassword"),
            })
            {
                Properties = {
                    Description = "test description"
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMySql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress.mysql.database.azure.com;Port=3306;Database=myDataBase;Uid=myUsername@myServerAddress;Pwd=myPassword;SslMode=Required;")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMySql_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMySqlLinkedService(DataFactoryElement<string>.FromSecretString("fakestring"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AmazonMWS()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AmazonMwsLinkedService("mws,amazonservices.com", "A2EUQ1WTGCTBG2", "ACGMZIK6QTD9T", "128393242334")
            {
                MwsAuthToken = new DataFactorySecretString("fakeMwsAuthToken"),
                SecretKey = new DataFactorySecretString("fakeSecretKey"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzurePostgreSql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromKeyVaultSecretReference(new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"))
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzurePostgreSql_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzurePostgreSqlLinkedService()
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
                ConnectionString = DataFactoryElement<string>.FromKeyVaultSecretReference(new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName"))
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Concur()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ConcurLinkedService("f145kn9Pcyq9pr4lvumdapfl4rive", "jsmith")
            {
                Password = new DataFactorySecretString("somesecret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Couchbase()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Couchbase_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CouchbaseLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                CredString = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Drill()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DrillLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Drill_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DrillLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Eloqua()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new EloquaLinkedService("eloqua.example.com", "username")
            {
                Password = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleAdWords()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GoogleAdWordsLinkedService()
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Greenplum()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GreenplumLinkedService()
            {
                ConnectionString = "SecureString"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Greenplum_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GreenplumLinkedService()
            {
                ConnectionString = "SecureString",
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_HBase()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HBaseLinkedService("192.168.12.122", HBaseAuthenticationType.Anonymous)
            {
                HttpPath = "/gateway/sandbox/hbase/version",
                EnableSsl = true,
                AllowHostNameCNMismatch = true,
                AllowSelfSignedServerCert = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hive()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HiveLinkedService("192.168.12.122", HiveAuthenticationType.Anonymous)
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Hubspot()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new HubspotLinkedService("11b5516f1322-11e6-9653-93a39db85acf")
            {
                ClientSecret = new DataFactorySecretString("abCD+E1f2Gxhi3J4klmN/OP5QrSTuvwXYzabcdEF"),
                AccessToken = new DataFactorySecretString("some secret"),
                RefreshToken = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Impala()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ImpalaLinkedService("192.168.12.122", ImpalaAuthenticationType.Anonymous)
            {
                Username = "",
                Password = new DataFactorySecretString("some secret"),
                EnableSsl = true,
                TrustedCertPath = "",
                UseSystemTrustStore = true,
                AllowHostNameCNMismatch = true,
                AllowSelfSignedServerCert = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Jira()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new JiraLinkedService("192.168.12.122", "skroob")
            {
                Port = 1000,
                Password = new DataFactorySecretString("some secret"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Magento()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MagentoLinkedService("192.168.12.122")
            {
                AccessToken = new DataFactorySecretString("some secret"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Mariadb()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("Server=mydemoserver.mariadb.database.azure.com; Port=3306; Database=wpdb; Uid=WPAdmin@mydemoserver; Pwd=mypassword!2; SslMode=Required;\r\n")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MongoDbAtlas()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MongoDBAtlasLinkedService(DataFactoryElement<string>.FromSecretString("mongodb://username:password@localhost:27017/?authSource=admin"), "database") { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureMariadb()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureMariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("Server=mydemoserver.mariadb.database.azure.com; Port=3306; Database=wpdb; Uid=fakeUsername; Pwd=fakePassword; SslMode=Required;")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Mariadb_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MariaDBLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connnection secret"),
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Marketo()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MarketoLinkedService("123-ABC-321.mktorest.com", "fakeClientId")
            {
                ClientSecret = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Paypal()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MarketoLinkedService("api.sandbox.paypal.com", "fakeClientId")
            {
                ClientSecret = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Phoenix()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new PhoenixLinkedService("192.168.222.160", PhoenixAuthenticationType.Anonymous)
            {
                Port = 443,
                HttpPath = "/gateway/sandbox/phoenix/version",
                EnableSsl = true,
                UseSystemTrustStore = true,
                AllowHostNameCNMismatch = true,
                AllowSelfSignedServerCert = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Presto()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new PrestoLinkedService("192.168.222.160", "0.148-t", "test", PrestoAuthenticationType.Anonymous)
            {
                Username = "test",
                Password = new DataFactorySecretString("some secret"),
                EnableSsl = true,
                TrustedCertPath = "",
                UseSystemTrustStore = true,
                AllowHostNameCNMismatch = true,
                AllowSelfSignedServerCert = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_QuickBooks()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new QuickBooksLinkedService()
            {
                Endpoint = "quickbooks.api.intuit.com",
                CompanyId = "fakeCompanyId",
                ConsumerKey = "fakeConsumerKey",
                ConsumerSecret = new DataFactorySecretString("some secret"),
                AccessToken = new DataFactorySecretString("some secret"),
                AccessTokenSecret = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_ServiceNow()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ServiceNowLinkedService("http://instance.service-now.com", ServiceNowAuthenticationType.Basic)
            {
                Username = "admin",
                Password = new DataFactorySecretString("some secret")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Shopify()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ShopifyLinkedService("mystore.myshopify.com")
            {
                AccessToken = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Spark()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SparkLinkedService("myserver", 443, SparkAuthenticationType.WindowsAzureHDInsightService)
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Square()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SquareLinkedService()
            {
                Host = "mystore.mysquare.com",
                ClientId = "clientIdFake",
                ClientSecret = new DataFactorySecretString("some secret"),
                RedirectUri = "http://localhost:2500",
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Square_ConnectionProperties()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SquareLinkedService()
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Xero()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new XeroLinkedService()
            {
                Host = "api.xero.com",
                ConsumerKey = new DataFactorySecretString("some secret"),
                PrivateKey = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Xero_ConnectionProperties()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new XeroLinkedService()
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zoho()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ZohoLinkedService()
            {
                Endpoint = "crm.zoho.com/crm/private",
                AccessToken = new DataFactorySecretString("some secret"),
                UseEncryptedEndpoints = true,
                UseHostVerification = true,
                UsePeerVerification = true
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zoho_ConnectionProperties()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ZohoLinkedService()
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleAdWords_ConnectionProperties()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GoogleAdWordsLinkedService()
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Netezza()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new NetezzaLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Vertica()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new VerticaLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Vertica_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new VerticaLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("some connection string"),
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
            {
                AccessToken = new DataFactorySecretString("some secret"),
                ExistingClusterId = "1215-091927-stems91",
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]

        public async Task LinkedService_AzureDatabricks_Script()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
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
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks_workspaceResourceId()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
            {
                Authentication = "MSI",
                WorkspaceResourceId = "/subscriptions/1e42591f-1f0c-4c5a-b7f2-a268f6105ec5/resourceGroups/keshADF_test/providers/Microsoft.Databricks/workspaces/keshPremDB",
                NewClusterVersion = "3.4.x-scala2.11",
                NewClusterNumOfWorker = "1",
                NewClusterNodeType = "Standard_DS3_v2",
                NewClusterDriverNodeType = "Standard_DS3_v2",
                PolicyId = "DS2K4A1WIEIQDX",
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDatabricks_newClusterSparkEnvVars()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDatabricksLinkedService("https://westeurope.azuredatabricks.net/")
            {
                AccessToken = new DataFactorySecretString("some secret"),
                NewClusterVersion = "3.4.x-scala2.11",
                NewClusterNumOfWorker = "1",
                NewClusterNodeType = "Standard_DS3_v2"
                //Error
                //NewClusterSparkConf = ,
                //NewClusterSparkEnvVars = ,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Db2_Connection()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string integrationRuntimeName = Recording.GenerateAssetName("integrationRuntime");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new Db2LinkedService()
            {
                ConnectionString = "Server=<server>;Database=<database>;AuthenticationType=Basic;UserName=<username>;PackageCollection=<packageCollection>;CertificateCommonName=<certificateCommonName>",
            })
            {
                Properties = {
                    ConnectVia = new IntegrationRuntimeReference(IntegrationRuntimeReferenceType.IntegrationRuntimeReference,integrationRuntimeName)
                }
            };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapOpenHub_MessageServerService()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SapOpenHubLinkedService()
            {
                MessageServer = "fakeserver",
                MessageServerService = "00",
                SystemId = "ecc",
                LogonGroup = "fakegroup",
                ClientId = "800",
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_RestService()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new RestServiceLinkedService("https://fakeurl/", RestServiceAuthenticationType.Basic)
            {
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
                AzureCloudType = "azurepublic"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SapTable()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SapTableLinkedService()
            {
                Server = "fakeserver",
                SystemNumber = "00",
                ClientId = "000",
                UserName = "user",
                Password = new DataFactorySecretString("fakepwd"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureDataExplorer()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureDataExplorerLinkedService("https://fakecluster.eastus2.kusto.windows.net", "MyDatabase")
            {
                ServicePrincipalId = "fakeSPID",
                ServicePrincipalKey = new DataFactorySecretString("fakepwd"),
                Tenant = "faketenant"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                Host = "fakehost",
                UserId = "fakeaccess",
                Password = new DataFactorySecretString("fakepwd"),
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_ConnectionString()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("DefaultEndpointsProtocol=https;AccountName=testaccount;EndpointSuffix=core.windows.net;")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_FileShare()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("\"server=10.0.0.122;port=3306;database=db;user=https:\\\\\\\\test.com;sslmode=1;usesystemtruststore=0\""),
                FileShare = "myFileshareName",
                Snapshot = "2020-06-18T02:35.43"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_AccountKey()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString("fakeconnection"),
                AccountKey = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_SasUri()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                SasUri = DataFactoryElement<string>.FromSecretString("fakeconnection"),
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_AzureFileStorage_SasToken()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureFileStorageLinkedService()
            {
                SasUri = DataFactoryElement<string>.FromSecretString("fakeconnection"),
                SasToken = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleCloudStorage()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GoogleCloudStorageLinkedService()
            {
                AccessKeyId = "Fakeaccess",
                SecretAccessKey = new DataFactorySecretString("fakekey")
            })
            { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_SharePointOnlineList()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SharePointOnlineListLinkedService("http://localhost/webhdfs/v1/", "tenantId", "servicePrincipalId", new DataFactorySecretString("ServicePrincipalKey")) { }) { Properties = { Description = "test description" } };
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_CosmosDbMongoDbApi()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new CosmosDBMongoDBApiLinkedService(DataFactoryElement<string>.FromSecretString("mongodb+srv://myDatabaseUser:@server.example.com"), "TestDB")
            {
                IsServerVersionAbove32 = true,
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_TeamDesk()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new TeamDeskLinkedService(TeamDeskAuthenticationType.Basic, "testUrl")
            {
                UserName = "username",
                Password = new DataFactorySecretString("fakePassword")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Quickbase()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new QuickbaseLinkedService("testUrl", new DataFactorySecretString("FakeuerToken")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Smartsheet()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new SmartsheetLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_Zendesk()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new ZendeskLinkedService(ZendeskAuthenticationType.Token, "testUri")
            {
                ApiToken = new DataFactorySecretString("FakeApiToeken")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }
        [Test]
        [RecordedTest]
        public async Task LinkedService_Dataworld()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new DataworldLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_RestService_CertificateValidation()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new RestServiceLinkedService("testUri", RestServiceAuthenticationType.OAuth2ClientCredential)
            {
                EnableServerCertificateValidation = true,
                ClientId = "FakeclientID",
                ClientSecret = new DataFactorySecretString("somesecret"),
                TokenEndpoint = "fakeTokenEndpoint",
                Resource = "fakeResource",
                Scope = "FakeScope"
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_GoogleSheets()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new GoogleSheetsLinkedService(new DataFactorySecretString("FakeapiToken")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_MySql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new MySqlLinkedService(DataFactoryElement<string>.FromSecretString("Fakeconnstring"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_PostgreSql()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            var linkedService = dataFactory.GetDataFactoryLinkedServices();

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new PostgreSqlLinkedService(DataFactoryElement<string>.FromSecretString("Server=myServerAddress;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;\r\n")) { });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }

        [Test]
        [RecordedTest]
        public async Task LinkedService_PostgreSql_AzureKeyValue()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string linkedServiceName = Recording.GenerateAssetName("LinkedService");

            string linkedServiceKeyVaultName = Recording.GenerateAssetName("LinkedService");
            var linkedService = dataFactory.GetDataFactoryLinkedServices();
            await CreateDefaultAzureKeyVaultLinkedService(dataFactory, linkedServiceKeyVaultName);

            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new PostgreSqlLinkedService(DataFactoryElement<string>.FromSecretString("Fakeconnstring"))
            {
                Password = new DataFactoryKeyVaultSecretReference(new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference, linkedServiceKeyVaultName), "fakeSecretName1")
            });
            var result = await linkedService.CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            Assert.NotNull(result.Value.Id);
        }
    }
}

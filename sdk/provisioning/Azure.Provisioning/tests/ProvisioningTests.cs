// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Provisioning.ResourceManager;
using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.Sql;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.AppConfiguration;
using Azure.Provisioning.ApplicationInsights;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.CognitiveServices;
using Azure.Provisioning.CosmosDB;
using Azure.Provisioning.EventHubs;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.PostgreSql;
using Azure.Provisioning.Redis;
using Azure.Provisioning.Search;
using Azure.Provisioning.ServiceBus;
using Azure.Provisioning.SignalR;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Search.Models;
using Azure.ResourceManager.SignalR.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using CoreTestEnvironment = Azure.Core.TestFramework.TestEnvironment;
using UserAssignedIdentity = Azure.Provisioning.ManagedServiceIdentities.UserAssignedIdentity;

namespace Azure.Provisioning.Tests
{
    [AsyncOnly]
    public class ProvisioningTests : ManagementRecordedTestBase<ProvisioningTestEnvironment>
    {
        public ProvisioningTests(bool async) : base(async)
        {
        }

        private static readonly string _infrastructureRoot = Path.Combine(GetGitRoot(), "sdk", "provisioning", "Azure.Provisioning", "tests", "Infrastructure");

        [RecordedTest]
        public async Task ResourceGroupOnly()
        {
            TestInfrastructure infrastructure = new TestInfrastructure();
            var resourceGroup = infrastructure.AddResourceGroup();
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task SqlServerUsingAdminPassword()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administratorLogin: new Parameter("adminLogin", "SQL Server administrator login"),
                administratorPassword: new Parameter("adminPassword", "SQL Server administrator password", isSecure: true));
            _ = new SqlDatabase(infrastructure, sqlServer);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "admin" },
                        adminPassword = new { value = "password" }
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task SqlServerUsingIdentity()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });

            var admin = new SqlServerAdministrator(
                new Parameter("adminLogin", "SQL Server administrator login"),
                new Parameter("adminObjectId", "SQL Server administrator Object ID"));

            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administrator: admin);

            _ = new SqlDatabase(infrastructure, sqlServer);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "admin" },
                        adminObjectId = new { value = Guid.Empty.ToString() }
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task SqlServerUsingHybrid()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });

            var admin = new SqlServerAdministrator(
                new Parameter("adminIdentityLogin", "SQL Server administrator login"),
                new Parameter("adminObjectId", "SQL Server administrator Object ID"));

            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administratorLogin: new Parameter("adminLogin", "SQL Server administrator login"),
                administratorPassword: new Parameter("adminPassword", "SQL Server administrator password", isSecure: true),
                administrator: admin);

            _ = new SqlDatabase(infrastructure, sqlServer);
            _ = new SqlFirewallRule(infrastructure, sqlServer);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "admin" },
                        adminPassword = new { value = "password" },
                        adminIdentityLogin = new { value = "admin" },
                        adminObjectId = new { value = Guid.Empty.ToString() }
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public void SqlServerDatabaseThrowsWithoutParent()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            Assert.Throws<InvalidOperationException>(() => new SqlDatabase(infrastructure));
        }

        [RecordedTest]
        public async Task RedisCache()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var cache = new RedisCache(infrastructure);
            _ = infrastructure.AddKeyVault();
            _ = new KeyVaultSecret(infrastructure, name: "connectionString", connectionString: cache.GetConnectionString());

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task RedisCacheSecondaryConnectionString()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var cache = new RedisCache(infrastructure);
            _ = infrastructure.AddKeyVault();
            _ = new KeyVaultSecret(infrastructure, "connectionString", cache.GetConnectionString(useSecondary: true));

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task RedisCacheWithExistingKeyVault()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var cache = new RedisCache(infrastructure);
            var kv = KeyVault.FromExisting(infrastructure, name: "'existingVault'");
            kv.AddOutput("vaultUri", data => data.Properties.VaultUri);

            // can't mutate existing resource
            Assert.Throws<InvalidOperationException>(() => kv.Properties.Tags.Add("key", "value"));
            // can't mutate existing resource
            Assert.Throws<InvalidOperationException>(() => kv.AssignProperty(data => data.Properties.EnableSoftDelete, "true"));

            _ = new KeyVaultSecret(infrastructure, "primaryConnectionString", cache.GetConnectionString(), kv);
            _ = new KeyVaultSecret(infrastructure, "secondaryConnectionString", cache.GetConnectionString(useSecondary: true), kv);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task PostgreSql()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var adminLogin = new Parameter("adminLogin", "Administrator login");
            var adminPassword = new Parameter("adminPassword", "Administrator password", isSecure: true);
            var server = new PostgreSqlFlexibleServer(
                infrastructure,
                administratorLogin: adminLogin,
                administratorPassword: adminPassword,
                highAvailability: new PostgreSqlFlexibleServerHighAvailability { Mode = "haMode" },
                backup: new PostgreSqlFlexibleServerBackupProperties
                {
                    BackupRetentionDays = 7,
                    GeoRedundantBackup = PostgreSqlFlexibleServerGeoRedundantBackupEnum.Disabled
                });
            server.AssignProperty(data => data.Sku.Name, new Parameter("dbInstanceType"));
            server.AssignProperty(data => data.Sku.Tier, new Parameter("serverEdition"));
            var kv = infrastructure.AddKeyVault();
            // verify we can assign a property that is already assigned automatically by the CDK
            var p = new Parameter("p", defaultValue: "name");
            kv.AssignProperty(x=> x.Name, p);

            _ = new PostgreSqlFlexibleServerDatabase(infrastructure, server);
            _ = new PostgreSqlFirewallRule(infrastructure, parent: server, startIpAddress: "0.0.0.0", endIpAddress: "255.255.255.255");

            _ = new KeyVaultSecret(infrastructure, "connectionString", server.GetConnectionString(adminLogin, adminPassword));

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "password" },
                        adminPassword = new { value = "password" },
                        dbInstanceType = new { value = "Standard_B1ms" },
                        serverEdition = new { value = "Burstable" }
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public void PostgreSqlDatabaseThrowsWithoutParent()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            Assert.Throws<InvalidOperationException>(() => new PostgreSqlFlexibleServerDatabase(infrastructure));
        }

        [RecordedTest]
        public async Task CosmosDB()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            infrastructure.AddParameter(new Parameter("keyVaultName"));
            var account = new CosmosDBAccount(
                infrastructure,
                accountLocations: new CosmosDBAccountLocation[]
                {
                    new CosmosDBAccountLocation
                    {
                        FailoverPriority = 0
                    }
                });
            account.AssignProperty(data => data.Locations[0].LocationName, "location");
            _ = new CosmosDBSqlDatabase(infrastructure, account);
            var kv = KeyVault.FromExisting(infrastructure, name: "keyVaultName");
            _ = new KeyVaultSecret(infrastructure, "connectionString", account.GetConnectionString(), kv);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                BinaryData.FromObjectAsJson(
                    new
                    {
                        keyVaultName = new { value = "vault" },
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public void CognitiveServices()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new CognitiveServicesAccount(infrastructure, location: AzureLocation.EastUS);
            account.AssignProperty(data => data.Properties.PublicNetworkAccess, new Parameter("publicNetworkAccess", defaultValue: "Enabled"));
            account.AddOutput("endpoint", "'Endpoint=${{{0}}}'", data => data.Properties.Endpoint);
            account.AddOutput("expression", "uniqueString({0})", data => data.Properties.Endpoint);
            _ = new CognitiveServicesAccountDeployment(
                infrastructure,
                new CognitiveServicesAccountDeploymentModel
                {
                    Name = "text-embedding-3-large",
                    Format = "OpenAI",
                    Version = "1"
                },
                account);

            infrastructure.Build(GetOutputPath());

            // couldn't fine a deployable combination of sku and model using test subscription
            // await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task ServiceBus()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new ServiceBusNamespace(infrastructure);
            _ = new ServiceBusQueue(infrastructure, parent: account);
            var topic = new ServiceBusTopic(infrastructure, parent: account);
            _ = new ServiceBusSubscription(infrastructure, parent: topic);
            account.AssignRole(RoleDefinition.ServiceBusDataOwner, Guid.Empty);
            account.AddOutput("endpoint", "'Endpoint=${{{0}}}'", data => data.ServiceBusEndpoint);
            account.AddOutput("expression", "uniqueString({0})", data => data.ServiceBusEndpoint);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task EventHubs()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var account = new EventHubsNamespace(infrastructure);
            var hub = new EventHub(infrastructure, parent: account);
            var consumerGroup = new EventHubsConsumerGroup(infrastructure, parent: hub);
            account.AssignRole(RoleDefinition.EventHubsDataOwner, Guid.Empty);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task Search()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var search = new SearchService(infrastructure, sku: SearchSkuName.Standard);
            search.AssignRole(RoleDefinition.SearchServiceContributor, Guid.Empty);
            search.AssignRole(RoleDefinition.SearchIndexDataContributor, Guid.Empty);
            search.AssignProperty(data => data.ReplicaCount, "1");
            search.AssignProperty(data => data.PartitionCount, "1");
            search.AssignProperty(data => data.HostingMode, "'default'");
            search.AssignProperty(data => data.IsLocalAuthDisabled, "true");

            search.AddOutput("connectionString", "'Endpoint=https://${{{0}}}.search.windows.net'", data => data.Name);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task SignalR()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var signalR = new SignalRService(infrastructure, sku: new SignalRResourceSku("Standard_S1"), serviceMode: "Serverless");
            signalR.AssignRole(RoleDefinition.SignalRAppServer, Guid.Empty);

            signalR.AddOutput("hostName", data => data.HostName);
            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task AppInsights()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var workspace = new OperationalInsightsWorkspace(infrastructure);
            var output = workspace.AddOutput("workspaceId", data => data.Id);

            var appInsights = new ApplicationInsightsComponent(infrastructure);
            appInsights.AssignProperty(data => data.WorkspaceResourceId, new Parameter(output));

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task UserAssignedIdentities()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            _ = new UserAssignedIdentity(infrastructure);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task StorageBlobDefaults()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task RoleAssignmentWithParameter()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(new { principalId = new { value = Guid.Empty }}), interactiveMode: true);
        }

        [RecordedTest]
        public async Task RoleAssignmentWithoutParameter()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task RoleAssignmentWithoutParameterInteractiveMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageQueueDataContributor, Guid.Empty);
            storageAccount.AssignRole(RoleDefinition.StorageTableDataContributor, Guid.Empty, RoleManagementPrincipalType.User);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public void RoleAssignmentPrincipalMustBeSuppliedInNonInteractiveMode()
        {
            var infra = new TestInfrastructure();
            var storageAccount = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();

            Assert.Throws<InvalidOperationException>(() => storageAccount.AssignRole(RoleDefinition.StorageBlobDataContributor));
        }

        [RecordedTest]
        public async Task StorageBlobDefaultsInPromptMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        [RecordedTest]
        public async Task CanAddCustomLocationParameterInInteractiveMode()
        {
            var infra = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var sa = infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            sa.AssignProperty(d => d.Location, new Parameter("myLocationParam"));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    myLocationParam = new { value = "eastus" },
                }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task CanAssignParameterToMultipleResources()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var overrideLocation = new Parameter("overrideLocation");

            var account1 = infra.AddStorageAccount(
                name: "sa1",
                kind: StorageKind.BlobStorage,
                sku: StorageSkuName.StandardLrs
            );
            account1.AssignProperty(a => a.Location, overrideLocation);

            var account2 = infra.AddStorageAccount(
                name: "sa2",
                kind: StorageKind.BlobStorage,
                sku: StorageSkuName.PremiumLrs
            );
            account2.AssignProperty(a => a.Location, overrideLocation);

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    overrideLocation = new { value = "eastus" },
                }));
        }

        [RecordedTest]
        public async Task StorageBlobDropDown()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var blob = infra.AddBlobService();
            blob.Properties.DeleteRetentionPolicy = new DeleteRetentionPolicy()
            {
                IsEnabled = true
            };
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task AppConfiguration()
        {
            var infra = new TestInfrastructure();
            var appConfig = new AppConfigurationStore(infra, "standard");
            appConfig.AssignRole(RoleDefinition.AppConfigurationDataOwner, Guid.Empty);
            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public void MultipleSubscriptions()
        {
            // ensure deterministic subscription names and directories
            var random = new TestRandom(RecordedTestMode.Playback, 1);
            var infra = new TestSubscriptionInfrastructure();
            var sub1 = new Subscription(infra, random.NewGuid());
            var sub2 = new Subscription(infra, random.NewGuid());
            _ = new ResourceGroup(infra, parent: sub1);
            _ = new ResourceGroup(infra, parent: sub2);
            infra.Build(GetOutputPath());

            // Multiple subscriptions are not fully supported yet. https://github.com/Azure/azure-sdk-for-net/issues/42146
            // await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task OutputsSpanningModules()
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");
            var rg2 = new ResourceGroup(infra, "rg2");
            var rg3 = new ResourceGroup(infra, "rg3");
            var storageAccount1 = infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg1);

            var output1 = storageAccount1.AddOutput("STORAGE_KIND", data => data.Kind);

            KeyVault keyVault = infra.AddKeyVault(resourceGroup: rg1);
            keyVault.AssignProperty(data => data.Properties.EnableSoftDelete, new Parameter("enableSoftDelete", "Enable soft delete", defaultValue: true, isSecure: false));

            var storageAccount2 = infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg2);

            storageAccount2.AssignProperty(data => data.Kind, new Parameter(output1));

            infra.AddStorageAccount(kind: StorageKind.Storage, sku: StorageSkuName.StandardGrs, parent: rg3);
            infra.Build(GetOutputPath());

            Assert.AreEqual(2, infra.GetParameters().Count());
            Assert.AreEqual(1, infra.GetOutputs().Count());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task ExistingResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            infra.AddParameter(new Parameter("existingAppConfig"));
            infra.AddResource(AppConfigurationStore.FromExisting(infra, "existingAppConfig", rg));
            var kv = KeyVault.FromExisting(infra, "'existingVault'", rg);
            infra.AddResource(kv);
            var sa = StorageAccount.FromExisting(infra, "'existingStorage'", rg);
            infra.AddResource(sa);

            infra.AddResource(KeyVaultSecret.FromExisting(infra, "'existingSecret'", kv));
            infra.AddResource(PostgreSqlFlexibleServer.FromExisting(infra, "'existingPostgreSql'", rg));
            var sql = SqlServer.FromExisting(infra, "'existingSqlServer'", rg);
            infra.AddResource(sql);
            infra.AddResource(Redis.RedisCache.FromExisting(infra, "'existingRedis'", rg));
            var cosmosDB = CosmosDBAccount.FromExisting(infra, "'cosmosDb'", rg);
            infra.AddResource(cosmosDB);
            infra.AddResource(CosmosDBSqlDatabase.FromExisting(infra, "'cosmosDb'", cosmosDB));
            infra.AddResource(DeploymentScript.FromExisting(infra, "'existingDeploymentScript'", rg));
            infra.AddParameter(new Parameter("existingSqlDatabase"));
            infra.AddResource(SqlDatabase.FromExisting(infra, "existingSqlDatabase", sql));
            infra.AddResource(SqlFirewallRule.FromExisting(infra, "'existingSqlFirewallRule'", sql));
            infra.AddResource(BlobService.FromExisting(infra, "'existingBlobService'", sa));

            var sb = ServiceBusNamespace.FromExisting(infra, "'existingSbNamespace'", rg);
            infra.AddResource(ServiceBusQueue.FromExisting(infra, "'existingSbQueue'", sb));
            var topic = ServiceBusTopic.FromExisting(infra, "'existingSbTopic'", sb);
            infra.AddResource(topic);
            infra.AddResource(ServiceBusSubscription.FromExisting(infra, "'existingSbSubscription'", topic));

            infra.AddResource(SearchService.FromExisting(infra, "'existingSearch'", rg));

            var eh = EventHubsNamespace.FromExisting(infra, "'existingEhNamespace'", rg);
            var hub = EventHub.FromExisting(infra, "'existingHub'", eh);
            infra.AddResource(hub);
            infra.AddResource(EventHubsConsumerGroup.FromExisting(infra, "'existingEhConsumerGroup'", hub));

            infra.AddResource(SignalRService.FromExisting(infra, "'existingSignalR'", rg));

            infra.AddResource(ApplicationInsightsComponent.FromExisting(infra, "'existingAppInsights'", rg));

            infra.AddResource(OperationalInsightsWorkspace.FromExisting(infra, "'existingOpInsights'", rg));

            infra.AddResource(UserAssignedIdentity.FromExisting(infra, "'existingUserAssignedIdentity'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    existingAppConfig = new { value = "appConfig" },
                    existingSqlDatabase = new { value = "sqlDatabase" },
                }));
        }

        public async Task ValidateBicepAsync(BinaryData? parameters = null, bool interactiveMode = false)
        {
            if (CoreTestEnvironment.GlobalIsRunningInCI)
            {
                return;
            }

            var testPath = Path.Combine(_infrastructureRoot, TestContext.CurrentContext.Test.Name);
            var client = GetArmClient();
            ResourceGroupResource? rg = null;

            SubscriptionResource subscription = await client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);

            try
            {
                var bicepPath = Path.Combine(testPath, "main.bicep");
                var args = Path.Combine(
                    CoreTestEnvironment.RepositoryRoot,
                    "eng",
                    "scripts",
                    $"Validate-Bicep.ps1 {bicepPath}");
                var processInfo = new ProcessStartInfo("pwsh.exe", args)
                {
                    UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true,
                };
                var process = Process.Start(processInfo);
                while (!process!.HasExited && !process!.StandardError.EndOfStream)
                {
                    var error = process.StandardError.ReadLine();
                    TestContext.Progress.WriteLine(error);
                    if (error!.Contains("Error"))
                    {
                        Assert.Fail(error);
                    }
                }

                ResourceIdentifier scope;
                if (interactiveMode)
                {
                    var rgs = subscription.GetResourceGroups();
                    var data = new ResourceGroupData("westus");
                    rg = (await rgs.CreateOrUpdateAsync(WaitUntil.Completed, TestContext.CurrentContext.Test.Name, data)).Value;
                    scope = ResourceGroupResource.CreateResourceIdentifier(subscription.Id.SubscriptionId,
                        TestContext.CurrentContext.Test.Name);
                }
                else
                {
                    scope = subscription.Id;
                }

                var resource = client.GetArmDeploymentResource(ArmDeploymentResource.CreateResourceIdentifier(scope, TestContext.CurrentContext.Test.Name));
                var content = new ArmDeploymentContent(
                    new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
                    {
                        Template = new BinaryData(File.ReadAllText(Path.Combine(testPath, "main.json"))),
                        Parameters = parameters
                    });
                if (!interactiveMode)
                {
                    content.Location = "westus";
                }
                await resource.ValidateAsync(WaitUntil.Completed, content);
            }
            finally
            {
                File.Delete(Path.Combine(testPath, "main.json"));
                if (rg != null)
                {
                    await rg.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        private static string GetGitRoot()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "rev-parse --show-toplevel",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo)!)
            {
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    string gitRoot = process.StandardOutput.ReadToEnd().Trim();
                    return gitRoot;
                }
                else
                {
                    throw new Exception("Failed to get the root of the Git repository.");
                }
            }
        }

        private string GetOutputPath()
        {
            string output = Path.Combine(_infrastructureRoot, TestContext.CurrentContext.Test.Name);
            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }
            return output;
        }
    }
}

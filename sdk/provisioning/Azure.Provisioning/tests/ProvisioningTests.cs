// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Provisioning.ResourceManager;
using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Identity;
using Azure.Provisioning.AppService;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.Sql;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.AppConfiguration;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.PostgreSql;
using Azure.Provisioning.Redis;
using Azure.ResourceManager;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using CoreTestEnvironment = Azure.Core.TestFramework.TestEnvironment;

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
        public async Task WebSiteUsingL1()
        {
            var infra = new TestInfrastructure();

            Parameter sqlAdminPasswordParam = new Parameter("sqlAdminPassword", "SQL Server administrator password", isSecure: true);
            infra.AddParameter(sqlAdminPasswordParam);
            Parameter appUserPasswordParam = new Parameter("appUserPassword", "Application user password", isSecure: true);
            infra.AddParameter(appUserPasswordParam);

            infra.AddResourceGroup();
            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");

            AppServicePlan appServicePlan = infra.AddAppServicePlan();
            Assert.True(appServicePlan.Properties.Name.EndsWith(infra.EnvironmentName));

            WebSite frontEnd = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts");
            Assert.True(frontEnd.Properties.Name.EndsWith(infra.EnvironmentName));

            Assert.AreEqual(Guid.Empty.ToString(), frontEnd.Properties.AppServicePlanId.SubscriptionId);

            var frontEndPrincipalId = frontEnd.AddOutput(
                website => website.Identity.PrincipalId, //Identity.PrincipalId
                "SERVICE_API_IDENTITY_PRINCIPAL_ID",
                isSecure: true);

            var kv = infra.AddKeyVault();
            kv.AddAccessPolicy(frontEndPrincipalId); // frontEnd.properties.identity.principalId
            kv.AssignRole(RoleDefinition.KeyVaultAdministrator, Guid.Empty);
            kv.AddOutput(data => data.Properties.VaultUri, "vaultUri");

            KeyVaultSecret sqlAdminSecret = new KeyVaultSecret(infra, name: "sqlAdminPassword");
            Assert.False(sqlAdminSecret.Properties.Name.EndsWith(infra.EnvironmentName));
            sqlAdminSecret.AssignProperty(secret => secret.Properties.Value, sqlAdminPasswordParam);

            KeyVaultSecret appUserSecret = new KeyVaultSecret(infra, name: "appUserPassword");
            Assert.False(appUserSecret.Properties.Name.EndsWith(infra.EnvironmentName));
            appUserSecret.AssignProperty(secret => secret.Properties.Value, appUserPasswordParam);

            SqlServer sqlServer = new SqlServer(infra, "sqlserver");
            sqlServer.AssignProperty(sql => sql.AdministratorLogin, "'sqladmin'");
            sqlServer.AssignProperty(sql => sql.AdministratorLoginPassword, sqlAdminPasswordParam);
            Output sqlServerName = sqlServer.AddOutput(sql => sql.FullyQualifiedDomainName, "sqlServerName");

            SqlDatabase sqlDatabase = new SqlDatabase(infra, sqlServer);
            Assert.False(sqlDatabase.Properties.Name.EndsWith(infra.EnvironmentName));

            KeyVaultSecret sqlAzureConnectionStringSecret = new KeyVaultSecret(infra, "connectionString", sqlDatabase.GetConnectionString(appUserPasswordParam));
            Assert.False(sqlAzureConnectionStringSecret.Properties.Name.EndsWith(infra.EnvironmentName));

            SqlFirewallRule sqlFirewallRule = new SqlFirewallRule(infra, name: "firewallRule");
            Assert.False(sqlFirewallRule.Properties.Name.EndsWith(infra.EnvironmentName));

            DeploymentScript deploymentScript = new DeploymentScript(
                infra,
                "cliScript",
                sqlDatabase,
                new Parameter(sqlServerName),
                appUserPasswordParam,
                sqlAdminPasswordParam);

            WebSite backEnd = new WebSite(infra, "backEnd", appServicePlan, WebSiteRuntime.Dotnetcore, "6.0");
            Assert.True(backEnd.Properties.Name.EndsWith(infra.EnvironmentName));

            WebSiteConfigLogs logs = new WebSiteConfigLogs(infra, "logs", frontEnd);
            Assert.False(logs.Properties.Name.EndsWith(infra.EnvironmentName));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    sqlAdminPassword = new { value = "password" },
                    appUserPassword = new { value = "password" }
                }));
        }

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
                adminLogin: new Parameter("adminLogin", "SQL Server administrator login"),
                adminPassword: new Parameter("adminPassword", "SQL Server administrator password", isSecure: true));
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
                adminLogin: new Parameter("adminLogin", "SQL Server administrator login"),
                adminPassword: new Parameter("adminPassword", "SQL Server administrator password", isSecure: true),
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
            var kv = KeyVault.FromExisting(infrastructure, name: "existingVault");
            _ = new KeyVaultSecret(infrastructure, "primaryConnectionString", cache.GetConnectionString(), kv);
            _ = new KeyVaultSecret(infrastructure, "secondaryConnectionString", cache.GetConnectionString(useSecondary: true), kv);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(interactiveMode: true);
        }

        // [RecordedTest]
        // public async Task RedisCacheWithExistingKeyVaultOtherRg()
        // {
        //     TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
        //     var cache = new RedisCache(infrastructure);
        //     var rg = new ResourceGroup(infrastructure, "otherRg", isExisting: true);
        //     var kv = KeyVault.FromExisting(infrastructure, parent: rg, name: "existingVault");
        //     _ = new KeyVaultSecret(infrastructure, "connectionString", cache.GetConnectionString(), kv);
        //
        //     infrastructure.Build(GetOutputPath());
        //
        //     await ValidateBicepAsync(interactiveMode: true);
        // }

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
            var kv = infrastructure.AddKeyVault();
            // verify we can assign a property that is already assigned automatically by the CDK
            var p = new Parameter("p", defaultValue: "name");
            kv.AssignProperty(x=> x.Name, p);
            _ = new KeyVaultSecret(infrastructure, "connectionString", server.GetConnectionString(adminLogin, adminPassword));

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(
                BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "password" },
                        adminPassword = new { value = "password" }
                    }),
                interactiveMode: true);
        }

        [RecordedTest]
        public async Task WebSiteUsingL2()
        {
            var infra = new TestInfrastructure();
            infra.AddFrontEndWebSite();

            Assert.AreEqual(Guid.Empty.ToString(), infra.GetSingleResourceInScope<WebSite>()!.Properties.AppServicePlanId.SubscriptionId);

            infra.AddCommonSqlDatabase();
            infra.AddBackEndWebSite();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    sqlAdminPassword = new { value = "password" },
                    appUserPassword = new { value = "password" }
                }));
        }

        [RecordedTest]
        public async Task WebSiteUsingL3()
        {
            var infra = new TestInfrastructure();
            infra.AddWebSiteWithSqlBackEnd();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.GetSingleResourceInScope<KeyVault>()!.Properties.Tags.Add("key", "value");

            foreach (var website in infra.GetResources().Where(r => r is WebSite))
            {
                Assert.AreEqual(Guid.Empty.ToString(), ((WebSite)website).Properties.AppServicePlanId.SubscriptionId);
            }

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    sqlAdminPassword = new { value = "password" },
                    appUserPassword = new { value = "password" }
                }));
        }

        [RecordedTest]
        public async Task WebSiteUsingL3SpecificSubscription()
        {
            var infra = new TestInfrastructure();
            infra.AddWebSiteWithSqlBackEnd();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.GetSingleResourceInScope<KeyVault>()!.Properties.Tags.Add("key", "value");
            foreach (var website in infra.GetResources().Where(r => r is WebSite))
            {
                Assert.AreEqual(Guid.Empty.ToString(), ((WebSite)website).Properties.AppServicePlanId.SubscriptionId);
            }

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    sqlAdminPassword = new { value = "password" },
                    appUserPassword = new { value = "password" }
                }));
        }

        [RecordedTest]
        public async Task WebSiteUsingL3ResourceGroupScope()
        {
            var infra = new TestInfrastructure(scope: ConstructScope.ResourceGroup, configuration: new Configuration { UseInteractiveMode = true });
            infra.AddWebSiteWithSqlBackEnd();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.GetSingleResourceInScope<KeyVault>()!.Properties.Tags.Add("key", "value");

            foreach (var website in infra.GetResources().Where(r => r is WebSite))
            {
                Assert.AreEqual("subscription()", ((WebSite)website).Properties.AppServicePlanId.SubscriptionId);
                Assert.AreEqual("resourceGroup()", ((WebSite)website).Properties.AppServicePlanId.ResourceGroupName);
            }

            infra.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                new
                {
                    sqlAdminPassword = new { value = "password" },
                    appUserPassword = new { value = "password" }
                }), interactiveMode: true);
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
            infra.AddAppConfigurationStore();
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
            var appServicePlan = infra.AddAppServicePlan(parent: rg1);
            WebSite frontEnd1 = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts", parent: rg1);

            var output1 = frontEnd1.AddOutput(data => data.Identity.PrincipalId, "STORAGE_PRINCIPAL_ID");
            var output2 = frontEnd1.AddOutput(data => data.Location, "LOCATION");

            KeyVault keyVault = infra.AddKeyVault(resourceGroup: rg1);
            keyVault.AssignProperty(data => data.Properties.EnableSoftDelete, new Parameter("enableSoftDelete", "Enable soft delete", defaultValue: true, isSecure: false));

            WebSite frontEnd2 = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts", parent: rg2);

            frontEnd2.AssignProperty(data => data.Identity.PrincipalId, new Parameter(output1));

            var testFrontEndWebSite = new TestFrontEndWebSite(infra, parent: rg3);
            infra.Build(GetOutputPath());

            Assert.AreEqual(3, infra.GetParameters().Count());
            Assert.AreEqual(4, infra.GetOutputs().Count());

            Assert.AreEqual(0, testFrontEndWebSite.GetParameters().Count());
            Assert.AreEqual(1, testFrontEndWebSite.GetOutputs().Count());

            await ValidateBicepAsync();
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

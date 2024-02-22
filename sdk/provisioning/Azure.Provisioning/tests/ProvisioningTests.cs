// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Provisioning.ResourceManager;
using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Identity;
using Azure.Provisioning.AppService;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.Sql;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.AppConfiguration;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.Provisioning.Tests
{
    public class ProvisioningTests
    {
        private static readonly string _infrastructureRoot = Path.Combine(GetGitRoot(), "sdk", "provisioning", "Azure.Provisioning", "tests", "Infrastructure");

        [Test]
        public void WebSiteUsingL1()
        {
            var infra = new TestInfrastructure();

            Parameter sqlAdminPasswordParam = new Parameter("sqlAdminPassword", "SQL Server administrator password", isSecure: true, defaultValue: "password");
            infra.AddParameter(sqlAdminPasswordParam);
            Parameter appUserPasswordParam = new Parameter("appUserPassword", "Application user password", isSecure: true, defaultValue: "password");
            infra.AddParameter(appUserPasswordParam);

            infra.AddResourceGroup();
            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");

            AppServicePlan appServicePlan = infra.AddAppServicePlan();

            WebSite frontEnd = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts");
            var frontEndPrincipalId = frontEnd.AddOutput(
                website => website.Identity.PrincipalId, //Identity.PrincipalId
                "SERVICE_API_IDENTITY_PRINCIPAL_ID",
                isSecure: true);

            infra.AddKeyVault()
                .AddAccessPolicy(frontEndPrincipalId); // frontEnd.properties.identity.principalId

            KeyVaultSecret sqlAdminSecret = new KeyVaultSecret(infra, "sqlAdminPassword");
            sqlAdminSecret.AssignParameter(secret => secret.Properties.Value, sqlAdminPasswordParam);

            KeyVaultSecret appUserSecret = new KeyVaultSecret(infra, "appUserPassword");
            appUserSecret.AssignParameter(secret => secret.Properties.Value, appUserPasswordParam);

            SqlServer sqlServer = new SqlServer(infra, "sqlserver");
            sqlServer.AssignParameter(sql => sql.AdministratorLoginPassword, sqlAdminPasswordParam);

            SqlDatabase sqlDatabase = new SqlDatabase(infra);

            KeyVaultSecret sqlAzureConnectionStringSecret = new KeyVaultSecret(infra, "connectionString", sqlDatabase.GetConnectionString(appUserPasswordParam));

            SqlFirewallRule sqlFirewallRule = new SqlFirewallRule(infra, "firewallRule");

            DeploymentScript deploymentScript = new DeploymentScript(infra, "cliScript", sqlDatabase, appUserPasswordParam, sqlAdminPasswordParam);

            WebSite backEnd = new WebSite(infra, "backEnd", appServicePlan, WebSiteRuntime.Dotnetcore, "6.0");

            WebSiteConfigLogs logs = new WebSiteConfigLogs(infra, "logs", frontEnd);

            infra.Build(GetOutputPath());
        }

        [TearDown]
        public async Task ValidateBicep()
        {
            if (TestEnvironment.GlobalIsRunningInCI)
            {
                return;
            }

            var testPath = Path.Combine(_infrastructureRoot, TestContext.CurrentContext.Test.Name);

            try
            {
                var bicepPath = Path.Combine(testPath, "main.bicep");
                var args = Path.Combine(
                    TestEnvironment.RepositoryRoot,
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
                    if (error!.StartsWith("ERROR"))
                    {
                        Assert.Fail(error);
                    }
                }

                var client = new ArmClient(new DefaultAzureCredential());
                SubscriptionResource subscription = await client.GetSubscriptions().GetAsync(Environment.GetEnvironmentVariable("SUBSCRIPTION_ID"));

                var identifier = ArmDeploymentResource.CreateResourceIdentifier(subscription.Id, TestContext.CurrentContext.Test.Name);
                var resource = client.GetArmDeploymentResource(identifier);
                await resource.ValidateAsync(WaitUntil.Completed,
                    new ArmDeploymentContent(
                        new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
                        {
                            Template = new BinaryData(File.ReadAllText(Path.Combine(testPath, "main.json"))),
                        })
                    {
                        Location = "westus"
                    });
            }
            finally
            {
                // File.Delete(Path.Combine(testPath, "main.json"));
            }
        }

        [Test]
        public void ResourceGroupOnly()
        {
            TestInfrastructure infrastructure = new TestInfrastructure();
            var resourceGroup = infrastructure.AddResourceGroup();
            infrastructure.Build(GetOutputPath());
        }

        [Test]
        public void WebSiteUsingL2()
        {
            var infra = new TestInfrastructure();
            infra.AddFrontEndWebSite();
            infra.AddCommonSqlDatabase();
            infra.AddBackEndWebSite();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.Build(GetOutputPath());
        }

        [Test]
        public void WebSiteUsingL3()
        {
            var infra = new TestInfrastructure();
            infra.AddWebSiteWithSqlBackEnd();

            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");
            infra.GetSingleResourceInScope<KeyVault>()!.Properties.Tags.Add("key", "value");
            infra.Build(GetOutputPath());
        }

        [Test]
        public void StorageBlobDefaults()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            infra.AddBlobService();
            infra.Build(GetOutputPath());
        }

        [Test]
        public void StorageBlobDropDown()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var blob = infra.AddBlobService();
            blob.Properties.DeleteRetentionPolicy = new DeleteRetentionPolicy()
            {
                IsEnabled = true
            };
            infra.Build(GetOutputPath());
        }

        [Test]
        public void AppConfiguration()
        {
            var infra = new TestInfrastructure();
            infra.AddAppConfigurationStore();
            infra.Build(GetOutputPath());
        }

        [Test]
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
        }

        [Test]
        public void OutputsSpanningModules()
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
            keyVault.AssignParameter(data => data.Properties.EnableSoftDelete, new Parameter("enableSoftDelete", "Enable soft delete", defaultValue: true, isSecure: false));

            WebSite frontEnd2 = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts", parent: rg2);

            frontEnd2.AssignParameter(data => data.Identity.PrincipalId, new Parameter(output1));

            var testFrontEndWebSite = new TestFrontEndWebSite(infra, parent: rg3);
            infra.Build(GetOutputPath());

            Assert.AreEqual(3, infra.GetParameters().Count());
            Assert.AreEqual(4, infra.GetOutputs().Count());

            Assert.AreEqual(0, testFrontEndWebSite.GetParameters().Count());
            Assert.AreEqual(1, testFrontEndWebSite.GetOutputs().Count());
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
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1)!;
            string output = Path.Combine(_infrastructureRoot, stackFrame.GetMethod()!.Name);
            if (!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }
            return output;
        }
    }
}

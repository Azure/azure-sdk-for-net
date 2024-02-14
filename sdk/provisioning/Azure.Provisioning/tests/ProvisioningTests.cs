// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Provisioning.ResourceManager;
using System;
using System.IO;
using System.Diagnostics;
using Azure.Provisioning.AppService;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.Sql;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
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

            Parameter sqlAdminPasswordParam = new Parameter("sqlAdminPassword", "SQL Server administrator password", isSecure: true);
            infra.AddParameter(sqlAdminPasswordParam);
            Parameter appUserPasswordParam = new Parameter("appUserPassword", "Application user password", isSecure: true);
            infra.AddParameter(appUserPasswordParam);

            infra.AddResourceGroup();
            infra.GetSingleResource<ResourceGroup>()!.Properties.Tags.Add("key", "value");

            AppServicePlan appServicePlan = infra.AddAppServicePlan();

            WebSite frontEnd = new WebSite(infra, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts");
            var frontEndPrincipalId = frontEnd.AddOutput(
                website => website.Identity.PrincipalId,
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
            infra.AddBlobService(name: "photos");
            infra.Build(GetOutputPath());
        }

        [Test]
        public void StorageBlobDropDown()
        {
            var infra = new TestInfrastructure();
            infra.AddStorageAccount(name: "photoAcct", sku: StorageSkuName.PremiumLrs, kind: StorageKind.BlockBlobStorage);
            var blob = infra.AddBlobService(name: "photos");
            blob.Properties.DeleteRetentionPolicy = new DeleteRetentionPolicy()
            {
                IsEnabled = true
            };
            infra.Build(GetOutputPath());
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

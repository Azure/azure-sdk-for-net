// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using NUnit.Framework;

namespace Azure.Provisioning.PostgreSql.Tests
{
    public class PostgreSqlTests : ProvisioningTestBase
    {
        public PostgreSqlTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task PostgreSql()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var adminLogin = new Parameter("adminLogin", description: "Administrator login");
            var adminPassword = new Parameter("adminPassword", description: "Administrator password", isSecure: true);
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
        public async Task ExistingPostgreSqlResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();

            infra.AddResource(PostgreSqlFlexibleServer.FromExisting(infra, "'existingPostgreSqlServer'", rg));

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }

        [RecordedTest]
        public async Task PostgreSqlResourceWithConfig()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var adminLogin = new Parameter("adminLogin", description: "Administrator login");
            var adminPassword = new Parameter("adminPassword", description: "Administrator password", isSecure: true);
            var server = new PostgreSqlFlexibleServer(
                infrastructure,
                administratorLogin: adminLogin,
                administratorPassword: adminPassword);

            _ = new PostgreSqlFlexibleServerConfiguration(
                infrastructure,
                "azure.extensions",
                "VECTOR",
                parent: server);

            infrastructure.Build(GetOutputPath());

            await ValidateBicepAsync(BinaryData.FromObjectAsJson(
                    new
                    {
                        adminLogin = new { value = "password" },
                        adminPassword = new { value = "password" },
                    }),
                    interactiveMode: true);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Tests;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Sql.Tests
{
    public class SqlTests : ProvisioningTestBase
    {
        public SqlTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SqlServerUsingAdminPassword()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administratorLogin: new Parameter("adminLogin", description: "SQL Server administrator login"),
                administratorPassword: new Parameter("adminPassword", description: "SQL Server administrator password", isSecure: true));
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

            var admin = new ServerExternalAdministrator { AdministratorType = "ActiveDirectory" };

            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administrator: admin);

            sqlServer.AssignProperty(data => data.Administrators.Login, new Parameter("adminLogin", description: "SQL Server administrator login"));
            sqlServer.AssignProperty(data => data.Administrators.Sid, new Parameter("adminObjectId", description: "SQL Server administrator Object ID"));

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

            var admin = new ServerExternalAdministrator { AdministratorType = "ActiveDirectory" };

            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver",
                administratorLogin: new Parameter("adminLogin", description: "SQL Server administrator login"),
                administratorPassword: new Parameter("adminPassword", description: "SQL Server administrator password", isSecure: true),
                administrator: admin);
            sqlServer.AssignProperty(data => data.Administrators.Login, new Parameter("adminIdentityLogin", description: "SQL Server administrator login"));
            sqlServer.AssignProperty(data => data.Administrators.Sid, new Parameter("adminObjectId", description: "SQL Server administrator Object ID"));

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
        public async Task SqlServerUsingChildAdminResource()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });

            var sqlServer = new SqlServer(
                infrastructure,
                "sqlserver");

            var admin = new SqlServerAdministrator(infrastructure, sqlServer);
            admin.Properties.AdministratorType = "ActiveDirectory";
            admin.AssignProperty(data => data.Login, new Parameter("adminLogin", description: "SQL Server administrator login"));
            admin.AssignProperty(data => data.Sid, new Parameter("adminObjectId", description: "SQL Server administrator Object ID"));

            _ = new SqlDatabase(infrastructure, sqlServer);
            _ = new SqlFirewallRule(infrastructure, sqlServer);
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

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetConstructsChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            _ = new TestCommonSqlDatabase(infra);
            var constructs = infra.GetConstructs(recursive);

            Assert.AreEqual(1, constructs.Count());
        }

        [RecordedTest]
        public void SqlServerDatabaseThrowsWithoutParent()
        {
            TestInfrastructure infrastructure = new TestInfrastructure(configuration: new Configuration { UseInteractiveMode = true });
            Assert.Throws<InvalidOperationException>(() => new SqlDatabase(infrastructure));
        }

        [RecordedTest]
        public async Task ExistingResources()
        {
            var infra = new TestInfrastructure();
            var rg = infra.AddResourceGroup();
            var sql = SqlServer.FromExisting(infra, "'existingSqlServer'", rg);
            infra.AddResource(sql);
            var db = SqlDatabase.FromExisting(infra, "'existingSqlDatabase'", sql);
            infra.AddResource(db);

            infra.Build(GetOutputPath());

            await ValidateBicepAsync();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Sql;

namespace Azure.Provisioning.Tests
{
    public class TestCommonSqlDatabase : Construct
    {
        public SqlDatabase SqlDatabase { get; }

        public TestCommonSqlDatabase(IConstruct scope, KeyVault? keyVault = null)
            : base(scope, nameof(TestCommonSqlDatabase))
        {
            if (ResourceGroup is null)
            {
                ResourceGroup = new ResourceGroup(scope, "rg");
            }

            keyVault = UseExistingResource(keyVault, () => scope.AddKeyVault(ResourceGroup));

            Parameter sqlAdminPasswordParam = new Parameter("sqlAdminPassword", "SQL Server administrator password", isSecure: true);
            Parameter appUserPasswordParam = new Parameter("appUserPassword", "Application user password", isSecure: true);
            AddParameter(sqlAdminPasswordParam);
            AddParameter(appUserPasswordParam);

            KeyVaultSecret sqlAdminSecret = new KeyVaultSecret(this, name: "sqlAdminPassword");
            sqlAdminSecret.AssignProperty(secret => secret.Properties.Value, sqlAdminPasswordParam);

            KeyVaultSecret appUserSecret = new KeyVaultSecret(this, name: "appUserPassword");
            appUserSecret.AssignProperty(secret => secret.Properties.Value, appUserPasswordParam);

            SqlServer sqlServer = new SqlServer(this, "sqlserver");
            sqlServer.AssignProperty(sql => sql.AdministratorLoginPassword, sqlAdminPasswordParam);
            sqlServer.AssignProperty(sql => sql.AdministratorLogin, "'sqladmin'");
            Output sqlServerName = sqlServer.AddOutput("sqlServerName", sql => sql.FullyQualifiedDomainName);

            SqlDatabase = new SqlDatabase(this, sqlServer);

            KeyVaultSecret sqlAzureConnectionStringSecret = new KeyVaultSecret(this, "connectionString", SqlDatabase.GetConnectionString(appUserPasswordParam));

            SqlFirewallRule sqlFirewallRule = new SqlFirewallRule(this, name: "firewallRule");
            Parameter databaseName = new Parameter("appUserPassword", "Application user password", isSecure: true);
            DeploymentScript deploymentScript = new DeploymentScript(
                this,
                "cliScript",
                SqlDatabase,
                new Parameter(sqlServerName),
                appUserPasswordParam,
                sqlAdminPasswordParam);
        }
    }
}

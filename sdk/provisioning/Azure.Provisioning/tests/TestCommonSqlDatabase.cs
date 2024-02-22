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

            // specifying the default value for the parameters to allow the ARM validation to pass in our tests
            Parameter sqlAdminPasswordParam = new Parameter("sqlAdminPassword", "SQL Server administrator password", isSecure: true, defaultValue: "password");
            Parameter appUserPasswordParam = new Parameter("appUserPassword", "Application user password", isSecure: true, defaultValue: "password");
            AddParameter(sqlAdminPasswordParam);
            AddParameter(appUserPasswordParam);

            KeyVaultSecret sqlAdminSecret = new KeyVaultSecret(this, "sqlAdminPassword");
            sqlAdminSecret.AssignParameter(secret => secret.Properties.Value, sqlAdminPasswordParam);

            KeyVaultSecret appUserSecret = new KeyVaultSecret(this, "appUserPassword");
            appUserSecret.AssignParameter(secret => secret.Properties.Value, appUserPasswordParam);

            SqlServer sqlServer = new SqlServer(this, "sqlserver");
            sqlServer.AssignParameter(sql => sql.AdministratorLoginPassword, sqlAdminPasswordParam);
            SqlDatabase = new SqlDatabase(this);

            KeyVaultSecret sqlAzureConnectionStringSecret = new KeyVaultSecret(this, "connectionString", SqlDatabase.GetConnectionString(appUserPasswordParam));

            SqlFirewallRule sqlFirewallRule = new SqlFirewallRule(this, "firewallRule");

            DeploymentScript deploymentScript = new DeploymentScript(this, "cliScript", SqlDatabase, appUserPasswordParam, sqlAdminPasswordParam);
        }
    }
}

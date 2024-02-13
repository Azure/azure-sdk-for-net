@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource keyVault_CRoMbemLF 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: 'keyVault_CRoMbemLF'
}

resource keyVaultSecret_nMDmVNMVq 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'sqlAdminPassword'
  properties: {
    value: '00000000-0000-0000-0000-000000000000'
  }
}

resource keyVaultSecret_PrlUnEuAz 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'appUserPassword'
  properties: {
    value: '00000000-0000-0000-0000-000000000000'
  }
}

resource sqlServer_GfC780gjO 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: 'sqlserver-mnash-cdk'
  location: 'westus'
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: '00000000-0000-0000-0000-000000000000'
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_06pzzL812 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_GfC780gjO
  name: 'db-mnash-cdk'
  location: 'westus'
  properties: {
  }
}

resource keyVaultSecret_NP8ELZpgb 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'connectionString'
  properties: {
    value: 'Server=${sqlServer_GfC780gjO.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_06pzzL812.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource sqlFirewallRule_uT1qFq1g9 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_GfC780gjO
  name: 'firewallRule-mnash-cdk'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_rue7c15EI 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  name: 'cliScript-mnash-cdk'
  location: 'westus'
  kind: 'AzureCLI'
  properties: {
    cleanupPreference: 'OnSuccess'
    scriptContent: '''
wget https://github.com/microsoft/go-sqlcmd/releases/download/v0.8.1/sqlcmd-v0.8.1-linux-x64.tar.bz2
tar x -f sqlcmd-v0.8.1-linux-x64.tar.bz2 -C .
cat <<SCRIPT_END > ./initDb.sql
drop user ${APPUSERNAME}
go
create user ${APPUSERNAME} with password = '${APPUSERPASSWORD}'
go
alter role db_owner add member ${APPUSERNAME}
go
SCRIPT_END
./sqlcmd -S ${DBSERVER} -d ${DBNAME} -U ${SQLADMIN} -i ./initDb.sql'''
    environmentVariables: [
      {
        name: 'APPUSERNAME'
        value: 'appUser'
      }
      {
        name: 'APPUSERPASSWORD'
        secureValue: '_p_.appUserPassword'
      }
      {
        name: 'DBNAME'
        value: '_p_.sqlDatabase_06pzzL812.name'
      }
      {
        name: 'DBSERVER'
        value: '_p_.sqlServer_GfC780gjO.properties.fullyQualifiedDomainName'
      }
      {
        name: 'SQLCMDPASSWORD'
        secureValue: '_p_.sqlAdminPassword'
      }
      {
        name: 'SQLADMIN'
        value: 'sqlAdmin'
      }
    ]
    retentionInterval: 'PT1H'
    timeout: 'PT5M'
    azCliVersion: '2.37.0'
  }
}

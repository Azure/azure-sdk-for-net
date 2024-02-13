@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource keyVault_n6Xn70PzJ 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: 'keyVault_n6Xn70PzJ'
}

resource keyVaultSecret_mAspwDx0h 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_n6Xn70PzJ
  name: 'sqlAdminPassword'
  properties: {
    value: '00000000-0000-0000-0000-000000000000'
  }
}

resource keyVaultSecret_qg5TJE5co 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_n6Xn70PzJ
  name: 'appUserPassword'
  properties: {
    value: '00000000-0000-0000-0000-000000000000'
  }
}

resource sqlServer_h9WlA3ws7 'Microsoft.Sql/servers@2022-08-01-preview' = {
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

resource sqlDatabase_5rllN3VNV 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_h9WlA3ws7
  name: 'db-mnash-cdk'
  location: 'westus'
  properties: {
  }
}

resource keyVaultSecret_dZU0IKkqM 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_n6Xn70PzJ
  name: 'connectionString'
  properties: {
    value: 'Server=${sqlServer_h9WlA3ws7.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_5rllN3VNV.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource sqlFirewallRule_mYeCi9UIt 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_h9WlA3ws7
  name: 'firewallRule-mnash-cdk'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_CQw5nRksz 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
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
        value: '_p_.sqlDatabase_5rllN3VNV.name'
      }
      {
        name: 'DBSERVER'
        value: '_p_.sqlServer_h9WlA3ws7.properties.fullyQualifiedDomainName'
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

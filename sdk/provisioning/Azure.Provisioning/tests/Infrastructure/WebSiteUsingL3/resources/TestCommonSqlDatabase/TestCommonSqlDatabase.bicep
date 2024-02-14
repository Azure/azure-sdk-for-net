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
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_PrlUnEuAz 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'appUserPassword'
  properties: {
    value: appUserPassword
  }
}

resource sqlServer_zjdvvB2wl 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: 'sqlserver-TEST'
  location: 'westus'
  properties: {
    administratorLogin: sqlAdminPassword
    administratorLoginPassword: '00000000-0000-0000-0000-000000000000'
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_U7NzorRJT 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_zjdvvB2wl
  name: 'db-TEST'
  location: 'westus'
  properties: {
  }
}

resource keyVaultSecret_NP8ELZpgb 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'connectionString'
  properties: {
    value: 'Server=${sqlServer_zjdvvB2wl.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_U7NzorRJT.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource sqlFirewallRule_eS4m8st65 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_zjdvvB2wl
  name: 'firewallRule-TEST'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_3Zq2Pl8xa 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  name: 'cliScript-TEST'
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
        value: '_p_.sqlDatabase_U7NzorRJT.name'
      }
      {
        name: 'DBSERVER'
        value: '_p_.sqlServer_zjdvvB2wl.properties.fullyQualifiedDomainName'
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

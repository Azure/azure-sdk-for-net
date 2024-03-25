@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource appServicePlan_kjMZSF1FP 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource keyVault_qo1DED50V 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  tags: {
    'key': 'value'
  }
  properties: {
    tenantId: tenant().tenantId
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_QYuNvUKSY 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_qo1DED50V
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: webSite_W5EweSXEq.identity.principalId
        permissions: {
          secrets: [
            'get'
            'list'
          ]
        }
      }
    ]
  }
}

resource keyVaultSecret_Cv86ZMNJH 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_qo1DED50V
  name: 'sqlAdminPassword'
  properties: {
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_3hklpmSpi 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_qo1DED50V
  name: 'appUserPassword'
  properties: {
    value: appUserPassword
  }
}

resource keyVaultSecret_VSwNDRv3g 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_qo1DED50V
  name: 'connectionString'
  properties: {
    value: 'Server=${sqlServer_IUrwXj0qc.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_znwZqtuG7.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource webSite_W5EweSXEq 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
    siteConfig: {
      linuxFxVersion: 'node|18-lts'
      alwaysOn: true
      appCommandLine: './entrypoint.sh -o ./env-config.js && pm2 serve /home/site/wwwroot --no-daemon --spa'
      cors: {
        allowedOrigins: [
          'https://portal.azure.com'
          'https://ms.portal.azure.com'
        ]
      }
      minTlsVersion: '1.2'
      ftpsState: 'FtpsOnly'
    }
    httpsOnly: true
  }
}

resource applicationSettingsResource_NslbdUwEt 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_W5EweSXEq
  name: 'appsettings'
}

resource webSiteConfigLogs_giqxapQs0 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_W5EweSXEq
  name: 'logs'
  properties: {
    applicationLogs: {
      fileSystem: {
        level: 'Verbose'
      }
    }
    httpLogs: {
      fileSystem: {
        retentionInMb: 35
        retentionInDays: 1
        enabled: true
      }
    }
    failedRequestsTracing: {
      enabled: true
    }
    detailedErrorMessages: {
      enabled: true
    }
  }
}

resource sqlServer_IUrwXj0qc 'Microsoft.Sql/servers@2020-11-01-preview' = {
  name: toLower(take('sqlserver${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: sqlAdminPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_znwZqtuG7 'Microsoft.Sql/servers/databases@2020-11-01-preview' = {
  parent: sqlServer_IUrwXj0qc
  name: 'db'
  location: 'westus'
  properties: {
  }
}

resource sqlFirewallRule_c0A2hKlAH 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_IUrwXj0qc
  name: 'firewallRule'
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
        name: 'APPUSERPASSWORD'
        secureValue: appUserPassword
      }
      {
        name: 'SQLCMDPASSWORD'
        secureValue: sqlAdminPassword
      }
      {
        name: 'DBSERVER'
        value: sqlServer_IUrwXj0qc.properties.fullyQualifiedDomainName
      }
      {
        name: 'DBNAME'
        value: 'db'
      }
      {
        name: 'APPUSERNAME'
        value: 'appUser'
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

resource webSite_4pzZqR2OO 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
    siteConfig: {
      linuxFxVersion: 'dotnetcore|6.0'
      alwaysOn: true
      appCommandLine: ''
      cors: {
        allowedOrigins: [
          'https://portal.azure.com'
          'https://ms.portal.azure.com'
        ]
      }
      minTlsVersion: '1.2'
      ftpsState: 'FtpsOnly'
    }
    httpsOnly: true
  }
}

resource applicationSettingsResource_Pfdqa0OdT 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_4pzZqR2OO
  name: 'appsettings'
  properties: {
    'SCM_DO_BUILD_DURING_DEPLOYMENT': 'False'
    'ENABLE_ORYX_BUILD': 'True'
  }
}

output vaultUri string = keyVault_qo1DED50V.properties.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_W5EweSXEq.identity.principalId
output sqlServerName string = sqlServer_IUrwXj0qc.properties.fullyQualifiedDomainName

targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource appServicePlan_PxkuWnuWL 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: location
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource keyVault_wv66C4HPm 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: location
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

resource keyVaultAddAccessPolicy_o5MspwSXj 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_wv66C4HPm
  name: 'add'
  location: location
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: webSite_IGuzwfciS.identity.principalId
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

resource keyVaultSecret_hGC2pnnGh 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_wv66C4HPm
  name: 'sqlAdminPassword'
  location: location
  properties: {
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_1FOMdqlt9 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_wv66C4HPm
  name: 'appUserPassword'
  location: location
  properties: {
    value: appUserPassword
  }
}

resource keyVaultSecret_U6mjHf1cW 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_wv66C4HPm
  name: 'connectionString'
  location: location
  properties: {
    value: 'Server=${sqlServer_YFcCarAEq.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_kBJgqdio1.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource webSite_IGuzwfciS 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/subscription()/resourceGroups/resourceGroup()/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_FiUwo15IY 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_IGuzwfciS
  name: 'appsettings'
}

resource webSiteConfigLogs_GwVSHGFxS 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_IGuzwfciS
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

resource sqlServer_YFcCarAEq 'Microsoft.Sql/servers@2020-11-01-preview' = {
  name: toLower(take('sqlserver${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: sqlAdminPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_kBJgqdio1 'Microsoft.Sql/servers/databases@2020-11-01-preview' = {
  parent: sqlServer_YFcCarAEq
  name: 'db'
  location: location
  properties: {
  }
}

resource sqlFirewallRule_eQtj5OOfp 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_YFcCarAEq
  name: 'firewallRule'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_qloqQ8wU0 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  name: 'cliScript-TEST'
  location: location
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
        value: sqlServer_YFcCarAEq.properties.fullyQualifiedDomainName
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

resource webSite_TR8bo87ZZ 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-TEST'
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/subscription()/resourceGroups/resourceGroup()/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_EFVSysO15 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_TR8bo87ZZ
  name: 'appsettings'
  properties: {
    'SCM_DO_BUILD_DURING_DEPLOYMENT': 'False'
    'ENABLE_ORYX_BUILD': 'True'
  }
}

output vaultUri string = keyVault_wv66C4HPm.properties.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_IGuzwfciS.identity.principalId
output sqlServerName string = sqlServer_YFcCarAEq.properties.fullyQualifiedDomainName

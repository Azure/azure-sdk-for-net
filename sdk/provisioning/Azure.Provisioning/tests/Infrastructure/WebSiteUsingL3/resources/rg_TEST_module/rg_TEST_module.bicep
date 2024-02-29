@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource appServicePlan_nKzfukzAR 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource keyVault_NOcGdMTAl 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: 'kv-TEST'
  location: 'westus'
  tags: {
    'key': 'value'
  }
  properties: {
    tenantId: tenant()
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_fdtNwabkj 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_NOcGdMTAl
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: webSite_3FpK5CT8n.identity.principalId
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

resource keyVaultSecret_WEEeoRpl3 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_NOcGdMTAl
  name: 'sqlAdminPassword-TEST'
  properties: {
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_xSSyrFMVp 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_NOcGdMTAl
  name: 'appUserPassword-TEST'
  properties: {
    value: appUserPassword
  }
}

resource keyVaultSecret_KqH6qKQUV 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_NOcGdMTAl
  name: 'connectionString-TEST'
  properties: {
    value: 'Server=${sqlServer_34dfu0qpx.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_tV9E87T4T.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource webSite_3FpK5CT8n 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_yiPI2wk9b 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_3FpK5CT8n
  name: 'appsettings'
}

resource webSiteConfigLogs_DBqwiSXAX 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_3FpK5CT8n
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

resource sqlServer_34dfu0qpx 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: 'sqlserver-TEST'
  location: 'westus'
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: sqlAdminPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_tV9E87T4T 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_34dfu0qpx
  name: 'db-TEST'
  properties: {
  }
}

resource sqlFirewallRule_RcqDFN0Hf 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_34dfu0qpx
  name: 'firewallRule-TEST'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_AX1YbZ1ue 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
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
        value: sqlServer_34dfu0qpx.properties.fullyQualifiedDomainName
      }
      {
        name: 'DBNAME'
        value: 'db-TEST'
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

resource webSite_k7tHspdBX 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_NvIa6MBRq 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_k7tHspdBX
  name: 'appsettings'
  properties: {
    'SCM_DO_BUILD_DURING_DEPLOYMENT': 'False'
    'ENABLE_ORYX_BUILD': 'True'
  }
}

output vaultUri string = keyVault_NOcGdMTAl.properties.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_3FpK5CT8n.identity.principalId
output sqlServerName string = sqlServer_34dfu0qpx.properties.fullyQualifiedDomainName

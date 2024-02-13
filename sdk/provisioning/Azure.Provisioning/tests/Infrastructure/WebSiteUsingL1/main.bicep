targetScope = subscription

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource resourceGroup_IABVtvgDt 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-mnash-cdk'
  location: 'westus'
  tags: {
    azd-env-name: 'mnash-cdk'
    key: 'value'
  }
}

resource appServicePlan_zDVZJZSeJ 'Microsoft.Web/serverfarms@2021-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'appServicePlan-mnash-cdk'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource webSite_kwcoFVmFY 'Microsoft.Web/sites@2021-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'frontEnd-mnash-cdk'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-mnash-cdk/providers/Microsoft.Web/serverfarms/appServicePlan-mnash-cdk'
    siteConfig: {
      linuxFxVersion: 'node|18-lts'
      alwaysOn: true
      appCommandLine: './entrypoint.sh -o ./env-config.js && pm2 serve /home/site/wwwroot --no-daemon --spa'
      experiments: {
      }
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

resource applicationSettingsResource_GTzB2G8tg 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_kwcoFVmFY
  name: 'appsettings'
}

resource keyVault_n6Xn70PzJ 'Microsoft.KeyVault/vaults@2023-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'kv-mnash-cdk'
  location: 'westus'
  properties: {
    tenantId: '72f988bf-86f1-41af-91ab-2d7cd011db47'
    sku: {
      name: 'standard'
      family: 'A'
    }
  }
}

resource keyVaultAddAccessPolicy_pzaknyGaJ 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_n6Xn70PzJ
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '72f988bf-86f1-41af-91ab-2d7cd011db47'
        objectId: 'SERVICE_API_IDENTITY_PRINCIPAL_ID'
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
  scope: resourceGroup_IABVtvgDt
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
  scope: resourceGroup_IABVtvgDt
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

resource webSite_bbXnyuYEl 'Microsoft.Web/sites@2021-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'backEnd-mnash-cdk'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-mnash-cdk/providers/Microsoft.Web/serverfarms/appServicePlan-mnash-cdk'
    siteConfig: {
      linuxFxVersion: 'dotnetcore|6.0'
      alwaysOn: true
      appCommandLine: ''
      experiments: {
      }
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

resource applicationSettingsResource_6U6Xi0A5f 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_bbXnyuYEl
  name: 'appsettings'
  properties: {
    SCM_DO_BUILD_DURING_DEPLOYMENT: 'False'
    ENABLE_ORYX_BUILD: 'True'
  }
}

resource webSiteConfigLogs_caWaXRSC1 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_kwcoFVmFY
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

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_kwcoFVmFY.identity.principalId

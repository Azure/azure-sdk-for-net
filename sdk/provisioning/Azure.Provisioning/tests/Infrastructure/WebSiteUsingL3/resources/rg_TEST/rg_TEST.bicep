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

resource keyVault_CRoMbemLF 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: 'kv-TEST'
  location: 'westus'
  tags: {
    'key': 'value'
  }
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_NWCGclP20 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_CRoMbemLF
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

resource keyVaultSecret_NmXfhaHvM 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'sqlAdminPassword-TEST'
  properties: {
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_QRsiyFBMe 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'appUserPassword-TEST'
  properties: {
    value: appUserPassword
  }
}

resource keyVaultSecret_7eiFxkj0r 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'connectionString-TEST'
  properties: {
    value: 'Server=${sqlServer_zjdvvB2wl.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_U7NzorRJT.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource webSite_W5EweSXEq 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_9BG7vUQd2 'Microsoft.Web/sites/config@2021-02-01' = {
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

output vaultUri string = keyVault_CRoMbemLF.properties.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_W5EweSXEq.identity.principalId

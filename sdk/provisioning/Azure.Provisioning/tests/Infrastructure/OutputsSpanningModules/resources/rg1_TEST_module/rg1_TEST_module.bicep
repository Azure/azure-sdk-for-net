@description('Enable soft delete')
param enableSoftDelete string = 'True'

@secure()
@description('')
param SERVICE_API_IDENTITY_PRINCIPAL_ID string


resource appServicePlan_9KdpMkrui 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource webSite_SSM1v738n 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg1-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_p8nYwST6O 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_SSM1v738n
  name: 'appsettings'
}

resource keyVault_OqtTDSECw 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: 'kv-TEST'
  location: 'westus'
  properties: {
    tenantId: tenant()
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_G5bnl7Xqn 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_OqtTDSECw
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: SERVICE_API_IDENTITY_PRINCIPAL_ID
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

output STORAGE_PRINCIPAL_ID string = webSite_SSM1v738n.identity.principalId
output LOCATION string = webSite_SSM1v738n.location
output vaultUri string = keyVault_OqtTDSECw.properties.vaultUri

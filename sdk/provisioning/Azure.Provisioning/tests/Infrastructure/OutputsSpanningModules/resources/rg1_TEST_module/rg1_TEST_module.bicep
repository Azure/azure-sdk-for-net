@description('Enable soft delete')
param enableSoftDelete string = 'True'

@secure()
@description('')
param SERVICE_API_IDENTITY_PRINCIPAL_ID string


resource appServicePlan_viooTTlOI 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource webSite_dOTaZfna6 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
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

resource applicationSettingsResource_lzuRUWkeF 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_dOTaZfna6
  name: 'appsettings'
}

resource keyVault_67efR8a7Y 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  properties: {
    tenantId: tenant().tenantId
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_3qcQEiN63 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_67efR8a7Y
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

output STORAGE_PRINCIPAL_ID string = webSite_dOTaZfna6.identity.principalId
output LOCATION string = webSite_dOTaZfna6.location
output vaultUri string = keyVault_67efR8a7Y.properties.vaultUri

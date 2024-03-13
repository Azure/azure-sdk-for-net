targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource keyVault_vxw9QYjTK 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: 'existingVault'
}

resource redisCache_YE3v6ym48 'Microsoft.Cache/Redis@2020-06-01' = {
  name: toLower(take(concat('redis', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    enableNonSslPort: false
    minimumTlsVersion: '1.2'
    sku: {
      name: 'Basic'
      family: 'C'
      capacity: 1
    }
  }
}

resource keyVaultSecret_PGXfP6Z9q 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_vxw9QYjTK
  name: 'primaryConnectionString'
  location: location
  properties: {
    value: '${redisCache_YE3v6ym48.properties.hostName},ssl=true,password=${redisCache_YE3v6ym48.listkeys(redisCache_YE3v6ym48.apiVersion).primaryKey}'
  }
}

resource keyVaultSecret_bTFii2gaH 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_vxw9QYjTK
  name: 'secondaryConnectionStrin'
  location: location
  properties: {
    value: '${redisCache_YE3v6ym48.properties.hostName},ssl=true,password=${redisCache_YE3v6ym48.listkeys(redisCache_YE3v6ym48.apiVersion).secondaryKey}'
  }
}

output vaultUri string = keyVault_vxw9QYjTK.properties.vaultUri

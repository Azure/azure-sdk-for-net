targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource keyVault_gudpA4XUx 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
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

resource keyVaultSecret_BjriHg4Dh 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_gudpA4XUx
  name: 'primaryConnectionString'
  location: location
  properties: {
    value: '${redisCache_YE3v6ym48.properties.hostName},ssl=true,password=${redisCache_YE3v6ym48.listkeys(redisCache_YE3v6ym48.apiVersion).primaryKey}'
  }
}

resource keyVaultSecret_pekkgeXRu 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_gudpA4XUx
  name: 'secondaryConnectionStrin'
  location: location
  properties: {
    value: '${redisCache_YE3v6ym48.properties.hostName},ssl=true,password=${redisCache_YE3v6ym48.listkeys(redisCache_YE3v6ym48.apiVersion).secondaryKey}'
  }
}

output vaultUri string = keyVault_gudpA4XUx.properties.vaultUri

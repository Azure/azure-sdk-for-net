targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


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

resource keyVault_5t0GshPLB 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take(concat('kv', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    tenantId: tenant().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultSecret_R6AWfDGcA 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_5t0GshPLB
  name: 'connectionString'
  location: location
  properties: {
    value: '${redisCache_YE3v6ym48.properties.hostName},ssl=true,password=${redisCache_YE3v6ym48.listkeys(redisCache_YE3v6ym48.apiVersion).primaryKey}'
  }
}

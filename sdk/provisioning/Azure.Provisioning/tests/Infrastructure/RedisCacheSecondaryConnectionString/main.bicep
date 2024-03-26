targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource redisCache_1pkKDcARg 'Microsoft.Cache/Redis@2020-06-01' = {
  name: toLower(take('redis${uniqueString(resourceGroup().id)}', 24))
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

resource keyVault_NEuaN7OeP 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
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

resource keyVaultSecret_ztMuSEPLk 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_NEuaN7OeP
  name: 'connectionString'
  location: location
  properties: {
    value: '${redisCache_1pkKDcARg.properties.hostName},ssl=true,password=${redisCache_1pkKDcARg.listkeys(redisCache_1pkKDcARg.apiVersion).secondaryKey}'
  }
}

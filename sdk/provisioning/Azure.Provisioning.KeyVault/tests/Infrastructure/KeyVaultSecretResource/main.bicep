targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


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

resource keyVaultSecret_0hGd6UGfz 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_NEuaN7OeP
  name: 'kvs'
  location: location
  properties: {
    value: '00000000-0000-0000-0000-000000000000'
  }
}

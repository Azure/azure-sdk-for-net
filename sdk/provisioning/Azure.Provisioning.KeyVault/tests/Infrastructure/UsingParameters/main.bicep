targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Enable soft delete for the key vault.')
param enableSoftDelete bool = true


resource keyVault_7LloDNJK5 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take('kv${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}

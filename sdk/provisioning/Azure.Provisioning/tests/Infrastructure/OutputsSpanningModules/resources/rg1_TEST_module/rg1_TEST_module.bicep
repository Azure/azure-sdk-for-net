@description('Enable soft delete')
param enableSoftDelete string = 'True'


resource storageAccount_yKzpwi6Qr 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('sa', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Standard_GRS'
  }
  kind: 'Storage'
  properties: {
  }
}

resource keyVault_aUw0nRbmu 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: toLower(take(concat('kv', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  properties: {
    tenantId: tenant().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableSoftDelete: enableSoftDelete
    enableRbacAuthorization: true
  }
}

output STORAGE_KIND string = storageAccount_yKzpwi6Qr.kind


resource storageAccount_qoZyLiiYO 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctfadf2ed2a58d43c'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_8zCl9jaMv 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_qoZyLiiYO
  name: 'default'
  properties: {
  }
}

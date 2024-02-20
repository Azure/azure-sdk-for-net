
resource storageAccount_o16OWzTQE 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct985209930ac24f6'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_b1lTObtBZ 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_o16OWzTQE
  name: 'default'
  properties: {
    cors: {
    }
  }
}

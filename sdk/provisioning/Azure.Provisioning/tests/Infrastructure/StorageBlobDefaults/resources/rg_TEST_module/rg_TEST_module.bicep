
resource storageAccount_9Dvxxgn8O 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct58eee912f50347d'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_zJM6Ics0G 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_9Dvxxgn8O
  name: 'default'
  properties: {
  }
}

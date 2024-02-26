
resource storageAccount_v68CLFjrL 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct17b6e77d8453479'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_trxerMWWN 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_v68CLFjrL
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

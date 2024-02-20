
resource storageAccount_qyiy38jjE 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct4e2c754458594ab'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_ChZGQnE2Y 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_qyiy38jjE
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

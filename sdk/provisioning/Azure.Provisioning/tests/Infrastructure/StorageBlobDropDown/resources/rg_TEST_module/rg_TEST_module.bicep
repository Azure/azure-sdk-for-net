
resource storageAccount_3S3yTe8Uk 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct0cba824071e046a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Mv9WBXOiS 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_3S3yTe8Uk
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}


resource storageAccount_8IFaxJjQB 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct5482f9ff12ce4b8'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_NLeppAjLn 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8IFaxJjQB
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

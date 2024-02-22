
resource storageAccount_Rx5iuerhh 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct8cb90ee591ac46d'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_RdulWdFAE 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_Rx5iuerhh
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

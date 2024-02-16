
resource storageAccount_7T9xmsrh2 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-73942c65065844'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_dpAXvabvu 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_7T9xmsrh2
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

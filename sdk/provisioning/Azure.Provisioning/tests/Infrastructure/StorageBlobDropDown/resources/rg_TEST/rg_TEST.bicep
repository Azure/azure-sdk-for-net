
resource storageAccount_wkpTyTxEg 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-85e78c3b34ff40'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_vAIKMJkqV 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_wkpTyTxEg
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

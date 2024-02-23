
resource storageAccount_G59l5B2rB 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctbc21bc86b39b414'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_H0uNWDEc2 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_G59l5B2rB
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

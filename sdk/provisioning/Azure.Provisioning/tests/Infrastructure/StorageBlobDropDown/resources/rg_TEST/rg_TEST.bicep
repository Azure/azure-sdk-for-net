
resource storageAccount_6VLdSTr9S 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct64dbc9ed565a414'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_s3vWj1mku 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_6VLdSTr9S
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

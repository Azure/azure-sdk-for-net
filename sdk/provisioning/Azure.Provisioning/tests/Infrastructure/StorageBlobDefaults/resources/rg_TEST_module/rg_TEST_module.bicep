
resource storageAccount_v03fg7zUF 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct44b504f6e12d4a4'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_MYBzZwJkK 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_v03fg7zUF
  name: 'default'
  properties: {
  }
}


resource storageAccount_rJRF56wLn 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctdbd29b86eb654ef'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_wGH0Fapvd 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_rJRF56wLn
  name: 'default'
  properties: {
  }
}

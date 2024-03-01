
resource storageAccount_melvnlpF2 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_NVMDcYVF9 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_melvnlpF2
  name: 'default'
  properties: {
  }
}


resource storageAccount_ZnnWSenAP 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_wAcYakiP0 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ZnnWSenAP
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

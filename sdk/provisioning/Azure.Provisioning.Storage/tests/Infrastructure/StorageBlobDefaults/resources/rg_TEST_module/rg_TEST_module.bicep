@description('')
param primaryEndpoints object = { 'blob': 'https://photoacct.blob.core.windows.net/' 
'file': 'https://photoacct.file.core.windows.net/' 
'queue': 'https://photoacct.queue.core.windows.net/' 
}


resource storageAccount_ZnnWSenAP 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
    primaryEndpoints: primaryEndpoints
    networkAcls: {
      defaultAction: 'Deny'
    }
  }
}

resource blobService_wAcYakiP0 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ZnnWSenAP
  name: 'default'
  properties: {
  }
}

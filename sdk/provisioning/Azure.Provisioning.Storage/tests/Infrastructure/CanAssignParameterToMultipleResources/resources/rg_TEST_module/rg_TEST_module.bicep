@description('')
param overrideLocation string


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

resource storageAccount_OmNRM19HT 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('sa1${uniqueString(resourceGroup().id)}', 24))
  location: overrideLocation
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'BlobStorage'
  properties: {
    accessTier: 'Hot'
  }
}

resource storageAccount_hOGnwcQFE 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('sa2${uniqueString(resourceGroup().id)}', 24))
  location: overrideLocation
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlobStorage'
  properties: {
    accessTier: 'Hot'
  }
}

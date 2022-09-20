param baseName string = resourceGroup().name
param location string = resourceGroup().location

resource storageAccount 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: '${baseName}files'
  location: location
  kind: 'FileStorage'
  sku: {
    name: 'Premium_LRS'
  }

  resource service 'fileServices' = {
    name: 'default'
    properties: {
      shareDeleteRetentionPolicy: {
        enabled: false
      }
    }
  }
}

var name = storageAccount.name
var key = storageAccount.listKeys().keys[0].value
var connectionString = 'DefaultEndpointsProtocol=https;AccountName=${name};AccountKey=${key}'

output AZURE_STORAGE_ACCOUNT_NAME string = name
output AZURE_STORAGE_ACCOUNT_KEY string = key
output AZURE_STORAGE_CONNECTION_STRING string = connectionString
output STANDARD_STORAGE_CONNECTION_STRING string = connectionString
output STORAGE_CONNECTION_STRING string = connectionString

param baseName string = 'batch'
param location string = resourceGroup().location
var prefix = 'batch'
var seed = resourceGroup().id
var randomId = substring(uniqueString(seed), 0, 10)

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-09-01' = {
    name: '${prefix}storage${randomId}'
    location: location
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'
    properties: {
        accessTier: 'Hot'
    }
}

resource batchAccount 'Microsoft.Batch/batchAccounts@2022-06-01' = {
    name: '${prefix}batchacct${randomId}'
    location: location
    properties: {
        autoStorage: {
            storageAccountId: storageAccount.id
        }
    }
}

output storageAccount string = storageAccount.id
output batchAccount string = batchAccount.id
output batch_endpoint string = 'https://${batchAccount.properties.accountEndpoint}'

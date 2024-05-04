targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

resource batch_NJHADAP 'Microsoft.Batch/batchAccounts@2023-11-01' = {
    name: toLower(take('batch${uniqueString(resourceGroup().id)}', 24))
    location: location
    properties: {
    }
}

resource batchPool_KBJG233A 'Microsoft.Batch/batchAccounts/pools@2023-11-01' = {
    parent: batch_NJHADAP
    name: 'pool'
    location: location
    properties: {
    }
}

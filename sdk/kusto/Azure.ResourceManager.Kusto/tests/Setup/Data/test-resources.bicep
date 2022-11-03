param id string
param location string = resourceGroup().location

output ID string = id

module cluster 'cluster.bicep' = {
    name: 'cluster'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output KUSTO_CLUSTER_NAME string = cluster.outputs.KUSTO_CLUSTER_NAME
output KUSTO_DATABASE_NAME string = cluster.outputs.KUSTO_DATABASE_NAME
output KUSTO_FOLLOWER_CLUSTER_NAME string = cluster.outputs.KUSTO_FOLLOWER_CLUSTER_NAME

module keyVault 'keyVault.bicep' = {
    name: 'keyVault'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output USER_ASSIGNED_IDENTITY_ID string = keyVault.outputs.USER_ASSIGNED_IDENTITY_ID
output KEY_NAME string = keyVault.outputs.KEY_NAME
output KEY_VERSION string = keyVault.outputs.KEY_VERSION
output KEY_VAULT_URI string = keyVault.outputs.KEY_VAULT_URI

module privateEndpoint 'privateEndpoint.bicep' = {
    name: 'privateEndpoint'
    params: {
        id: id
        location: location
        clusterId: cluster.outputs.KUSTO_CLUSTER_ID
    }
    scope: resourceGroup()
    dependsOn: [cluster]
}

output PRIVATE_ENDPOINT_NAME string = privateEndpoint.outputs.PRIVATE_ENDPOINT_NAME

module storage 'storage.bicep' = {
    name: 'storage'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output STORAGE_ACCOUNT_ID string = storage.outputs.STORAGE_ACCOUNT_ID
output SCRIPT_URI string = storage.outputs.SCRIPT_URI
output SCRIPT_SAS_TOKEN string = storage.outputs.SCRIPT_SAS_TOKEN

module dataConnection 'dataConnection.bicep' = {
    name: 'dataConnection'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output EVENT_HUB_ID string = dataConnection.outputs.EVENT_HUB_ID
output IOT_HUB_ID string = dataConnection.outputs.IOT_HUB_ID

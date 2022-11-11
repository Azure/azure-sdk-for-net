param id string
param app_id string
param location string = resourceGroup().location

output ID string = id

module managedIdentity './data/managedIdentity.bicep' = {
    name: 'managedIdentity'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output USER_ASSIGNED_IDENTITY_ID string = managedIdentity.outputs.USER_ASSIGNED_IDENTITY_ID
output USER_ASSIGNED_IDENTITY_PRINCIPAL_ID string = managedIdentity.outputs.USER_ASSIGNED_IDENTITY_PRINCIPAL_ID

module cluster './data/cluster.bicep' = {
    name: 'cluster'
    params: {
        id: id
        user_assigned_identity_id: managedIdentity.outputs.USER_ASSIGNED_IDENTITY_ID
        app_id: app_id
        location: location
    }
    scope: resourceGroup()
    dependsOn: [managedIdentity]
}

output CLUSTER_NAME string = cluster.outputs.CLUSTER_NAME
output DATABASE_NAME string = cluster.outputs.DATABASE_NAME
output TABLE_NAME string = cluster.outputs.TABLE_NAME
output FOLLOWING_CLUSTER_NAME string = cluster.outputs.FOLLOWING_CLUSTER_NAME

module keyVault './data/keyVault.bicep' = {
    name: 'keyVault'
    params: {
        id: id
        location: location
        cluster_object_id: cluster.outputs.CLUSTER_OBJECT_ID
    }
    scope: resourceGroup()
}

output KEY_VAULT_URI string = keyVault.outputs.KEY_VAULT_URI
output KEY_NAME string = keyVault.outputs.KEY_NAME
output KEY_VERSION string = keyVault.outputs.KEY_VERSION

module privateEndpoint './data/privateEndpoint.bicep' = {
    name: 'privateEndpoint'
    params: {
        id: id
        location: location
        cluster_id: cluster.outputs.CLUSTER_ID
    }
    scope: resourceGroup()
}

output PRIVATE_ENDPOINT_NAME string = privateEndpoint.outputs.PRIVATE_ENDPOINT_NAME

module dataConnection './data/dataConnection.bicep' = {
    name: 'dataConnection'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output EVENT_HUB_ID string = dataConnection.outputs.EVENT_HUB_ID
output IOT_HUB_ID string = dataConnection.outputs.IOT_HUB_ID

module storage './data/storage.bicep' = {
    name: 'storage'
    params: {
        id: id
        location: location
    }
    scope: resourceGroup()
}

output STORAGE_ACCOUNT_ID string = storage.outputs.STORAGE_ACCOUNT_ID
output STORAGE_ACCOUNT_SAS_TOKEN string = storage.outputs.STORAGE_ACCOUNT_SAS_TOKEN
output SCRIPT_URI string = storage.outputs.SCRIPT_URI

param id string
param user_assigned_identity_id string
param app_id string
param location string

var clusterName = 'sdkCluster${id}'
var databaseName = 'sdkDatabase${id}'
var databasePrincipalName = 'sdkDatabasePrincipal${id}'
var scriptName = 'sdkScript${id}'
var tableName = 'sdkScriptContentTable${id}'

var tenantId = tenant().tenantId

resource cluster 'Microsoft.Kusto/clusters@2023-08-15' = {
    name: clusterName
    location: location
    sku: {
        name: 'Dev(No SLA)_Standard_E2a_v4'
        tier: 'Basic'
    }
    identity: {
        type: 'SystemAssigned, UserAssigned'
        userAssignedIdentities: {
            '${user_assigned_identity_id}': {}
        }
    }

    resource database 'databases' = {
        name: databaseName
        location: location
        kind: 'ReadWrite'

        resource databasePrincipal 'principalAssignments' = {
            name: databasePrincipalName
            properties: {
                principalId: app_id
                principalType: 'App'
                role: 'Admin'
                tenantId: tenantId
            }
        }

        resource script 'scripts' = {
            name: scriptName
            properties: {
                scriptContent: '.create table ${tableName} (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)'
            }
        }
    }
}

output CLUSTER_ID string = cluster.id
output CLUSTER_OBJECT_ID string = cluster.identity.principalId
output CLUSTER_NAME string = clusterName
output DATABASE_NAME string = databaseName
output TABLE_NAME string = tableName

var followingClusterName = 'sdkFollowingCluster${id}'

resource followerCluster 'Microsoft.Kusto/clusters@2023-08-15' = {
    name: followingClusterName
    location: location
    sku: {
        name: 'Standard_E8as_v5+1TB_PS'
        tier: 'Standard'
    }
    identity: {
        type: 'SystemAssigned'
    }
}

output FOLLOWING_CLUSTER_NAME string = followingClusterName

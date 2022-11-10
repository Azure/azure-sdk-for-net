param id string
param app_id string
param location string

var clusterName = 'sdkCluster${id}'
var databaseName = 'sdkDatabase${id}'
var databasePrincipalName = 'sdkDatabasePrincipal${id}'
var scriptName = 'sdkScript${id}'
var tableName = 'sdkScriptContentTable${id}'

var tenantId = tenant().tenantId

resource cluster 'Microsoft.Kusto/clusters@2022-07-07' = {
    name: clusterName
    location: location
    sku: {
        name: 'Standard_D13_v2'
        tier: 'Standard'
    }
    identity: {
        type: 'SystemAssigned'
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

output CLUSTER_NAME string = clusterName
output DATABASE_NAME string = databaseName
output TABLE_NAME string = tableName

var followingClusterName = 'sdkFollowingCluster${id}'

resource followerCluster 'Microsoft.Kusto/clusters@2022-07-07' = {
    name: followingClusterName
    location: location
    sku: {
        name: 'Standard_D13_v2'
        tier: 'Standard'
    }
    identity: {
        type: 'SystemAssigned'
    }
}

output FOLLOWING_CLUSTER_NAME string = followingClusterName

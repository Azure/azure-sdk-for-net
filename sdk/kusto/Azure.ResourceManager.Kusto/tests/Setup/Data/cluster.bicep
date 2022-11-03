param id string
param location string

resource cluster 'Microsoft.Kusto/clusters@2022-07-07' = {
    name: 'sdkCluster${id}'
    location: location
    sku: {
        name: 'Standard_D13_v2'
        tier: 'Standard'
    }
}

resource database 'Microsoft.Kusto/clusters/databases@2022-07-07' = {
    parent: cluster
    name: 'sdkDatabase${id}'
    location: location
    kind: 'ReadWrite'
}

resource followerCluster 'Microsoft.Kusto/clusters@2022-07-07' = {
    name: 'sdkFollowerCluster${id}'
    location: location
    sku: {
        name: 'Standard_D13_v2'
        tier: 'Standard'
    }
}

output KUSTO_CLUSTER_ID string = cluster.id
output KUSTO_CLUSTER_NAME string = cluster.name
output KUSTO_DATABASE_NAME string = database.name
output KUSTO_FOLLOWER_CLUSTER_NAME string = followerCluster.name

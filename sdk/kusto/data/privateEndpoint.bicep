param id string
param location string
param cluster_id string

resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
    name: 'sdkVnet${id}'
    location: location
    properties: {
        addressSpace: {
            addressPrefixes: ['10.0.0.0/16']
        }
    }
}

resource subnet 'Microsoft.Network/virtualNetworks/subnets@2021-05-01' = {
    parent: vnet
    name: 'sdkSubnet${id}'
    properties: {
        addressPrefix: '10.0.0.0/24'
        privateLinkServiceNetworkPolicies: 'Disabled'
    }
}

param privateEndpointName string = 'sdkPrivateEndpoint${id}'
resource privateEndpoint 'Microsoft.Network/privateEndpoints@2021-05-01' = {
    name: privateEndpointName
    location: location
    properties: {
        subnet: {
            id: subnet.id
        }
        privateLinkServiceConnections: [
            {
                name: privateEndpointName
                properties: {
                    privateLinkServiceId: cluster_id
                    groupIds: ['cluster']
                }
            }
        ]
    }
}

output PRIVATE_ENDPOINT_NAME string = privateEndpoint.name

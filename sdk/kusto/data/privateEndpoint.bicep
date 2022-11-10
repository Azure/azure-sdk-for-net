param id string
param location string
param clusterId string

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
        manualPrivateLinkServiceConnections:[
        ]
        privateLinkServiceConnections: [
            {
                name: privateEndpointName
                properties: {
                    privateLinkServiceId: clusterId
                    groupIds: ['cluster']
                }
            }
        ]
    }
}

output PRIVATE_ENDPOINT_NAME string = privateEndpoint.name

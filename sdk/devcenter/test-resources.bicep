param resourceLocation string = resourceGroup().location

var defaultDevCenterName = 'sdk-default-devcenter'
var defaultProjectName = 'sdk-default-project'
var defaultNetworkConnectionName = 'sdk-default-networkconnection'
var defaultNetworkConnection2Name = 'sdk-default-networkconnection2'
var defaultMarketplaceDefinition = 'sdk-default-devboxdefinition'

var devBoxSkuName = 'general_a_8c32gb_v1'
var devBoxStorage = 'ssd_1024gb'
var marketplaceImageName = 'MicrosoftWindowsDesktop_windows-ent-cpc_win11-21h2-ent-cpc-m365'

resource devcenter 'Microsoft.DevCenter/devcenters@2022-08-01-preview' = {
  name: defaultDevCenterName
  location: resourceLocation
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
  }
}

resource project 'Microsoft.DevCenter/projects@2022-08-01-preview' = {
  name: defaultProjectName
  location: resourceLocation
  properties: {
    devCenterId: devcenter.id
  }
}

resource vnet1 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: 'sdk-vnet1'
  location: resourceLocation
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.4.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'default'
        properties: {
          addressPrefix: '10.4.0.0/24'
          serviceEndpoints: []
          delegations: [
            {
              name: 'Microsoft.DevCenter.networkConnections'
              properties: {
                'serviceName': 'Microsoft.DevCenter/networkConnection'
              }
            }
          ]
          privateEndpointNetworkPolicies: 'Enabled'
          privateLinkServiceNetworkPolicies: 'Enabled'
        }
      }
    ]
    virtualNetworkPeerings: [

    ]
    enableDdosProtection: false
  }
}

resource vnet2 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: 'sdk-vnet2'
  location: resourceLocation
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.4.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'default'
        properties: {
          addressPrefix: '10.4.0.0/24'
          serviceEndpoints: []
          delegations: [
            {
              name: 'Microsoft.DevCenter.networkConnections'
              properties: {
                'serviceName': 'Microsoft.DevCenter/networkConnection'
              }
            }
          ]
          privateEndpointNetworkPolicies: 'Enabled'
          privateLinkServiceNetworkPolicies: 'Enabled'
        }
      }
    ]
    virtualNetworkPeerings: [

    ]
    enableDdosProtection: false
  }
}

resource networkConnection1 'Microsoft.DevCenter/networkConnections@2022-08-01-preview' = {
  name: defaultNetworkConnectionName
  location: resourceLocation
  properties: {
    domainJoinType: 'AzureADJoin'
    subnetId: vnet1.properties.subnets[0].id
  }
}

resource networkConnection2 'Microsoft.DevCenter/networkConnections@2022-08-01-preview' = {
  name: defaultNetworkConnection2Name
  location: resourceLocation
  properties: {
    domainJoinType: 'AzureADJoin'
    subnetId: vnet2.properties.subnets[0].id
  }
}

resource attachedNetwork 'Microsoft.DevCenter/devcenters/attachednetworks@2022-08-01-preview' = {
  name: '${devcenter.name}/${networkConnection1.name}'
  properties: {
    networkConnectionId: networkConnection1.id
  }
}

resource marketplaceDefinition 'Microsoft.DevCenter/devcenters/devboxdefinitions@2022-08-01-preview' = {
  name: '${devcenter.name}/${defaultMarketplaceDefinition}'
  location: resourceLocation
  properties: {
    imageReference: {
      id: '${devcenter.id}/galleries/Default/images/${marketplaceImageName}'
    }
    sku: {
      name: devBoxSkuName
    }
    osStorageType: devBoxStorage
  }
}

output DEFAULT_DEVCENTER_ID string = devcenter.id
output DEFAULT_PROJECT_ID string = project.id
output DEFAULT_MARKETPLACE_DEFINITION_ID string = marketplaceDefinition.id
output DEFAULT_NETWORKCONNECTION_ID string = networkConnection1.id
output DEFAULT_ATTACHED_NETWORK_NAME string = networkConnection1.name
output DEFAULT_NETWORK_CONNECTION_ID string = networkConnection2.id
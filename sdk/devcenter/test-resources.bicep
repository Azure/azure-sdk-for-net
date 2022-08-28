param resourceLocation string = resourceGroup().location

var defaultDevCenterName = 'sdk-default-devcenter'
var defaultProjectName = 'sdk-default-project'

// var devBoxSkuName = 'general_a_8c32gb_v1'
// var devBoxStorage = 'ssd_1024gb'
// var marketplaceImageName = 'MicrosoftWindowsDesktop_windows-ent-cpc_win11-21h2-ent-cpc-m365'
// var localAdminStatus = 'Enabled'

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

// resource gallery 'Microsoft.DevCenter/devcenters/galleries@2022-08-01-preview' = {
//   name: '${devcenter.name}/Gallery1'
//   properties: {
//     galleryResourceId: computeGalleryId
//   }
// }

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

// resource net1 'Microsoft.DevCenter/networkConnections@2022-08-01-preview' = {
//   name: 'NetworkConnection'
//   location: resourceLocation
//   properties: {
//     domainJoinType: 'AzureADJoin'
//     subnetId: vnet1.properties.subnets[0].id
//   }
// }

// resource attachedNetwork 'Microsoft.DevCenter/devcenters/attachednetworks@2022-08-01-preview' = {
//   name: '${devcenter.name}/AttachedNetwork'
//   properties: {
//     networkConnectionResourceId: net1.id
//   }
// }

// resource marketplaceDefinition 'Microsoft.DevCenter/devcenters/devboxdefinitions@2022-08-01-preview' = {
//   name: '${devcenter.name}/MarketplaceDefinition'
//   location: resourceLocation
//   properties: {
//     imageReference: {
//       id: '${devcenter.id}/galleries/Default/images/${marketplaceImageName}'
//     }
//     sku: {
//       name: devBoxSkuName
//     }
//     osStorageType: devBoxStorage
//   }
// }

output DefaultDevCenterId string = devcenter.id
output DefaultProjectId string = project.id

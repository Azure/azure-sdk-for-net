param resourceLocation string = resourceGroup().location
param baseName string = resourceGroup().name
param catalogPatIdentifier string
param devCenterPresetMsi string
param projectEnvironmentTypePresetMsi string
param testUserOid string
param testUserName string
param projectAdminRoleDefinitionId string
param deploymentEnvironmentsRoleDefinitionId string

var defaultDevCenterName = 'sdk-dc-${uniqueString('devcenter', '2022-11-11-preview', baseName, resourceGroup().name)}'

var defaultProjectName = 'sdk-project-${uniqueString('project', '2022-09-01-preview', baseName, resourceGroup().name)}'
var defaultPoolName = 'sdk-pool-${uniqueString('pool', '2022-09-01-preview', baseName, resourceGroup().name)}'
var defaultNetworkConnectionName = 'sdk-networkconnection-${uniqueString('networkConnection', '2022-09-01-preview', baseName, resourceGroup().name)}'
var defaultNetworkConnection2Name = 'sdk-networkconnection2-${uniqueString('networkConnection', '2022-09-01-preview', baseName, resourceGroup().name)}'
var defaultMarketplaceDefinition = 'sdk-devboxdefinition-${uniqueString('devboxdefinition', '2022-09-01-preview', baseName, resourceGroup().name)}'
var defaultCatalogName = 'sdk-default-catalog'
var defaultScheduleName = 'default'
var defaultEnvironmentTypeName = 'sdk-environment-type-${uniqueString('environment-type', '2022-11-11-preview', baseName, resourceGroup().name)}'
var devBoxSkuName = 'general_i_8c32gb256ssd_v2'
var devBoxStorage = 'ssd_256gb'
var marketplaceImageName = 'microsoftvisualstudio_visualstudioplustools_vs-2022-ent-general-win11-m365-gen2'
var gitUri = 'https://github.com/Azure/deployment-environments.git'

resource devcenter 'Microsoft.DevCenter/devcenters@2022-11-11-preview' = {
  name: defaultDevCenterName
  location: resourceLocation
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${devCenterPresetMsi}': {}
  }
  }
  properties: {
  }
}

resource project 'Microsoft.DevCenter/projects@2022-09-01-preview' = {
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
                serviceName: 'Microsoft.DevCenter/networkConnection'
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
                serviceName: 'Microsoft.DevCenter/networkConnection'
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

resource networkConnection1 'Microsoft.DevCenter/networkConnections@2022-09-01-preview' = {
  name: defaultNetworkConnectionName
  location: resourceLocation
  properties: {
    domainJoinType: 'AzureADJoin'
    subnetId: vnet1.properties.subnets[0].id
  }
}

resource networkConnection2 'Microsoft.DevCenter/networkConnections@2022-09-01-preview' = {
  name: defaultNetworkConnection2Name
  location: resourceLocation
  properties: {
    domainJoinType: 'AzureADJoin'
    subnetId: vnet2.properties.subnets[0].id
  }
}

resource attachedNetwork 'Microsoft.DevCenter/devcenters/attachednetworks@2022-09-01-preview' = {
  name: '${devcenter.name}/${networkConnection1.name}'
  properties: {
    networkConnectionId: networkConnection1.id
  }
}

resource marketplaceDefinition 'Microsoft.DevCenter/devcenters/devboxdefinitions@2022-09-01-preview' = {
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

resource pool 'Microsoft.DevCenter/projects/pools@2022-09-01-preview' = {
  name: '${project.name}/${defaultPoolName}'
  location: resourceLocation
  properties: {
    networkConnectionName: networkConnection1.name
    devBoxDefinitionName: defaultMarketplaceDefinition
    localAdministrator: 'Enabled'
    licenseType: 'Windows_Client'
  }
}

resource catalog 'Microsoft.DevCenter/devcenters/catalogs@2022-09-01-preview' = {
  name: '${devcenter.name}/${defaultCatalogName}'
  properties: {
    gitHub: {
      branch: 'main'
      secretIdentifier: catalogPatIdentifier
      path: '/Environments'
      uri: gitUri
    }
  }
}

resource schedule 'Microsoft.DevCenter/projects/pools/schedules@2023-01-01-preview' = {
  name: '${project.name}/${defaultPoolName}/${defaultScheduleName}'
  properties: {
    type: 'StopDevBox'
    frequency: 'Daily'
    time: '19:00'
    timeZone: 'America/Los_Angeles'
    state: 'Enabled'
  }
  dependsOn: [
    project, pool
  ]
}

resource environmentType 'Microsoft.DevCenter/devcenters/environmentTypes@2022-11-11-preview' = {
  name: '${devcenter.name}/${defaultEnvironmentTypeName}'
  properties: {
  }
}

resource projectEnvironmentType 'Microsoft.DevCenter/projects/environmentTypes@2022-11-11-preview' = {
  name: '${project.name}/${defaultEnvironmentTypeName}'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
        '${projectEnvironmentTypePresetMsi}': {}
    }
  }
  properties: {
      deploymentTargetId: subscription().id
      status: 'Enabled'
  }
}

resource environmentRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, project.name, deploymentEnvironmentsRoleDefinitionId, testUserOid)
  scope: project
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', deploymentEnvironmentsRoleDefinitionId)
    principalId: testUserOid
    principalType: 'User'
  }
}

resource devcenterRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, devcenter.name, projectAdminRoleDefinitionId, testUserOid)
  scope: devcenter
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', projectAdminRoleDefinitionId)
    principalId: testUserOid
    principalType: 'User'
}
}

resource devBoxRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, project.name, projectAdminRoleDefinitionId, testUserOid)
  scope: project
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', projectAdminRoleDefinitionId)
    principalId: testUserOid
    principalType: 'User'
}
}

output DEFAULT_DEVCENTER_ID string = devcenter.id
output DEFAULT_PROJECT_ID string = project.id
output DEFAULT_MARKETPLACE_DEFINITION_ID string = marketplaceDefinition.id
output DEFAULT_NETWORKCONNECTION_ID string = networkConnection1.id
output DEFAULT_ATTACHED_NETWORK_NAME string = networkConnection1.name
output DEFAULT_NETWORK_CONNECTION_ID string = networkConnection2.id
output DEFAULT_PROJECT_NAME string = defaultProjectName
output DEFAULT_DEVCENTER_NAME string = defaultDevCenterName
output DEFAULT_POOL_NAME string = defaultPoolName
output DEFAULT_ENVIRONMENT_TYPE_NAME string = defaultEnvironmentTypeName
output DEFAULT_CATALOG_NAME string = defaultCatalogName
output DEVCENTER_TENANT_ID string = subscription().tenantId
output DEVCENTER_ENDPOINT string = devcenter.properties.devCenterUri
output STATIC_TEST_USER_ID string = testUserOid
output DEFAULT_TEST_USER_NAME string = testUserName

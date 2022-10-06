param resourceLocation string = resourceGroup().location
param catalogSecretIdentifier string = 'https://dtc-ppe-integrationtests.vault.azure.net/secrets/FidalgoIntegrationTestsGithubTemplates'
param devCenterPresetMsi string = '/subscriptions/62e47139-66d0-4b0b-a000-1e8a412890c1/resourceGroups/KeepFidalgoIntegrationTestResourcesCanary/providers/Microsoft.ManagedIdentity/userAssignedIdentities/FidalgoIntegrationTestIdentity'
param projectEnvironmentTypePresetMsi string = '/subscriptions/974ae608-fbe5-429f-83ae-924a64019bf3/resourceGroups/Common/providers/Microsoft.ManagedIdentity/userAssignedIdentities/IntegrationTestProjectEnvTypeIdentity'
param testUserOid string = 'df428e89-1bc2-4e72-b736-032c31a6cd97'
param projectAdminRoleDefinitionId string = '331c37c6-af14-46d9-b9f4-e1909e1b95a0'
param deploymentEnvironmentsRoleDefinitionId string = '18e40d4e-8d2e-438d-97e1-9528336e149c'

var defaultDevCenterName = 'sdk-default-dc-euap7'
var defaultProjectName = 'sdk-default-project'
var defaultPoolName = 'sdk-default-pool'
var defaultNetworkConnectionName = 'sdk-default-networkconnection'
var defaultNetworkConnection2Name = 'sdk-default-networkconnection2'
var defaultMarketplaceDefinition = 'sdk-default-devboxdefinition'
var defaultCatalogName = 'sdk-default-catalog'
var defaultEnvironmentTypeName = 'sdk-default-environment-type'
var devBoxSkuName = 'general_a_8c32gb_v1'
var devBoxStorage = 'ssd_1024gb'
var marketplaceImageName = 'MicrosoftWindowsDesktop_windows-ent-cpc_win11-21h2-ent-cpc-m365'
var gitUri = 'https://github.com/Azure/fidalgoIntegrationTests.git'

resource devcenter 'Microsoft.DevCenter/devcenters@2022-09-01-preview' = {
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
      secretIdentifier: catalogSecretIdentifier
      path: '/NewFormat'
      uri: gitUri
    }
  }
}

resource environmentType 'Microsoft.DevCenter/devcenters/environmentTypes@2022-09-01-preview' = {
  name: '${devcenter.name}/${defaultEnvironmentTypeName}'
  properties: {
  }
}

resource projectEnvironmentType 'Microsoft.DevCenter/projects/environmentTypes@2022-09-01-preview' = {
  name: '${project.name}/${defaultEnvironmentTypeName}'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
        '${devCenterPresetMsi}': {}
    }
  }
  properties: {
      deploymentTargetId: subscription().id
      status: 'Enabled'
  }
}

resource environmentRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, projectAdminRoleDefinitionId, testUserOid)
  scope: project
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', projectAdminRoleDefinitionId)
    principalId: testUserOid
    principalType: 'User'
  }
}

resource devBoxRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, deploymentEnvironmentsRoleDefinitionId, testUserOid)
  scope: project
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', deploymentEnvironmentsRoleDefinitionId)
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
output STATIC_TEST_USER_ID string = testUserOid

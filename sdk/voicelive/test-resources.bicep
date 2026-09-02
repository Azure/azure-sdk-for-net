// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

var aiServicesName = '${baseName}-ai'
var defaultProjectName = '${toLower(aiServicesName)}-defaultproject'
var cognitiveServicesUserRoleId = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a97b65f3-24c7-4388-baec-2e87135dc908')

resource aiServices 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' = {
  name: aiServicesName
  location: location
  kind: 'AIServices'
  sku: {
    name: 'S0'
  }
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    customSubDomainName: toLower(aiServicesName)
    publicNetworkAccess: 'Enabled'
    allowProjectManagement: true
    defaultProjectName: toLower(aiServicesName)
  }

  resource defaultProject 'projects' = {
    name: defaultProjectName
    location: location
    identity: {
      type: 'SystemAssigned'
    }
    sku: {
      name: 'S0'
    }
    properties: {
      displayName: defaultProjectName
      description: 'Default project created with the resource'
    }
  }
}

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, aiServices.id, cognitiveServicesUserRoleId)
  scope: aiServices
  properties: {
    roleDefinitionId: cognitiveServicesUserRoleId
    principalId: testApplicationOid
  }
}

// Outputs become environment variables injected into the test run
output AI_SERVICES_NAME string = aiServices.name
output AI_SERVICES_ENDPOINT string = aiServices.properties.endpoints['AI Foundry API']
output AI_SERVICES_KEY string = aiServices.listKeys().key1
output DEFAULT_PROJECT_NAME string = defaultProjectName
output AGENT_PROJECT_ENDPOINT string = aiServices::defaultProject.properties.endpoints['AI Foundry API']

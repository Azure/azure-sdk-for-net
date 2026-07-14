targetScope = 'resourceGroup'

@description('Tags that will be applied to all resources')
param tags object = {}

@description('Bing grounding resource name')
param resourceName string

@description('AI Services account name for the project parent')
param aiServicesAccountName string = ''

@description('AI project name for creating the connection')
param aiProjectName string = ''

@description('Name for the AI Foundry Bing Search connection')
param connectionName string

// Get reference to the AI Services account and project to access their managed identities
resource aiAccount 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: aiServicesAccountName

  resource aiProject 'projects' existing = {
    name: aiProjectName
  }
}

// Bing Search resource for grounding capability
resource bingSearch 'Microsoft.Bing/accounts@2020-06-10' = {
  name: resourceName
  location: 'global'
  tags: tags
  sku: {
    name: 'G1'
  }
  properties: {
    statisticsEnabled: false
  }
  kind: 'Bing.Grounding'
}

// Role assignment to allow AI project to use Bing Search
resource bingSearchRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  scope: bingSearch
  name: guid(subscription().id, resourceGroup().id, 'bing-search-role', aiServicesAccountName, aiProjectName)
  properties: {
    principalId: aiAccount::aiProject.identity.principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', 'a97b65f3-24c7-4388-baec-2e87135dc908') // Cognitive Services User
  }
}

// Create the Bing Search connection using the centralized connection module
module bingSearchConnection '../ai/connection.bicep' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: 'bing-search-connection-creation'
  params: {
    aiServicesAccountName: aiServicesAccountName
    aiProjectName: aiProjectName
    connectionConfig: {
      name: connectionName
      category: 'GroundingWithBingSearch'
      target: bingSearch.properties.endpoint
      authType: 'ApiKey'
      isSharedToAll: true
      metadata: {
        Location: 'global'
        ResourceId: bingSearch.id
        ApiType: 'Azure'
        type: 'bing_grounding'
      }
    }
    credentials: {
      key: bingSearch.listKeys().key1
    }
  }
  dependsOn: [
    bingSearchRoleAssignment
  ]
}

output bingGroundingName string = bingSearch.name
output bingGroundingConnectionName string = bingSearchConnection.outputs.connectionName
output bingGroundingResourceId string = bingSearch.id
output bingGroundingConnectionId string = bingSearchConnection.outputs.connectionId

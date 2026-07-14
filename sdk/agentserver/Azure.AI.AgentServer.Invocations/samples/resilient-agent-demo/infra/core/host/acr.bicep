targetScope = 'resourceGroup'

@description('The location used for all deployed resources')
param location string = resourceGroup().location

@description('Tags that will be applied to all resources')
param tags object = {}

@description('Resource name for the container registry')
param resourceName string

@description('Id of the user or app to assign application roles')
param principalId string

@description('Principal type of user or app')
param principalType string

@description('AI Services account name for the project parent')
param aiServicesAccountName string = ''

@description('AI project name for creating the connection')
param aiProjectName string = ''

@description('Name for the AI Foundry ACR connection')
param connectionName string

// Get reference to the AI Services account and project to access their managed identities
resource aiAccount 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: aiServicesAccountName

  resource aiProject 'projects' existing = {
    name: aiProjectName
  }
}

// Create the Container Registry
module containerRegistry 'br/public:avm/res/container-registry/registry:0.1.1' = {
  name: 'registry'
  params: {
    name: resourceName
    location: location
    tags: tags
    publicNetworkAccess: 'Enabled'
    roleAssignments:[
      {
        principalId: principalId
        principalType: principalType
        // Container Registry Tasks Contributor — build images with ACR tasks and push container images
        roleDefinitionIdOrName: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'fb382eab-e894-4461-af04-94435c366c3f')
      }
      // TODO SEPARATELY
      {
        // the foundry project itself can pull from the ACR
        principalId: aiAccount::aiProject.identity.principalId
        principalType: 'ServicePrincipal'
        roleDefinitionIdOrName: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')
      }
    ]
  }
}

// Create the ACR connection using the centralized connection module
module acrConnection '../ai/connection.bicep' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: 'acr-connection-creation'
  params: {
    aiServicesAccountName: aiServicesAccountName
    aiProjectName: aiProjectName
    connectionConfig: {
      name: connectionName
      category: 'ContainerRegistry'
      target: containerRegistry.outputs.loginServer
      authType: 'ManagedIdentity'
      isSharedToAll: true
      metadata: {
        ResourceId: containerRegistry.outputs.resourceId
      }
    }
    credentials: {
      clientId: aiAccount::aiProject.identity.principalId
      resourceId: containerRegistry.outputs.resourceId
    }
  }
}

output containerRegistryName string = containerRegistry.outputs.name
output containerRegistryLoginServer string = containerRegistry.outputs.loginServer
output containerRegistryResourceId string = containerRegistry.outputs.resourceId
output containerRegistryConnectionName string = acrConnection.outputs.connectionName

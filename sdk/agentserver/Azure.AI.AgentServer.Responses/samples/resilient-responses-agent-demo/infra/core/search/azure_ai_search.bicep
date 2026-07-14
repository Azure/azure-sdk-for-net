targetScope = 'resourceGroup'

@description('Tags that will be applied to all resources')
param tags object = {}

@description('Azure Search resource name')
param resourceName string

@description('Azure Search SKU name')
param azureSearchSkuName string = 'basic'

@description('Azure storage account resource ID')
param storageAccountResourceId string

@description('container name')
param containerName string = 'knowledgebase'

@description('AI Services account name for the project parent')
param aiServicesAccountName string = ''

@description('AI project name for creating the connection')
param aiProjectName string = ''

@description('Id of the user or app to assign application roles')
param principalId string

@description('Principal type of user or app')
param principalType string

@description('Name for the AI Foundry search connection')
param connectionName string

@description('Location for all resources')
param location string = resourceGroup().location

// Get reference to the AI Services account and project to access their managed identities
resource aiAccount 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: aiServicesAccountName

  resource aiProject 'projects' existing = {
    name: aiProjectName
  }
}

// Azure Search Service
resource searchService 'Microsoft.Search/searchServices@2024-06-01-preview' = {
  name: resourceName
  location: location
  tags: tags
  sku: {
    name: azureSearchSkuName
  }
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    replicaCount: 1
    partitionCount: 1
    hostingMode: 'default'
    authOptions: {
      aadOrApiKey: {
        aadAuthFailureMode: 'http401WithBearerChallenge'
      }
    }
    disableLocalAuth: false
    encryptionWithCmk: {
      enforcement: 'Unspecified'
    }
    publicNetworkAccess: 'enabled'
  }
}

// Reference to existing Storage Account
resource storageAccount 'Microsoft.Storage/storageAccounts@2023-05-01' existing = {
  name: last(split(storageAccountResourceId, '/'))
}

// Reference to existing Blob Service
resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2023-05-01' existing = {
  parent: storageAccount
  name: 'default'
}

// Storage Container (create if it doesn't exist)
resource storageContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-05-01' = {
  parent: blobService
  name: containerName
  properties: {
    publicAccess: 'None'
  }
}

// RBAC Assignments

// Search needs to read from Storage
resource searchToStorageRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(storageAccount.id, searchService.id, 'Storage Blob Data Reader', uniqueString(deployment().name))
  scope: storageAccount
  properties: {
    // GOOD
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '2a2b9908-6ea1-4ae2-8e65-a410df84e7d1') // Storage Blob Data Reader
    principalId: searchService.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

// Search needs OpenAI access (AI Services account)
resource searchToAIServicesRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = if (!empty(aiServicesAccountName)) {
  name: guid(aiServicesAccountName, searchService.id, 'Cognitive Services OpenAI User', uniqueString(deployment().name))
  properties: {
    // GOOD
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '5e0bd9bd-7b93-4f28-af87-19fc36ad61bd') // Cognitive Services OpenAI User
    principalId: searchService.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

// AI Project needs Search access - Service Contributor
resource aiServicesToSearchServiceRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: guid(searchService.id, aiServicesAccountName, aiProjectName, 'Search Service Contributor', uniqueString(deployment().name))
  scope: searchService
  properties: {
    // GOOD
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7ca78c08-252a-4471-8644-bb5ff32d4ba0') // Search Service Contributor
    principalId: aiAccount::aiProject.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

// AI Project needs Search access - Index Data Contributor
resource aiServicesToSearchDataRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: guid(searchService.id, aiServicesAccountName, aiProjectName, 'Search Index Data Contributor', uniqueString(deployment().name))
  scope: searchService
  properties: {
    // GOOD
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7') // Search Index Data Contributor
    principalId: aiAccount::aiProject.identity.principalId
    principalType: 'ServicePrincipal'
  }
}

// User permissions - Search Index Data Contributor
resource userToSearchRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(searchService.id, principalId, 'Search Index Data Contributor', uniqueString(deployment().name))
  scope: searchService
  properties: {
    // GOOD
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7') // Search Index Data Contributor
    principalId: principalId
    principalType: principalType
  }
}

// // User permissions - Storage Blob Data Contributor
// resource userToStorageRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
//   name: guid(storageAccount.id, principalId, 'Storage Blob Data Contributor', uniqueString(deployment().name))
//   scope: storageAccount
//   properties: {
//     roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe') // Storage Blob Data Contributor
//     principalId: principalId
//     principalType: principalType
//   }
// }

// // Project needs Search access - Index Data Contributor
// resource projectToSearchRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
//   name: guid(searchService.id, aiProjectName, 'Search Index Data Contributor', uniqueString(deployment().name))
//   scope: searchService
//   properties: {
//     roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7') // Search Index Data Contributor
//     principalId: aiAccountPrincipalId // Using AI account principal ID as project identity
//     principalType: 'ServicePrincipal'
//   }
// }

// Create the AI Search connection using the centralized connection module
module aiSearchConnection '../ai/connection.bicep' = if (!empty(aiServicesAccountName) && !empty(aiProjectName)) {
  name: 'ai-search-connection-creation'
  params: {
    aiServicesAccountName: aiServicesAccountName
    aiProjectName: aiProjectName
    connectionConfig: {
      name: connectionName
      category: 'CognitiveSearch'
      target: 'https://${searchService.name}.search.windows.net'
      authType: 'AAD'
      isSharedToAll: true
      metadata: {
        ApiVersion: '2024-07-01'
        ResourceId: searchService.id
        ApiType: 'Azure'
        type: 'azure_ai_search'
      }
    }
  }
  dependsOn: [
    aiServicesToSearchDataRoleAssignment
  ]
}

// Outputs
output searchServiceName string = searchService.name
output searchServiceId string = searchService.id
output searchServicePrincipalId string = searchService.identity.principalId
output storageAccountName string = storageAccount.name
output storageAccountId string = storageAccount.id
output containerName string = storageContainer.name
output storageAccountPrincipalId string = storageAccount.identity.principalId
output searchConnectionName string = (!empty(aiServicesAccountName) && !empty(aiProjectName)) ? aiSearchConnection!.outputs.connectionName : ''
output searchConnectionId string = (!empty(aiServicesAccountName) && !empty(aiProjectName)) ? aiSearchConnection!.outputs.connectionId : ''


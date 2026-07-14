targetScope = 'resourceGroup'

@description('Name of the existing AI Services account')
param aiServicesAccountName string

@description('Name of the existing AI Foundry project')
param aiFoundryProjectName string

@description('Existing ACR connection name (already set in the environment)')
param existingAcrConnectionName string = ''

@description('Existing container registry endpoint (already set in the environment)')
param existingContainerRegistryEndpoint string = ''

@description('Existing Application Insights connection string (already set in the environment)')
param existingApplicationInsightsConnectionString string = ''

@description('Existing Application Insights resource ID (already set in the environment)')
param existingApplicationInsightsResourceId string = ''

@description('Model deployments to create on the existing AI Services account')
param deployments deploymentsType

@description('List of connections to provision on the existing project')
param connections array = []

@secure()
@description('Map of connection name to credentials object. Kept as @secure to prevent secrets from appearing in deployment logs. Example: { "my-conn": { "key": "secret" } }')
param connectionCredentials object = {}

// Reference the existing account and project — read-only except for the
// additional connections provisioned below from the agent manifest.
resource aiAccount 'Microsoft.CognitiveServices/accounts@2025-06-01' existing = {
  name: aiServicesAccountName

  resource project 'projects' existing = {
    name: aiFoundryProjectName
  }
}

// Create model deployments on the existing AI Services account.
// Uses @batchSize(1) to avoid concurrent deployment conflicts (same as ai-project.bicep).
@batchSize(1)
resource seqDeployments 'Microsoft.CognitiveServices/accounts/deployments@2025-06-01' = [
  for dep in (deployments ?? []): {
    parent: aiAccount
    name: dep.name
    properties: {
      model: dep.model
    }
    sku: dep.sku
  }
]

// Create additional connections from ai.yaml / agent manifest configuration on
// the existing project. Mirrors the loop in ai-project.bicep so manifest-declared
// connections are provisioned regardless of whether the project itself is new or
// pre-existing.
module aiConnections './connection.bicep' = [for (connection, index) in connections: {
  name: 'existing-connection-${connection.name}'
  params: {
    aiServicesAccountName: aiAccount.name
    aiProjectName: aiAccount::project.name
    connectionConfig: connection
    credentials: connectionCredentials[?connection.name] ?? {}
  }
}]

// Outputs — same shape as ai-project.bicep so main.bicep can use either interchangeably
output AZURE_AI_PROJECT_ENDPOINT string = aiAccount::project.properties.endpoints['AI Foundry API']
output FOUNDRY_PROJECT_ENDPOINT string = aiAccount::project.properties.endpoints['AI Foundry API']
output AZURE_OPENAI_ENDPOINT string = aiAccount.properties.endpoints['OpenAI Language Model Instance API']
output aiServicesEndpoint string = aiAccount.properties.endpoint
output accountId string = aiAccount.id
output projectId string = aiAccount::project.id
output aiServicesAccountName string = aiAccount.name
output aiServicesProjectName string = aiAccount::project.name
output aiServicesPrincipalId string = aiAccount.identity.principalId
output projectName string = aiAccount::project.name
output APPLICATIONINSIGHTS_CONNECTION_STRING string = existingApplicationInsightsConnectionString
output APPLICATIONINSIGHTS_RESOURCE_ID string = existingApplicationInsightsResourceId

// Empty connection outputs — these are already set in the azd environment from init
// Connection outputs from the connections array (provisioned above)
output connectionIds array = [for (connection, index) in (connections ?? []): {
  name: aiConnections[index].outputs.connectionName
  id: aiConnections[index].outputs.connectionId
}]

output dependentResources object = {
  registry: {
    name: ''
    loginServer: existingContainerRegistryEndpoint
    connectionName: existingAcrConnectionName
  }
  bing_grounding: {
    name: ''
    connectionName: ''
    connectionId: ''
  }
  bing_custom_grounding: {
    name: ''
    connectionName: ''
    connectionId: ''
  }
  search: {
    serviceName: ''
    connectionName: ''
  }
  storage: {
    accountName: ''
    connectionName: ''
  }
}

type deploymentsType = {
  @description('Specify the name of cognitive service account deployment.')
  name: string

  @description('Required. Properties of Cognitive Services account deployment model.')
  model: {
    @description('Required. The name of Cognitive Services account deployment model.')
    name: string

    @description('Required. The format of Cognitive Services account deployment model.')
    format: string

    @description('Required. The version of Cognitive Services account deployment model.')
    version: string
  }

  @description('The resource model definition representing SKU.')
  sku: {
    @description('Required. The name of the resource model definition representing SKU.')
    name: string

    @description('The capacity of the resource model definition representing SKU.')
    capacity: int
  }
}[]?

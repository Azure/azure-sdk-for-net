// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

type ModelDeployment = {
  @minLength(1)
  name: string
  @minLength(1)
  version: string
  @minLength(1)
  sku: string
  @minValue(1)
  capacity: int
}

@minLength(2)
param accountName string
@minLength(2)
param projectName string
@minLength(1)
param agentName string
param sampleModel ModelDeployment

@secure()
@description('Complete GitHub PAT, including its prefix. Supplied only through an ADO secret.')
param mcpPat string = ''

resource account 'Microsoft.CognitiveServices/accounts@2025-10-01-preview' existing = {
  name: accountName
}

resource project 'Microsoft.CognitiveServices/accounts/projects@2025-10-01-preview' existing = {
  parent: account
  name: projectName
}

resource sampleDeployment 'Microsoft.CognitiveServices/accounts/deployments@2025-10-01-preview' = {
  parent: account
  name: sampleModel.name
  sku: {
    name: sampleModel.sku
    capacity: sampleModel.capacity
  }
  properties: {
    model: {
      format: 'OpenAI'
      name: sampleModel.name
      version: sampleModel.version
    }
    versionUpgradeOption: 'NoAutoUpgrade'
  }
}

// Same contract as foundry-project-pool/provisions/provision-mcp-connection.ps1.
resource mcpConnection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-10-01-preview' = {
  parent: project
  name: 'mcp'
  properties: {
    category: 'RemoteTool'
    authType: 'CustomKeys'
    target: 'https://api.githubcopilot.com/mcp'
    isSharedToAll: false
    credentials: {
      keys: {
        Authorization: 'Bearer ${mcpPat}'
      }
    }
    metadata: {
      type: 'custom_MCP'
    }
  }
}

output environment object = {
  FOUNDRY_PROJECT_ENDPOINT: 'https://${accountName}.services.ai.azure.com/api/projects/${projectName}'
  FOUNDRY_MODEL_NAME: sampleDeployment.name
  FOUNDRY_AGENT_NAME: agentName
  MCP_PROJECT_CONNECTION_ID: mcpConnection.id
}

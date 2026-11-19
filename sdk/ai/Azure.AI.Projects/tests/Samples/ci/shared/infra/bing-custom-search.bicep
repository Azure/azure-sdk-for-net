// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

param accountName string
param projectName string
param bingAccountName string

// Microsoft.Bing types are absent from the bundled Bicep catalog; matches the pool's ARM request.
#disable-next-line BCP081
resource bing 'Microsoft.Bing/accounts@2020-06-10' = {
  name: bingAccountName
  location: 'global'
  kind: 'Bing.GroundingCustomSearch'
  sku: {
    name: 'G2'
  }
  properties: {
    statisticsEnabled: false
  }
}

#disable-next-line BCP081
resource configuration 'Microsoft.Bing/accounts/customSearchConfigurations@2025-05-01-preview' = {
  parent: bing
  name: 'agentdoc'
  properties: {
    allowedDomains: [
      {
        domain: 'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/overview'
        includeSubPages: false
        boostLevel: 'Default'
      }
      {
        domain: 'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/overview'
        includeSubPages: false
        boostLevel: 'Default'
      }
      {
        domain: 'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/bing-grounding'
        includeSubPages: false
        boostLevel: 'Default'
      }
      {
        domain: 'https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/bing-custom-search'
        includeSubPages: false
        boostLevel: 'Default'
      }
    ]
    blockedDomains: []
    pinnedDomains: []
  }
}

resource account 'Microsoft.CognitiveServices/accounts@2025-10-01-preview' existing = {
  name: accountName
}

resource project 'Microsoft.CognitiveServices/accounts/projects@2025-10-01-preview' existing = {
  parent: account
  name: projectName
}

resource connection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-10-01-preview' = {
  parent: project
  name: 'bing-custom'
  properties: {
    category: 'GroundingWithCustomSearch'
    target: bing.properties.endpoint
    authType: 'ApiKey'
    isSharedToAll: false
    credentials: {
      key: bing.listKeys().key1
    }
    metadata: {
      ApiType: 'Azure'
      ResourceId: bing.id
      type: 'bing_custom_search'
    }
  }
}

output environment object = {
  BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID: connection.id
  BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME: connection.name
  BING_CUSTOM_SEARCH_INSTANCE_NAME: configuration.name
  BING_CUSTOM_USER_INPUT: 'What is Azure AI Foundry Agent Service and which search tools does it support?'
}

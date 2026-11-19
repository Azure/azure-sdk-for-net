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
  kind: 'Bing.Grounding'
  sku: {
    name: 'G1'
  }
  properties: {
    statisticsEnabled: false
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
  name: 'bing'
  properties: {
    category: 'GroundingWithBingSearch'
    target: bing.properties.endpoint
    authType: 'ApiKey'
    isSharedToAll: false
    credentials: {
      key: bing.listKeys().key1
    }
    metadata: {
      ApiType: 'Azure'
      ResourceId: bing.id
      type: 'bing_grounding'
    }
  }
}

output environment object = {
  BING_PROJECT_CONNECTION_ID: connection.id
  BING_PROJECT_CONNECTION_NAME: connection.name
}

// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

param accountName string
param projectName string

@secure()
@minLength(1)
param openApiKey string

resource account 'Microsoft.CognitiveServices/accounts@2025-10-01-preview' existing = {
  name: accountName
}

resource project 'Microsoft.CognitiveServices/accounts/projects@2025-10-01-preview' existing = {
  parent: account
  name: projectName
}

resource connection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-10-01-preview' = {
  parent: project
  name: 'openapi'
  properties: {
    category: 'CustomKeys'
    target: '_'
    authType: 'CustomKeys'
    isSharedToAll: false
    credentials: {
      keys: {
        key: openApiKey
      }
    }
    metadata: {
      type: 'openapi'
    }
  }
}

output environment object = {
  OPENAPI_PROJECT_CONNECTION_ID: connection.id
  OPENAPI_PROJECT_CONNECTION_NAME: connection.name
  TRIPADVISOR_PROJECT_CONNECTION_ID: connection.id
}

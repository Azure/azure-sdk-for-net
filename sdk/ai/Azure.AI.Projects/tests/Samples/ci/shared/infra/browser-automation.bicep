// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// Ports the pool's workspace and connection scripts using the shared project UAMI.

param location string
@minLength(2)
param accountName string
@minLength(2)
param projectName string
@minLength(3)
@maxLength(24)
param workspaceName string

resource workspace 'Microsoft.LoadTestService/playwrightWorkspaces@2025-09-01' = {
  name: workspaceName
  location: location
  properties: {
    localAuth: 'Disabled'
    regionalAffinity: 'Enabled'
  }
}

resource account 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = {
  name: accountName
}
resource project 'Microsoft.CognitiveServices/accounts/projects@2025-04-01-preview' existing = {
  parent: account
  name: projectName
}

resource connection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-04-01-preview' = {
  parent: project
  name: 'browserAutomation'
  properties: {
    category: 'PlaywrightWorkspace'
    target: '${replace(workspace.properties.dataplaneUri, '.api.playwright.microsoft.com', '.mcp.playwright.microsoft.com')}/mcp'
    // Foundry's Playwright sample uses this value; the API's published Bicep enum omits it.
    #disable-next-line BCP036
    authType: 'ProjectManagedIdentity'
    audience: 'https://mcp.playwright.microsoft.com'
    isSharedToAll: true
    credentials: null
    metadata: {
      resourceId: workspace.id
    }
  }
}

output environment object = {
  BROWSER_AUTOMATION_PROJECT_CONNECTION_ID: connection.id
  BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME: connection.name
  PLAYWRIGHT_SERVICE_RESOURCE_ID: workspace.id
}

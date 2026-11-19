// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

targetScope = 'resourceGroup'

param location string
param accountPrefix string
param deploymentTimestamp string
param ownerToken string
param agentName string
param sampleModel object
param sharedProjectIdentityResourceId string
param sharedAccountIdentityResourceId string
param sharedSearchIdentityResourceId string
param sharedFunctionIdentityResourceId string
param sharedProjectPrincipalId string

@secure()
param mcpPat string

@secure()
@minLength(1)
param openApiKey string

// All modules are unconditional. Test selection is not an infrastructure input.
module standard './standard-shared-identities.bicep' = {
  name: 'standard-setup'
  params: {
    location: location
    accountPrefix: accountPrefix
    projectPrefix: 'project'
    deploymentTimestamp: deploymentTimestamp
    sharedProjectIdentityResourceId: sharedProjectIdentityResourceId
    sharedAccountIdentityResourceId: sharedAccountIdentityResourceId
    sharedSearchIdentityResourceId: sharedSearchIdentityResourceId
    sharedProjectPrincipalId: sharedProjectPrincipalId
  }
}

module samples './sample-resources.bicep' = {
  name: 'sample-resources'
  params: {
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    agentName: agentName
    sampleModel: sampleModel
    mcpPat: mcpPat
  }
}

module functions './function-app.bicep' = {
  name: 'function-app'
  params: {
    location: location
    functionAppName: 'func-${substring(ownerToken, 0, 20)}'
    storageAccountName: standard.outputs.storageAccountName
    sharedFunctionIdentityResourceId: sharedFunctionIdentityResourceId
  }
}

module search './ai-search.bicep' = {
  name: 'ai-search'
  params: {
    location: location
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    storageAccountName: standard.outputs.storageAccountName
    searchServiceName: standard.outputs.searchServiceName
    sharedSearchIdentityResourceId: sharedSearchIdentityResourceId
    ownerToken: ownerToken
  }
  // Foundry rejects concurrent model deployment operations on the same account.
  dependsOn: [
    samples
  ]
}

module browser './browser-automation.bicep' = {
  name: 'browser-automation'
  params: {
    location: location
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    workspaceName: 'pw-${uniqueString(resourceGroup().id, ownerToken)}'
  }
}

module bing './bing-search.bicep' = {
  name: 'bing-search'
  params: {
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    bingAccountName: 'bing-${uniqueString(resourceGroup().id, ownerToken)}'
  }
}

module bingCustom './bing-custom-search.bicep' = {
  name: 'bing-custom-search'
  params: {
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    bingAccountName: 'bing-custom-${uniqueString(resourceGroup().id, ownerToken)}'
  }
}

module openapi './openapi.bicep' = {
  name: 'openapi'
  params: {
    accountName: standard.outputs.accountName
    projectName: standard.outputs.projectName
    openApiKey: openApiKey
  }
}

// Public, non-secret contract consumed by every SDK language. Keep explicit keys
// so offline planning can discover supported bindings without Azure or a compiler.
// Add new modules above and expose their test inputs here; no PowerShell edits.
output environment object = {
  FOUNDRY_PROJECT_ENDPOINT: samples.outputs.environment.FOUNDRY_PROJECT_ENDPOINT
  FOUNDRY_MODEL_NAME: samples.outputs.environment.FOUNDRY_MODEL_NAME
  FOUNDRY_AGENT_NAME: samples.outputs.environment.FOUNDRY_AGENT_NAME
  MCP_PROJECT_CONNECTION_ID: samples.outputs.environment.MCP_PROJECT_CONNECTION_ID
  FUNCTION_APP_NAME: functions.outputs.environment.FUNCTION_APP_NAME
  FUNCTION_APP_URL: functions.outputs.environment.FUNCTION_APP_URL
  STORAGE_INPUT_QUEUE_NAME: functions.outputs.environment.STORAGE_INPUT_QUEUE_NAME
  STORAGE_OUTPUT_QUEUE_NAME: functions.outputs.environment.STORAGE_OUTPUT_QUEUE_NAME
  STORAGE_QUEUE_SERVICE_ENDPOINT: functions.outputs.environment.STORAGE_QUEUE_SERVICE_ENDPOINT
  AZURE_AI_SEARCH_ENDPOINT: search.outputs.environment.AZURE_AI_SEARCH_ENDPOINT
  AI_SEARCH_PROJECT_CONNECTION_ID: search.outputs.environment.AI_SEARCH_PROJECT_CONNECTION_ID
  AI_SEARCH_INDEX_NAME: search.outputs.environment.AI_SEARCH_INDEX_NAME
  AZURE_AI_EMBED_DEPLOYMENT_NAME: search.outputs.environment.AZURE_AI_EMBED_DEPLOYMENT_NAME
  AZURE_AI_EMBED_DIMENSIONS: search.outputs.environment.AZURE_AI_EMBED_DIMENSIONS
  AZURE_BLOB_CONTAINER_NAME: search.outputs.environment.AZURE_BLOB_CONTAINER_NAME
  AI_SEARCH_USER_INPUT: search.outputs.environment.AI_SEARCH_USER_INPUT
  BROWSER_AUTOMATION_PROJECT_CONNECTION_ID: browser.outputs.environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_ID
  BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME: browser.outputs.environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME
  PLAYWRIGHT_SERVICE_RESOURCE_ID: browser.outputs.environment.PLAYWRIGHT_SERVICE_RESOURCE_ID
  BING_PROJECT_CONNECTION_ID: bing.outputs.environment.BING_PROJECT_CONNECTION_ID
  BING_PROJECT_CONNECTION_NAME: bing.outputs.environment.BING_PROJECT_CONNECTION_NAME
  BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID: bingCustom.outputs.environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID
  BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME: bingCustom.outputs.environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME
  BING_CUSTOM_SEARCH_INSTANCE_NAME: bingCustom.outputs.environment.BING_CUSTOM_SEARCH_INSTANCE_NAME
  BING_CUSTOM_USER_INPUT: bingCustom.outputs.environment.BING_CUSTOM_USER_INPUT
  OPENAPI_PROJECT_CONNECTION_ID: openapi.outputs.environment.OPENAPI_PROJECT_CONNECTION_ID
  OPENAPI_PROJECT_CONNECTION_NAME: openapi.outputs.environment.OPENAPI_PROJECT_CONNECTION_NAME
  TRIPADVISOR_PROJECT_CONNECTION_ID: openapi.outputs.environment.TRIPADVISOR_PROJECT_CONNECTION_ID
}

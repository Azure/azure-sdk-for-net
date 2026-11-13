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
}

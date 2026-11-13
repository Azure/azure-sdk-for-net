// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

targetScope = 'resourceGroup'

param location string
param accountPrefix string
param deploymentTimestamp string
param agentName string
param sampleModel object
param sharedProjectIdentityResourceId string
param sharedAccountIdentityResourceId string
param sharedSearchIdentityResourceId string
param sharedProjectPrincipalId string

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

module model './standard-model.bicep' = {
  name: 'sample-model'
  params: {
    accountName: standard.outputs.accountName
    sampleModel: sampleModel
  }
}

output environment object = {
  FOUNDRY_PROJECT_ENDPOINT: standard.outputs.projectEndpoint
  FOUNDRY_MODEL_NAME: model.outputs.modelName
  FOUNDRY_AGENT_NAME: agentName
}

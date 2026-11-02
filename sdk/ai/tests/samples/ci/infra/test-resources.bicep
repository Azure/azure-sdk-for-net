// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

targetScope = 'resourceGroup'

@minLength(2)
param accountName string

@minLength(2)
param projectName string

@minLength(1)
param agentName string = 'sample-agent'

@minLength(1)
param modelName string = 'gpt-5.5'

@minLength(1)
param modelVersion string = '2026-04-24'

@minLength(1)
param modelSku string = 'GlobalStandard'

@minValue(1)
param modelCapacity int = 40

@secure()
@description('Complete GitHub PAT, including its prefix. Supplied only through an ADO secret variable when needed.')
param mcpPat string = ''

module sampleResources './sample-resources.bicep' = {
  name: 'sample-resources'
  params: {
	accountName: accountName
	projectName: projectName
	agentName: agentName
	sampleModel: {
	  name: modelName
	  version: modelVersion
	  sku: modelSku
	  capacity: modelCapacity
	}
	mcpPat: mcpPat
  }
}

output FOUNDRY_PROJECT_ENDPOINT string = sampleResources.outputs.environment.FOUNDRY_PROJECT_ENDPOINT
output FOUNDRY_MODEL_NAME string = sampleResources.outputs.environment.FOUNDRY_MODEL_NAME
output FOUNDRY_AGENT_NAME string = sampleResources.outputs.environment.FOUNDRY_AGENT_NAME
output MCP_PROJECT_CONNECTION_ID string = sampleResources.outputs.environment.MCP_PROJECT_CONNECTION_ID

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The name of the existing AI Services resource.')
param aiServicesResourceName string = 'changfu-azure-ai-service'

@description('The resource group containing the existing AI Services resource.')
param aiServicesResourceGroupName string = 'changfu-carbon-rg'

// Reference existing AI Services resource
resource aiServices 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' existing = {
  name: aiServicesResourceName
  scope: resourceGroup(aiServicesResourceGroupName)
}

// Outputs become environment variables injected into the test run
output AI_SERVICES_ENDPOINT string = aiServices.properties.endpoints['AI Foundry API']
output AI_SERVICES_KEY string = aiServices.listKeys().key1
output MODEL_DEPLOYMENT_NAME string = 'gpt-realtime'

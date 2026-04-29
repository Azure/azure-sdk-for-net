// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The base resource name.')
param baseName string = resourceGroup().name

// RBAC: Log Analytics Reader role for querying
var logAnalyticsReaderRoleId = '73c42c96-874c-492b-b04d-ab87d138a893'

resource logAnalyticsReaderRole 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, testApplicationOid, logAnalyticsReaderRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', logAnalyticsReaderRoleId)
    principalId: testApplicationOid
  }
}

// Log Analytics Workspace
resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs'
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      searchVersion: 1
      legacy: 0
      enableLogAccessUsingOnlyResourcePermissions: 'true'
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

// Application Insights (workspace-based)
resource applicationInsights 'Microsoft.Insights/components@2020-02-02-preview' = {
  name: '${baseName}-ai'
  kind: 'other'
  location: location
  properties: {
    Application_Type: 'other'
    WorkspaceResourceId: logAnalyticsWorkspace.id
  }
}

// Outputs consumed by TestEnvironment via env vars
output APPLICATIONINSIGHTS_CONNECTION_STRING string = applicationInsights.properties.ConnectionString
output WORKSPACE_ID string = logAnalyticsWorkspace.properties.customerId
output LOGS_ENDPOINT string = 'https://api.loganalytics.io'

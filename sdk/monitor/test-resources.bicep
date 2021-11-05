@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The client OID to grant access to test resources.')
param testApplicationOid string

resource baseName_resource 'Microsoft.Insights/components@2020-02-02-preview' = {
  name: baseName
  kind: 'other'
  location: location
  properties: {
    Application_Type: 'other'
  }
}

resource primaryWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
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
  }
}

resource secondaryWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs2'
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
  }
}

var logReaderRoleId = '73c42c96-874c-492b-b04d-ab87d138a893'

resource logsReaderRole 'Microsoft.Authorization/roleAssignments@2018-01-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, logReaderRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', logReaderRoleId)
    principalId: testApplicationOid
  }
}

var metricPublisherRoleId = '3913510d-42f4-4e42-8a64-420c390055eb'

resource metricReaderRole 'Microsoft.Authorization/roleAssignments@2018-01-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, metricPublisherRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
    principalId: testApplicationOid
  }
}

output CONNECTION_STRING string = baseName_resource.properties.ConnectionString
output APPLICATION_ID string = baseName_resource.properties.AppId
output WORKSPACE_ID string = primaryWorkspace.properties.customerId
output SECONDARY_WORKSPACE_ID string = secondaryWorkspace.properties.customerId
output WORKSPACE_KEY string = listKeys(primaryWorkspace.id, '2020-10-01').primarySharedKey
output SECONDARY_WORKSPACE_KEY string = listKeys(secondaryWorkspace.id, '2020-10-01').primarySharedKey
output METRICS_RESOURCE_ID string = primaryWorkspace.id
output METRICS_RESOURCE_NAMESPACE string = 'Microsoft.OperationalInsights/workspaces'
output LOGS_ENDPOINT string =  'https://api.loganalytics.io'

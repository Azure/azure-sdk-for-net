@description('The object ID of the identity used to query the test workspaces.')
param testApplicationOid string

@allowed([
  'User'
  'ServicePrincipal'
  'Group'
])
param principalType string = 'ServicePrincipal'

param primaryLocation string = 'westus2'
param secondaryLocation string = 'eastus2'
param baseName string = resourceGroup().name
param logsEndpoint string = 'https://api.loganalytics.io'

var locations = [primaryLocation, secondaryLocation]
var components = [
  { name: 'host', region: 0 }
  { name: 'tenant-a', region: 0 }
  { name: 'tenant-b', region: 0 }
  { name: 'tenant-c', region: 1 }
]
var logAnalyticsReaderRoleId = '73c42c96-874c-492b-b04d-ab87d138a893'

resource workspaces 'Microsoft.OperationalInsights/workspaces@2022-10-01' = [for (location, index) in locations: {
  name: '${baseName}-mt-logs-${index}'
  location: location
  properties: {
    sku: { name: 'PerGB2018' }
    retentionInDays: 30
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}]

resource queryAccess 'Microsoft.Authorization/roleAssignments@2022-04-01' = [for (location, index) in locations: {
  name: guid(workspaces[index].id, testApplicationOid, logAnalyticsReaderRoleId)
  scope: workspaces[index]
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', logAnalyticsReaderRoleId)
    principalId: testApplicationOid
    principalType: principalType
  }
}]

resource insights 'Microsoft.Insights/components@2020-02-02' = [for component in components: {
  name: '${baseName}-mt-${component.name}'
  location: locations[component.region]
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: workspaces[component.region].id
    DisableLocalAuth: false
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}]

output MULTI_TENANT_RESOURCES array = [for (component, index) in components: {
  name: component.name
  connectionString: insights[index].properties.ConnectionString
  workspaceId: workspaces[component.region].properties.customerId
  resourceId: insights[index].id
}]

output LOGS_ENDPOINT string = logsEndpoint
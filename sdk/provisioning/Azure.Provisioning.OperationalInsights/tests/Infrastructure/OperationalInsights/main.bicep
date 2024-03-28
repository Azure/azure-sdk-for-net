targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource operationalInsightsWorkspace_gbBdKXLFF 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: toLower(take('opinsights${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
  }
}

output workspaceId string = operationalInsightsWorkspace_gbBdKXLFF.id

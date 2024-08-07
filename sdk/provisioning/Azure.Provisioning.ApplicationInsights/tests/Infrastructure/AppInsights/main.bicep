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

resource applicationInsightsComponent_QCfYrDqDy 'Microsoft.Insights/components@2020-02-02' = {
  name: toLower(take('appinsights${uniqueString(resourceGroup().id)}', 24))
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: operationalInsightsWorkspace_gbBdKXLFF.id
  }
}

output workspaceId string = operationalInsightsWorkspace_gbBdKXLFF.id

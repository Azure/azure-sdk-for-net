targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource applicationInsightsComponent_FpLXFVEKV 'Microsoft.Insights/components@2020-02-02' = {
  name: toLower(take(concat('appinsights', uniqueString(resourceGroup().id)), 24))
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

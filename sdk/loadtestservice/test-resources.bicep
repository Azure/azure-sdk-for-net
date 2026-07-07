param baseName string = resourceGroup().name
param location string = 'eastus'

resource loadTests 'Microsoft.LoadTestService/loadTests@2022-12-01' = {
  name: '${baseName}-csharpsdk-loadTests'
  location: location
  properties: {
  }
}

resource actionGroup 'Microsoft.Insights/actionGroups@2023-01-01' = {
  name: '${baseName}-actiongroup'
  location: 'global'
  properties: {
    groupShortName: 'loadtest'  // Max 12 chars
    enabled: true
  }
}

output LOADTESTSERVICE_ENDPOINT string = loadTests.properties.dataPlaneURI
output LOADTESTSERVICE_RESOURCE_ID string = '/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/contoso-sampleapp-rg/providers/Microsoft.Web/sites/contoso-sampleapp'
output LOADTESTING_ACTION_GROUP_ID string = actionGroup.id

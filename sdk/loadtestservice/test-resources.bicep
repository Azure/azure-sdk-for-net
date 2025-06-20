param baseName string = resourceGroup().name
param location string = 'centralus'

resource loadTests 'Microsoft.LoadTestService/loadTests@2022-12-01' = {
  name: '${baseName}-csharpsdk-loadTests'
  location: location
  properties: {
  }
}

output LOADTESTSERVICE_ENDPOINT string = loadTests.properties.dataPlaneURI
output LOADTESTSERVICE_RESOURCE_ID string = '/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/contoso-sampleapp-rg/providers/Microsoft.Web/sites/contoso-sampleapp'
output LOADTESTSERVICE_TARGET_RESOURCE_ID string = '/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/nikita-rg/providers/Microsoft.Web/sites/perfOptSampleApp'

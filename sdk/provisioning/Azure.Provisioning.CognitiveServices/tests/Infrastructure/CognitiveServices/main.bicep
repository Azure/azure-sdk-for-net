targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param publicNetworkAccess string = 'Enabled'


resource cognitiveServicesAccount_FfhcEiZ4I 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: toLower(take('cs${uniqueString(resourceGroup().id)}', 24))
  location: location
  kind: 'OpenAI'
  sku: {
    name: 'S0'
  }
  properties: {
    publicNetworkAccess: publicNetworkAccess
  }
}

resource cognitiveServicesAccountDeployment_aUMXBryzW 'Microsoft.CognitiveServices/accounts/deployments@2023-05-01' = {
  parent: cognitiveServicesAccount_FfhcEiZ4I
  name: 'cs'
  sku: {
    name: 'S0'
  }
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-embedding-3-large'
      version: '1'
    }
  }
}

output endpoint string = 'Endpoint=${cognitiveServicesAccount_FfhcEiZ4I.properties.endpoint}'
output expression string = uniqueString(cognitiveServicesAccount_FfhcEiZ4I.properties.endpoint)

targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param publicNetworkAccess string = 'Enabled'


resource cognitiveServicesAccount_ZfMvJY5Po 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: 'cs-TEST'
  location: location
  kind: 'OpenAI'
  sku: {
    name: 'S0'
  }
  properties: {
    publicNetworkAccess: publicNetworkAccess
  }
}

resource cognitiveServicesAccountDeployment_JeeW2XLVR 'Microsoft.CognitiveServices/accounts/deployments@2023-05-01' = {
  parent: cognitiveServicesAccount_ZfMvJY5Po
  name: 'cs'
  sku: {
    name: 'S0'
  }
  properties: {
    model: {
      name: 'text-embedding-3-large'
      format: 'OpenAI'
      version: '1'
    }
  }
}

output endpoint string = 'Endpoint=${cognitiveServicesAccount_ZfMvJY5Po.properties.endpoint}'

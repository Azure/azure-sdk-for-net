
resource cognitiveServicesAccount_i9VB7IP7M 'Microsoft.CognitiveServices/accounts@2023-05-01' existing = {
  name: 'cognitiveServices'
}

resource cognitiveServicesAccountDeployment_bOi45xgKN 'Microsoft.CognitiveServices/accounts/deployments@2023-04-15' existing = {
  name: '${cognitiveServicesAccount_i9VB7IP7M}/cognitiveServicesDeployment'
}

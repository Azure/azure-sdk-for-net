targetScope = subscription


resource resourceGroup_IABVtvgDt 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-mnash-cdk'
  location: 'westus'
  tags: {
    azd-env-name: 'mnash-cdk'
  }
}

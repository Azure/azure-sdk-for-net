targetScope = 'subscription'


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

module rg_TEST './resources/rg_TEST/rg_TEST.bicep' = {
  name: 'rg_TEST'
  scope: resourceGroup_I6QNkoPsb
}

output appConfigurationStore_sgecYnln3_endpoint string = appConfigurationStore_sgecYnln3.properties.endpoint

targetScope = 'subscription'


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

module rg_TEST_module './resources/rg_TEST_module/rg_TEST_module.bicep' = {
  name: 'rg_TEST_module'
  scope: resourceGroup_I6QNkoPsb
}

output appConfigurationStore_sgecYnln3_endpoint string = rg_TEST_module.outputs.appConfigurationStore_sgecYnln3_endpoint

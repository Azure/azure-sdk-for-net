targetScope = 'subscription'

@description('')
param overrideLocation string


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
  params: {
    overrideLocation: overrideLocation
  }
}

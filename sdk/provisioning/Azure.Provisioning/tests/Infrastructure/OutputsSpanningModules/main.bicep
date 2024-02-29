targetScope = 'subscription'

@description('Enable soft delete')
param enableSoftDelete string = 'True'


resource resourceGroup_601b9OXIs 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg1-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

resource resourceGroup_pziZsS8EC 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg2-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

resource resourceGroup_rl3Hejsnb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg3-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

module rg1_TEST_module './resources/rg1_TEST_module/rg1_TEST_module.bicep' = {
  name: 'rg1_TEST_module'
  scope: resourceGroup_601b9OXIs
  params: {
    enableSoftDelete: enableSoftDelete
    SERVICE_API_IDENTITY_PRINCIPAL_ID: rg3_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
  }
}

module rg2_TEST_module './resources/rg2_TEST_module/rg2_TEST_module.bicep' = {
  name: 'rg2_TEST_module'
  scope: resourceGroup_pziZsS8EC
  params: {
    STORAGE_PRINCIPAL_ID: rg1_TEST_module.outputs.STORAGE_PRINCIPAL_ID
  }
}

module rg3_TEST_module './resources/rg3_TEST_module/rg3_TEST_module.bicep' = {
  name: 'rg3_TEST_module'
  scope: resourceGroup_rl3Hejsnb
}

output STORAGE_PRINCIPAL_ID string = rg1_TEST_module.outputs.STORAGE_PRINCIPAL_ID
output LOCATION string = rg1_TEST_module.outputs.LOCATION
output vaultUri string = rg1_TEST_module.outputs.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = rg3_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID

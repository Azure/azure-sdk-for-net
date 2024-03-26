targetScope = 'subscription'

@description('Enable soft delete')
param enableSoftDelete string = 'True'


resource resourceGroup_AVG5HpqPz 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg1-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

resource resourceGroup_hu2r8JaSi 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg2-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

resource resourceGroup_Q4i0lpa1h 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg3-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

module rg1_TEST_module './resources/rg1_TEST_module/rg1_TEST_module.bicep' = {
  name: 'rg1_TEST_module'
  scope: resourceGroup_AVG5HpqPz
  params: {
    enableSoftDelete: enableSoftDelete
    SERVICE_API_IDENTITY_PRINCIPAL_ID: rg3_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
  }
}

module rg2_TEST_module './resources/rg2_TEST_module/rg2_TEST_module.bicep' = {
  name: 'rg2_TEST_module'
  scope: resourceGroup_hu2r8JaSi
  params: {
    enableSoftDelete: enableSoftDelete
    STORAGE_PRINCIPAL_ID: rg1_TEST_module.outputs.STORAGE_PRINCIPAL_ID
    SERVICE_API_IDENTITY_PRINCIPAL_ID: rg3_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
  }
}

module rg3_TEST_module './resources/rg3_TEST_module/rg3_TEST_module.bicep' = {
  name: 'rg3_TEST_module'
  scope: resourceGroup_Q4i0lpa1h
}

output STORAGE_PRINCIPAL_ID string = rg1_TEST_module.outputs.STORAGE_PRINCIPAL_ID
output LOCATION string = rg1_TEST_module.outputs.LOCATION
output vaultUri string = rg1_TEST_module.outputs.vaultUri
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = rg3_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID

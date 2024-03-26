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
  }
}

module rg2_TEST_module './resources/rg2_TEST_module/rg2_TEST_module.bicep' = {
  name: 'rg2_TEST_module'
  scope: resourceGroup_hu2r8JaSi
  params: {
    enableSoftDelete: enableSoftDelete
    STORAGE_KIND: rg1_TEST_module.outputs.STORAGE_KIND
  }
}

module rg3_TEST_module './resources/rg3_TEST_module/rg3_TEST_module.bicep' = {
  name: 'rg3_TEST_module'
  scope: resourceGroup_Q4i0lpa1h
  params: {
    enableSoftDelete: enableSoftDelete
    STORAGE_KIND: rg1_TEST_module.outputs.STORAGE_KIND
  }
}

output STORAGE_KIND string = rg1_TEST_module.outputs.STORAGE_KIND

targetScope = 'subscription'

@description('')
param STORAGE_PRINCIPAL_ID string

@description('')
param LOCATION string


resource resourceGroup_AVG5HpqPz 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg1-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource resourceGroup_hu2r8JaSi 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg2-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

module rg1_TEST './resources/rg1_TEST/rg1_TEST.bicep' = {
  name: 'rg1_TEST'
  scope: resourceGroup_AVG5HpqPz
}

module rg2_TEST './resources/rg2_TEST/rg2_TEST.bicep' = {
  name: 'rg2_TEST'
  scope: resourceGroup_hu2r8JaSi
  params: {
    STORAGE_PRINCIPAL_ID: STORAGE_PRINCIPAL_ID
    LOCATION: LOCATION
  }
}

output STORAGE_PRINCIPAL_ID string = rg1_TEST.outputs.STORAGE_PRINCIPAL_ID
output LOCATION string = rg1_TEST.outputs.LOCATION

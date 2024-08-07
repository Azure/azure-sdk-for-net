targetScope = 'subscription'

@description('')
param primaryEndpoints object = { 'blob': 'https://photoacct.blob.core.windows.net/' 
'file': 'https://photoacct.file.core.windows.net/' 
'queue': 'https://photoacct.queue.core.windows.net/' 
}


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
    primaryEndpoints: primaryEndpoints
  }
}

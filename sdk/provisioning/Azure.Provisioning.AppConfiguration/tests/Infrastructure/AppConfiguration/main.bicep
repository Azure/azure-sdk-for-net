targetScope = 'subscription'

@description('')
param disableLocalAuth bool = false

@description('')
param retention int = 5

@description('')
param privateEndpointConnections array = [{ 'properties': { 
'provisioningState': 'Succeeded'
'privateLinkServiceConnectionState': { 'status': 'Approved', 'description': 'Approved', 'actionsRequired': 'None' }
 } }]


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
    disableLocalAuth: disableLocalAuth
    retention: retention
    privateEndpointConnections: privateEndpointConnections
  }
}

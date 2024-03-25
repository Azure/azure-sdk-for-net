targetScope = 'subscription'

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
    'key': 'value'
  }
}

module rg_TEST_module './resources/rg_TEST_module/rg_TEST_module.bicep' = {
  name: 'rg_TEST_module'
  scope: resourceGroup_I6QNkoPsb
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = rg_TEST_module.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
output vaultUri string = rg_TEST_module.outputs.vaultUri
output sqlServerName string = rg_TEST_module.outputs.sqlServerName

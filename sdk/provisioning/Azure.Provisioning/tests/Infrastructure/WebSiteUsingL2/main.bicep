targetScope = 'subscription'

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string = 'password'

@secure()
@description('Application user password')
param appUserPassword string = 'password'

@description('')
param workaround string = '/subscriptions/subscription()/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
    'key': 'value'
  }
}

module rg_TEST './resources/rg_TEST/rg_TEST.bicep' = {
  name: 'rg_TEST'
  scope: resourceGroup_I6QNkoPsb
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
    workaround: workaround
  }
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = rg_TEST.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
output vaultUri string = rg_TEST.outputs.vaultUri

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
    azd-env-name: 'TEST'
    key: 'value'
  }
}

module rg_TEST './resources/rg_TEST/rg_TEST.bicep' = {
  name: 'rg_TEST'
  scope: resourceGroup_I6QNkoPsb
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = TestFrontEndWebSite.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID

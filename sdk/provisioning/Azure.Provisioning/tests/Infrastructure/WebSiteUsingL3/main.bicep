targetScope = subscription

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

module TestWebSiteWithSqlBackEnd './resources/TestWebSiteWithSqlBackEnd/TestWebSiteWithSqlBackEnd.bicep' = {
  name: 'TestWebSiteWithSqlBackEnd'
  scope: resourceGroup_I6QNkoPsb
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

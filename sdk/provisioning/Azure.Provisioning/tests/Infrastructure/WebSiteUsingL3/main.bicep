targetScope = subscription

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource resourceGroup_IABVtvgDt 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-mnash-cdk'
  location: 'westus'
  tags: {
    azd-env-name: 'mnash-cdk'
    key: 'value'
  }
}

module TestWebSiteWithSqlBackEnd './resources/TestWebSiteWithSqlBackEnd/TestWebSiteWithSqlBackEnd.bicep' = {
  name: 'TestWebSiteWithSqlBackEnd'
  scope: resourceGroup_IABVtvgDt
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('SQL Server administrator login')
param adminLogin string

@secure()
@description('SQL Server administrator password')
param adminPassword string


resource sqlServer_Yt40VknQJ 'Microsoft.Sql/servers@2020-11-01-preview' = {
  name: toLower(take(concat('sqlserver', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    version: '12.0'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_qFhDi2oga 'Microsoft.Sql/servers/databases@2020-11-01-preview' = {
  parent: sqlServer_Yt40VknQJ
  name: 'db'
  location: location
  properties: {
  }
}

targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('SQL Server administrator login')
param adminLogin string

@secure()
@description('SQL Server administrator password')
param adminPassword string

@description('SQL Server administrator login')
param adminIdentityLogin string

@description('SQL Server administrator Object ID')
param adminObjectId string


resource sqlServer_Yt40VknQJ 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: toLower(take(concat('sqlserver', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    administrators: {
      administratorType: 'ActiveDirectory'
      login: adminIdentityLogin
      sid: adminObjectId
      tenantId: tenant().tenantId
    }
  }
}

resource sqlDatabase_qFhDi2oga 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_Yt40VknQJ
  name: 'db'
  location: location
  properties: {
  }
}

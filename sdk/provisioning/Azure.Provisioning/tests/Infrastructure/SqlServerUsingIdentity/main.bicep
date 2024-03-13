targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('SQL Server administrator login')
param adminLogin string

@description('SQL Server administrator Object ID')
param adminObjectId string


resource sqlServer_Yt40VknQJ 'Microsoft.Sql/servers@2021-11-01' = {
  name: toLower(take(concat('sqlserver', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    administrators: {
      administratorType: 'ActiveDirectory'
      login: adminLogin
      sid: adminObjectId
      tenantId: tenant().tenantId
    }
  }
}

resource sqlDatabase_qFhDi2oga 'Microsoft.Sql/servers/databases@2021-11-01' = {
  parent: sqlServer_Yt40VknQJ
  name: 'db'
  location: location
  properties: {
  }
}

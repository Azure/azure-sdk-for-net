targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('SQL Server administrator login')
param adminLogin string

@description('SQL Server administrator Object ID')
param adminObjectId string


resource sqlServer_DLIjdcaKF 'Microsoft.Sql/servers@2020-11-01-preview' = {
  name: toLower(take('sqlserver${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    version: '12.0'
    publicNetworkAccess: 'Enabled'
    administrators: {
      administratorType: 'ActiveDirectory'
      login: adminLogin
      sid: adminObjectId
      tenantId: tenant().tenantId
    }
  }
}

resource sqlDatabase_LkBQNoSaa 'Microsoft.Sql/servers/databases@2020-11-01-preview' = {
  parent: sqlServer_DLIjdcaKF
  name: 'db'
  location: location
  properties: {
  }
}

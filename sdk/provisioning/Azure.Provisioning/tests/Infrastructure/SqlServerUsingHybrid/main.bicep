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


resource sqlServer_DLIjdcaKF 'Microsoft.Sql/servers@2020-11-01-preview' = {
  name: toLower(take('sqlserver${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    version: '12.0'
    publicNetworkAccess: 'Enabled'
    administrators: {
      administratorType: 'ActiveDirectory'
      login: adminIdentityLogin
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

resource sqlFirewallRule_utDbw2Vvs 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_DLIjdcaKF
  name: 'fw'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

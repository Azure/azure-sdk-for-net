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


resource sqlServer_Yt40VknQJ 'Microsoft.Sql/servers@2020-11-01-preview' = {
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

resource sqlDatabase_qFhDi2oga 'Microsoft.Sql/servers/databases@2020-11-01-preview' = {
  parent: sqlServer_Yt40VknQJ
  name: 'db'
  location: location
  properties: {
  }
}

resource sqlFirewallRule_l3kW1XrET 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_Yt40VknQJ
  name: 'fw'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

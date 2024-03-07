targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param administratorLogin string

@secure()
@description('')
param administratorPassword string


resource sqlServer_iWTDw4HGr 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: toLower(take(concat('sql', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_WdzeeqGIM 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_iWTDw4HGr
  name: 'db'
  location: location
  properties: {
  }
}

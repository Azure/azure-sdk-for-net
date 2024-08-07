targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Administrator login')
param adminLogin string

@secure()
@description('Administrator password')
param adminPassword string


resource postgreSqlFlexibleServer_StT5lUao4 'Microsoft.DBforPostgreSQL/flexibleServers@2023-03-01-preview' = {
  name: toLower(take('postgres${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Standard_D4s_v3'
    tier: 'GeneralPurpose'
  }
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    version: ''
  }
}

resource postgreSqlFlexibleServerConfiguration_fuQyXsjrO 'Microsoft.DBforPostgreSQL/flexibleServers/configurations@2023-03-01-preview' = {
  parent: postgreSqlFlexibleServer_StT5lUao4
  name: 'azure.extensions'
  properties: {
    value: 'VECTOR'
    source: 'user-override'
  }
}

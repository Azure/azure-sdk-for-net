targetScope = 'resourceGroup'

@description('')
param keyVaultName string

@description('')
param location string = resourceGroup().location


resource keyVault_UEcuHY1Rh 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: keyVaultName
}

resource cosmosDBAccount_20A3gDQya 'Microsoft.DocumentDB/databaseAccounts@2023-04-15' = {
  name: toLower(take(concat('cosmosDB', uniqueString(resourceGroup().id)), 24))
  location: location
  kind: 'GlobalDocumentDB'
  properties: {
    databaseAccountOfferType: 'Standard'
    consistencyPolicy: {
      defaultConsistencyLevel: 'Session'
    }
    locations: [
      {
        locationName: location
        failoverPriority: 0
      }
    ]
  }
}

resource cosmosDBSqlDatabase_l1zQLmb4K 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2023-04-15' = {
  parent: cosmosDBAccount_20A3gDQya
  name: 'db'
  location: location
  properties: {
    resource: {
      id: 'db'
    }
  }
}

resource keyVaultSecret_q9NjpylOg 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_UEcuHY1Rh
  name: 'connectionString'
  location: location
  properties: {
    value: 'AccountEndpoint=${cosmosDBAccount_20A3gDQya.properties.documentEndpoint};AccountKey=${cosmosDBAccount_20A3gDQya.listkeys(cosmosDBAccount_20A3gDQya.apiVersion).primaryMasterKey}'
  }
}

targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


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
        id: 'westus'
      }
    ]
  }
}

resource cosmosDBSqlDatabase_l1zQLmb4K 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2022-05-15' = {
  parent: cosmosDBAccount_20A3gDQya
  name: 'db'
  location: location
  properties: {
    resource: {
      id: 'db'
    }
  }
}

resource keyVault_5t0GshPLB 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: toLower(take(concat('kv', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    tenantId: tenant().tenantId
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultSecret_R6AWfDGcA 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_5t0GshPLB
  name: 'connectionString'
  location: location
  properties: {
    value: 'AccountEndpoint=${cosmosDBAccount_20A3gDQya.properties.documentEndpoint};AccountKey=${cosmosDBAccount_20A3gDQya.listkeys(cosmosDBAccount_20A3gDQya.apiVersion).primaryMasterKey}'
  }
}

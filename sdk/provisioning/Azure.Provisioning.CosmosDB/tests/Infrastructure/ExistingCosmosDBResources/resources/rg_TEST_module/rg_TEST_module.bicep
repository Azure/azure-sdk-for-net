
resource cosmosDBAccount_YYHnVjsWQ 'Microsoft.DocumentDB/databaseAccounts@2023-04-15' existing = {
  name: 'cosmosDb'
}

resource cosmosDBSqlDatabase_HPAp4ft3Q 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2023-04-15' existing = {
  name: '${cosmosDBAccount_YYHnVjsWQ}/cosmosDb'
}

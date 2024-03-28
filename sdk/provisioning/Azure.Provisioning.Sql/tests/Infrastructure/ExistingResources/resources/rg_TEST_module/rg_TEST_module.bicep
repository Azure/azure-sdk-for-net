
resource sqlServer_O1efuGmrm 'Microsoft.Sql/servers@2020-11-01-preview' existing = {
  name: 'existingSqlServer'
}

resource sqlDatabase_m9ZmzLlHS 'Microsoft.Sql/servers/databases@2020-11-01-preview' existing = {
  name: '${sqlServer_O1efuGmrm}/existingSqlDatabase'
}

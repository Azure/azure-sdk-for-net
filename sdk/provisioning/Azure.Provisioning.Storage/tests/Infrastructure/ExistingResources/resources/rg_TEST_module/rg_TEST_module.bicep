
resource storageAccount_LhqOcwcwC 'Microsoft.Storage/storageAccounts@2022-09-01' existing = {
  name: 'existingStorage'
}

resource blobService_KtyZZZEH1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' existing = {
  name: '${storageAccount_LhqOcwcwC}/existingBlobService'
}

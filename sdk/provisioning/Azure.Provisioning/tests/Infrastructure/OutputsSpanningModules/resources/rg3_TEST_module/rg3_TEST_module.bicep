@description('Enable soft delete')
param enableSoftDelete string = 'True'

@description('')
param STORAGE_KIND string


resource storageAccount_UTndXtFYD 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('sa', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Standard_GRS'
  }
  kind: 'Storage'
  properties: {
  }
}

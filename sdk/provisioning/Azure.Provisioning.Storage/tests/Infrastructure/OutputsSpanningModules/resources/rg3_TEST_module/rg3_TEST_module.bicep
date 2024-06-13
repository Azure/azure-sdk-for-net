@description('Enable soft delete')
param enableSoftDelete string = 'True'

@description('')
param STORAGE_KIND string

@description('')
param PRIMARY_ENDPOINTS object


resource storageAccount_TtwZtKQQ1 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('sa${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  sku: {
    name: 'Standard_GRS'
  }
  kind: 'Storage'
  properties: {
    networkAcls: {
      defaultAction: 'Deny'
    }
  }
}

@description('')
param overrideLocation string


resource storageAccount_melvnlpF2 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource storageAccount_DysMV79Ig 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('sa1', uniqueString(resourceGroup().id)), 24))
  location: overrideLocation
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource storageAccount_I0kTuAmmD 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('sa2', uniqueString(resourceGroup().id)), 24))
  location: overrideLocation
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

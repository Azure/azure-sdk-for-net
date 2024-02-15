targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource appConfigurationStore_sgecYnln3 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'store-TEST'
  location: 'westus'
  sku: {
    name: 'free'
  }
  properties: {
  }
}

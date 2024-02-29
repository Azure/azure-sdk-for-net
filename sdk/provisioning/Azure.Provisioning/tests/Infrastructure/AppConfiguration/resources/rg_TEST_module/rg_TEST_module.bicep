
resource appConfigurationStore_sgecYnln3 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: 'store-TEST'
  location: 'westus'
  sku: {
    name: 'free'
  }
  properties: {
  }
}

output appConfigurationStore_sgecYnln3_endpoint string = appConfigurationStore_sgecYnln3.properties.endpoint

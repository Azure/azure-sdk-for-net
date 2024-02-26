
resource appConfigurationStore_kRqdpAmmZ 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: 'store-TEST'
  location: 'westus'
  sku: {
    name: 'free'
  }
  properties: {
  }
}

output appConfigurationStore_kRqdpAmmZ_endpoint string = appConfigurationStore_kRqdpAmmZ.properties.endpoint

targetScope = 'subscription'


resource resourceGroup_RKFHPNHNS 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

targetScope = 'subscription'

@description('')
param myLocationParam string


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: myLocationParam
  tags: {
    'azd-env-name': 'TEST'
  }
}

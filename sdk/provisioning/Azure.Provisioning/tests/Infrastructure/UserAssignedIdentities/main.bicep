targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource userAssignedIdentity_gswVmGJeD 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: toLower(take('useridentity${uniqueString(resourceGroup().id)}', 24))
  location: location
  properties: {
  }
}

@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

@description('The objectId of the current user principal.')
param principalId string

resource project_identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'cm0c420d2f21084cd'
  location: location
}

resource cm0c420d2f21084cd_hub 'Microsoft.MachineLearningServices/workspaces@2023-08-01-preview' = {
  name: 'cm0c420d2f21084cd_hub'
  location: location
  kind: 'hub'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    friendlyName: 'cm0c420d2f21084cd_hub'
    publicNetworkAccess: 'Enabled'
  }
}

resource cm0c420d2f21084cd_project 'Microsoft.MachineLearningServices/workspaces@2023-08-01-preview' = {
  name: 'cm0c420d2f21084cd_project'
  location: location
  kind: 'Project'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    friendlyName: 'cm0c420d2f21084cd_project'
    hubResourceId: cm0c420d2f21084cd_hub.id
    publicNetworkAccess: 'Enabled'
  }
}

output project_identity_id string = project_identity.id

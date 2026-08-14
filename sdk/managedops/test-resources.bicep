param location string = resourceGroup().location
param namePrefix string = 'managedops'

var logAnalyticsWorkspaceName = '${namePrefix}-law'
var azureMonitorWorkspaceName = '${namePrefix}-amw'
var userAssignedIdentityName = '${namePrefix}-uami'

resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
	name: logAnalyticsWorkspaceName
	location: location
	properties: {
		sku: {
			name: 'PerGB2018'
		}
	}
}

resource azureMonitorWorkspace 'Microsoft.Monitor/accounts@2023-04-03' = {
	name: azureMonitorWorkspaceName
	location: location
}

resource userAssignedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
	name: userAssignedIdentityName
	location: location
}

output logAnalyticsWorkspaceId string = logAnalyticsWorkspace.id
output azureMonitorWorkspaceId string = azureMonitorWorkspace.id
output userAssignedManagedIdentityId string = userAssignedIdentity.id

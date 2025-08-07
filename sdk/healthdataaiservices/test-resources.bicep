// "id": "/subscriptions/d12535ed-5958-4ce6-8350-b17b3af1d6b1/resourceGroups/oro-billing-exhaust-test/providers/Microsoft.HealthDataAIServices/DeidServices/deid-billing-test",
// "name": "deid-billing-test",
// "type": "microsoft.healthdataaiservices/deidservices",
// "location": "East US 2 EUAP",
// "tags": {},

@minLength(10)
param testApplicationOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string

param location string = resourceGroup().location

@description('The location of the resource. By default, this is the same as the resource group.')
param deidLocation string = 'eastus2'
param deidLocationShort string = 'eus2'

param deploymentTime string = utcNow('u')

var realtimeDataUserRoleId = 'bb6577c4-ea0a-40b2-8962-ea18cb8ecd4e'
var batchDataOwnerRoleId = '8a90fa6b-6997-4a07-8a95-30633a7c97b9'
var storageBlobDataContributor = 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'

var blobStorageName = take(toLower(replace('blob-${baseName}', '-', '')), 24)
var blobContainerName = 'container-${baseName}'
var deidServiceName = take('deid-${deidLocationShort}-${baseName}', 24)

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: blobStorageName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    minimumTlsVersion: 'TLS1_2'

    accessTier: 'Hot'
    supportsHttpsTrafficOnly: true
    allowBlobPublicAccess: false
    allowCrossTenantReplication: false
    allowSharedKeyAccess: false

    encryption: {
      services: {
        blob: {
          enabled: true
          keyType: 'Account'
        }
        file: {
          enabled: true
          keyType: 'Account'
        }
      }
      requireInfrastructureEncryption: true
      keySource: 'Microsoft.Storage'
    }

    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Deny'
      ipRules: [
        {
          action: 'Allow'
          value: '4.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '13.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '20.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '40.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '51.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '52.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '65.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '70.0.0.0/8'
        }
        {
          action: 'Allow'
          value: '74.234.0.0/16'
        }
        {
          action: 'Allow'
          value: '74.235.60.120/30'
        }
        {
          action: 'Allow'
          value: '94.245.0.0/16'
        }
        {
          action: 'Allow'
          value: '98.71.0.0/16'
        }
        {
          action: 'Allow'
          value: '102.133.0.0/16'
        }
        {
          action: 'Allow'
          value: '104.41.214.32/29'
        }
        {
          action: 'Allow'
          value: '104.44.0.0/16'
        }
        {
          action: 'Allow'
          value: '104.45.71.156/30'
        }
        {
          action: 'Allow'
          value: '104.208.0.0/12'
        }
        {
          action: 'Allow'
          value: '108.142.0.0/16'
        }
        {
          action: 'Allow'
          value: '131.107.0.0/16'
        }
        {
          action: 'Allow'
          value: '157.58.0.0/16'
        }
        {
          action: 'Allow'
          value: '167.220.0.0/16'
        }
        {
          action: 'Allow'
          value: '172.128.0.0/13'
        }
        {
          action: 'Allow'
          value: '191.234.97.0/26'
        }
        {
          action: 'Allow'
          value: '194.69.0.0/16'
        }
        {
          action: 'Allow'
          value: '207.46.0.0/16'
        }
      ]
    }
  }
}

resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  parent: storageAccount
  name: 'default'
}

resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  parent: blobService
  name: blobContainerName
}

resource storageRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  name: guid(resourceGroup().id, storageAccount.id, testApplicationOid, storageBlobDataContributor)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', storageBlobDataContributor)
    principalId: testApplicationOid
  }
  scope: storageAccount
}

resource testDeidService 'microsoft.healthdataaiservices/deidservices@2024-09-20' = {
  name: deidServiceName
  location: deidLocation
  identity: {
    type: 'SystemAssigned'
  }
}

resource storageMIRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  name: guid(resourceGroup().id, storageAccount.id, testDeidService.id, storageBlobDataContributor)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', storageBlobDataContributor)
    principalId: testDeidService.identity.principalId
  }
  scope: storageAccount
}

resource realtimeRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testApplicationOid, realtimeDataUserRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', realtimeDataUserRoleId)
    principalId: testApplicationOid
  }
}

resource batchRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testApplicationOid, batchDataOwnerRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', batchDataOwnerRoleId)
    principalId: testApplicationOid
  }
}

output HEALTHDATAAISERVICES_DEID_SERVICE_ENDPOINT string = testDeidService.properties.serviceUrl
output HEALTHDATAAISERVICES_STORAGE_ACCOUNT_NAME string = storageAccount.name
output HEALTHDATAAISERVICES_STORAGE_CONTAINER_NAME string = container.name

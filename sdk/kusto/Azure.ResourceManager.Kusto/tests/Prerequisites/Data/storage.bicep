param id string
param location string
param now string = utcNow()

var storageAccountName = 'sdkstorageaccount${id}'
var containerName = 'sdkcontainer${id}'

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
    name: storageAccountName
    location: location
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'

    resource blobService 'blobServices' = {
        name: 'default'

        resource container 'containers' = {
            name: containerName
        }
    }
}

output STORAGE_ACCOUNT_ID string = storageAccount.id
output STORAGE_ACCOUNT_SAS_TOKEN string = storageAccount.listAccountSAS('2022-05-01', {
    signedResourceTypes: 'o'
    signedPermission: 'r'
    signedServices: 'b'
    signedExpiry: dateTimeAdd(now, 'P5D')
}).accountSasToken


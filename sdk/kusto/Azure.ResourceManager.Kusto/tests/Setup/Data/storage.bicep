param id string
param location string

resource sdkStorageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
    name: 'sdkstorageaccount${id}'
    location: location
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'
}

resource sdkBlobService 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  parent: sdkStorageAccount
  name: 'default'
}

resource sdkContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
    parent: sdkBlobService
    name: 'sdkstoragecontainer${id}'
}

param fileName string = 'script.txt'
param fileContent string = loadTextContent('script.txt')

resource sdkUploadBlob 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
    name: 'sdkUploadBlob${id}'
    location: location
    kind: 'AzureCLI'
    properties: {
        azCliVersion: '2.40.0'
        environmentVariables: [
            {
                name: 'AZURE_STORAGE_ACCOUNT'
                value: sdkStorageAccount.name
            }
            {
                name: 'AZURE_STORAGE_KEY'
                secureValue: sdkStorageAccount.listKeys().keys[0].value
            }
            {
                name: 'FILE_CONTENT'
                value: fileContent
            }
        ]
        scriptContent: 'echo "$FILE_CONTENT" > ${fileName}; az storage blob upload -f ${fileName} -c ${sdkContainer.name} -n ${fileName}'
    }
}

param now string = utcNow()

output STORAGE_ACCOUNT_ID string = sdkStorageAccount.id
output SCRIPT_URI string = 'https://${sdkStorageAccount.name}.blob.core.windows.net/${sdkContainer.name}/${fileName}'
output SCRIPT_SAS_TOKEN string = sdkStorageAccount.listAccountSAS('2021-02-01', {
    signedResourceTypes: 'o'
    signedPermission: 'r'
    signedServices: 'b'
    signedExpiry: dateTimeAdd(now, 'PT24H')
}).accountSasToken

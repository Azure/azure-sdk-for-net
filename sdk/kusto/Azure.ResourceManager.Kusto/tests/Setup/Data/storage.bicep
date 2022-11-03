param id string
param location string

param now string = utcNow()

resource sdkStorageAccount 'Microsoft.Storage/storageAccounts@2021-02-01' = {
    name: 'sdk0storage0account${id}'
    location: location
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'
}

resource sdkContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-02-01' = {
    name: '${sdkStorageAccount.name}/default/sdk-storage-container${id}'
}

param fileName string = 'script.txt'
param fileContent string = loadTextContent('script.txt')
resource sdkUploadBlob 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
    name: 'sdkUploadBlob'
    location: location
    kind: 'AzureCLI'
    properties: {
        azCliVersion: '2.41.0'
        retentionInterval: 'PT1H'
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
        scriptContent: 'echo $FILE_CONTENT > ${fileName} && az storage blob upload -f ${fileName} -c ${sdkContainer.name} -n ${fileName}'
    }
}

output STORAGE_ACCOUNT_ID string = sdkStorageAccount.id
output SCRIPT_URI string = 'https://${sdkStorageAccount.name}.blob.core.windows.net/${sdkContainer.name}/${fileName}'
output SCRIPT_SAS_TOKEN string = sdkStorageAccount.listAccountSAS('2021-02-01', {
    signedResourceTypes: 'o'
    signedPermission: 'r'
    signedServices: 'b'
    signedExpiry: dateTimeAdd(now, 'PT24H')
}).accountSasToken

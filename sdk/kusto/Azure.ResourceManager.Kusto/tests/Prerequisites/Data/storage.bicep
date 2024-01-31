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

var deploymentScriptName = 'sdkDeploymentScript${id}'
var blobName = 'sdkBlob${id}.txt'
var tableName = 'sdkScriptUriTable${id}'

var blobUploadScript = '".create table ${tableName} (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)" > ${blobName}; az storage blob upload -f ${blobName} -c ${containerName} -n ${blobName}'
var storageAccountKey = storageAccount.listKeys().keys[0].value

resource deploymentScript 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
    name: deploymentScriptName
    location: location
    kind: 'AzureCLI'
    properties: {
        azCliVersion: '2.40.0'
        retentionInterval: 'P1D'
        environmentVariables: [
            {
                name: 'AZURE_STORAGE_ACCOUNT'
                value: storageAccountName
            }
            {
                name: 'AZURE_STORAGE_KEY'
                secureValue: storageAccountKey
            }
        ]
        scriptContent: blobUploadScript
    }
}

output SCRIPT_URI string = 'https://${storageAccountName}.blob.${environment().suffixes.storage}/${containerName}/${blobName}'

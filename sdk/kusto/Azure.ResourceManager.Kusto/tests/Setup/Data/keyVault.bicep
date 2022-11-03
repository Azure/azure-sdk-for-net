param id string
param location string

resource sdkUserAssignedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2018-11-30' = {
    name: 'sdkUserAssignedIdentity${id}'
    location: location
}

resource sdkKeyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
    name: 'sdkKeyVault${id}'
    location: location
    properties: {
        sku: {
            family: 'A'
            name: 'standard'
        }
        tenantId: tenant().tenantId
        accessPolicies: [
            {
                objectId: sdkUserAssignedIdentity.properties.principalId
                permissions: {
                    keys: ['all']
                }
                tenantId: tenant().tenantId
            }
        ]
        enableSoftDelete: false
    }
}

resource sdkKey 'Microsoft.KeyVault/vaults/keys@2022-07-01' = {
    parent: sdkKeyVault
    name: 'sdkKey${id}'
    properties: {
        kty: 'RSA'
        keySize: 2048
        attributes: {
            enabled: true
        }
    }
}

output USER_ASSIGNED_IDENTITY_ID string = sdkUserAssignedIdentity.id
output KEY_VAULT_URI string = sdkKeyVault.properties.vaultUri
output KEY_NAME string = sdkKey.name
output KEY_VERSION string = last(split(sdkKey.properties.keyUriWithVersion, '/'))

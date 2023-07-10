param id string
param location string
param cluster_object_id string

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
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
                objectId: cluster_object_id
                permissions: {
                    keys: [ 'get', 'list', 'wrapKey', 'unwrapKey' ]
                }
                tenantId: tenant().tenantId
            }
        ]
    }
}

resource key 'Microsoft.KeyVault/vaults/keys@2022-07-01' = {
    parent: keyVault
    name: 'sdkKey${id}'
    properties: {
        kty: 'RSA'
        keySize: 2048
        attributes: {
            enabled: true
        }
    }
}

output KEY_VAULT_URI string = keyVault.properties.vaultUri
output KEY_NAME string = key.name
output KEY_VERSION string = last(split(key.properties.keyUriWithVersion, '/'))


resource keyVault_78IwnSu6G 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: 'existingVault'
}

resource keyVaultSecret_ChWKOL5pG 'Microsoft.KeyVault/vaults/secrets@2022-07-01' existing = {
  name: '${keyVault_78IwnSu6G}/existingSecret'
}

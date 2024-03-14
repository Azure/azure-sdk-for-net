param location string = resourceGroup().location

@description('A signing account name to provision.')
@minLength(3)
@maxLength(15)
param accountName string

@description('A certificate profile to provision.')
@minLength(3)
@maxLength(15)
param profileName string

@description('The identity validation id to be use for the certificate profile provisioning.')
param identityValidationId string //'4931b0b1-c1d4-43a5-800e-259f7937220b'

@description('Profile type for the certificate profile creation.')
@allowed([
  'PublicTrust'
  'PrivateTrust'
  'PrivateTrustCIPolicy'
  'PublicTrustTest'
  'VBSEnclave'
])
param profileType string = 'PublicTrustTest'

resource account 'Microsoft.CodeSigning/codeSigningAccounts@2024-02-05-preview' = {
  location: location
  name: accountName
  properties: {
    sku: {
      name: 'Basic'
    }
  }
}

resource profile 'Microsoft.CodeSigning/codeSigningAccounts/certificateProfiles@2024-02-05-preview' = {
  parent: account
  name: profileName
  properties: {
    profileType: profileType
    identityValidationId:  identityValidationId
  }
}

output DEVSIGNING_REGION string = location
output DEVSIGNING_ACCOUNT_NAME string = account.name
output DEVSIGNING_PROFILE_NAME string = profile.name
output DEVSIGNING_ENDPOINT string = account.properties.accountUri

param location string = az.resourceGroup().location

@description('A signing account name to provision.')
@minLength(3)
@maxLength(15)
param accountName string = uniqueString(az.resourceGroup().id)

@description('A certificate profile to provision.')
@minLength(3)
@maxLength(15)
param profileName string = uniqueString(az.resourceGroup().id)

@description('The identity validation id to be use for the certificate profile provisioning.')
param identityValidationId string = 'f0bde931-daf1-497b-a4fa-789a4d9fc6c0'

//Short name regions
var shortLocation = {
  eastus: 'eus'
  centraluseuap: 'scus'
  northeurope: 'neu'
  westcentralus: 'wcus'
  westeurope: 'weu'
  westus: 'wus'
  westus2: 'wus2'
}

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

output DEVSIGNING_REGION string = shortLocation[toLower(replace(location, ' ', ''))]
output DEVSIGNING_ACCOUNT_NAME string = account.name
output DEVSIGNING_PROFILE_NAME string = profile.name
output DEVSIGNING_ENDPOINT string = account.properties.accountUri

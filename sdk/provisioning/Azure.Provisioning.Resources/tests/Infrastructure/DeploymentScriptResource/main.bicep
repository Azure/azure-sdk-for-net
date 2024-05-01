targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource deploymentScript_BNhoISG8r 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  name: 'script-TEST'
  location: location
  kind: 'AzureCLI'
  properties: {
    cleanupPreference: 'OnSuccess'
    scriptContent: 'echo $foo'
    environmentVariables: [
      {
        name: 'foo'
      }
    ]
    retentionInterval: 'PT1H'
    timeout: 'PT5M'
    azCliVersion: '2.37.0'
  }
}

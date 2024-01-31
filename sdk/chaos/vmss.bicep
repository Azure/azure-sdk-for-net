param location string = resourceGroup().location

param baseName string = resourceGroup().name

param adminUsername string = 'chaosadmin'

param vmssId string = '0'

@secure()
param adminPassword string = newGuid()

var MAX_LENGTH = 64
var vmssName = take('${baseName}-vmss-${location}-${vmssId}', MAX_LENGTH)

resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2020-07-01' = {
  name: '${vmssName}-nsg'
  location: location
  tags: {
    'NRMS-Info': 'http://aka.ms/nrms'
    'NRMS-Version': '2019-03-20'
  }
  properties: {}
}

resource networkSecurityGroupName_NRMS_Rule_102 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-102'
  parent: networkSecurityGroup
  properties: {
    description: 'Created by Azure Core Security managed policy, rule can be deleted but do not change source ips, please see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    destinationPortRange: '*'
    sourceAddressPrefix: 'CorpNetPublic'
    destinationAddressPrefix: '*'
    access: 'Allow'
    priority: 102
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: []
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_103 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-103'
  parent: networkSecurityGroup
  properties: {
    description: 'Default NRMS Corpnet rule, rule can be deleted but do not change source ips, please see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    destinationPortRange: '*'
    sourceAddressPrefix: 'CorpNetPublic'
    destinationAddressPrefix: '*'
    access: 'Allow'
    priority: 103
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: []
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_104 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-104'
  parent: networkSecurityGroup
  properties: {
    description: 'Created by Azure Core Security managed policy, rule can be deleted but do not change source ips, please see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    destinationPortRange: '*'
    sourceAddressPrefix: 'CorpNetSaw'
    destinationAddressPrefix: '*'
    access: 'Allow'
    priority: 104
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: []
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_105 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-105'
  parent: networkSecurityGroup
  properties: {
    description: 'DO NOT DELETE - Will result in ICM Sev 2 - Azure Core Security, see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    sourceAddressPrefix: 'Internet'
    destinationAddressPrefix: '*'
    access: 'Deny'
    priority: 105
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: [
      '1433'
      '1434'
      '3306'
      '4333'
      '5432'
      '6379'
      '7000'
      '7001'
      '7199'
      '9042'
      '9160'
      '9200'
      '9300'
      '16379'
      '26379'
      '27017'
    ]
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_106 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-106'
  parent: networkSecurityGroup
  properties: {
    description: 'DO NOT DELETE - Will result in ICM Sev 2 - Azure Core Security, see aka.ms/cainsgpolicy'
    protocol: 'Tcp'
    sourcePortRange: '*'
    sourceAddressPrefix: 'Internet'
    destinationAddressPrefix: '*'
    access: 'Deny'
    priority: 106
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: [
      '22'
      '3389'
    ]
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_107 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-107'
  parent: networkSecurityGroup
  properties: {
    description: 'DO NOT DELETE - Will result in ICM Sev 2 - Azure Core Security, see aka.ms/cainsgpolicy'
    protocol: 'Tcp'
    sourcePortRange: '*'
    sourceAddressPrefix: 'Internet'
    destinationAddressPrefix: '*'
    access: 'Deny'
    priority: 107
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: [
      '23'
      '135'
      '445'
      '5985'
      '5986'
    ]
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_108 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-108'
  parent: networkSecurityGroup
  properties: {
    description: 'DO NOT DELETE - Will result in ICM Sev 2 - Azure Core Security, see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    sourceAddressPrefix: 'Internet'
    destinationAddressPrefix: '*'
    access: 'Deny'
    priority: 108
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: [
      '13'
      '17'
      '19'
      '53'
      '69'
      '111'
      '123'
      '512'
      '514'
      '593'
      '873'
      '1900'
      '5353'
      '11211'
    ]
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource networkSecurityGroupName_NRMS_Rule_109 'Microsoft.Network/networkSecurityGroups/securityRules@2021-05-01' = {
  name: 'NRMS-Rule-109'
  parent: networkSecurityGroup
  properties: {
    description: 'DO NOT DELETE - Will result in ICM Sev 2 - Azure Core Security, see aka.ms/cainsgpolicy'
    protocol: '*'
    sourcePortRange: '*'
    sourceAddressPrefix: 'Internet'
    destinationAddressPrefix: '*'
    access: 'Deny'
    priority: 109
    direction: 'Inbound'
    sourcePortRanges: []
    destinationPortRanges: [
      '119'
      '137'
      '138'
      '139'
      '161'
      '162'
      '389'
      '636'
      '2049'
      '2301'
      '2381'
      '3268'
      '5800'
      '5900'
    ]
    sourceAddressPrefixes: []
    destinationAddressPrefixes: []
  }
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2020-06-01' = {
  name: '${vmssName}-vnet'
  location: location
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.0.0.0/16'
      ]
    }
    subnets: [
      {
        name: '${vmssName}-subnet'
        properties: {
          addressPrefix: '10.0.0.0/24'
          networkSecurityGroup: {
            id: networkSecurityGroup.id
          }
          serviceEndpoints: []
          delegations: []
          privateEndpointNetworkPolicies: 'Enabled'
          privateLinkServiceNetworkPolicies: 'Enabled'
        }
      }
    ]
  }
}

resource vmss 'Microsoft.Compute/virtualMachineScaleSets@2020-12-01' = {
  name: vmssName
  location: location
  sku: {
    name: 'Standard_B2s'
    tier: 'Standard'
    capacity: 2
  }
  properties: {
    overprovision: false
    upgradePolicy: {
      automaticOSUpgradePolicy: {
        enableAutomaticOSUpgrade: true
      }
      mode: 'Automatic'
    }
    virtualMachineProfile: {
      osProfile: {
        computerNamePrefix: 'node'
        adminUsername: adminUsername
        adminPassword: adminPassword
        windowsConfiguration: {
          enableAutomaticUpdates: false
          provisionVMAgent: true
        }
        secrets: []
      }
      storageProfile: {
        imageReference: {
          publisher: 'MicrosoftWindowsServer'
          offer: 'WindowsServer'
          sku: '2019-Datacenter-GS'
          version: 'latest'
        }
        osDisk: {
          osType: 'Windows'
          createOption: 'FromImage'
          diskSizeGB: 127
          managedDisk: {
            storageAccountType: 'Standard_LRS'
          }
        }
      }
      extensionProfile: {
        extensions: [
          {
            name: 'healthRepairExtension'
            properties: {
              autoUpgradeMinorVersion: true
              publisher: 'Microsoft.ManagedServices'
              type: 'ApplicationHealthWindows'
              typeHandlerVersion: '1.0'
              settings: {
                protocol: 'tcp'
                port: 135
              }
            }
          }
        ]
      }
      networkProfile: {
        networkInterfaceConfigurations: [
          {
            name: 'nic'
            properties: {
              primary: true
              ipConfigurations: [
                {
                  name: 'ipconfig'
                  properties: {
                    subnet: {
                      id: resourceId('Microsoft.Network/virtualNetworks/subnets', virtualNetwork.name, virtualNetwork.properties.subnets[0].name)
                    }
                    loadBalancerBackendAddressPools: []
                    loadBalancerInboundNatPools: []
                  }
                }
              ]
            }
          }
        ]
      }
      licenseType: 'Windows_Server'
    }
  }
}

// Target/Capability Resources

resource serviceDirectTarget 'Microsoft.Chaos/targets@2021-09-15-preview' = {
  name: 'Microsoft-VirtualMachineScaleSet'
  scope: vmss
  properties: {}
}

resource shutdownCapability 'Microsoft.Chaos/targets/capabilities@2021-09-15-preview' = {
  name: '${serviceDirectTarget.name}/Shutdown-1.0'
  scope: vmss
}

resource shutdownCapabilityV2 'Microsoft.Chaos/targets/capabilities@2022-10-01-preview' = {
  name: '${serviceDirectTarget.name}/Shutdown-2.0'
  scope: vmss
}

resource experiment 'Microsoft.Chaos/experiments@2022-10-01-preview' = {
  name: 'sdktest-chaos-execution-${vmssId}'
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    steps: [
      {
        name: 'Step1'
        branches: [
          {
            name: 'Branch1'
            actions: [
              {
                type: 'continuous'
                name: shutdownCapabilityV2.properties.urn
                duration: 'PT2M'
                selectorId: 'Selector1'
                parameters: [
                  {
                    key: 'abruptShutdown'
                    value: 'false'
                  }
                ]
              }
            ]
          }
        ]
      }
    ]
    selectors: [
      {
        id: 'Selector1'
        type: 'List'
        targets: [
          {
            type: 'ChaosTarget'
            id: serviceDirectTarget.id
          }
        ]
      }
    ]
  }
}

// Role Assignment

var virtualMachineContributorRoleId = '9980e02c-c2be-4d73-94e8-173b1dc7cf3c'
resource roleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(virtualMachineContributorRoleId, toUpper(vmss.id), vmssId, toUpper(experiment.id))
  scope: vmss
  properties: {
    principalId: experiment.identity.principalId
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', virtualMachineContributorRoleId)
    principalType: 'ServicePrincipal'
  }
}

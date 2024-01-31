@minLength(12)
@secure()
param adminPassword string
param adminUsername string = 'testUser'
param location string = 'eastus'
param vmName string = 'test-vm'

var nicName = '${vmName}-NetworkInterface'
var virtualNetworkName = '${vmName}-VirtualNetwork'
var subnetName = '${virtualNetworkName}-Subnet'

resource vn 'Microsoft.Network/virtualNetworks@2021-02-01' = {
    name: virtualNetworkName
    location: location
    properties: {
        addressSpace: {
            addressPrefixes: [
                '10.0.0.0/16'
            ]
        }
        subnets: [
            {
                name: subnetName
                properties: {
                    addressPrefix: '10.0.0.0/24'
                }
            }
        ]
    }
}

resource nic 'Microsoft.Network/networkInterfaces@2021-02-01' = {
    name: nicName
    location: location
    properties: {
        ipConfigurations: [
            {
                name: 'ipconfig1'
                properties: {
                    privateIPAllocationMethod: 'Dynamic'
                    subnet: {
                        id: resourceId('Microsoft.Network/virtualNetworks/subnets', vn.name, subnetName)
                    }
                }
            }
        ]
    }
}

resource vm 'Microsoft.Compute/virtualMachines@2021-03-01' = {
    name: vmName
    location: location
    properties: {
        hardwareProfile: {
            vmSize: 'Standard_B1s'
        }
        osProfile: {
            computerName: vmName
            adminUsername: adminUsername
            adminPassword: adminPassword
        }
        storageProfile: {
            imageReference: {
                publisher: 'MicrosoftWindowsDesktop'
                offer: 'Windows-10'
                sku: 'win10-21h2-pro'
                version: 'latest'
            }
            osDisk: {
                createOption: 'FromImage'
                managedDisk: {
                    storageAccountType: 'StandardSSD_LRS'
                }
            }
        }
        networkProfile: {
            networkInterfaces: [
                {
                    id: nic.id
                }
            ]
        }
    }
}

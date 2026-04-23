// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerInstance.Tests;

public class BasicContainerInstanceTests
{
    internal static Trycep CreateLinuxContainerGroupTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ContainerInstanceBasic
                Infrastructure infra = new();

                ProvisioningParameter image =
                    new(nameof(image), typeof(string))
                    {
                        Value = "mcr.microsoft.com/azuredocs/aci-helloworld",
                        Description = "Container image to deploy.",
                    };
                infra.Add(image);

                ProvisioningParameter port =
                    new(nameof(port), typeof(int))
                    {
                        Value = 80,
                        Description = "Port to open on the container and the public IP address.",
                    };
                infra.Add(port);

                ContainerGroup containerGroup =
                    new(nameof(containerGroup), ContainerGroup.ResourceVersions.V2025_09_01)
                    {
                        ContainerGroupOSType = ContainerInstanceOperatingSystemType.Linux,
                        RestartPolicy = ContainerGroupRestartPolicy.Always,
                        IPAddress = new ContainerGroupIPAddress
                        {
                            AddressType = ContainerGroupIPAddressType.Public,
                            Ports =
                            {
                                new ContainerGroupPort { Port = port, Protocol = ContainerGroupNetworkProtocol.Tcp }
                            },
                        },
                        Containers =
                        {
                            new ContainerInstanceContainer
                            {
                                Name = "helloworld",
                                Image = image,
                                Ports =
                                {
                                    new ContainerPort { Port = port, Protocol = ContainerNetworkProtocol.Tcp }
                                },
                                Resources = new ContainerResourceRequirements
                                {
                                    Requests = new ContainerResourceRequestsContent
                                    {
                                        Cpu = 1,
                                        MemoryInGB = 1.5,
                                    },
                                },
                            }
                        },
                    };
                infra.Add(containerGroup);

                infra.Add(new ProvisioningOutput("containerIPv4Address", typeof(string)) { Value = containerGroup.IPAddress.IP });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.containerinstance/aci-linuxcontainer-public-ip/main.bicep")]
    public async Task CreateLinuxContainerGroup()
    {
        await using Trycep test = CreateLinuxContainerGroupTest();
        test.Compare(
            """
            @description('Container image to deploy.')
            param image string = 'mcr.microsoft.com/azuredocs/aci-helloworld'

            @description('Port to open on the container and the public IP address.')
            param port int = 80

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource containerGroup 'Microsoft.ContainerInstance/containerGroups@2025-09-01' = {
              name: take('containergroup${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                containers: [
                  {
                    name: 'helloworld'
                    properties: {
                      image: image
                      ports: [
                        {
                          protocol: 'TCP'
                          port: port
                        }
                      ]
                      resources: {
                        requests: {
                          memoryInGB: json('1.5')
                          cpu: 1
                        }
                      }
                    }
                  }
                ]
                restartPolicy: 'Always'
                ipAddress: {
                  ports: [
                    {
                      protocol: 'TCP'
                      port: port
                    }
                  ]
                  type: 'Public'
                }
                osType: 'Linux'
              }
            }

            output containerIPv4Address string = containerGroup.properties.ipAddress.ip
            """);
    }
}
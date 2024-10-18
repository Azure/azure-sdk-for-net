// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using Microsoft.Win32;
using NUnit.Framework;

namespace Azure.Provisioning.ContainerService.Tests;

public class BasicContainerServiceTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.kubernetes/aks/main.bicep")]
    public async Task CreateAksCluster()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter dnsPrefix = new(nameof(dnsPrefix), typeof(string));
                infra.Add(dnsPrefix);

                ProvisioningParameter linuxAdminUsername = new(nameof(linuxAdminUsername), typeof(string));
                infra.Add(linuxAdminUsername);

                ProvisioningParameter sshRsaPublicKey = new(nameof(sshRsaPublicKey), typeof(string));
                infra.Add(sshRsaPublicKey);

                ContainerServiceManagedCluster aks =
                    new(nameof(aks))
                    {
                        ClusterIdentity = new ManagedClusterIdentity { ResourceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        DnsPrefix = dnsPrefix,
                        LinuxProfile =
                            new ContainerServiceLinuxProfile
                            {
                                AdminUsername = linuxAdminUsername,
                                SshPublicKeys =
                                {
                                    new ContainerServiceSshPublicKey { KeyData = sshRsaPublicKey }
                                }
                            },
                        AgentPoolProfiles =
                        {
                            new ManagedClusterAgentPoolProfile
                            {
                                Name = "agentpool",
                                VmSize = "standard_d2s_v3",
                                OSDiskSizeInGB = 0, // 0 means default disk size for that agent
                                Count = 3,
                                OSType = ContainerServiceOSType.Linux,
                                Mode = AgentPoolMode.System
                            }
                        }
                    };
                infra.Add(aks);

                return infra;
            })
        .Compare(
            """
            param dnsPrefix string

            param linuxAdminUsername string

            param sshRsaPublicKey string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource aks 'Microsoft.ContainerService/managedClusters@2024-08-01' = {
              name: take('aks-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                agentPoolProfiles: [
                  {
                    name: 'agentpool'
                    count: 3
                    vmSize: 'standard_d2s_v3'
                    osDiskSizeGB: 0
                    osType: 'Linux'
                    mode: 'System'
                  }
                ]
                dnsPrefix: dnsPrefix
                linuxProfile: {
                  adminUsername: linuxAdminUsername
                  ssh: {
                    publicKeys: [
                      {
                        keyData: sshRsaPublicKey
                      }
                    ]
                  }
                }
              }
              identity: {
                type: 'SystemAssigned'
              }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}

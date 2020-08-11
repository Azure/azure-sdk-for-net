// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using SqlVirtualMachine.Tests;
using static Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities.VirtualMachineTestBase;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public static class SqlVirtualMachineTestBase
    {
        public static void ValidateSqlVirtualMachine(SqlVirtualMachineModel sqlVM1, SqlVirtualMachineModel sqlVM2, bool sameTags = true)
        {
            Assert.Equal(sqlVM1.Id, sqlVM2.Id);
            Assert.Equal(sqlVM1.Name, sqlVM2.Name);
            Assert.Equal(sqlVM1.Location, sqlVM2.Location);
            Assert.Equal(sqlVM1.SqlManagement, sqlVM2.SqlManagement);
            if (sameTags)
            {
                Assert.True(ValidateTags(sqlVM1, sqlVM2));
            }
        }

        public static void ValidateSqlVirtualMachineGroups(SqlVirtualMachineGroup group1, SqlVirtualMachineGroup group2, bool sameTags = true)
        {
            Assert.Equal(group1.Id, group2.Id);
            Assert.Equal(group1.Name, group2.Name);
            Assert.Equal(group1.SqlImageOffer, group2.SqlImageOffer);
            if (sameTags)
            {
                Assert.True(ValidateTags(group1, group2));
            }
        }

        public static void ValidateAGListener(AvailabilityGroupListener listener1, AvailabilityGroupListener  listener2)
        {
            Assert.Equal(listener1.Id, listener2.Id);
            Assert.Equal(listener1.Name, listener2.Name);
            Assert.Equal(listener1.Port, listener2.Port);
            Assert.Equal(listener1.ProvisioningState, listener2.ProvisioningState);
        }

        public static bool ValidateTags(SqlVirtualMachineGroup group1, SqlVirtualMachineGroup group2)
        {
            return ValidateTags(group1.Tags, group2.Tags);
        }

        public static bool ValidateTags(SqlVirtualMachineModel sqlVM1, SqlVirtualMachineModel sqlVM2)
        {
            return ValidateTags(sqlVM1.Tags, sqlVM2.Tags);
        }

        public static bool ValidateTags(IDictionary<string, string> tags1, IDictionary<string, string> tags2)
        {
            if (tags1 == null && tags2 == null)
            {
                return true;
            }
                
            if (tags1 == null || tags2 == null || tags1.Count != tags2.Count)
            {
                return false;
            }

            foreach (string s in tags1.Keys)
            {
                if (!tags2.ContainsKey(s) || !tags1[s].Equals(tags2[s]))
                {
                    return false;
                }
            }
            
            return true;
        }

        public static SqlVirtualMachineModel CreateSqlVirtualMachine(SqlVirtualMachineTestContext context, SqlVirtualMachineGroup group = null, VirtualMachine virtualMachine = null)
        {
            ISqlVirtualMachinesOperations sqlOperations = context.getSqlClient().SqlVirtualMachines;
            VirtualMachine vm = virtualMachine == null? VirtualMachineTestBase.CreateVM(context) : virtualMachine;

            SqlVirtualMachineModel sqlVM = sqlOperations.CreateOrUpdate(context.resourceGroup.Name, vm.Name, new SqlVirtualMachineModel()
            {
                Location = context.location,
                VirtualMachineResourceId = vm.Id,
                SqlServerLicenseType = SqlServerLicenseType.PAYG,
                SqlManagement = SqlManagementMode.Full,
                SqlImageSku = Constants.imageSku,
                SqlImageOffer = Constants.imageOffer,
                SqlVirtualMachineGroupResourceId = (group != null) ? group.Id : null,
                ServerConfigurationsManagementSettings = new ServerConfigurationsManagementSettings()
                {
                    SqlConnectivityUpdateSettings = new SqlConnectivityUpdateSettings()
                    {
                        SqlAuthUpdateUserName = Constants.sqlLogin,
                        SqlAuthUpdatePassword = Constants.adminPassword,
                        ConnectivityType = "Private",
                        Port = 1433
                    },
                    SqlStorageUpdateSettings = new SqlStorageUpdateSettings()
                    {
                        DiskCount = 1,
                        DiskConfigurationType = "NEW",
                        StartingDeviceId = 2
                    },
                    SqlWorkloadTypeUpdateSettings = new SqlWorkloadTypeUpdateSettings()
                    {
                        SqlWorkloadType = "OLTP"
                    }
                },
                AutoPatchingSettings = new AutoPatchingSettings(false)
            });
            sqlVM.Validate();
            return sqlVM;
        }

        public static SqlVirtualMachineGroup CreateSqlVirtualMachineGroup(SqlVirtualMachineTestContext context, StorageAccount storageAccount, string groupName = null, WsfcDomainProfile profile = null)
        {
            ISqlVirtualMachineGroupsOperations sqlOperations = context.getSqlClient().SqlVirtualMachineGroups;
            StorageAccountListKeysResult storageAccountKeys = context.client.storageClient.StorageAccounts.ListKeys(context.resourceGroup.Name, storageAccount.Name);
            IEnumerator<StorageAccountKey> iter = storageAccountKeys.Keys.GetEnumerator();
            iter.MoveNext();
            string key = iter.Current.Value;
            string blobAccount = storageAccount.PrimaryEndpoints.Blob;
            if(groupName == null)
            {
                groupName = context.generateResourceName();
            }
            SqlVirtualMachineGroup group = sqlOperations.CreateOrUpdate(context.resourceGroup.Name, groupName, new SqlVirtualMachineGroup
            {
                Location = context.location,
                SqlImageOffer = Constants.imageOffer,
                SqlImageSku = Constants.imageSku,
                WsfcDomainProfile = (profile != null)? profile : new WsfcDomainProfile
                {
                    SqlServiceAccount = getUsername(Constants.sqlService, Constants.domainName),
                    ClusterOperatorAccount = getUsername(Constants.adminLogin, Constants.domainName),
                    DomainFqdn = Constants.domainName + ".com",
                    StorageAccountUrl = blobAccount,
                    StorageAccountPrimaryKey = key
                }
            });
            group.Validate();
            return group;
        }

        public static AvailabilityGroupListener CreateAGListener(SqlVirtualMachineTestContext context, string agListenerName, string groupName)
        {
            MockClient client = context.client;

            string domainName = Constants.domainName;
            string adminLogin = Constants.adminLogin;
            string adminPassword = Constants.adminPassword;

            // Create domain
            NetworkSecurityGroup nsg = CreateNsg(context);
            VirtualNetwork vnet = CreateVirtualNetwork(context, networkSecurityGroup: nsg);
            NetworkInterface nic = CreateNetworkInterface(context, virtualNetwork: vnet, networkSecurityGroup: nsg);
            VirtualMachine vm = CreateVM(context, nic: nic);
            VirtualMachineExtension domain = CreateDomain(context, vm, domainName, adminLogin, adminPassword);
            Assert.NotNull(domain);

            // Update DNS
            Subnet subnet = vnet.Subnets[0]; 
            UpdateVnetDNS(context, vnet, nsg, nic, subnet);
            
            // Create SqlVirtualMachineGroup
            StorageAccount storageAccount = CreateStorageAccount(context);
            StorageAccountListKeysResult storageAccountKeys = client.storageClient.StorageAccounts.ListKeys(context.resourceGroup.Name, storageAccount.Name);
            IEnumerator<StorageAccountKey> iter = storageAccountKeys.Keys.GetEnumerator();
            iter.MoveNext();
            string key = iter.Current.Value;
            WsfcDomainProfile profile = new WsfcDomainProfile()
            {
                ClusterBootstrapAccount = getUsername(adminLogin, domainName),
                ClusterOperatorAccount = getUsername(adminLogin, domainName),
                SqlServiceAccount = getUsername(Constants.sqlService, domainName),
                StorageAccountUrl = "https://" + storageAccount.Name + ".blob.core.windows.net/",
                StorageAccountPrimaryKey = key,
                DomainFqdn = domainName + ".com",
                OuPath = ""
            };
            SqlVirtualMachineGroup group = CreateSqlVirtualMachineGroup(context, storageAccount, groupName: groupName, profile: profile);

            // Create availability set
            AvailabilitySet availabilitySet = client.computeClient.AvailabilitySets.CreateOrUpdate(context.resourceGroup.Name, context.generateResourceName(), new AvailabilitySet()
            {
                Location = context.location,
                PlatformFaultDomainCount = 3,
                PlatformUpdateDomainCount = 2,
                Sku = new Microsoft.Azure.Management.Compute.Models.Sku
                {
                    Name = "Aligned"
                }
            });

            // Create two sql virtual machines
            NetworkInterface nic1 = CreateNetworkInterface(context, virtualNetwork: vnet);
            NetworkInterface nic2 = CreateNetworkInterface(context, virtualNetwork: vnet);

            VirtualMachine vm1 = CreateVM(context, nic: nic1, availabilitySet: availabilitySet);
            VirtualMachine vm2 = CreateVM(context, nic: nic2, availabilitySet: availabilitySet);

            SqlVirtualMachineModel sqlVM1 = prepareMachine(context, group, vm1, domainName, adminLogin, adminPassword);
            SqlVirtualMachineModel sqlVM2 = prepareMachine(context, group, vm2, domainName, adminLogin, adminPassword);
            
            // Create load balancer
            LoadBalancer loadBalancer = client.networkClient.LoadBalancers.CreateOrUpdate(context.resourceGroup.Name, context.generateResourceName(), new LoadBalancer()
            {
                Location = context.location,
                Sku = new LoadBalancerSku("Basic"),
                FrontendIPConfigurations = new List<FrontendIPConfiguration> (new FrontendIPConfiguration[]
                {
                    new FrontendIPConfiguration()
                    {
                        Name = "LoadBalancerFrontEnd",
                        PrivateIPAllocationMethod = "Dynamic",
                        Subnet = subnet
                    }
                })
            });
            
            // Run deployment to create an availability group with the two machines created
            string AgName = "AvGroup";
            VirtualMachineExtension availabilityGroup = context.client.computeClient.VirtualMachineExtensions.CreateOrUpdate(context.resourceGroup.Name, vm1.Name, "agCreation", new VirtualMachineExtension(context.location, name: AgName)
            {
                VirtualMachineExtensionType = "CustomScriptExtension",

                Publisher = "Microsoft.Compute",
                TypeHandlerVersion = "1.9",
                AutoUpgradeMinorVersion = true,

                Settings = new CustomScriptExtensionSettings
                {
                    FileUris = new List<string>(new string[] {
                        "https://agtemplatestorage.blob.core.windows.net/templates/Deploy.ps1",
                        "https://agtemplatestorage.blob.core.windows.net/templates/sqlvm6.sql",
                        "https://agtemplatestorage.blob.core.windows.net/templates/sqlvm7.sql",
                        "https://agtemplatestorage.blob.core.windows.net/templates/sqlvm8.sql",
                        "https://agtemplatestorage.blob.core.windows.net/test/sqlvm9.sql",
                        "https://agtemplatestorage.blob.core.windows.net/templates/sqlvm10.sql"
                    }),
                    CommandToExecute = "powershell -ExecutionPolicy Unrestricted -File Deploy.ps1 " + AgName + " " + vm1.Name + " " + vm2.Name + " " + Constants.sqlLogin + " " + adminPassword + " " + domainName + "\\" + Constants.sqlService,
                    ContentVersion = "1.0.0.0"
                }
            });
            
            // Create availability group listener
            return context.getSqlClient().AvailabilityGroupListeners.CreateOrUpdate(context.resourceGroup.Name, group.Name, agListenerName, new AvailabilityGroupListener()
            {
                LoadBalancerConfigurations = new List<LoadBalancerConfiguration>(new LoadBalancerConfiguration[]
                {
                    new LoadBalancerConfiguration()
                    {
                        PrivateIpAddress = new PrivateIPAddress(ipAddress: "10.0.0.11", subnetResourceId: subnet.Id),
                        ProbePort = 59999,
                        LoadBalancerResourceId = loadBalancer.Id,
                        SqlVirtualMachineInstances = new List<string>() { sqlVM1.Id, sqlVM2.Id }
                    }
                }),
                AvailabilityGroupName = AgName,
                Port = 1433
            });
        }

        public static void UpdateVnetDNS(SqlVirtualMachineTestContext context, VirtualNetwork vnet, NetworkSecurityGroup nsg, NetworkInterface nic, Subnet subnet)
        {
            context.client.resourceManagerClient.Deployments.CreateOrUpdate(context.resourceGroup.Name, "UpdateVNetDNS", new Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = DeploymentMode.Incremental,
                    TemplateLink = new TemplateLink
                    {
                        Uri = "https://strdstore.blob.core.windows.net/test/DNSserver.json",
                        ContentVersion = "1.0.0.0"
                    },
                    Parameters = new DeploymentParameters()
                    {
                        Location = new Parameter(context.location),
                        NetworkSecurityGroupName = new Parameter(nsg.Name),
                        VirtualNetworkName = new Parameter(vnet.Name),
                        VirtualNetworkAddressRange = new Parameter(vnet.AddressSpace.AddressPrefixes[0]),
                        SubnetName = new Parameter(subnet.Name),
                        SubnetRange = new Parameter(subnet.AddressPrefix),
                        DNSServerAddress = new ParameterList(new string[] { nic.IpConfigurations[0].PrivateIPAddress })
                    }
                }
            });
        }

        private static SqlVirtualMachineModel prepareMachine(SqlVirtualMachineTestContext context, SqlVirtualMachineGroup group, VirtualMachine vm, string domain, string login, string password)
        {
            // Create the sql virtual machine
            SqlVirtualMachineModel sqlVM = CreateSqlVirtualMachine(context, virtualMachine: vm);

            // Join domain
            IVirtualMachineExtensionsOperations operations = context.client.computeClient.VirtualMachineExtensions;
            VirtualMachineExtension joinDomain = operations.CreateOrUpdate(context.resourceGroup.Name, vm.Name, "joindomain", new VirtualMachineExtension()
            {
                Location = context.location,
                Publisher = "Microsoft.Compute",
                VirtualMachineExtensionType = "JsonADDomainExtension",
                TypeHandlerVersion = "1.3",
                AutoUpgradeMinorVersion = true,
                Settings = new JoinDomainSettings()
                {
                    Name = domain + ".com",
                    OUPath = "",
                    User = domain + "\\" + login,
                    Restart = "true",
                    Options = "3"
                },
                ProtectedSettings = new JoinDomainProtectedSettings()
                {
                    Password = password
                }
            });

            // Join sql virtual machine group 
            context.getSqlClient().SqlVirtualMachines.CreateOrUpdate(context.resourceGroup.Name, sqlVM.Name, new SqlVirtualMachineModel()
            {
                Location = context.location,
                SqlVirtualMachineGroupResourceId = group.Id,
                VirtualMachineResourceId = sqlVM.VirtualMachineResourceId,
                WsfcDomainCredentials = new WsfcDomainCredentials()
                {
                    ClusterBootstrapAccountPassword = password,
                    ClusterOperatorAccountPassword = password,
                    SqlServiceAccountPassword = password
                }
            });

            return sqlVM;
        }

        private static string getUsername(string username, string domain)
        {
            return username + "@" + domain + ".com";
        }
    }
}

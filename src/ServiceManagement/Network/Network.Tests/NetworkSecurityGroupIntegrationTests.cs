using System;
using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Testing;
using Xunit;

namespace Network.Tests
{
    public class NetworkSecurityGroupIntegrationTests
    {
        #region NetworkSecurityGroups

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestCreateNetworkSecurityGroupWithNullNameFails()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    const string securityGroupName = null;
                    const string securityGroupLabel = null;
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    try
                    {
                        _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    }

                    // assert
                    catch (ArgumentNullException ane)
                    {
                        Assert.Contains("parameters.Name", ane.Message);
                        // succeed
                        return;
                    }
                }

                // fail if the above call succeeded
                Assert.True(false);
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestCreateNetworkSecurityGroupSucceeds()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null);
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                }
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestCreateNetworkSecurityGroupFullDetailsSucceeds()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                    // Default rules
                    Assert.NotEmpty(response.Rules);
                }
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestListNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    int networkSecurityGroupCount = _testFixture.NetworkClient.NetworkSecurityGroups.List().Count();
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    var response = _testFixture.NetworkClient.NetworkSecurityGroups.List();

                    // assert
                    Assert.Equal(networkSecurityGroupCount + 1, response.Count());
                }
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestDeleteNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    NetworkSecurityGroupGetResponse getResponse = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null);

                    Assert.Equal(securityGroupName, getResponse.Name);

                    var beforeDeletionListResponse = _testFixture.NetworkClient.NetworkSecurityGroups.List();

                    // action
                    _testFixture.DeleteNetworkSecurityGroup(securityGroupName);

                    // assert
                    Assert.Throws<CloudException>(() => _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null));

                    var afterDeletionListResponse = _testFixture.NetworkClient.NetworkSecurityGroups.List();
                    Assert.Equal(beforeDeletionListResponse.NetworkSecurityGroups.Count, afterDeletionListResponse.NetworkSecurityGroups.Count + 1);
                }
            }
        }
        #endregion

        #region NetworkSecurityRules

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void TestSetAndDeleteNetworkSecurityRule()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;
                    string ruleName = _testFixture.GenerateRandomName();
                    string action = "Allow";
                    string sourceAddressPrefix = "*";
                    string sourcePortRange = "*";
                    string destinationAddressPrefix = "*";
                    string destinationPortRange = "*";
                    int priority = 500;
                    string protocol = "TCP";
                    string type = "Inbound";

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    _testFixture.SetRuleToSecurityGroup(
                        securityGroupName,
                        ruleName,
                        action,
                        sourceAddressPrefix,
                        sourcePortRange,
                        destinationAddressPrefix,
                        destinationPortRange,
                        priority,
                        protocol,
                        type);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                    Assert.NotEmpty(response.Rules.Where(r => string.Equals(r.Name, ruleName)));

                    NetworkSecurityRule rule = response.Rules.First();
                    Assert.Equal(ruleName, rule.Name);
                    Assert.Equal(sourceAddressPrefix, rule.SourceAddressPrefix);
                    Assert.Equal(sourcePortRange, rule.SourcePortRange);
                    Assert.Equal(destinationAddressPrefix, rule.DestinationAddressPrefix);
                    Assert.Equal(destinationPortRange, rule.DestinationPortRange);
                    Assert.Equal(priority, rule.Priority);
                    Assert.Equal(protocol, rule.Protocol);
                    Assert.Equal(action, rule.Action);
                    Assert.Equal(type, rule.Type);

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.DeleteRule(securityGroupName, ruleName);
                    NetworkSecurityGroupGetResponse afterDeleteGetRuleresponse = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Empty(afterDeleteGetRuleresponse.Rules.Where(r => string.Equals(r.Name, ruleName)));
                }
            }
        }

        #endregion

        #region Subnets

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void AddAndRemoveNetworkSecurityGroupToSubnet()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    //setup

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";

                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // create vnet with subnet
                    string vnetName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";
                    _testFixture.SetSimpleVirtualNetwork();

                    NetworkSecurityGroupAddAssociationParameters parameters = new NetworkSecurityGroupAddAssociationParameters()
                    {
                        Name = securityGroupName
                    };

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.AddToSubnet(vnetName, subnetName, parameters);
                    var listNetworkResponse = _testFixture.NetworkClient.Networks.List();

                    // assert
                    var getResponse = _testFixture.NetworkClient.NetworkSecurityGroups.GetForSubnet(vnetName, subnetName);
                    Assert.Equal(securityGroupName, getResponse.Name);
                    Assert.Equal(listNetworkResponse.VirtualNetworkSites.First(vnet =>
                        vnetName.Equals(vnet.Name)).Subnets.First(subnet =>
                        subnetName.Equals(subnet.Name))
                        .NetworkSecurityGroup, securityGroupName);

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.RemoveFromSubnet(vnetName, subnetName, securityGroupName);


                    // assert
                    Assert.Throws<CloudException>(() => _testFixture.NetworkClient.NetworkSecurityGroups.GetForSubnet(vnetName, subnetName));
                }
            }
        }

        #endregion

        #region Role

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void AddAndRemoveNetworkSecurityGroupToRole()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;

                    string serviceName = _testFixture.GenerateRandomName();
                    string deploymentName = _testFixture.GenerateRandomName();
                    string roleName = "WebRole1";
                    string location = _testFixture.ManagementClient.GetDefaultLocation("Storage", "Compute", "PersistentVMRole");

                    string storageAccountName = _testFixture.GenerateRandomName().ToLower();

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);
                    _testFixture.SetSimpleVirtualNetwork();
                    _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);
                    var deployment = _testFixture.CreatePaaSDeployment(
                        storageAccountName,
                        serviceName,
                        deploymentName,
                        NetworkTestConstants.OneWebOneWorkerPkgFilePath,
                        NetworkTestConstants.VnetOneWebOneWorkerCscfgFilePath);

                    try
                    {
                        // action 1
                        var associationParams = new NetworkSecurityGroupAddAssociationParameters(securityGroupName);
                        _testFixture.NetworkClient.NetworkSecurityGroups.AddToRole(serviceName, deploymentName, roleName,
                            associationParams);

                        // assert 1
                        NetworkSecurityGroupGetAssociationResponse response =
                            _testFixture.NetworkClient.NetworkSecurityGroups.GetForRole(serviceName, deploymentName, roleName);
                        Assert.Equal(associationParams.Name, response.Name);

                        // action 2
                        _testFixture.NetworkClient.NetworkSecurityGroups.RemoveFromRole(
                            serviceName,
                            deploymentName,
                            roleName,
                            securityGroupName);

                        // assert 2
                        Assert.Throws<CloudException>(() =>
                            _testFixture.NetworkClient.NetworkSecurityGroups.GetForRole(serviceName, deploymentName, roleName));
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            _testFixture.StorageClient.StorageAccounts.Delete(storageAccountName);
                        }
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void CreateVMWithNetworkSecurityGroupOnRole()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;

                    string serviceName = _testFixture.GenerateRandomName();
                    string deploymentName = _testFixture.GenerateRandomName();
                    string roleName = _testFixture.GenerateRandomName();
                    string networkInterfaceName = _testFixture.GenerateRandomName();
                    string location = _testFixture.ManagementClient.GetDefaultLocation("Storage", "Compute", "PersistentVMRole");
                    string virtualNetworkName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";

                    string storageAccountName = _testFixture.GenerateRandomName().ToLower();

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);
                    _testFixture.SetSimpleVirtualNetwork();
                    _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);

                    var multiNICVMDeployment = _testFixture.CreateMultiNICIaaSDeploymentParameters(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            storageAccountName,
                            virtualNetworkName,
                            subnetName);

                    var configurationSets = multiNICVMDeployment.Roles.Single(
                        r => string.Equals(r.RoleName, roleName)).ConfigurationSets;

                    configurationSets
                        .Single(
                            cs => string.Equals(cs.ConfigurationSetType, ConfigurationSetTypes.NetworkConfiguration))
                        .NetworkSecurityGroup = securityGroupName;

                    try
                    {
                        // action 1: create Deployment with NSG
                        _testFixture.ComputeClient.VirtualMachines.CreateDeployment(
                            serviceName,
                            multiNICVMDeployment);

                        // assert 1
                        NetworkSecurityGroupGetAssociationResponse response =
                            _testFixture.NetworkClient.NetworkSecurityGroups.GetForRole(
                            serviceName,
                            deploymentName,
                            roleName);
                        Assert.Equal(securityGroupName, response.Name);

                        var deployment = _testFixture.ComputeClient.Deployments.GetBySlot(serviceName,
                            DeploymentSlot.Production);

                        Assert.Equal(
                            securityGroupName,
                            deployment.Roles.Single(r => string.Equals(r.RoleName, roleName))
                                .ConfigurationSets.Single(
                                    cs =>
                                        string.Equals(cs.ConfigurationSetType,
                                            ConfigurationSetTypes.NetworkConfiguration))
                                .NetworkSecurityGroup);

                        // action 2: update deployment without NSG
                        configurationSets
                            .Single(
                                cs => string.Equals(cs.ConfigurationSetType, ConfigurationSetTypes.NetworkConfiguration))
                            .NetworkSecurityGroup = null;

                        _testFixture.ComputeClient.VirtualMachines.Update(serviceName, deploymentName, roleName,
                            new VirtualMachineUpdateParameters()
                            {
                                RoleName = roleName,
                                ConfigurationSets = configurationSets,
                                OSVirtualHardDisk = _testFixture.GetOSVirtualHardDisk(storageAccountName, serviceName)
                            });

                        // assert 2
                        deployment = _testFixture.ComputeClient.Deployments.GetBySlot(serviceName,
                            DeploymentSlot.Production);

                        Assert.Null(
                            deployment.Roles.Single(r => string.Equals(r.RoleName, roleName))
                                .ConfigurationSets.Single(
                                    cs =>
                                        string.Equals(cs.ConfigurationSetType,
                                            ConfigurationSetTypes.NetworkConfiguration))
                                .NetworkSecurityGroup);
                    }

                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        #endregion


        #region NICs

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void AddAndRemoveNetworkSecurityGroupToNIC()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;

                    string serviceName = _testFixture.GenerateRandomName();
                    string deploymentName = _testFixture.GenerateRandomName();
                    string roleName = _testFixture.GenerateRandomName();
                    string networkInterfaceName = _testFixture.GenerateRandomName();
                    string location = _testFixture.ManagementClient.GetDefaultLocation("Storage", "Compute", "PersistentVMRole");
                    string virtualNetworkName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";

                    string storageAccountName = _testFixture.GenerateRandomName().ToLower();

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);
                    _testFixture.SetSimpleVirtualNetwork();
                    _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);
                    _testFixture.ComputeClient.VirtualMachines.CreateDeployment(
                        serviceName,
                        _testFixture.CreateMultiNICIaaSDeploymentParameters(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            storageAccountName,
                            virtualNetworkName,
                            subnetName));

                    try
                    {
                        // action 1
                        var associationParams = new NetworkSecurityGroupAddAssociationParameters(securityGroupName);
                        _testFixture.NetworkClient.NetworkSecurityGroups.AddToNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            associationParams);

                        // assert 1
                        NetworkSecurityGroupGetAssociationResponse response =
                            _testFixture.NetworkClient.NetworkSecurityGroups.GetForNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName);
                        Assert.Equal(associationParams.Name, response.Name);

                        // action 2
                        _testFixture.NetworkClient.NetworkSecurityGroups.RemoveFromNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            securityGroupName);

                        // assert 2
                        Assert.Throws<CloudException>(() =>_testFixture.NetworkClient.NetworkSecurityGroups.GetForNetworkInterface(
                                serviceName,
                                deploymentName,
                                roleName,
                                networkInterfaceName));
                    }

                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void CreateVMWithNetworkSecurityGroupOnNIC()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;

                    string serviceName = _testFixture.GenerateRandomName();
                    string deploymentName = _testFixture.GenerateRandomName();
                    string roleName = _testFixture.GenerateRandomName();
                    string networkInterfaceName = _testFixture.GenerateRandomName();
                    string location = _testFixture.ManagementClient.GetDefaultLocation("Storage", "Compute", "PersistentVMRole");
                    string virtualNetworkName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";

                    string storageAccountName = _testFixture.GenerateRandomName().ToLower();

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);
                    _testFixture.SetSimpleVirtualNetwork();
                    _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);

                    var multiNICVMDeployment = _testFixture.CreateMultiNICIaaSDeploymentParameters(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            storageAccountName,
                            virtualNetworkName,
                            subnetName);

                    var configurationSets = multiNICVMDeployment.Roles.Single(
                        r => string.Equals(r.RoleName, roleName)).ConfigurationSets;

                    configurationSets
                        .Single(
                            cs => string.Equals(cs.ConfigurationSetType, ConfigurationSetTypes.NetworkConfiguration))
                        .NetworkInterfaces.Single(nic => string.Equals(nic.Name, networkInterfaceName))
                        .NetworkSecurityGroup = securityGroupName;

                    try
                    {
                        // action 1: create Deployment with NSG
                        _testFixture.ComputeClient.VirtualMachines.CreateDeployment(
                            serviceName,
                            multiNICVMDeployment);

                        // assert 1
                        NetworkSecurityGroupGetAssociationResponse response =
                            _testFixture.NetworkClient.NetworkSecurityGroups.GetForNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName);
                        Assert.Equal(securityGroupName, response.Name);

                        var deployment = _testFixture.ComputeClient.Deployments.GetBySlot(serviceName,
                            DeploymentSlot.Production);

                        Assert.Equal(
                            securityGroupName,
                            deployment.Roles.Single(r => string.Equals(r.RoleName, roleName))
                                .ConfigurationSets.Single(
                                    cs =>
                                        string.Equals(cs.ConfigurationSetType,
                                            ConfigurationSetTypes.NetworkConfiguration))
                                .NetworkInterfaces.Single(nic => string.Equals(nic.Name, networkInterfaceName))
                                .NetworkSecurityGroup);

                        // action 2: update deployment without NSG
                        configurationSets
                            .Single(
                                cs => string.Equals(cs.ConfigurationSetType, ConfigurationSetTypes.NetworkConfiguration))
                            .NetworkInterfaces.Single(nic => string.Equals(nic.Name, networkInterfaceName))
                            .NetworkSecurityGroup = null;

                        _testFixture.ComputeClient.VirtualMachines.Update(serviceName, deploymentName, roleName,
                            new VirtualMachineUpdateParameters()
                            {
                                RoleName = roleName,
                                ConfigurationSets = configurationSets,
                                OSVirtualHardDisk = _testFixture.GetOSVirtualHardDisk(storageAccountName, serviceName)
                            });

                        // assert 2
                        deployment = _testFixture.ComputeClient.Deployments.GetBySlot(serviceName,
                            DeploymentSlot.Production);

                        Assert.Null(
                            deployment.Roles.Single(r => string.Equals(r.RoleName, roleName))
                                .ConfigurationSets.Single(
                                    cs =>
                                        string.Equals(cs.ConfigurationSetType,
                                            ConfigurationSetTypes.NetworkConfiguration))
                                .NetworkInterfaces.Single(nic => string.Equals(nic.Name, networkInterfaceName))
                                .NetworkSecurityGroup);
                    }

                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        #endregion
    }
}

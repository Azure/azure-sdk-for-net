using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Testing;
using Xunit;

namespace Network.Tests.Routes
{
    public class GetEffectiveRouteTableTests
    {
        #region Role

        [Fact]
        [Trait("Feature", "Routes")]
        public void GetEffectiveRouteTableOnRoleSucceeds()
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
                    string routeTableName = _testFixture.GenerateRandomName();
                    string routeName = "routename";
                    string vnetName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";

                    string storageAccountName = _testFixture.GenerateRandomName().ToLower();

                    _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);
                    _testFixture.SetSimpleVirtualNetwork();
                    _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);

                    CreateRouteTableParameters parameters = new CreateRouteTableParameters()
                    {
                        Name = routeTableName,
                        Label = _testFixture.GenerateRandomName(),
                        Location = location,
                    };

                    AzureOperationResponse createResponse = _testFixture.NetworkClient.Routes.CreateRouteTable(parameters);
                    var createRouteParameters = new SetRouteParameters()
                    {
                        Name = routeName,
                        AddressPrefix = "0.0.0.0/0",
                        NextHop = new NextHop()
                        {
                            IpAddress = "192.168.100.4",
                            Type = "VirtualAppliance"
                        },
                    };

                    _testFixture.NetworkClient.Routes.SetRoute(routeTableName, routeName, createRouteParameters);

                    AddRouteTableToSubnetParameters addRouteTableToSubnetParameters = new AddRouteTableToSubnetParameters()
                    {
                        RouteTableName = routeTableName
                    };

                    _testFixture.NetworkClient.Routes.AddRouteTableToSubnet(vnetName, subnetName, addRouteTableToSubnetParameters);

                    var deployment = _testFixture.CreatePaaSDeployment(
                        storageAccountName,
                        serviceName,
                        deploymentName,
                        NetworkTestConstants.OneWebOneWorkerPkgFilePath,
                        NetworkTestConstants.VnetOneWebOneWorkerCscfgFilePath);

                    try
                    {
                        // action
                        _testFixture.ComputeClient.Deployments.UpdateStatusByDeploymentName(serviceName, deploymentName,
                            new DeploymentUpdateStatusParameters()
                            {
                                Status = UpdatedDeploymentStatus.Running
                            });

                        RoleInstancePowerState roleStatus = RoleInstancePowerState.Unknown;
                        Action getRole = () =>
                        {
                            var vmStatus = _testFixture.ComputeClient.Deployments.GetByName(serviceName, deploymentName);
                            roleStatus =
                                vmStatus.RoleInstances.Single(
                                    r => string.Equals(r.RoleName, roleName, StringComparison.OrdinalIgnoreCase))
                                    .PowerState;
                        };

                        Func<bool> retryUntil = () =>
                        {
                            return roleStatus == RoleInstancePowerState.Started;
                        };

                        TestUtilities.RetryActionWithTimeout(
                            getRole,
                            retryUntil,
                            TimeSpan.FromMinutes(15),
                            (code =>
                            {
                                Thread.Sleep(5000);
                                return true;
                            }));

                        // assert
                        var response =
                            _testFixture.NetworkClient.Routes.GetEffectiveRouteTableForRoleInstance(serviceName, deploymentName, roleName + "_IN_0");
                        Assert.NotNull(response);
                        Assert.NotNull(response.EffectiveRouteTable);
                        Assert.NotEmpty(response.EffectiveRouteTable.EffectiveRoutes);
                        var userDefinedRoute =
                            response.EffectiveRouteTable.EffectiveRoutes.Single(r => r.Source == "User");
                        Assert.Equal(1, userDefinedRoute.AddressPrefixes.Count);
                        Assert.Equal(createRouteParameters.AddressPrefix, userDefinedRoute.AddressPrefixes[0]);
                        Assert.Equal(createRouteParameters.Name, userDefinedRoute.Name);
                        Assert.Equal(createRouteParameters.NextHop.Type, userDefinedRoute.EffectiveNextHop.Type);
                        Assert.Equal(1, userDefinedRoute.EffectiveNextHop.IpAddresses.Count);
                        Assert.Equal(createRouteParameters.NextHop.IpAddress, userDefinedRoute.EffectiveNextHop.IpAddresses[0]);
                        Assert.Equal("Active", userDefinedRoute.Status);
                    }
                    finally
                    {
                        _testFixture.NetworkClient.Routes.BeginRemoveRouteTableFromSubnet(vnetName, subnetName);
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

        #endregion

        #region NICs

        [Fact]
        [Trait("Feature", "Routes")]
        public void GetEffectiveRouteTableOnNICSucceeds()
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
                        // action

                        // assert
                        var response =
                            _testFixture.NetworkClient.Routes.GetEffectiveRouteTableForRoleInstance(serviceName, deploymentName, roleName);
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

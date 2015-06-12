using System.Threading;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Testing;
using Xunit;

namespace Network.Tests
{
    public class IPForwardingIntegrationTests
    {
        public IPForwardingIntegrationTests()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        #region Role

        [Fact]
        [Trait("Feature", "IPForwarding")]
        public void SetIPForwardingOnRoleSucceeds()
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
                        // action
                        var ipForwardingState = "Enabled";
                        var ipForwarding = new IPForwardingSetParameters(ipForwardingState);

                        _testFixture.NetworkClient.IPForwarding.SetOnRole(serviceName, deploymentName, roleName,
                            ipForwarding);

                        // assert
                        IPForwardingGetResponse response =
                            _testFixture.NetworkClient.IPForwarding.GetForRole(serviceName, deploymentName, roleName);
                        Assert.Equal(ipForwardingState, response.State);
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

        #endregion

        #region NICs

        [Fact]
        [Trait("Feature", "IPForwarding")]
        public void SetIPForwardingOnNICSucceeds()
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
                        var ipForwardingState = "Enabled";
                        var ipForwarding = new IPForwardingSetParameters(ipForwardingState);

                        _testFixture.NetworkClient.IPForwarding.SetOnNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName,
                            ipForwarding);

                        // assert
                        IPForwardingGetResponse response = _testFixture.NetworkClient.IPForwarding.GetForNetworkInterface(
                            serviceName,
                            deploymentName,
                            roleName,
                            networkInterfaceName);
                        Assert.Equal(ipForwardingState, response.State);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Test;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure;
using Xunit;

namespace SiteRecovery.Tests
{
    public class ProcessServerTests : SiteRecoveryTestsBase
    {
        private string runAsAccountName = "mobility_update_account";

        public void ProcessServerLoadBalance()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var protectedItemsResponse = client.ReplicationProtectedItem.List(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    RequestHeaders);
                Assert.NotNull(protectedItemsResponse);

                var protectedItem = protectedItemsResponse.ReplicationProtectedItems[0];
                Assert.NotNull(protectedItem.Properties.ProviderSpecificDetails);

                var vmWareAzureV2Details = protectedItem.Properties.ProviderSpecificDetails
                    as InMageAzureV2ProviderSpecificSettings;
                Assert.NotNull(vmWareAzureV2Details);                        

                var response =
                    client.Fabrics.ReassociateGateway(
                        vmWareFabric.Name,
                        new FailoverProcessServerRequest
                        {
                            Properties = new FailoverProcessServerRequestProperties()
                            {
                                ContainerId = containersResponse.ProtectionContainers[0].Name,
                                FailoverType = "ServerLevel",
                                SourceProcessServerId = "90E6D52D-FAAF-E447-A3ED88CABB6D4F5A",
                                TargetProcessServerId = "568CF408-19CE-334D-844C76D9F6C0CEB6",
                                VmsToMigrate = new List<string> { vmWareAzureV2Details.InfrastructureVmId }
                            }
                        },
                        RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);
            }
        }

        public void ProcessServerFailover()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var response =
                    client.Fabrics.ReassociateGateway(
                        vmWareFabric.Name,
                        new FailoverProcessServerRequest
                        {
                            Properties = new FailoverProcessServerRequestProperties
                            {
                                ContainerId = containersResponse.ProtectionContainers[0].Name,
                                FailoverType = "SystemLevel",
                                SourceProcessServerId = "568CF408-19CE-334D-844C76D9F6C0CEB6",
                                TargetProcessServerId = "90E6D52D-FAAF-E447-A3ED88CABB6D4F5A",
                                VmsToMigrate = null
                            }
                        },
                        RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);
            }
        }

        public void DeployProcessServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                //var response =
                //    client.Fabrics.DeployProcessServer(
                //        vmWareFabric.Name,
                //        new DeployProcessServerRequest
                //        {
                //            Properties = new DeployProcessServerRequestProperties
                //            {
                //                SubscriptionId = "",
                //                VaultLocation = "",
                //                ProcessServerName = "",
                //                Username = "",
                //                Password = "",
                //                IpAddress = "",
                //                AzureNetworkName = "",
                //                AzureNetworkSubnet = ""
                //            }
                //        },
                //        RequestHeaders);

                //Assert.Equal(OperationStatus.Succeeded, response.Status);
            }
        }

        public void UpdateMobilityService()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var vmWareDetails =
                   vmWareFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);

                var runAsAccount = vmWareDetails.RunAsAccounts.First(
                   account => account.AccountName.Equals(
                       this.runAsAccountName,
                       StringComparison.InvariantCultureIgnoreCase));
                Assert.NotNull(runAsAccount);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var protectedItemsResponse = client.ReplicationProtectedItem.List(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    RequestHeaders);
                Assert.NotNull(protectedItemsResponse);

                var protectedItem = protectedItemsResponse.ReplicationProtectedItems[0];
                Assert.NotNull(protectedItem.Properties.ProviderSpecificDetails);

                var vmWareAzureV2Details = protectedItem.Properties.ProviderSpecificDetails
                    as InMageAzureV2ProviderSpecificSettings;
                Assert.NotNull(vmWareAzureV2Details);

                var response =
                    client.ReplicationProtectedItem.UpdateMobilityService(
                        vmWareFabric.Name,
                        containersResponse.ProtectionContainers[0].Name,
                        vmWareAzureV2Details.InfrastructureVmId,
                        new UpdateMobilityServiceRequest
                        {
                            Properties = new UpdateMobilityServiceRequestProperties
                            {
                                RunAsAccountId = runAsAccount.AccountId
                            }
                        },
                        RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);
            }
        }

        public void DiscoverProtectableItemPhysicalServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var response =
                    client.ProtectionContainer.DiscoverProtectableItem(
                        vmWareFabric.Name,
                        containersResponse.ProtectionContainers[0].Name,
                        new DiscoverProtectableItemRequest
                        {
                            Properties = new DiscoverProtectableItemRequestProperties
                            {
                                FriendlyName = "Physical Server - chpadh4",
                                IpAddress = "10.0.0.4",
                                OsType = "Windows"
                            }
                        },
                        RequestHeaders);

                Assert.Equal(OperationStatus.Succeeded, response.Status);
            }
        }
    }
}

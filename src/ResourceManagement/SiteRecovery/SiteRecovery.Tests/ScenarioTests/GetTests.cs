//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using System.Linq;
using Xunit;
using System;


namespace SiteRecovery.Tests
{
    public class GetTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void GetServerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricListResponse responseServers = client.Fabrics.List(RequestHeaders);

                FabricResponse response = client.Fabrics.Get(responseServers.Fabrics[0].Name, RequestHeaders);

                Assert.NotNull(response.Fabric);
                Assert.NotNull(response.Fabric.Name);
                Assert.NotNull(response.Fabric.Id);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void GetRecoveryServicesProviders()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricListResponse responseServers = client.Fabrics.List(RequestHeaders);

                FabricResponse response = client.Fabrics.Get(responseServers.Fabrics[0].Name, RequestHeaders);

                foreach (Fabric fabric in responseServers.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType == "VMM")
                    {
                        RecoveryServicesProviderResponse dra =
                            client.RecoveryServicesProvider.Get(fabric.Name, fabric.Properties.InternalIdentifier, RequestHeaders);
                    }
                }

                Assert.NotNull(response.Fabric);
                Assert.NotNull(response.Fabric.Name);
                Assert.NotNull(response.Fabric.Id);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void GetStorageClassification()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricListResponse responseServers = client.Fabrics.List(RequestHeaders);

                FabricResponse response = client.Fabrics.Get(responseServers.Fabrics[0].Name, RequestHeaders);

                foreach (Fabric fabric in responseServers.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType == "VMM")
                    {
                        var storageClassifications = client.StorageClassification.List(fabric.Name, RequestHeaders);

                        var storageClassification = client.StorageClassification.Get(
                            fabric.Name, 
                            storageClassifications.StorageClassifications[0].Name, 
                            RequestHeaders);
                    }
                }
            }
        }

        public void GetProtectedContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Fabric selectedfabric = null;
                foreach (var fabric in responseServers.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
                    {
                        selectedfabric = fabric;
                        break;
                    }
                }

                var protectionContainerList = client.ProtectionContainer.List(selectedfabric.Name, RequestHeaders);
                var response = client.ProtectionContainer.Get(selectedfabric.Name,
                    protectionContainerList.ProtectionContainers[0].Name,
                    RequestHeaders);

                Assert.NotNull(response.ProtectionContainer);
                Assert.NotNull(response.ProtectionContainer.Name);
                Assert.NotNull(response.ProtectionContainer.Id);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void GetAllProtectedContainerTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var protectionContainerList = client.ProtectionContainer.ListAll(RequestHeaders);
            }
        }

	public void GetReplicationProtectedItems()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "f0632449-effd-4858-a210-4ea15756e4b7";
                string containerId = "d38048d4-b460-4791-8ece-108395ee8478";

                var response = client.ReplicationProtectedItem.List(fabricId, containerId, RequestHeaders);
            }
        }

        public void GetVMwareAzureV2ReplicationProtectableItems()
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

                var protectableItemsResponse = client.ProtectableItem.List(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    "Unprotected",
                    "",
                    "1000",
                    RequestHeaders);
                Assert.NotNull(protectableItemsResponse);
                Assert.NotEmpty(protectableItemsResponse.ProtectableItems);

                var protectableItem = protectableItemsResponse.ProtectableItems[0];
                Assert.NotNull(protectableItem.Properties.CustomDetails);

                var vmWareAzureV2Details = protectableItem.Properties.CustomDetails
                    as VMwareVirtualMachineDetails;
                Assert.NotNull(vmWareAzureV2Details);

                var hikewalrProtectableItems =
                    protectableItemsResponse.ProtectableItems.Where(
                        p => p.Properties.FriendlyName.Contains("hikewalr"));
            }
        }

        public void GetVMwareAzureV2ReplicationProtectedItem()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = this.GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.ReplicationProtectedItem.Get(
                    "52fcbc3c29d2b391598f1e98737138e54ae3597b04bef2a71df5143c16cf9a14",
                    "cloud_2e908a93-f69f-49fe-bdf8-8687a9f1db35",
                    "dee537e5-a9a0-11e5-af2b-0050569e66ab-Protected",
                    RequestHeaders);

                Assert.NotNull(response);
                Assert.NotNull(response.ReplicationProtectedItem);
            }
        }

        public void GetVMwareAzureV2ReplicationProtectedItems()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = this.GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics[1];
                //var vmWareFabric = responseServers.Fabrics.First(
                //    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                //Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var response = client.ReplicationProtectedItem.List(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    RequestHeaders);
                Assert.NotNull(response);

                foreach(ReplicationProtectedItem replicatedItem in response.ReplicationProtectedItems)
                {
                    var response1 = client.ReplicationProtectedItem.Get(
                        vmWareFabric.Name,
                        containersResponse.ProtectionContainers[0].Name,
                        replicatedItem.Name,
                        RequestHeaders);

                    Assert.NotNull(response1);
                }
            }
        }

        public void GetNetworkTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                const string networkName = "15e1a665-e184-4da0-8e9d-0de72a7d8fa9";
                var response = client.Network.Get(fabricName, networkName, RequestHeaders);
            }
        }

        public void GetNetworkMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                const string networkName = "399137cc-f0de-4a3f-b961-fd0892d8ebc4";
                const string networkMappingName = "VMNetworkPair;f0632449-effd-4858-a210-4ea15756e4b7_399137cc-f0de-4a3f-b961-fd0892d8ebc4_21a9403c-6ec1-44f2-b744-b4e50b792387";
                var response = client.NetworkMapping.Get(
                    fabricName,
                    networkName,
                    networkMappingName,
                    RequestHeaders);
            }
        }

        public void GetContainerMappings()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string fabricId = "Vmm;6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string containerId = "de2e082c-3123-42c5-a867-10dc58950db6";

                var response = client.ProtectionContainerMapping.List(fabricId, containerId, RequestHeaders);
            }
        }

        public void GetVMwareAzureV2ContainerMapping()
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

                var containersMappingResponse = client.ProtectionContainerMapping.Get(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    "Hitesh-VMwareAzureV2-Mapping",
                    RequestHeaders);
                Assert.NotNull(containersMappingResponse);
            }
        }

        public void GetEvents()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Events.List(
                    new EventQueryParameter
                    {
                        StartTime = DateTime.Parse("01112015 000000").ToString(),
                        EndTime = DateTime.Now.AddDays(-1).ToString(),
                        AffectedObjectFriendlyName = "sadko-1102-1",
                    },
                    RequestHeaders);
                Assert.NotNull(response);
                Assert.NotEmpty(response.Events);
            }
        }

        public void GetEvent()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Events.List(
                    new EventQueryParameter
                    {
                        StartTime = DateTime.Parse("2015-11-01 00:00").ToString(),
                        EndTime = DateTime.Now.AddDays(-1).ToString(),
                        AffectedObjectFriendlyName = "sadko-1102-1",
                    },
                    RequestHeaders);
                Assert.NotNull(response);
                Assert.NotEmpty(response.Events);

                var eventResponse = client.Events.Get(
                    response.Events[0].Name,
                    RequestHeaders);
                Assert.NotNull(eventResponse);
                Assert.NotNull(eventResponse.Event);
            }
        }

        public void GetEventNegativeTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                EventResponse eventResponse = null;

                try
                {
                    client.Events.Get(
                        "UnrealisticEventName42", // Because 42 is the answer to life, the universe and everything.
                        RequestHeaders);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToUpper().Contains("NOTFOUND"))
                    {
                        eventResponse = new EventResponse();
                        eventResponse.Event = null;
                        eventResponse.StatusCode = HttpStatusCode.NotFound;
                    }
                }

                Assert.NotNull(eventResponse);
                Assert.Null(eventResponse.Event);
                Assert.Equal(HttpStatusCode.NotFound, eventResponse.StatusCode);
            }
        }

        public void GetAlertSettingsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.AlertSettings.List(RequestHeaders);
                Assert.NotNull(response);
                Assert.NotEmpty(response.Alerts);

                var alertResponse = client.AlertSettings.Get(
                    response.Alerts[0].Name,
                    RequestHeaders);

                Assert.NotNull(alertResponse);
                Assert.NotNull(alertResponse.Alert);
            }
        }

        public void GetAlertSettingsNegativeTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                AlertSettingsResponse alertResponse = null;

                try
                {
                    alertResponse = client.AlertSettings.Get(
                        "dummyName",
                        RequestHeaders);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToUpper().Contains("NOTFOUND"))
                    {
                        alertResponse = new AlertSettingsResponse();
                        alertResponse.Alert = null;
                        alertResponse.StatusCode = HttpStatusCode.NotFound;
                    }
                }

                Assert.NotNull(alertResponse);
                Assert.Equal(alertResponse.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public void GetStorageClassificationAndPairingsUnderVault()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                client.StorageClassification.ListAll(RequestHeaders);
                client.StorageClassificationMapping.ListAll(RequestHeaders);
            }
        }
    }
}

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

using System.Linq;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System;
using System.Runtime.Serialization;

namespace SiteRecovery.Tests
{
    /// <summary>
    /// Network target type.
    /// </summary>
    public enum NetworkTargetType
    {
        /// <summary>
        /// SCVMM VM Network.
        /// </summary>
        SCVMM = 0,

        /// <summary>
        /// Azure VM Network.
        /// </summary>
        Azure,
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateNetworkMappingInput
    {
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        [DataMember(Order = 3)]
        public string RecoveryServerId { get; set; }

        [DataMember(Order = 4)]
        public string RecoveryNetworkId { get; set; }
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateAzureNetworkMappingInput
    {
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        [DataMember(Order = 3)]
        public string RecoveryNetworkId { get; set; }

        [DataMember(Order = 4)]
        public string RecoveryNetworkName { get; set; }
    }

    public class NetworkOperationTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void EnumerateNetworksTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                var response = client.Networks.List(servers.Servers[0].ID, RequestHeaders);
                /* string subscriptionId = string.Empty;
                var response1 = client.Networks.ListAzureNetworks(subscriptionId); */

                Assert.True(response.Networks.Count > 0, "Networks count can't be less than 1");
                Assert.True(response.Networks.All(network => !string.IsNullOrEmpty(network.Name)), "Network name can't be null or empty");
                Assert.True(response.Networks.All(network => !string.IsNullOrEmpty(network.ID)), "Network Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateNetworkMappingsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                // 57f95c35-6c83-42ce-bb21-2c4f10f92d8e
                var response = client.NetworkMappings.List(servers.Servers[0].ID, servers.Servers[0].ID, RequestHeaders);

                Assert.True(response.NetworkMappings.Count > 0, "Network mappings count can't be less than 1");
                Assert.True(response.NetworkMappings.All(networkMapping => !string.IsNullOrEmpty(networkMapping.PrimaryServerId)), "Network mapping primary server ID can't be null or empty");
                Assert.True(response.NetworkMappings.All(networkMapping => !string.IsNullOrEmpty(networkMapping.PrimaryNetworkId)), "Network mapping primary network ID can't be null or empty");
                Assert.True(response.NetworkMappings.All(networkMapping => !string.IsNullOrEmpty(networkMapping.RecoveryServerId)), "Network mapping recovery server ID can't be null or empty");
                Assert.True(response.NetworkMappings.All(networkMapping => !string.IsNullOrEmpty(networkMapping.RecoveryNetworkId)), "Network mapping recovery network ID can't be null or empty");
                Assert.True(response.NetworkMappings.All(networkMapping => !string.IsNullOrEmpty(networkMapping.PairingStatus)), "Network mapping pairing status can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void CreateNetworkMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                // 57f95c35-6c83-42ce-bb21-2c4f10f92d8e
                var networksOnPrimary = client.Networks.List(servers.Servers[0].ID, RequestHeaders);
                var networksOnRecovery = client.Networks.List(servers.Servers[1].ID, RequestHeaders);

                CreateNetworkMappingInput createNetworkMappingInput = new CreateNetworkMappingInput();
                createNetworkMappingInput.PrimaryServerId = servers.Servers[0].ID;
                createNetworkMappingInput.PrimaryNetworkId = networksOnPrimary.Networks[0].ID;
                createNetworkMappingInput.RecoveryServerId = servers.Servers[1].ID;
                createNetworkMappingInput.RecoveryNetworkId = networksOnRecovery.Networks[0].ID;

                NetworkMappingInput networkMappingInput = new NetworkMappingInput();
                networkMappingInput.NetworkTargetType = NetworkTargetType.SCVMM.ToString();
                networkMappingInput.CreateNetworkMappingInput =
                    DataContractUtils.Serialize<CreateNetworkMappingInput>(createNetworkMappingInput);

                var response = client.NetworkMappings.Create(networkMappingInput, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while creating network mapping");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                CreateAzureNetworkMappingInput mappingInput = new CreateAzureNetworkMappingInput();
                
            }
        }

        [Fact]
        public void CreateAzureNetworkMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                // 57f95c35-6c83-42ce-bb21-2c4f10f92d8e
                var networks = client.Networks.List(servers.Servers[0].ID, RequestHeaders);

                CreateAzureNetworkMappingInput createAzureNetworkMappingInput = new CreateAzureNetworkMappingInput();
                createAzureNetworkMappingInput.PrimaryServerId = servers.Servers[0].ID;
                createAzureNetworkMappingInput.PrimaryNetworkId = networks.Networks[0].ID;
                createAzureNetworkMappingInput.RecoveryNetworkName = "Azure VM Network name";
                createAzureNetworkMappingInput.RecoveryNetworkId = "Azure VM Network ID";

                NetworkMappingInput networkMappingInput = new NetworkMappingInput();
                networkMappingInput.NetworkTargetType = NetworkTargetType.Azure.ToString();
                networkMappingInput.CreateNetworkMappingInput =
                    DataContractUtils.Serialize<CreateAzureNetworkMappingInput>(createAzureNetworkMappingInput);

                var response = client.NetworkMappings.Create(networkMappingInput, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while creating network mapping");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteNetworkMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                // Get Network mappings
                var networkMappings = client.NetworkMappings.List(servers.Servers[0].ID, servers.Servers[1].ID, RequestHeaders);

                NetworkUnMappingInput mappingInput = new NetworkUnMappingInput();
                mappingInput.PrimaryServerId = networkMappings.NetworkMappings[0].PrimaryServerId;
                mappingInput.PrimaryNetworkId = networkMappings.NetworkMappings[0].PrimaryNetworkId;
                mappingInput.RecoveryServerId = networkMappings.NetworkMappings[0].RecoveryServerId;
                var response = client.NetworkMappings.Delete(mappingInput, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while deleting network mapping");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}

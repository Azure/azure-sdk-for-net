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

using Microsoft.Azure;

namespace Network.Tests.Networks
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class SetConfigurationTests
    {
        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetConfigurationThrowsArgumentNullExceptionWhenParameterIsNull()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                const NetworkSetConfigurationParameters parameters = null;
                try
                {
                    networkTestClient.SetNetworkConfiguration(parameters);
                }
                catch (ArgumentNullException e)
                {
                    Assert.Equal("parameters", e.ParamName);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetConfigurationThrowsArgumentNullExceptionWhenConfigurationIsNull()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                NetworkSetConfigurationParameters parameters = new NetworkSetConfigurationParameters();
                try
                {
                    networkTestClient.SetNetworkConfiguration(parameters);
                }
                catch (ArgumentNullException e)
                {
                    Assert.Equal("parameters.Configuration", e.ParamName);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetConfigurationWhenConfigurationIsEmpty()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                NetworkSetConfigurationParameters parameters = new NetworkSetConfigurationParameters()
                {
                    Configuration = string.Empty,
                };

                try
                {
                    networkTestClient.SetNetworkConfiguration(parameters);
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetSiteToSiteConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();

                OperationStatusResponse response = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SiteToSiteNetworkConfigurationParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                NetworkGetConfigurationResponse getConfigurationResponse = networkTestClient.GetNetworkConfiguration();
                Assert.NotNull(getConfigurationResponse);

                string responseConfiguration = getConfigurationResponse.Configuration;
                Assert.NotNull(responseConfiguration);
                Assert.NotEmpty(responseConfiguration);
                Assert.True(responseConfiguration.Contains("localNetworkSiteName"));
                Assert.True(responseConfiguration.Contains("virtualNetworkSiteName"));
                Assert.True(responseConfiguration.Contains("affinityGroupName"));
                Assert.True(responseConfiguration.Contains("192.168.0.0/24"));
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetPointToSiteConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();

                OperationStatusResponse response = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.PointToSiteNetworkConfigurationParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                NetworkGetConfigurationResponse getConfigurationResponse = networkTestClient.GetNetworkConfiguration();
                Assert.NotNull(getConfigurationResponse);

                string responseConfiguration = getConfigurationResponse.Configuration;
                Assert.NotNull(responseConfiguration);
                Assert.NotEmpty(responseConfiguration);
                Assert.True(responseConfiguration.Contains("virtualNetworkSiteName"));
                Assert.True(responseConfiguration.Contains("affinityGroupName"));
                Assert.True(responseConfiguration.Contains("192.168.100.0/24"));
                Assert.True(responseConfiguration.Contains("VPNClientAddressPool"));
                Assert.True(responseConfiguration.Contains("192.168.101.0/24"));
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void SetWideVNetConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();

                OperationStatusResponse response = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.WideVNetNetworkConfigurationParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                NetworkGetConfigurationResponse getConfigurationResponse = networkTestClient.GetNetworkConfiguration();
                Assert.NotNull(getConfigurationResponse);

                string responseConfiguration = getConfigurationResponse.Configuration;
                Assert.NotNull(responseConfiguration);
                Assert.NotEmpty(responseConfiguration);
                Assert.True(responseConfiguration.Contains(NetworkTestConstants.VirtualNetworkSiteName));
                Assert.True(responseConfiguration.Contains(NetworkTestConstants.WideVNetLocation));
                Assert.True(responseConfiguration.Contains(NetworkTestConstants.WideVNetSubnetName));
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "SetConfiguration")]
        public void DeleteConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();

                OperationStatusResponse response = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.EmptyNetworkConfigurationParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                try
                {
                    networkTestClient.GetNetworkConfiguration();
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                }
            }
        }
    }
}

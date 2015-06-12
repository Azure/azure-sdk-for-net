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

using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp vnet specific test cases
    /// </summary>
    public class VnetTests : TestBase
    {
        private string TestVnet = "cloudvnet";

        private string TrackingId { get; set; }

        private bool UseTestVnet { get; set; }

        private string GetVNetName()
        {
            if (UseTestVnet)
            {
                return TestVnet;
            }
            else
            {
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();
                VNetListResult vnets = remoteAppManagementClient.VNet.List();
                Assert.NotNull(vnets);
                Assert.Equal(HttpStatusCode.OK, vnets.StatusCode);
                IList<VNet> vnetsList = vnets.VNetList;
                Random r = new Random(42);
                int index = r.Next(0, vnetsList.Count - 1);
                return vnetsList[index].Name;
            }
        }

        private void AssertNotNullOrEmpty(string val)
        {
            Assert.NotNull(val);
            Assert.NotEmpty(val);
        }
        private void AssertNotNullOrEmpty(IList<string> val)
        {
            Assert.NotNull(val);
            Assert.NotEmpty(val);
        }

        private void ValidateVnets(IList<VNet> RemoteAppVnetList)
        {
            foreach (VNet vnet in RemoteAppVnetList)
            {
                ValidateVnet(vnet);
            }
        }

        private void ValidateVnet(VNet RemoteAppVnet)
        {
            AssertNotNullOrEmpty(RemoteAppVnet.Region);
            AssertNotNullOrEmpty(RemoteAppVnet.Name);
            AssertNotNullOrEmpty(RemoteAppVnet.VnetAddressSpaces);
            if (!string.Equals(RemoteAppVnet.Name, "cloudvnet", StringComparison.OrdinalIgnoreCase))
            {
                AssertNotNullOrEmpty(RemoteAppVnet.LocalAddressSpaces);
                AssertNotNullOrEmpty(RemoteAppVnet.DnsServers);
            }
        }

        private void ValidateVendors(IList<Vendor> vendors)
        {
            Assert.NotEmpty(vendors);
            foreach (Vendor vendor in vendors)
            {
                AssertNotNullOrEmpty(vendor.Name);
                Assert.NotEmpty(vendor.Platforms);
                foreach (Platform platform in vendor.Platforms)
                {
                    AssertNotNullOrEmpty(platform.Name);
                    foreach (OsFamily os in platform.OsFamilies)
                    {
                        AssertNotNullOrEmpty(os.Name);
                    }
                }
            }
        }

        private RemoteAppManagementClient GetRemoteAppManagementClient()
        {
            RemoteAppManagementClient client = 
                TestBase.GetServiceClient<RemoteAppManagementClient>(new RDFETestEnvironmentFactory());
            client.RdfeNamespace = "rdst15";
            return client;
        }

        /// <summary>
        /// Testin of querying of a list of vnets
        /// </summary>
        [Fact]
        public void CanGetVnetList()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    VNetListResult result = remoteAppManagementClient.VNet.List();
                    Assert.NotNull(result);
                    Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                    AssertNotNullOrEmpty(result.RequestId);
                    ValidateVnets(result.VNetList);
                });
            }
        }

        /// <summary>
        /// Testing of querying of a vnet details by name
        /// </summary>
        [Fact]
        public void CanGetVnet()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    string vNet = GetVNetName();
                    bool includeSharedKey = false;
                    VNetResult result = remoteAppManagementClient.VNet.Get(vNet, includeSharedKey);
                    Assert.NotNull(result);
                    Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                    AssertNotNullOrEmpty(result.RequestId);
                    ValidateVnet(result.VNet);
                });
            }
        }

        /// <summary>
        /// Testing of creation of a vnet
        /// </summary>
        [Fact]
        public void CanCreateVnet()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                string vnetName = "hkutvnet1";
                VNetParameter payload = new VNetParameter()
                {
                    Region = "West US",
                    VnetAddressSpaces = new List<string>
                            {
                                "172.16.0.0/16"
                            },
                    LocalAddressSpaces = new List<string>
                            {
                                "11.0.0.0/16"
                            },
                    DnsServers = new List<string>()
                            {
                                "10.0.0.1"
                            },
                    VpnAddress = "13.0.0.1",
                    GatewayType = GatewayType.StaticRouting
                };

                Assert.DoesNotThrow(() =>
                {
                    OperationResultWithTrackingId result = remoteAppManagementClient.VNet.CreateOrUpdate(vnetName, payload);

                    Assert.NotNull(result);
                    Assert.True(result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Accepted, "StatusCode = " + result.StatusCode + "is not one of the expected");

                    if (result.StatusCode == HttpStatusCode.Accepted)
                    {
                        Assert.NotNull(result.TrackingId);
                    }

                    // verify the creation
                    VNetResult vnet = remoteAppManagementClient.VNet.Get(vnetName, false);

                    Assert.NotNull(vnet);
                    Assert.Equal(HttpStatusCode.OK, vnet.StatusCode);
                    Assert.NotNull(vnet.VNet);
                    Assert.Equal(vnetName, vnet.VNet.Name);
                    Assert.Equal(payload.VpnAddress, vnet.VNet.VpnAddress);
                    Assert.Equal(payload.GatewayType, vnet.VNet.GatewayType);
                    Assert.Equal(payload.Region, vnet.VNet.Region);
                });
            }
        }

        /// <summary>
        /// Testing of deletion of a vnet
        /// </summary>
        [Fact]
        public void CanDeleteVnet()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                VNet vnet = null;

                // verify the creation
                VNetListResult vnetList = null;
                Assert.DoesNotThrow(() =>
                {
                    vnetList = remoteAppManagementClient.VNet.List();
                });

                Assert.NotNull(vnetList);
                Assert.Equal(HttpStatusCode.OK, vnetList.StatusCode);
                Assert.NotNull(vnetList.VNetList);
                Assert.NotEmpty(vnetList.VNetList);

                foreach (VNet v in vnetList.VNetList)
                {
                    if (Regex.IsMatch(v.Name, @"^hkutvnet"))
                    {
                        // found a match
                        if (v.State == VNetState.Connecting || v.State == VNetState.Ready)
                        {
                            vnet = v;
                            break;
                        }
                    }
                }

                Assert.NotNull(vnet);

                OperationResultWithTrackingId deleteResult = remoteAppManagementClient.VNet.Delete(vnet.Name);

                Assert.NotNull(deleteResult);
                Assert.True(deleteResult.StatusCode == HttpStatusCode.OK || deleteResult.StatusCode == HttpStatusCode.Accepted, "StatusCode = " + deleteResult.StatusCode + "is not one of the expected");

                if (deleteResult.StatusCode == HttpStatusCode.Accepted)
                {
                    Assert.NotNull(deleteResult.TrackingId);
                }
            }
        }

        /// <summary>
        /// Testing of querying of VPN devices for a vnet
        /// </summary>
        [Fact]
        public void CanGetVpnDevices()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    string vNet = TestVnet;
                    VNetVpnDeviceResult result = remoteAppManagementClient.VNet.GetVpnDevices(vNet);

                    Assert.NotNull(result);
                    Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                    ValidateVendors(result.Vendors);
                });
            }
        }

        /// <summary>
        /// Testing of querying of VPN script for a given VPN device
        /// </summary>
        [Fact]
        public void CanGetVpnConfigScript()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    string vNet = TestVnet;
                    VNetConfigScriptResult result = remoteAppManagementClient.VNet.GetVpnDeviceConfigScript(vNet, "Cisco Systems, Inc.", "ASA 5500 Series Adaptive Security Appliances", "ASA Software 8.3");
                    Assert.NotNull(result);
                    Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                    AssertNotNullOrEmpty(result.ConfigScript);
                });
            }
        }

        /// <summary>
        /// Testing of resetting of VPN shared key of the vnet
        /// </summary>
        [Fact]
        public void CanResetVpnSharedKey()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    string vNet = "hkutvnet1";

                    // lets remember the vpn shared key before the reset request
                    VNetResult vnetBefore = remoteAppManagementClient.VNet.Get(vNet, true);

                    Assert.Equal(HttpStatusCode.OK, vnetBefore.StatusCode);
                    Assert.NotNull(vnetBefore.VNet);
                    Assert.Equal(vNet, vnetBefore.VNet.Name);
                    Assert.NotNull(vnetBefore.VNet.SharedKey);

                    // now reset the key
                    OperationResultWithTrackingId result = remoteAppManagementClient.VNet.ResetVpnSharedKey(vNet);

                    Assert.NotNull(result);
                    Assert.InRange(result.StatusCode, HttpStatusCode.OK, HttpStatusCode.Accepted);
                    if (result.StatusCode == HttpStatusCode.Accepted)
                    {
                        Assert.NotNull(result.TrackingId);
                        TrackingId = result.TrackingId;
                    }

                    VNetOperationStatusResult vnetOperationResult = remoteAppManagementClient.VNet.GetResetVpnSharedKeyOperationStatus(TrackingId);

                    Assert.NotNull(vnetOperationResult);
                    Assert.Equal(HttpStatusCode.OK, vnetOperationResult.StatusCode);

                    // lets check if the key is actually reset
                    VNetResult vnetAfter = remoteAppManagementClient.VNet.Get(vNet, true);

                    Assert.Equal(HttpStatusCode.OK, vnetAfter.StatusCode);
                    Assert.NotNull(vnetAfter.VNet);
                    Assert.Equal(vNet, vnetAfter.VNet.Name);
                    Assert.NotNull(vnetAfter.VNet.SharedKey);

                    // make sure that the key before and after does not match
                    Assert.NotEqual(vnetBefore.VNet.SharedKey, vnetAfter.VNet.SharedKey);
                });
            }
        }
    }
}

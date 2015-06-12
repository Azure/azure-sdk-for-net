// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class VirtualDeviceTests : StorSimpleTestBase
    {
        [Fact]
        public void VirtualDeviceScenarioTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Getting all devices in the Resource
                var devices = client.Devices.List(GetCustomRequestHeaders());

                // Asserting that atleast one Physical Device is available.
                Assert.NotNull(devices);
                Assert.True(devices.Any(d => d.Type == DeviceType.Appliance));

                var virtualApplianceInfo = new VirtualDeviceProvisioningInfo()
                {
                    CreateNewStorageAccount = false,
                    StorageAccountName = ConfigurationManager.AppSettings["StorageAccountName"],
                    DeviceName = TestUtilities.GenerateName("VD"),
                    ReturnWorkflowId = true,
                    SubNetName = ConfigurationManager.AppSettings["SubNetName"],
                    VirtualNetworkName = ConfigurationManager.AppSettings["VirtualNetworkName"],
                    SubscriptionId = GetCurrentSubscriptionId(),
                };

                var deviceJobResponse = client.VirtualDevice.Create(virtualApplianceInfo, GetCustomRequestHeaders());

                Assert.True(deviceJobResponse != null && deviceJobResponse.JobId != default(Guid).ToString("D"));
            }
        }
        
    }
}
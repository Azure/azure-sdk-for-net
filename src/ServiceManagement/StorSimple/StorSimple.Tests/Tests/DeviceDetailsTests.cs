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
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Xunit;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple;
using StorSimple.Tests.Utilities;

namespace StorSimple.Tests.Tests
{
    public class DeviceDetailsTests : StorSimpleTestBase
    {
        [Fact]
        public void CanGetDeviceDetailsTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Listing all Devices
                var devices = client.Devices.List(GetCustomRequestHeaders());

                // Asserting that atleast One Device is returned.
                Assert.True(devices != null);
                Assert.True(devices.Any());

                var actualdeviceId = devices.FirstOrDefault().DeviceId;
                actualdeviceId = actualdeviceId.Trim();
                var devicedetails = client.DeviceDetails.Get(actualdeviceId, GetCustomRequestHeaders());

                var returnedModelDesc = devicedetails.DeviceDetails.DeviceProperties.ModelDescription;
                var actualModelDesc = devices.FirstOrDefault().ModelDescription;


                // Asserting that atleast One data container is returned.
                Assert.True(devices != null);
                Assert.True(devices.Any());
                
            }
        }
        /// <summary>
        /// Test positive case for updating DeviceDetails/Config
        /// 
        /// Expects the resource present in the context to contain an online device - as Device Config changes are allowed only on online devices.
        /// Modifies device config in the online device ( A side effect that is not undone )
        /// </summary>
        [Fact]
        public void CanUpdateDeviceDetailsTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();

                // Get all devices.
                var devices = client.Devices.List(GetCustomRequestHeaders());

                // Get hold of an online device.
                var onlineDevice = devices.LastOrDefault(device => device.Status == DeviceStatus.Online);
                if (onlineDevice == null)
                {
                    throw new ArgumentException("Device Config/Details can be set only on online devices. No online device found in the resource specified for testing.");
                }

                // Get current device details/config
                var deviceId = onlineDevice.DeviceId;
                var details = client.DeviceDetails.Get(deviceId, GetCustomRequestHeaders()).DeviceDetails;
                var updatedDetails = new DeviceDetailsRequest();
                Helpers.CopyProperties(details, updatedDetails);

                // Alter device details/config for update
                DataHelpers.ModifyDeviceDetails(updatedDetails);

                // Try and update device details/config
                var taskStatus = client.DeviceDetails.UpdateDeviceDetails(updatedDetails, GetCustomRequestHeaders());

                //Assert the job status
                Assert.NotNull(taskStatus);
                Assert.True(taskStatus.Status == AsyncTaskStatus.Completed);
                Assert.True(taskStatus.Result == AsyncTaskResult.Succeeded);

                // Get device details again and make sure they match to the modified ones.
                var newDetails = client.DeviceDetails.Get(deviceId, GetCustomRequestHeaders()).DeviceDetails;

                Assert.NotNull(newDetails);
                Assert.Equal(newDetails.DeviceProperties.FriendlyName, updatedDetails.DeviceProperties.FriendlyName);
                Assert.Equal(newDetails.DeviceProperties.Description, updatedDetails.DeviceProperties.Description);
                Assert.Contains(updatedDetails.AlertNotification.AlertNotificationEmailList.Last(), newDetails.AlertNotification.AlertNotificationEmailList);
            }
        }
    }
}

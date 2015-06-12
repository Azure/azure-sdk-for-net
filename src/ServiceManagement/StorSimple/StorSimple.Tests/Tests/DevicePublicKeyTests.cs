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

using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class DevicePublicKeyTests : StorSimpleTestBase
    {
        [Fact]
        public void CanGetDevicePublicKey()
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

                var deviceId = devices.First().DeviceId;


                //Getting Device Public Key
                var devicePublicKey = client.DevicePublicKey.Get(deviceId, GetCustomRequestHeaders());

                Assert.NotNull(devicePublicKey);
                Assert.False(string.IsNullOrWhiteSpace(devicePublicKey.DevicePublicKey));

            }
        }
    }
}
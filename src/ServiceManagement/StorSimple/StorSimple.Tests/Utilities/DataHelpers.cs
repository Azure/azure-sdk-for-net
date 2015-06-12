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

using System.Configuration;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Linq;

namespace StorSimple.Tests.Utilities
{
    /// <summary>
    /// Class for helper methods related to mocking, modifying and managing data for tests
    /// </summary>
    public static class DataHelpers
    {
        /// <summary>
        /// Modifies properties on provided deviceDetails object.
        /// Potential usage is in update scenarios
        /// </summary>
        /// <param name="details">DeviceDetails object</param>
        public static void ModifyDeviceDetails(DeviceDetailsBase details)
        {
            details.AlertNotification.AlertNotificationEnabledForAdminCoAdmins = true;
            details.AlertNotification.AlertNotificationEmailList.Add(TestUtilities.GenerateName("test") + "@test.com");

            var data0 = details.NetInterfaceList.FirstOrDefault(x => x.InterfaceId == NetInterfaceId.Data0);

            if (data0 != null)
            {
                data0.NicIPv4Settings.Controller0IPv4Address = ConfigurationManager.AppSettings["FreeIpForTestAppliance1"];
                data0.NicIPv4Settings.Controller1IPv4Address = ConfigurationManager.AppSettings["FreeIpForTestAppliance2"];
                data0.IsEnabled = true;
                data0.IsCloudEnabled = true;
                data0.IsIScsiEnabled = true;
            }

            details.Chap = null;
            details.DnsServer = null;
            details.Snapshot = null;
            details.WebProxy = null;
            details.SecretEncryptionCertThumbprint = null;
            details.RemoteMgmtSettingsInfo = null;
            details.RemoteMinishellSecretInfo = null;
            details.VirtualApplianceProperties = null;
            
            details.DeviceProperties.Description = TestUtilities.GenerateName("TestDescription");
            details.DeviceProperties.FriendlyName = TestUtilities.GenerateName("TestFriendlyName");

            details.TimeServer.Secondary.Clear();
            details.TimeServer.Secondary.Add("3.in.pool.ntp.org");
            if (details.TimeServer.TimeZone == null)
            {
                details.TimeServer.TimeZone = "Pacific Standard Time";
            }
        }
    }
}

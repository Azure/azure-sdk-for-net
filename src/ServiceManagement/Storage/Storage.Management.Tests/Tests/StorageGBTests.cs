using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Testing;

namespace Storage.Management.Tests.Tests
{
    public class StorageGBTests : TestBase
    {
        [Fact]
        public void TestLabelAndContraintsForGB()
        {
            var storage = TestBase.GetServiceClient<StorageManagementClient>();
            var manage = TestBase.GetManagementClient();
            string account = "mygbstore001";
            string location = TestUtilities.GetDefaultLocation(manage, "Storage");
            var createResponse = storage.StorageAccounts.Create(new StorageAccountCreateParameters
            {
                ServiceName = account,
                Description = " ،؟ئبتجدرشعەﭖﭙﯓﯿﺉﺒﻺﻼ",
                Location = location,
                Label = " ،؟ئبتجدرشعەﭖﭙﯓﯿﺉﺒﻺﻼ",
                GeoReplicationEnabled = true,
            });

            var getResponse = storage.StorageAccounts.Get(account);
        }
    }
}

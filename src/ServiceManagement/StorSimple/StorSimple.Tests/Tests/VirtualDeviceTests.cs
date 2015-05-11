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
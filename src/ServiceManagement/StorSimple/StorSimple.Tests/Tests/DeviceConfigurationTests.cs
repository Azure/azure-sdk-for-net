using System.Linq;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class DeviceConfigurationTests : StorSimpleTestBase
    {
        [Fact]
        public void CanGetAllDevicesTest()
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
            }
        }

        
         
    }
}
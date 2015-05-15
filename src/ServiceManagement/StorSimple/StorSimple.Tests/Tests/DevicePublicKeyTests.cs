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
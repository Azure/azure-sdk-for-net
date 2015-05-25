using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class IscsiConnectionDetailsTest : StorSimpleTestBase
    {
        [Fact]
        public void CanGetIscsiConnectionDetailsTest()
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
                
                var iscsiconnections = client.IscsiConnection.Get(actualdeviceId,
                    GetCustomRequestHeaders());
                
                Assert.True(iscsiconnections != null);
            }
        }
    }
}

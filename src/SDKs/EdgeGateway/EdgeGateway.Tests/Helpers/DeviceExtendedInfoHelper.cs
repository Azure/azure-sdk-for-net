using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {
        public static DataBoxEdgeDeviceExtendedInfo GetExtendedInformation(string deviceName,
                    DataBoxEdgeManagementClient client,
                    string resourceGroupName)
        {
            return client.Devices.GetExtendedInformation(deviceName, resourceGroupName);
        }

    }
}

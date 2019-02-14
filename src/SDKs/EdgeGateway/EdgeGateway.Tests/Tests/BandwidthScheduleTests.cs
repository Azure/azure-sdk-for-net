using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    public class BandwidthScheduleTests : EdgeGatewayTestBase
    {
        #region Constructor
        public BandwidthScheduleTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_BandwidthSchedule()
        {
            BandwidthSchedule schedule = TestUtilities.GetBWSObject();

            // Create a bandwidth schedule
            Client.BandwidthSchedules.CreateOrUpdate(TestConstants.GatewayResourceName, "schedule-1", schedule, TestConstants.DefaultResourceGroupName);

            // Get a bandwidth schedule by name
            var bandwidthSchedule = Client.BandwidthSchedules.Get(TestConstants.GatewayResourceName, "schedule-1", TestConstants.DefaultResourceGroupName);

            // List all schedules in device
            string contiuationToken = null;
            var bandwidthSchedules = TestUtilities.ListBandwidthSchedules(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, out contiuationToken);

            // Delete a schedules by name
            Client.BandwidthSchedules.Delete(TestConstants.GatewayResourceName, "schedule-1", TestConstants.DefaultResourceGroupName);

        }
        #endregion Test Methods

    }
}

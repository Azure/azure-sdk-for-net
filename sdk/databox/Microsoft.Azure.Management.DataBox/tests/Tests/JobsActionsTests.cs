using System;
using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Xunit;
using Xunit.Abstractions;

namespace DataBox.Tests.Tests
{
    public class JobsActionsTests : DataBoxTestBase
    {
        public JobsActionsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }        

        [Fact]
        public void TestListCredentials()
        {
            try
            {
                var secrets = this.Client.Jobs.ListCredentials(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName);
                Assert.True(secrets != null, "Call for list secrets was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }        

        [Fact]
        public void TestBookShipmentPickup()
        {
            var shipmentPickupRequest = new ShipmentPickUpRequest
            {
                ShipmentLocation = "Front desk",
                StartTime = DateTime.Today,
                EndTime = DateTime.Today.AddDays(2)
            };
            try
            {
                var response = this.Client.Jobs.BookShipmentPickUp(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName, shipmentPickupRequest);
                Assert.True(response != null, "Call for book shipment pickup was not successful.");
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }
        }

    }
}


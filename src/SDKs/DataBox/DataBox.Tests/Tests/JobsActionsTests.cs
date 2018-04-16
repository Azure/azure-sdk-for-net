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
        public void TestGetCopyLogsUri()
        {
            try
            {
                var copyLogsUri = this.Client.Jobs.GetCopyLogsUri(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName);
                Assert.True(copyLogsUri != null, "Call for copy logs uri was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestDownloadShippingLabelUri()
        {
            try
            {
                var shippingLabelUri = this.Client.Jobs.DownloadShippingLabelUri(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName);
                Assert.True(shippingLabelUri != null, "Call for download shipping label uri was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestListSecrets()
        {
            try
            {
                var secrets = this.Client.ListSecrets.ListByJobs(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName);
                Assert.True(secrets != null, "Call for list secrets was not successful.");
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestReportIssue()
        {
            try
            {
                this.Client.Jobs.ReportIssue(TestConstants.DefaultResourceGroupName, TestConstants.DefaultJobName,
                    IssueType.DeviceFailure, DeviceIssueType.DeviceNotBootingUp);
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
                Assert.Null(e);
            }
        }

    }
}

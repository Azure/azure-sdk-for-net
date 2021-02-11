using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.NetApp;
using NetApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Xunit;

namespace NetApp.Tests.ResourceTests
{
    public class ResourceAvailabilityTests : TestBase
    {
        [Fact(Skip ="Manifest not released yet")]
        public void CheckQuotaAvailability()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var checkQuotaAvailabilityResponse = netAppMgmtClient.NetAppResource.CheckQuotaAvailability(ResourceUtils.location, ResourceUtils.accountName1, "Microsoft.NetApp/netAppAccounts", ResourceUtils.resourceGroup);

                Assert.NotNull(checkQuotaAvailabilityResponse);
                Assert.True(checkQuotaAvailabilityResponse.IsAvailable);
            }
        }
        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.SnapshotTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}

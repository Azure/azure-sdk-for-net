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
using System.Linq;

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
        
        [Fact]
        public void GetQuotaLimit()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var getQuotaLimit = netAppMgmtClient.NetAppResourceQuotaLimits.Get(ResourceUtils.location, quotaLimitName: "totalVolumesPerSubscription");
                Assert.NotNull(getQuotaLimit);
            }
        }

        [Fact(Skip = "Service side bug not released yet")]
        public void ListQuotaLimits()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var quotaLimitList = netAppMgmtClient.NetAppResourceQuotaLimits.List(ResourceUtils.location);
                Assert.NotNull(quotaLimitList);
                Assert.NotEmpty(quotaLimitList);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.ResourceAvailabilityTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}

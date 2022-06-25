using System;
using System.Collections.Generic;
using System.Text;
using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using System.IO;
using QuotaType = Microsoft.Azure.Management.NetApp.Models.Type;
using System.Reflection;
using System.Net;

namespace NetApp.Tests.ResourceTests
{
    public class VolumeQuotaRulesTests : TestBase
    {          
        [Fact(Skip = "Manifest not released yet")]        
        public void CreateVolumeQuotaRule()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                var resource = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), resource.ExportPolicy.ToString());
                // check DP properties exist but unassigned because
                // dataprotection volume was not created
                Assert.Null(resource.VolumeType);
                Assert.Null(resource.DataProtection);

                var volumesBefore = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Single(volumesBefore);

                //Try to Create volume quota rule
                var quotaRuleObject = new VolumeQuotaRule()
                {
                    QuotaSizeInKiBs = 100006,
                    QuotaType = QuotaType.DefaultUserQuota,
                    QuotaTarget = "1821"
                };
                var quotaRule = netAppMgmtClient.VolumeQuotaRules.Create(quotaRuleObject, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.volumeQuotaRule1);
                Assert.NotNull(quotaRule);
                var quotaRulesList = netAppMgmtClient.VolumeQuotaRules.ListByVolume(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                var quotaRulesGet = netAppMgmtClient.VolumeQuotaRules.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.volumeQuotaRule1);

                Assert.Single(quotaRulesList);
                Assert.NotNull(quotaRulesGet);
                Assert.Equal(100006, quotaRulesGet.QuotaSizeInKiBs);

                // delete the quotaRule and check again
                netAppMgmtClient.VolumeQuotaRules.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.volumeQuotaRule1);
                var quotaRulesDeletedList = netAppMgmtClient.VolumeQuotaRules.ListByVolume(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Empty(quotaRulesDeletedList);

                // delete the volume and check again
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                var volumesAfter = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Empty(volumesAfter);

                // cleanup
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.VolumeQuotaRulesTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}

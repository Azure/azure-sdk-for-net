using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System.Threading;

namespace NetApp.Tests.ResourceTests
{
    public class SnapshotPolicyTests : TestBase
    {
        [Fact]
        public void CreateDeleteSnapshotPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });                
                //create account
                ResourceUtils.CreateAccount(netAppMgmtClient);
                var snapshotPolicy = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName1);

                // create the snapshotPolicy
                //ResourceUtils.CreateSnapshot(netAppMgmtClient);                
                var snapshotsBefore = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);

                // check snapshotPolicy exists
                var snapshotPolciesBefore = netAppMgmtClient.SnapshotPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Single(snapshotPolciesBefore);
                
                var resultSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                Assert.Equal($"{ResourceUtils.accountName1}/{ResourceUtils.snapshotPolicyName1}", resultSnapshotPolicy.Name);
                // delete the snapshotPolicy and check again
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                var snapshotsAfter = netAppMgmtClient.SnapshotPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Empty(snapshotsAfter);

                // cleanup - remove the resources                
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void ListSnapshotPolicies()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                ResourceUtils.CreateAccount(netAppMgmtClient);
                // create two snapshots under same account
                var snapshotPolicy1 = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName1);
                var snapshotPolicy2 = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName2);
                var resultSnapshotPolicy1 = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy1, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                var resultSnapshotPolicy2  = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy2, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName2);


                // get the snapshotPolicy list and check
                var snapshotPolicies = netAppMgmtClient.SnapshotPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Equal($"{ResourceUtils.accountName1}/{ResourceUtils.snapshotPolicyName1}", snapshotPolicies.ElementAt(0).Name );
                Assert.Equal($"{ResourceUtils.accountName1}/{ResourceUtils.snapshotPolicyName2}", snapshotPolicies.ElementAt(1).Name);
                Assert.Equal(2, snapshotPolicies.Count());

                // clean up
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName2);                
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetSnapshotPolicyByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            { 
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                //Create account
                ResourceUtils.CreateAccount(netAppMgmtClient);
                var snapshotPolicy = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName1);

                // create the snapshotPolicy                
                var createSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
            
                var resultSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                Assert.Equal($"{ResourceUtils.accountName1}/{ResourceUtils.snapshotPolicyName1}", resultSnapshotPolicy.Name);
                Assert.Equal(createSnapshotPolicy.Name, resultSnapshotPolicy.Name);
                // cleanup - remove the resources
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void CreateVolumeWithSnapshotPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the Pool and account
                ResourceUtils.CreatePool(netAppMgmtClient);
                // create the snapshotPolicy
                var snapshotPolicy = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName1);
                var createSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);

                // Create volume with snapshotPolicy
                var createVolume = ResourceUtils.CreateVolume(netAppMgmtClient, snapshotPolicyId: createSnapshotPolicy.Id);
                Assert.NotNull(createVolume.DataProtection);
                Assert.NotNull(createVolume.DataProtection.Snapshot);
                Assert.NotNull(createVolume.DataProtection.Snapshot.SnapshotPolicyId);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                //Get volume and check
                var getVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.NotNull(getVolume.DataProtection);
                Assert.NotNull(getVolume.DataProtection.Snapshot);
                Assert.NotNull(getVolume.DataProtection.Snapshot.SnapshotPolicyId);

                //ListVolumes 
                ///TODO this is not ready, due to an issue with the result causing serialization errors, needs service side fix will be added in 2020-11-01
                //var listVolumes = netAppMgmtClient.SnapshotPolicies.ListVolumes(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                //Assert.NotNull(listVolumes);

                // clean up                
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);                
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }


        [Fact]
        public void PatchSnapshotPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                //Create acccount
                
                ResourceUtils.CreateAccount(netAppMgmtClient);
                //create the snapshotPolicy
                var snapshotPolicy = CreatePolicy(ResourceUtils.location, ResourceUtils.snapshotPolicyName1);
                var createSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Create(snapshotPolicy, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);


                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value1");

                var patchDailySchedule = new DailySchedule(1, 1, 1);
                // Now try and modify it                
                var patchSnapshotPolicy = new SnapshotPolicyPatch()
                {
                    //DailySchedule = patchDailySchedule,
                    Tags = dict,
                    DailySchedule = patchDailySchedule
                };

                var resultSnapshotPolicy = netAppMgmtClient.SnapshotPolicies.Update(patchSnapshotPolicy, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                Assert.NotNull(resultSnapshotPolicy);                               
                Assert.NotNull(resultSnapshotPolicy.DailySchedule);
                //Assert.Equal(patchDailySchedule.SnapshotsToKeep, resultSnapShotPolicy.DailySchedule.SnapshotsToKeep);

                // cleanup
                netAppMgmtClient.SnapshotPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.snapshotPolicyName1);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        private static SnapshotPolicy CreatePolicy(string location , string name = "")
        {
            // Create basic policy records with a selection of data
            HourlySchedule HourlySchedule = new HourlySchedule
            {
                SnapshotsToKeep = 2,
                Minute = 50
            };

            DailySchedule DailySchedule = new DailySchedule
            {
                SnapshotsToKeep = 4,
                Hour = 14,
                Minute = 30
            };

            WeeklySchedule WeeklySchedule = new WeeklySchedule
            {
                SnapshotsToKeep = 3,
                Day = "Wednesday",
                Hour = 14,
                Minute = 45
            };

            MonthlySchedule MonthlySchedule = new MonthlySchedule
            {
                SnapshotsToKeep = 5,
                DaysOfMonth = "10,11,12",
                Hour = 14,
                Minute = 15
            };

            SnapshotPolicy testSnapshotPolicy = new SnapshotPolicy(location: location, name: name)
            {                
                Enabled = true,
                HourlySchedule = HourlySchedule,
                DailySchedule = DailySchedule,
                WeeklySchedule = WeeklySchedule,
                MonthlySchedule = MonthlySchedule
            };

            return testSnapshotPolicy;
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.SnapshotTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}

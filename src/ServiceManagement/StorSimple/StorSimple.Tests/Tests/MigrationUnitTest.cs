// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Configuration;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using StorSimple.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace StorSimple.Tests.Tests
{
    public class MigrationHydraSpecTest : StorSimpleTestBase
    {
        private LegacyApplianceConfig CreateConfig()
        {
            LegacyApplianceConfigTestParser parser = new LegacyApplianceConfigTestParser();
            string configpath = Path.Combine(System.Environment.CurrentDirectory, "Data");
            configpath = Path.Combine(configpath, ConfigurationManager.AppSettings["MigrationUnitTestConfig"]);
            LegacyApplianceConfig config = parser.ParseLegacyApplianceTestConfig(configpath);
            config.DeviceId = ConfigurationManager.AppSettings["MigrationTargetDeviceID"];
            return config;
        }

        [Fact]
        public void VerifyMigration()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = GetServiceClient<StorSimpleManagementClient>();
                LegacyApplianceConfig config = CreateConfig();

                List<MigrationDataContainer> dcList = new List<MigrationDataContainer>(config.CloudConfigurations);
                List<string> dcNameList = dcList.Select(migrationDC => migrationDC.Name).ToList();

                // Import legacy appliance config returns void, other than http status code. An exception from hydra spec if the http response code is not expected
                client.MigrateLegacyAppliance.ImportLegacyApplianceConfig(config.InstanceId, config, GetCustomRequestHeaders());

                MigrationPlanStartRequest startMigrationPlanRequest = new MigrationPlanStartRequest() { ConfigId = config.InstanceId, DataContainerNameList = dcNameList};
                client.MigrateLegacyAppliance.StartMigrationPlan(startMigrationPlanRequest, GetCustomRequestHeaders());
                client.MigrateLegacyAppliance.UpdateMigrationPlan(config.InstanceId, GetCustomRequestHeaders());
                var getmigrationPlanResponse = client.MigrateLegacyAppliance.GetMigrationPlan(config.InstanceId, GetCustomRequestHeaders());
                Assert.NotNull(getmigrationPlanResponse);
                Assert.NotNull(getmigrationPlanResponse.MigrationPlans);
                Assert.True(1 == getmigrationPlanResponse.MigrationPlans.Count);
                Assert.NotNull(getmigrationPlanResponse.MigrationPlans[0].MigrationPlanInfo);                
                Assert.True(dcList.Count == getmigrationPlanResponse.MigrationPlans[0].MigrationPlanInfo.Count);
                List<MigrationPlanInfo> migrationPlanInfoList = new List<MigrationPlanInfo>(getmigrationPlanResponse.MigrationPlans[0].MigrationPlanInfo);
                
                Assert.True(0 == migrationPlanInfoList.FindAll(plan=>!dcNameList.Contains(plan.DataContainerName)).Count);

                var getmigrationAllPlanResponse = client.MigrateLegacyAppliance.GetAllMigrationPlan(GetCustomRequestHeaders());
                Assert.NotNull(getmigrationAllPlanResponse);                 
                Assert.NotNull(getmigrationAllPlanResponse.MigrationPlans);
                Assert.True(0 < getmigrationAllPlanResponse.MigrationPlans.Count);
                List<MigrationPlan> allPlans = new List<MigrationPlan>(getmigrationAllPlanResponse.MigrationPlans);
                Assert.True(null != allPlans.Find(plan => plan.ConfigId == config.InstanceId));


                MigrationImportDataContainerRequest importDCRequest = new MigrationImportDataContainerRequest() { DataContainerNames = new List<string>() };
                client.MigrateLegacyAppliance.MigrationImportDataContainer(config.InstanceId, importDCRequest, GetCustomRequestHeaders());
                client.MigrateLegacyAppliance.UpdateDataContainerMigrationStatus(config.InstanceId, GetCustomRequestHeaders());
                var getMigrationStatus = client.MigrateLegacyAppliance.GetDataContainerMigrationStatus(config.InstanceId, GetCustomRequestHeaders());
                Assert.NotNull(getMigrationStatus);
                Assert.NotNull(getMigrationStatus.MigrationDataContainerStatuses);
                List<MigrationDataContainerStatus> migrationStatusList = new List<MigrationDataContainerStatus>(getMigrationStatus.MigrationDataContainerStatuses);
                Assert.True(dcList.Count == migrationStatusList.Count);
                Assert.True(0 == migrationStatusList.FindAll(status=>!dcNameList.Contains(status.CloudConfigurationName)).Count);

                // Migration will start only after 12mins and will take roughly around 14mins to complete for single dc.
                TestUtilities.Wait(14 * 60 * 1000);

                DateTime timeOutTime = DateTime.UtcNow.AddMinutes(6);
                while (true)
                {
                    if(0 <= DateTime.UtcNow.CompareTo(timeOutTime))
                    {
                        throw new System.TimeoutException("Import DC did not completed in expected time");
                    }
                    client.MigrateLegacyAppliance.UpdateDataContainerMigrationStatus(config.InstanceId, GetCustomRequestHeaders());
                    var migrationStatus = client.MigrateLegacyAppliance.GetDataContainerMigrationStatus(config.InstanceId, GetCustomRequestHeaders());
                    List<MigrationDataContainerStatus> statusList = new List<MigrationDataContainerStatus>(migrationStatus.MigrationDataContainerStatuses);
                    if(dcList.Count != statusList.FindAll(status=>MigrationStatus.Completed == status.Status || MigrationStatus.Failed == status.Status).Count)
                    {
                        TestUtilities.Wait(30 * 1000);
                    }
                    else
                    {
                        break;
                    }
                }

                MigrationConfirmStatusRequest confirmRequest = new MigrationConfirmStatusRequest() { DataContainerNameList = new List<string>(), Operation = MigrationOperation.Commit };
                client.MigrateLegacyAppliance.ConfirmMigration(config.InstanceId, confirmRequest, GetCustomRequestHeaders());
                client.MigrateLegacyAppliance.UpdateMigrationConfirmStatus(config.InstanceId, GetCustomRequestHeaders());
                var getConfirmStatus = client.MigrateLegacyAppliance.GetMigrationConfirmStatus(config.InstanceId, GetCustomRequestHeaders());
                Assert.NotNull(getConfirmStatus);
                Assert.NotNull(getConfirmStatus.ContainerConfirmStatus);
                List<MigrationContainerConfirmStatus> confirmStatusList = new List<MigrationContainerConfirmStatus>(getConfirmStatus.ContainerConfirmStatus);
                Assert.True(dcList.Count == confirmStatusList.Count);
                Assert.True(0 == confirmStatusList.FindAll(status => !dcNameList.Contains(status.CloudConfigurationName)).Count);
            }
        }
    }
}
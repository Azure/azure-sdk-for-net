// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabServicesScheduleTests : LabServicesManagementTestBase
    {
        public LabServicesScheduleTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task LabServicesScheduleCRUD()
        {
            // Prepare lab resource
            var rg = await CreateResourceGroupAsync();
            var labCollection = rg.GetLabs();
            var labData = GetLabData();
            var labName = Recording.GenerateAssetName("sdklab-");
            var lab = (await labCollection.CreateOrUpdateAsync(WaitUntil.Completed, labName, labData)).Value;

            // Create test
            var scheduleCollection = lab.GetLabServicesSchedules();
            var scheduleData = GetScheduleData();
            var scheduleName = Recording.GenerateAssetName("sdklabsch-");
            var schedule = (await scheduleCollection.CreateOrUpdateAsync(WaitUntil.Completed, scheduleName, scheduleData)).Value;
            AssertSchedule(scheduleData, schedule.Data);

            // Get test - 1
            schedule = await scheduleCollection.GetAsync(scheduleName);
            AssertSchedule(scheduleData, schedule.Data);

            // Update test with PUT
            scheduleData.Notes = BinaryData.FromString("\"New Schedule for students\"");
            schedule = (await scheduleCollection.CreateOrUpdateAsync(WaitUntil.Completed, scheduleName, scheduleData)).Value;
            AssertSchedule(scheduleData, schedule.Data);

            // Get test - 2
            schedule = await schedule.GetAsync();
            AssertSchedule(scheduleData, schedule.Data);

            // Update with PATCH
            scheduleData.TimeZoneId = "America/New_York";
            var patch = new LabServicesSchedulePatch()
            {
                TimeZoneId = "America/New_York"
            };
            schedule = await schedule.UpdateAsync(patch);
            AssertSchedule(scheduleData, schedule.Data);

            // Exists test
            bool boolResult = await scheduleCollection.ExistsAsync(scheduleName);
            Assert.IsTrue(boolResult);

            // GetAll test
            var list = await scheduleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            AssertSchedule(scheduleData, list[0].Data);

            // Delete test
            await schedule.DeleteAsync(WaitUntil.Completed);
            boolResult = await scheduleCollection.ExistsAsync(scheduleName);
            Assert.IsFalse(boolResult);
        }

        public LabServicesScheduleData GetScheduleData()
        {
            return new LabServicesScheduleData()
            {
                StartOn = DateTimeOffset.Parse("2020-05-26T12:00:00Z"),
                StopOn = DateTimeOffset.Parse("2020-05-26T18:00:00Z"),
                RecurrencePattern = new LabServicesRecurrencePattern(LabServicesRecurrenceFrequency.Daily, DateTimeOffset.Parse("2020-08-14T23:59:59Z"))
                {
                    Interval = 2,
                },
                TimeZoneId = "America/Los_Angeles",
                Notes = BinaryData.FromString("\"Schedule 1 for students\""),
            };
        }

        public LabData GetLabData()
        {
            return new LabData(DefaultLocation)
            {
                Title = "test lab",
                AutoShutdownProfile = new LabAutoShutdownProfile()
                {
                    ShutdownOnDisconnect = LabServicesEnableState.Disabled,
                    ShutdownOnIdle = LabVirtualMachineShutdownOnIdleMode.UserAbsence,
                    ShutdownWhenNotConnected = LabServicesEnableState.Disabled,
                    IdleDelay = TimeSpan.FromMinutes(15)
                },
                ConnectionProfile = new LabConnectionProfile()
                {
                    ClientRdpAccess = LabVirtualMachineConnectionType.Public,
                    ClientSshAccess = LabVirtualMachineConnectionType.Public,
                    WebRdpAccess = LabVirtualMachineConnectionType.None,
                    WebSshAccess = LabVirtualMachineConnectionType.None
                },
                VirtualMachineProfile = new LabVirtualMachineProfile(
                    createOption: LabVirtualMachineCreateOption.TemplateVm,
                    imageReference: new LabVirtualMachineImageReference()
                    {
                        Sku = "20_04-lts",
                        Offer = "0001-com-ubuntu-server-focal",
                        Publisher = "canonical",
                        Version = "latest"
                    },
                    sku: new LabServicesSku("Standard_Fsv2_2_4GB_64_S_SSD")
                    {
                        Capacity = 0
                    },
                    usageQuota: TimeSpan.FromHours(2),
                    adminUser: new LabVirtualMachineCredential("tester")
                    {
                        // Set the password if not in playback mode
                        Password = Mode == RecordedTestMode.Playback ? "Sanitized" : Environment.GetEnvironmentVariable("USER_PWD"),
                    }
                    )
                {
                    UseSharedPassword = LabServicesEnableState.Enabled
                },
                SecurityProfile = new LabSecurityProfile()
                {
                    OpenAccess = LabServicesEnableState.Disabled
                }
            };
        }

        public void AssertSchedule(LabServicesScheduleData expected, LabServicesScheduleData actual)
        {
            Assert.AreEqual(expected.StartOn, actual.StartOn);
            Assert.AreEqual(expected.StopOn, actual.StopOn);
            Assert.AreEqual(expected.RecurrencePattern.Frequency, actual.RecurrencePattern.Frequency);
            Assert.AreEqual(expected.RecurrencePattern.ExpireOn, actual.RecurrencePattern.ExpireOn);
            Assert.AreEqual(expected.RecurrencePattern.Interval, actual.RecurrencePattern.Interval);
            Assert.AreEqual(expected.TimeZoneId, actual.TimeZoneId);
            Assert.AreEqual(expected.Notes.ToString(), actual.Notes.ToString());
        }
    }
}

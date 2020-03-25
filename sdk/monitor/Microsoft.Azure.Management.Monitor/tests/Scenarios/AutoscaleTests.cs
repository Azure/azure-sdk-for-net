// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Globalization;

namespace Monitor.Tests.Scenarios
{
    public class AutoscaleTests : TestBase
    {
        private const string ResourceGroup = "vmscalesetrg";
        private const string ResourceUri = "/subscriptions/{0}/resourceGroups/" + ResourceGroup + "/providers/Microsoft.Compute/virtualMachineScaleSets/vmscaleset";
        private const string Location = "eastus";
        private const string SettingName = "setting1";

        private RecordedDelegatingHandler handler;

        public AutoscaleTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void MetricBasedFixedAndRecurrent()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // NOTE: checking the existence of the resource group here is not that useful since the scale set must also exist
                var insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroup, location: Location);

                AutoscaleSettingResource body = CreateAutoscaleSetting(
                    location: Location, 
                    resourceUri: string.Format(
                        provider: CultureInfo.InvariantCulture,
                        format: ResourceUri,
                        args: insightsClient.SubscriptionId),
                    metricName: "Percentage CPU");
                AutoscaleSettingResource actualResponse = insightsClient.AutoscaleSettings.CreateOrUpdate(
                    resourceGroupName: ResourceGroup, 
                    autoscaleSettingName: SettingName, 
                    parameters: body);

                if (!this.IsRecording)
                {
                    Check(actualResponse);
                }

                // Retrieve the setting created above
                AutoscaleSettingResource recoveredSetting = insightsClient.AutoscaleSettings.Get(
                    resourceGroupName: ResourceGroup,
                    autoscaleSettingName: SettingName);

                if (!this.IsRecording)
                {
                    Check(recoveredSetting);

                    // Compare the two of them
                    Utilities.AreEqual(actualResponse, recoveredSetting);
                }

                var newTags = new Dictionary<string, string>
                    {
                        { "key2", "val2" }
                    };

                // Update the setting created above
                // TODO: File bug since the request fails due to 'invalid location'
                AutoscaleSettingResourcePatch pathResource = new AutoscaleSettingResourcePatch(
                    name: recoveredSetting.Name,
                    tags: newTags,
                    notifications: recoveredSetting.Notifications,
                    enabled: !recoveredSetting.Enabled,
                    profiles: recoveredSetting.Profiles,
                    targetResourceUri: recoveredSetting.TargetResourceUri
                );

                AutoscaleSettingResource updatedSetting = null;
                Assert.Throws<ErrorResponseException>( 
                    () => updatedSetting = insightsClient.AutoscaleSettings.Update(
                        resourceGroupName: ResourceGroup,
                        autoscaleSettingName: SettingName,
                        autoscaleSettingResource: pathResource));

                if (!this.IsRecording && updatedSetting != null)
                {
                    Check(updatedSetting);

                    // Check the changes from above
                    Assert.NotEqual(recoveredSetting.Tags, updatedSetting.Tags);
                    Assert.True(recoveredSetting.Enabled = !updatedSetting.Enabled);
                    Assert.Equal(recoveredSetting.Name, updatedSetting.Name);
                    Assert.Equal(recoveredSetting.Location, updatedSetting.Location);
                    Assert.Equal(recoveredSetting.Id, updatedSetting.Id);
                }

                // Retrieve again the setting created above
                AutoscaleSettingResource recoveredUpdatedSetting = insightsClient.AutoscaleSettings.Get(
                    resourceGroupName: ResourceGroup,
                    autoscaleSettingName: SettingName);

                if (!this.IsRecording && updatedSetting != null)
                {
                    Check(recoveredUpdatedSetting);

                    // Compare the two of them
                    Assert.NotEqual(recoveredSetting.Tags, recoveredUpdatedSetting.Tags);
                    Assert.True(recoveredSetting.Enabled = !recoveredUpdatedSetting.Enabled);
                    Assert.Equal(recoveredSetting.Name, recoveredUpdatedSetting.Name);
                    Assert.Equal(recoveredSetting.Location, recoveredUpdatedSetting.Location);
                    Assert.Equal(recoveredSetting.Id, recoveredUpdatedSetting.Id);
                }

                // Remove the setting created above
                insightsClient.AutoscaleSettings.Delete(
                    resourceGroupName: ResourceGroup,
                    autoscaleSettingName: SettingName);

                // Retrieve again the setting created above (must fail)
                Assert.Throws<ErrorResponseException>(
                    () => insightsClient.AutoscaleSettings.Get(
                        resourceGroupName: ResourceGroup,
                        autoscaleSettingName: SettingName));
            }
        }

        private static AutoscaleSettingResource CreateAutoscaleSetting(string location, string resourceUri, string metricName)
        {
            var capacity = new ScaleCapacity()
            {
                DefaultProperty = "1",
                Maximum = "10",
                Minimum = "1"
            };

            var fixedDate = new TimeWindow()
            {
                End = DateTime.Parse("2014-04-16T21:06:11.7882792Z"),
                Start = DateTime.Parse("2014-04-15T21:06:11.7882792Z"),
                TimeZone = TimeZoneInfo.Utc.Id.ToString()
            };

            var recurrence = new Recurrence()
            {
                Frequency = RecurrenceFrequency.Week,
                Schedule = new RecurrentSchedule()
                {
                    Days = new List<string> { "Monday" },
                    Hours = new List<int?> { 0 },
                    Minutes = new List<int?> { 10 },
                    TimeZone = "UTC-11"
                }
            };

            var rules = new ScaleRule[]
            {
                new ScaleRule()
                {
                    MetricTrigger = new MetricTrigger
                    {
                        MetricName = metricName,
                        MetricResourceUri = resourceUri,
                        Statistic = MetricStatisticType.Average,
                        Threshold = 80.0,
                        TimeAggregation = TimeAggregationType.Maximum,
                        TimeGrain = TimeSpan.FromMinutes(1),
                        TimeWindow = TimeSpan.FromHours(1)
                    },
                    ScaleAction = new ScaleAction
                    {
                        Cooldown = TimeSpan.FromMinutes(20),
                        Direction = ScaleDirection.Increase,
                        Value = "1",
                        Type = ScaleType.ChangeCount
                    }
                }
            };

            var profiles = new AutoscaleProfile[]
            {
                new AutoscaleProfile()
                {
                    Name = "Profile1",
                    Capacity = capacity,
                    FixedDate = fixedDate,
                    Recurrence = null,
                    Rules = rules
                },
                new AutoscaleProfile()
                {
                    Name = "Profile2",
                    Capacity = capacity,
                    FixedDate = null,
                    Recurrence = recurrence,
                    Rules = rules
                }
            };

            AutoscaleSettingResource setting = new AutoscaleSettingResource(location: Location, profiles: profiles, name: SettingName)
            {
                AutoscaleSettingResourceName = SettingName,
                TargetResourceUri = resourceUri,
                Enabled = true,
                Tags = null,
                Notifications = null
            };

            return setting;
        }

        private static void Check(AutoscaleSettingResource act)
        {
            if (act != null)
            {
                Assert.False(string.IsNullOrWhiteSpace(act.Name));
                Assert.Equal(act.Name, act.AutoscaleSettingResourceName);
                Assert.False(string.IsNullOrWhiteSpace(act.Id));
                Assert.False(string.IsNullOrWhiteSpace(act.Location));
                Assert.False(string.IsNullOrWhiteSpace(act.TargetResourceUri));
                Assert.False(string.IsNullOrWhiteSpace(act.Type));
            }
            else
            {
                // Guarantee failure, act should not be null
                Assert.NotNull(act);
            }
        }
    }
}

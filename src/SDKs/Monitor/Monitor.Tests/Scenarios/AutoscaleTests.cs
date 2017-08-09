// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Diagnostics;

namespace Monitor.Tests.Scenarios
{
    public class AutoscaleTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/vmscalesetrg/providers/Microsoft.Compute/virtualMachineScaleSets/vmscaleset";
        private const string ResourceGroup = "vmscalesetrg";

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                AutoscaleSettingResource body = CreateAutoscaleSetting(location: "East US", resourceUri: ResourceUri, metricName: "Percentage CPU");

                var insightsClient = GetMonitorManagementClient(context, handler);

                AutoscaleSettingResource actualResponse = insightsClient.AutoscaleSettings.CreateOrUpdate(
                    resourceGroupName: ResourceGroup, 
                    autoscaleSettingName: "setting1", 
                    parameters: body);

                if (!this.IsRecording)
                {
                    Check(actualResponse);
                }

                // Retrieve the setting created above
                AutoscaleSettingResource recoveredSetting = insightsClient.AutoscaleSettings.Get(
                    resourceGroupName: ResourceGroup,
                    autoscaleSettingName: "setting1");

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
                Assert.Throws(
                    typeof(ErrorResponseException), 
                    () => updatedSetting = insightsClient.AutoscaleSettings.Update(
                        resourceGroupName: ResourceGroup,
                        autoscaleSettingName: "setting1",
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
                    autoscaleSettingName: "setting1");

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
                    autoscaleSettingName: "setting1");

                // Retrieve again the setting created above (must fail)
                Assert.Throws(
                    typeof(ErrorResponseException),
                    () => insightsClient.AutoscaleSettings.Get(
                        resourceGroupName: ResourceGroup,
                        autoscaleSettingName: "setting1"));
            }
        }

        /*  write-host -fore green "Creating webhook"
            $webhook1 = New-AzureRmAutoscaleWebhook -ServiceUri "http://myservice.com"

          if (!$webhook1 -or $webhook1.ServiceUri -ne "http://myservice.com" -or $webhook1.properties.count -ne 0)
          {  
            write-host -fore red "The web hook is incorrect"
          }

            write-host -fore green "Creating notification"
          $notification1 = New-AzureRmAutoscaleNotification -Cust gu@ms.com, ge @ns.net -SendEmailToSubscriptionAdministrator -SendEmailToSubscriptionCoAdministrators

          if (!$notification1 -or $notification1.webhooks -or !$notification1.email -or !$notification1.email.customemails -or !$notification1.Email.SendToSubscriptionAdministrator -or !$notification1.Email.SendToSubscriptionCoAdministrators)
            {
                write - host - fore red "Notification is incorrect"
          }

          $notification1 = New-AzureRmAutoscaleNotification -Cust gu@ms.com, ge @ns.net -SendEmailToSubscriptionAdministrator -SendEmailToSubscriptionCoAdministrators -webhooks $webhook1

          if (!$notification1 -or !$notification1.webhooks -or !$notification1.email -or !$notification1.email.customemails -or !$notification1.Email.SendToSubscriptionAdministrator -or !$notification1.Email.SendToSubscriptionCoAdministrators)
            {
                write - host - fore red "Notification is incorrect"
          }
        */

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

            AutoscaleSettingResource setting = new AutoscaleSettingResource(location: "West US", profiles: profiles, name: "setting1")
            {
                AutoscaleSettingResourceName = "setting1",
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

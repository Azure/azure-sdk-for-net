// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Helpers
{
    public static class RecurringScheduledActionUtils
    {
/*
        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() },
        };

        private static readonly HashSet<OccurrenceState> s_activeStates = [OccurrenceState.Created, OccurrenceState.Scheduled, OccurrenceState.Rescheduling];

        public static ScheduledActionData GenerateScheduledActionData(
            string location,
            UserRequestRetryPolicy retryPolicy,
            ScheduledActionDeadlineType deadlineType,
            DateTimeOffset startsOn,
            DateTimeOffset endsOn,
            ScheduledActionType actionType,
            TimeSpan scheduleTime,
            string timezone,
            bool isDisabled)
        {
            ScheduledActionData sa =  new(new AzureLocation(location))
            {
                Properties = new ScheduledActionProperties(Models.ResourceType.VirtualMachine, actionType, startsOn, new ScheduledActionsSchedule(
                    scheduleTime,
                    timezone,
                    [WeekDay.All],
                    [Month.All],
                    [])
                {
                    ExecutionParameters = new ScheduledActionExecutionParameterDetail
                    {
                        RetryPolicy = retryPolicy,
                    },
                    DeadlineType = deadlineType,
                },
                [])
                {
                    EndOn = endsOn,
                    Disabled = isDisabled,
                },
                Tags ={},
            };

            return sa;
        }

        public static ScheduledActionData GenerateScheduledActionData(
            string scheduledActionName,
            string location,
            UserRequestRetryPolicy retryPolicy,
            ScheduledActionDeadlineType deadlineType,
            DateTimeOffset startsOn,
            DateTimeOffset endsOn,
            ScheduledActionType actionType,
            TimeSpan scheduleTime,
            string timezone,
            bool isDisabled,
            string subId,
            string rgName)
        {
            ScheduledActionProperties props = new(Models.ResourceType.VirtualMachine, actionType, startsOn, new ScheduledActionsSchedule(
                    scheduleTime,
                    timezone,
                    [WeekDay.All],
                    [Month.All],
                    [])
            {
                ExecutionParameters = new ScheduledActionExecutionParameterDetail
                {
                    RetryPolicy = retryPolicy,
                },
                DeadlineType = deadlineType,
            },
                [])
            {
                EndOn = endsOn,
                Disabled = isDisabled,
                StartOn = startsOn
            };

            ScheduledActionData scheduledAction = new(id: ResourceIdentifier.Parse($"/subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.ComputeSchedule/scheduledActions/{scheduledActionName}"), name: $"{scheduledActionName}", resourceType: "microsoft.computeschedule/scheduledactions", systemData: new SystemData(), tags: new Dictionary<string, string>(), location: new AzureLocation($"{location}"), properties: props, serializedAdditionalRawData: new Dictionary<string, BinaryData>());

            return scheduledAction;
        }

        public static string FormatCollection<T>(this IEnumerable<T> collection)
        {
            return $"[{string.Join(", ", collection.FormatComplexObject())}]";
        }

        public static string FormatComplexObject(this object obj)
        {
            return JsonConvert.SerializeObject(obj, DefaultJsonSerializerSettings);
        }

        public static ScheduledActionResourceModel[] GenerateResources(List<ResourceIdentifier> resources)
        {
            var allResources = new ScheduledActionResourceModel[resources.Count];

            if (resources.Count > 0)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    allResources[i] = new ScheduledActionResourceModel(resources[i])
                    {
                        ResourceId = resources[i],
                        NotificationSettings = {},
                    };
                }
            }
            else
            {
                allResources = [];
            }

            return allResources;
        }

        public static bool IsActive(OccurrenceData occurrence)
        {
            return occurrence.Properties != null && occurrence.Properties.ProvisioningState != null && s_activeStates.Contains(occurrence.Properties.ProvisioningState.Value);
        }

        public static void ValidateTriggeredOccurrence(OccurrenceData triggeredOccurrenceData, string scheduledActionName)
        {
            DateTimeOffset scheduledTime = triggeredOccurrenceData.Properties.ScheduledOn;
            DateTimeOffset utcNow = DateTimeOffset.UtcNow.AddMinutes(1);
            Assert.IsTrue(IsActive(triggeredOccurrenceData), $"The next occurrence of scheduledaction {scheduledActionName} should be active but has status {triggeredOccurrenceData.Properties.ProvisioningState}");

            Assert.IsFalse(scheduledTime > utcNow, $"The triggered occurrence with id {triggeredOccurrenceData.Name} should be started right now at around {utcNow} but has schedule time {scheduledTime}");
        }
*/
    }
}

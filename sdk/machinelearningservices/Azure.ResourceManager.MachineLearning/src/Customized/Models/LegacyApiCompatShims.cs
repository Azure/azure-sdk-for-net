// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Legacy API shims are grouped to keep compatibility members together.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningCertificateDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid tenantId, MachineLearningCertificateDatastoreSecrets secrets, Guid clientId, string thumbprint)
            : this(tenantId, clientId, thumbprint, secrets)
        {
        }
    }

    public partial class MachineLearningServicePrincipalDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid tenantId, MachineLearningServicePrincipalDatastoreSecrets secrets, Guid clientId)
            : this(tenantId, clientId, secrets)
        {
        }
    }

    public partial class MachineLearningObjective
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(MachineLearningGoal goal, string primaryMetric)
            : this(primaryMetric, goal)
        {
        }
    }

    public partial class MachineLearningSweepJob
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        public MachineLearningSweepJob(MachineLearningObjective objective, SamplingAlgorithm samplingAlgorithm, BinaryData searchSpace, MachineLearningTrialComponent trial)
            : this(searchSpace, samplingAlgorithm, objective, trial)
        {
        }
    }

    public partial class MachineLearningComputeStartStopSchedule
    {
        /// <summary> Required if triggerType is Cron. </summary>
        public CronTrigger Cron => CronSchedule is null ? null : new CronTrigger(endTime: null, CronSchedule.StartTime, CronSchedule.TimeZone, MachineLearningTriggerType.Cron, additionalBinaryDataProperties: null, CronSchedule.Expression);

        /// <summary> Required if triggerType is Recurrence. </summary>
        public MachineLearningRecurrenceTrigger Recurrence => RecurrenceSchedule is null
            ? null
            : new MachineLearningRecurrenceTrigger(
                endTime: null,
                RecurrenceSchedule.StartTime,
                RecurrenceSchedule.TimeZone,
                MachineLearningTriggerType.Recurrence,
                additionalBinaryDataProperties: null,
                RecurrenceSchedule.Frequency.HasValue ? new MachineLearningRecurrenceFrequency(RecurrenceSchedule.Frequency.Value.ToString()) : default,
                RecurrenceSchedule.Interval.GetValueOrDefault(),
                RecurrenceSchedule.Schedule is null ? null : new MachineLearningRecurrenceSchedule(RecurrenceSchedule.Schedule.Hours, RecurrenceSchedule.Schedule.Minutes, RecurrenceSchedule.Schedule.MonthDays, ConvertWeekDays(RecurrenceSchedule.Schedule.WeekDays), additionalBinaryDataProperties: null));

        private static IList<MachineLearningDayOfWeek> ConvertWeekDays(IEnumerable<MachineLearningComputeWeekDay> weekDays)
        {
            if (weekDays is null)
            {
                return null;
            }

            var result = new List<MachineLearningDayOfWeek>();
            foreach (var weekDay in weekDays)
            {
                result.Add(new MachineLearningDayOfWeek(weekDay.ToString()));
            }

            return result;
        }
    }

    public partial class MachineLearningWorkspacePatch
    {
        /// <summary> Whether requests from Public Network are allowed. </summary>
        public MachineLearningPublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicNetworkAccessType.HasValue ? new MachineLearningPublicNetworkAccess(PublicNetworkAccessType.Value.ToString()) : null;
            set => PublicNetworkAccessType = value.HasValue ? new PublicNetworkAccess(value.Value.ToString()) : null;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
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
}

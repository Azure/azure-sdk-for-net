// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The schedule for automatically starting and stopping a compute instance. </summary>
    public partial class MachineLearningComputeStartStopSchedule : IJsonModel<MachineLearningComputeStartStopSchedule>
    {
        // The current spec models compute start/stop schedules through the newer trigger/schedule shapes, while GA exposed this flattened
        // compatibility model from Swagger. TypeSpec decorators cannot reintroduce properties that no longer exist on a generated model,
        // so this partial preserves the shipped members and translates them to the generated trigger models where possible.
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeStartStopSchedule"/>. </summary>
        public MachineLearningComputeStartStopSchedule()
        {
        }

        internal MachineLearningComputeStartStopSchedule(string id, MachineLearningComputeProvisioningStatus? provisioningStatus, MachineLearningScheduleStatus? status, MachineLearningComputePowerAction? action, MachineLearningTriggerType? triggerType, ComputeStartStopRecurrenceSchedule recurrenceSchedule, ComputeStartStopCronSchedule cronSchedule, MachineLearningScheduleBase schedule, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            ProvisioningStatus = provisioningStatus;
            Status = status;
            Action = action;
            TriggerType = triggerType;
            RecurrenceSchedule = recurrenceSchedule;
            CronSchedule = cronSchedule;
            Schedule = schedule;
        }

        /// <summary> The ARM resource ID of the schedule. </summary>
        [WirePath("id")]
        public string Id { get; }
        /// <summary> The schedule provisioning status. </summary>
        [WirePath("provisioningStatus")]
        public MachineLearningComputeProvisioningStatus? ProvisioningStatus { get; }
        /// <summary> The schedule status. </summary>
        [WirePath("status")]
        public MachineLearningScheduleStatus? Status { get; set; }
        /// <summary> The compute power action. </summary>
        [WirePath("action")]
        public MachineLearningComputePowerAction? Action { get; set; }
        /// <summary> The trigger type. </summary>
        [WirePath("triggerType")]
        public MachineLearningTriggerType? TriggerType { get; set; }
        /// <summary> The recurrence schedule details. </summary>
        [WirePath("recurrence")]
        public ComputeStartStopRecurrenceSchedule RecurrenceSchedule { get; set; }
        /// <summary> The cron schedule details. </summary>
        [WirePath("cron")]
        public ComputeStartStopCronSchedule CronSchedule { get; set; }
        /// <summary> The schedule definition. </summary>
        [WirePath("schedule")]
        public MachineLearningScheduleBase Schedule { get; set; }

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

        internal static MachineLearningComputeStartStopSchedule DeserializeMachineLearningComputeStartStopSchedule(JsonElement element, ModelReaderWriterOptions options = null)
        {
            return new MachineLearningComputeStartStopSchedule(default, default, default, default, default, default, default, default, serializedAdditionalRawData: null);
        }

        void IJsonModel<MachineLearningComputeStartStopSchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningComputeStartStopSchedule IJsonModel<MachineLearningComputeStartStopSchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningComputeStartStopSchedule(document.RootElement, options);
        }

        /// <summary> Writes the JSON representation of the model to the provided writer. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<MachineLearningComputeStartStopSchedule>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString("{}");

        MachineLearningComputeStartStopSchedule IPersistableModel<MachineLearningComputeStartStopSchedule>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new MachineLearningComputeStartStopSchedule(default, default, default, default, default, default, default, default, serializedAdditionalRawData: null);

        string IPersistableModel<MachineLearningComputeStartStopSchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

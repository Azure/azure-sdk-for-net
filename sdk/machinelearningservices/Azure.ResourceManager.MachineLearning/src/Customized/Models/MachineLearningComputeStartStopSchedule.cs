// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Compute start stop schedule properties. </summary>
    public partial class MachineLearningComputeStartStopSchedule : ComputeStartStopSchedule, IJsonModel<MachineLearningComputeStartStopSchedule>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeStartStopSchedule"/>. </summary>
        public MachineLearningComputeStartStopSchedule()
        {
        }

        internal MachineLearningComputeStartStopSchedule(string id, MachineLearningComputeProvisioningStatus? provisioningStatus, MachineLearningScheduleStatus? status, MachineLearningComputePowerAction? action, ComputeTriggerType? triggerType, ComputeStartStopRecurrenceSchedule recurrence, ComputeStartStopCronSchedule cron, MachineLearningScheduleBase schedule, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, provisioningStatus, status, action, triggerType, recurrence, cron, schedule, additionalBinaryDataProperties)
        {
        }

        internal static new MachineLearningComputeStartStopSchedule DeserializeComputeStartStopSchedule(JsonElement element, ModelReaderWriterOptions options)
        {
            ComputeStartStopSchedule schedule = ComputeStartStopSchedule.DeserializeComputeStartStopSchedule(element, options);
            if (schedule is null)
            {
                return null;
            }

            return new MachineLearningComputeStartStopSchedule(
                schedule.Id,
                schedule.ProvisioningStatus,
                schedule.Status,
                schedule.Action,
                schedule.TriggerType,
                schedule.Recurrence,
                schedule.Cron,
                schedule.Schedule,
                null);
        }

        /// <summary> Required if triggerType is Recurrence. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new MachineLearningRecurrenceTrigger Recurrence
        {
            get
            {
                return base.Recurrence is null || !base.Recurrence.Frequency.HasValue || !base.Recurrence.Interval.HasValue
                    ? null
                    : new MachineLearningRecurrenceTrigger(new MachineLearningRecurrenceFrequency(base.Recurrence.Frequency.Value.ToString()), base.Recurrence.Interval.Value);
            }
        }

        /// <summary> Required if triggerType is Cron. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new CronTrigger Cron
        {
            get
            {
                return base.Cron is null ? null : new CronTrigger(base.Cron.Expression);
            }
        }

        /// <summary> Required if triggerType is Cron. </summary>
        [WirePath("cron")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ComputeStartStopCronSchedule CronSchedule
        {
            get => base.Cron;
            set => base.Cron = value;
        }

        /// <summary> Required if triggerType is Recurrence. </summary>
        [WirePath("recurrence")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ComputeStartStopRecurrenceSchedule RecurrenceSchedule
        {
            get => base.Recurrence;
            set => base.Recurrence = value;
        }

        /// <summary> The schedule trigger type. </summary>
        [WirePath("triggerType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new MachineLearningTriggerType? TriggerType
        {
            get => base.TriggerType.HasValue ? new MachineLearningTriggerType(base.TriggerType.Value.ToString()) : null;
            set => base.TriggerType = value.HasValue ? new ComputeTriggerType(value.Value.ToString()) : null;
        }

        void IJsonModel<MachineLearningComputeStartStopSchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ComputeStartStopSchedule>)this).Write(writer, options);
        }

        MachineLearningComputeStartStopSchedule IJsonModel<MachineLearningComputeStartStopSchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComputeStartStopSchedule(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningComputeStartStopSchedule>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ComputeStartStopSchedule>)this).Write(options);
        }

        MachineLearningComputeStartStopSchedule IPersistableModel<MachineLearningComputeStartStopSchedule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningComputeStartStopSchedule>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeComputeStartStopSchedule(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningComputeStartStopSchedule)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningComputeStartStopSchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

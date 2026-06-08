// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Sweep job definition. </summary>
    public partial class MachineLearningSweepJob : SweepJob, IJsonModel<MachineLearningSweepJob>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        public MachineLearningSweepJob(MachineLearningObjective objective, SamplingAlgorithm samplingAlgorithm, BinaryData searchSpace, MachineLearningTrialComponent trial) : base(objective, samplingAlgorithm, searchSpace, trial)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningSweepJob"/>. </summary>
        public MachineLearningSweepJob(BinaryData searchSpace, SamplingAlgorithm samplingAlgorithm, MachineLearningObjective objective, MachineLearningTrialComponent trial) : this(objective, samplingAlgorithm, searchSpace, trial)
        {
        }

        internal MachineLearningSweepJob(string description, IDictionary<string, string> properties, IDictionary<string, string> tags, ResourceIdentifier componentId, ResourceIdentifier computeId, string displayName, string experimentName, MachineLearningIdentityConfiguration identity, bool? isArchived, NotificationSetting notificationSetting, IDictionary<string, MachineLearningJobService> services, MachineLearningJobStatus? status, MachineLearningEarlyTerminationPolicy earlyTermination, IDictionary<string, MachineLearningJobInput> inputs, MachineLearningSweepJobLimits limits, MachineLearningObjective objective, IDictionary<string, MachineLearningJobOutput> outputs, QueueSettings queueSettings, SamplingAlgorithm samplingAlgorithm, BinaryData searchSpace, MachineLearningTrialComponent trial)
            : base(description, properties, tags, additionalBinaryDataProperties: null, componentId, computeId, displayName, experimentName, identity, isArchived, JobType.Sweep, notificationSetting, parentJobName: default, services, status, earlyTermination, inputs, limits, objective, outputs, queueSettings, samplingAlgorithm, searchSpace, trial)
        {
        }

        /// <summary> [Required] Optimization objective. </summary>
        [WirePath("objective")]
        public new MachineLearningObjective Objective
        {
            get => base.Objective as MachineLearningObjective;
            set => base.Objective = value;
        }

        void IJsonModel<MachineLearningSweepJob>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<SweepJob>)this).Write(writer, options);
        }

        MachineLearningSweepJob IJsonModel<MachineLearningSweepJob>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningSweepJob(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningSweepJob>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<SweepJob>)this).Write(options);
        }

        MachineLearningSweepJob IPersistableModel<MachineLearningSweepJob>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningSweepJob>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningSweepJob(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningSweepJob)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningSweepJob>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningSweepJob DeserializeMachineLearningSweepJob(JsonElement element, ModelReaderWriterOptions options)
        {
            SweepJob sweepJob = SweepJob.DeserializeSweepJob(element, options);
            if (sweepJob is null)
            {
                return null;
            }

            MachineLearningObjective objective = sweepJob.Objective as MachineLearningObjective;
            if (objective is null && sweepJob.Objective is not null)
            {
                objective = new MachineLearningObjective(sweepJob.Objective.Goal, sweepJob.Objective.PrimaryMetric);
            }

            return new MachineLearningSweepJob(
                sweepJob.Description,
                sweepJob.Properties,
                sweepJob.Tags,
                sweepJob.ComponentId,
                sweepJob.ComputeId,
                sweepJob.DisplayName,
                sweepJob.ExperimentName,
                sweepJob.Identity,
                sweepJob.IsArchived,
                sweepJob.NotificationSetting,
                sweepJob.Services,
                sweepJob.Status,
                sweepJob.EarlyTermination,
                sweepJob.Inputs,
                sweepJob.Limits,
                objective,
                sweepJob.Outputs,
                sweepJob.QueueSettings,
                sweepJob.SamplingAlgorithm,
                sweepJob.SearchSpace,
                sweepJob.Trial);
        }
    }
}

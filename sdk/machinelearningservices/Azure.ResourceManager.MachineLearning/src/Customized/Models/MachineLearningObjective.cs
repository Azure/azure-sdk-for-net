// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Optimization objective. </summary>
    public partial class MachineLearningObjective : Objective, IJsonModel<MachineLearningObjective>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(MachineLearningGoal goal, string primaryMetric) : base(goal, primaryMetric)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(string primaryMetric, MachineLearningGoal goal) : this(goal, primaryMetric)
        {
        }

        void IJsonModel<MachineLearningObjective>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<Objective>)this).Write(writer, options);
        }

        MachineLearningObjective IJsonModel<MachineLearningObjective>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            Objective objective = Objective.DeserializeObjective(document.RootElement, options);
            return objective is null ? null : new MachineLearningObjective(objective.Goal, objective.PrimaryMetric);
        }

        BinaryData IPersistableModel<MachineLearningObjective>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<Objective>)this).Write(options);
        }

        MachineLearningObjective IPersistableModel<MachineLearningObjective>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningObjective>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        Objective objective = Objective.DeserializeObjective(document.RootElement, options);
                        return objective is null ? null : new MachineLearningObjective(objective.Goal, objective.PrimaryMetric);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningObjective)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningObjective>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

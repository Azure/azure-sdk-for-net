// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.Analytics.OnlineExperimentation
{
    /// <summary> Partial <see cref="ExperimentMetric"/> instance for update operations. </summary>
    public class ExperimentMetricUpdate : ExperimentMetric
    {
        /// <summary> Initializes a new instance of <see cref="ExperimentMetric"/> for partial updates. </summary>
        public ExperimentMetricUpdate()
            : base(
                  id: null,
                  lifecycle: default,
                  displayName: null,
                  description: null,
                  categories: new ChangeTrackingList<string>(),
                  desiredDirection: default,
                  definition: null,
                  eTag: default,
                  lastModifiedAt: default,
                  serializedAdditionalRawData: null)
        {
        }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            WriteOptional("id"u8, Id);
            WriteOptional("lifecycle"u8, Lifecycle.ToString());
            WriteOptional("displayName"u8, DisplayName);
            WriteOptional("description"u8, Description);

            if (Optional.IsCollectionDefined(Categories))
            {
                writer.WritePropertyName("categories"u8);
                writer.WriteStartArray();
                foreach (var item in Categories)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }

            WriteOptional("desiredDirection"u8, DesiredDirection.ToString());

            // "definition" should not be updated partially
            if (Optional.IsDefined(Definition))
            {
                writer.WritePropertyName("definition"u8);
                IJsonModel<ExperimentMetricDefinition> jsonModel = Definition;
                jsonModel.Write(writer, ModelReaderWriterOptions.Json);
            }

            void WriteOptional(ReadOnlySpan<byte> key, string value)
            {
                if (Optional.IsDefined(value))
                {
                    writer.WritePropertyName(key);
                    writer.WriteStringValue(value);
                }
            }
        }
    }
}

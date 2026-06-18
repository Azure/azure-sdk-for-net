// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class QueuePurgesNotInAllowedRange : IPersistableModel<QueuePurgesNotInAllowedRange>
    {
        /// <summary> Initializes a new instance of <see cref="QueuePurgesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public QueuePurgesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "QueuePurgesNotInAllowedRange";
        }

        QueuePurgesNotInAllowedRange IJsonModel<QueuePurgesNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (QueuePurgesNotInAllowedRange)JsonModelCreateCore(ref reader, options);

        void IJsonModel<QueuePurgesNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        QueuePurgesNotInAllowedRange IPersistableModel<QueuePurgesNotInAllowedRange>.Create(BinaryData data, ModelReaderWriterOptions options) => (QueuePurgesNotInAllowedRange)PersistableModelCreateCore(data, options);

        string IPersistableModel<QueuePurgesNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<QueuePurgesNotInAllowedRange>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}

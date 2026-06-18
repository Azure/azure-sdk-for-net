// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class TwinUpdatesNotInAllowedRange : IPersistableModel<TwinUpdatesNotInAllowedRange>
    {
        /// <summary> Initializes a new instance of <see cref="TwinUpdatesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public TwinUpdatesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "TwinUpdatesNotInAllowedRange";
        }

        TwinUpdatesNotInAllowedRange IJsonModel<TwinUpdatesNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (TwinUpdatesNotInAllowedRange)JsonModelCreateCore(ref reader, options);

        void IJsonModel<TwinUpdatesNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        TwinUpdatesNotInAllowedRange IPersistableModel<TwinUpdatesNotInAllowedRange>.Create(BinaryData data, ModelReaderWriterOptions options) => (TwinUpdatesNotInAllowedRange)PersistableModelCreateCore(data, options);

        string IPersistableModel<TwinUpdatesNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<TwinUpdatesNotInAllowedRange>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}

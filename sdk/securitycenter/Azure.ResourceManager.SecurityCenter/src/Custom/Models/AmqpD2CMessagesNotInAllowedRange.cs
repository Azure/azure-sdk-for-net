// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class AmqpD2CMessagesNotInAllowedRange : IPersistableModel<AmqpD2CMessagesNotInAllowedRange>
    {
        /// <summary> Initializes a new instance of <see cref="AmqpD2CMessagesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public AmqpD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "AmqpD2CMessagesNotInAllowedRange";
        }

        AmqpD2CMessagesNotInAllowedRange IJsonModel<AmqpD2CMessagesNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (AmqpD2CMessagesNotInAllowedRange)JsonModelCreateCore(ref reader, options);

        void IJsonModel<AmqpD2CMessagesNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        AmqpD2CMessagesNotInAllowedRange IPersistableModel<AmqpD2CMessagesNotInAllowedRange>.Create(BinaryData data, ModelReaderWriterOptions options) => (AmqpD2CMessagesNotInAllowedRange)PersistableModelCreateCore(data, options);

        string IPersistableModel<AmqpD2CMessagesNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<AmqpD2CMessagesNotInAllowedRange>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}

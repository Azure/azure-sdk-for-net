// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class MqttD2CMessagesNotInAllowedRange : IPersistableModel<MqttD2CMessagesNotInAllowedRange>
    {
        /// <summary> Initializes a new instance of <see cref="MqttD2CMessagesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public MqttD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "MqttD2CMessagesNotInAllowedRange";
        }

        MqttD2CMessagesNotInAllowedRange IJsonModel<MqttD2CMessagesNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (MqttD2CMessagesNotInAllowedRange)JsonModelCreateCore(ref reader, options);

        void IJsonModel<MqttD2CMessagesNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        MqttD2CMessagesNotInAllowedRange IPersistableModel<MqttD2CMessagesNotInAllowedRange>.Create(BinaryData data, ModelReaderWriterOptions options) => (MqttD2CMessagesNotInAllowedRange)PersistableModelCreateCore(data, options);

        string IPersistableModel<MqttD2CMessagesNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<MqttD2CMessagesNotInAllowedRange>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The TypeSpec leaf uses Legacy.hierarchyBuilding to share TimeWindow/Allowlist properties through a base model; generated leaf classes therefore get only internal deserialization constructors, not the previous GA public constructor. Keep that constructor and delegate serialization to the generated partial implementation.
    public partial class HttpC2DMessagesNotInAllowedRange : IPersistableModel<HttpC2DMessagesNotInAllowedRange>
    {
        /// <summary> Initializes a new instance of <see cref="HttpC2DMessagesNotInAllowedRange"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        /// <param name="timeWindowSize"> The time window size in iso8601 format. </param>
        public HttpC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, TimeSpan timeWindowSize) : base(isEnabled, minThreshold, maxThreshold, timeWindowSize)
        {
            RuleType = "HttpC2DMessagesNotInAllowedRange";
        }

        HttpC2DMessagesNotInAllowedRange IJsonModel<HttpC2DMessagesNotInAllowedRange>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (HttpC2DMessagesNotInAllowedRange)JsonModelCreateCore(ref reader, options);

        void IJsonModel<HttpC2DMessagesNotInAllowedRange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        HttpC2DMessagesNotInAllowedRange IPersistableModel<HttpC2DMessagesNotInAllowedRange>.Create(BinaryData data, ModelReaderWriterOptions options) => (HttpC2DMessagesNotInAllowedRange)PersistableModelCreateCore(data, options);

        string IPersistableModel<HttpC2DMessagesNotInAllowedRange>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<HttpC2DMessagesNotInAllowedRange>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    }
}

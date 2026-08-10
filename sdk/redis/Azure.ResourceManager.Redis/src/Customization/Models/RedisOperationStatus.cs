// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Redis.Models
{
    // Workaround: spec declares `model OperationStatus extends OperationStatusResult` but the
    // MPG emitter does not yet treat OperationStatusResult as a fully inheritable system type
    // (Case B in ManagementTypeFactory.CreateModelCore does not fire for it). Without this
    // customization, ApiCompat against the baseline fails:
    //   CannotRemoveBaseTypeOrInterface : 'RedisOperationStatus' does not inherit from base
    //   type 'OperationStatusResult' in the implementation but it does in the contract.
    // We re-declare the base and re-emit JsonModelWriteCore so the inherited base fields plus
    // the `properties` dictionary serialize correctly.
    // Tracked: https://github.com/Azure/azure-sdk-for-net/issues/58711 -- remove once the
    // emitter promotes OperationStatusResult to a full inheritable system type.
    public partial class RedisOperationStatus : OperationStatusResult
    {
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RedisOperationStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RedisOperationStatus)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsCollectionDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                foreach (var item in Properties)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndObject();
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }
    }
}

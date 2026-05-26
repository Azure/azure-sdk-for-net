// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // The shipped SDK exposed flat Add/Delete/Set IP community ID lists while the generated model now
    // represents them as nested add/delete/set objects. These suppressions keep the custom flattened
    // accessors and writer; removing them would reintroduce an incompatible generated add accessor and
    // the custom delete/set lists would not be serialized into the request payload.
    [CodeGenSuppress("AddIPCommunityIds")]
    [CodeGenSuppress("JsonModelWriteCore")]
    public partial class ActionIPCommunityProperties : IPCommunityAddOperationProperties
    {
        /// <summary> List of IP Community resource IDs. </summary>
        public IList<ResourceIdentifier> DeleteIPCommunityIds
        {
            get
            {
                if (Delete is null)
                {
                    Delete = new IPCommunityIdList();
                }
                return Delete.IPCommunityIds;
            }
        }

        /// <summary> List of IP Community resource IDs. </summary>
        public IList<ResourceIdentifier> SetIPCommunityIds
        {
            get
            {
                if (Set is null)
                {
                    Set = new IPCommunityIdList();
                }
                return Set.IPCommunityIds;
            }
        }

        /// <summary> Writes the model JSON payload. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ActionIPCommunityProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ActionIPCommunityProperties)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(Add))
            {
                writer.WritePropertyName("add"u8);
                writer.WriteObjectValue(Add, options);
            }
            if (Optional.IsDefined(Delete))
            {
                writer.WritePropertyName("delete"u8);
                writer.WriteObjectValue(Delete, options);
            }
            if (Optional.IsDefined(Set))
            {
                writer.WritePropertyName("set"u8);
                writer.WriteObjectValue(Set, options);
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

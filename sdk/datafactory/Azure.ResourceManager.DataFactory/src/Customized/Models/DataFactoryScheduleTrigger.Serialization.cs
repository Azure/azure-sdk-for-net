// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.DataFactory;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/58691 :
    // for this model the generator emits a Deserialize method whose additional-properties catch-all writes to
    // the undeclared `additionalBinaryDataProperties` local instead of the declared `additionalProperties`
    // (CS0103). [CodeGenSerialization] cannot target the catch-all on a derived model (the AdditionalProperties
    // bag is inherited), so the generated Deserialize is suppressed and re-emitted here with the corrected
    // local name. The body is otherwise identical to the generated output.
    // TODO: remove once the generator emits a consistent additional-properties local name (#58691).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DeserializeDataFactoryScheduleTrigger", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class DataFactoryScheduleTrigger
    {
        internal static DataFactoryScheduleTrigger DeserializeDataFactoryScheduleTrigger(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string type = "ScheduleTrigger";
            string description = default;
            DataFactoryTriggerRuntimeState? runtimeState = default;
            IList<BinaryData> annotations = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            IList<TriggerPipelineReference> pipelines = default;
            ScheduleTriggerTypeProperties typeProperties = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("runtimeState"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    runtimeState = new DataFactoryTriggerRuntimeState(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("annotations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    annotations = array;
                    continue;
                }
                if (prop.NameEquals("pipelines"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TriggerPipelineReference> array = new List<TriggerPipelineReference>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(TriggerPipelineReference.DeserializeTriggerPipelineReference(item, options));
                    }
                    pipelines = array;
                    continue;
                }
                if (prop.NameEquals("typeProperties"u8))
                {
                    typeProperties = ScheduleTriggerTypeProperties.DeserializeScheduleTriggerTypeProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DataFactoryScheduleTrigger(
                type,
                description,
                runtimeState,
                annotations ?? new ChangeTrackingList<BinaryData>(),
                additionalProperties,
                pipelines ?? new ChangeTrackingList<TriggerPipelineReference>(),
                typeProperties);
        }
    }
}
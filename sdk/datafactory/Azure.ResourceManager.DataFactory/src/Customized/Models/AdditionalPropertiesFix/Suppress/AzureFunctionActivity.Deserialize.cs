// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Expressions.DataFactory;
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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DeserializeAzureFunctionActivity", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class AzureFunctionActivity
    {
        internal static AzureFunctionActivity DeserializeAzureFunctionActivity(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string @type = "AzureFunctionActivity";
            string description = default;
            PipelineActivityState? state = default;
            ActivityOnInactiveMarkAs? onInactiveMarkAs = default;
            IList<PipelineActivityDependency> dependsOn = default;
            IList<PipelineActivityUserProperty> userProperties = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            DataFactoryLinkedServiceReference linkedServiceName = default;
            PipelineActivityPolicy policy = default;
            AzureFunctionActivityTypeProperties typeProperties = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("state"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    state = new PipelineActivityState(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("onInactiveMarkAs"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    onInactiveMarkAs = new ActivityOnInactiveMarkAs(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("dependsOn"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PipelineActivityDependency> array = new List<PipelineActivityDependency>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(PipelineActivityDependency.DeserializePipelineActivityDependency(item, options));
                    }
                    dependsOn = array;
                    continue;
                }
                if (prop.NameEquals("userProperties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PipelineActivityUserProperty> array = new List<PipelineActivityUserProperty>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(PipelineActivityUserProperty.DeserializePipelineActivityUserProperty(item, options));
                    }
                    userProperties = array;
                    continue;
                }
                if (prop.NameEquals("linkedServiceName"u8))
                {
                    ReadLinkedServiceName(prop, ref linkedServiceName);
                    continue;
                }
                if (prop.NameEquals("policy"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    policy = PipelineActivityPolicy.DeserializePipelineActivityPolicy(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("typeProperties"u8))
                {
                    typeProperties = AzureFunctionActivityTypeProperties.DeserializeAzureFunctionActivityTypeProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AzureFunctionActivity(
                name,
                @type,
                description,
                state,
                onInactiveMarkAs,
                dependsOn ?? new ChangeTrackingList<PipelineActivityDependency>(),
                userProperties ?? new ChangeTrackingList<PipelineActivityUserProperty>(),
                additionalProperties,
                linkedServiceName,
                policy,
                typeProperties);
        }
    }
}

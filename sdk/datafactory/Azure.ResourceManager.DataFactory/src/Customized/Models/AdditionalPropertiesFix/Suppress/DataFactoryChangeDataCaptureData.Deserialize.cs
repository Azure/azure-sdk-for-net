// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Models;
using Azure;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System;

namespace Azure.ResourceManager.DataFactory
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/58691 :
    // for this model the generator emits a Deserialize method whose additional-properties catch-all writes to
    // the undeclared `additionalBinaryDataProperties` local instead of the declared `additionalProperties`
    // (CS0103). [CodeGenSerialization] cannot target the catch-all on a derived model (the AdditionalProperties
    // bag is inherited), so the generated Deserialize is suppressed and re-emitted here with the corrected
    // local name. The body is otherwise identical to the generated output.
    // TODO: remove once the generator emits a consistent additional-properties local name (#58691).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DeserializeDataFactoryChangeDataCaptureData", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class DataFactoryChangeDataCaptureData
    {
        internal static DataFactoryChangeDataCaptureData DeserializeDataFactoryChangeDataCaptureData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            Models.ChangeDataCapture properties = default;
            ETag? eTag = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerDataFactoryContext.Default);
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    properties = Models.ChangeDataCapture.DeserializeChangeDataCapture(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("etag"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    eTag = new ETag(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DataFactoryChangeDataCaptureData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                eTag,
                additionalProperties);
        }
    }
}

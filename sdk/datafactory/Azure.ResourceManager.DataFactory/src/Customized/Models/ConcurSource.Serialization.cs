// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // The MPG generator emits <ExternalType>.Deserialize<ExternalType>(element, options) for properties whose
    // type is an Azure.Core.Expressions.DataFactory type (mapped via @@alternateType identity), but those static
    // Deserialize overloads do not exist (CS0117). Each property below redirects deserialization to a shared,
    // correct ModelReaderWriter-based reader via [CodeGenSerialization].
    // TODO: remove once the generator emits correct deserialization for identity-aliased types (#59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Query), DeserializationValueHook = nameof(ReadQuery))]
    public partial class ConcurSource
    {
        internal static void ReadQuery(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }

    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/58691 :
    // for this model the generator emits a Deserialize method whose additional-properties catch-all writes to
    // the undeclared `additionalBinaryDataProperties` local instead of the declared `additionalProperties`
    // (CS0103). [CodeGenSerialization] cannot target the catch-all on a derived model (the AdditionalProperties
    // bag is inherited), so the generated Deserialize is suppressed and re-emitted here with the corrected
    // local name. The body is otherwise identical to the generated output.
    // TODO: remove once the generator emits a consistent additional-properties local name (#58691).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DeserializeConcurSource", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class ConcurSource
    {
        internal static ConcurSource DeserializeConcurSource(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string type = "ConcurSource";
            DataFactoryElement<int> sourceRetryCount = default;
            DataFactoryElement<string> sourceRetryWait = default;
            DataFactoryElement<int> maxConcurrentConnections = default;
            DataFactoryElement<bool> disableMetricsCollection = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            DataFactoryElement<string> queryTimeout = default;
            BinaryData additionalColumns = default;
            DataFactoryElement<string> query = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("sourceRetryCount"u8))
                {
                    ReadSourceRetryCount(prop, ref sourceRetryCount);
                    continue;
                }
                if (prop.NameEquals("sourceRetryWait"u8))
                {
                    ReadSourceRetryWait(prop, ref sourceRetryWait);
                    continue;
                }
                if (prop.NameEquals("maxConcurrentConnections"u8))
                {
                    ReadMaxConcurrentConnections(prop, ref maxConcurrentConnections);
                    continue;
                }
                if (prop.NameEquals("disableMetricsCollection"u8))
                {
                    ReadDisableMetricsCollection(prop, ref disableMetricsCollection);
                    continue;
                }
                if (prop.NameEquals("queryTimeout"u8))
                {
                    ReadQueryTimeout(prop, ref queryTimeout);
                    continue;
                }
                if (prop.NameEquals("additionalColumns"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    additionalColumns = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("query"u8))
                {
                    ReadQuery(prop, ref query);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ConcurSource(
                type,
                sourceRetryCount,
                sourceRetryWait,
                maxConcurrentConnections,
                disableMetricsCollection,
                additionalProperties,
                queryTimeout,
                additionalColumns,
                query);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Shared deserialization helpers backing the [CodeGenSerialization] hooks that work around
    // https://github.com/Azure/azure-sdk-for-net/issues/59298 (generator emits non-existent
    // <ExternalType>.Deserialize<ExternalType>(...) for identity-aliased Azure.Core.Expressions.DataFactory types).
    // TODO: remove once the generator emits correct deserialization for these types (#59298).
    internal static class DataFactoryExpressionSerialization
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        internal static DataFactoryElement<T> ReadElement<T>(JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null
                ? null
                : ModelReaderWriter.Read<DataFactoryElement<T>>(BinaryData.FromString(property.Value.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default);

        internal static DataFactoryLinkedServiceReference ReadLinkedServiceReference(JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null
                ? null
                : ModelReaderWriter.Read<DataFactoryLinkedServiceReference>(BinaryData.FromString(property.Value.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default);

        internal static DataFactorySecret ReadSecret(JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null
                ? null
                : ModelReaderWriter.Read<DataFactorySecret>(BinaryData.FromString(property.Value.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default);

        internal static DataFactorySecretString ReadSecretString(JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null
                ? null
                : ModelReaderWriter.Read<DataFactorySecretString>(BinaryData.FromString(property.Value.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default);

        internal static System.Collections.Generic.IList<DataFactoryLinkedServiceReference> ReadLinkedServiceReferenceList(JsonProperty property)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            var list = new System.Collections.Generic.List<DataFactoryLinkedServiceReference>();
            foreach (var item in property.Value.EnumerateArray())
            {
                list.Add(item.ValueKind == JsonValueKind.Null ? null : ModelReaderWriter.Read<DataFactoryLinkedServiceReference>(BinaryData.FromString(item.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default));
            }
            return list;
        }

        internal static System.Collections.Generic.IList<DataFactoryElement<T>> ReadElementList<T>(JsonProperty property)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            var list = new System.Collections.Generic.List<DataFactoryElement<T>>();
            foreach (var item in property.Value.EnumerateArray())
            {
                list.Add(item.ValueKind == JsonValueKind.Null ? null : ModelReaderWriter.Read<DataFactoryElement<T>>(BinaryData.FromString(item.GetRawText()), WireOptions, AzureResourceManagerDataFactoryContext.Default));
            }
            return list;
        }
    }
}

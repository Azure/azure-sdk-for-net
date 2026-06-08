// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: generator emits an internal-only ctor for DatasetSchemaDataElement
// (the @@usage decorator does not transitively reach models wrapped by Dfe<T>). Restore the public
// parameterless ctor to match the pre-MPG API surface so callers can construct instances. Provides
// a nested JsonConverter so DataFactoryElement<IList<DatasetSchemaDataElement>> can serialize via Azure.Core.Expressions.DataFactory.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Expressions.DataFactory;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // generator treats this Dfe<T>-wrapped model as output-only and emits getter-only properties
    // plus a read-only additional-properties bag, but the GA contract exposed mutable members.
    // TODO: remove once the generator honors input usage through DataFactoryElement<T> wrappers (#59298).
    [JsonConverter(typeof(DatasetSchemaDataElement.DatasetSchemaDataElementConverter))]
    public partial class DatasetSchemaDataElement
    {
        /// <summary> Initializes a new instance of <see cref="DatasetSchemaDataElement"/>. </summary>
        public DatasetSchemaDataElement()
        {
            _additionalBinaryDataProperties = new global::Azure.ResourceManager.DataFactory.ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Name of the schema column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("SchemaColumnName")]
        public DataFactoryElement<string> SchemaColumnName { get; set; }

        /// <summary> Type of the schema column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("SchemaColumnType")]
        public DataFactoryElement<string> SchemaColumnType { get; set; }

        /// <summary> Gets the AdditionalProperties. </summary>
        [CodeGenMember("AdditionalProperties")]
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;

        internal sealed class DatasetSchemaDataElementConverter : JsonConverter<DatasetSchemaDataElement>
        {
            private static readonly ModelReaderWriterOptions s_options = new ModelReaderWriterOptions("W");

            public override DatasetSchemaDataElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => ((IJsonModel<DatasetSchemaDataElement>)new DatasetSchemaDataElement()).Create(ref reader, s_options);

            public override void Write(Utf8JsonWriter writer, DatasetSchemaDataElement value, JsonSerializerOptions options)
                => ((IJsonModel<DatasetSchemaDataElement>)value).Write(writer, s_options);
        }
    }
}
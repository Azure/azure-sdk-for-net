// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Expressions.DataFactory;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataFactory.Models
{
    // MPG migration back-compat: generator emits an internal-only ctor for DatasetDataElement
    // (the @@usage decorator does not transitively reach models wrapped by Dfe<T>). Restore the public
    // parameterless ctor to match the pre-MPG API surface so callers can construct instances. Provides
    // a nested JsonConverter so DataFactoryElement<IList<DatasetDataElement>> can serialize via Azure.Core.Expressions.DataFactory.
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // generator treats this Dfe<T>-wrapped model as output-only and emits getter-only properties,
    // but the GA contract exposed setters. CodeGenMember is required to replace the generated properties.
    // TODO: remove once the generator honors input usage through DataFactoryElement<T> wrappers (#59298).
    [JsonConverter(typeof(DatasetDataElement.DatasetDataElementConverter))]
    public partial class DatasetDataElement
    {
        /// <summary> Initializes a new instance of <see cref="DatasetDataElement"/>. </summary>
        public DatasetDataElement()
        {
            _additionalBinaryDataProperties = new global::Azure.ResourceManager.DataFactory.ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Name of the column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("ColumnName")]
        public DataFactoryElement<string> ColumnName { get; set; }

        /// <summary> Type of the column. Type: string (or Expression with resultType string). </summary>
        [CodeGenMember("ColumnType")]
        public DataFactoryElement<string> ColumnType { get; set; }

        internal sealed class DatasetDataElementConverter : JsonConverter<DatasetDataElement>
        {
            private static readonly ModelReaderWriterOptions s_options = new ModelReaderWriterOptions("W");

            public override DatasetDataElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => ((IJsonModel<DatasetDataElement>)new DatasetDataElement()).Create(ref reader, s_options);

            public override void Write(Utf8JsonWriter writer, DatasetDataElement value, JsonSerializerOptions options)
                => ((IJsonModel<DatasetDataElement>)value).Write(writer, s_options);
        }
    }
}

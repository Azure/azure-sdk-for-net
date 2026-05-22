// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: generator emits an internal-only ctor for DatasetDataElement
// (the @@usage decorator does not transitively reach models wrapped by Dfe<T>). Restore the public
// parameterless ctor to match the pre-MPG API surface so callers can construct instances. Provides
// a nested JsonConverter so DataFactoryElement<IList<DatasetDataElement>> can serialize via Azure.Core.Expressions.DataFactory.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.DataFactory.Models
{
    [JsonConverter(typeof(DatasetDataElement.DatasetDataElementConverter))]
    public partial class DatasetDataElement
    {
        /// <summary> Initializes a new instance of <see cref="DatasetDataElement"/>. </summary>
        public DatasetDataElement()
        {
            _additionalBinaryDataProperties = new global::Azure.ResourceManager.DataFactory.ChangeTrackingDictionary<string, BinaryData>();
        }

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
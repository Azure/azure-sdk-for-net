// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// MPG migration back-compat: generator emits an internal-only ctor for Office365TableOutputColumn
// (the @@usage decorator does not transitively reach models wrapped by Dfe<T>). Restore the public
// parameterless ctor to match the pre-MPG API surface so callers can construct instances. Provides
// a nested JsonConverter so DataFactoryElement<IList<Office365TableOutputColumn>> can serialize via Azure.Core.Expressions.DataFactory.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.DataFactory.Models
{
    [JsonConverter(typeof(Office365TableOutputColumn.Office365TableOutputColumnConverter))]
    public partial class Office365TableOutputColumn
    {
        /// <summary> Initializes a new instance of <see cref="Office365TableOutputColumn"/>. </summary>
        public Office365TableOutputColumn()
        {
        }

        internal sealed class Office365TableOutputColumnConverter : JsonConverter<Office365TableOutputColumn>
        {
            private static readonly ModelReaderWriterOptions s_options = new ModelReaderWriterOptions("W");

            public override Office365TableOutputColumn Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => ((IJsonModel<Office365TableOutputColumn>)new Office365TableOutputColumn()).Create(ref reader, s_options);

            public override void Write(Utf8JsonWriter writer, Office365TableOutputColumn value, JsonSerializerOptions options)
                => ((IJsonModel<Office365TableOutputColumn>)value).Write(writer, s_options);
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    /// <summary> Handwritten custom base resource data used by compatibility customizations. </summary>
    public partial class CustomWritableResourceData : IJsonModel<CustomWritableResourceData>, IPersistableModel<CustomWritableResourceData>
    {
        /// <summary> Initializes a new instance of <see cref="CustomWritableResourceData"/>. </summary>
        public CustomWritableResourceData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomWritableResourceData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CustomWritableResourceData(ResourceIdentifier id, string name, ResourceType? resourceType, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> Resource ID. </summary>
        [WirePath("id")]
        public ResourceIdentifier Id { get; set; }

        /// <summary> Resource name. </summary>
        [WirePath("name")]
        public string Name { get; set; }

        /// <summary> Resource type. </summary>
        [WirePath("type")]
        public ResourceType? ResourceType { get; set; }

        /// <summary> Writes the JSON representation of the model. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        /// <summary> Reads the JSON representation of the model. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CustomWritableResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Writes the model as binary data. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads the model from binary data. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CustomWritableResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<CustomWritableResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            JsonModelWriteCore(writer, options);
        }

        CustomWritableResourceData IJsonModel<CustomWritableResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return JsonModelCreateCore(ref reader, options);
        }

        BinaryData IPersistableModel<CustomWritableResourceData>.Write(ModelReaderWriterOptions options)
        {
            return PersistableModelWriteCore(options);
        }

        CustomWritableResourceData IPersistableModel<CustomWritableResourceData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return PersistableModelCreateCore(data, options);
        }

        string IPersistableModel<CustomWritableResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return "J";
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class AzureDevOpsScopeEnvironment : IPersistableModel<AzureDevOpsScopeEnvironment>
    {
        /// <summary> Initializes a new instance of <see cref="AzureDevOpsScopeEnvironment"/>. </summary>
        public AzureDevOpsScopeEnvironment() : base(EnvironmentType.AzureDevOpsScope, new ChangeTrackingDictionary<string, BinaryData>())
        {
        }

        void IJsonModel<AzureDevOpsScopeEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        AzureDevOpsScopeEnvironment IJsonModel<AzureDevOpsScopeEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (AzureDevOpsScopeEnvironment)JsonModelCreateCore(ref reader, options);
        BinaryData IPersistableModel<AzureDevOpsScopeEnvironment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        AzureDevOpsScopeEnvironment IPersistableModel<AzureDevOpsScopeEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) => (AzureDevOpsScopeEnvironment)PersistableModelCreateCore(data, options);
        string IPersistableModel<AzureDevOpsScopeEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

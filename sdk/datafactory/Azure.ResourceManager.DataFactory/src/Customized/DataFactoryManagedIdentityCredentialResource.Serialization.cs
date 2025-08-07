// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryManagedIdentityCredentialResource : IJsonModel<DataFactoryManagedIdentityCredentialData>
    {
        void IJsonModel<DataFactoryManagedIdentityCredentialData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DataFactoryManagedIdentityCredentialData>)Data).Write(writer, options);

        DataFactoryManagedIdentityCredentialData IJsonModel<DataFactoryManagedIdentityCredentialData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<DataFactoryManagedIdentityCredentialData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options, AzureResourceManagerDataFactoryContext.Default);

        DataFactoryManagedIdentityCredentialData IPersistableModel<DataFactoryManagedIdentityCredentialData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DataFactoryManagedIdentityCredentialData>(data, options, AzureResourceManagerDataFactoryContext.Default);

        string IPersistableModel<DataFactoryManagedIdentityCredentialData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<DataFactoryManagedIdentityCredentialData>)Data).GetFormatFromOptions(options);
    }
}

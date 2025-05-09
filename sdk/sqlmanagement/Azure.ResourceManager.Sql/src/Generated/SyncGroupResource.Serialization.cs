// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Sql
{
    public partial class SyncGroupResource : IJsonModel<SyncGroupData>
    {
        void IJsonModel<SyncGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SyncGroupData>)Data).Write(writer, options);

        SyncGroupData IJsonModel<SyncGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SyncGroupData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<SyncGroupData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SyncGroupData>(Data, options, AzureResourceManagerSqlContext.Default);

        SyncGroupData IPersistableModel<SyncGroupData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SyncGroupData>(data, options, AzureResourceManagerSqlContext.Default);

        string IPersistableModel<SyncGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SyncGroupData>)Data).GetFormatFromOptions(options);
    }
}

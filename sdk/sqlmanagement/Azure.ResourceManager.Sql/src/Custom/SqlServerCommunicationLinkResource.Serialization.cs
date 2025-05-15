// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerCommunicationLinkResource : IJsonModel<SqlServerCommunicationLinkData>
    {
        void IJsonModel<SqlServerCommunicationLinkData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SqlServerCommunicationLinkData>)Data).Write(writer, options);

        SqlServerCommunicationLinkData IJsonModel<SqlServerCommunicationLinkData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SqlServerCommunicationLinkData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<SqlServerCommunicationLinkData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SqlServerCommunicationLinkData>(Data, options, AzureResourceManagerSqlContext.Default);

        SqlServerCommunicationLinkData IPersistableModel<SqlServerCommunicationLinkData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SqlServerCommunicationLinkData>(data, options, AzureResourceManagerSqlContext.Default);

        string IPersistableModel<SqlServerCommunicationLinkData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SqlServerCommunicationLinkData>)Data).GetFormatFromOptions(options);
    }
}

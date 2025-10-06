// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Sql
{
    public partial class ServiceObjectiveResource : IJsonModel<ServiceObjectiveData>
    {
        void IJsonModel<ServiceObjectiveData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ServiceObjectiveData>)Data).Write(writer, options);

        ServiceObjectiveData IJsonModel<ServiceObjectiveData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ServiceObjectiveData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<ServiceObjectiveData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<ServiceObjectiveData>(Data, options, AzureResourceManagerSqlContext.Default);

        ServiceObjectiveData IPersistableModel<ServiceObjectiveData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<ServiceObjectiveData>(data, options, AzureResourceManagerSqlContext.Default);

        string IPersistableModel<ServiceObjectiveData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<ServiceObjectiveData>)Data).GetFormatFromOptions(options);
    }
}

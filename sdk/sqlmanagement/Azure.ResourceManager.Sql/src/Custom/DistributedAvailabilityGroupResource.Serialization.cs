// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    public partial class DistributedAvailabilityGroupResource : IJsonModel<DistributedAvailabilityGroupData>
    {
        void IJsonModel<DistributedAvailabilityGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DistributedAvailabilityGroupData>)Data).Write(writer, options);

        DistributedAvailabilityGroupData IJsonModel<DistributedAvailabilityGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<DistributedAvailabilityGroupData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<DistributedAvailabilityGroupData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DistributedAvailabilityGroupData>(Data, options, AzureResourceManagerSqlContext.Default);

        DistributedAvailabilityGroupData IPersistableModel<DistributedAvailabilityGroupData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DistributedAvailabilityGroupData>(data, options, AzureResourceManagerSqlContext.Default);

        string IPersistableModel<DistributedAvailabilityGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<DistributedAvailabilityGroupData>)Data).GetFormatFromOptions(options);
    }
}

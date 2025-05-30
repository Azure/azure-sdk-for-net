// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.AppService
{
    public partial class WorkflowTriggerHistoryResource : IJsonModel<WorkflowTriggerHistoryData>
    {
        private static WorkflowTriggerHistoryData s_dataDeserializationInstance;
        private static WorkflowTriggerHistoryData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<WorkflowTriggerHistoryData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<WorkflowTriggerHistoryData>)Data).Write(writer, options);

        WorkflowTriggerHistoryData IJsonModel<WorkflowTriggerHistoryData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<WorkflowTriggerHistoryData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<WorkflowTriggerHistoryData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<WorkflowTriggerHistoryData>(Data, options, AzureResourceManagerAppServiceContext.Default);

        WorkflowTriggerHistoryData IPersistableModel<WorkflowTriggerHistoryData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<WorkflowTriggerHistoryData>(data, options, AzureResourceManagerAppServiceContext.Default);

        string IPersistableModel<WorkflowTriggerHistoryData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<WorkflowTriggerHistoryData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}

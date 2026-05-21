// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA SDK exposed this renamed task resource and its serialization interfaces.
    [CodeGenType("TaskResource")]
    public partial class DataMigrationServiceTaskResource : IJsonModel<DataMigrationProjectTaskData>, IPersistableModel<DataMigrationProjectTaskData>
    {
        private static IJsonModel<DataMigrationProjectTaskData> s_dataDeserializationInstance;

        private static IJsonModel<DataMigrationProjectTaskData> DataDeserializationInstance => s_dataDeserializationInstance ??= new DataMigrationProjectTaskData();

        void IJsonModel<DataMigrationProjectTaskData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<DataMigrationProjectTaskData>)Data).Write(writer, options);

        DataMigrationProjectTaskData IJsonModel<DataMigrationProjectTaskData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => DataDeserializationInstance.Create(ref reader, options);

        BinaryData IPersistableModel<DataMigrationProjectTaskData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<DataMigrationProjectTaskData>(Data, options, AzureResourceManagerDataMigrationContext.Default);

        DataMigrationProjectTaskData IPersistableModel<DataMigrationProjectTaskData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<DataMigrationProjectTaskData>(data, options, AzureResourceManagerDataMigrationContext.Default);

        string IPersistableModel<DataMigrationProjectTaskData>.GetFormatFromOptions(ModelReaderWriterOptions options) => DataDeserializationInstance.GetFormatFromOptions(options);
    }
}

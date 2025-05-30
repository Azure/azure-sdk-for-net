// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearningCompute
{
    public partial class OperationalizationClusterResource : IJsonModel<OperationalizationClusterData>
    {
        private static OperationalizationClusterData s_dataDeserializationInstance;
        private static OperationalizationClusterData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<OperationalizationClusterData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<OperationalizationClusterData>)Data).Write(writer, options);

        OperationalizationClusterData IJsonModel<OperationalizationClusterData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<OperationalizationClusterData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<OperationalizationClusterData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<OperationalizationClusterData>(Data, options, AzureResourceManagerMachineLearningComputeContext.Default);

        OperationalizationClusterData IPersistableModel<OperationalizationClusterData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<OperationalizationClusterData>(data, options, AzureResourceManagerMachineLearningComputeContext.Default);

        string IPersistableModel<OperationalizationClusterData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<OperationalizationClusterData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}

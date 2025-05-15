// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosTargetTypeResource : IJsonModel<ChaosTargetTypeData>
    {
        void IJsonModel<ChaosTargetTypeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ChaosTargetTypeData>)Data).Write(writer, options);

        ChaosTargetTypeData IJsonModel<ChaosTargetTypeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ChaosTargetTypeData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<ChaosTargetTypeData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<ChaosTargetTypeData>(Data, options, AzureResourceManagerChaosContext.Default);

        ChaosTargetTypeData IPersistableModel<ChaosTargetTypeData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<ChaosTargetTypeData>(data, options, AzureResourceManagerChaosContext.Default);

        string IPersistableModel<ChaosTargetTypeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<ChaosTargetTypeData>)Data).GetFormatFromOptions(options);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosCapabilityTypeResource : IJsonModel<ChaosCapabilityTypeData>
    {
        void IJsonModel<ChaosCapabilityTypeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<ChaosCapabilityTypeData>)Data).Write(writer, options);

        ChaosCapabilityTypeData IJsonModel<ChaosCapabilityTypeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<ChaosCapabilityTypeData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<ChaosCapabilityTypeData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<ChaosCapabilityTypeData>(Data, options, AzureResourceManagerChaosContext.Default);

        ChaosCapabilityTypeData IPersistableModel<ChaosCapabilityTypeData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<ChaosCapabilityTypeData>(data, options, AzureResourceManagerChaosContext.Default);

        string IPersistableModel<ChaosCapabilityTypeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<ChaosCapabilityTypeData>)Data).GetFormatFromOptions(options);
    }
}

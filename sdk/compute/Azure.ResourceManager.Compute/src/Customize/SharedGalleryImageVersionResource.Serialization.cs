// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Compute
{
    public partial class SharedGalleryImageVersionResource : IJsonModel<SharedGalleryImageVersionData>
    {
        private static SharedGalleryImageVersionData s_dataDeserializationInstance;
        private static SharedGalleryImageVersionData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<SharedGalleryImageVersionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SharedGalleryImageVersionData>)Data).Write(writer, options);

        SharedGalleryImageVersionData IJsonModel<SharedGalleryImageVersionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SharedGalleryImageVersionData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<SharedGalleryImageVersionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SharedGalleryImageVersionData>(Data, options, AzureResourceManagerComputeContext.Default);

        SharedGalleryImageVersionData IPersistableModel<SharedGalleryImageVersionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SharedGalleryImageVersionData>(data, options, AzureResourceManagerComputeContext.Default);

        string IPersistableModel<SharedGalleryImageVersionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SharedGalleryImageVersionData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}

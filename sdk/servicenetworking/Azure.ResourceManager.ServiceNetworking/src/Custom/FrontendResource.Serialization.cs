// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ServiceNetworking
{
    public partial class FrontendResource : IJsonModel<FrontendData>
    {
        void IJsonModel<FrontendData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FrontendData>)Data).Write(writer, options);

        FrontendData IJsonModel<FrontendData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<FrontendData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<FrontendData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options, AzureResourceManagerServiceNetworkingContext.Default);

        FrontendData IPersistableModel<FrontendData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<FrontendData>(data, options, AzureResourceManagerServiceNetworkingContext.Default);

        string IPersistableModel<FrontendData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<FrontendData>)Data).GetFormatFromOptions(options);
    }
}

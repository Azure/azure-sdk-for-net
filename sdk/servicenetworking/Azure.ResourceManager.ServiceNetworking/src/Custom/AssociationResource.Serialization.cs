// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ServiceNetworking
{
    public partial class AssociationResource : IJsonModel<AssociationData>
    {
        void IJsonModel<AssociationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<AssociationData>)Data).Write(writer, options);

        AssociationData IJsonModel<AssociationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<AssociationData>)Data).Create(ref reader, options);

        BinaryData IPersistableModel<AssociationData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(Data, options, AzureResourceManagerServiceNetworkingContext.Default);

        AssociationData IPersistableModel<AssociationData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<AssociationData>(data, options, AzureResourceManagerServiceNetworkingContext.Default);

        string IPersistableModel<AssociationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<AssociationData>)Data).GetFormatFromOptions(options);
    }
}

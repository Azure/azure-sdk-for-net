// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

// NOTE: The following customization is intentionally retained for backward compatibility.
// There is a spec breaking change which defines a new resource model ProjectCapabilityHost with the similar properties as CapabilityHost for the existing resource operations.
// To avoid breaking existing customers, we are using customization code to reuse the existing data model CognitiveServicesCapabilityHostData for both resources.
// This customization will be removed if service team can align on a single resource model for both resource as before, otherwise it will remain for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class CognitiveServicesProjectCapabilityHostResource : IJsonModel<CognitiveServicesCapabilityHostData>
    {
        private static CognitiveServicesCapabilityHostData s_dataDeserializationInstance;
        private static CognitiveServicesCapabilityHostData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<CognitiveServicesCapabilityHostData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<CognitiveServicesCapabilityHostData>)Data).Write(writer, options);

        CognitiveServicesCapabilityHostData IJsonModel<CognitiveServicesCapabilityHostData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<CognitiveServicesCapabilityHostData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<CognitiveServicesCapabilityHostData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<CognitiveServicesCapabilityHostData>(Data, options, AzureResourceManagerCognitiveServicesContext.Default);

        CognitiveServicesCapabilityHostData IPersistableModel<CognitiveServicesCapabilityHostData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<CognitiveServicesCapabilityHostData>(data, options, AzureResourceManagerCognitiveServicesContext.Default);

        string IPersistableModel<CognitiveServicesCapabilityHostData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<CognitiveServicesCapabilityHostData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}

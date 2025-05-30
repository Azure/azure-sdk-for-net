// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecuritySubAssessmentResource : IJsonModel<SecuritySubAssessmentData>
    {
        private static SecuritySubAssessmentData s_dataDeserializationInstance;
        private static SecuritySubAssessmentData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<SecuritySubAssessmentData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SecuritySubAssessmentData>)Data).Write(writer, options);

        SecuritySubAssessmentData IJsonModel<SecuritySubAssessmentData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SecuritySubAssessmentData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<SecuritySubAssessmentData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SecuritySubAssessmentData>(Data, options, AzureResourceManagerSecurityCenterContext.Default);

        SecuritySubAssessmentData IPersistableModel<SecuritySubAssessmentData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SecuritySubAssessmentData>(data, options, AzureResourceManagerSecurityCenterContext.Default);

        string IPersistableModel<SecuritySubAssessmentData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SecuritySubAssessmentData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable SA1402 // File may only contain a single type

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    // Serialization interfaces preserved for API compatibility on obsolete type.
    public partial class KubernetesFluxConfigurationData : IJsonModel<KubernetesFluxConfigurationData>, IPersistableModel<KubernetesFluxConfigurationData>
    {
        /// <inheritdoc />
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesFluxConfigurationData IJsonModel<KubernetesFluxConfigurationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        void IJsonModel<KubernetesFluxConfigurationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesFluxConfigurationData IPersistableModel<KubernetesFluxConfigurationData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        string IPersistableModel<KubernetesFluxConfigurationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<KubernetesFluxConfigurationData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");
    }

    // Serialization interfaces preserved for API compatibility on obsolete type.
    public partial class KubernetesFluxConfigurationResource : IJsonModel<KubernetesFluxConfigurationData>, IPersistableModel<KubernetesFluxConfigurationData>
    {
        KubernetesFluxConfigurationData IJsonModel<KubernetesFluxConfigurationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        void IJsonModel<KubernetesFluxConfigurationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesFluxConfigurationData IPersistableModel<KubernetesFluxConfigurationData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        string IPersistableModel<KubernetesFluxConfigurationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<KubernetesFluxConfigurationData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");
    }

    // Serialization interfaces preserved for API compatibility on obsolete type.
    public partial class KubernetesSourceControlConfigurationData : IJsonModel<KubernetesSourceControlConfigurationData>, IPersistableModel<KubernetesSourceControlConfigurationData>
    {
        /// <inheritdoc />
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesSourceControlConfigurationData IJsonModel<KubernetesSourceControlConfigurationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        void IJsonModel<KubernetesSourceControlConfigurationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesSourceControlConfigurationData IPersistableModel<KubernetesSourceControlConfigurationData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        string IPersistableModel<KubernetesSourceControlConfigurationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<KubernetesSourceControlConfigurationData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");
    }

    // Serialization interfaces preserved for API compatibility on obsolete type.
    public partial class KubernetesSourceControlConfigurationResource : IJsonModel<KubernetesSourceControlConfigurationData>, IPersistableModel<KubernetesSourceControlConfigurationData>
    {
        KubernetesSourceControlConfigurationData IJsonModel<KubernetesSourceControlConfigurationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        void IJsonModel<KubernetesSourceControlConfigurationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        KubernetesSourceControlConfigurationData IPersistableModel<KubernetesSourceControlConfigurationData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        string IPersistableModel<KubernetesSourceControlConfigurationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<KubernetesSourceControlConfigurationData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This type is obsolete.");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceUploadDefinition : IJsonModel<SourceUploadDefinition>, IPersistableModel<SourceUploadDefinition>
    {
        SourceUploadDefinition IJsonModel<SourceUploadDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceUploadDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceUploadDefinition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceUploadDefinition IPersistableModel<SourceUploadDefinition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceUploadDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        internal SourceUploadDefinition() { }
        [WirePath("uploadUrl")]
        public System.Uri UploadUri { get { throw new NotSupportedException(); } }
        [WirePath("relativePath")]
        public string RelativePath { get { throw new NotSupportedException(); } }
    }
}

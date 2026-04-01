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
    public partial class ContainerRegistryRunGetLogResult : IJsonModel<ContainerRegistryRunGetLogResult>, IPersistableModel<ContainerRegistryRunGetLogResult>
    {
        ContainerRegistryRunGetLogResult IJsonModel<ContainerRegistryRunGetLogResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunGetLogResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunGetLogResult>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunGetLogResult IPersistableModel<ContainerRegistryRunGetLogResult>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunGetLogResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        internal ContainerRegistryRunGetLogResult() { }
        [WirePath("logLink")]
        public string LogLink { get { throw new NotSupportedException(); } }
        [WirePath("logArtifactLink")]
        public string LogArtifactLink { get { throw new NotSupportedException(); } }
    }
}

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
    public partial class ContainerRegistryImageDescriptor : IJsonModel<ContainerRegistryImageDescriptor>, IPersistableModel<ContainerRegistryImageDescriptor>
    {
        ContainerRegistryImageDescriptor IJsonModel<ContainerRegistryImageDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryImageDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryImageDescriptor>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryImageDescriptor IPersistableModel<ContainerRegistryImageDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryImageDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("registry")]
        public string Registry { get { throw new NotSupportedException(); } set { } }
        [WirePath("repository")]
        public string Repository { get { throw new NotSupportedException(); } set { } }
        [WirePath("tag")]
        public string Tag { get { throw new NotSupportedException(); } set { } }
        [WirePath("digest")]
        public string Digest { get { throw new NotSupportedException(); } set { } }
    }
}

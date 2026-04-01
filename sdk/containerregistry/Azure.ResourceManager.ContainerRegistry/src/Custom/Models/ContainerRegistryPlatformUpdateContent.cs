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
    public partial class ContainerRegistryPlatformUpdateContent : IJsonModel<ContainerRegistryPlatformUpdateContent>, IPersistableModel<ContainerRegistryPlatformUpdateContent>
    {
        ContainerRegistryPlatformUpdateContent IJsonModel<ContainerRegistryPlatformUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryPlatformUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryPlatformUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryPlatformUpdateContent IPersistableModel<ContainerRegistryPlatformUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("os")]
        public ContainerRegistryOS? OS { get { throw new NotSupportedException(); } set { } }
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw new NotSupportedException(); } set { } }
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw new NotSupportedException(); } set { } }
    }
}

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
    // Backward compatibility: Trigger-related model types (BaseImageDependency, BaseImageTrigger,
    // SourceTrigger, TimerTrigger, TriggerProperties, TriggerUpdateContent, and related enums) have been
    // moved to Azure.ResourceManager.ContainerRegistryTasks. These deprecated stubs preserve the old API
    // surface with [Obsolete] attributes and NotSupportedException implementations so existing code compiles
    // but directs users to the new package.

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageDependency : IJsonModel<ContainerRegistryBaseImageDependency>, IPersistableModel<ContainerRegistryBaseImageDependency>
    {
        ContainerRegistryBaseImageDependency IJsonModel<ContainerRegistryBaseImageDependency>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryBaseImageDependency>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageDependency>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryBaseImageDependency IPersistableModel<ContainerRegistryBaseImageDependency>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryBaseImageDependency>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        internal ContainerRegistryBaseImageDependency() { }
        [WirePath("type")]
        public ContainerRegistryBaseImageDependencyType? DependencyType { get { throw new NotSupportedException(); } }
        [WirePath("digest")]
        public string Digest { get { throw new NotSupportedException(); } }
        [WirePath("registry")]
        public string Registry { get { throw new NotSupportedException(); } }
        [WirePath("repository")]
        public string Repository { get { throw new NotSupportedException(); } }
        [WirePath("tag")]
        public string Tag { get { throw new NotSupportedException(); } }
    }
}

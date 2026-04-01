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
    [PersistableModelProxy(typeof(UnknownRunRequest))]
    public abstract partial class ContainerRegistryRunContent : IJsonModel<ContainerRegistryRunContent>, IPersistableModel<ContainerRegistryRunContent>
    {
        ContainerRegistryRunContent IJsonModel<ContainerRegistryRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunContent IPersistableModel<ContainerRegistryRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected ContainerRegistryRunContent() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw new NotSupportedException(); } set { } }
        [WirePath("agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException(); } set { } }
        [WirePath("logTemplate")]
        public string LogTemplate { get { throw new NotSupportedException(); } set { } }
    }
}

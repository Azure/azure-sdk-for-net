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
    public partial class ContainerRegistryTaskRunPatch : IJsonModel<ContainerRegistryTaskRunPatch>, IPersistableModel<ContainerRegistryTaskRunPatch>
    {
        ContainerRegistryTaskRunPatch IJsonModel<ContainerRegistryTaskRunPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskRunPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunPatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskRunPatch IPersistableModel<ContainerRegistryTaskRunPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskRunPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotSupportedException(); } set { } }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw new NotSupportedException(); } }
        [WirePath("location")]
        public AzureLocation? Location { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.forceUpdateTag")]
        public string ForceUpdateTag { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.runRequest")]
        public ContainerRegistryRunContent RunRequest { get { throw new NotSupportedException(); } set { } }
    }
}

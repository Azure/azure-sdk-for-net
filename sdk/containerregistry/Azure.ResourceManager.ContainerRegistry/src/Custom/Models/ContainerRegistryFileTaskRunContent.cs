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
    public partial class ContainerRegistryFileTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryFileTaskRunContent>, IPersistableModel<ContainerRegistryFileTaskRunContent>
    {
        ContainerRegistryFileTaskRunContent IJsonModel<ContainerRegistryFileTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryFileTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskRunContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryFileTaskRunContent IPersistableModel<ContainerRegistryFileTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryFileTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryFileTaskRunContent(string taskFilePath, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException(); } set { } }
        [WirePath("agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException(); } set { } }
        [WirePath("timeout")]
        public int? TimeoutInSeconds { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceLocation")]
        public string SourceLocation { get { throw new NotSupportedException(); } set { } }
        [WirePath("credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }
}

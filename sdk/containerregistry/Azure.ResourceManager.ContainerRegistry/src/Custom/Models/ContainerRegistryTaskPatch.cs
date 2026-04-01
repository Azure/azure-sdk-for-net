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
    public partial class ContainerRegistryTaskPatch : IJsonModel<ContainerRegistryTaskPatch>, IPersistableModel<ContainerRegistryTaskPatch>
    {
        ContainerRegistryTaskPatch IJsonModel<ContainerRegistryTaskPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskPatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskPatch IPersistableModel<ContainerRegistryTaskPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw new NotSupportedException(); } set { } }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw new NotSupportedException(); } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformUpdateContent Platform { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.timeout")]
        public int? TimeoutInSeconds { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.step")]
        public ContainerRegistryTaskStepUpdateContent Step { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.trigger")]
        public ContainerRegistryTriggerUpdateContent Trigger { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.logTemplate")]
        public string LogTemplate { get { throw new NotSupportedException(); } set { } }
        [WirePath("properties.status")]
        public ContainerRegistryTaskStatus? Status { get { throw new NotSupportedException(); } set { } }
    }
}

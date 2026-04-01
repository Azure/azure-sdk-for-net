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
    public partial class ContainerRegistrySourceTriggerDescriptor : IJsonModel<ContainerRegistrySourceTriggerDescriptor>, IPersistableModel<ContainerRegistrySourceTriggerDescriptor>
    {
        ContainerRegistrySourceTriggerDescriptor IJsonModel<ContainerRegistrySourceTriggerDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistrySourceTriggerDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistrySourceTriggerDescriptor IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("id")]
        public System.Guid? Id { get { throw new NotSupportedException(); } set { } }
        [WirePath("eventType")]
        public string EventType { get { throw new NotSupportedException(); } set { } }
        [WirePath("commitId")]
        public string CommitId { get { throw new NotSupportedException(); } set { } }
        [WirePath("pullRequestId")]
        public string PullRequestId { get { throw new NotSupportedException(); } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw new NotSupportedException(); } set { } }
        [WirePath("branchName")]
        public string BranchName { get { throw new NotSupportedException(); } set { } }
        [WirePath("providerType")]
        public string ProviderType { get { throw new NotSupportedException(); } set { } }
    }
}

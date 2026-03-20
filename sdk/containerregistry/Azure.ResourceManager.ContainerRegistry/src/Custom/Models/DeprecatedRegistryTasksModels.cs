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
    // Unknown proxy types for PersistableModelProxy on abstract base classes
    [Obsolete("Moved to Azure.ResourceManager.ContainerRegistryTasks")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownRunRequest : ContainerRegistryRunContent { }
    [Obsolete("Moved to Azure.ResourceManager.ContainerRegistryTasks")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownTaskStepProperties : ContainerRegistryTaskStepProperties { }
    [Obsolete("Moved to Azure.ResourceManager.ContainerRegistryTasks")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownTaskStepUpdateParameters : ContainerRegistryTaskStepUpdateContent { }
}

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolPatch : IJsonModel<ContainerRegistryAgentPoolPatch>, IPersistableModel<ContainerRegistryAgentPoolPatch>
    {
        ContainerRegistryAgentPoolPatch IJsonModel<ContainerRegistryAgentPoolPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryAgentPoolPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolPatch>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryAgentPoolPatch IPersistableModel<ContainerRegistryAgentPoolPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryAgentPoolPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw null; } }
        [WirePath("properties.count")]
        public int? Count { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolQueueStatus : IJsonModel<ContainerRegistryAgentPoolQueueStatus>, IPersistableModel<ContainerRegistryAgentPoolQueueStatus>
    {
        ContainerRegistryAgentPoolQueueStatus IJsonModel<ContainerRegistryAgentPoolQueueStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryAgentPoolQueueStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryAgentPoolQueueStatus IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("count")]
        public int? Count { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageDependency : IJsonModel<ContainerRegistryBaseImageDependency>, IPersistableModel<ContainerRegistryBaseImageDependency>
    {
        ContainerRegistryBaseImageDependency IJsonModel<ContainerRegistryBaseImageDependency>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryBaseImageDependency>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageDependency>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryBaseImageDependency IPersistableModel<ContainerRegistryBaseImageDependency>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryBaseImageDependency>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("type")]
        public ContainerRegistryBaseImageDependencyType? DependencyType { get { throw null; } }
        [WirePath("digest")]
        public string Digest { get { throw null; } }
        [WirePath("registry")]
        public string Registry { get { throw null; } }
        [WirePath("repository")]
        public string Repository { get { throw null; } }
        [WirePath("tag")]
        public string Tag { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageTrigger : IJsonModel<ContainerRegistryBaseImageTrigger>, IPersistableModel<ContainerRegistryBaseImageTrigger>
    {
        ContainerRegistryBaseImageTrigger IJsonModel<ContainerRegistryBaseImageTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryBaseImageTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageTrigger>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryBaseImageTrigger IPersistableModel<ContainerRegistryBaseImageTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryBaseImageTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryBaseImageTrigger(ContainerRegistryBaseImageTriggerType baseImageTriggerType, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageTriggerType")]
        public ContainerRegistryBaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        [WirePath("name")]
        public string Name { get { throw null; } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        [WirePath("updateTriggerEndpoint")]
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        [WirePath("updateTriggerPayloadType")]
        public ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageTriggerUpdateContent : IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>, IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>
    {
        ContainerRegistryBaseImageTriggerUpdateContent IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryBaseImageTriggerUpdateContent IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryBaseImageTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageTriggerType")]
        public ContainerRegistryBaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        [WirePath("name")]
        public string Name { get { throw null; } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        [WirePath("updateTriggerEndpoint")]
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        [WirePath("updateTriggerPayloadType")]
        public ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryCredentials : IJsonModel<ContainerRegistryCredentials>, IPersistableModel<ContainerRegistryCredentials>
    {
        ContainerRegistryCredentials IJsonModel<ContainerRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryCredentials IPersistableModel<ContainerRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRegistry")]
        public SourceRegistryCredentials SourceRegistry { get { throw null; } set { } }
        [WirePath("sourceRegistry.loginMode")]
        public SourceRegistryLoginMode? SourceRegistryLoginMode { get { throw null; } set { } }
        [WirePath("customRegistries")]
        public IDictionary<string, CustomRegistryCredentials> CustomRegistries { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryDockerBuildContent>, IPersistableModel<ContainerRegistryDockerBuildContent>
    {
        ContainerRegistryDockerBuildContent IJsonModel<ContainerRegistryDockerBuildContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryDockerBuildContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryDockerBuildContent IPersistableModel<ContainerRegistryDockerBuildContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryDockerBuildContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryDockerBuildContent(string dockerFilePath, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw null; } set { } }
        [WirePath("platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw null; } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw null; } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw null; } set { } }
        [WirePath("agentConfiguration.cpu")]
        public int? AgentCpu { get { throw null; } set { } }
        [WirePath("timeout")]
        public int? TimeoutInSeconds { get { throw null; } set { } }
        [WirePath("sourceLocation")]
        public string SourceLocation { get { throw null; } set { } }
        [WirePath("target")]
        public string Target { get { throw null; } set { } }
        [WirePath("credentials")]
        public ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryDockerBuildStep>, IPersistableModel<ContainerRegistryDockerBuildStep>
    {
        ContainerRegistryDockerBuildStep IJsonModel<ContainerRegistryDockerBuildStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryDockerBuildStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildStep>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryDockerBuildStep IPersistableModel<ContainerRegistryDockerBuildStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryDockerBuildStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw null; } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw null; } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw null; } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw null; } set { } }
        [WirePath("target")]
        public string Target { get { throw null; } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>, IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>
    {
        ContainerRegistryDockerBuildStepUpdateContent IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryDockerBuildStepUpdateContent IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw null; } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw null; } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw null; } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw null; } set { } }
        [WirePath("target")]
        public string Target { get { throw null; } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryEncodedTaskRunContent>, IPersistableModel<ContainerRegistryEncodedTaskRunContent>
    {
        ContainerRegistryEncodedTaskRunContent IJsonModel<ContainerRegistryEncodedTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryEncodedTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskRunContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryEncodedTaskRunContent IPersistableModel<ContainerRegistryEncodedTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryEncodedTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryEncodedTaskRunContent(string encodedTaskContent, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw null; } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw null; } set { } }
        [WirePath("platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        [WirePath("agentConfiguration.cpu")]
        public int? AgentCpu { get { throw null; } set { } }
        [WirePath("timeout")]
        public int? TimeoutInSeconds { get { throw null; } set { } }
        [WirePath("sourceLocation")]
        public string SourceLocation { get { throw null; } set { } }
        [WirePath("credentials")]
        public ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryEncodedTaskStep>, IPersistableModel<ContainerRegistryEncodedTaskStep>
    {
        ContainerRegistryEncodedTaskStep IJsonModel<ContainerRegistryEncodedTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryEncodedTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStep>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryEncodedTaskStep IPersistableModel<ContainerRegistryEncodedTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw null; } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>, IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>
    {
        ContainerRegistryEncodedTaskStepUpdateContent IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryEncodedTaskStepUpdateContent IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw null; } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryFileTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryFileTaskRunContent>, IPersistableModel<ContainerRegistryFileTaskRunContent>
    {
        ContainerRegistryFileTaskRunContent IJsonModel<ContainerRegistryFileTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryFileTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskRunContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryFileTaskRunContent IPersistableModel<ContainerRegistryFileTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryFileTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryFileTaskRunContent(string taskFilePath, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw null; } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw null; } set { } }
        [WirePath("platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        [WirePath("agentConfiguration.cpu")]
        public int? AgentCpu { get { throw null; } set { } }
        [WirePath("timeout")]
        public int? TimeoutInSeconds { get { throw null; } set { } }
        [WirePath("sourceLocation")]
        public string SourceLocation { get { throw null; } set { } }
        [WirePath("credentials")]
        public ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryFileTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryFileTaskStep>, IPersistableModel<ContainerRegistryFileTaskStep>
    {
        ContainerRegistryFileTaskStep IJsonModel<ContainerRegistryFileTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryFileTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskStep>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryFileTaskStep IPersistableModel<ContainerRegistryFileTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryFileTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryFileTaskStep(string taskFilePath) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw null; } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryFileTaskStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryFileTaskStepUpdateContent>, IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>
    {
        ContainerRegistryFileTaskStepUpdateContent IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryFileTaskStepUpdateContent IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw null; } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw null; } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryImageDescriptor : IJsonModel<ContainerRegistryImageDescriptor>, IPersistableModel<ContainerRegistryImageDescriptor>
    {
        ContainerRegistryImageDescriptor IJsonModel<ContainerRegistryImageDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryImageDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryImageDescriptor>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryImageDescriptor IPersistableModel<ContainerRegistryImageDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryImageDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("registry")]
        public string Registry { get { throw null; } set { } }
        [WirePath("repository")]
        public string Repository { get { throw null; } set { } }
        [WirePath("tag")]
        public string Tag { get { throw null; } set { } }
        [WirePath("digest")]
        public string Digest { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryImageUpdateTrigger : IJsonModel<ContainerRegistryImageUpdateTrigger>, IPersistableModel<ContainerRegistryImageUpdateTrigger>
    {
        ContainerRegistryImageUpdateTrigger IJsonModel<ContainerRegistryImageUpdateTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryImageUpdateTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryImageUpdateTrigger>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryImageUpdateTrigger IPersistableModel<ContainerRegistryImageUpdateTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryImageUpdateTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("id")]
        public System.Guid? Id { get { throw null; } set { } }
        [WirePath("timestamp")]
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        [WirePath("images")]
        public IList<ContainerRegistryImageDescriptor> Images { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryOverrideTaskStepProperties : IJsonModel<ContainerRegistryOverrideTaskStepProperties>, IPersistableModel<ContainerRegistryOverrideTaskStepProperties>
    {
        ContainerRegistryOverrideTaskStepProperties IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryOverrideTaskStepProperties IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("contextPath")]
        public string ContextPath { get { throw null; } set { } }
        [WirePath("file")]
        public string File { get { throw null; } set { } }
        [WirePath("target")]
        public string Target { get { throw null; } set { } }
        [WirePath("updateTriggerToken")]
        public string UpdateTriggerToken { get { throw null; } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw null; } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryPlatformProperties : IJsonModel<ContainerRegistryPlatformProperties>, IPersistableModel<ContainerRegistryPlatformProperties>
    {
        ContainerRegistryPlatformProperties IJsonModel<ContainerRegistryPlatformProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryPlatformProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryPlatformProperties>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryPlatformProperties IPersistableModel<ContainerRegistryPlatformProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryPlatformProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryPlatformProperties(ContainerRegistryOS os) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("os")]
        public ContainerRegistryOS OS { get { throw null; } set { } }
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryPlatformUpdateContent : IJsonModel<ContainerRegistryPlatformUpdateContent>, IPersistableModel<ContainerRegistryPlatformUpdateContent>
    {
        ContainerRegistryPlatformUpdateContent IJsonModel<ContainerRegistryPlatformUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryPlatformUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryPlatformUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryPlatformUpdateContent IPersistableModel<ContainerRegistryPlatformUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("os")]
        public ContainerRegistryOS? OS { get { throw null; } set { } }
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunArgument : IJsonModel<ContainerRegistryRunArgument>, IPersistableModel<ContainerRegistryRunArgument>
    {
        ContainerRegistryRunArgument IJsonModel<ContainerRegistryRunArgument>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryRunArgument>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunArgument>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryRunArgument IPersistableModel<ContainerRegistryRunArgument>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryRunArgument>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryRunArgument(string name, string value) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("name")]
        public string Name { get { throw null; } set { } }
        [WirePath("value")]
        public string Value { get { throw null; } set { } }
        [WirePath("isSecret")]
        public bool? IsSecret { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunGetLogResult : IJsonModel<ContainerRegistryRunGetLogResult>, IPersistableModel<ContainerRegistryRunGetLogResult>
    {
        ContainerRegistryRunGetLogResult IJsonModel<ContainerRegistryRunGetLogResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryRunGetLogResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunGetLogResult>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryRunGetLogResult IPersistableModel<ContainerRegistryRunGetLogResult>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryRunGetLogResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("logLink")]
        public string LogLink { get { throw null; } }
        [WirePath("logArtifactLink")]
        public string LogArtifactLink { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunPatch : IJsonModel<ContainerRegistryRunPatch>, IPersistableModel<ContainerRegistryRunPatch>
    {
        ContainerRegistryRunPatch IJsonModel<ContainerRegistryRunPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryRunPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunPatch>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryRunPatch IPersistableModel<ContainerRegistryRunPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryRunPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySecretObject : IJsonModel<ContainerRegistrySecretObject>, IPersistableModel<ContainerRegistrySecretObject>
    {
        ContainerRegistrySecretObject IJsonModel<ContainerRegistrySecretObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistrySecretObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySecretObject>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistrySecretObject IPersistableModel<ContainerRegistrySecretObject>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistrySecretObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("value")]
        public string Value { get { throw null; } set { } }
        [WirePath("type")]
        public ContainerRegistrySecretObjectType? ObjectType { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySourceTrigger : IJsonModel<ContainerRegistrySourceTrigger>, IPersistableModel<ContainerRegistrySourceTrigger>
    {
        ContainerRegistrySourceTrigger IJsonModel<ContainerRegistrySourceTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistrySourceTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTrigger>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistrySourceTrigger IPersistableModel<ContainerRegistrySourceTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistrySourceTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistrySourceTrigger(SourceCodeRepoProperties sourceRepository, System.Collections.Generic.IEnumerable<ContainerRegistrySourceTriggerEvent> sourceTriggerEvents, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRepository")]
        public SourceCodeRepoProperties SourceRepository { get { throw null; } set { } }
        [WirePath("sourceTriggerEvents")]
        public IList<ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        [WirePath("name")]
        public string Name { get { throw null; } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySourceTriggerDescriptor : IJsonModel<ContainerRegistrySourceTriggerDescriptor>, IPersistableModel<ContainerRegistrySourceTriggerDescriptor>
    {
        ContainerRegistrySourceTriggerDescriptor IJsonModel<ContainerRegistrySourceTriggerDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistrySourceTriggerDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistrySourceTriggerDescriptor IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistrySourceTriggerDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("id")]
        public System.Guid? Id { get { throw null; } set { } }
        [WirePath("eventType")]
        public string EventType { get { throw null; } set { } }
        [WirePath("commitId")]
        public string CommitId { get { throw null; } set { } }
        [WirePath("pullRequestId")]
        public string PullRequestId { get { throw null; } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw null; } set { } }
        [WirePath("branchName")]
        public string BranchName { get { throw null; } set { } }
        [WirePath("providerType")]
        public string ProviderType { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySourceTriggerUpdateContent : IJsonModel<ContainerRegistrySourceTriggerUpdateContent>, IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>
    {
        ContainerRegistrySourceTriggerUpdateContent IJsonModel<ContainerRegistrySourceTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistrySourceTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistrySourceTriggerUpdateContent IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistrySourceTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRepository")]
        public SourceCodeRepoUpdateContent SourceRepository { get { throw null; } set { } }
        [WirePath("sourceTriggerEvents")]
        public IList<ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        [WirePath("name")]
        public string Name { get { throw null; } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskOverridableValue : IJsonModel<ContainerRegistryTaskOverridableValue>, IPersistableModel<ContainerRegistryTaskOverridableValue>
    {
        ContainerRegistryTaskOverridableValue IJsonModel<ContainerRegistryTaskOverridableValue>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskOverridableValue>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskOverridableValue>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskOverridableValue IPersistableModel<ContainerRegistryTaskOverridableValue>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskOverridableValue>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryTaskOverridableValue(string name, string value) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("name")]
        public string Name { get { throw null; } set { } }
        [WirePath("value")]
        public string Value { get { throw null; } set { } }
        [WirePath("isSecret")]
        public bool? IsSecret { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskPatch : IJsonModel<ContainerRegistryTaskPatch>, IPersistableModel<ContainerRegistryTaskPatch>
    {
        ContainerRegistryTaskPatch IJsonModel<ContainerRegistryTaskPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskPatch>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskPatch IPersistableModel<ContainerRegistryTaskPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw null; } set { } }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw null; } }
        [WirePath("properties.platform")]
        public ContainerRegistryPlatformUpdateContent Platform { get { throw null; } set { } }
        [WirePath("properties.agentConfiguration.cpu")]
        public int? AgentCpu { get { throw null; } set { } }
        [WirePath("properties.agentPoolName")]
        public string AgentPoolName { get { throw null; } set { } }
        [WirePath("properties.timeout")]
        public int? TimeoutInSeconds { get { throw null; } set { } }
        [WirePath("properties.step")]
        public ContainerRegistryTaskStepUpdateContent Step { get { throw null; } set { } }
        [WirePath("properties.trigger")]
        public ContainerRegistryTriggerUpdateContent Trigger { get { throw null; } set { } }
        [WirePath("properties.credentials")]
        public ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        [WirePath("properties.logTemplate")]
        public string LogTemplate { get { throw null; } set { } }
        [WirePath("properties.status")]
        public ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryTaskRunContent>, IPersistableModel<ContainerRegistryTaskRunContent>
    {
        ContainerRegistryTaskRunContent IJsonModel<ContainerRegistryTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskRunContent IPersistableModel<ContainerRegistryTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryTaskRunContent(ResourceIdentifier taskId) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskId")]
        public ResourceIdentifier TaskId { get { throw null; } set { } }
        [WirePath("overrideTaskStepProperties")]
        public ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunPatch : IJsonModel<ContainerRegistryTaskRunPatch>, IPersistableModel<ContainerRegistryTaskRunPatch>
    {
        ContainerRegistryTaskRunPatch IJsonModel<ContainerRegistryTaskRunPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskRunPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunPatch>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskRunPatch IPersistableModel<ContainerRegistryTaskRunPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskRunPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("identity")]
        public ManagedServiceIdentity Identity { get { throw null; } set { } }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw null; } }
        [WirePath("location")]
        public AzureLocation? Location { get { throw null; } set { } }
        [WirePath("properties.forceUpdateTag")]
        public string ForceUpdateTag { get { throw null; } set { } }
        [WirePath("properties.runRequest")]
        public ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTrigger : IJsonModel<ContainerRegistryTimerTrigger>, IPersistableModel<ContainerRegistryTimerTrigger>
    {
        ContainerRegistryTimerTrigger IJsonModel<ContainerRegistryTimerTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTimerTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTrigger>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTimerTrigger IPersistableModel<ContainerRegistryTimerTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTimerTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryTimerTrigger(string schedule, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("schedule")]
        public string Schedule { get { throw null; } set { } }
        [WirePath("name")]
        public string Name { get { throw null; } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTriggerDescriptor : IJsonModel<ContainerRegistryTimerTriggerDescriptor>, IPersistableModel<ContainerRegistryTimerTriggerDescriptor>
    {
        ContainerRegistryTimerTriggerDescriptor IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTimerTriggerDescriptor IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("timerTriggerName")]
        public string TimerTriggerName { get { throw null; } set { } }
        [WirePath("scheduleOccurrence")]
        public string ScheduleOccurrence { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTriggerUpdateContent : IJsonModel<ContainerRegistryTimerTriggerUpdateContent>, IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>
    {
        ContainerRegistryTimerTriggerUpdateContent IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTimerTriggerUpdateContent IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public ContainerRegistryTimerTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("schedule")]
        public string Schedule { get { throw null; } set { } }
        [WirePath("name")]
        public string Name { get { throw null; } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTriggerProperties : IJsonModel<ContainerRegistryTriggerProperties>, IPersistableModel<ContainerRegistryTriggerProperties>
    {
        ContainerRegistryTriggerProperties IJsonModel<ContainerRegistryTriggerProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTriggerProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTriggerProperties>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTriggerProperties IPersistableModel<ContainerRegistryTriggerProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTriggerProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceTriggers")]
        public IList<ContainerRegistrySourceTrigger> SourceTriggers { get { throw null; } }
        [WirePath("timerTriggers")]
        public IList<ContainerRegistryTimerTrigger> TimerTriggers { get { throw null; } }
        [WirePath("baseImageTrigger")]
        public ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTriggerUpdateContent : IJsonModel<ContainerRegistryTriggerUpdateContent>, IPersistableModel<ContainerRegistryTriggerUpdateContent>
    {
        ContainerRegistryTriggerUpdateContent IJsonModel<ContainerRegistryTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTriggerUpdateContent IPersistableModel<ContainerRegistryTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceTriggers")]
        public IList<ContainerRegistrySourceTriggerUpdateContent> SourceTriggers { get { throw null; } }
        [WirePath("timerTriggers")]
        public IList<ContainerRegistryTimerTriggerUpdateContent> TimerTriggers { get { throw null; } }
        [WirePath("baseImageTrigger")]
        public ContainerRegistryBaseImageTriggerUpdateContent BaseImageTrigger { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomRegistryCredentials : IJsonModel<CustomRegistryCredentials>, IPersistableModel<CustomRegistryCredentials>
    {
        CustomRegistryCredentials IJsonModel<CustomRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<CustomRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<CustomRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw null;
        CustomRegistryCredentials IPersistableModel<CustomRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<CustomRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("userName")]
        public ContainerRegistrySecretObject UserName { get { throw null; } set { } }
        [WirePath("password")]
        public ContainerRegistrySecretObject Password { get { throw null; } set { } }
        [WirePath("identity")]
        public string Identity { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoAuthInfo : IJsonModel<SourceCodeRepoAuthInfo>, IPersistableModel<SourceCodeRepoAuthInfo>
    {
        SourceCodeRepoAuthInfo IJsonModel<SourceCodeRepoAuthInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceCodeRepoAuthInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoAuthInfo>.Write(ModelReaderWriterOptions options) => throw null;
        SourceCodeRepoAuthInfo IPersistableModel<SourceCodeRepoAuthInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceCodeRepoAuthInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public SourceCodeRepoAuthInfo(SourceCodeRepoAuthTokenType tokenType, string token) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tokenType")]
        public SourceCodeRepoAuthTokenType TokenType { get { throw null; } set { } }
        [WirePath("token")]
        public string Token { get { throw null; } set { } }
        [WirePath("refreshToken")]
        public string RefreshToken { get { throw null; } set { } }
        [WirePath("scope")]
        public string Scope { get { throw null; } set { } }
        [WirePath("expiresIn")]
        public int? ExpireInSeconds { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoAuthInfoUpdateContent : IJsonModel<SourceCodeRepoAuthInfoUpdateContent>, IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>
    {
        SourceCodeRepoAuthInfoUpdateContent IJsonModel<SourceCodeRepoAuthInfoUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceCodeRepoAuthInfoUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        SourceCodeRepoAuthInfoUpdateContent IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tokenType")]
        public SourceCodeRepoAuthTokenType? TokenType { get { throw null; } set { } }
        [WirePath("token")]
        public string Token { get { throw null; } set { } }
        [WirePath("refreshToken")]
        public string RefreshToken { get { throw null; } set { } }
        [WirePath("scope")]
        public string Scope { get { throw null; } set { } }
        [WirePath("expiresIn")]
        public int? ExpiresIn { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoProperties : IJsonModel<SourceCodeRepoProperties>, IPersistableModel<SourceCodeRepoProperties>
    {
        SourceCodeRepoProperties IJsonModel<SourceCodeRepoProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceCodeRepoProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoProperties>.Write(ModelReaderWriterOptions options) => throw null;
        SourceCodeRepoProperties IPersistableModel<SourceCodeRepoProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceCodeRepoProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        public SourceCodeRepoProperties(SourceControlType sourceControlType, System.Uri repositoryUri) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceControlType")]
        public SourceControlType SourceControlType { get { throw null; } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw null; } set { } }
        [WirePath("branch")]
        public string Branch { get { throw null; } set { } }
        [WirePath("sourceControlAuthProperties")]
        public SourceCodeRepoAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoUpdateContent : IJsonModel<SourceCodeRepoUpdateContent>, IPersistableModel<SourceCodeRepoUpdateContent>
    {
        SourceCodeRepoUpdateContent IJsonModel<SourceCodeRepoUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceCodeRepoUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        SourceCodeRepoUpdateContent IPersistableModel<SourceCodeRepoUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceCodeRepoUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceControlType")]
        public SourceControlType? SourceControlType { get { throw null; } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw null; } set { } }
        [WirePath("branch")]
        public string Branch { get { throw null; } set { } }
        [WirePath("sourceControlAuthProperties")]
        public SourceCodeRepoAuthInfoUpdateContent SourceControlAuthProperties { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceUploadDefinition : IJsonModel<SourceUploadDefinition>, IPersistableModel<SourceUploadDefinition>
    {
        SourceUploadDefinition IJsonModel<SourceUploadDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceUploadDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceUploadDefinition>.Write(ModelReaderWriterOptions options) => throw null;
        SourceUploadDefinition IPersistableModel<SourceUploadDefinition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceUploadDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("uploadUrl")]
        public System.Uri UploadUri { get { throw null; } }
        [WirePath("relativePath")]
        public string RelativePath { get { throw null; } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownRunRequest))]
    public abstract partial class ContainerRegistryRunContent : IJsonModel<ContainerRegistryRunContent>, IPersistableModel<ContainerRegistryRunContent>
    {
        ContainerRegistryRunContent IJsonModel<ContainerRegistryRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryRunContent IPersistableModel<ContainerRegistryRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected ContainerRegistryRunContent() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        [WirePath("agentPoolName")]
        public string AgentPoolName { get { throw null; } set { } }
        [WirePath("logTemplate")]
        public string LogTemplate { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepProperties))]
    public abstract partial class ContainerRegistryTaskStepProperties : IJsonModel<ContainerRegistryTaskStepProperties>, IPersistableModel<ContainerRegistryTaskStepProperties>
    {
        ContainerRegistryTaskStepProperties IJsonModel<ContainerRegistryTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskStepProperties IPersistableModel<ContainerRegistryTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected ContainerRegistryTaskStepProperties() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageDependencies")]
        public IReadOnlyList<ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw null; } }
        [WirePath("contextPath")]
        public string ContextPath { get { throw null; } set { } }
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepUpdateParameters))]
    public abstract partial class ContainerRegistryTaskStepUpdateContent : IJsonModel<ContainerRegistryTaskStepUpdateContent>, IPersistableModel<ContainerRegistryTaskStepUpdateContent>
    {
        ContainerRegistryTaskStepUpdateContent IJsonModel<ContainerRegistryTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<ContainerRegistryTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw null;
        ContainerRegistryTaskStepUpdateContent IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected ContainerRegistryTaskStepUpdateContent() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("contextPath")]
        public string ContextPath { get { throw null; } set { } }
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw null; } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryBaseImageDependencyType : IEquatable<ContainerRegistryBaseImageDependencyType>
    {
        private readonly string _value;
        public ContainerRegistryBaseImageDependencyType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryBaseImageDependencyType BuildTime { get; } = new ContainerRegistryBaseImageDependencyType("BuildTime");
        public static ContainerRegistryBaseImageDependencyType RunTime { get; } = new ContainerRegistryBaseImageDependencyType("RunTime");
        public static bool operator ==(ContainerRegistryBaseImageDependencyType left, ContainerRegistryBaseImageDependencyType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryBaseImageDependencyType left, ContainerRegistryBaseImageDependencyType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryBaseImageDependencyType(string value) => new ContainerRegistryBaseImageDependencyType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryBaseImageDependencyType other && Equals(other);
        public bool Equals(ContainerRegistryBaseImageDependencyType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryBaseImageTriggerType : IEquatable<ContainerRegistryBaseImageTriggerType>
    {
        private readonly string _value;
        public ContainerRegistryBaseImageTriggerType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryBaseImageTriggerType All { get; } = new ContainerRegistryBaseImageTriggerType("All");
        public static ContainerRegistryBaseImageTriggerType Runtime { get; } = new ContainerRegistryBaseImageTriggerType("Runtime");
        public static bool operator ==(ContainerRegistryBaseImageTriggerType left, ContainerRegistryBaseImageTriggerType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryBaseImageTriggerType left, ContainerRegistryBaseImageTriggerType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryBaseImageTriggerType(string value) => new ContainerRegistryBaseImageTriggerType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryBaseImageTriggerType other && Equals(other);
        public bool Equals(ContainerRegistryBaseImageTriggerType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryCpuVariant : IEquatable<ContainerRegistryCpuVariant>
    {
        private readonly string _value;
        public ContainerRegistryCpuVariant(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryCpuVariant V6 { get; } = new ContainerRegistryCpuVariant("v6");
        public static ContainerRegistryCpuVariant V7 { get; } = new ContainerRegistryCpuVariant("v7");
        public static ContainerRegistryCpuVariant V8 { get; } = new ContainerRegistryCpuVariant("v8");
        public static bool operator ==(ContainerRegistryCpuVariant left, ContainerRegistryCpuVariant right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryCpuVariant left, ContainerRegistryCpuVariant right) => !left.Equals(right);
        public static implicit operator ContainerRegistryCpuVariant(string value) => new ContainerRegistryCpuVariant(value);
        public override bool Equals(object obj) => obj is ContainerRegistryCpuVariant other && Equals(other);
        public bool Equals(ContainerRegistryCpuVariant other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryOS : IEquatable<ContainerRegistryOS>
    {
        private readonly string _value;
        public ContainerRegistryOS(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryOS Linux { get; } = new ContainerRegistryOS("Linux");
        public static ContainerRegistryOS Windows { get; } = new ContainerRegistryOS("Windows");
        public static bool operator ==(ContainerRegistryOS left, ContainerRegistryOS right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryOS left, ContainerRegistryOS right) => !left.Equals(right);
        public static implicit operator ContainerRegistryOS(string value) => new ContainerRegistryOS(value);
        public override bool Equals(object obj) => obj is ContainerRegistryOS other && Equals(other);
        public bool Equals(ContainerRegistryOS other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryOSArchitecture : IEquatable<ContainerRegistryOSArchitecture>
    {
        private readonly string _value;
        public ContainerRegistryOSArchitecture(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryOSArchitecture Amd64 { get; } = new ContainerRegistryOSArchitecture("amd64");
        public static ContainerRegistryOSArchitecture Arm { get; } = new ContainerRegistryOSArchitecture("arm");
        public static ContainerRegistryOSArchitecture Arm64 { get; } = new ContainerRegistryOSArchitecture("arm64");
        public static ContainerRegistryOSArchitecture ThreeHundredEightySix { get; } = new ContainerRegistryOSArchitecture("386");
        public static ContainerRegistryOSArchitecture X86 { get; } = new ContainerRegistryOSArchitecture("x86");
        public static bool operator ==(ContainerRegistryOSArchitecture left, ContainerRegistryOSArchitecture right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryOSArchitecture left, ContainerRegistryOSArchitecture right) => !left.Equals(right);
        public static implicit operator ContainerRegistryOSArchitecture(string value) => new ContainerRegistryOSArchitecture(value);
        public override bool Equals(object obj) => obj is ContainerRegistryOSArchitecture other && Equals(other);
        public bool Equals(ContainerRegistryOSArchitecture other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryRunStatus : IEquatable<ContainerRegistryRunStatus>
    {
        private readonly string _value;
        public ContainerRegistryRunStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryRunStatus Canceled { get; } = new ContainerRegistryRunStatus("Canceled");
        public static ContainerRegistryRunStatus Error { get; } = new ContainerRegistryRunStatus("Error");
        public static ContainerRegistryRunStatus Failed { get; } = new ContainerRegistryRunStatus("Failed");
        public static ContainerRegistryRunStatus Queued { get; } = new ContainerRegistryRunStatus("Queued");
        public static ContainerRegistryRunStatus Running { get; } = new ContainerRegistryRunStatus("Running");
        public static ContainerRegistryRunStatus Started { get; } = new ContainerRegistryRunStatus("Started");
        public static ContainerRegistryRunStatus Succeeded { get; } = new ContainerRegistryRunStatus("Succeeded");
        public static ContainerRegistryRunStatus Timeout { get; } = new ContainerRegistryRunStatus("Timeout");
        public static bool operator ==(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryRunStatus left, ContainerRegistryRunStatus right) => !left.Equals(right);
        public static implicit operator ContainerRegistryRunStatus(string value) => new ContainerRegistryRunStatus(value);
        public override bool Equals(object obj) => obj is ContainerRegistryRunStatus other && Equals(other);
        public bool Equals(ContainerRegistryRunStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryRunType : IEquatable<ContainerRegistryRunType>
    {
        private readonly string _value;
        public ContainerRegistryRunType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryRunType AutoBuild { get; } = new ContainerRegistryRunType("AutoBuild");
        public static ContainerRegistryRunType AutoRun { get; } = new ContainerRegistryRunType("AutoRun");
        public static ContainerRegistryRunType QuickBuild { get; } = new ContainerRegistryRunType("QuickBuild");
        public static ContainerRegistryRunType QuickRun { get; } = new ContainerRegistryRunType("QuickRun");
        public static bool operator ==(ContainerRegistryRunType left, ContainerRegistryRunType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryRunType left, ContainerRegistryRunType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryRunType(string value) => new ContainerRegistryRunType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryRunType other && Equals(other);
        public bool Equals(ContainerRegistryRunType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistrySecretObjectType : IEquatable<ContainerRegistrySecretObjectType>
    {
        private readonly string _value;
        public ContainerRegistrySecretObjectType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistrySecretObjectType Opaque { get; } = new ContainerRegistrySecretObjectType("Opaque");
        public static ContainerRegistrySecretObjectType VaultSecret { get; } = new ContainerRegistrySecretObjectType("Vaultsecret");
        public static bool operator ==(ContainerRegistrySecretObjectType left, ContainerRegistrySecretObjectType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistrySecretObjectType left, ContainerRegistrySecretObjectType right) => !left.Equals(right);
        public static implicit operator ContainerRegistrySecretObjectType(string value) => new ContainerRegistrySecretObjectType(value);
        public override bool Equals(object obj) => obj is ContainerRegistrySecretObjectType other && Equals(other);
        public bool Equals(ContainerRegistrySecretObjectType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistrySourceTriggerEvent : IEquatable<ContainerRegistrySourceTriggerEvent>
    {
        private readonly string _value;
        public ContainerRegistrySourceTriggerEvent(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistrySourceTriggerEvent Commit { get; } = new ContainerRegistrySourceTriggerEvent("commit");
        public static ContainerRegistrySourceTriggerEvent PullRequest { get; } = new ContainerRegistrySourceTriggerEvent("pullrequest");
        public static bool operator ==(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => left.Equals(right);
        public static bool operator !=(ContainerRegistrySourceTriggerEvent left, ContainerRegistrySourceTriggerEvent right) => !left.Equals(right);
        public static implicit operator ContainerRegistrySourceTriggerEvent(string value) => new ContainerRegistrySourceTriggerEvent(value);
        public override bool Equals(object obj) => obj is ContainerRegistrySourceTriggerEvent other && Equals(other);
        public bool Equals(ContainerRegistrySourceTriggerEvent other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryTaskStatus : IEquatable<ContainerRegistryTaskStatus>
    {
        private readonly string _value;
        public ContainerRegistryTaskStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryTaskStatus Disabled { get; } = new ContainerRegistryTaskStatus("Disabled");
        public static ContainerRegistryTaskStatus Enabled { get; } = new ContainerRegistryTaskStatus("Enabled");
        public static bool operator ==(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryTaskStatus left, ContainerRegistryTaskStatus right) => !left.Equals(right);
        public static implicit operator ContainerRegistryTaskStatus(string value) => new ContainerRegistryTaskStatus(value);
        public override bool Equals(object obj) => obj is ContainerRegistryTaskStatus other && Equals(other);
        public bool Equals(ContainerRegistryTaskStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    // ContainerRegistryTriggerStatus is now generated from the spec (via @@clientName on TriggerStatus).
    // The generated partial struct only has operators and constants. This partial provides the remaining
    // members (field, constructor, static properties, Equals, GetHashCode, ToString).
    public readonly partial struct ContainerRegistryTriggerStatus
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTriggerStatus"/>. </summary>
        public ContainerRegistryTriggerStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Enabled. </summary>
        public static ContainerRegistryTriggerStatus Disabled { get; } = new ContainerRegistryTriggerStatus("Disabled");
        /// <summary> Disabled. </summary>
        public static ContainerRegistryTriggerStatus Enabled { get; } = new ContainerRegistryTriggerStatus("Enabled");
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerRegistryTriggerStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerRegistryTriggerStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerRegistryUpdateTriggerPayloadType : IEquatable<ContainerRegistryUpdateTriggerPayloadType>
    {
        private readonly string _value;
        public ContainerRegistryUpdateTriggerPayloadType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static ContainerRegistryUpdateTriggerPayloadType Default { get; } = new ContainerRegistryUpdateTriggerPayloadType("Default");
        public static ContainerRegistryUpdateTriggerPayloadType Token { get; } = new ContainerRegistryUpdateTriggerPayloadType("Token");
        public static bool operator ==(ContainerRegistryUpdateTriggerPayloadType left, ContainerRegistryUpdateTriggerPayloadType right) => left.Equals(right);
        public static bool operator !=(ContainerRegistryUpdateTriggerPayloadType left, ContainerRegistryUpdateTriggerPayloadType right) => !left.Equals(right);
        public static implicit operator ContainerRegistryUpdateTriggerPayloadType(string value) => new ContainerRegistryUpdateTriggerPayloadType(value);
        public override bool Equals(object obj) => obj is ContainerRegistryUpdateTriggerPayloadType other && Equals(other);
        public bool Equals(ContainerRegistryUpdateTriggerPayloadType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SourceCodeRepoAuthTokenType : IEquatable<SourceCodeRepoAuthTokenType>
    {
        private readonly string _value;
        public SourceCodeRepoAuthTokenType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static SourceCodeRepoAuthTokenType OAuth { get; } = new SourceCodeRepoAuthTokenType("OAuth");
        public static SourceCodeRepoAuthTokenType Pat { get; } = new SourceCodeRepoAuthTokenType("PAT");
        public static bool operator ==(SourceCodeRepoAuthTokenType left, SourceCodeRepoAuthTokenType right) => left.Equals(right);
        public static bool operator !=(SourceCodeRepoAuthTokenType left, SourceCodeRepoAuthTokenType right) => !left.Equals(right);
        public static implicit operator SourceCodeRepoAuthTokenType(string value) => new SourceCodeRepoAuthTokenType(value);
        public override bool Equals(object obj) => obj is SourceCodeRepoAuthTokenType other && Equals(other);
        public bool Equals(SourceCodeRepoAuthTokenType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SourceControlType : IEquatable<SourceControlType>
    {
        private readonly string _value;
        public SourceControlType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static SourceControlType Github { get; } = new SourceControlType("Github");
        public static SourceControlType VisualStudioTeamService { get; } = new SourceControlType("VisualStudioTeamService");
        public static bool operator ==(SourceControlType left, SourceControlType right) => left.Equals(right);
        public static bool operator !=(SourceControlType left, SourceControlType right) => !left.Equals(right);
        public static implicit operator SourceControlType(string value) => new SourceControlType(value);
        public override bool Equals(object obj) => obj is SourceControlType other && Equals(other);
        public bool Equals(SourceControlType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SourceRegistryLoginMode : IEquatable<SourceRegistryLoginMode>
    {
        private readonly string _value;
        public SourceRegistryLoginMode(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        public static SourceRegistryLoginMode Default { get; } = new SourceRegistryLoginMode("Default");
        public static SourceRegistryLoginMode None { get; } = new SourceRegistryLoginMode("None");
        public static bool operator ==(SourceRegistryLoginMode left, SourceRegistryLoginMode right) => left.Equals(right);
        public static bool operator !=(SourceRegistryLoginMode left, SourceRegistryLoginMode right) => !left.Equals(right);
        public static implicit operator SourceRegistryLoginMode(string value) => new SourceRegistryLoginMode(value);
        public override bool Equals(object obj) => obj is SourceRegistryLoginMode other && Equals(other);
        public bool Equals(SourceRegistryLoginMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceRegistryCredentials : IJsonModel<SourceRegistryCredentials>, IPersistableModel<SourceRegistryCredentials>
    {
        SourceRegistryCredentials IJsonModel<SourceRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;
        void IJsonModel<SourceRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw null;
        SourceRegistryCredentials IPersistableModel<SourceRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;
        string IPersistableModel<SourceRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary>
        /// The Entra identity used for source registry login.
        /// The value is `[system]` for system-assigned managed identity, `[caller]` for caller identity,
        /// and client ID for user-assigned managed identity.
        /// </summary>
        [WirePath("identity")]
        public string Identity { get { throw null; } set { } }
        /// <summary>
        /// The authentication mode which determines the source registry login scope.
        /// </summary>
        [WirePath("loginMode")]
        public SourceRegistryLoginMode? LoginMode { get { throw null; } set { } }
    }

}

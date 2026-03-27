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
    // Backward compatibility: Task-related model types (DockerBuildStep, EncodedTaskStep, FileTaskStep,
    // TaskOverridableValue, TaskPatch, TaskRunContent, TaskStepProperties, TaskStatus enum, etc.) have been
    // moved to Azure.ResourceManager.ContainerRegistryTasks. These deprecated stubs preserve the old API
    // surface with [Obsolete] attributes and NotSupportedException implementations so existing code compiles
    // but directs users to the new package.

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryDockerBuildStep>, IPersistableModel<ContainerRegistryDockerBuildStep>
    {
        ContainerRegistryDockerBuildStep IJsonModel<ContainerRegistryDockerBuildStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryDockerBuildStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryDockerBuildStep IPersistableModel<ContainerRegistryDockerBuildStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryDockerBuildStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw new NotSupportedException(); } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw new NotSupportedException(); } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>, IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>
    {
        ContainerRegistryDockerBuildStepUpdateContent IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryDockerBuildStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryDockerBuildStepUpdateContent IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryDockerBuildStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw new NotSupportedException(); } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw new NotSupportedException(); } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryEncodedTaskStep>, IPersistableModel<ContainerRegistryEncodedTaskStep>
    {
        ContainerRegistryEncodedTaskStep IJsonModel<ContainerRegistryEncodedTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryEncodedTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryEncodedTaskStep IPersistableModel<ContainerRegistryEncodedTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>, IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>
    {
        ContainerRegistryEncodedTaskStepUpdateContent IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryEncodedTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryEncodedTaskStepUpdateContent IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryEncodedTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryFileTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryFileTaskStep>, IPersistableModel<ContainerRegistryFileTaskStep>
    {
        ContainerRegistryFileTaskStep IJsonModel<ContainerRegistryFileTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryFileTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryFileTaskStep IPersistableModel<ContainerRegistryFileTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryFileTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryFileTaskStep(string taskFilePath) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryFileTaskStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryFileTaskStepUpdateContent>, IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>
    {
        ContainerRegistryFileTaskStepUpdateContent IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryFileTaskStepUpdateContent IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskOverridableValue : IJsonModel<ContainerRegistryTaskOverridableValue>, IPersistableModel<ContainerRegistryTaskOverridableValue>
    {
        ContainerRegistryTaskOverridableValue IJsonModel<ContainerRegistryTaskOverridableValue>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskOverridableValue>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskOverridableValue>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskOverridableValue IPersistableModel<ContainerRegistryTaskOverridableValue>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskOverridableValue>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTaskOverridableValue(string name, string value) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } set { } }
        [WirePath("value")]
        public string Value { get { throw new NotSupportedException(); } set { } }
        [WirePath("isSecret")]
        public bool? IsSecret { get { throw new NotSupportedException(); } set { } }
    }

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

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryTaskRunContent>, IPersistableModel<ContainerRegistryTaskRunContent>
    {
        ContainerRegistryTaskRunContent IJsonModel<ContainerRegistryTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskRunContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskRunContent IPersistableModel<ContainerRegistryTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTaskRunContent(ResourceIdentifier taskId) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskId")]
        public ResourceIdentifier TaskId { get { throw new NotSupportedException(); } set { } }
        [WirePath("overrideTaskStepProperties")]
        public ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties { get { throw new NotSupportedException(); } set { } }
    }

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

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepProperties))]
    public abstract partial class ContainerRegistryTaskStepProperties : IJsonModel<ContainerRegistryTaskStepProperties>, IPersistableModel<ContainerRegistryTaskStepProperties>
    {
        ContainerRegistryTaskStepProperties IJsonModel<ContainerRegistryTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskStepProperties IPersistableModel<ContainerRegistryTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected ContainerRegistryTaskStepProperties() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageDependencies")]
        public IReadOnlyList<ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw new NotSupportedException(); } }
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException(); } set { } }
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepUpdateParameters))]
    public abstract partial class ContainerRegistryTaskStepUpdateContent : IJsonModel<ContainerRegistryTaskStepUpdateContent>, IPersistableModel<ContainerRegistryTaskStepUpdateContent>
    {
        ContainerRegistryTaskStepUpdateContent IJsonModel<ContainerRegistryTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskStepUpdateContent IPersistableModel<ContainerRegistryTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected ContainerRegistryTaskStepUpdateContent() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException(); } set { } }
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw new NotSupportedException(); } set { } }
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

}

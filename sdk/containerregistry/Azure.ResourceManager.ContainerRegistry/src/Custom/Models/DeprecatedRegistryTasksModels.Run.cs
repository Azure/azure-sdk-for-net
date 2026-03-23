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
    public partial class ContainerRegistryDockerBuildContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryDockerBuildContent>, IPersistableModel<ContainerRegistryDockerBuildContent>
    {
        ContainerRegistryDockerBuildContent IJsonModel<ContainerRegistryDockerBuildContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryDockerBuildContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryDockerBuildContent IPersistableModel<ContainerRegistryDockerBuildContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryDockerBuildContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryDockerBuildContent(string dockerFilePath, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("platform")]
        public ContainerRegistryPlatformProperties Platform { get { throw new NotSupportedException(); } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw new NotSupportedException(); } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw new NotSupportedException(); } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw new NotSupportedException(); } set { } }
        [WirePath("agentConfiguration.cpu")]
        public int? AgentCpu { get { throw new NotSupportedException(); } set { } }
        [WirePath("timeout")]
        public int? TimeoutInSeconds { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceLocation")]
        public string SourceLocation { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("credentials")]
        public ContainerRegistryCredentials Credentials { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryEncodedTaskRunContent : ContainerRegistryRunContent, IJsonModel<ContainerRegistryEncodedTaskRunContent>, IPersistableModel<ContainerRegistryEncodedTaskRunContent>
    {
        ContainerRegistryEncodedTaskRunContent IJsonModel<ContainerRegistryEncodedTaskRunContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryEncodedTaskRunContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskRunContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryEncodedTaskRunContent IPersistableModel<ContainerRegistryEncodedTaskRunContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryEncodedTaskRunContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryEncodedTaskRunContent(string encodedTaskContent, ContainerRegistryPlatformProperties platform) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw new NotSupportedException(); } set { } }
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

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryImageUpdateTrigger : IJsonModel<ContainerRegistryImageUpdateTrigger>, IPersistableModel<ContainerRegistryImageUpdateTrigger>
    {
        ContainerRegistryImageUpdateTrigger IJsonModel<ContainerRegistryImageUpdateTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryImageUpdateTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryImageUpdateTrigger>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryImageUpdateTrigger IPersistableModel<ContainerRegistryImageUpdateTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryImageUpdateTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("id")]
        public System.Guid? Id { get { throw new NotSupportedException(); } set { } }
        [WirePath("timestamp")]
        public System.DateTimeOffset? Timestamp { get { throw new NotSupportedException(); } set { } }
        [WirePath("images")]
        public IList<ContainerRegistryImageDescriptor> Images { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryOverrideTaskStepProperties : IJsonModel<ContainerRegistryOverrideTaskStepProperties>, IPersistableModel<ContainerRegistryOverrideTaskStepProperties>
    {
        ContainerRegistryOverrideTaskStepProperties IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryOverrideTaskStepProperties IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException(); } set { } }
        [WirePath("file")]
        public string File { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunArgument : IJsonModel<ContainerRegistryRunArgument>, IPersistableModel<ContainerRegistryRunArgument>
    {
        ContainerRegistryRunArgument IJsonModel<ContainerRegistryRunArgument>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunArgument>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunArgument>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunArgument IPersistableModel<ContainerRegistryRunArgument>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunArgument>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryRunArgument(string name, string value) { }
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
    public partial class ContainerRegistryRunGetLogResult : IJsonModel<ContainerRegistryRunGetLogResult>, IPersistableModel<ContainerRegistryRunGetLogResult>
    {
        ContainerRegistryRunGetLogResult IJsonModel<ContainerRegistryRunGetLogResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunGetLogResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunGetLogResult>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunGetLogResult IPersistableModel<ContainerRegistryRunGetLogResult>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunGetLogResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("logLink")]
        public string LogLink { get { throw new NotSupportedException(); } }
        [WirePath("logArtifactLink")]
        public string LogArtifactLink { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryRunPatch : IJsonModel<ContainerRegistryRunPatch>, IPersistableModel<ContainerRegistryRunPatch>
    {
        ContainerRegistryRunPatch IJsonModel<ContainerRegistryRunPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryRunPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryRunPatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryRunPatch IPersistableModel<ContainerRegistryRunPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryRunPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("isArchiveEnabled")]
        public bool? IsArchiveEnabled { get { throw new NotSupportedException(); } set { } }
    }

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

}

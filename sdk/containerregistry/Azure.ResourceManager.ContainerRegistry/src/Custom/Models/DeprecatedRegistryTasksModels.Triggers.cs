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
    public partial class ContainerRegistryBaseImageDependency : IJsonModel<ContainerRegistryBaseImageDependency>, IPersistableModel<ContainerRegistryBaseImageDependency>
    {
        ContainerRegistryBaseImageDependency IJsonModel<ContainerRegistryBaseImageDependency>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryBaseImageDependency>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageDependency>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryBaseImageDependency IPersistableModel<ContainerRegistryBaseImageDependency>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryBaseImageDependency>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
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

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageTrigger : IJsonModel<ContainerRegistryBaseImageTrigger>, IPersistableModel<ContainerRegistryBaseImageTrigger>
    {
        ContainerRegistryBaseImageTrigger IJsonModel<ContainerRegistryBaseImageTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryBaseImageTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageTrigger>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryBaseImageTrigger IPersistableModel<ContainerRegistryBaseImageTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryBaseImageTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryBaseImageTrigger(ContainerRegistryBaseImageTriggerType baseImageTriggerType, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageTriggerType")]
        public ContainerRegistryBaseImageTriggerType BaseImageTriggerType { get { throw new NotSupportedException(); } set { } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerEndpoint")]
        public string UpdateTriggerEndpoint { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerPayloadType")]
        public ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryBaseImageTriggerUpdateContent : IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>, IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>
    {
        ContainerRegistryBaseImageTriggerUpdateContent IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryBaseImageTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryBaseImageTriggerUpdateContent IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryBaseImageTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryBaseImageTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageTriggerType")]
        public ContainerRegistryBaseImageTriggerType? BaseImageTriggerType { get { throw new NotSupportedException(); } set { } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerEndpoint")]
        public string UpdateTriggerEndpoint { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerPayloadType")]
        public ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySourceTrigger : IJsonModel<ContainerRegistrySourceTrigger>, IPersistableModel<ContainerRegistrySourceTrigger>
    {
        ContainerRegistrySourceTrigger IJsonModel<ContainerRegistrySourceTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistrySourceTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTrigger>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistrySourceTrigger IPersistableModel<ContainerRegistrySourceTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistrySourceTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistrySourceTrigger(SourceCodeRepoProperties sourceRepository, System.Collections.Generic.IEnumerable<ContainerRegistrySourceTriggerEvent> sourceTriggerEvents, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRepository")]
        public SourceCodeRepoProperties SourceRepository { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceTriggerEvents")]
        public IList<ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw new NotSupportedException(); } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
    }

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

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySourceTriggerUpdateContent : IJsonModel<ContainerRegistrySourceTriggerUpdateContent>, IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>
    {
        ContainerRegistrySourceTriggerUpdateContent IJsonModel<ContainerRegistrySourceTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistrySourceTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistrySourceTriggerUpdateContent IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistrySourceTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistrySourceTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRepository")]
        public SourceCodeRepoUpdateContent SourceRepository { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceTriggerEvents")]
        public IList<ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw new NotSupportedException(); } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTrigger : IJsonModel<ContainerRegistryTimerTrigger>, IPersistableModel<ContainerRegistryTimerTrigger>
    {
        ContainerRegistryTimerTrigger IJsonModel<ContainerRegistryTimerTrigger>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTimerTrigger>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTrigger>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTimerTrigger IPersistableModel<ContainerRegistryTimerTrigger>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTimerTrigger>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTimerTrigger(string schedule, string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("schedule")]
        public string Schedule { get { throw new NotSupportedException(); } set { } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } set { } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTriggerDescriptor : IJsonModel<ContainerRegistryTimerTriggerDescriptor>, IPersistableModel<ContainerRegistryTimerTriggerDescriptor>
    {
        ContainerRegistryTimerTriggerDescriptor IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTimerTriggerDescriptor IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("timerTriggerName")]
        public string TimerTriggerName { get { throw new NotSupportedException(); } set { } }
        [WirePath("scheduleOccurrence")]
        public string ScheduleOccurrence { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTimerTriggerUpdateContent : IJsonModel<ContainerRegistryTimerTriggerUpdateContent>, IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>
    {
        ContainerRegistryTimerTriggerUpdateContent IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTimerTriggerUpdateContent IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTimerTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("schedule")]
        public string Schedule { get { throw new NotSupportedException(); } set { } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTriggerProperties : IJsonModel<ContainerRegistryTriggerProperties>, IPersistableModel<ContainerRegistryTriggerProperties>
    {
        ContainerRegistryTriggerProperties IJsonModel<ContainerRegistryTriggerProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTriggerProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTriggerProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTriggerProperties IPersistableModel<ContainerRegistryTriggerProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTriggerProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceTriggers")]
        public IList<ContainerRegistrySourceTrigger> SourceTriggers { get { throw new NotSupportedException(); } }
        [WirePath("timerTriggers")]
        public IList<ContainerRegistryTimerTrigger> TimerTriggers { get { throw new NotSupportedException(); } }
        [WirePath("baseImageTrigger")]
        public ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTriggerUpdateContent : IJsonModel<ContainerRegistryTriggerUpdateContent>, IPersistableModel<ContainerRegistryTriggerUpdateContent>
    {
        ContainerRegistryTriggerUpdateContent IJsonModel<ContainerRegistryTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTriggerUpdateContent IPersistableModel<ContainerRegistryTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceTriggers")]
        public IList<ContainerRegistrySourceTriggerUpdateContent> SourceTriggers { get { throw new NotSupportedException(); } }
        [WirePath("timerTriggers")]
        public IList<ContainerRegistryTimerTriggerUpdateContent> TimerTriggers { get { throw new NotSupportedException(); } }
        [WirePath("baseImageTrigger")]
        public ContainerRegistryBaseImageTriggerUpdateContent BaseImageTrigger { get { throw new NotSupportedException(); } set { } }
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

    // ContainerRegistryTriggerStatus is now generated from the spec (via @@clientName on TriggerStatus).
    // The generated partial struct only has operators and constants. This partial provides the remaining
    // members (field, constructor, static properties, Equals, GetHashCode, ToString).
    public readonly partial struct ContainerRegistryTriggerStatus
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryTriggerStatus"/>. </summary>
        public ContainerRegistryTriggerStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> Disabled. </summary>
        public static ContainerRegistryTriggerStatus Disabled { get; } = new ContainerRegistryTriggerStatus("Disabled");
        /// <summary> Enabled. </summary>
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

}

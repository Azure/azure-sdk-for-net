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
        ContainerRegistryAgentPoolPatch IJsonModel<ContainerRegistryAgentPoolPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryAgentPoolPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolPatch>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryAgentPoolPatch IPersistableModel<ContainerRegistryAgentPoolPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryAgentPoolPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get { throw new NotSupportedException(); } }
        [WirePath("properties.count")]
        public int? Count { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryAgentPoolQueueStatus : IJsonModel<ContainerRegistryAgentPoolQueueStatus>, IPersistableModel<ContainerRegistryAgentPoolQueueStatus>
    {
        ContainerRegistryAgentPoolQueueStatus IJsonModel<ContainerRegistryAgentPoolQueueStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryAgentPoolQueueStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryAgentPoolQueueStatus IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryAgentPoolQueueStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("count")]
        public int? Count { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryCredentials : IJsonModel<ContainerRegistryCredentials>, IPersistableModel<ContainerRegistryCredentials>
    {
        ContainerRegistryCredentials IJsonModel<ContainerRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryCredentials IPersistableModel<ContainerRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceRegistry")]
        public SourceRegistryCredentials SourceRegistry { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceRegistry.loginMode")]
        public SourceRegistryLoginMode? SourceRegistryLoginMode { get { throw new NotSupportedException(); } set { } }
        [WirePath("customRegistries")]
        public IDictionary<string, CustomRegistryCredentials> CustomRegistries { get { throw new NotSupportedException(); } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryPlatformProperties : IJsonModel<ContainerRegistryPlatformProperties>, IPersistableModel<ContainerRegistryPlatformProperties>
    {
        ContainerRegistryPlatformProperties IJsonModel<ContainerRegistryPlatformProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryPlatformProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryPlatformProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryPlatformProperties IPersistableModel<ContainerRegistryPlatformProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryPlatformProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryPlatformProperties(ContainerRegistryOS os) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("os")]
        public ContainerRegistryOS OS { get { throw new NotSupportedException(); } set { } }
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw new NotSupportedException(); } set { } }
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryPlatformUpdateContent : IJsonModel<ContainerRegistryPlatformUpdateContent>, IPersistableModel<ContainerRegistryPlatformUpdateContent>
    {
        ContainerRegistryPlatformUpdateContent IJsonModel<ContainerRegistryPlatformUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryPlatformUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryPlatformUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryPlatformUpdateContent IPersistableModel<ContainerRegistryPlatformUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("os")]
        public ContainerRegistryOS? OS { get { throw new NotSupportedException(); } set { } }
        [WirePath("architecture")]
        public ContainerRegistryOSArchitecture? Architecture { get { throw new NotSupportedException(); } set { } }
        [WirePath("variant")]
        public ContainerRegistryCpuVariant? Variant { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistrySecretObject : IJsonModel<ContainerRegistrySecretObject>, IPersistableModel<ContainerRegistrySecretObject>
    {
        ContainerRegistrySecretObject IJsonModel<ContainerRegistrySecretObject>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistrySecretObject>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistrySecretObject>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistrySecretObject IPersistableModel<ContainerRegistrySecretObject>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistrySecretObject>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("value")]
        public string Value { get { throw new NotSupportedException(); } set { } }
        [WirePath("type")]
        public ContainerRegistrySecretObjectType? ObjectType { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomRegistryCredentials : IJsonModel<CustomRegistryCredentials>, IPersistableModel<CustomRegistryCredentials>
    {
        CustomRegistryCredentials IJsonModel<CustomRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<CustomRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<CustomRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        CustomRegistryCredentials IPersistableModel<CustomRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<CustomRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("userName")]
        public ContainerRegistrySecretObject UserName { get { throw new NotSupportedException(); } set { } }
        [WirePath("password")]
        public ContainerRegistrySecretObject Password { get { throw new NotSupportedException(); } set { } }
        [WirePath("identity")]
        public string Identity { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoAuthInfo : IJsonModel<SourceCodeRepoAuthInfo>, IPersistableModel<SourceCodeRepoAuthInfo>
    {
        SourceCodeRepoAuthInfo IJsonModel<SourceCodeRepoAuthInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoAuthInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoAuthInfo>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoAuthInfo IPersistableModel<SourceCodeRepoAuthInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoAuthInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public SourceCodeRepoAuthInfo(SourceCodeRepoAuthTokenType tokenType, string token) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tokenType")]
        public SourceCodeRepoAuthTokenType TokenType { get { throw new NotSupportedException(); } set { } }
        [WirePath("token")]
        public string Token { get { throw new NotSupportedException(); } set { } }
        [WirePath("refreshToken")]
        public string RefreshToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("scope")]
        public string Scope { get { throw new NotSupportedException(); } set { } }
        [WirePath("expiresIn")]
        public int? ExpireInSeconds { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoAuthInfoUpdateContent : IJsonModel<SourceCodeRepoAuthInfoUpdateContent>, IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>
    {
        SourceCodeRepoAuthInfoUpdateContent IJsonModel<SourceCodeRepoAuthInfoUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoAuthInfoUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoAuthInfoUpdateContent IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoAuthInfoUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tokenType")]
        public SourceCodeRepoAuthTokenType? TokenType { get { throw new NotSupportedException(); } set { } }
        [WirePath("token")]
        public string Token { get { throw new NotSupportedException(); } set { } }
        [WirePath("refreshToken")]
        public string RefreshToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("scope")]
        public string Scope { get { throw new NotSupportedException(); } set { } }
        [WirePath("expiresIn")]
        public int? ExpiresIn { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoProperties : IJsonModel<SourceCodeRepoProperties>, IPersistableModel<SourceCodeRepoProperties>
    {
        SourceCodeRepoProperties IJsonModel<SourceCodeRepoProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoProperties IPersistableModel<SourceCodeRepoProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public SourceCodeRepoProperties(SourceControlType sourceControlType, System.Uri repositoryUri) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceControlType")]
        public SourceControlType SourceControlType { get { throw new NotSupportedException(); } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw new NotSupportedException(); } set { } }
        [WirePath("branch")]
        public string Branch { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceControlAuthProperties")]
        public SourceCodeRepoAuthInfo SourceControlAuthProperties { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceCodeRepoUpdateContent : IJsonModel<SourceCodeRepoUpdateContent>, IPersistableModel<SourceCodeRepoUpdateContent>
    {
        SourceCodeRepoUpdateContent IJsonModel<SourceCodeRepoUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoUpdateContent IPersistableModel<SourceCodeRepoUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceControlType")]
        public SourceControlType? SourceControlType { get { throw new NotSupportedException(); } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw new NotSupportedException(); } set { } }
        [WirePath("branch")]
        public string Branch { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceControlAuthProperties")]
        public SourceCodeRepoAuthInfoUpdateContent SourceControlAuthProperties { get { throw new NotSupportedException(); } set { } }
    }

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SourceUploadDefinition : IJsonModel<SourceUploadDefinition>, IPersistableModel<SourceUploadDefinition>
    {
        SourceUploadDefinition IJsonModel<SourceUploadDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceUploadDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceUploadDefinition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceUploadDefinition IPersistableModel<SourceUploadDefinition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceUploadDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("uploadUrl")]
        public System.Uri UploadUri { get { throw new NotSupportedException(); } }
        [WirePath("relativePath")]
        public string RelativePath { get { throw new NotSupportedException(); } }
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
        SourceRegistryCredentials IJsonModel<SourceRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceRegistryCredentials IPersistableModel<SourceRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary>
        /// The Entra identity used for source registry login.
        /// The value is `[system]` for system-assigned managed identity, `[caller]` for caller identity,
        /// and client ID for user-assigned managed identity.
        /// </summary>
        [WirePath("identity")]
        public string Identity { get { throw new NotSupportedException(); } set { } }
        /// <summary>
        /// The authentication mode which determines the source registry login scope.
        /// </summary>
        [WirePath("loginMode")]
        public SourceRegistryLoginMode? LoginMode { get { throw new NotSupportedException(); } set { } }
    }

}

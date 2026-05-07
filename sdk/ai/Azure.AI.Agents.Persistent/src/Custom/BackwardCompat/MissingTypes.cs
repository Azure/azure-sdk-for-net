// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stubs: These extensible enum types existed in GA 1.0.0 but the new emitter
// internalized or removed them. Stub implementations maintain API compatibility.

using System;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> Backward-compat stub for AzureFunctionBindingType. </summary>
    public readonly partial struct AzureFunctionBindingType : IEquatable<AzureFunctionBindingType>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of <see cref="AzureFunctionBindingType"/>. </summary>
        public AzureFunctionBindingType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> storage_queue. </summary>
        public static AzureFunctionBindingType StorageQueue { get; } = new("storage_queue");
        /// <inheritdoc />
        public bool Equals(AzureFunctionBindingType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is AzureFunctionBindingType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(AzureFunctionBindingType left, AzureFunctionBindingType right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(AzureFunctionBindingType left, AzureFunctionBindingType right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator AzureFunctionBindingType(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(AzureFunctionBindingType value) => value._value;
    }

    /// <summary> Backward-compat stub for FileSearchToolCallContentType. </summary>
    public readonly partial struct FileSearchToolCallContentType : IEquatable<FileSearchToolCallContentType>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public FileSearchToolCallContentType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> text. </summary>
        public static FileSearchToolCallContentType Text { get; } = new("text");
        /// <inheritdoc />
        public bool Equals(FileSearchToolCallContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is FileSearchToolCallContentType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(FileSearchToolCallContentType left, FileSearchToolCallContentType right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(FileSearchToolCallContentType left, FileSearchToolCallContentType right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator FileSearchToolCallContentType(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(FileSearchToolCallContentType value) => value._value;
    }

    /// <summary> Backward-compat stub for MessageDeltaChunkObject. </summary>
    public readonly partial struct MessageDeltaChunkObject : IEquatable<MessageDeltaChunkObject>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public MessageDeltaChunkObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> thread.message.delta. </summary>
        public static MessageDeltaChunkObject ThreadMessageDelta { get; } = new("thread.message.delta");
        /// <inheritdoc />
        public bool Equals(MessageDeltaChunkObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is MessageDeltaChunkObject other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(MessageDeltaChunkObject left, MessageDeltaChunkObject right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(MessageDeltaChunkObject left, MessageDeltaChunkObject right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator MessageDeltaChunkObject(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(MessageDeltaChunkObject value) => value._value;
    }

    /// <summary> Backward-compat stub for PersistentAgentsVectorStoreObject. </summary>
    public readonly partial struct PersistentAgentsVectorStoreObject : IEquatable<PersistentAgentsVectorStoreObject>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public PersistentAgentsVectorStoreObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> vector_store. </summary>
        public static PersistentAgentsVectorStoreObject VectorStore { get; } = new("vector_store");
        /// <inheritdoc />
        public bool Equals(PersistentAgentsVectorStoreObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is PersistentAgentsVectorStoreObject other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(PersistentAgentsVectorStoreObject left, PersistentAgentsVectorStoreObject right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(PersistentAgentsVectorStoreObject left, PersistentAgentsVectorStoreObject right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator PersistentAgentsVectorStoreObject(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(PersistentAgentsVectorStoreObject value) => value._value;
    }

    /// <summary> Backward-compat stub for ResponseFormatJsonSchemaTypeType. </summary>
    public readonly partial struct ResponseFormatJsonSchemaTypeType : IEquatable<ResponseFormatJsonSchemaTypeType>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public ResponseFormatJsonSchemaTypeType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> json_schema. </summary>
        public static ResponseFormatJsonSchemaTypeType JsonSchema { get; } = new("json_schema");
        /// <inheritdoc />
        public bool Equals(ResponseFormatJsonSchemaTypeType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ResponseFormatJsonSchemaTypeType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(ResponseFormatJsonSchemaTypeType left, ResponseFormatJsonSchemaTypeType right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(ResponseFormatJsonSchemaTypeType left, ResponseFormatJsonSchemaTypeType right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator ResponseFormatJsonSchemaTypeType(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(ResponseFormatJsonSchemaTypeType value) => value._value;
    }

    /// <summary> Backward-compat stub for RunStepDeltaChunkObject. </summary>
    public readonly partial struct RunStepDeltaChunkObject : IEquatable<RunStepDeltaChunkObject>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public RunStepDeltaChunkObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> thread.run.step.delta. </summary>
        public static RunStepDeltaChunkObject ThreadRunStepDelta { get; } = new("thread.run.step.delta");
        /// <inheritdoc />
        public bool Equals(RunStepDeltaChunkObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is RunStepDeltaChunkObject other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(RunStepDeltaChunkObject left, RunStepDeltaChunkObject right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(RunStepDeltaChunkObject left, RunStepDeltaChunkObject right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator RunStepDeltaChunkObject(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(RunStepDeltaChunkObject value) => value._value;
    }

    /// <summary> Backward-compat stub for VectorStoreFileBatchObject. </summary>
    public readonly partial struct VectorStoreFileBatchObject : IEquatable<VectorStoreFileBatchObject>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public VectorStoreFileBatchObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> vector_store.files_batch. </summary>
        public static VectorStoreFileBatchObject VectorStoreFilesBatch { get; } = new("vector_store.files_batch");
        /// <inheritdoc />
        public bool Equals(VectorStoreFileBatchObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is VectorStoreFileBatchObject other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(VectorStoreFileBatchObject left, VectorStoreFileBatchObject right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(VectorStoreFileBatchObject left, VectorStoreFileBatchObject right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator VectorStoreFileBatchObject(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(VectorStoreFileBatchObject value) => value._value;
    }

    /// <summary> Backward-compat stub for VectorStoreFileObject. </summary>
    public readonly partial struct VectorStoreFileObject : IEquatable<VectorStoreFileObject>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance. </summary>
        public VectorStoreFileObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary> vector_store.file. </summary>
        public static VectorStoreFileObject VectorStoreFile { get; } = new("vector_store.file");
        /// <inheritdoc />
        public bool Equals(VectorStoreFileObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is VectorStoreFileObject other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
        /// <summary> Equality operator. </summary>
        public static bool operator ==(VectorStoreFileObject left, VectorStoreFileObject right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(VectorStoreFileObject left, VectorStoreFileObject right) => !left.Equals(right);
        /// <summary> Implicit conversion from string. </summary>
        public static implicit operator VectorStoreFileObject(string value) => new(value);
        /// <summary> Implicit conversion to string. </summary>
        public static implicit operator string(VectorStoreFileObject value) => value._value;
    }
}

namespace Microsoft.Extensions.Azure
{
    /// <summary> Backward-compat stub — old name was AIAgentsPersistentClientBuilderExtensions. </summary>
    public static partial class AIAgentsPersistentClientBuilderExtensions
    {
        /// <summary> Registers a PersistentAgentsAdministrationClient. </summary>
        public static global::Azure.Core.Extensions.IAzureClientBuilder<global::Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClient, global::Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions> AddPersistentAgentsAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : global::Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential
            => AgentsPersistentClientBuilderExtensions.AddPersistentAgentsAdministrationClient(builder, endpoint);

        /// <summary> Registers a PersistentAgentsAdministrationClient from configuration. </summary>
        [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static global::Azure.Core.Extensions.IAzureClientBuilder<global::Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClient, global::Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions> AddPersistentAgentsAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : global::Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
            => AgentsPersistentClientBuilderExtensions.AddPersistentAgentsAdministrationClient(builder, configuration);
#pragma warning restore IL2026, IL3050
    }
}

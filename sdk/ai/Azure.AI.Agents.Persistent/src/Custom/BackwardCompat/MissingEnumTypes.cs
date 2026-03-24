// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Agents.Persistent;

// Backward-compat stubs for enum-like types that were removed in the TypeSpec migration.
// These types existed in version 1.0.0 as extensible enums. They are now represented as
// plain strings in the generated code. These stubs preserve binary compatibility.

/// <summary> The type of binding for an Azure Function. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct AzureFunctionBindingType : IEquatable<AzureFunctionBindingType>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="AzureFunctionBindingType"/>. </summary>
    public AzureFunctionBindingType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> StorageQueue. </summary>
    public static AzureFunctionBindingType StorageQueue { get; } = new("storage_queue");

    /// <summary> Converts a string to <see cref="AzureFunctionBindingType"/>. </summary>
    public static implicit operator AzureFunctionBindingType(string value) => new(value);

    /// <summary> Converts a <see cref="AzureFunctionBindingType"/> to a string. </summary>
    public static implicit operator string(AzureFunctionBindingType value) => value._value;

    /// <summary> Determines if two <see cref="AzureFunctionBindingType"/> values are the same. </summary>
    public static bool operator ==(AzureFunctionBindingType left, AzureFunctionBindingType right) => left.Equals(right);

    /// <summary> Determines if two <see cref="AzureFunctionBindingType"/> values are not the same. </summary>
    public static bool operator !=(AzureFunctionBindingType left, AzureFunctionBindingType right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(AzureFunctionBindingType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is AzureFunctionBindingType other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The type of content in a file search tool call. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct FileSearchToolCallContentType : IEquatable<FileSearchToolCallContentType>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="FileSearchToolCallContentType"/>. </summary>
    public FileSearchToolCallContentType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> Text. </summary>
    public static FileSearchToolCallContentType Text { get; } = new("text");

    /// <summary> Converts a string to <see cref="FileSearchToolCallContentType"/>. </summary>
    public static implicit operator FileSearchToolCallContentType(string value) => new(value);

    /// <summary> Converts a <see cref="FileSearchToolCallContentType"/> to a string. </summary>
    public static implicit operator string(FileSearchToolCallContentType value) => value._value;

    /// <summary> Determines if two <see cref="FileSearchToolCallContentType"/> values are the same. </summary>
    public static bool operator ==(FileSearchToolCallContentType left, FileSearchToolCallContentType right) => left.Equals(right);

    /// <summary> Determines if two <see cref="FileSearchToolCallContentType"/> values are not the same. </summary>
    public static bool operator !=(FileSearchToolCallContentType left, FileSearchToolCallContentType right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(FileSearchToolCallContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is FileSearchToolCallContentType other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The object type of a message delta chunk. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct MessageDeltaChunkObject : IEquatable<MessageDeltaChunkObject>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="MessageDeltaChunkObject"/>. </summary>
    public MessageDeltaChunkObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> ThreadMessageDelta. </summary>
    public static MessageDeltaChunkObject ThreadMessageDelta { get; } = new("thread.message.delta");

    /// <summary> Converts a string to <see cref="MessageDeltaChunkObject"/>. </summary>
    public static implicit operator MessageDeltaChunkObject(string value) => new(value);

    /// <summary> Converts a <see cref="MessageDeltaChunkObject"/> to a string. </summary>
    public static implicit operator string(MessageDeltaChunkObject value) => value._value;

    /// <summary> Determines if two <see cref="MessageDeltaChunkObject"/> values are the same. </summary>
    public static bool operator ==(MessageDeltaChunkObject left, MessageDeltaChunkObject right) => left.Equals(right);

    /// <summary> Determines if two <see cref="MessageDeltaChunkObject"/> values are not the same. </summary>
    public static bool operator !=(MessageDeltaChunkObject left, MessageDeltaChunkObject right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(MessageDeltaChunkObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is MessageDeltaChunkObject other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The object type of a persistent agents vector store. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct PersistentAgentsVectorStoreObject : IEquatable<PersistentAgentsVectorStoreObject>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="PersistentAgentsVectorStoreObject"/>. </summary>
    public PersistentAgentsVectorStoreObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> VectorStore. </summary>
    public static PersistentAgentsVectorStoreObject VectorStore { get; } = new("vector_store");

    /// <summary> Converts a string to <see cref="PersistentAgentsVectorStoreObject"/>. </summary>
    public static implicit operator PersistentAgentsVectorStoreObject(string value) => new(value);

    /// <summary> Converts a <see cref="PersistentAgentsVectorStoreObject"/> to a string. </summary>
    public static implicit operator string(PersistentAgentsVectorStoreObject value) => value._value;

    /// <summary> Determines if two <see cref="PersistentAgentsVectorStoreObject"/> values are the same. </summary>
    public static bool operator ==(PersistentAgentsVectorStoreObject left, PersistentAgentsVectorStoreObject right) => left.Equals(right);

    /// <summary> Determines if two <see cref="PersistentAgentsVectorStoreObject"/> values are not the same. </summary>
    public static bool operator !=(PersistentAgentsVectorStoreObject left, PersistentAgentsVectorStoreObject right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(PersistentAgentsVectorStoreObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is PersistentAgentsVectorStoreObject other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The type of a response format JSON schema type. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct ResponseFormatJsonSchemaTypeType : IEquatable<ResponseFormatJsonSchemaTypeType>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="ResponseFormatJsonSchemaTypeType"/>. </summary>
    public ResponseFormatJsonSchemaTypeType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> JsonSchema. </summary>
    public static ResponseFormatJsonSchemaTypeType JsonSchema { get; } = new("json_schema");

    /// <summary> Converts a string to <see cref="ResponseFormatJsonSchemaTypeType"/>. </summary>
    public static implicit operator ResponseFormatJsonSchemaTypeType(string value) => new(value);

    /// <summary> Converts a <see cref="ResponseFormatJsonSchemaTypeType"/> to a string. </summary>
    public static implicit operator string(ResponseFormatJsonSchemaTypeType value) => value._value;

    /// <summary> Determines if two <see cref="ResponseFormatJsonSchemaTypeType"/> values are the same. </summary>
    public static bool operator ==(ResponseFormatJsonSchemaTypeType left, ResponseFormatJsonSchemaTypeType right) => left.Equals(right);

    /// <summary> Determines if two <see cref="ResponseFormatJsonSchemaTypeType"/> values are not the same. </summary>
    public static bool operator !=(ResponseFormatJsonSchemaTypeType left, ResponseFormatJsonSchemaTypeType right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(ResponseFormatJsonSchemaTypeType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is ResponseFormatJsonSchemaTypeType other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The object type of a run step delta chunk. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct RunStepDeltaChunkObject : IEquatable<RunStepDeltaChunkObject>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="RunStepDeltaChunkObject"/>. </summary>
    public RunStepDeltaChunkObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> ThreadRunStepDelta. </summary>
    public static RunStepDeltaChunkObject ThreadRunStepDelta { get; } = new("thread.run.step.delta");

    /// <summary> Converts a string to <see cref="RunStepDeltaChunkObject"/>. </summary>
    public static implicit operator RunStepDeltaChunkObject(string value) => new(value);

    /// <summary> Converts a <see cref="RunStepDeltaChunkObject"/> to a string. </summary>
    public static implicit operator string(RunStepDeltaChunkObject value) => value._value;

    /// <summary> Determines if two <see cref="RunStepDeltaChunkObject"/> values are the same. </summary>
    public static bool operator ==(RunStepDeltaChunkObject left, RunStepDeltaChunkObject right) => left.Equals(right);

    /// <summary> Determines if two <see cref="RunStepDeltaChunkObject"/> values are not the same. </summary>
    public static bool operator !=(RunStepDeltaChunkObject left, RunStepDeltaChunkObject right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(RunStepDeltaChunkObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is RunStepDeltaChunkObject other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The object type of a vector store file batch. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct VectorStoreFileBatchObject : IEquatable<VectorStoreFileBatchObject>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="VectorStoreFileBatchObject"/>. </summary>
    public VectorStoreFileBatchObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> VectorStoreFilesBatch. </summary>
    public static VectorStoreFileBatchObject VectorStoreFilesBatch { get; } = new("vector_store.files_batch");

    /// <summary> Converts a string to <see cref="VectorStoreFileBatchObject"/>. </summary>
    public static implicit operator VectorStoreFileBatchObject(string value) => new(value);

    /// <summary> Converts a <see cref="VectorStoreFileBatchObject"/> to a string. </summary>
    public static implicit operator string(VectorStoreFileBatchObject value) => value._value;

    /// <summary> Determines if two <see cref="VectorStoreFileBatchObject"/> values are the same. </summary>
    public static bool operator ==(VectorStoreFileBatchObject left, VectorStoreFileBatchObject right) => left.Equals(right);

    /// <summary> Determines if two <see cref="VectorStoreFileBatchObject"/> values are not the same. </summary>
    public static bool operator !=(VectorStoreFileBatchObject left, VectorStoreFileBatchObject right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(VectorStoreFileBatchObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is VectorStoreFileBatchObject other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

/// <summary> The object type of a vector store file. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct VectorStoreFileObject : IEquatable<VectorStoreFileObject>
{
    private readonly string _value;

    /// <summary> Initializes a new instance of <see cref="VectorStoreFileObject"/>. </summary>
    public VectorStoreFileObject(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> VectorStoreFile. </summary>
    public static VectorStoreFileObject VectorStoreFile { get; } = new("vector_store.file");

    /// <summary> Converts a string to <see cref="VectorStoreFileObject"/>. </summary>
    public static implicit operator VectorStoreFileObject(string value) => new(value);

    /// <summary> Converts a <see cref="VectorStoreFileObject"/> to a string. </summary>
    public static implicit operator string(VectorStoreFileObject value) => value._value;

    /// <summary> Determines if two <see cref="VectorStoreFileObject"/> values are the same. </summary>
    public static bool operator ==(VectorStoreFileObject left, VectorStoreFileObject right) => left.Equals(right);

    /// <summary> Determines if two <see cref="VectorStoreFileObject"/> values are not the same. </summary>
    public static bool operator !=(VectorStoreFileObject left, VectorStoreFileObject right) => !left.Equals(right);

    /// <inheritdoc/>
    public bool Equals(VectorStoreFileObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is VectorStoreFileObject other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}

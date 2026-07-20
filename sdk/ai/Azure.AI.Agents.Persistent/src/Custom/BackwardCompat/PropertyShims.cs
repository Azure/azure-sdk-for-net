// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shims for property accessors, SerializedAdditionalRawData fields,
// and constructor visibility changes between the old GA 1.0.0 contract and the new
// TypeSpec-generated code.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Agents.Persistent
{
    // ── Property getter shims ─────────────────────────────────────────────────
    // The old contract had properties returning extensible enum struct types
    // (e.g. AzureFunctionBindingType). The new generator emits string properties.
    // CodeGenSuppress removes the generated string property; we restore the
    // enum-typed property for backward compatibility.
    // NOTE: These require code regeneration (dotnet build /t:GenerateCode) to
    // take effect, because CodeGenSuppress only affects future generation runs.

    [CodeGenSuppress("Type")]
    public partial class AzureFunctionBinding
    {
        // Backward-compat: returns AzureFunctionBindingType instead of string.
        // Uses auto-property with internal setter so the generated internal ctor can assign it.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureFunctionBindingType Type { get; internal set; } = AzureFunctionBindingType.StorageQueue;
    }

    [CodeGenSuppress("Type")]
    public partial class FileSearchToolCallContent
    {
        // Backward-compat: returns FileSearchToolCallContentType instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileSearchToolCallContentType Type { get; internal set; } = FileSearchToolCallContentType.Text;
    }

    [CodeGenSuppress("Object")]
    public partial class MessageDeltaChunk
    {
        // Backward-compat: returns MessageDeltaChunkObject instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MessageDeltaChunkObject Object { get; internal set; } = MessageDeltaChunkObject.ThreadMessageDelta;
    }

    [CodeGenSuppress("Object")]
    public partial class PersistentAgentsVectorStore
    {
        // Backward-compat: returns PersistentAgentsVectorStoreObject instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PersistentAgentsVectorStoreObject Object { get; internal set; } = PersistentAgentsVectorStoreObject.VectorStore;
    }

    [CodeGenSuppress("Type")]
    public partial class ResponseFormatJsonSchemaType
    {
        // Backward-compat: returns ResponseFormatJsonSchemaTypeType instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseFormatJsonSchemaTypeType Type { get; internal set; } = ResponseFormatJsonSchemaTypeType.JsonSchema;
    }

    [CodeGenSuppress("Object")]
    public partial class RunStepDeltaChunk
    {
        // Backward-compat: returns RunStepDeltaChunkObject instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RunStepDeltaChunkObject Object { get; internal set; } = RunStepDeltaChunkObject.ThreadRunStepDelta;
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFileBatch
    {
        // Backward-compat: returns VectorStoreFileBatchObject instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileBatchObject Object { get; internal set; } = VectorStoreFileBatchObject.VectorStoreFilesBatch;
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFile
    {
        // Backward-compat: returns VectorStoreFileObject instead of string.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileObject Object { get; internal set; } = VectorStoreFileObject.VectorStoreFile;
    }
}

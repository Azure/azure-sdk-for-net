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

// This file intentionally groups the small backward-compatibility partial declarations for many
// types; splitting them into one file per type would obscure that they are a single cohesive shim.
#pragma warning disable SA1402 // File may only contain a single type

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
        /// <summary> Gets the type of the Azure Function binding. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureFunctionBindingType Type { get; internal set; } = AzureFunctionBindingType.StorageQueue;
    }

    [CodeGenSuppress("Type")]
    public partial class FileSearchToolCallContent
    {
        /// <summary> Gets the type of the file search tool call content. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileSearchToolCallContentType Type { get; internal set; } = FileSearchToolCallContentType.Text;
    }

    [CodeGenSuppress("Object")]
    public partial class MessageDeltaChunk
    {
        /// <summary> Gets the object type of the message delta chunk. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MessageDeltaChunkObject Object { get; internal set; } = MessageDeltaChunkObject.ThreadMessageDelta;
    }

    [CodeGenSuppress("Object")]
    public partial class PersistentAgentsVectorStore
    {
        /// <summary> Gets the object type of the vector store. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PersistentAgentsVectorStoreObject Object { get; internal set; } = PersistentAgentsVectorStoreObject.VectorStore;
    }

    [CodeGenSuppress("Type")]
    public partial class ResponseFormatJsonSchemaType
    {
        /// <summary> Gets the response format type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseFormatJsonSchemaTypeType Type { get; internal set; } = ResponseFormatJsonSchemaTypeType.JsonSchema;
    }

    [CodeGenSuppress("Object")]
    public partial class RunStepDeltaChunk
    {
        /// <summary> Gets the object type of the run step delta chunk. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RunStepDeltaChunkObject Object { get; internal set; } = RunStepDeltaChunkObject.ThreadRunStepDelta;
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFileBatch
    {
        /// <summary> Gets the object type of the vector store file batch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileBatchObject Object { get; internal set; } = VectorStoreFileBatchObject.VectorStoreFilesBatch;
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFile
    {
        /// <summary> Gets the object type of the vector store file. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileObject Object { get; internal set; } = VectorStoreFileObject.VectorStoreFile;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("Type")]
    public partial class FileSearchToolCallContent
    {
        /// <summary> The type of the content. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileSearchToolCallContentType Type { get; } = new FileSearchToolCallContentType("text");
    }

    [CodeGenSuppress("Object")]
    public partial class MessageDeltaChunk
    {
        /// <summary> The object type, which is always `thread.message.delta`. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MessageDeltaChunkObject Object { get; } = new MessageDeltaChunkObject("thread.message.delta");
    }

    [CodeGenSuppress("Object")]
    public partial class PersistentAgentsVectorStore
    {
        /// <summary> The object type, which is always `vector_store`. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PersistentAgentsVectorStoreObject Object { get; } = new PersistentAgentsVectorStoreObject("vector_store");
    }

    [CodeGenSuppress("Type")]
    public partial class ResponseFormatJsonSchemaType
    {
        /// <summary> Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResponseFormatJsonSchemaTypeType Type { get; } = new ResponseFormatJsonSchemaTypeType("json_schema");
    }

    [CodeGenSuppress("Object")]
    public partial class RunStepDeltaChunk
    {
        /// <summary> The object type, which is always `thread.run.step.delta`. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RunStepDeltaChunkObject Object { get; } = new RunStepDeltaChunkObject("thread.run.step.delta");
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFile
    {
        /// <summary> The object type, which is always `vector_store.file`. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileObject Object { get; } = new VectorStoreFileObject("vector_store.file");
    }

    [CodeGenSuppress("Object")]
    public partial class VectorStoreFileBatch
    {
        /// <summary> The object type, which is always `vector_store.files_batch`. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VectorStoreFileBatchObject Object { get; } = new VectorStoreFileBatchObject("vector_store.files_batch");
    }
}

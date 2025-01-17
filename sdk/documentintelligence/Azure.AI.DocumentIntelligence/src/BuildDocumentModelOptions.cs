// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.DocumentIntelligence
{
    public partial class BuildDocumentModelOptions
    {
        // CUSTOM CODE NOTE: since either BlobSource or BlobFileListSource must be specified
        // when building this object, we're hiding its generated constructor, adding custom
        // constructors, and making both properties readonly.

        /// <summary> Initializes a new instance of <see cref="BuildDocumentModelOptions"/>. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="buildMode"> Custom document model build mode. </param>
        /// <param name="blobSource"> Azure Blob Storage location containing the training data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="blobSource"/> is null. </exception>
        public BuildDocumentModelOptions(string modelId, DocumentBuildMode buildMode, BlobContentSource blobSource) : this(modelId, buildMode)
        {
            Argument.AssertNotNull(blobSource, nameof(blobSource));

            BlobSource = blobSource;
        }

        /// <summary> Initializes a new instance of <see cref="BuildDocumentModelOptions"/>. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="buildMode"> Custom document model build mode. </param>
        /// <param name="blobFileListSource"> Azure Blob Storage file list specifying the training data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="blobFileListSource"/> is null. </exception>
        public BuildDocumentModelOptions(string modelId, DocumentBuildMode buildMode, BlobFileListContentSource blobFileListSource) : this(modelId, buildMode)
        {
            Argument.AssertNotNull(blobFileListSource, nameof(blobFileListSource));

            BlobFileListSource = blobFileListSource;
        }

        internal BuildDocumentModelOptions(string modelId, DocumentBuildMode buildMode)
        {
            Argument.AssertNotNull(modelId, nameof(modelId));

            ModelId = modelId;
            BuildMode = buildMode;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary>
        /// Azure Blob Storage location containing the training data.
        /// </summary>
        public BlobContentSource BlobSource { get; }

        /// <summary>
        /// Azure Blob Storage file list specifying the training data.
        /// </summary>
        public BlobFileListContentSource BlobFileListSource { get; }
    }
}

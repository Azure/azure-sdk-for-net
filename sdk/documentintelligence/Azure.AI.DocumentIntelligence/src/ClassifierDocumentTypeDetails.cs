// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.DocumentIntelligence
{
    public partial class ClassifierDocumentTypeDetails
    {
        // CUSTOM CODE NOTE: since either BlobSource or BlobFileListSource must be specified
        // when building this object, we're hiding its generated constructor, adding custom
        // constructors, and making both properties readonly.

        /// <summary> Initializes a new instance of <see cref="ClassifierDocumentTypeDetails"/>. </summary>
        /// <param name="blobSource"> Azure Blob Storage location containing the training data for a classifier document type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobSource"/> is null. </exception>
        public ClassifierDocumentTypeDetails(BlobContentSource blobSource)
        {
            Argument.AssertNotNull(blobSource, nameof(blobSource));

            BlobSource = blobSource;
        }

        /// <summary> Initializes a new instance of <see cref="ClassifierDocumentTypeDetails"/>. </summary>
        /// <param name="blobFileListSource"> Azure Blob Storage file list specifying the training data for a classifier document type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobFileListSource"/> is null. </exception>
        public ClassifierDocumentTypeDetails(BlobFileListContentSource blobFileListSource)
        {
            Argument.AssertNotNull(blobFileListSource, nameof(blobFileListSource));

            BlobFileListSource = blobFileListSource;
        }

        /// <summary> Initializes a new instance of <see cref="ClassifierDocumentTypeDetails"/>. </summary>
        internal ClassifierDocumentTypeDetails()
        {
        }

        /// <summary>
        /// Azure Blob Storage location containing the training data for a classifier
        /// document type.
        /// </summary>
        public BlobContentSource BlobSource { get; }

        /// <summary>
        /// Azure Blob Storage file list specifying the training data for a classifier
        /// document type.
        /// </summary>
        public BlobFileListContentSource BlobFileListSource { get; }
    }
}

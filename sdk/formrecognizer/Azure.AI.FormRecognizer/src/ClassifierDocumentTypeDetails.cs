// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class ClassifierDocumentTypeDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifierDocumentTypeDetails"/> class.
        /// </summary>
        /// <param name="trainingDataContentSource">The location containing the training data. See <see cref="ContentSource"/> for more details.</param>
        public ClassifierDocumentTypeDetails(ContentSource trainingDataContentSource)
        {
            Argument.AssertNotNull(trainingDataContentSource, nameof(trainingDataContentSource));

            TrainingDataContentSource = trainingDataContentSource;

            switch (trainingDataContentSource)
            {
                case BlobContentSource blobSource:
                    AzureBlobSource = blobSource;
                    break;
                case BlobFileListContentSource blobFileListSource:
                    AzureBlobFileListSource = blobFileListSource;
                    break;
                default:
                    throw new ArgumentException("Unsupported training data content source.", nameof(trainingDataContentSource));
            }
        }

        /// <summary> Initializes a new instance of ClassifierDocumentTypeDetails. </summary>
        /// <param name="azureBlobSource"> Azure Blob Storage location containing the training data for a classifier document type.  Either azureBlobSource or azureBlobFileListSource must be specified. </param>
        /// <param name="azureBlobFileListSource"> Azure Blob Storage file list specifying the training data for a classifier document type.  Either azureBlobSource or azureBlobFileListSource must be specified. </param>
        internal ClassifierDocumentTypeDetails(BlobContentSource azureBlobSource, BlobFileListContentSource azureBlobFileListSource)
        {
            AzureBlobSource = azureBlobSource;
            AzureBlobFileListSource = azureBlobFileListSource;
            TrainingDataContentSource = (ContentSource) azureBlobSource ?? azureBlobFileListSource;
        }

        private ClassifierDocumentTypeDetails()
        {
        }

        /// <summary>
        /// The location containing the training data.
        /// </summary>
        public ContentSource TrainingDataContentSource { get; }

        /// <summary>
        /// The Azure Blob Storage location containing the training data.
        /// </summary>
        private BlobContentSource AzureBlobSource { get; }

        /// <summary>
        /// The Azure Blob Storage file list specifying the training data.
        /// </summary>
        private BlobFileListContentSource AzureBlobFileListSource { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class ClassifierDocumentTypeDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifierDocumentTypeDetails"/> class.
        /// </summary>
        /// <param name="azureBlobSource">The Azure Blob Storage location containing the training data.</param>
        public ClassifierDocumentTypeDetails(AzureBlobContentSource azureBlobSource)
        {
            Argument.AssertNotNull(azureBlobSource, nameof(azureBlobSource));

            AzureBlobSource = azureBlobSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifierDocumentTypeDetails"/> class.
        /// </summary>
        /// <param name="azureBlobFileListSource">The Azure Blob Storage file list specifying the training data.</param>
        public ClassifierDocumentTypeDetails(AzureBlobFileListSource azureBlobFileListSource)
        {
            Argument.AssertNotNull(azureBlobFileListSource, nameof(azureBlobFileListSource));

            AzureBlobFileListSource = azureBlobFileListSource;
        }

        private ClassifierDocumentTypeDetails()
        {
        }

        /// <summary>
        /// The Azure Blob Storage location containing the training data.
        /// </summary>
        public AzureBlobContentSource AzureBlobSource { get; }

        /// <summary>
        /// The Azure Blob Storage file list specifying the training data.
        /// </summary>
        public AzureBlobFileListSource AzureBlobFileListSource { get; }
    }
}

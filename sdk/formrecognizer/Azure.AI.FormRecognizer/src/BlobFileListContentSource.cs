// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("AzureBlobFileListContentSource")]
    public partial class BlobFileListContentSource : DocumentContentSource
    {
        /// <summary> Initializes a new instance of BlobFileListContentSource. </summary>
        /// <param name="containerUri"> Azure Blob Storage container URL. </param>
        /// <param name="fileList"> Path to a JSONL file within the container specifying a subset of documents for training. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerUri"/> or <paramref name="fileList"/> is null. </exception>
        public BlobFileListContentSource(Uri containerUri, string fileList)
            : base(DocumentContentSourceKind.BlobFileList)
        {
            Argument.AssertNotNull(containerUri, nameof(containerUri));
            Argument.AssertNotNull(fileList, nameof(fileList));

            ContainerUri = containerUri;
            FileList = fileList;
        }

        /// <summary>
        /// The Azure Blob Storage container URI.
        /// </summary>
        [CodeGenMember("ContainerUrl")]
        public Uri ContainerUri { get; }

        /// <summary>
        /// The Path to the JSONL file within the container specifying a subset of documents for training.
        /// </summary>
        public string FileList { get; }
    }
}

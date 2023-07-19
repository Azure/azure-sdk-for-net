// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class AzureBlobFileListSource
    {
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

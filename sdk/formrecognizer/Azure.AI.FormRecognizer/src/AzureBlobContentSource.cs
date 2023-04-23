// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class AzureBlobContentSource
    {
        /// <summary>
        /// The Azure Blob Storage container URI.
        /// </summary>
        [CodeGenMember("ContainerUrl")]
        public Uri ContainerUri { get; }
    }
}

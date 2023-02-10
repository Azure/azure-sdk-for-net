// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    internal partial class AzureBlobContentSource
    {
        /// <summary> Azure Blob Storage container URL. </summary>
        public string ContainerUrl { get; }
    }
}

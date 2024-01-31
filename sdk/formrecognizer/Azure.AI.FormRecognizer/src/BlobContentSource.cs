// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("AzureBlobContentSource")]
    public partial class BlobContentSource : DocumentContentSource
    {
        /// <summary> Initializes a new instance of BlobContentSource. </summary>
        /// <param name="containerUri"> Azure Blob Storage container URL. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerUri"/> is null. </exception>
        public BlobContentSource(Uri containerUri)
            : base(DocumentContentSourceKind.Blob)
        {
            Argument.AssertNotNull(containerUri, nameof(containerUri));

            ContainerUri = containerUri;
        }

        /// <summary> Initializes a new instance of BlobContentSource. </summary>
        /// <param name="containerUri"> Azure Blob Storage container URL. </param>
        /// <param name="prefix"> Blob name prefix. </param>
        internal BlobContentSource(Uri containerUri, string prefix)
            : base(DocumentContentSourceKind.Blob)
        {
            ContainerUri = containerUri;
            Prefix = prefix;
        }

        /// <summary>
        /// The Azure Blob Storage container URI.
        /// </summary>
        [CodeGenMember("ContainerUrl")]
        public Uri ContainerUri { get; }
    }
}

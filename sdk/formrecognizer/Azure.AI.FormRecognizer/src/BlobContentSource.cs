// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BlobContentSource(Uri containerUri, string prefix, IDictionary<string, BinaryData> serializedAdditionalRawData)
            : base(DocumentContentSourceKind.Blob)
        {
            ContainerUri = containerUri;
            Prefix = prefix;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The Azure Blob Storage container URI.
        /// </summary>
        [CodeGenMember("ContainerUrl")]
        public Uri ContainerUri { get; }
    }
}

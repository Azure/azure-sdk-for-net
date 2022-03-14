// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Defines the properties of the Blob Transfer Job
    /// </summary>
    public class BlobTransferJobProperties
    {
        /// <summary>
        /// Constructor internal.
        /// </summary>
        internal BlobTransferJobProperties(){ }

        /// <summary>
        /// Job Id. Guid.
        /// </summary>
        public string JobId { get; internal set; }

        /// <summary>
        /// Defines the type of transfer the job is performing.
        /// </summary>
        public BlobTransferType TransferType { get; internal set; }

        /// <summary>
        /// Source Uri single transfers.
        /// </summary>
        public Uri SourcePath { get; internal set; }

        /// <summary>
        /// Gets the local path which will store the contents for a single blob to be downloaded.
        /// </summary>
        public Uri DestinationUri { get; internal set; }
    }
}

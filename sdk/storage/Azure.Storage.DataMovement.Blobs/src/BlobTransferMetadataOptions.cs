// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    ///  Represents the options for transferring metadata from the source to the destination storage resource.
    /// </summary>
    public class BlobTransferMetadataOptions
    {
        internal Metadata _metadata;
        internal bool _preserve;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected BlobTransferMetadataOptions()
        {
        }

        /// <summary>
        /// Specifies whether to preserve the metadata from the source to the destination
        /// storage resource, if the source and destination supports metadata.
        /// </summary>
        /// <param name="preserve">Defines whether the preserve the metadata. True to preserve, false to not.</param>
        public BlobTransferMetadataOptions(bool preserve)
        {
            _preserve = preserve;
            _metadata = default;
        }

        /// <summary>
        /// Specifies the custom metadata to set on the destination
        /// storage resource, if destination supports metadata.
        /// </summary>
        /// <param name="metadata">The metadata to set on the destination storage resource.</param>
        public BlobTransferMetadataOptions(Metadata metadata)
        {
            _preserve = false;
            _metadata = metadata;
        }
    }
}

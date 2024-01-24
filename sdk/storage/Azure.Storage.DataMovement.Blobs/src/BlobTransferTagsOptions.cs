// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    ///  Represents the options for transferring tags from the source to the destination storage resource.
    /// </summary>
    public class BlobTransferTagsOptions
    {
        internal Tags _tags;
        internal bool _preserve;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected BlobTransferTagsOptions()
        {
        }

        /// <summary>
        /// Specifies whether to preserve the tags from the source to the destination
        /// storage resource, if the source and destination supports tags.
        /// </summary>
        /// <param name="preserve">Defines whether the preserve the tags. True to preserve, false to not.</param>
        public BlobTransferTagsOptions(bool preserve)
        {
            _preserve = preserve;
            _tags = default;
        }

        /// <summary>
        /// Specifies the custom tags to set on the destination
        /// storage resource, if destination supports tags.
        /// </summary>
        /// <param name="tags">The tags to set on the destination storage resource.</param>
        public BlobTransferTagsOptions(Tags tags)
        {
            _preserve = false;
            _tags = tags;
        }
    }
}

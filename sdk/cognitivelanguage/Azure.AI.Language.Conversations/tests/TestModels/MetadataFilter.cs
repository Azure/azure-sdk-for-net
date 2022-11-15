// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Find QnAs that are associated with the given list of metadata. </summary>
    public partial class MetadataFilter
    {
        /// <summary> Initializes a new instance of MetadataFilter. </summary>
        public MetadataFilter()
        {
            Metadata = new ChangeTrackingList<MetadataRecord>();
        }

        /// <summary> Gets the metadata. </summary>
        public IList<MetadataRecord> Metadata { get; }
        /// <summary> Operation used to join metadata filters. </summary>
        public LogicalOperationKind? LogicalOperation { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.QuestionAnswering.Models
{
    public partial class UpdateMetadata
    {
        /// <summary>
        /// List of Metadata associated with answer to be deleted.
        /// </summary>
        [CodeGenMember("Delete")]
        internal IList<MetadataDTO> InternalDelete { get; }

        /// <summary>
        /// List of metadata associated with answer to be added.
        /// </summary>
        [CodeGenMember("Add")]
        internal IList<MetadataDTO> InternalAdd { get; }

        /// <summary>
        /// Gets a dictionary of metadata to add.
        /// </summary>
        public IDictionary<string, string> Add { get; } // TODO: Implement wrapper over InternalAdd.

        /// <summary>
        /// Gets a dictionary of metadata to delete.
        /// </summary>
        public IDictionary<string, string> Delete { get; } // TODO: Implement wrapper over InternalDelete; also, can this just be a list of names?
    }
}

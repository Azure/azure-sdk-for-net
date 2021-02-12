// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueSignedIdentifier.
    /// </summary>
    [CodeGenModel("SignedIdentifier")]
    public partial class QueueSignedIdentifier
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public QueueSignedIdentifier() { }

        internal QueueSignedIdentifier(string id, QueueAccessPolicy accessPolicy)
        {
            Id = id;
            AccessPolicy = accessPolicy;
        }
    }
}

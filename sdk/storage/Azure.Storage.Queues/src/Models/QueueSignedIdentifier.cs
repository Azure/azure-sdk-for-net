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
        internal QueueSignedIdentifier(string id, QueueAccessPolicy accessPolicy)
        {
            Id = id;
            AccessPolicy = accessPolicy;
        }

        /// <summary>
        /// Creates a new QueueSignedIdentifier instance.
        /// </summary>
        public QueueSignedIdentifier()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueSignedIdentifier instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueSignedIdentifier(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                AccessPolicy = new Azure.Storage.Queues.Models.QueueAccessPolicy();
            }
        }
    }
}

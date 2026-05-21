// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.DataMigration.Models
{
    public abstract partial class DataMigrationMongoDBProgress
    {
        /// <summary> Backward-compatible protected constructor for ApiCompat. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected DataMigrationMongoDBProgress(long bytesCopied, long documentsCopied, string elapsedTime, IReadOnlyDictionary<string, DataMigrationMongoDBError> errors, long eventsPending, long eventsReplayed, DataMigrationMongoDBMigrationState state, long totalBytes, long totalDocuments)
            : this(bytesCopied, documentsCopied, elapsedTime, errors, eventsPending, eventsReplayed, default, default, default, default, default, state, totalBytes, totalDocuments, null)
        {
        }
    }
}

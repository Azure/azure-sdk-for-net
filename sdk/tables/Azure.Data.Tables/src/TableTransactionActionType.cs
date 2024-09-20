// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The type of operation to be executed on a table entity as part of a table transactional batch operations.
    /// </summary>
    public enum TableTransactionActionType
    {
        /// <summary>
        /// Add the entity to the table. This is equivalent to <see cref="TableClient.AddEntity{T}"/>.
        /// </summary>
        Add,
        /// <summary>
        /// Update the entity in <see cref="TableUpdateMode.Merge"/> mode. This is equivalent to <see cref="TableClient.UpdateEntity{T}"/>
        /// </summary>
        UpdateMerge,
        /// <summary>
        /// Update the entity in <see cref="TableUpdateMode.Replace"/> mode. This is equivalent to <see cref="TableClient.UpdateEntity{T}"/>
        /// </summary>
        UpdateReplace,
        /// <summary>
        /// Delete the entity. This is equivalent to <see cref="TableClient.DeleteEntity(string, string, ETag, CancellationToken)"/>
        /// </summary>
        Delete,
        /// <summary>
        /// Upsert the entity in <see cref="TableUpdateMode.Merge"/> mode. This is equivalent to <see cref="TableClient.UpsertEntity{T}"/>
        /// </summary>
        UpsertMerge,
        /// <summary>
        /// Upsert the entity in <see cref="TableUpdateMode.Replace"/> mode. This is equivalent to <see cref="TableClient.UpsertEntity{T}"/>
        /// </summary>
        UpsertReplace
    }
}

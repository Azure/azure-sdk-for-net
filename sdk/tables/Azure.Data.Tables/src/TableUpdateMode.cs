// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    /// <summary>
    /// Defines the behavior of <see cref="TableClient.UpdateEntity{T}(T, ETag, TableUpdateMode, System.Threading.CancellationToken)"/>, \
    /// <see cref="TableClient.UpdateEntityAsync{T}(T, ETag, TableUpdateMode, System.Threading.CancellationToken)"/>,
    /// <see cref="TableClient.UpsertEntity{T}(T, TableUpdateMode, System.Threading.CancellationToken)"/>, and
    /// <see cref="TableClient.UpsertEntityAsync{T}(T, TableUpdateMode, System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <remarks>
    /// To expand on the behavior of the modes, consider a scenario where the table already contains an entity with 2 user defined properties named "Price" and "Description"
    /// and the entity passed to the method only defines the "Price" property.
    /// If the <see cref="TableUpdateMode.Replace"/> mode is specified, the entity will be replaced with the specified version containing only the "Price" property.
    /// We have effectively updated the "Price" property and removed the "Description" property.
    /// If the <see cref="TableUpdateMode.Merge"/> mode is specified, the existing entity is merged with the properties defined in entity passed to the method.
    /// In this case, we have effectively updated the "Price" property and left the "Description" property unchanged.
    /// </remarks>
    public enum TableUpdateMode
    {
        /// <summary>
        /// Merge the properties of the supplied entity with the entity in the table.
        /// </summary>
        Merge = 0,

        /// <summary>
        /// Replace the entity in the table with the supplied entity.
        /// </summary>
        Replace = 1
    }
}

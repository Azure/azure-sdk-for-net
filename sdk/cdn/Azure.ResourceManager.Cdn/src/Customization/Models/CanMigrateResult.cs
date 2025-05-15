// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CanMigrateResult
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id => ResourceId?.ToString();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal CanMigrateResult
            (
                string id = null,
                string canMigrateResultType = null,
                bool? canMigrate = default,
                CanMigrateDefaultSku? defaultSku = default,
                System.Collections.Generic.IEnumerable<MigrationErrorType> errors = null
            ) :
            this
            (
                new ResourceIdentifier(id),
                canMigrateResultType,
                canMigrate,
                defaultSku,
                (System.Collections.Generic.IReadOnlyList<MigrationErrorType>)errors,
                null
            )
        {
        }
    }
}

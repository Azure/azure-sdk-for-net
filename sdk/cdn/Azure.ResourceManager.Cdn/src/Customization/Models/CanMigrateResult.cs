// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CanMigrateResult
    {
        /// <summary>
        /// Initializes a new instance of CanMigrateResult.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CanMigrateResult(
            string id = null,
            string canMigrateResultType = null,
            bool? canMigrate = default,
            CanMigrateDefaultSku? defaultSku = default,
            System.Collections.Generic.IEnumerable<MigrationErrorType> errors = null)
        {
            Id = id != null ? new ResourceIdentifier(id) : null;
            CanMigrateResultType = canMigrateResultType;
            CanMigrate = canMigrate;
            DefaultSku = defaultSku;
            Errors = (System.Collections.Generic.IReadOnlyList<MigrationErrorType>)errors;
        }
    }
}

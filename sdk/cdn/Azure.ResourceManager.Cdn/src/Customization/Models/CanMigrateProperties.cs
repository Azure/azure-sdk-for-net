// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Cdn.Models
{
    internal partial class CanMigrateProperties
    {
        /// <summary> Gets the Errors. </summary>
        [WirePath("errors")]
        public IReadOnlyList<MigrationErrorType> Errors { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.Collections.Generic;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: the GA contract exposed OutputErrors as IReadOnlyList,
    // but the generator now emits IList. Override to preserve the GA return type.
    public partial class MigrateMISyncCompleteCommandProperties
    {
        public IReadOnlyList<DataMigrationReportableException> OutputErrors => Output?.Errors as IReadOnlyList<DataMigrationReportableException>;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves previous IReadOnlyList validation detail properties.
    [CodeGenSuppress("ServerLevelValidationDetails")]
    [CodeGenSuppress("DbLevelValidationDetails")]
    public partial class PostgreSqlFlexibleServersValidationDetails
    {
        /// <summary> Details of server level validations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("serverLevelValidationDetails")]
        public IReadOnlyList<ValidationSummaryItem> ServerLevelValidationDetails
        {
            get => (IReadOnlyList<ValidationSummaryItem>)ServerLevelValidationDetailsInternal;
        }

        [CodeGenMember("ServerLevelValidationDetails")]
        internal IList<ValidationSummaryItem> ServerLevelValidationDetailsInternal { get; }

        /// <summary> Details of database level validations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dbLevelValidationDetails")]
        public IReadOnlyList<DbLevelValidationStatus> DbLevelValidationDetails
        {
            get => (IReadOnlyList<DbLevelValidationStatus>)DbLevelValidationDetailsInternal;
        }

        [CodeGenMember("DbLevelValidationDetails")]
        internal IList<DbLevelValidationStatus> DbLevelValidationDetailsInternal { get; }
    }
}

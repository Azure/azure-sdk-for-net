// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserves the previous parameterless constructor while suppressing the generated required-parameter constructor.
    [CodeGenSuppress("PostgreSqlFlexibleServerMicrosoftEntraAdministratorData")]
    public partial class PostgreSqlFlexibleServerMicrosoftEntraAdministratorData
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerMicrosoftEntraAdministratorData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerMicrosoftEntraAdministratorData()
        {
        }
    }
}

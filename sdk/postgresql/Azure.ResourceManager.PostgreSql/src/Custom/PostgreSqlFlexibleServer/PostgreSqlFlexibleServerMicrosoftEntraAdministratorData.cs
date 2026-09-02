// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // TODO: Remove this shim after https://github.com/Azure/azure-sdk-for-net/pull/58867 is available in the generator.
    // It preserves the previous parameterless constructor while suppressing the generated required-parameter constructor.
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

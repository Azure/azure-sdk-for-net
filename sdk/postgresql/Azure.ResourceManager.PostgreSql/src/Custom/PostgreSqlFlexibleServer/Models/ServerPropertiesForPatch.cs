// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("AdministratorLogin")]
    internal partial class ServerPropertiesForPatch
    {
        /// <summary> Name of the login designated as the first password based administrator. </summary>
        [WirePath("administratorLogin")]
        public string AdministratorLogin { get; set; }
    }
}

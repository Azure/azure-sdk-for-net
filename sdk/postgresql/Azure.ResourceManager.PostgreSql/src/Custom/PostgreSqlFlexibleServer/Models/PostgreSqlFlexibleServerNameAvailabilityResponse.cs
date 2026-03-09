// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("Reason")]
    public partial class PostgreSqlFlexibleServerNameAvailabilityResponse
    {
        /// <summary> The reason why the given name is not available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("reason")]
        public PostgreSqlFlexibleServerNameUnavailableReason? Reason { get; private set; }
    }
}

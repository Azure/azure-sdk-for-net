// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("UserAssignedIdentities")]
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        /// <summary> Represents user assigned identities map. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("userAssignedIdentities")]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities
        {
            get
            {
                if (UserAssignedIdentitiesInternal is null)
                    return null;
                return UserAssignedIdentitiesInternal.ToDictionary(
                    kvp => kvp.Key,
                    kvp => new UserAssignedIdentity());
            }
        }

        internal IDictionary<string, UserIdentity> UserAssignedIdentitiesInternal { get; }
    }
}

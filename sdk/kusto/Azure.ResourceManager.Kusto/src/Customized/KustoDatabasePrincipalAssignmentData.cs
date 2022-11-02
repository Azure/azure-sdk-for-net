// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto
{
    /// <summary> A class representing the KustoDatabasePrincipalAssignment data model. </summary>
    public partial class KustoDatabasePrincipalAssignmentData : ResourceData
    {
        /// <summary> The principal ID assigned to the database principal. It should be a Guid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use DatabasePrincipalId instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? PrincipalId {
            get
            {
                if (DatabasePrincipalId != null && Guid.TryParse(DatabasePrincipalId, out var principalId))
                    return principalId;
                return null;
            }
            set
            {
                DatabasePrincipalId = value == null ? null : value.ToString();
            }
        }
    }
}

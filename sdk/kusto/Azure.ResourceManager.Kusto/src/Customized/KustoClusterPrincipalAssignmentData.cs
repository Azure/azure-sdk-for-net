// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto
{
    /// <summary> A class representing the KustoClusterPrincipalAssignment data model. </summary>
    public partial class KustoClusterPrincipalAssignmentData : ResourceData
    {
        /// <summary> The principal ID assigned to the cluster principal. It should be a Guid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use ClusterPrincipalId instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? PrincipalId
        {
            get
            {
                if (ClusterPrincipalId != null && Guid.TryParse(ClusterPrincipalId, out var principalId))
                    return principalId;
                return null;
            }
            set
            {
                ClusterPrincipalId = value == null ? null : value.ToString();
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> CloudExadataInfrastructure resource model. </summary>
    public partial class CloudExadataInfrastructureProperties
    {
        /// <summary> Exadata infra ocid. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(ExadataInfraOcid); }
        /// <summary> The OCID of the last maintenance run. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier LastMaintenanceRunId { get => new ResourceIdentifier(LastMaintenanceRunOcid); }
        /// <summary> The OCID of the next maintenance run. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier NextMaintenanceRunId { get => new ResourceIdentifier(NextMaintenanceRunOcid); }
    }
}

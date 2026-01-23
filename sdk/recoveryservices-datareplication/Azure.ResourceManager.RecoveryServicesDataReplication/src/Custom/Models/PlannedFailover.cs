// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Models
{
    // NOTE: The following customization is intentionally retained for backward compatibility
    public partial class PlannedFailover
    {
        /// <summary> Initializes a new instance of <see cref="PlannedFailover"/>. </summary>
        /// <param name="properties"> Planned failover model properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public PlannedFailover(PlannedFailoverProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }
    }
}

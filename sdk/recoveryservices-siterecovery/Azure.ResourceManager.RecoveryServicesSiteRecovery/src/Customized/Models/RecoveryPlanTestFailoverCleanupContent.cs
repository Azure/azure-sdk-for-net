// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class RecoveryPlanTestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryPlanTestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Recovery plan test failover cleanup input properties. </param>
        public RecoveryPlanTestFailoverCleanupContent(RecoveryPlanTestFailoverCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}

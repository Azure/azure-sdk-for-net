// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct SqlReplicaSynchronizationHealth
    {
        /// <summary> HEALTHY. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static SqlReplicaSynchronizationHealth Healthy => HEALTHY;

        /// <summary> NOT_HEALTHY. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static SqlReplicaSynchronizationHealth NotHealthy => NOTHEALTHY;

        /// <summary> PARTIALLY_HEALTHY. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static SqlReplicaSynchronizationHealth PartiallyHealthy => PARTIALLYHEALTHY;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct SqlReplicaConnectedState
    {
        /// <summary> CONNECTED. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static SqlReplicaConnectedState Connected => CONNECTED;

        /// <summary> DISCONNECTED. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static SqlReplicaConnectedState Disconnected => DISCONNECTED;
    }
}

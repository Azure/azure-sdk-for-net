// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct ReplicationLinkType
    {
        /// <summary> GEO. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ReplicationLinkType Geo => GEO;

        /// <summary> NAMED. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ReplicationLinkType Named => NAMED;

        /// <summary> STANDBY. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ReplicationLinkType Standby => STANDBY;
    }
}

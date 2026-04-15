// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct NetAppApplicationType
    {
        /// <summary> SAP-HANA. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppApplicationType SapHana { get; } = SAPHANA;

        /// <summary> Oracle. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppApplicationType Oracle { get; } = ORACLE;
    }
}

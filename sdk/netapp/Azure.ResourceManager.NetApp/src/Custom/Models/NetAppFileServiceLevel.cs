// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct NetAppFileServiceLevel
    {
        /// <summary> Zone-redundant storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppFileServiceLevel StandardZrs { get; } = StandardZRS;
    }
}

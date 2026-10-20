// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct IPsecIntegrity
    {
        // SHA384 was a custom compatibility value in 1.15.0; the current schema omits it.
        /// <summary> SHA384. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility value is not defined by the current service schema.")]
        public static IPsecIntegrity Sha384 { get; } = new IPsecIntegrity("SHA384");
    }
}

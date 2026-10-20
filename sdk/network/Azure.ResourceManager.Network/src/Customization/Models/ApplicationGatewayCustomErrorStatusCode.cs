// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ApplicationGatewayCustomErrorStatusCode
    {
        // Shipped in 1.15.0, but not a value in the current service schema.
        /// <summary> HttpStatus499. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This status is obsolete and will be removed in a future release", false)]
        public static ApplicationGatewayCustomErrorStatusCode HttpStatus499 { get; } = new ApplicationGatewayCustomErrorStatusCode("HttpStatus499");
    }
}

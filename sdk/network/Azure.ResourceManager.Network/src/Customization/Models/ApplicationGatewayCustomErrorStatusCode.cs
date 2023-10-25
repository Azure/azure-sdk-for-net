// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Status code of the application gateway custom error. </summary>
    public readonly partial struct ApplicationGatewayCustomErrorStatusCode : IEquatable<ApplicationGatewayCustomErrorStatusCode>
    {
        private const string HttpStatus499Value = "HttpStatus499";

        /// <summary> HttpStatus499. </summary>
        [Obsolete("This status is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ApplicationGatewayCustomErrorStatusCode HttpStatus499 { get; } = new ApplicationGatewayCustomErrorStatusCode(HttpStatus499Value);
    }
}

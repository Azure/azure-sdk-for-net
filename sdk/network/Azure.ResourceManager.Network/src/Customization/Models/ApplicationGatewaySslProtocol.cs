// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewaySslProtocol type. </summary>
    public readonly partial struct ApplicationGatewaySslProtocol
    {
        /// <inheritdoc cref="Tls1_0"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Tls1_0 instead.")]
        public static ApplicationGatewaySslProtocol TLSv10 => Tls1_0;

        /// <inheritdoc cref="Tls1_1"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Tls1_1 instead.")]
        public static ApplicationGatewaySslProtocol TLSv11 => Tls1_1;

        /// <inheritdoc cref="Tls1_2"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Tls1_2 instead.")]
        public static ApplicationGatewaySslProtocol TLSv12 => Tls1_2;

        /// <inheritdoc cref="Tls1_3"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Tls1_3 instead.")]
        public static ApplicationGatewaySslProtocol TLSv13 => Tls1_3;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ApplicationGatewaySslProtocol
    {
        /// <inheritdoc cref="Tls1_3"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Tls1_3 instead.")]
        public static ApplicationGatewaySslProtocol TLSv13 => Tls1_3;
    }
}

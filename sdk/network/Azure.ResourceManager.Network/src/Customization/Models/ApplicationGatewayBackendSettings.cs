// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Backend settings of an application gateway. </summary>
    public partial class ApplicationGatewayBackendSettings
    {
        // Preserve the previous acronym spelling as an alias of the preferred generated property.
        /// <inheritdoc cref="IsL4ClientIPPreservationEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsL4ClientIPPreservationEnabled instead.")]
        public bool? EnableL4ClientIpPreservation
        {
            get => IsL4ClientIPPreservationEnabled;
            set => IsL4ClientIPPreservationEnabled = value;
        }

        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="IsL4ClientIPPreservationEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsL4ClientIPPreservationEnabled instead.")]
        public bool? EnableL4ClientIPPreservation
        {
            get => IsL4ClientIPPreservationEnabled;
            set => IsL4ClientIPPreservationEnabled = value;
        }

        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="TimeoutInSeconds"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use TimeoutInSeconds instead.")]
        public int? Timeout
        {
            get => TimeoutInSeconds;
            set => TimeoutInSeconds = value;
        }
    }
}

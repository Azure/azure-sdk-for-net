// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Describes a connection monitor output destination. </summary>
    public partial class ConnectionMonitorOutput
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="OutputType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use OutputType instead.")]
        public OutputType? Type
        {
            get => OutputType;
            set => OutputType = value;
        }
    }
}

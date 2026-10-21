// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NvaInterfaceConfigurationsProperties
    {
        // PropertiesType was already the generated 1.15.0 name; retain it as an alias over the same wire-backed list.
        /// <inheritdoc cref="Type"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use Type instead.")]
        public IList<NvaNicType> PropertiesType => Type;
    }
}

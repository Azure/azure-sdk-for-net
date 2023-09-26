// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Hop link. </summary>
    public partial class HopLink
    {
        /// <summary> Resource ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceIdString", false)]
        public ResourceIdentifier ResourceId {
            get => ResourceId;
            set
            {
                ResourceId = value;
            }
        }
    }
}

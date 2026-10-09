// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The format of the What-If results. </summary>
    [Obsolete("Use Azure.ResourceManager.Resources.Deployments.Models.WhatIfResultFormat instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum WhatIfResultFormat
    {
        /// <summary> ResourceIdOnly. </summary>
        ResourceIdOnly,
        /// <summary> FullResourcePayloads. </summary>
        FullResourcePayloads
    }
}

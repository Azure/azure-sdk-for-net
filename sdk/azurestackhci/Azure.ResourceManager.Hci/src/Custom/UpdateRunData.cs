// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateRunData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunData : HciClusterUpdateRunData
    {
        /// <summary> Initializes a new instance of UpdateRunData. </summary>
        public UpdateRunData() : base()
        {
        }

        /// <summary> Initializes a new instance of UpdateRunData from base type. </summary>
        internal UpdateRunData(HciClusterUpdateRunData data) : base(
            data?.Id,
            data?.Name,
            data?.ResourceType ?? default,
            data?.SystemData,
            additionalBinaryDataProperties: null,
            default,
            default,
            data?.Location)
        {
        }
    }
}

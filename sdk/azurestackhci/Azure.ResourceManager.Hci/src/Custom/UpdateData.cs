// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateData : HciClusterUpdateData
    {
        /// <summary> Initializes a new instance of UpdateData. </summary>
        public UpdateData() : base()
        {
        }

        /// <summary> Initializes a new instance of UpdateData from base type. </summary>
        internal UpdateData(HciClusterUpdateData data) : base(
            data?.Id,
            data?.Name,
            data?.ResourceType ?? default,
            data?.SystemData,
            additionalBinaryDataProperties: null,
            default,
            data?.Location)
        {
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

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

        /// <summary>
        /// If update State is HasPrerequisite, this property contains an array of objects describing prerequisite updates before installing this update. Otherwise, it is empty.
        /// </summary>
        [Obsolete("This property is obsolete. Use base.Prerequisites with type IList<HciClusterUpdatePrerequisite> instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<UpdatePrerequisite> Prerequisites
        {
            get => base.Prerequisites?.Select(p => new UpdatePrerequisite(p.UpdateType, p.Version, p.PackageName, null)).ToList() ?? new List<UpdatePrerequisite>();
        }
    }
}

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
    /// <summary> Backward-compat alias for HciClusterUpdateSummaryData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateSummaryData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateSummaryData : HciClusterUpdateSummaryData
    {
        /// <summary> Initializes a new instance of UpdateSummaryData. </summary>
        public UpdateSummaryData() : base()
        {
        }

        /// <summary> Initializes a new instance of UpdateSummaryData from base type. </summary>
        internal UpdateSummaryData(HciClusterUpdateSummaryData data) : base(
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
        /// Overall update state of the stamp.
        /// </summary>
        [Obsolete("This property is obsolete. Use base.State with type HciClusterUpdateState? instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new UpdateSummariesPropertiesState? State
        {
            get => base.State.HasValue ? new UpdateSummariesPropertiesState(base.State.Value.ToString()) : null;
            set
            {
                if (value.HasValue)
                {
                    base.State = new HciClusterUpdateState(value.Value.ToString());
                }
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated flatten of dataResidency.type produced property name "DataResidencyType",
// but baseline API had "ResidencyType". This adds a backward-compatible alias property.

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeDeviceData
    {
        /// <summary> The type of data residency. </summary>
        public Models.DataBoxEdgeDataResidencyType? ResidencyType
        {
            get => DataResidencyType;
            set => DataResidencyType = value;
        }
    }
}

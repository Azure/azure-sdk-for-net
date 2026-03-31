// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline had a public parameterless constructor. New generator requires discriminator parameter.

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeTriggerData
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeTriggerData"/>. </summary>
        public DataBoxEdgeTriggerData() : this(default)
        {
        }
    }
}

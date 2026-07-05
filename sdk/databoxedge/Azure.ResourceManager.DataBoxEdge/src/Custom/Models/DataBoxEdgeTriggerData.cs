// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had a public parameterless constructor. New generator requires discriminator parameter.

using System.ComponentModel;

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeTriggerData
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeTriggerData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataBoxEdgeTriggerData() : this(default)
        {
        }
    }
}

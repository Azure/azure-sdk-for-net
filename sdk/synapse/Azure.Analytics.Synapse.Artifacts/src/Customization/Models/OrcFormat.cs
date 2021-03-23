// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The data stored in Optimized Row Columnar (ORC) format. </summary>
    public partial class OrcFormat : DatasetStorageFormat
    {
        /// <summary> Initializes a new instance of OrcFormat. </summary>
        public OrcFormat()
        {
            Type = "OrcFormat";
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    public partial class AvroFormat : DatasetStorageFormat
    {
        /// <summary> Initializes a new instance of AvroFormat. </summary>
        public AvroFormat()
        {
            Type = "AvroFormat";
        }
    }
}

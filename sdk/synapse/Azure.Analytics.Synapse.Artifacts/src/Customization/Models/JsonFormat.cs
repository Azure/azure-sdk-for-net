// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The data stored in JSON format. </summary>
    public partial class JsonFormat : DatasetStorageFormat
    {
        /// <summary> Initializes a new instance of JsonFormat. </summary>
        public JsonFormat()
        {
            Type = "JsonFormat";
        }
    }
}

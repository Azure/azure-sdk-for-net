// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The data stored in text format. </summary>
    public partial class TextFormat : DatasetStorageFormat
    {
        /// <summary> Initializes a new instance of TextFormat. </summary>
        public TextFormat()
        {
            Type = "TextFormat";
        }
    }
}

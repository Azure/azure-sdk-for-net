// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Columns that define the structure of the dataset. </summary>
    public partial class DatasetDataElement
    {
        /// <summary> Initializes a new instance of DatasetDataElement. </summary>
        public DatasetDataElement()
        {
        }

        /// <summary> Name of the column. Type: string (or Expression with resultType string). </summary>
        public object Name { get; set; }
        /// <summary> Type of the column. Type: string (or Expression with resultType string). </summary>
        public object Type { get; set; }
    }
}

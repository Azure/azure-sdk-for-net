// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Columns that define the physical type schema of the dataset. </summary>
    public partial class DatasetSchemaDataElement : IReadOnlyDictionary<string, object>
    {
        /// <summary> Initializes a new instance of DatasetSchemaDataElement. </summary>
        public DatasetSchemaDataElement()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Name of the schema column. Type: string (or Expression with resultType string). </summary>
        public object Name { get; set; }
        /// <summary> Type of the schema column. Type: string (or Expression with resultType string). </summary>
        public object Type { get; set; }
    }
}

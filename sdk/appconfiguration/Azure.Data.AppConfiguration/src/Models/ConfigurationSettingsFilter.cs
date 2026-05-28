// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Rename.
    /// <summary> Enables filtering of key-values. </summary>
    [CodeGenType("KeyValueFilter")]
    public partial class ConfigurationSettingsFilter
    {
        /// <summary> Initializes a new instance of KeyValueFilter. </summary>
        /// <param name="key"> Filters key-values by their key field. </param>
        /// <param name="label"> Filters key-values by their label field. </param>
        /// <param name="tags"> Filters key-values by their tags field.
        /// Each tag in the list should be expressed as a string in the format `tag=value`.
        /// </param>
        internal ConfigurationSettingsFilter(string key, string label, IList<string> tags)
        {
            Key = key;
            Label = label;
            Tags = tags;
        }
    }
}

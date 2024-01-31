// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Enables filtering of key-values. </summary>
    public partial class ConfigurationSettingsFilter
    {
        /// <summary> Initializes a new instance of KeyValueFilter. </summary>
        /// <param name="key"> Filters key-values by their key field. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ConfigurationSettingsFilter(string key)
        {
            Argument.AssertNotNull(key, nameof(key));

            Key = key;
        }

        /// <summary> Initializes a new instance of KeyValueFilter. </summary>
        /// <param name="key"> Filters key-values by their key field. </param>
        /// <param name="label"> Filters key-values by their label field. </param>
        internal ConfigurationSettingsFilter(string key, string label)
        {
            Key = key;
            Label = label;
        }

        /// <summary> Filters key-values by their key field. </summary>
        public string Key { get; set; }
        /// <summary> Filters key-values by their label field. </summary>
        public string Label { get; set; }
    }
}

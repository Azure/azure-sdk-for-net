// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.
    /// </summary>
    public class SettingSelector
    {
        /// <summary>
        /// Wildcard that symbolizes any value when used in filters.
        /// </summary>
        public static readonly string Any = "*";
        /// <summary>
        /// Keys that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public IList<string> Keys { get; }
        /// <summary>
        /// Labels that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public IList<string> Labels { get; }
        /// <summary>
        /// Allows requesting a specific set of fields.
        /// </summary>
        public SettingFields Fields { get; set; } = SettingFields.All;
        /// <summary>
        /// If set, then key values will be retrieved exactly as they existed at the provided time.
        /// </summary>
        public DateTimeOffset? AsOf { get; set; }

        /// <summary>
        /// Creates a SettingSelector with Any wildcards for both Key and Label properties
        /// </summary>
        public SettingSelector() : this(Any, Any) { }

        /// <summary>
        /// Creates a SettingSelector
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        public SettingSelector(string key, string label = default)
        {
            Keys = new List<string>
            {
                key ?? Any
            };

            Labels = new List<string>();
            if (label != null)
                Labels.Add(label);
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two SettingSelector instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the SettingSelector
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a string in reference to the SettingSelector.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO ()
        public override string ToString() => base.ToString();
        #endregion
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
        public IList<string> Keys { get; set; }
        /// <summary>
        /// Labels that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public IList<string> Labels { get; set; }
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
            Keys = new List<string>();
            Keys.Add(key ?? Any);

            Labels = new List<string>();
            if (label != null) Labels.Add(label);
        }

        /// <summary>
        /// Check if two SettingSelector instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        public bool Equals(SettingSelector other)
        {
            if (other == null) return false;
            if (!Keys.SequenceEqual(other.Keys)) return false;
            if (!Labels.SequenceEqual(other.Labels)) return false;
            if (!Fields.Equals(other.Fields)) return false;
            if (AsOf != other.AsOf) return false;

            return true;
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two SettingSelector instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is SettingSelector other)
            {
                return Equals(other);
            }
            else return false;
        }

        /// <summary>
        /// Get a hash code for the SettingSelector
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            var hashCode = new HashCodeBuilder();
            hashCode.Add(Keys);
            hashCode.Add(Labels);
            hashCode.Add(AsOf);
            hashCode.Add(Fields);
            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Creates a string in reference to the SettingSelector.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO ()
        public override string ToString() => base.ToString();
        #endregion
    }
}

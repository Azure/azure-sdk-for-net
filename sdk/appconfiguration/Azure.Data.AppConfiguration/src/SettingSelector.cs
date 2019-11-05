// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// <para><see cref="SettingSelector"/> is a set of options that allows selecting
    /// a filtered set of <see cref="ConfigurationSetting"/> entities from the
    /// configuration store, and optionally allows indicating which fields of
    /// each setting to retreive.</para>
    /// <para>Literals or filters may be specified for keys and labels.</para>
    /// <para>For more information, <see href="https://github.com/Azure/AppConfiguration/blob/master/docs/REST/kv.md#filtering"/>.</para>
    /// </summary>
    public class SettingSelector
    {
        /// <summary>
        /// A wildcard that matches any key or any label when passed as a filter
        /// to Keys or Labels.
        /// </summary>
        public static readonly string Any = "*";

        /// <summary>
        /// Keys or key filters that will be used to select a set of <see cref="ConfigurationSetting"/> entities.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public IList<string> Keys { get; }

        /// <summary>
        /// Labels or label filters that will be used to select a set of <see cref="ConfigurationSetting"/> entities.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public IList<string> Labels { get; }

        /// <summary>
        /// The fields of the <see cref="ConfigurationSetting"/> to retrieve for each setting in the retrieved group.
        /// </summary>
        public SettingFields Fields { get; set; } = SettingFields.All;

        /// <summary>
        /// Indicates the point in time in the revision history of the selected <see cref="ConfigurationSetting"/> entities to retrieve.
        /// If set, all properties of the <see cref="ConfigurationSetting"/> entities in the returned group will be exactly what they
        /// were at this time.
        /// </summary>
        public DateTimeOffset? AsOf { get; set; }

        /// <summary>
        /// Creates a <see cref="SettingSelector"/> that will retrieve all <see cref="ConfigurationSetting"/> entities in the
        /// configuration store by setting both Key and Label filters to Any.
        /// </summary>
        public SettingSelector() : this(Any, Any) { }

        /// <summary>
        /// Creates a <see cref="SettingSelector"/> that will retrieve <see cref="ConfigurationSetting"/> entities that match
        /// the passed-in keys and labels.
        /// </summary>
        /// <param name="key">A key or key filter indicating which <see cref="ConfigurationSetting"/> entities to select.</param>
        /// <param name="label">A label or label filter indicating which <see cref="ConfigurationSetting"/> entities to select</param>
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
        public override string ToString() => base.ToString();
        #endregion
    }
}

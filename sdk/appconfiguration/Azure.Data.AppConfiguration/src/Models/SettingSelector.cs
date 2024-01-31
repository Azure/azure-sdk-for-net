// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// <para><see cref="SettingSelector"/> is a set of options that allows selecting
    /// a filtered set of <see cref="ConfigurationSetting"/> entities from the
    /// configuration store, and optionally allows indicating which fields of
    /// each setting to retrieve.</para>
    /// <para>Literals or filters may be specified for keys and labels.</para>
    /// <para>For more information, <see href="https://docs.microsoft.com/azure/azure-app-configuration/rest-api-keys#filtering">Filtering</see>.</para>
    /// </summary>
    public class SettingSelector
    {
        /// <summary>
        /// A wildcard that matches any key or any label when passed as a filter
        /// to Keys or Labels.
        /// </summary>
        public static readonly string Any = "*";

        /// <summary>
        /// Key filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public string KeyFilter { get; set; }

        /// <summary>
        /// Label filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.
        /// </summary>
        /// <remarks>See the documentation for this client library for details on the format of filter expressions.</remarks>
        public string LabelFilter { get; set; }

        /// <summary>
        /// The fields of the <see cref="ConfigurationSetting"/> to retrieve for each setting in the retrieved group.
        /// </summary>
        public SettingFields Fields { get; set; } = SettingFields.All;

        /// <summary>
        /// Indicates the point in time in the revision history of the selected <see cref="ConfigurationSetting"/> entities to retrieve.
        /// If set, all properties of the <see cref="ConfigurationSetting"/> entities in the returned group will be exactly what they
        /// were at this time.
        /// </summary>
        public DateTimeOffset? AcceptDateTime { get; set; }

        /// <summary>
        /// Creates a default <see cref="SettingSelector"/> that will retrieve all <see cref="ConfigurationSetting"/> entities in the configuration store.
        /// </summary>
        public SettingSelector() { }

        #region nobody wants to see these
        /// <summary>
        /// Check if two SettingSelector instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the SettingSelector.
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

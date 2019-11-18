// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

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
        private StringBuilder _keys;
        private StringBuilder _labels;

        private StringBuilder Keys => _keys ??= new StringBuilder();
        private StringBuilder Labels => _labels ??= new StringBuilder();

        private const char AnyChar = '*';
        private const char EscapeChar = '\\';
        private const char SeparatorChar = ',';
        private const string KeyQueryFilter = "key";
        private const string LabelQueryFilter = "label";
        private const string FieldsQueryFilter = "$select";

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
        /// Creates a <see cref="SettingSelector"/> that will retrieve all <see cref="ConfigurationSetting"/> entities in the configuration store.
        /// </summary>
        public SettingSelector() { }

        /// <summary>
        /// Creates a <see cref="SettingSelector"/> that will retrieve <see cref="ConfigurationSetting"/> entities that match the passed-in key filter.
        /// </summary>
        /// <param name="keyFilter">A key filter indicating which <see cref="ConfigurationSetting"/> entities to select.</param>
        public static SettingSelector FromFilterString(string keyFilter)
        {
            Argument.AssertNotNullOrEmpty(keyFilter, nameof(keyFilter));
            return new SettingSelector
            {
                _keys = new StringBuilder(keyFilter)
            };
        }

        /// <summary>
        /// Creates a <see cref="SettingSelector"/> that will retrieve <see cref="ConfigurationSetting"/> entities that match the passed-in key filter.
        /// </summary>
        /// <param name="keyFilter">A key filter indicating which <see cref="ConfigurationSetting"/> entities to select.</param>
        /// <param name="labelFilter">A label filter indicating which <see cref="ConfigurationSetting"/> entities to select.</param>
        public static SettingSelector FromFilterString(string keyFilter, string labelFilter)
        {
            Argument.AssertNotNullOrEmpty(keyFilter, nameof(keyFilter));
            Argument.AssertNotNullOrEmpty(labelFilter, nameof(labelFilter));
            return new SettingSelector
            {
                _keys = new StringBuilder(keyFilter),
                _labels = new StringBuilder(labelFilter)
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddKey(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            AppendSeparator(Keys);
            AppendEscaped(Keys, key);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddKeyStartsWith(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            AppendSeparator(Keys);
            AppendEscaped(Keys, key);
            AppendAny(Keys);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddKeyEndsWith(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            AppendSeparator(Keys);
            AppendAny(Keys);
            AppendEscaped(Keys, key);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddKeyContains(string key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            AppendSeparator(Keys);
            AppendAny(Keys);
            AppendEscaped(Keys, key);
            AppendAny(Keys);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddLabel(string label)
        {
            Argument.AssertNotNull(label, nameof(label));
            AppendSeparator(Labels);
            AppendEscaped(Labels, label.Length > 0 ? label : "\0");
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddLabelStartsWith(string label)
        {
            Argument.AssertNotNullOrEmpty(label, nameof(label));
            AppendSeparator(Labels);
            AppendEscaped(Labels, label);
            AppendAny(Labels);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddLabelEndsWith(string label)
        {
            Argument.AssertNotNullOrEmpty(label, nameof(label));
            AppendSeparator(Labels);
            AppendAny(Labels);
            AppendEscaped(Labels, label);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public SettingSelector AddLabelContains(string label)
        {
            Argument.AssertNotNullOrEmpty(label, nameof(label));
            AppendSeparator(Labels);
            AppendAny(Labels);
            AppendEscaped(Labels, label);
            AppendAny(Labels);
            return this;
        }

        internal void BuildBatchQuery(RequestUriBuilder builder, string pageLink)
        {
            var keys = _keys != default ? _keys.ToString() : new string(AnyChar, 1);
            builder.AppendQuery(KeyQueryFilter, keys);

            if (_labels != default)
            {
                builder.AppendQuery(LabelQueryFilter, _labels.ToString());
            }

            if (Fields != SettingFields.All)
            {
                var filter = Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked");
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

            if (!string.IsNullOrEmpty(pageLink))
            {
                builder.AppendQuery("after", pageLink, escapeValue: false);
            }
        }

        private static void AppendSeparator(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(SeparatorChar);
            }
        }

        private static void AppendAny(StringBuilder sb) => sb.Append(AnyChar);

        private static void AppendEscaped(StringBuilder sb, string input)
        {
            foreach (var c in input)
            {
                switch (c)
                {
                    case AnyChar:
                    case SeparatorChar:
                    case EscapeChar:
                        sb.Append(EscapeChar);
                        break;
                }

                sb.Append(c);
            }
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

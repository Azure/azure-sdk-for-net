// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Azure.ApplicationModel.Configuration
{
    public sealed class ConfigurationSetting : IEquatable<ConfigurationSetting>
    {
        string _key;
        IDictionary<string, string> _tags;

        // TODO (pri 3): this is just for deserialization. We can remove after we move to JsonDocument
        internal ConfigurationSetting() { }

        public ConfigurationSetting(string key, string value, string label = null)
        {
            Key = key;
            Value = value;
            Label = label;
        }

        /// <summary>
        /// The primary identifier of a key-value.
        /// The key is used in unison with the label to uniquely identify a key-value.
        /// </summary>
        public string Key {
            get => _key;
            set {
                if (value == null) throw new ArgumentNullException(nameof(Key));
                _key = value;
            }
        }

        /// <summary>
        /// A value used to group key-values.
        /// The label is used in unison with the key to uniquely identify a key-value.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value of the key-value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The content type of the key-value's value.
        /// Providing a proper content-type can enable transformations of values when they are retrieved by applications.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// An ETag indicating the state of a key-value within a configuration store.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given key-value.
        /// </summary>
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// A value indicating whether the key-value is locked.
        /// A locked key-value may not be modified until it is unlocked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// A dictionary of tags that can help identify what a key-value may be applicable for.
        /// </summary>
        public IDictionary<string, string> Tags {
            get {
                if (_tags == null) {
                    lock (_key) {
                        if (_tags == null) {
                            _tags = new Dictionary<string, string>();
                        }
                    }
                }
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }

        public bool Equals(ConfigurationSetting other)
        {
            if (other == null) return false;
            if (!string.Equals(Value, other.Value, StringComparison.Ordinal)) return false;
            if (!string.Equals(Label, other.Label, StringComparison.Ordinal)) return false;
            if (!string.Equals(ContentType, other.ContentType, StringComparison.Ordinal)) return false;
            if (!LastModified.Equals(other.LastModified)) return false;
            if (!TagsEquals(other.Tags)) return false;
            // TODO (pri 1): any other fields we should compare?
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ConfigurationSetting other) {
                return Equals(other);
            }
            else return false;
        }

        private bool TagsEquals(IDictionary<string, string> other)
        {
            if (other == null) return false;
            if (Tags.Count != other.Count) return false;
            foreach (var pair in Tags)
            {
                if (!other.TryGetValue(pair.Key, out string value)) return false;
                if (!string.Equals(value, pair.Value, StringComparison.Ordinal)) return false;
            }
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            int hash = 17;
            if (Key!=null) hash = hash * 23 + Key.GetHashCode();
            if (Value != null) hash = hash * 23 + Value.GetHashCode();
            if (Label != null) hash = hash * 23 + Label.GetHashCode();
            if (ETag != null) hash = hash * 23 + ETag.GetHashCode();
            hash = hash * 23 + LastModified.GetHashCode();
            return hash;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
            => $"({Key},{Value})";
    }

    [DebuggerTypeProxy(typeof(SettingBatchDebugView))]
    public class SettingBatch
    {
        readonly ConfigurationSetting[] _settings;
        readonly BatchRequestOptions _filter;
        readonly string _link;

        internal SettingBatch(ConfigurationSetting[] settings, string link, BatchRequestOptions filter)
        {
            _settings = settings;
            _link = link;
            _filter = filter;
        }

        public ConfigurationSetting this[int index] => _settings[index];

        public int Count => _settings.Length;

        public BatchRequestOptions NextBatch
        {
            get
            {
                var clonedFilter = _filter.Clone();
                clonedFilter.BatchLink = _link;
                return clonedFilter;
            }
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }

    class SettingBatchDebugView
    {
        SettingBatch _batch;
        ConfigurationSetting[] _items;

        public SettingBatchDebugView(SettingBatch batch)
        {
            _batch = batch;
            _items = new ConfigurationSetting[_batch.Count];
            for(int i=0; i<_batch.Count; i++) {
                _items[i] = _batch[i];
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ConfigurationSetting[] Items => _items;        
    }
}

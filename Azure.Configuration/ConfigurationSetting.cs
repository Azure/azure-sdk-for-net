using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Configuration
{
    public sealed class ConfigurationSetting
    {
        /// <summary>
        /// The primary identifier of a key-value.
        /// The key is used in unison with the label to uniquely identify a key-value.
        /// </summary>
        public string Key { get; set; }

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
        public IDictionary<string, string> Tags { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }

    public sealed class SettingBatch : IEnumerable<ConfigurationSetting>
    {
        IReadOnlyList<ConfigurationSetting> _settings;

        public SettingBatch(IReadOnlyList<ConfigurationSetting> settings, int next)
        {
            _settings = settings;
            NextIndex = next;
        }

        public int NextIndex { get;  private set; }

        // TODO (pri 2): add struct enumerator 
        public IEnumerator<ConfigurationSetting> GetEnumerator() => _settings.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _settings.GetEnumerator();

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}

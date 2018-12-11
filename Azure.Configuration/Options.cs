using Azure.Core.Net;
using System;
using System.ComponentModel;

namespace Azure.Configuration
{
    [Flags]
    public enum SettingFields : uint
    {
        None = 0x0000,
        Key = 0x0001,
        Label = 0x0002,
        Value = 0x0004,
        ContentType = 0x0008,
        ETag = 0x0010,
        LastModified = 0x0020,
        Locked = 0x0040,
        Tags = 0x0080,

        All = uint.MaxValue
    }

    public class SettingFilter
    {
        /// <summary>
        /// Specific label of the key.
        /// </summary>
        public string Label { get; set; } = null;

        public ETagFilter ETag { get; set; }

        /// <summary>
        /// If set, then key values will be retrieved exactly as they existed at the provided time.
        /// </summary>
        public DateTimeOffset? Revision { get; set; }

        /// <summary>
        /// IKeyValue fields that will be retrieved.
        /// </summary>
        public SettingFields Fields { get; set; } = SettingFields.All;

        public static implicit operator SettingFilter(string label) => new SettingFilter() { Label = label};

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }

    public class BatchFilter : SettingFilter
    {
        /// <summary>
        /// Keys that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this SDK for details on the format of filter expressions</remarks>
        public string Key { get; set; } = "*";

        public int StartIndex { get; set; }
    }
}

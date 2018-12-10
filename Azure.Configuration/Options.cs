using System;

namespace Azure.Configuration
{
    [Flags]
    public enum SettingFields
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

        All = Key | Label | Value | ContentType | ETag | LastModified | Locked | Tags
    }

    public class SettingQueryOptions
    {
        public const string NullFilter = "\0";
        public const string AnyFilter = "*";

        /// <summary>
        /// Specific label of the key.
        /// </summary>
        public string LabelFilter { get; set; } = NullFilter;

        /// <summary>
        /// If set, then key values will be retrieved exactly as they existed at the provided time.
        /// </summary>
        public DateTimeOffset? PreferredDateTime { get; set; }

        /// <summary>
        /// IKeyValue fields that will be retrieved.
        /// </summary>
        public SettingFields FieldsSelector { get; set; } = SettingFields.All;
    }

    public sealed class BatchQueryOptions : SettingQueryOptions
    {
        /// <summary>
        /// Keys that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this SDK for details on the format of filter expressions</remarks>
        public string KeyFilter { get; set; } = AnyFilter;

        public int StartIndex { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using System;
using System.ComponentModel;

namespace Azure.ApplicationModel.Configuration
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

    public class RequestOptions
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

        public Guid RequestId { get; set; }

        public static implicit operator RequestOptions(string label) => new RequestOptions() { Label = label };

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO ()
        public override string ToString() => base.ToString();
        #endregion
    }

    public class BatchRequestOptions : RequestOptions
    {
        /// <summary>
        /// Keys that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this SDK for details on the format of filter expressions</remarks>
        public string Key { get; set; } = "*";

        public string BatchLink { get; set; }

        internal BatchRequestOptions Clone()
        {
            return new BatchRequestOptions()
            {
                Key = Key,
                BatchLink = BatchLink
            };
        }
    }

    public static class LabelFilters
    {
        public static readonly string Null = "\0";

        public static readonly string Any = "*";
    }
}

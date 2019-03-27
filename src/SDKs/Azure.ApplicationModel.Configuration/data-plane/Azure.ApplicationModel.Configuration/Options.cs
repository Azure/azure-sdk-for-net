// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base;
using System;
using System.Collections.Generic;
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

    public class ConfigurationSelector
    {
        public static readonly string Any = "*";
        /// <summary>
        /// Keys that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this SDK for details on the format of filter expressions</remarks>
        public List<string> Keys { get; set; } = new List<string> { Any };
        /// <summary>
        /// Labels that will be used to filter.
        /// </summary>
        /// <remarks>See the documentation for this SDK for details on the format of filter expressions</remarks>
        public List<string> Labels { get; set; } = new List<string> { Any };
        /// <summary>
        /// IKeyValue fields that will be retrieved.
        /// </summary>
        public SettingFields Fields { get; set; } = SettingFields.All;
        /// <summary>
        /// If set, then key values will be retrieved exactly as they existed at the provided time.
        /// </summary>
        public DateTimeOffset? AcceptDateTime { get; set; }

        public ConfigurationSelector() { }

        public ConfigurationSelector(string key, string label = default)
        {
            Keys = new List<string> { key };
            if(label != default) Labels = new List<string> { label };
        }

        internal string BatchLink { get; set; }

        internal ConfigurationSelector Clone(string batchLink)
        {
            return new ConfigurationSelector()
            {
                Keys = Keys,
                Labels = Labels,
                Fields = Fields,
                AcceptDateTime = AcceptDateTime,
                BatchLink = batchLink
            };
        }

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
}

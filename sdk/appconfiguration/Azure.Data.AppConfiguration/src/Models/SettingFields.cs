// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Rename and convert to an enum.
    // - Renamed enum members.
    /// <summary>
    /// Fields to retrieve from a configuration setting.
    /// </summary>
    [Flags]
    [CodeGenType("KeyValueFields")]
    public enum SettingFields : uint
    {
        /// <summary>
        /// The primary identifier of a configuration setting.
        /// </summary>
        Key = 0x0001,

        /// <summary>
        /// A label used to group configuration settings.
        /// </summary>
        Label = 0x0002,

        /// <summary>
        /// The value of the configuration setting.
        /// </summary>
        Value = 0x0004,

        /// <summary>
        /// The content type of the configuration setting's value.
        /// </summary>
        ContentType = 0x0008,

        /// <summary>
        /// An ETag indicating the version of a configuration setting within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        ETag = 0x0010,

        /// <summary>
        /// >The last time a modifying operation was performed on the given configuration setting.
        /// </summary>
        LastModified = 0x0020,

        /// <summary>
        /// A value indicating whether the configuration setting is read-only.
        /// </summary>
        [CodeGenMember("Locked")]
        IsReadOnly = 0x0040,

        /// <summary>
        /// A dictionary of tags that can help identify what a configuration setting may be applicable for.
        /// </summary>
        Tags = 0x0080,

        /// <summary>
        /// Allows for all the properties of a ConfigurationSetting to be retrieved.
        /// </summary>
        All = uint.MaxValue
    }
}

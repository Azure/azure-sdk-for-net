// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Rename and convert to an enum.
    // - Renamed enum members.
    /// <summary>
    /// Fields to retrieve from a feature flag configuration setting.
    /// </summary>
    [Flags]
    [CodeGenType("FeatureFlagFields")]
    public enum FeatureFlagFields : uint
    {
        /// <summary>
        /// No fields specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// The primary identifier of the feature flag.
        /// </summary>
        Name = 0x001,

        /// <summary>
        /// A label used to group feature flag settings.
        /// </summary>
        Label = 0x002,

        /// <summary>
        /// The last time a modifying operation was performed on the given feature flag.
        /// </summary>
        LastModified = 0x004,

        /// <summary>
        /// A dictionary of tags that can help identify what a feature flag may be applicable for.
        /// </summary>
        Tags = 0x008,

        /// <summary>
        /// An ETag indicating the version of a feature flag within a configuration store.
        /// </summary>
        [CodeGenMember("Etag")]
        ETag = 0x010,

        /// <summary>
        /// A value indicating whether the feature flag is read-only.
        /// </summary>
        [CodeGenMember("Locked")]
        IsReadOnly = 0x020,

        /// <summary>
        /// A value indicating whether the feature flag is enabled or disabled.
        /// </summary>
        Enabled = 0x040,

        /// <summary>
        /// A description of the feature flag and its purpose.
        /// </summary>
        Description = 0x080,

        /// <summary>
        /// The variants configuration for the feature flag, defining different feature variations.
        /// </summary>
        Variants = 0x100,

        /// <summary>
        /// The allocation configuration for the feature flag, controlling how traffic is distributed among variants.
        /// </summary>
        Allocation = 0x200,

        /// <summary>
        /// The conditions configuration for the feature flag, defining when the feature should be enabled.
        /// </summary>
        Conditions = 0x400,

        /// <summary>
        /// The telemetry configuration for the feature flag, controlling what telemetry data is collected.
        /// </summary>
        Telemetry = 0x800,

        /// <summary>
        /// An alias for the feature flag, providing an alternative identifier.
        /// </summary>
        Alias = 0x20000,

        /// <summary>
        /// Allows for all the properties of a feature flag to be retrieved.
        /// </summary>
        All = uint.MaxValue
    }
}

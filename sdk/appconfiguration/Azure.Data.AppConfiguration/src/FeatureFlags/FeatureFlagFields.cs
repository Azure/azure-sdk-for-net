// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Convert the generated extensible enum to a [Flags] enum so that a single value can
    //   represent a combination of fields, matching the SettingFields/SettingSelector pattern.
    /// <summary>
    /// Fields to retrieve from a <see cref="FeatureFlag"/>.
    /// </summary>
    [Flags]
    [CodeGenType("FeatureFlagFields")]
    public enum FeatureFlagFields : uint
    {
        /// <summary>
        /// The name of the feature flag.
        /// </summary>
        Name = 0x0001,

        /// <summary>
        /// A value indicating whether the feature flag is enabled.
        /// </summary>
        Enabled = 0x0002,

        /// <summary>
        /// A label used to group feature flags.
        /// </summary>
        Label = 0x0004,

        /// <summary>
        /// The description of the feature flag.
        /// </summary>
        Description = 0x0008,

        /// <summary>
        /// The conditions that determine when the feature flag should be enabled.
        /// </summary>
        Conditions = 0x0010,

        /// <summary>
        /// The variants defined for the feature flag.
        /// </summary>
        Variants = 0x0020,

        /// <summary>
        /// The allocation that determines how variants are assigned.
        /// </summary>
        Allocation = 0x0040,

        /// <summary>
        /// The telemetry configuration of the feature flag.
        /// </summary>
        Telemetry = 0x0080,

        /// <summary>
        /// A dictionary of tags that can help identify what a feature flag may be applicable for.
        /// </summary>
        Tags = 0x0100,

        /// <summary>
        /// The last time a modifying operation was performed on the given feature flag.
        /// </summary>
        LastModified = 0x0200,

        /// <summary>
        /// An ETag indicating the version of a feature flag within a configuration store.
        /// </summary>
        Etag = 0x0400,

        /// <summary>
        /// Allows for all the properties of a <see cref="FeatureFlag"/> to be retrieved.
        /// </summary>
        All = uint.MaxValue
    }
}

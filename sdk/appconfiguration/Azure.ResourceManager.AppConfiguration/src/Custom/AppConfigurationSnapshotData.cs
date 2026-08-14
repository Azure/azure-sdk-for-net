// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppConfiguration
{
    // add back a removed property due to generator update
    // and a removed constructor: the parameterless constructor shipped in the stable release
    // was replaced by one that requires a "filters" parameter, which is a binary breaking change.
    // The generated internal parameterless constructor (used only for deserialization) is suppressed
    // below and replaced here with a public one so existing callers keep compiling and the same
    // instance can still be used by the generated deserialization code.
    [CodeGenSuppress("AppConfigurationSnapshotData")]
    public partial class AppConfigurationSnapshotData
    {
        /// <summary> Initializes a new instance of <see cref="AppConfigurationSnapshotData"/>. </summary>
        public AppConfigurationSnapshotData()
        {
        }

        /// <summary> The type of the resource. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string SnapshotType => ResourceType.ToString();
    }
}

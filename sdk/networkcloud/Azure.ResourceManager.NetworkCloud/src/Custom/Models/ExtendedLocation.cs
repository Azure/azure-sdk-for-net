// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shim: old API exposed ExtendedLocation in Azure.ResourceManager.NetworkCloud.Models namespace.
// New generator uses Azure.ResourceManager.Resources.Models.ExtendedLocation. This shim preserves ApiCompat.
// [CodeGenType] maps the generated NetworkCloudExtendedLocation (from @@alternateType in client.tsp) to this class.
// [CodeGenSuppress] removes generated members that hide inherited ones from the base class.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> The complex type of the extended location. </summary>
    [CodeGenType("NetworkCloudExtendedLocation")]
    [CodeGenSuppress("Name")]
    [CodeGenSuppress("ExtendedLocationType")]
    [CodeGenSuppress("ExtendedLocation", typeof(string), typeof(ExtendedLocationType))]
    [CodeGenSuppress("ExtendedLocation", typeof(string), typeof(ExtendedLocationType), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ExtendedLocation : Azure.ResourceManager.Resources.Models.ExtendedLocation
    {
        /// <summary> Initializes a new instance of <see cref="ExtendedLocation"/>. </summary>
        public ExtendedLocation()
        {
        }

        // Backward compat: old API had constructor taking two strings (name, extendedLocationType).
        // New API uses ExtendedLocationType enum via base class. This shim preserves the old API surface.
        /// <summary> Initializes a new instance of <see cref="ExtendedLocation"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExtendedLocation(string name, string extendedLocationType)
        {
            Name = name;
            base.ExtendedLocationType = new Resources.Models.ExtendedLocationType(extendedLocationType);
        }

        // Backward compat: old API exposed ExtendedLocationType as string.
        // New base class uses ExtendedLocationType? enum. Shadow with string version for ApiCompat.
        /// <summary> The type of the extended location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string ExtendedLocationType
        {
            get => base.ExtendedLocationType?.ToString();
            set => base.ExtendedLocationType = value == null ? null : new Resources.Models.ExtendedLocationType(value);
        }
    }
}

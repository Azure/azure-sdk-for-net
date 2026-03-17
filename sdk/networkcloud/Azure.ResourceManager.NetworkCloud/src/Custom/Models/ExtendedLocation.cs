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
    public partial class ExtendedLocation : Azure.ResourceManager.Resources.Models.ExtendedLocation, IJsonModel<ExtendedLocation>, IPersistableModel<ExtendedLocation>
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

        // IJsonModel<ExtendedLocation> implementation - delegates to base class
        ExtendedLocation IJsonModel<ExtendedLocation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var baseResult = ((IJsonModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>)this).Create(ref reader, options);
            if (baseResult is ExtendedLocation custom) return custom;
            return new ExtendedLocation(baseResult.Name, baseResult.ExtendedLocationType?.ToString());
        }

        void IJsonModel<ExtendedLocation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>)this).Write(writer, options);
        }

        // IPersistableModel<ExtendedLocation> implementation - delegates to base class
        ExtendedLocation IPersistableModel<ExtendedLocation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var baseResult = ((IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>)this).Create(data, options);
            if (baseResult is ExtendedLocation custom) return custom;
            return new ExtendedLocation(baseResult.Name, baseResult.ExtendedLocationType?.ToString());
        }

        string IPersistableModel<ExtendedLocation>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>)this).GetFormatFromOptions(options);
        }

        BinaryData IPersistableModel<ExtendedLocation>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>)this).Write(options);
        }
    }
}

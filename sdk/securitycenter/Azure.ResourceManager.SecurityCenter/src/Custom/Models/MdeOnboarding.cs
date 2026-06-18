// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the MdeOnboarding class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MdeOnboarding : ResourceData, IJsonModel<MdeOnboarding>, IPersistableModel<MdeOnboarding>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdeOnboarding"/> type for compatibility with the previous public API surface.
        /// </summary>
        public MdeOnboarding() { }
        /// <summary>
        /// Gets or sets the OnboardingPackageLinux value preserved from the previous public API surface.
        /// </summary>
        public byte[] OnboardingPackageLinux { get; set; }
        /// <summary>
        /// Gets or sets the OnboardingPackageWindows value preserved from the previous public API surface.
        /// </summary>
        public byte[] OnboardingPackageWindows { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        MdeOnboarding IJsonModel<MdeOnboarding>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<MdeOnboarding>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        MdeOnboarding IPersistableModel<MdeOnboarding>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<MdeOnboarding>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<MdeOnboarding>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}

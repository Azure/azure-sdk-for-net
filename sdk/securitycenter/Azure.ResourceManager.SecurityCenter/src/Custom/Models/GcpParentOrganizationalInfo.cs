// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the GcpParentOrganizationalInfo class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GcpParentOrganizationalInfo : GcpOrganizationalInfo, IJsonModel<GcpParentOrganizationalInfo>, IPersistableModel<GcpParentOrganizationalInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GcpParentOrganizationalInfo"/> type for compatibility with the previous public API surface.
        /// </summary>
        public GcpParentOrganizationalInfo() { }
        /// <summary>
        /// Gets the ExcludedProjectNumbers value preserved from the previous public API surface.
        /// </summary>
        public IList<string> ExcludedProjectNumbers { get; } = new List<string>();
        /// <summary>
        /// Gets the OrganizationName value preserved from the previous public API surface.
        /// </summary>
        public string OrganizationName { get; }
        /// <summary>
        /// Gets or sets the ServiceAccountEmailAddress value preserved from the previous public API surface.
        /// </summary>
        public string ServiceAccountEmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the WorkloadIdentityProviderId value preserved from the previous public API surface.
        /// </summary>
        public string WorkloadIdentityProviderId { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        GcpParentOrganizationalInfo IJsonModel<GcpParentOrganizationalInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<GcpParentOrganizationalInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        GcpParentOrganizationalInfo IPersistableModel<GcpParentOrganizationalInfo>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<GcpParentOrganizationalInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<GcpParentOrganizationalInfo>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}

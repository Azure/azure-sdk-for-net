// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, SiteRecoveryClusterRecoveryPointData was emitted as a
// ResourceData type because SiteRecoveryClusterRecoveryPoint was modeled as a full ARM
// resource. The new TypeSpec specification no longer models it as an ARM resource (it does
// not appear in the ARM templates index), so the MPG emitter does not generate this type.
// Removing the v1.x public surface would be a binary-breaking change for consumers, so we
// keep the type signature here, mark it obsolete, and have every member throw
// NotSupportedException. Callers should migrate to SiteRecoveryClusterRecoveryPoint.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary> Recovery point for a replication protection cluster. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource.")]
    public partial class SiteRecoveryClusterRecoveryPointData : ResourceData, IJsonModel<SiteRecoveryClusterRecoveryPointData>, IPersistableModel<SiteRecoveryClusterRecoveryPointData>
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryClusterRecoveryPointData"/>. </summary>
        internal SiteRecoveryClusterRecoveryPointData() { }

        /// <summary> The recovery point type. </summary>
        public string ClusterRecoveryPointType => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> The recovery point properties. </summary>
        public SiteRecoveryClusterRecoveryPointProperties Properties => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Writes the JSON representation of this instance to the provided writer. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        SiteRecoveryClusterRecoveryPointData IJsonModel<SiteRecoveryClusterRecoveryPointData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        void IJsonModel<SiteRecoveryClusterRecoveryPointData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SiteRecoveryClusterRecoveryPointData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        string IPersistableModel<SiteRecoveryClusterRecoveryPointData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        BinaryData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, SiteRecoveryClusterRecoveryPoint was emitted as a
// full ARM resource type (Resource + Data + Collection + parent accessors). The new
// TypeSpec specification no longer models it as an ARM resource — it does not appear in the
// ARM templates index at learn.microsoft.com/azure/templates and the spec author removed it
// from the resource hierarchy, so the MPG emitter does not generate any of these types.
// Removing the v1.x public surface would be a binary-breaking change for consumers, so we
// keep the type signature here, mark it obsolete, and have every member throw
// NotSupportedException. Callers should migrate to the methods on
// SiteRecoveryReplicationProtectionClusterResource that operate on the cluster recovery
// point payload directly without modeling it as a resource.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary>
    /// A class representing a SiteRecoveryClusterRecoveryPoint along with the instance operations that can be performed on it.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource; use the methods on SiteRecoveryReplicationProtectionClusterResource that operate on SiteRecoveryClusterRecoveryPoint payloads directly.")]
    public partial class SiteRecoveryClusterRecoveryPointResource : ArmResource, IJsonModel<SiteRecoveryClusterRecoveryPointData>, IPersistableModel<SiteRecoveryClusterRecoveryPointData>
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectionClusters/recoveryPoints";

        /// <summary> Initializes a new instance of <see cref="SiteRecoveryClusterRecoveryPointResource"/> for mocking. </summary>
        protected SiteRecoveryClusterRecoveryPointResource() : base() { }

        /// <summary> Gets the data representing this Resource. </summary>
        public virtual SiteRecoveryClusterRecoveryPointData Data => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Generates the resource identifier for this resource. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string replicationProtectionClusterName, string recoveryPointName)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        internal static void ValidateResourceId(ResourceIdentifier id) { }

        /// <summary> Gets the cluster recovery point. </summary>
        public virtual Response<SiteRecoveryClusterRecoveryPointResource> Get(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Gets the cluster recovery point. </summary>
        public virtual Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

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

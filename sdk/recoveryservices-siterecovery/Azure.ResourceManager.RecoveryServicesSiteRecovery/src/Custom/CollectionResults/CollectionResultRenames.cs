// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// =============================================================================
// CollectionResult type renames
// -----------------------------------------------------------------------------
// The MPG generator synthesizes one CollectionResult<T> / AsyncCollectionResult<T>
// nested subtype per paged operation and names it using the pattern:
//
//     {ServiceMethodCollectionName}{OperationName}[Async]CollectionResultOfT
//
// For this RP, several operation names have been client-renamed to long v1.x
// names (e.g. "GetSiteRecoveryReplicationProtectionClusterResources",
// "GetByReplicationProtectionContainers") to preserve binary compatibility with
// the AutoRest-generated 1.x baseline. The synthesized CollectionResult subtype
// names therefore become long enough that the resulting source file paths
// exceed the Windows 260-character MAX_PATH limit, breaking CI on Windows
// agents and breaking `git clone` on developer machines without long-path
// support enabled.
//
// Workaround: rename each affected CollectionResult subtype to its short v1.x-
// derived name via [CodeGenType]. These types are internal implementation
// details (returned only through public IAsyncEnumerable/IEnumerable surfaces)
// so renaming them has no public-API impact.
//
// This entire file can (and SHOULD) be deleted once the following issue is
// resolved in the generator, which tracks shortening these synthesized names
// at the source:
//
//     https://github.com/Azure/azure-sdk-for-net/issues/58996
// =============================================================================

#nullable disable
#pragma warning disable SA1402 // File may only contain a single type — these are intentionally bundled; see header.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    [CodeGenType("ReplicationProtectionClustersGetSiteRecoveryReplicationProtectionClusterResourcesAsyncCollectionResultOfT")]
    internal partial class ReplicationProtectionClustersListBySubscriptionAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationProtectionClustersGetSiteRecoveryReplicationProtectionClusterResourcesCollectionResultOfT")]
    internal partial class ReplicationProtectionClustersListBySubscriptionCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationProtectionContainerMappingsGetProtectionContainerMappingsAsyncCollectionResultOfT")]
    internal partial class ReplicationProtectionContainerMappingsListAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationProtectionContainerMappingsGetByReplicationProtectionContainersAsyncCollectionResultOfT")]
    internal partial class ReplicationProtectionContainerMappingsListByContainerAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationProtectionContainerMappingsGetByReplicationProtectionContainersCollectionResultOfT")]
    internal partial class ReplicationProtectionContainerMappingsListByContainerCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationRecoveryServicesProvidersGetSiteRecoveryServicesProvidersAsyncCollectionResultOfT")]
    internal partial class ReplicationRecoveryServicesProvidersListAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationStorageClassificationMappingsGetStorageClassificationMappingsAsyncCollectionResultOfT")]
    internal partial class ReplicationStorageClassificationMappingsListAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationStorageClassificationMappingsGetByReplicationStorageClassificationsAsyncCollectionResultOfT")]
    internal partial class ReplicationStorageClassificationMappingsListByClassificationAsyncCollectionResultOfT
    {
    }

    [CodeGenType("ReplicationStorageClassificationMappingsGetByReplicationStorageClassificationsCollectionResultOfT")]
    internal partial class ReplicationStorageClassificationMappingsListByClassificationCollectionResultOfT
    {
    }
}

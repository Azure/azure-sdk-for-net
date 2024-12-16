// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if EXPERIMENTAL_PROVISIONING

using System;
using Azure.Core;
using Azure.Provisioning.Storage;

#pragma warning disable IDE0130 // Namespace does not match folder structure
// TODO: Decide how folks feel about putting the high level helpers in the main
// namespace so `using Azure.Provisioning;` helps you easily get started.
namespace Azure.Provisioning;

// TODO: This is a rough outline of what the higher level conveniences could
// look like.  Pulling the most common types out will help with discovery.
// Adding ResourceResolver will help with easy of composition.

/// <summary>
/// Helpers to construct the most commonly used Azure Storage resources.
/// </summary>
public class StorageResources
{
    /// <summary>
    /// Create a new Azure Storage account.
    /// </summary>
    /// <param name="resourceName">
    /// The friendly name of the Storage account that by default is used as
    /// a prefix for the Azure name.
    /// </param>
    /// <param name="infrastructureVersion">
    /// Determines the version of the resource to create.  It always defaults
    /// to the latest, but you can hard code it for long term stability.
    /// </param>
    /// <returns></returns>
    public static StorageAccount CreateAccount(
        string resourceName,
        int? infrastructureVersion = 2) =>
        // TODO: Generate examples of v1 and v2 in the <remarks> to better explain
        infrastructureVersion == 1 ?
            new(resourceName, StorageAccount.ResourceVersions.V2022_09_01)
            {
                // Let the resolvers default the Name and Location
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
            } :
        infrastructureVersion == 2 ?
            new(resourceName, StorageAccount.ResourceVersions.V2023_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardLrs },

                // As an example, we're making v2 slightly more secure
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false
            } :
        throw new ArgumentOutOfRangeException(nameof(infrastructureVersion), $"Expected a value between 1 and 2 inclusive, not {infrastructureVersion}.");
}

#endif

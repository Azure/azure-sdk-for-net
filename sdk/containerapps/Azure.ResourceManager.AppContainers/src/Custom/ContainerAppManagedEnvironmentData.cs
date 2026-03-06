// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers
{
    /// <summary> A class representing the ContainerAppManagedEnvironmentData data model. </summary>
    public partial class ContainerAppManagedEnvironmentData : TrackedResourceData
    {
        // This property and the AppContainersSkuName type were removed from the service spec
        // but are preserved here as hidden members to avoid breaking existing consumers.
        // See https://github.com/Azure/azure-sdk-for-net/issues/56807

        /// <summary> SkuName for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppContainersSkuName? SkuName { get; set; }
    }
}

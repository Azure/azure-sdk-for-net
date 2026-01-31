// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    public partial class WorkloadNetworkResource : ArmResource
    {
        /// <summary>
        /// Generate the resource identifier of a <see cref="WorkloadNetworkResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="privateCloudName"> The privateCloudName. </param>
        /// <param name="workloadNetworkName"> The workloadNetworkName. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, WorkloadNetworkName workloadNetworkName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName);
    }
}

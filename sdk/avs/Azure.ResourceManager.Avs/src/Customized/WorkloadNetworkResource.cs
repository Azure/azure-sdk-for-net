// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A Class representing a WorkloadNetwork along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="WorkloadNetworkResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetWorkloadNetworkResource method.
    /// Otherwise you can get one from its parent resource <see cref="AvsPrivateCloudResource"/> using the GetWorkloadNetwork method.
    /// </summary>
     [EditorBrowsable(EditorBrowsableState.Never)]
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
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
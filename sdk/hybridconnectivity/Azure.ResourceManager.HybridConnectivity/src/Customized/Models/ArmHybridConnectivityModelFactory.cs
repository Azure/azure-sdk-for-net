// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmHybridConnectivityModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PublicCloudConnectorPatch"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="awsCloudExcludedAccounts"> List of AWS accounts which need to be excluded. </param>
        /// <returns> A new <see cref="Models.PublicCloudConnectorPatch"/> instance for mocking. </returns>
        /// <remarks>
        /// Retained for binary compatibility with 1.1.1. Starting with API version 2027-01-01 the
        /// connector patch carries a <see cref="PublicCloudConnectorPropertiesPatch"/>, because the
        /// properties can describe either an AWS or a GCP profile. Prefer the overload that accepts
        /// a <see cref="PublicCloudConnectorPropertiesPatch"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PublicCloudConnectorPatch PublicCloudConnectorPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, IEnumerable<string> awsCloudExcludedAccounts)
        {
            return PublicCloudConnectorPatch(id, name, resourceType, systemData, awsCloudExcludedAccounts, tags);
        }

        /// <summary> Initializes a new instance of <see cref="Models.HybridConnectivityOperationStatus"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        /// <returns> A new <see cref="Models.HybridConnectivityOperationStatus"/> instance for mocking. </returns>
        public static HybridConnectivityOperationStatus HybridConnectivityOperationStatus(ResourceIdentifier id = default, string name = default, string status = default, double? percentComplete = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, IEnumerable<HybridConnectivityOperationStatus> operations = default, ResponseError error = default, ResourceIdentifier resourceId = default)
        {
            operations ??= new List<HybridConnectivityOperationStatus>();

            return new HybridConnectivityOperationStatus(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations?.ToList(),
                error,
                resourceId,
                null);
        }
    }
}

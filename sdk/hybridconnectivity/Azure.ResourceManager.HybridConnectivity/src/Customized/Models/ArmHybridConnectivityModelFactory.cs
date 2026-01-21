// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmHybridConnectivityModelFactory
    {
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

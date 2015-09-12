// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

    /// <summary>
    /// Converts payloads to and from an object form.
    /// </summary>
    internal interface IPayloadConverter
    {
        /// <summary>
        /// Deserializes the status response of a connectivity request.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>
        /// A Payload Response with the details of the User Change Request Status.
        /// </returns>
        PayloadResponse<UserChangeRequestStatus> DeserializeConnectivityStatus(string payload);

        /// <summary>
        /// Deserializes a Connectivity Response.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <returns>
        /// A PayloadResponse object with the operation id for the data.
        /// </returns>
        PayloadResponse<Guid> DeserializeConnectivityResponse(string payload);

        /// <summary>
        /// Deserializes the result of a List Containers call.
        /// </summary>
        /// <param name="payload">
        /// The Payload.
        /// </param>
        /// <param name="deploymentNamespace">
        /// The deployment namespace.
        /// </param>
        /// <param name="subscriptionId">
        /// The Subscription Id.
        /// </param>
        /// <returns>
        /// A collection of HDInsight cluster objects.
        /// </returns>
        Collection<ClusterDetails> DeserializeListContainersResult(string payload, string deploymentNamespace, Guid subscriptionId);

        /// <summary>
        /// Serializes a create cluster request into a string that can be used as the 
        /// payload for a rest call.
        /// </summary>
        /// <param name="cluster">
        /// The create cluster request object.
        /// </param>
        /// <returns>
        /// A string that can be used as the payload in a rest call.
        /// </returns>
        string SerializeClusterCreateRequest(ClusterCreateParametersV2 cluster);

        /// <summary>
        /// Serializes a create cluster request into a string that can be used as the 
        /// payload for a rest call using schemaversion v3.
        /// </summary>
        /// <param name="cluster">
        /// The create cluster request object.
        /// </param>
        /// <returns>
        /// A string that can be used as the payload in a rest call.
        /// </returns>
        string SerializeClusterCreateRequestV3(ClusterCreateParametersV2 cluster);

        /// <summary>
        /// Converts an HDInsight version string to a Version object.
        /// </summary>
        /// <param name="version">
        /// The version string.
        /// </param>
        /// <returns>
        /// A version object that represents the components of the version string.
        /// </returns>
        Version ConvertStringToVersion(string version);
    }
}
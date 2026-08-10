// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    // The CsmDeploymentStatus class is a GA-compatibility shim for the original CsmDeploymentStatus model, which was a plain payload returned by WebSiteResource.GetProductionSiteDeploymentStatus* (and slot variants).
    // After the TypeSpec migration, the underlying API surfaced as a resource (CsmSiteDeploymentStatusResource) with a *Data model (CsmDeploymentStatusData).
    // To preserve the GA API surface, this class is retained.
    /// <summary>
    /// Deployment status response payload.
    /// </summary>
    public partial class CsmDeploymentStatus : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="CsmDeploymentStatus"/>. </summary>
        public CsmDeploymentStatus()
        {
            FailedInstancesLogs = new ChangeTrackingList<string>();
            Errors = new ChangeTrackingList<ResponseError>();
        }

        internal CsmDeploymentStatus(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string kind,
            string deploymentId,
            DeploymentBuildStatus? status,
            int? numberOfInstancesSuccessful,
            int? numberOfInstancesInProgress,
            int? numberOfInstancesFailed,
            IList<string> failedInstancesLogs,
            IList<ResponseError> errors,
            IDictionary<string, BinaryData> rawData)
            : base(id, name, resourceType, systemData)
        {
            Kind = kind;
            DeploymentId = deploymentId;
            Status = status;
            NumberOfInstancesSuccessful = numberOfInstancesSuccessful;
            NumberOfInstancesInProgress = numberOfInstancesInProgress;
            NumberOfInstancesFailed = numberOfInstancesFailed;
            FailedInstancesLogs = failedInstancesLogs ?? new ChangeTrackingList<string>();
            Errors = errors ?? new ChangeTrackingList<ResponseError>();
            _serializedAdditionalRawData = rawData;
        }

        /// <summary> Kind of resource. </summary>
        [WirePath("kind")]
        public string Kind { get; set; }

        /// <summary> Deployment identifier. </summary>
        [WirePath("properties.deploymentId")]
        public string DeploymentId { get; set; }

        /// <summary> Deployment build status. </summary>
        [WirePath("properties.status")]
        public DeploymentBuildStatus? Status { get; set; }

        /// <summary> Number of instances currently deploying successfully. </summary>
        [WirePath("properties.numberOfInstancesSuccessful")]
        public int? NumberOfInstancesSuccessful { get; set; }

        /// <summary> Number of instances in progress. </summary>
        [WirePath("properties.numberOfInstancesInProgress")]
        public int? NumberOfInstancesInProgress { get; set; }

        /// <summary> Number of instances that failed. </summary>
        [WirePath("properties.numberOfInstancesFailed")]
        public int? NumberOfInstancesFailed { get; set; }

        /// <summary> List of URLs pointing to logs for failed instances. </summary>
        [WirePath("properties.failedInstancesLogs")]
        public IList<string> FailedInstancesLogs { get; }

        /// <summary> List of errors. </summary>
        [WirePath("properties.errors")]
        public IList<ResponseError> Errors { get; }

        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;
    }
}

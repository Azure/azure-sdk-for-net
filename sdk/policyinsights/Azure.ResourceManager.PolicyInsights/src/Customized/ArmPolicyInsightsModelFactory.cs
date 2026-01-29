// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    public static partial class ArmPolicyInsightsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PolicyInsights.PolicyRemediationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyAssignmentId"> The resource ID of the policy assignment that should be remediated. </param>
        /// <param name="policyDefinitionReferenceId"> The policy definition reference ID of the individual definition that should be remediated. Required when the policy assignment being remediated assigns a policy set definition. </param>
        /// <param name="resourceDiscoveryMode"> The way resources to remediate are discovered. Defaults to ExistingNonCompliant if not specified. </param>
        /// <param name="provisioningState"> The status of the remediation. </param>
        /// <param name="createdOn"> The time at which the remediation was created. </param>
        /// <param name="lastUpdatedOn"> The time at which the remediation was last updated. </param>
        /// <param name="filterLocations"> The filters that will be applied to determine which resources to remediate. </param>
        /// <param name="deploymentStatus"> The deployment status summary for all deployments created by the remediation. </param>
        /// <param name="statusMessage"> The remediation status message. Provides additional details regarding the state of the remediation. </param>
        /// <param name="correlationId"> The remediation correlation Id. Can be used to find events related to the remediation in the activity log. </param>
        /// <param name="resourceCount"> Determines the max number of resources that can be remediated by the remediation job. If not provided, the default resource count is used. </param>
        /// <param name="parallelDeployments"> Determines how many resources to remediate at any given time. Can be used to increase or reduce the pace of the remediation. If not provided, the default parallel deployments value is used. </param>
        /// <param name="failureThresholdPercentage"> The remediation failure threshold settings. </param>
        /// <returns> A new <see cref="PolicyInsights.PolicyRemediationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyRemediationData PolicyRemediationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, ResourceDiscoveryMode? resourceDiscoveryMode = null, string provisioningState = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastUpdatedOn = null, IEnumerable<AzureLocation> filterLocations = null, RemediationDeploymentSummary deploymentStatus = null, string statusMessage = null, string correlationId = null, int? resourceCount = null, int? parallelDeployments = null, float? failureThresholdPercentage = null)
        {
            filterLocations ??= new List<AzureLocation>();

            return new PolicyRemediationData(
                id,
                name,
                resourceType,
                systemData,
                policyAssignmentId,
                policyDefinitionReferenceId,
                resourceDiscoveryMode,
                provisioningState,
                createdOn,
                lastUpdatedOn,
                filterLocations != null ? new RemediationFilters(filterLocations?.ToList(), new List<string>(), serializedAdditionalRawData: null) : null,
                deploymentStatus,
                statusMessage,
                correlationId,
                resourceCount,
                parallelDeployments,
                failureThresholdPercentage != null ? new RemediationPropertiesFailureThreshold(failureThresholdPercentage, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PolicyEvaluationResult"/>. </summary>
        /// <param name="policyInfo"> The details of the policy that was evaluated. </param>
        /// <param name="evaluationResult"> The result of the policy evaluation against the resource. This will typically be 'NonCompliant' but may contain other values if errors were encountered. </param>
        /// <param name="evaluationDetails"> The detailed results of the policy expressions and values that were evaluated. </param>
        /// <returns> A new <see cref="Models.PolicyEvaluationResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyEvaluationResult PolicyEvaluationResult(PolicyReference policyInfo = null, string evaluationResult = null, PolicyEvaluationDetails evaluationDetails = null)
        {
            var checkRestrictionEvaluationDetails = new CheckRestrictionEvaluationDetails();
            if (evaluationResult != null)
            {
                checkRestrictionEvaluationDetails = new CheckRestrictionEvaluationDetails(evaluationDetails.EvaluatedExpressions, evaluationDetails.IfNotExistsDetails, null, null);
            }
            return new PolicyEvaluationResult(policyInfo, evaluationResult, checkRestrictionEvaluationDetails, null, serializedAdditionalRawData: null);
        }
    }
}

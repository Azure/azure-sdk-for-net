// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class ResourceManagerModelFactory
    {
        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.SubResource"/> instance for mocking. </returns>
        public static SubResource SubResource(ResourceIdentifier id = null)
        {
            return new SubResource(id);
        }

        /// <summary> Initializes a new instance of WritableSubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.WritableSubResource"/> instance for mocking. </returns>
        public static WritableSubResource WritableSubResource(ResourceIdentifier id = null)
        {
            return new WritableSubResource(id);
        }

        /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="id"> The fully qualified ID of the location. For example, /subscriptions/00000000-0000-0000-0000-000000000000/locations/westus. </param>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="name"> The location name. </param>
        /// <param name="locationType"> The location type. </param>
        /// <param name="displayName"> The display name of the location. </param>
        /// <param name="regionalDisplayName"> The display name of the location and its region. </param>
        /// <param name="metadata"> Metadata of the location, such as lat/long, paired region, and others. </param>
        /// <returns> A new <see cref="Resources.Models.LocationExpanded"/> instance for mocking. </returns>
        public static LocationExpanded LocationExpanded(string id, string subscriptionId, string name, LocationType? locationType, string displayName, string regionalDisplayName, LocationMetadata metadata)
        {
            return new LocationExpanded(id, subscriptionId, name, locationType, displayName, regionalDisplayName, metadata, null);
        }

        /// <summary> Initializes a new instance of <see cref="Resources.PolicyAssignmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The location of the policy assignment. Only required when utilizing managed identity. </param>
        /// <param name="managedIdentity"> The managed identity associated with the policy assignment. Current supported identity types: None, SystemAssigned, UserAssigned. </param>
        /// <param name="displayName"> The display name of the policy assignment. </param>
        /// <param name="policyDefinitionId"> The ID of the policy definition or policy set definition being assigned. </param>
        /// <param name="scope"> The scope for the policy assignment. </param>
        /// <param name="excludedScopes"> The policy's excluded scopes. </param>
        /// <param name="parameters"> The parameter values for the assigned policy rule. The keys are the parameter names. </param>
        /// <param name="description"> This message will be part of response in case of policy violation. </param>
        /// <param name="metadata"> The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="enforcementMode"> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </param>
        /// <param name="nonComplianceMessages"> The messages that describe why a resource is non-compliant with the policy. </param>
        /// <param name="resourceSelectors"> The resource selector list to filter policies by resource properties. </param>
        /// <param name="overrides"> The policy property value override. </param>
        /// <returns> A new <see cref="Resources.PolicyAssignmentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyAssignmentData PolicyAssignmentData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            AzureLocation? location,
            ManagedServiceIdentity managedIdentity,
            string displayName,
            string policyDefinitionId,
            string scope,
            IEnumerable<string> excludedScopes,
            IDictionary<string, ArmPolicyParameterValue> parameters,
            string description,
            BinaryData metadata,
            EnforcementMode? enforcementMode,
            IEnumerable<NonComplianceMessage> nonComplianceMessages,
            IEnumerable<ResourceSelector> resourceSelectors,
            IEnumerable<PolicyOverride> overrides)
        {
            return PolicyAssignmentData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                location: location,
                managedIdentity: managedIdentity,
                displayName: displayName,
                policyDefinitionId: policyDefinitionId,
                definitionVersion: null,
                latestDefinitionVersion: null,
                effectiveDefinitionVersion: null,
                scope: scope,
                excludedScopes: excludedScopes,
                parameters: parameters,
                description: description,
                metadata: metadata,
                enforcementMode: enforcementMode,
                nonComplianceMessages: nonComplianceMessages,
                resourceSelectors: resourceSelectors,
                overrides: overrides,
                assignmentType: null,
                instanceId: null
            );
        }

        /// <summary> Initializes a new instance of <see cref="Resources.PolicyDefinitionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyType"> The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static. </param>
        /// <param name="mode"> The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data. </param>
        /// <param name="displayName"> The display name of the policy definition. </param>
        /// <param name="description"> The policy definition description. </param>
        /// <param name="policyRule"> The policy rule. </param>
        /// <param name="metadata"> The policy definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="parameters"> The parameter definitions for parameters used in the policy rule. The keys are the parameter names. </param>
        /// <returns> A new <see cref="Resources.PolicyDefinitionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicyDefinitionData PolicyDefinitionData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            PolicyType? policyType,
            string mode,
            string displayName,
            string description,
            BinaryData policyRule,
            BinaryData metadata,
            IDictionary<string, ArmPolicyParameter> parameters)
        {
            return PolicyDefinitionData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                policyType: policyType,
                mode: mode,
                displayName: displayName,
                description: description,
                policyRule: policyRule,
                metadata: metadata,
                parameters: parameters,
                version: null,
                versions: null,
                externalEvaluationEnforcementSettings: null
            );
        }

        /// <summary> Initializes a new instance of <see cref="Resources.PolicySetDefinitionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyType"> The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static. </param>
        /// <param name="displayName"> The display name of the policy set definition. </param>
        /// <param name="description"> The policy set definition description. </param>
        /// <param name="metadata"> The policy set definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="parameters"> The policy set definition parameters that can be used in policy definition references. </param>
        /// <param name="policyDefinitions"> An array of policy definition references. </param>
        /// <param name="policyDefinitionGroups"> The metadata describing groups of policy definition references within the policy set definition. </param>
        /// <returns> A new <see cref="Resources.PolicySetDefinitionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PolicySetDefinitionData PolicySetDefinitionData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            PolicyType? policyType,
            string displayName,
            string description,
            BinaryData metadata,
            IDictionary<string, ArmPolicyParameter> parameters,
            IEnumerable<PolicyDefinitionReference> policyDefinitions,
            IEnumerable<PolicyDefinitionGroup> policyDefinitionGroups)
        {
            return PolicySetDefinitionData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                policyType: policyType,
                displayName: displayName,
                description: description,
                metadata: metadata,
                parameters: parameters,
                policyDefinitions: policyDefinitions,
                policyDefinitionGroups: policyDefinitionGroups,
                version: null,
                versions: null
            );
        }
    }
}

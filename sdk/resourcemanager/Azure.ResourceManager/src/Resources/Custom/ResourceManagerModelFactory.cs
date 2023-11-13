// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public static SubResource SubResource(ResourceIdentifier id)
        {
            return new SubResource(id);
        }

        /// <summary> Initializes a new instance of WritableSubResource. </summary>
        /// <param name="id"></param>
        /// <returns> A new <see cref="Resources.Models.WritableSubResource"/> instance for mocking. </returns>
        public static WritableSubResource WritableSubResource(ResourceIdentifier id)
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

        /// <summary> Initializes a new instance of PolicyDefinitionData. </summary>
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
        public static PolicyDefinitionData PolicyDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PolicyType? policyType, string mode, string displayName, string description, BinaryData policyRule, BinaryData metadata, IDictionary<string, ArmPolicyParameter> parameters)
            => PolicyDefinitionData(id, name, resourceType, systemData, policyType, mode, displayName, description, policyRule, metadata, parameters, null, null);

        /// <summary> Initializes a new instance of PolicySetDefinitionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyType"> The type of policy set definition. Possible values are NotSpecified, BuiltIn, Custom, and Static. </param>
        /// <param name="displayName"> The display name of the policy set definition. </param>
        /// <param name="description"> The policy set definition description. </param>
        /// <param name="metadata"> The policy set definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="parameters"> The policy set definition parameters that can be used in policy definition references. </param>
        /// <param name="policyDefinitions"> An array of policy definition references. </param>
        /// <param name="policyDefinitionGroups"> The metadata describing groups of policy definition references within the policy set definition. </param>
        /// <returns> A new <see cref="Resources.PolicySetDefinitionData"/> instance for mocking. </returns>
        public static PolicySetDefinitionData PolicySetDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PolicyType? policyType, string displayName, string description, BinaryData metadata, IDictionary<string, ArmPolicyParameter> parameters, IEnumerable<PolicyDefinitionReference> policyDefinitions, IEnumerable<PolicyDefinitionGroup> policyDefinitionGroups)
            => PolicySetDefinitionData(id, name, resourceType, systemData, policyType, displayName, description, metadata, parameters, policyDefinitions, policyDefinitionGroups, null, null);
    }
}

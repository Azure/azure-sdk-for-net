// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("PolicyAssignmentData")]
namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing the PolicyAssignment data model. </summary>
    public partial class PolicyAssignmentData : ResourceData
    {
        /// <summary> Initializes a new instance of PolicyAssignmentData. </summary>
        public PolicyAssignmentData()
        {
            ExcludedScopes = new ChangeTrackingList<string>();
            Parameters = new ChangeTrackingDictionary<string, ArmPolicyParameterValue>();
            NonComplianceMessages = new ChangeTrackingList<NonComplianceMessage>();
        }

        /// <summary> Initializes a new instance of PolicyAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The location of the policy assignment. Only required when utilizing managed identity. </param>
        /// <param name="managedIdentity"> The managed identity associated with the policy assignment. </param>
        /// <param name="displayName"> The display name of the policy assignment. </param>
        /// <param name="policyDefinitionId"> The ID of the policy definition or policy set definition being assigned. </param>
        /// <param name="scope"> The scope for the policy assignment. </param>
        /// <param name="excludedScopes"> The policy&apos;s excluded scopes. </param>
        /// <param name="parameters"> The parameter values for the assigned policy rule. The keys are the parameter names. </param>
        /// <param name="description"> This message will be part of response in case of policy violation. </param>
        /// <param name="metadata"> The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="enforcementMode"> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </param>
        /// <param name="nonComplianceMessages"> The messages that describe why a resource is non-compliant with the policy. </param>
        internal PolicyAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, ManagedServiceIdentity managedIdentity, string displayName, string policyDefinitionId, string scope, IList<string> excludedScopes, IDictionary<string, ArmPolicyParameterValue> parameters, string description, BinaryData metadata, EnforcementMode? enforcementMode, IList<NonComplianceMessage> nonComplianceMessages) : base(id, name, resourceType, systemData)
        {
            Location = location;
            ManagedIdentity = managedIdentity;
            DisplayName = displayName;
            PolicyDefinitionId = policyDefinitionId;
            Scope = scope;
            ExcludedScopes = excludedScopes;
            Parameters = parameters;
            Description = description;
            Metadata = metadata;
            EnforcementMode = enforcementMode;
            NonComplianceMessages = nonComplianceMessages;
        }

        /// <summary> The location of the policy assignment. Only required when utilizing managed identity. </summary>
        public AzureLocation? Location { get; set; }

#pragma warning disable CS0618 // This type is obsolete and will be removed in a future release.
        private SystemAssignedServiceIdentity _identity;
        /// <summary> The managed identity associated with the policy assignment. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use ManagedIdentity.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SystemAssignedServiceIdentity Identity
        {
            get => _identity;
            set
            {
                _identity = value;
                _managedIdentity = value == null ? null : _identity.Identity;
            }
        }

        private ManagedServiceIdentity _managedIdentity;
        /// <summary> The managed identity associated with the policy assignment. </summary>
        public ManagedServiceIdentity ManagedIdentity
        {
            get => _managedIdentity;
            set
            {
                _managedIdentity = value;
                if (value == null)
                    _identity = null;
                else
                {
                    if (_identity == null)
                        _identity = new SystemAssignedServiceIdentity(value.PrincipalId, value.TenantId, value.ManagedServiceIdentityType.ToString());
                    _identity.Identity = value;
                }
            }
        }
#pragma warning restore CS0618 // This type is obsolete and will be removed in a future release.

        /// <summary> The display name of the policy assignment. </summary>
        public string DisplayName { get; set; }
        /// <summary> The ID of the policy definition or policy set definition being assigned. </summary>
        public string PolicyDefinitionId { get; set; }
        /// <summary> The scope for the policy assignment. </summary>
        public string Scope { get; }
        /// <summary> The policy&apos;s excluded scopes. </summary>
        public IList<string> ExcludedScopes { get; }
        /// <summary> The parameter values for the assigned policy rule. The keys are the parameter names. </summary>
        public IDictionary<string, ArmPolicyParameterValue> Parameters { get; }
        /// <summary> This message will be part of response in case of policy violation. </summary>
        public string Description { get; set; }
        /// <summary> The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs. </summary>
        public BinaryData Metadata { get; set; }
        /// <summary> The policy assignment enforcement mode. Possible values are Default and DoNotEnforce. </summary>
        public EnforcementMode? EnforcementMode { get; set; }
        /// <summary> The messages that describe why a resource is non-compliant with the policy. </summary>
        public IList<NonComplianceMessage> NonComplianceMessages { get; }
    }
}

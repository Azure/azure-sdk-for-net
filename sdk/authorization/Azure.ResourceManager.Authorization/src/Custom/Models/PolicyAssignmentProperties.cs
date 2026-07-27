// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Authorization.Models
{
#pragma warning disable CS0618 // This type intentionally implements the obsolete GA compatibility surface.
    // TypeSpec now generates RoleManagementPolicyAssignmentProperties. This wrapper keeps the shipped
    // PolicyAssignmentProperties type and delegates serialization to the same generated backing model.
    /// <summary> Expanded info of resource scope, role definition and policy. </summary>
    [Obsolete("Use RoleManagementPolicyAssignmentProperties instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PolicyAssignmentProperties : ResourceData, IJsonModel<PolicyAssignmentProperties>
    {
        private readonly RoleManagementPolicyAssignmentProperties _value;

        internal PolicyAssignmentProperties()
            : this(new RoleManagementPolicyAssignmentProperties())
        {
        }

        internal PolicyAssignmentProperties(RoleManagementPolicyAssignmentProperties value)
            : base(value?.Id, value?.Name, value is null ? default : value.ResourceType, value?.SystemData)
        {
            _value = value;
        }

        internal RoleManagementPolicyAssignmentProperties Value => _value;

        /// <summary> Id of the policy. </summary>
        [WirePath("policy.id")]
        public ResourceIdentifier PolicyId => _value?.PolicyId;

        /// <summary> The name of the entity last modified it. </summary>
        [WirePath("policy.lastModifiedBy")]
        public RoleManagementPrincipal LastModifiedBy => _value?.LastModifiedBy;

        /// <summary> The last modified date time. </summary>
        [WirePath("policy.lastModifiedDateTime")]
        public DateTimeOffset? LastModifiedOn => _value?.LastModifiedOn;

        /// <summary> Id of the role definition. </summary>
        [WirePath("roleDefinition.id")]
        public ResourceIdentifier RoleDefinitionId => _value?.RoleDefinitionId;

        /// <summary> Display name of the role definition. </summary>
        [WirePath("roleDefinition.displayName")]
        public string RoleDefinitionDisplayName => _value?.RoleDefinitionDisplayName;

        /// <summary> The role type. </summary>
        [WirePath("roleDefinition.type")]
        public AuthorizationRoleType? RoleType => _value?.RoleType;

        /// <summary> Scope id of the resource. </summary>
        [WirePath("scope.id")]
        public ResourceIdentifier ScopeId => _value?.ScopeId;

        /// <summary> Display name of the resource. </summary>
        [WirePath("scope.displayName")]
        public string ScopeDisplayName => _value?.ScopeDisplayName;

        /// <summary> Type of the scope. </summary>
        [WirePath("scope.type")]
        public RoleManagementScopeType? ScopeType => _value?.ScopeType;

        /// <summary> Creates a model from JSON. </summary>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            RoleManagementPolicyAssignmentProperties value =
                (RoleManagementPolicyAssignmentProperties)_value.CreateCompatibilityModel(ref reader, options);
            return value is null ? null : new PolicyAssignmentProperties(value);
        }

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => _value.WriteCompatibilityModel(writer, options);

        /// <summary> Creates a model from persisted data. </summary>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            RoleManagementPolicyAssignmentProperties value =
                (RoleManagementPolicyAssignmentProperties)_value.CreateCompatibilityModel(data, options);
            return value is null ? null : new PolicyAssignmentProperties(value);
        }

        /// <summary> Writes the model as persisted data. </summary>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
            => _value.WriteCompatibilityModel(options);

        PolicyAssignmentProperties IJsonModel<PolicyAssignmentProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (PolicyAssignmentProperties)JsonModelCreateCore(ref reader, options);

        void IJsonModel<PolicyAssignmentProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        PolicyAssignmentProperties IPersistableModel<PolicyAssignmentProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (PolicyAssignmentProperties)PersistableModelCreateCore(data, options);

        string IPersistableModel<PolicyAssignmentProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<PolicyAssignmentProperties>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
#pragma warning restore CS0618
}

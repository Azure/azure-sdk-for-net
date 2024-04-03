// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("ManagedClusterIdentity")]
namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary>
    /// Identity for the managed cluster.
    /// Serialized Name: ManagedClusterIdentity
    /// </summary>
    public partial class ManagedClusterIdentity
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ManagedClusterIdentity"/>. </summary>
        public ManagedClusterIdentity()
        {
            DelegatedResources = new ChangeTrackingDictionary<string, ManagedClusterDelegatedIdentity>();
            UserAssignedIdentities = new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>();
        }

        /// <summary> Initializes a new instance of <see cref="ManagedClusterIdentity"/>. </summary>
        /// <param name="principalId">
        /// The principal id of the system assigned identity which is used by master components.
        /// Serialized Name: ManagedClusterIdentity.principalId
        /// </param>
        /// <param name="tenantId">
        /// The tenant id of the system assigned identity which is used by master components.
        /// Serialized Name: ManagedClusterIdentity.tenantId
        /// </param>
        /// <param name="resourceIdentityType">
        /// For more information see [use managed identities in AKS](https://docs.microsoft.com/azure/aks/use-managed-identity).
        /// Serialized Name: ManagedClusterIdentity.type
        /// </param>
        /// <param name="delegatedResources">
        /// The delegated identity resources assigned to this managed cluster. This can only be set by another Azure Resource Provider, and managed cluster only accept one delegated identity resource. Internal use only.
        /// Serialized Name: ManagedClusterIdentity.delegatedResources
        /// </param>
        /// <param name="userAssignedIdentities">
        /// The keys must be ARM resource IDs in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// Serialized Name: ManagedClusterIdentity.userAssignedIdentities
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ManagedClusterIdentity(Guid? principalId, Guid? tenantId, ManagedServiceIdentityType resourceIdentityType, IDictionary<string, ManagedClusterDelegatedIdentity> delegatedResources, IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            ResourceIdentityType = resourceIdentityType;
            DelegatedResources = delegatedResources;
            UserAssignedIdentities = userAssignedIdentities;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The principal id of the system assigned identity which is used by master components.
        /// Serialized Name: ManagedClusterIdentity.principalId
        /// </summary>
        public Guid? PrincipalId { get; }
        /// <summary>
        /// The tenant id of the system assigned identity which is used by master components.
        /// Serialized Name: ManagedClusterIdentity.tenantId
        /// </summary>
        public Guid? TenantId { get; }
        /// <summary>
        /// For more information see [use managed identities in AKS](https://docs.microsoft.com/azure/aks/use-managed-identity).
        /// Serialized Name: ManagedClusterIdentity.type
        /// </summary>
        public ManagedServiceIdentityType ResourceIdentityType { get; set; }
        /// <summary>
        /// The delegated identity resources assigned to this managed cluster. This can only be set by another Azure Resource Provider, and managed cluster only accept one delegated identity resource. Internal use only.
        /// Serialized Name: ManagedClusterIdentity.delegatedResources
        /// </summary>
        public IDictionary<string, ManagedClusterDelegatedIdentity> DelegatedResources { get; }
        /// <summary>
        /// The keys must be ARM resource IDs in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// Serialized Name: ManagedClusterIdentity.userAssignedIdentities
        /// </summary>
        public IDictionary<ResourceIdentifier, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}

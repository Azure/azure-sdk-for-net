// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Models
{
    /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
    [PropertyReferenceType(new string[] { "UserAssignedIdentities" })]
    public partial class ManagedServiceIdentity
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

        /// <summary> Initializes a new instance of ManagedServiceIdentity. </summary>
        /// <param name="managedServiceIdentityType"> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </param>
        [InitializationConstructor]
        public ManagedServiceIdentity(ManagedServiceIdentityType managedServiceIdentityType)
        {
            ManagedServiceIdentityType = managedServiceIdentityType;
            UserAssignedIdentities = new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>();
        }

        /// <summary> Initializes a new instance of ManagedServiceIdentity. </summary>
        /// <param name="principalId"> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="tenantId"> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="managedServiceIdentityType"> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </param>
        /// <param name="userAssignedIdentities"> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        [SerializationConstructor]
        internal ManagedServiceIdentity(Guid? principalId, Guid? tenantId, ManagedServiceIdentityType managedServiceIdentityType, IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PrincipalId = principalId;
            TenantId = tenantId;
            ManagedServiceIdentityType = managedServiceIdentityType;
            UserAssignedIdentities = userAssignedIdentities;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        public Guid? PrincipalId { get; }
        /// <summary> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        public Guid? TenantId { get; }
        /// <summary> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </summary>
        public ManagedServiceIdentityType ManagedServiceIdentityType { get; set; }
        /// <summary> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </summary>
        public IDictionary<ResourceIdentifier, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}

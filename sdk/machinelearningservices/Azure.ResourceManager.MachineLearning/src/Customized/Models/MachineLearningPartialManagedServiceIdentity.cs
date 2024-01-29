// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

[assembly: CodeGenSuppressType("MachineLearningPartialManagedServiceIdentity")]
namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary>
    /// Managed service identity (system assigned and/or user assigned identities)
    /// </summary>
    public partial class MachineLearningPartialManagedServiceIdentity
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

        /// <summary> Initializes a new instance of <see cref="MachineLearningPartialManagedServiceIdentity"/>. </summary>
        public MachineLearningPartialManagedServiceIdentity()
        {
            UserAssignedIdentities = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of PartialManagedServiceIdentity. </summary>
        /// <param name="managedServiceIdentityType"> Managed service identity (system assigned and/or user assigned identities) </param>
        /// <param name="userAssignedIdentities"> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MachineLearningPartialManagedServiceIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType? managedServiceIdentityType, IDictionary<string, BinaryData> userAssignedIdentities, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ManagedServiceIdentityType = managedServiceIdentityType;
            UserAssignedIdentities = userAssignedIdentities;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Managed service identity (system assigned and/or user assigned identities)
        /// Serialized Name: PartialManagedServiceIdentity.type
        /// </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get; set; }
        /// <summary>
        /// The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests.
        /// Serialized Name: PartialManagedServiceIdentity.userAssignedIdentities
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public IDictionary<string, BinaryData> UserAssignedIdentities { get; }
    }
}

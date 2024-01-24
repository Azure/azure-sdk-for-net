// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

// This customization is here to override the serialization and deserialization for `ManagedIdentityType`
[assembly: CodeGenSuppressType("DevTestLabManagedIdentity")]
namespace Azure.ResourceManager.DevTestLabs.Models
{
    /// <summary> Properties of a managed identity. </summary>
    public partial class DevTestLabManagedIdentity
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

        /// <summary> Initializes a new instance of <see cref="DevTestLabManagedIdentity"/>. </summary>
        public DevTestLabManagedIdentity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DevTestLabManagedIdentity"/>. </summary>
        /// <param name="managedIdentityType"> Managed identity. </param>
        /// <param name="principalId"> The principal id of resource identity. </param>
        /// <param name="tenantId"> The tenant identifier of resource. </param>
        /// <param name="clientSecretUri"> The client secret URL of the identity. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DevTestLabManagedIdentity(ManagedServiceIdentityType managedIdentityType, Guid? principalId, Guid? tenantId, Uri clientSecretUri, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ManagedIdentityType = managedIdentityType;
            PrincipalId = principalId;
            TenantId = tenantId;
            ClientSecretUri = clientSecretUri;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Managed identity. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedIdentityType { get; set; }
        /// <summary> The principal id of resource identity. </summary>
        public Guid? PrincipalId { get; set; }
        /// <summary> The tenant identifier of resource. </summary>
        public Guid? TenantId { get; set; }
        /// <summary> The client secret URL of the identity. </summary>
        public Uri ClientSecretUri { get; set; }
    }
}

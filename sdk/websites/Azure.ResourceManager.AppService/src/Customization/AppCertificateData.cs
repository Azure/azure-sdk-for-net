// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class AppCertificateData
    {
        /// <summary> Key Vault Csm resource Id. </summary>
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(ReadKeyVaultId))]
        public ResourceIdentifier KeyVaultId { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadKeyVaultId(JsonProperty property, ref Optional<ResourceIdentifier> keyVaultId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var idString = property.Value.GetString();

            if (idString.Length == 0)
            {
                return;
            }
            keyVaultId = new ResourceIdentifier(idString);
        }

        /// <summary>
        /// Certificate thumbprint.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public BinaryData Thumbprint => BinaryData.FromString(ThumbprintString);
    }
}

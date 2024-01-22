// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    public partial class EnvironmentDefinition
    {
        /// <summary>
        /// JSON schema defining the parameters object passed to an environment.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeParametersSchema))]
        public BinaryData ParametersSchema { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeParametersSchema(JsonProperty property, ref Optional<BinaryData> parametersSchema)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            parametersSchema = BinaryData.FromString(property.Value.GetRawText());
        }
    }
}

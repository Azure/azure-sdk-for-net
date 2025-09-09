// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary> The ResponseSession. </summary>
    public partial class ResponseSession
    {
        /// <summary>
        /// Gets the Voice.
        /// <para> To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions?)"/>. </para>
        /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description> <see cref="OAIVoice"/>. </description>
        /// </item>
        /// <item>
        /// <description> <see cref="OpenAIVoice"/>. </description>
        /// </item>
        /// <item>
        /// <description> <see cref="AzureVoice"/>. </description>
        /// </item>
        /// <item>
        /// <description> <see cref="LlmVoiceName"/>. </description>
        /// </item>
        /// <item>
        /// <description> <see cref="LlmVoice"/>. </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term> BinaryData.FromObjectAsJson("foo"). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("\"foo\""). </term>
        /// <description> Creates a payload of "foo". </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromObjectAsJson(new { key = "value" }). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// <item>
        /// <term> BinaryData.FromString("{\"key\": \"value\"}"). </term>
        /// <description> Creates a payload of { "key": "value" }. </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal BinaryData VoiceInternal { get; }

        /// <summary>
        ///
        /// </summary>
        public VoiceProvider Voice { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Analytics.Defender.Easm
{
    [CodeGenSerialization(nameof(Value), "value")]
    public partial class InnerError
    {
        // due to a generator bug - in default the `InnerError` class is generated from the `InnerError` model from common types, instead of the `InnerError` model defined in Easm typespec.
        // therefore here we hide the property from common types (Innererror) and add back the property from Easm typespec (Value).
        // once the generator fixes this bug, we could change it back.
        /// <summary> Inner error. </summary>
        private InnerError Innererror { get; }
        /// <summary>
        /// This is an additional field representing the value that caused the error to help with debugging.
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
        public BinaryData Value { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Inference
{
    /// <summary> The CompleteRequest. </summary>
    internal partial class CompleteRequest
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

        /// <summary> Initializes a new instance of <see cref="CompleteRequest"/>. </summary>
        /// <param name="chatCompletionsOptions"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="chatCompletionsOptions"/> is null. </exception>
        internal CompleteRequest(ChatCompletionsOptions chatCompletionsOptions)
        {
            Argument.AssertNotNull(chatCompletionsOptions, nameof(chatCompletionsOptions));

            ChatCompletionsOptions = chatCompletionsOptions;
        }

        /// <summary> Initializes a new instance of <see cref="CompleteRequest"/>. </summary>
        /// <param name="chatCompletionsOptions"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CompleteRequest(ChatCompletionsOptions chatCompletionsOptions, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ChatCompletionsOptions = chatCompletionsOptions;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CompleteRequest"/> for deserialization. </summary>
        internal CompleteRequest()
        {
        }

        /// <summary> Gets the chat completions options. </summary>
        public ChatCompletionsOptions ChatCompletionsOptions { get; }
    }
}

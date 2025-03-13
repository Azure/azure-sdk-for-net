// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;

namespace Azure.AI.Inference
{
    public partial class FunctionDefinition
    {
        // CUSTOM CODE NOTES:
        //   - These customizations allow "init" style use of the definition via a public default constructor and
        //     accessible setters
        //   - These changes merge "presets" into static class members for ease of use

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.Auto"/>
        public static FunctionDefinition Auto
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.Auto.ToString());

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.None"/>
        public static FunctionDefinition None
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.None.ToString());

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.Required"/>
        public static FunctionDefinition Required
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.Required.ToString());

        /// <summary>
        /// Initializes a new instance of FunctionDefinition.
        /// </summary>
        public FunctionDefinition()
        { }

        /// <summary> The name of the function to be called. </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters the function accepts, described as a JSON Schema object.
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
        public BinaryData Parameters { get; set; }

        internal bool IsPredefined { get; set; } = false;

        internal static FunctionDefinition CreatePredefinedFunctionDefinition(string functionName)
            => new FunctionDefinition(functionName)
            {
                IsPredefined = true
            };
    }
}

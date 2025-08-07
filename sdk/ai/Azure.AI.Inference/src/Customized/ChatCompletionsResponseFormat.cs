// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Inference
{
    /// <summary>
    /// Represents the format that the model must output. Use this to enable JSON mode instead of the default text mode.
    /// Note that to enable JSON mode, some AI models may also require you to instruct the model to produce JSON
    /// via a system or user message.
    /// Please note <see cref="ChatCompletionsResponseFormat"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ChatCompletionsResponseFormatJsonObject"/> and <see cref="ChatCompletionsResponseFormatText"/>.
    /// </summary>
    public abstract partial class ChatCompletionsResponseFormat
    {
        /// <summary> Creates a new <see cref="ChatCompletionsResponseFormat"/> requesting plain text. </summary>
        public static ChatCompletionsResponseFormat CreateTextFormat() => new ChatCompletionsResponseFormatText();

        /// <summary> Creates a new <see cref="ChatCompletionsResponseFormat"/> requesting valid JSON, a.k.a. JSON mode. </summary>
        public static ChatCompletionsResponseFormat CreateJsonFormat() => new ChatCompletionsResponseFormatJsonObject();

        /// <summary>
        ///     Creates a new <see cref="ChatCompletionsResponseFormat"/> requesting adherence to the specified JSON schema,
        ///     a.k.a. structured outputs.
        /// </summary>
        /// <param name="jsonSchemaFormatName"> The name of the response format. </param>
        /// <param name="jsonSchema">
        ///     <para>
        ///         The schema of the response format, described as a JSON schema. Learn more in the
        ///         <see href="https://platform.openai.com/docs/guides/structured-outputs">structured outputs guide</see>.
        ///         and the
        ///         <see href="https://json-schema.org/understanding-json-schema">JSON schema reference documentation</see>.
        ///     </para>
        ///     <para>
        ///         You can easily create a JSON schema via the factory methods of the <see cref="BinaryData"/> class, such
        ///         as <see cref="BinaryData.FromBytes(byte[])"/> or <see cref="BinaryData.FromString(string)"/>. For
        ///         example, the following code defines a simple schema for step-by-step responses to math problems:
        ///         <code>
        ///             BinaryData jsonSchema = BinaryData.FromBytes("""
        ///                 {
        ///                     "type": "object",
        ///                     "properties": {
        ///                         "steps": {
        ///                             "type": "array",
        ///                             "items": {
        ///                                 "type": "object",
        ///                                 "properties": {
        ///                                     "explanation": {"type": "string"},
        ///                                     "output": {"type": "string"}
        ///                                 },
        ///                                 "required": ["explanation", "output"],
        ///                                 "additionalProperties": false
        ///                             }
        ///                         },
        ///                         "final_answer": {"type": "string"}
        ///                     },
        ///                     "required": ["steps", "final_answer"],
        ///                     "additionalProperties": false
        ///                 }
        ///                 """U8.ToArray());
        ///         </code>
        ///     </para>
        /// </param>
        /// <param name="jsonSchemaFormatDescription">
        ///     The description of what the response format is for, which is used by the model to determine how to respond
        ///     in the format.
        /// </param>
        /// <param name="jsonSchemaIsStrict">
        ///     <para>
        ///         Whether to enable strict schema adherence when generating the response. If set to <c>true</c>, the
        ///         model will follow the exact schema defined in <paramref name="jsonSchema"/>.
        ///     </para>
        ///     <para>
        ///         Only a subset of the JSON schema specification is supported when this is set to <c>true</c>. Learn more
        ///         in the
        ///         <see href="https://platform.openai.com/docs/guides/structured-outputs">structured outputs guide</see>.
        ///     </para>
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jsonSchemaFormatName"/> or <paramref name="jsonSchema"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jsonSchemaFormatName"/> is an empty string, and was expected to be non-empty. </exception>
        public static ChatCompletionsResponseFormat CreateJsonFormat(string jsonSchemaFormatName, IDictionary<string, BinaryData> jsonSchema, string jsonSchemaFormatDescription = null, bool? jsonSchemaIsStrict = null)
        {
            Argument.AssertNotNullOrEmpty(jsonSchemaFormatName, nameof(jsonSchemaFormatName));
            Argument.AssertNotNull(jsonSchema, nameof(jsonSchema));

            ChatCompletionsResponseFormatJsonSchemaDefinition internalSchema = new(
                jsonSchemaFormatName,
                jsonSchema,
                jsonSchemaFormatDescription,
                jsonSchemaIsStrict,
                serializedAdditionalRawData: null);

            return new ChatCompletionsResponseFormatJsonSchema(internalSchema);
        }
    }
}

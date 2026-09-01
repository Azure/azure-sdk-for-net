// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Hand-written: this model is declared in the Azure.AI.Projects TypeSpec namespace, which the
// C# emitter does not emit into this package. It remains part of the AgentServer.Responses
// output-item contract (its validator is still generated), so it is maintained here.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models
{
    /// <summary> An output item carrying a structured output captured during the response. </summary>
    [Experimental("AAIP002")]
    public partial class StructuredOutputsOutputItem : ResponseItem
    {
        /// <summary> Initializes a new instance of <see cref="StructuredOutputsOutputItem"/>. </summary>
        /// <param name="output"> The structured output captured during the response. </param>
        /// <param name="id"> The unique ID of the item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="output"/> or <paramref name="id"/> is null. </exception>
        public StructuredOutputsOutputItem(BinaryData output, string id) : base("structured_outputs")
        {
            Argument.AssertNotNull(output, nameof(output));
            Argument.AssertNotNull(id, nameof(id));

            Output = output;
            Id = id;
        }

        /// <summary>
        /// The structured output captured during the response.
        /// <para> To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions)"/>. </para>
        /// <para> To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>. </para>
        /// </summary>
        public BinaryData Output { get; set; }

        /// <summary> The unique ID of the item. </summary>
        public new string Id { get; set; }
    }
}

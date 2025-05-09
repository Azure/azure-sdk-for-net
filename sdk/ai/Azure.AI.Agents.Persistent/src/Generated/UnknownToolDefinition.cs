// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> Unknown version of ToolDefinition. </summary>
    internal partial class UnknownToolDefinition : ToolDefinition
    {
        /// <summary> Initializes a new instance of <see cref="UnknownToolDefinition"/>. </summary>
        /// <param name="type"> The object type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownToolDefinition(string type, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(type, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownToolDefinition"/> for deserialization. </summary>
        internal UnknownToolDefinition()
        {
        }
    }
}

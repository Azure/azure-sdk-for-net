// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace OpenAI
{
    internal partial class InternalFunctionTool : ResponseTool, IJsonModel<InternalFunctionTool>
    {
        // The generated parameterless deserialization constructor did not chain to the required
        // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
        // constructor). We add the chain here and supply the "function" discriminator so the
        // tool kind is set correctly during deserialization.
        /// <summary> Initializes a new instance of <see cref="InternalFunctionTool"/> for deserialization. </summary>
        internal InternalFunctionTool(): base(ResponseToolKind.Function)
        {
        }
    }
}

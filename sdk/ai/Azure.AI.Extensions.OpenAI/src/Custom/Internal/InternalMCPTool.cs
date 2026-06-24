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
    internal partial class InternalMCPTool : ResponseTool, IJsonModel<InternalMCPTool>
    {
        /// <summary> Initializes a new instance of <see cref="InternalMCPTool"/> for deserialization. </summary>
        internal InternalMCPTool(): base(ResponseToolKind.Mcp)
        {
        }
    }
}

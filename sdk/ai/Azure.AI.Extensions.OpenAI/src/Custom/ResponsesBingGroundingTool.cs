// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    public partial class BingGroundingTool : ResponseTool, IJsonModel<BingGroundingTool>
    {
        // The generated parameterless deserialization constructor did not chain to the required
        // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
        // constructor). We add the chain here and supply the "bing_grounding" discriminator so
        // the tool kind is set correctly during deserialization.
        /// <summary> Initializes a new instance of <see cref="BingGroundingTool"/> for deserialization. </summary>
        internal BingGroundingTool(): base(ResponseToolKind.BingGrounding)
        {
        }
    }
}

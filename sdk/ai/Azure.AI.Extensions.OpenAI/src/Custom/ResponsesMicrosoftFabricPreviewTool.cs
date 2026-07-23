// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    public partial class MicrosoftFabricPreviewTool : ResponseTool, IJsonModel<MicrosoftFabricPreviewTool>
    {
        // The generated parameterless deserialization constructor did not chain to the required
        // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
        // constructor). We add the chain here and supply the "fabric_dataagent_preview"
        // discriminator so the tool kind is set correctly during deserialization.
        /// <summary> Initializes a new instance of <see cref="MicrosoftFabricPreviewTool"/> for deserialization. </summary>
        internal MicrosoftFabricPreviewTool(): base(ResponseToolKind.FabricDataAgentPreview)
        {
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    public partial class ResponsesSharepointPreviewTool : ResponseTool, IJsonModel<ResponsesSharepointPreviewTool>
    {
        // The generated parameterless deserialization constructor did not chain to the required
        // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
        // constructor). We add the chain here and supply the "sharepoint_grounding_preview"
        // discriminator so the tool kind is set correctly during deserialization.
        /// <summary> Initializes a new instance of <see cref="ResponsesSharepointPreviewTool"/> for deserialization. </summary>
        internal ResponsesSharepointPreviewTool(): base(ResponseToolKind.SharePointGroundingPreview)
        {
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class MicrosoftCopilotToolsetPreview : ResponseTool, IJsonModel<MicrosoftCopilotToolsetPreview>
{
    // The generated parameterless deserialization constructor did not chain to the required
    // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
    // constructor). We add the chain here and supply the "microsoft_copilot_toolset_preview" discriminator so
    // the tool kind is set correctly during deserialization.
    /// <summary> Initializes a new instance of <see cref="MicrosoftCopilotToolsetPreview"/> for deserialization. </summary>
    internal MicrosoftCopilotToolsetPreview() : base(ResponseToolKind.MicrosoftCopilotToolsetPreview)
    {
    }
}

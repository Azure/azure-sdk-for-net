// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class WebIQPreviewTool
{
    // The generated parameterless deserialization constructor did not chain to the required
    // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
    // constructor). We add the chain here and supply the "web_iq_preview" discriminator so
    // the tool kind is set correctly during deserialization.
    /// <summary> Initializes a new instance of <see cref="WebIQPreviewTool"/> for deserialization. </summary>
    internal WebIQPreviewTool() : base(ResponseToolKind.WebIQPreview)
    {
    }
    /// <summary>
    /// Whether the agent requires approval before executing actions. When omitted, the service defaults to "always".
    /// </summary>
    [CodeGenMember("RequireApproval")]
    public WebIQPreviewToolRequireApprovalChoice RequireApproval { get; set; }
}

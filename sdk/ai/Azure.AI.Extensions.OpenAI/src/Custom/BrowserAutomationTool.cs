// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class BrowserAutomationTool
{
    // The generated parameterless deserialization constructor did not chain to the required
    // base ResponseTool(ResponseToolKind) constructor (ResponseTool has no parameterless
    // constructor). We add the chain here and supply the "browser_automation" discriminator so
    // the tool kind is set correctly during deserialization.
    /// <summary> Initializes a new instance of <see cref="BrowserAutomationTool"/> for deserialization. </summary>
    internal BrowserAutomationTool() : base(ResponseToolKind.BrowserAutomation)
    {
    }
}

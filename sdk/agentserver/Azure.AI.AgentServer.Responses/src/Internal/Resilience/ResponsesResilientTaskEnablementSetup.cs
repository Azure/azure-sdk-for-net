// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>Maps the effective Responses durability option onto the shared Core runtime gate.</summary>
internal sealed class ResponsesResilientTaskEnablementSetup :
    IPostConfigureOptions<ResilientTaskOptions>
{
    private readonly IOptions<ResponsesServerOptions> _responsesOptions;

    public ResponsesResilientTaskEnablementSetup(
        IOptions<ResponsesServerOptions> responsesOptions)
    {
        _responsesOptions = responsesOptions;
    }

    public void PostConfigure(string? name, ResilientTaskOptions options)
    {
        if (_responsesOptions.Value.ResilientBackground)
        {
            options.Enabled = true;
        }
    }
}

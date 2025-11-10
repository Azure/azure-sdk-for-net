// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIResponseClient : OpenAIResponseClient
{
    private readonly string _agentName;
    private readonly string _agentVersion;

    internal ProjectOpenAIResponseClient(ClientPipeline pipeline, OpenAIClientOptions options, string agentName, string agentVersion, string model)
        : base(pipeline, model, options)
    {
        _agentName = agentName;
        _agentVersion = agentVersion;
    }

    protected ProjectOpenAIResponseClient()
    { }
}

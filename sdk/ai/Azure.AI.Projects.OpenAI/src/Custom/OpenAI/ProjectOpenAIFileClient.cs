// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Files;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIFileClient : OpenAIFileClient
{
    internal ProjectOpenAIFileClient(ClientPipeline pipeline, OpenAIClientOptions options)
        : base(pipeline, options)
    {
    }

    protected ProjectOpenAIFileClient()
    { }
}

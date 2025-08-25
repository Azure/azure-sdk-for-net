// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Chat;

internal partial class AzureChatClient : ChatClient
{
    internal override PipelineMessage CreateCompleteChatRequest(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint, _apiVersion, _deploymentName)
            .WithPath("chat", "completions")
            .WithMethod("POST")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}

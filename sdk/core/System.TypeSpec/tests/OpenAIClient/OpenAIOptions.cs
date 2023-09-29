// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest;

namespace OpenAI;

public class OpenAIOptions : RequestOptions
{
    public static OpenAIOptions Default { get; private set; }

    // TODO: this should use static default transport, once it's moved to SM.Rest
    public OpenAIOptions() : base(MessagePipelineTransport.Default)
    {}

    static OpenAIOptions()
    {
        Default = new OpenAIOptions();
        Default.GetPipeline();
    }
}

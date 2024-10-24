// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class MessageLoggingPolicy : PipelinePolicy
{
    private readonly ClientLoggingOptions _options;
    private readonly PipelineMessageLogger _logger;

    public MessageLoggingPolicy(ClientLoggingOptions options)
    {
        _options = options;
        _logger = new PipelineMessageLogger(options.GetSanitizer(), options.LoggerFactory);
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _logger.LogRequest(message.Request, null /*TODO: get assembly name */);

        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _logger.LogRequest(message.Request, null /*TODO: get assembly name */);

        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

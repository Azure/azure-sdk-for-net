// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal class PipelineRetryLogger
{
    private readonly ILogger<ClientRetryPolicy>? _logger;

    public PipelineRetryLogger(ILoggerFactory? loggerFactory)
    {
        _logger = loggerFactory?.CreateLogger<ClientRetryPolicy>() ?? null;
    }
}

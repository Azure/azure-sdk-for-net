// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal class ClientPipelineLogger
{
    private readonly ILoggerFactory? _loggerFactory;

    public ClientPipelineLogger(ILoggerFactory? loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
}

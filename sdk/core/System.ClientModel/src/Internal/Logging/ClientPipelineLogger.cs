// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal partial class ClientPipelineLogger
{
    public static ClientRetryLogger GetRetryLogger(ILoggerFactory? loggerFactory)
    {
        throw new NotImplementedException();
    }

    public static PipelineMessageLogger GetMessageLogger(ILoggerFactory? loggerFactory)
    {
        throw new NotImplementedException();
    }

    public static PipelineTransportLogger GetTransportLogger(ILoggerFactory? loggerFactory)
    {
        throw new NotImplementedException();
    }


}

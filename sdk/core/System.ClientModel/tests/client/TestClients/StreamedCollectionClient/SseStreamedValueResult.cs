// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net.ServerSentEvents;
using System.Threading;

namespace ClientModel.Tests.Collections;

public static class SseStreamedValueResult
{
    public static AsyncStreamingClientResult<SseItem<StreamedValue>> Create(
        PipelineResponse response,
        CancellationToken cancellationToken = default)
        => AsyncStreamingClientResult.CreateSse(
            response,
            static (_, data) => StreamedValue.FromJson(data.ToArray()),
            static item => item.Data.ToString() == "[DONE]",
            cancellationToken);
}

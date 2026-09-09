// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace ClientModel.Tests.Collections;

public static class JsonlStreamedValueResult
{
    public static AsyncStreamingClientResult<StreamedValue> Create(
        PipelineResponse response,
        CancellationToken cancellationToken = default)
        => AsyncStreamingClientResult.CreateJsonLines(
            response,
            static data => StreamedValue.FromJson(data.ToArray()),
            cancellationToken);
}

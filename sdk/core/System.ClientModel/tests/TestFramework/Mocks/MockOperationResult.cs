// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockOperationResult : OperationResult
{
    // Count of responses to compete the operation after.
    private readonly int _completeAfterCount;

    private int _updateCount;

    internal MockOperationResult(PipelineResponse response, int completeAfterCount = 2) : base(response)
    {
        _completeAfterCount = completeAfterCount;
    }

    public Action? OnUpdate { get; set; }

    public override bool IsCompleted { get; protected set; }

    public override ContinuationToken? RehydrationToken { get; protected set; }

    public override ValueTask<ClientResult> UpdateStatusAsync(RequestOptions? options = null)
    {
        ClientResult result = UpdateStatus(options);

        return new ValueTask<ClientResult>(result);
    }

    public override ClientResult UpdateStatus(RequestOptions? options = null)
    {
        _updateCount++;

        if (_updateCount >= _completeAfterCount)
        {
            IsCompleted = true;
        }

        MockPipelineResponse response = new MockPipelineResponse(200);

        SetRawResponse(response);

        OnUpdate?.Invoke();

        return ClientResult.FromResponse(response);
    }
}

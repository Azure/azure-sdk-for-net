// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests.TestFramework
{
    public sealed class TestOperation<T> : Operation<T>
    {
        TimeSpan _after;
        T _finalResult;
        Response _finalResponse;

        bool _completed;
        DateTimeOffset _started;

        public override bool HasCompleted => _completed;

        public override bool HasValue => _completed;

        public Action UpdateCalled { get; set; }

        internal TestOperation(string id, TimeSpan after, T finalResult, Response finalResponse)
            : base(id)
        {
            _after = after;
            _finalResult = finalResult;
            _finalResponse = finalResponse;
            _started = DateTimeOffset.UtcNow;
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            UpdateStatus(cancellationToken);
            return new ValueTask<Response>(GetRawResponse());
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            UpdateCalled?.Invoke();

            if (DateTimeOffset.UtcNow - _started > _after)
            {
                _completed = true;
                Value = _finalResult;
                SetRawResponse(_finalResponse);
            }
            return null;
        }
    }
}

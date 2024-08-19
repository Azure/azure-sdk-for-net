// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests.TestFramework
{
    internal sealed class TestOperation<T> : Operation<T> where T: struct
    {
        private TimeSpan _after;
        private readonly T _finalResult;
        private readonly Response _finalResponse;

        private bool _completed;
        private DateTimeOffset _started;

        private T? _value;
        private Response _rawResponse;

        public override string Id { get; }
        public override bool HasCompleted => _completed;
        public override bool HasValue => _completed;
        public override Response GetRawResponse() => _rawResponse;
        public override T Value => GetValue(ref _value);

        public Action UpdateCalled { get; set; }

        internal TestOperation(string id, TimeSpan after, T finalResult, Response finalResponse)
        {
            Id = id;
            _after = after;
            _finalResult = finalResult;
            _finalResponse = finalResponse;
            _started = DateTimeOffset.UtcNow;
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            UpdateStatus(cancellationToken);
            return new ValueTask<Response>(GetRawResponse() ?? new MockResponse(200));
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            UpdateCalled?.Invoke();

            if (DateTimeOffset.UtcNow - _started > _after)
            {
                _completed = true;
                _value = _finalResult;
                _rawResponse = _finalResponse;
            }
            return null;
        }
    }
}

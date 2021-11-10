// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests.TestFramework
{
    internal sealed class TestPageableOperation<T> : PageableOperation<T> where T : struct
    {
        private TimeSpan _after;
        private readonly Response _finalResponse;
        private Response _rawResponse;

        private bool _completed;
        private DateTimeOffset _started;

        private Page<T> _firstPage;
        private readonly Page<T> _expectedFirstPage;
        private readonly Page<T> _secondPage;

        public override string Id { get; }
        public override bool HasCompleted => _completed;
        public override bool HasValue => _completed;
        public override Response GetRawResponse() => _rawResponse;
        public override AsyncPageable<T> Value => GetValuesAsync();

        public Action UpdateCalled { get; set; }

        internal TestPageableOperation(string id, TimeSpan after, Page<T> expectedFirstPage, Page<T> secondPage, Response finalResponse)
        {
            Id = id;
            _after = after;
            _expectedFirstPage = expectedFirstPage;
            _secondPage = secondPage;
            _finalResponse = finalResponse;
            _started = DateTimeOffset.UtcNow;
        }

        public override Pageable<T> GetValues(CancellationToken cancellationToken = default)
        {
            if (!HasValue)
                throw new InvalidOperationException("The operation has not completed yet.");
            return Pageable<T>.FromPages(new[]
            {
                _firstPage,
                _secondPage
            });
        }

        public override AsyncPageable<T> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            if (!HasValue)
                throw new InvalidOperationException("The operation has not completed yet.");
            return AsyncPageable<T>.FromPages(new[]
            {
                _firstPage,
                _secondPage
            });
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            UpdateCalled?.Invoke();

            if (DateTimeOffset.UtcNow - _started > _after)
            {
                _completed = true;
                _firstPage = _expectedFirstPage;
                _rawResponse = _finalResponse;
            }
            return null;
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            UpdateStatus(cancellationToken);
            return new ValueTask<Response>(GetRawResponse() ?? new MockResponse(200));
        }
    }
}

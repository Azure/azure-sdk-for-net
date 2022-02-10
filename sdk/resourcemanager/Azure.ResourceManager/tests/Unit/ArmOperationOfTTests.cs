using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ArmOperationOfTTests
    {
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 3)]
        [TestCase(4, 7)]
        [TestCase(5, 15)]
        [TestCase(6, 31)]
        [TestCase(7, 63)]
        [TestCase(8, 95)]
        public async Task DefaultPollingIntervalIsExponential(int count, int totalSeconds)
        {
            var start = DateTimeOffset.Now;
            var operation = new TestPollingOperation<int>(count);
            await operation.WaitForCompletionAsync();
            var duration = DateTimeOffset.Now - start;
            Assert.That(duration.TotalSeconds, Is.EqualTo(totalSeconds).Within(1));
        }

        [TestCase(1, 0)]
        [TestCase(2, 5)]
        [TestCase(3, 10)]
        public async Task ServerResponseOverDefaultPollingInterval(int count, int totalSeconds)
        {
            var start = DateTimeOffset.Now;
            var operation = new TestPollingOperation<int>(count, 5);
            await operation.WaitForCompletionAsync();
            var duration = DateTimeOffset.Now - start;
            Assert.That(duration.TotalSeconds, Is.EqualTo(totalSeconds).Within(1));
        }

        private class TestPollingOperation<T> : ArmOperation<T>
        {
            private MockResponse _response;

            private int _retryCount;
            private int _retryAfter;

            public override string Id { get; }

            public override bool HasCompleted => _retryCount == 0;

            public override T Value => default;

            public override bool HasValue => HasCompleted;

            public override Response GetRawResponse() => _response;

            public TestPollingOperation(int retryCount, int retryAfter = default)
            {
                _retryCount = retryCount;
                _retryAfter = retryAfter;
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                if (_retryCount > 1)
                {
                    _response = new MockResponse(202);
                    if (_retryAfter > 0)
                    {
                        _response.AddHeader("Retry-After", $"{_retryAfter}");
                    }
                }
                else
                {
                    _response = new MockResponse(200);
                }
                _retryCount--;
                return _response;
            }

            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                UpdateStatus(cancellationToken);
                return new ValueTask<Response>(GetRawResponse());
            }
        }

    }
}

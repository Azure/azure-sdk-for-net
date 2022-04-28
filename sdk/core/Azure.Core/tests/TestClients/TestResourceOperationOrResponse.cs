// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class TestResourceOperationOrResponse : Operation
    {
        private TestResource _value;
        private bool _exceptionOnWait;
        private OperationOrResponseInternals<TestResource> _operationHelper;
        private int _delaySteps = 0;

        protected TestResourceOperationOrResponse()
        {
        }

        public TestResourceOperationOrResponse(TestResource value, bool exceptionOnWait = false, int delaySteps = 0)
        {
            _value = value;
            _exceptionOnWait = exceptionOnWait;
            _operationHelper = new OperationOrResponseInternals<TestResource>(Response.FromValue(value, new MockResponse(200)));
            _delaySteps = delaySteps;
        }

        public override string Id => "testId";

        public override bool HasCompleted => _operationHelper.HasCompleted;

        public override Response GetRawResponse() => _operationHelper.GetRawResponse();

        public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return _operationHelper.WaitForCompletionResponse(cancellationToken);
        }

        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return _operationHelper.WaitForCompletionResponse(pollingInterval, cancellationToken);
        }

        public async override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await _operationHelper.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
        }

        public async override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await _operationHelper.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatusAsync(cancellationToken);

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatus(cancellationToken);
    }
}

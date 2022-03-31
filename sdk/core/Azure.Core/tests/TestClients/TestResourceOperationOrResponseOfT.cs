// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class TestResourceOperationOrResponseOfT : Operation<TestResource>, IOperationSource<TestResource>
    {
        private TestResource _value;
        private bool _exceptionOnWait;
        private OperationOrResponseInternals<TestResource> _operationHelper;
        private int _delaySteps = 0;

        protected TestResourceOperationOrResponseOfT()
        {
        }

        public TestResourceOperationOrResponseOfT(TestResource value, bool exceptionOnWait = false, int delaySteps = 0)
        {
            _value = value;
            _exceptionOnWait = exceptionOnWait;
            _operationHelper = new OperationOrResponseInternals<TestResource>(Response.FromValue(value, new MockResponse(200)));
            _delaySteps = delaySteps;
        }

        public override string Id => "testId";

        public override TestResource Value => _operationHelper.Value;

        public override bool HasCompleted => _operationHelper.HasCompleted;

        public override bool HasValue => _operationHelper.HasValue;

        public override Response GetRawResponse() => _operationHelper.GetRawResponse();

        public override Response<TestResource> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return _operationHelper.WaitForCompletion(cancellationToken);
        }

        public override Response<TestResource> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return _operationHelper.WaitForCompletion(pollingInterval, cancellationToken);
        }

        public async override ValueTask<Response<TestResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return await _operationHelper.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async override ValueTask<Response<TestResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return await _operationHelper.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return _operationHelper.UpdateStatusAsync(cancellationToken);
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return _operationHelper.UpdateStatus(cancellationToken);
        }

        public TestResource CreateResult(Response response, CancellationToken cancellationToken)
        {
            return _value;
        }

        public ValueTask<TestResource> CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return new ValueTask<TestResource>(_value);
        }
    }
}

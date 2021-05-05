// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class ArmOperationTest : ArmOperation<TestResource>, IOperationSource<TestResource>
    {
        private TestResource _value;
        private bool _exceptionOnWait;
        private OperationOrResponseInternals<TestResource> _operationHelper;

        protected ArmOperationTest()
        {
        }

        public ArmOperationTest(TestResource value, bool exceptionOnWait = false)
        {
            _value = value;
            _exceptionOnWait = exceptionOnWait;
            _operationHelper = new OperationOrResponseInternals<TestResource>(Response.FromValue(value, new MockResponse(200)));
        }

        public override string Id => "testId";

        public override TestResource Value => _operationHelper.Value;

        public override bool HasCompleted => _operationHelper.HasCompleted;

        public override bool HasValue => _operationHelper.HasValue;

        public override Response GetRawResponse() => _operationHelper.GetRawResponse();

        public override ValueTask<Response<TestResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return new ValueTask<Response<TestResource>>(Response.FromValue(_value, new MockResponse(200)));
        }

        public override ValueTask<Response<TestResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return new ValueTask<Response<TestResource>>(Response.FromValue(_value, new MockResponse(200)));
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatusAsync(cancellationToken);

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatus(cancellationToken);

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

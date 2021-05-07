// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    public class PhArmOperationTest<T> : Operation<T>
        where T : class
    {
        private OperationOrResponseInternals<T> _operationHelper;

        public override T Value => _operationHelper.Value;

        public override bool HasValue => _operationHelper.HasValue;

        public override string Id => "MyId";

        public override bool HasCompleted => _operationHelper.HasCompleted;

        protected PhArmOperationTest()
        {
        }

        public PhArmOperationTest(T value)
        {
            _operationHelper = new OperationOrResponseInternals<T>(Response.FromValue(value, new MockResponse(200)));
        }

        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operationHelper.WaitForCompletionAsync(cancellationToken);

        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _operationHelper.WaitForCompletionAsync(pollingInterval, cancellationToken);

        public override Response GetRawResponse() => _operationHelper.GetRawResponse();

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatusAsync(cancellationToken);

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationHelper.UpdateStatus(cancellationToken);
    }
}

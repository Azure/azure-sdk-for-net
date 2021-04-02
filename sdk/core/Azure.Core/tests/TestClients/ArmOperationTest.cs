// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class ArmOperationTest<T> : ArmOperation<T>
        where T : class
    {
        private T _value;
        protected ArmOperationTest()
        {
        }

        public ArmOperationTest(T value)
        {
            _value = value;
        }

        public override string Id => "testId";

        public override T Value => _value;

        public override bool HasCompleted => true;

        public override bool HasValue => true;

        public override Response GetRawResponse()
        {
            return Response.FromValue(_value, null) as Response;
        }

        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return new ValueTask<Response<T>>(Response.FromValue(_value, null));
        }

        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return new ValueTask<Response<T>>(Response.FromValue(_value, null));
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return new ValueTask<Response>(Response.FromValue(_value, null) as Response);
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return Response.FromValue(_value, null) as Response;
        }
    }
}

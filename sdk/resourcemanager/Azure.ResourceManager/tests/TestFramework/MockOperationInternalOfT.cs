// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
#pragma warning disable SA1649 // File name should match first type name
    internal class MockOperationInternal<TResult> : OperationInternal<TResult>, IMockOperationInternal
#pragma warning restore SA1649 // File name should match first type name
    {
        public MockOperationInternal(
            ClientDiagnostics clientDiagnostics,
            IOperation<TResult> operation,
            Func<MockResponse> responseFactory,
            string operationTypeName,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes,
            DelayStrategy pollingStrategy)
            : base(operation, clientDiagnostics, responseFactory(), operationTypeName, scopeAttributes, pollingStrategy)
        { }

        public List<TimeSpan> DelaysPassedToWait { get; set; } = new();

        public CancellationToken LastTokenReceivedByUpdateStatus { get; set; }

        public int UpdateStatusCallCount { get; set; }
        public int? CallsToComplete { get; set; }
    }
}

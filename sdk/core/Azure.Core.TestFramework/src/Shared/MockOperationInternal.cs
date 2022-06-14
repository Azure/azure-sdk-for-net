﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class MockOperationInternal : OperationInternal, IMockOperationInternal
    {
        public MockOperationInternal(
            ClientDiagnostics clientDiagnostics,
            IOperation operation,
            Func<MockResponse> responseFactory,
            string operationTypeName,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes,
            DelayStrategy pollingStrategy)
            : base(clientDiagnostics, operation, responseFactory(), operationTypeName, scopeAttributes, pollingStrategy)
        { }

        public List<TimeSpan> DelaysPassedToWait { get; set; } = new();

        public CancellationToken LastTokenReceivedByUpdateStatus { get; set; }

        public int UpdateStatusCallCount { get; set; }
        public int? CallsToComplete { get; set; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class MockOperationOfInt : MockOperation<int>
    {
        public MockOperationOfInt(
            UpdateResult result,
            Func<MockResponse> responseFactory,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null,
            DelayStrategy fallbackStrategy = null,
            bool exceptionOnWait = false,
            Exception customExceptionOnUpdate = null,
            RequestFailedException originalExceptionOnUpdate = null)
            : base(50, result, responseFactory, operationTypeName, scopeAttributes, callsToComplete, fallbackStrategy, exceptionOnWait, customExceptionOnUpdate, originalExceptionOnUpdate)
        {
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ComputeClientMockBase : MockTestBase
    {
        public ComputeClientMockBase(bool isAsync) : base(isAsync)
        {
        }

        public ComputeClientMockBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public string Location => "westus";
    }
}

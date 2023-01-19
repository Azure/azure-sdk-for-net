// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Workflows.Tests
{
    public class WorkflowsClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Workflows_ENDPOINT");

        // Add other client paramters here as above.
    }
}

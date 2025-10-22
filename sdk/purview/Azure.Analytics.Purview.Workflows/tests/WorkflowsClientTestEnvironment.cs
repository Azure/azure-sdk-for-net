// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Workflows.Tests
{
    public class WorkflowsClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("WORKFLOW_ENDPOINT"));
    }
}

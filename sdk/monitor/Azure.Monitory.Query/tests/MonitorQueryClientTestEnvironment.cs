// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template.Tests
{
    public class MonitorQueryClientTestEnvironment : TestEnvironment
    {
        public string WorkspaceId => GetRecordedVariable("WORKSPACE_ID");
    }
}

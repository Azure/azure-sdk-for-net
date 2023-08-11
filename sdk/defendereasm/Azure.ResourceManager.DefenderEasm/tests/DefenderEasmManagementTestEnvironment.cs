// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.DefenderEasm.Tests
{
    public class DefenderEasmManagementTestEnvironment : TestEnvironment
    {
        public string ResourceGroupName => GetRecordedVariable("RESOURCEGROUPNAME", options => options.IsSecret());
        public string WorkspaceName => GetRecordedVariable("WORKSPACENAME", options => options.IsSecret());
    }
}

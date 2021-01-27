// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientTestEnvironment : TestEnvironment
    {
        public string WorkspaceLocation => GetRecordedVariable("WORKSPACE_LOCATION");
    }
}

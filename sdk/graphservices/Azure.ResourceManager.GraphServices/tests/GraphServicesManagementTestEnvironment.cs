// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.GraphServices.Tests
{
    public class GraphServicesManagementTestEnvironment : TestEnvironment
    {
        public string ApplicationClientId => GetRecordedVariable("AZURE_CLIENT_ID");
    }
}

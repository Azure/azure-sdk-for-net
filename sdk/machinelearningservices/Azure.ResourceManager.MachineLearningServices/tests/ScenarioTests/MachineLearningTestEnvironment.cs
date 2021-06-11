// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class MachineLearningTestEnvironment: TestEnvironment
    {
        public new string TenantId => GetVariable("AZURE_TENANT_ID");

        /// <summary>
        /// Service principal object ID used to assign access policies.
        /// </summary>
        public string ObjectId => GetVariable("AZURE_CLIENT_OBJECT_ID");
    }
}

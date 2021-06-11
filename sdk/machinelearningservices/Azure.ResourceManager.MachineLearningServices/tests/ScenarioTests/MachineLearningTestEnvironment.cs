// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class MachineLearningTestEnvironment: TestEnvironment
    {
        //// Variables retrieved using GetRecordedVariable will be recorded in recorded tests
        //// Argument is the output name in the test-resources.json
        //public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT");
        // Variables retrieved using GetVariable will not be recorded but the method will throw if the variable is not set
        public new string TenantId => GetVariable("AZURE_TENANT_ID");

        /// <summary>
        /// Service principal object ID used to assign access policies.
        /// </summary>
        public string ObjectId => GetVariable("AZURE_CLIENT_OBJECT_ID");
        //// Variables retrieved using GetOptionalVariable will not be recorded and the method will return null if variable is not set
        //public string TestPassword => GetOptionalVariable("AZURE_IDENTITY_TEST_PASSWORD") ?? "SANITIZED";

        // todo: storage account id, key vault id, ...
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class LoadTestServiceManagementTestEnvironment : TestEnvironment
    {
        public string LOADTESTSERVICE_CLIENT_ID => GetVariable("LOADTESTSERVICE_CLIENT_ID");
        public string LOADTESTSERVICE_CLIENT_SECRET => GetVariable("LOADTESTSERVICE_CLIENT_SECRET");
        public string LOADTESTSERVICE_TENANT_ID => GetVariable("LOADTESTSERVICE_TENANT_ID");
        public string LOADTESTSERVICE_SUBSCRIPTION_ID => GetVariable("LOADTESTSERVICE_SUBSCRIPTION_ID");
        public string LOADTESTSERVICE_RESOURCE_GROUP => GetVariable("LOADTESTSERVICE_RESOURCE_GROUP");
        public string LOADTESTSERVICE_RESOURCE_NAME => "loadtestsdk-resource-dotnet";
        public string LOADTESTSERVICE_LOCATION => GetVariable("LOADTESTSERVICE_LOCATION");
        public string LOADTESTSERVICE_ENVIRONMENT => GetVariable("LOADTESTSERVICE_ENVIRONMENT");
        public string LOADTESTSERVICE_AZURE_AUTHORITY_HOST => GetVariable("LOADTESTSERVICE_AZURE_AUTHORITY_HOST");
        public string LOADTESTSERVICE_RESOURCE_MANAGER_URL => GetVariable("LOADTESTSERVICE_RESOURCE_MANAGER_URL");
        public string LOADTESTSERVICE_SERVICE_MANAGEMENT_URL => GetVariable("LOADTESTSERVICE_SERVICE_MANAGEMENT_URL");
        public string AZURE_SERVICE_DIRECTORY => GetVariable("AZURE_SERVICE_DIRECTORY");
    }
}

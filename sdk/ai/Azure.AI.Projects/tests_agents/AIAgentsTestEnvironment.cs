// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.Tests
{
    public class AIAgentsTestEnvironment : TestEnvironment
    {
        public string PROJECT_ENDPOINT => GetRecordedVariable("PROJECT_ENDPOINT");
        public string AGENT_NAME => GetRecordedVariable("AZURE_AI_FOUNDRY_AGENT_NAME");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string COMPUTER_USE_DEPLOYMENT_NAME => GetRecordedVariable("COMPUTER_USE_DEPLOYMENT_NAME");

        public override Dictionary<string, string> ParseEnvironmentFile() => new()
        {
            { "OPEN-API-KEY", Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "api-key" }
        };

        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }

        public override AuthenticationTokenProvider Credential => Mode switch
        {
            RecordedTestMode.Live or RecordedTestMode.Record => new DefaultAzureCredential(),
            _ => base.Credential
        };
        public string EMBEDDINGMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
        public string CONTAINER_APP_RESOURCE_ID => GetRecordedVariable("CONTAINER_APP_RESOURCE_ID");
        public string INGRESS_SUBDOMAIN_SUFFIX => GetRecordedVariable("INGRESS_SUBDOMAIN_SUFFIX");
        public string OPENAI_FILE_ID => GetRecordedVariable("OPENAI_FILE_ID");
        public string COMPUTER_SCREENSHOTS => GetRecordedVariable("COMPUTER_SCREENSHOTS");
        public string IMAGE_GENERATION_DEPLOYMENT_NAME => GetRecordedVariable("IMAGE_GENERATION_DEPLOYMENT_NAME");
        public string AI_SEARCH_CONNECTION_NAME => GetRecordedVariable("AI_SEARCH_CONNECTION_NAME");
        public string BING_CONNECTION_ID => GetRecordedVariable("BING_CONNECTION_ID");
        public string CUSTOM_BING_CONNECTION_ID => GetRecordedVariable("CUSTOM_BING_CONNECTION_ID");
        public string BING_CUSTOM_SEARCH_INSTANCE_NAME => GetRecordedVariable("BING_CUSTOM_SEARCH_INSTANCE_NAME");
        public string MCP_PROJECT_CONNECTION_NAME => GetRecordedOptionalVariable("MCP_PROJECT_CONNECTION_NAME");
        public string OPENAPI_PROJECT_CONNECTION_NAME => GetRecordedOptionalVariable("OPENAPI_PROJECT_CONNECTION_NAME");
        public string PLAYWRIGHT_CONNECTION_ID => GetRecordedOptionalVariable("PLAYWRIGHT_CONNECTION_ID");
        public string OPENAPI_PROJECT_CONNECTION_ID => GetRecordedOptionalVariable("OPENAPI_PROJECT_CONNECTION_ID");
        public string SHAREPOINT_CONNECTION_ID => GetRecordedOptionalVariable("SHAREPOINT_CONNECTION_ID");
    }
}

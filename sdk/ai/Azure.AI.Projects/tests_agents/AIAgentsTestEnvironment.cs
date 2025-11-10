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
    }
}

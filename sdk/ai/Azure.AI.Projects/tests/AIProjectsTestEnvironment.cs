// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using System;

namespace Azure.AI.Projects.Tests
{
    public class AIProjectsTestEnvironment : TestEnvironment
    {
        public string PROJECT_ENDPOINT => GetRecordedVariable(nameof(PROJECT_ENDPOINT), options => options.IsSecret("https://sanitized-host.services.ai.azure.com/api/projects/sanitized-project"));
        public string DATASETNAME => GetRecordedVariable("DATASET_NAME");
        public string DATASETVERSION1 => GetRecordedVariable("DATASET_VERSION_1");
        public string DATASETVERSION2 => GetRecordedVariable("DATASET_VERSION_2");
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
        public string TEXTEMBEDDINGSMODELDEPLOYMENTNAME => GetRecordedVariable("TEXT_EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
        public string MODELPUBLISHER => GetRecordedVariable("MODEL_PUBLISHER");
        public string INDEX_NAME => GetRecordedVariable(nameof(INDEX_NAME));
        public string INDEX_VERSION => GetRecordedVariable(nameof(INDEX_VERSION));
        public string AI_SEARCH_CONNECTION_NAME => GetRecordedVariable(nameof(AI_SEARCH_CONNECTION_NAME));
        public string AI_SEARCH_INDEX_NAME => GetRecordedVariable(nameof(AI_SEARCH_INDEX_NAME));
        public string STORAGECONNECTIONNAME => GetRecordedVariable("STORAGE_CONNECTION_NAME");
        public string STORAGECONNECTIONTYPE => GetRecordedVariable("STORAGE_CONNECTION_TYPE");
        public string AOAI_CONNECTION_NAME => GetRecordedVariable(nameof(AOAI_CONNECTION_NAME));
        public string TESTIMAGEPNGINPUTPATH => GetRecordedVariable("TEST_IMAGE_PNG_INPUT_PATH");
        public string SAMPLEFILEPATH => GetRecordedVariable("SAMPLE_FILE_PATH");
        public string SAMPLEFOLDERPATH => GetRecordedVariable("SAMPLE_FOLDER_PATH");
        public string MODEL_ENDPOINT => GetRecordedVariable(nameof(MODEL_ENDPOINT), options => options.IsSecret("https://sanitized.openai.azure.com/"));
        public string MODEL_API_KEY => GetRecordedVariable(nameof(MODEL_API_KEY), options => options.IsSecret("Sanitized"));
        // The Fine tuning environment variables
        public string FINE_TUNING_COMPLETED_JOB => GetRecordedVariable(nameof(FINE_TUNING_COMPLETED_JOB));
        public string FINE_TUNING_AZURE_SUBSCRIPTION_ID => GetRecordedVariable(nameof(FINE_TUNING_AZURE_SUBSCRIPTION_ID));
        public string FINE_TUNING_AZURE_RESOURCE_GROUP => GetRecordedVariable(nameof(FINE_TUNING_AZURE_RESOURCE_GROUP));
        public string FINE_TUNING_AZURE_FOUNDRY_NAME => GetRecordedVariable(nameof(FINE_TUNING_AZURE_FOUNDRY_NAME));
        public string FINE_TUNING_DEPLOYMENT_ID => GetRecordedVariable(nameof(FINE_TUNING_DEPLOYMENT_ID));
        // Agents specific environment variables.
        public string OPENAI_FILE_ID => GetRecordedVariable(nameof(OPENAI_FILE_ID));
        public string MCP_PROJECT_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(MCP_PROJECT_CONNECTION_NAME));
        public string OPENAPI_PROJECT_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(OPENAPI_PROJECT_CONNECTION_NAME));
        public string PLAYWRIGHT_CONNECTION_ID => GetRecordedOptionalVariable(nameof(PLAYWRIGHT_CONNECTION_ID));
        public string OPENAPI_PROJECT_CONNECTION_ID => GetRecordedOptionalVariable(nameof(OPENAPI_PROJECT_CONNECTION_ID));
        public string SHAREPOINT_CONNECTION_ID => GetRecordedOptionalVariable(nameof(SHAREPOINT_CONNECTION_ID));
        public string FABRIC_CONNECTION_ID => GetRecordedOptionalVariable(nameof(FABRIC_CONNECTION_ID));
        public string A2A_CONNECTION_ID => GetRecordedOptionalVariable(nameof(A2A_CONNECTION_ID));
        public string REMOTE_A2A_CONNECTION_ID => GetRecordedOptionalVariable("A2A_SPECIAL_CONNECTION_ID");
        public string A2A_BASE_URI => GetRecordedOptionalVariable("A2A_BASE_URI");
        public string IMAGE_GENERATION_DEPLOYMENT_NAME => GetRecordedVariable(nameof(IMAGE_GENERATION_DEPLOYMENT_NAME));
        public string BING_CONNECTION_ID => GetRecordedVariable(nameof(BING_CONNECTION_ID));
        public string CUSTOM_BING_CONNECTION_ID => GetRecordedVariable(nameof(CUSTOM_BING_CONNECTION_ID));
        public string BING_CUSTOM_SEARCH_INSTANCE_NAME => GetRecordedVariable(nameof(BING_CUSTOM_SEARCH_INSTANCE_NAME));
        public string COMPUTER_USE_DEPLOYMENT_NAME => GetRecordedVariable(nameof(COMPUTER_USE_DEPLOYMENT_NAME));
        public string COMPUTER_SCREENSHOTS => GetRecordedVariable(nameof(COMPUTER_SCREENSHOTS));
        public string CONTAINER_APP_RESOURCE_ID => GetRecordedVariable(nameof(CONTAINER_APP_RESOURCE_ID));
        public string INGRESS_SUBDOMAIN_SUFFIX => GetRecordedVariable(nameof(INGRESS_SUBDOMAIN_SUFFIX));
        public string APPLICATIONINSIGHTS_CONNECTION_STRING => GetRecordedVariable(nameof(APPLICATIONINSIGHTS_CONNECTION_STRING), options => options.IsSecret("Sanitized"));
        public string AGENT_DOCKER_IMAGE => GetRecordedOptionalVariable(nameof(AGENT_DOCKER_IMAGE));
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
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.OpenAI.Tests
{
    public class ProjectsOpenAITestEnvironment : TestEnvironment
    {
        public string PROJECT_ENDPOINT => WrappedGetRecordedVariable(nameof(PROJECT_ENDPOINT), isSecret: false);
        public string AGENT_NAME => WrappedGetRecordedVariable("AZURE_AI_FOUNDRY_AGENT_NAME", isSecret: false);
        public string MODELDEPLOYMENTNAME => WrappedGetRecordedVariable("MODEL_DEPLOYMENT_NAME", isSecret: false);
        public string EMBEDDINGMODELDEPLOYMENTNAME => WrappedGetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME", isSecret: false);
        public string INGRESS_SUBDOMAIN_SUFFIX => WrappedGetRecordedVariable(nameof(INGRESS_SUBDOMAIN_SUFFIX), isSecret: false);
        public string OPENAI_FILE_ID => WrappedGetRecordedVariable(nameof(OPENAI_FILE_ID), isSecret: false    );
        public string COMPUTER_SCREENSHOTS => WrappedGetRecordedVariable(nameof(COMPUTER_SCREENSHOTS), isSecret: false);
        public string IMAGE_GENERATION_DEPLOYMENT_NAME => WrappedGetRecordedVariable(nameof(IMAGE_GENERATION_DEPLOYMENT_NAME), isSecret: false);
        public string COMPUTER_USE_DEPLOYMENT_NAME => WrappedGetRecordedVariable(nameof(COMPUTER_USE_DEPLOYMENT_NAME), isSecret: false);
        public string CONTAINER_APP_RESOURCE_ID => WrappedGetRecordedVariable(nameof(CONTAINER_APP_RESOURCE_ID), isSecret: false);
        public string KNOWN_CONVERSATION_ID => WrappedGetRecordedVariable(nameof(KNOWN_CONVERSATION_ID), isSecret: false);
        public string PARITY_OPENAI_API_KEY => WrappedGetRecordedVariable("OPENAI_API_KEY");
        public string AI_SEARCH_CONNECTION_NAME => GetRecordedVariable(nameof(AI_SEARCH_CONNECTION_NAME));
        public string BING_CONNECTION_NAME => GetRecordedVariable(nameof(BING_CONNECTION_NAME));
        public string CUSTOM_BING_CONNECTION_NAME => GetRecordedVariable(nameof(CUSTOM_BING_CONNECTION_NAME));
        public string BING_CUSTOM_SEARCH_INSTANCE_NAME => GetRecordedVariable(nameof(BING_CUSTOM_SEARCH_INSTANCE_NAME));
        public string MCP_PROJECT_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(MCP_PROJECT_CONNECTION_NAME));
        public string PLAYWRIGHT_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(PLAYWRIGHT_CONNECTION_NAME));
        public string SHAREPOINT_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(SHAREPOINT_CONNECTION_NAME));
        public string FABRIC_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(FABRIC_CONNECTION_NAME));
        public string A2A_CONNECTION_NAME => GetRecordedOptionalVariable(nameof(A2A_CONNECTION_NAME));
        public string A2A_BASE_URI => GetRecordedOptionalVariable(nameof(A2A_BASE_URI));
        public string PUBLISHED_ENDPOINT => GetRecordedOptionalVariable(nameof(PUBLISHED_ENDPOINT));
        public string APPLICATIONINSIGHTS_CONNECTION_STRING => WrappedGetRecordedVariable(nameof(APPLICATIONINSIGHTS_CONNECTION_STRING), isSecret: true);
        public string AGENT_DOCKER_IMAGE => GetRecordedOptionalVariable(nameof(AGENT_DOCKER_IMAGE));
        public string WrappedGetRecordedVariable(string key, bool isSecret = true)
        {
            try
            {
                return GetRecordedVariable(
                    key,
                    options =>
                    {
                        if (isSecret)
                        {
                            options.IsSecret();
                        }
                    });
            }
            catch (InvalidOperationException invalidOperationException)
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    throw new TestRecordingMismatchException($"Failed to retrieve recorded variable '{key}' during playback.", invalidOperationException);
                }
                throw;
            }
        }

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            return new();
        }

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

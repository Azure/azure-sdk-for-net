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
        public string PROJECT_ENDPOINT => WrappedGetRecordedVariable("PROJECT_ENDPOINT", isSecret: false);
        public string AGENT_NAME => WrappedGetRecordedVariable("AZURE_AI_FOUNDRY_AGENT_NAME", isSecret: false);
        public string MODELDEPLOYMENTNAME => WrappedGetRecordedVariable("MODEL_DEPLOYMENT_NAME", isSecret: false);
        public string EMBEDDINGMODELDEPLOYMENTNAME => WrappedGetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME", isSecret: false);
        public string INGRESS_SUBDOMAIN_SUFFIX => WrappedGetRecordedVariable("INGRESS_SUBDOMAIN_SUFFIX", isSecret: false);
        public string OPENAI_FILE_ID => WrappedGetRecordedVariable("OPENAI_FILE_ID", isSecret: false    );
        public string COMPUTER_SCREENSHOTS => WrappedGetRecordedVariable("COMPUTER_SCREENSHOTS", isSecret: false);
        public string IMAGE_GENERATION_DEPLOYMENT_NAME => WrappedGetRecordedVariable("IMAGE_GENERATION_DEPLOYMENT_NAME", isSecret: false);
        public string COMPUTER_USE_DEPLOYMENT_NAME => WrappedGetRecordedVariable("COMPUTER_USE_DEPLOYMENT_NAME", isSecret: false);
        public string CONTAINER_APP_RESOURCE_ID => WrappedGetRecordedVariable("CONTAINER_APP_RESOURCE_ID", isSecret: false);
        public string KNOWN_CONVERSATION_ID => WrappedGetRecordedVariable("KNOWN_CONVERSATION_ID", isSecret: false);
        public string PARITY_OPENAI_API_KEY => WrappedGetRecordedVariable("OPENAI_API_KEY");

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

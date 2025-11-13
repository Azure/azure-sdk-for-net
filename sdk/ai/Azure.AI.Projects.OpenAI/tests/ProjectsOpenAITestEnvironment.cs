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

        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }

        public override AuthenticationTokenProvider Credential => Mode switch
        {
            RecordedTestMode.Live or RecordedTestMode.Record => new DefaultAzureCredential(),
            _ => base.Credential
        };

        public override Dictionary<string, string> ParseEnvironmentFile()
        {
            return new();
        }
    }
}

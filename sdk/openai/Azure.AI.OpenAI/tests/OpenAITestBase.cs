// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public abstract class OpenAITestBase : RecordedTestBase<OpenAITestEnvironment>
    {
        private static class Constants
        {
            public const string CompletionsDeploymentIdVariable = "OPENAI_DEPLOYMENT_ID";
            public const string EmbeddingsDeploymentIdVariable = "OPENAI_EMBEDDINGS_DEPLOYMENT_ID";
            public const string OpenAIAuthTokenVariable = "OPENAI_AUTH_TOKEN";
            public const string EndpointVariable = "OPENAI_ENDPOINT";
            public const string ResourceGroupName = "openai-test-rg";
            public const string CognitiveServicesAccountName = "openai-sdk-test-automation-account-eastus";
            public const string CompletionsModelName = "text-davinci-002";
            public const string ChatCompletionsModelName = "gpt-35-turbo";
            public const string EmbeddingsModelName = "text-similarity-curie-001";
            public const string NonAzureCompletionsModelName = "text-davinci-002";
            public const string NonAzureChatCompletionsModelName = "gpt-3.5-turbo";
            public const string NonAzureEmbeddingsModelName = "text-embedding-ada-002";
            public const string SubDomainPrefix = "sdk";
            public static AzureLocation Location = AzureLocation.EastUS;
        }

        private static readonly object _deploymentIdLock = new object();

        public string CompletionsDeploymentId { get => _completionsDeploymentId; }
        public string ChatCompletionsDeploymentId { get => _chatCompletionsDeploymentId; }
        public string EmbeddingsDeploymentId { get => _embeddingsDeploymentId; }

        public string NonAzureCompletionsModelName => Constants.NonAzureCompletionsModelName;
        public string NonAzureChatCompletionsModelName => Constants.NonAzureChatCompletionsModelName;
        public string NonAzureEmbeddingsModelName => Constants.NonAzureEmbeddingsModelName;

        private Uri _endpoint;
        private AzureKeyCredential _apiKey;
        private string _completionsDeploymentId;
        private string _chatCompletionsDeploymentId;
        private string _embeddingsDeploymentId;
        private string _openAIAuthToken;

        protected OpenAITestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            HeaderRegexSanitizers.Add(new Core.TestFramework.Models.HeaderRegexSanitizer("api-key", "***********"));
        }

        protected OpenAIClient GetAzureUnconfiguredClient() => InstrumentClient(
            new OpenAIClient(_endpoint, GetAzureApiKey(), GetInstrumentedClientOptions()));

        protected OpenAIClient GetAzureCompletionsClient() => InstrumentClient(
            new OpenAIClient(_endpoint, GetAzureApiKey(), GetInstrumentedClientOptions(_completionsDeploymentId)));

        protected OpenAIClient GetAzureCompletionsClientWithTokenCredential() => InstrumentClient(
            new OpenAIClient(_endpoint, TestEnvironment.Credential, GetInstrumentedClientOptions(_completionsDeploymentId)));

        protected OpenAIClient GetAzureChatCompletionsClient() => InstrumentClient(
            new OpenAIClient(_endpoint, GetAzureApiKey(), GetInstrumentedClientOptions(_chatCompletionsDeploymentId)));

        protected OpenAIClient GetAzureEmbeddingsClient() => InstrumentClient(
            new OpenAIClient(_endpoint, GetAzureApiKey(), GetInstrumentedClientOptions(_embeddingsDeploymentId)));

        protected OpenAIClient GetAzureClientWithInvalidDeployment() => InstrumentClient(
            new OpenAIClient(_endpoint, GetAzureApiKey(), GetInstrumentedClientOptions("BAD_DEPLOYMENT_ID")));

        protected OpenAIClient GetNonAzureUnconfiguredClient() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions()));

        protected OpenAIClient GetNonAzureCompletionsClient() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions(Constants.NonAzureCompletionsModelName)));

        protected OpenAIClient GetNonAzureChatCompletionsClient() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions(Constants.NonAzureChatCompletionsModelName)));

        protected OpenAIClient GetNonAzureEmbeddingsClient() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions(Constants.NonAzureEmbeddingsModelName)));

        protected AzureKeyCredential GetAzureApiKey() => _apiKey ?? new AzureKeyCredential("placeholder");
        protected string GetNonAzureApiKey() => string.IsNullOrEmpty(_openAIAuthToken) ? "placeholder" : _openAIAuthToken;

        [SetUp]
        public void CreateDeployment()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                // For playback, setup details are populated directly from the test recordings
                _endpoint = new Uri(Recording.GetVariable(Constants.EndpointVariable, null));
                _completionsDeploymentId = Recording.GetVariable(Constants.CompletionsDeploymentIdVariable, null);
                _embeddingsDeploymentId = Recording.GetVariable(Constants.EmbeddingsDeploymentIdVariable, null);
            }
            else if (_apiKey is not null)
            {
                // Non-recording modes don't need to initialize again if we've already initialized the deployment
            }
            else
            {
                // Non-recording modes that haven't yet initialized need to go initialize the deployment
                lock (_deploymentIdLock)
                {
                    if (_apiKey is not null)
                    {
                        // The lock may have taken a while to acquire if deployment was already underway in parallel; check here one more time
                        // and carry on if we're already good to go.
                    }
                    else
                    {
                        TestEnvironment.ThrowIfCannotDeploy();
                        ArmClient armClient = new ArmClient(TestEnvironment.Credential);

                        ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
                        SubscriptionResource subscription = armClient.GetSubscriptionResource(subscriptionResourceId);

                        ResourceGroupResource resourceGroup = GetEnsureTestResourceGroup(subscription);

                        CognitiveServicesAccountResource openAIResource = new Func<CognitiveServicesAccountResource>(() =>
                        {
                            string randomizedSubdomain = Recording.GenerateAssetName(Constants.SubDomainPrefix);
                            try
                            {
                                return GetEnsureTestOpenAIResource(resourceGroup, randomizedSubdomain);
                            }
                            catch (RequestFailedException ex) when (ex.Status == 409)
                            {
                                // A single retry attempt to automatically purge a previously deleted stale resource
                                CognitiveServicesDeletedAccountResource deletedOpenAIResource = subscription.GetCognitiveServicesDeletedAccount(
                                    Constants.Location,
                                    Constants.ResourceGroupName,
                                    Constants.CognitiveServicesAccountName);
                                deletedOpenAIResource.Delete(WaitUntil.Completed);
                                return GetEnsureTestOpenAIResource(resourceGroup, randomizedSubdomain);
                            }
                        }).Invoke();

                        CognitiveServicesAccountDeploymentResource completionsModelResource = GetEnsureDeployedModelResource(
                            openAIResource,
                            Constants.CompletionsModelName,
                            CognitiveServicesAccountDeploymentScaleType.Standard);
                        CognitiveServicesAccountDeploymentResource chatCompletionsModelResource = GetEnsureDeployedModelResource(
                            openAIResource,
                            Constants.ChatCompletionsModelName,
                            CognitiveServicesAccountDeploymentScaleType.Standard);
                        CognitiveServicesAccountDeploymentResource embeddingsModelResource = GetEnsureDeployedModelResource(
                            openAIResource,
                            Constants.EmbeddingsModelName,
                            CognitiveServicesAccountDeploymentScaleType.Standard);

                        _endpoint = new Uri(openAIResource.Data.Properties.Endpoint);
                        _completionsDeploymentId = completionsModelResource.Id.Name;
                        _chatCompletionsDeploymentId = chatCompletionsModelResource.Id.Name;
                        _embeddingsDeploymentId = embeddingsModelResource.Id.Name;

                        ServiceAccountApiKeys keys = openAIResource.GetKeys();
                        _apiKey = new AzureKeyCredential(keys.Key1);
                        _openAIAuthToken = TestEnvironment.PublicOpenAiApiKey;
                    }
                }
            }

            if (Mode == RecordedTestMode.Record)
            {
                Recording.SetVariable(Constants.EndpointVariable, _endpoint.ToString());
                Recording.SetVariable(Constants.CompletionsDeploymentIdVariable, _completionsDeploymentId);
                Recording.SetVariable(Constants.EmbeddingsDeploymentIdVariable, _embeddingsDeploymentId);
            }
        }

        private static ResourceGroupResource GetEnsureTestResourceGroup(SubscriptionResource subscription)
        {
            ResourceGroupData rgData = new ResourceGroupData(Constants.Location);
            rgData.Tags.Add("DeleteAfter", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy hh:mm:sszzz"));
            ResourceGroupResource resourceGroup = subscription.GetResourceGroups().Exists(Constants.ResourceGroupName)
                ? subscription.GetResourceGroup(Constants.ResourceGroupName)
                : subscription.GetResourceGroups().CreateOrUpdate(WaitUntil.Completed, Constants.ResourceGroupName, rgData).Value;
            return resourceGroup;
        }

        private static CognitiveServicesAccountResource GetEnsureTestOpenAIResource(ResourceGroupResource resourceGroup, string subdomain)
        {
            CognitiveServicesAccountData csaData = new CognitiveServicesAccountData(Constants.Location)
            {
                Kind = "OpenAI",
                Sku = new CognitiveServicesSku("S0"),
                Properties = new CognitiveServicesAccountProperties()
                {
                    CustomSubDomainName = subdomain,
                },
            };

            return resourceGroup.GetCognitiveServicesAccounts().Exists(Constants.CognitiveServicesAccountName)
                ? resourceGroup.GetCognitiveServicesAccounts().Get(Constants.CognitiveServicesAccountName)
                : resourceGroup.GetCognitiveServicesAccounts().CreateOrUpdate(WaitUntil.Completed, Constants.CognitiveServicesAccountName, csaData).Value;
        }

        private static CognitiveServicesAccountDeploymentResource GetEnsureDeployedModelResource(
            CognitiveServicesAccountResource openAIResource,
            string modelName,
            CognitiveServicesAccountDeploymentScaleType modelScaleType)
        {
            Pageable<CognitiveServicesAccountModel> availableModels = openAIResource.GetModels();
            CognitiveServicesAccountModel matchingModel = availableModels.FirstOrDefault(m => m.Name == modelName);
            if (matchingModel == null)
            {
                throw new Exception($"No available models match 'modelName' for Azure OpenAI resource: {openAIResource.Id}"
                    + $"Available models:\n  {string.Join("\n  ", availableModels.Select(model => model.Name))}");
            }

            var deploymentData = new CognitiveServicesAccountDeploymentData()
            {
                Properties = new CognitiveServicesAccountDeploymentProperties()
                {
                    Model = new CognitiveServicesAccountDeploymentModel()
                    {
                        Format = matchingModel.Format,
                        Name = matchingModel.Name,
                        Version = matchingModel.Version,
                    },
                    ScaleSettings = new CognitiveServicesAccountDeploymentScaleSettings()
                    {
                        ScaleType = modelScaleType,
                    },
                },
            };

            CognitiveServicesAccountDeploymentCollection existingModelDeployments = openAIResource.GetCognitiveServicesAccountDeployments();
            if (existingModelDeployments.Exists(matchingModel.Name))
            {
                return openAIResource.GetCognitiveServicesAccountDeployment(matchingModel.Name).Value;
            }
            else
            {
                return openAIResource.GetCognitiveServicesAccountDeployments().CreateOrUpdate(WaitUntil.Completed, matchingModel.Name, deploymentData).Value;
            }
        }

        private OpenAIClientOptions GetInstrumentedClientOptions(string defaultDeploymentOrModelName = null)
            => InstrumentClientOptions(new OpenAIClientOptions(OpenAIClientOptions.ServiceVersion.V2022_12_01)
            {
                DefaultDeploymentOrModelName = defaultDeploymentOrModelName,
            });

        protected enum OpenAIClientServiceTarget
        {
            Azure,
            NonAzure
        }

        protected enum OpenAIClientDefaultScenario
        {
            None,
            Completions,
            ChatCompletions,
            Embeddings,
        }

        protected OpenAIClient GetClient(OpenAIClientServiceTarget serviceTarget, OpenAIClientDefaultScenario defaultScenario)
        {
            return (serviceTarget, defaultScenario) switch
            {
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.None) => GetAzureUnconfiguredClient(),
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.Completions) => GetAzureCompletionsClient(),
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.ChatCompletions) => GetAzureChatCompletionsClient(),
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.Embeddings) => GetAzureEmbeddingsClient(),
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.None) => GetNonAzureUnconfiguredClient(),
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.Completions) => GetNonAzureCompletionsClient(),
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.ChatCompletions) => GetNonAzureChatCompletionsClient(),
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.Embeddings) => GetNonAzureEmbeddingsClient(),
                _ => throw new ArgumentException("Unexpected client configuration"),
            };
        }

        protected string GetDeploymentOrModelName(
            OpenAIClientServiceTarget serviceTarget,
            OpenAIClientDefaultScenario defaultScenario)
        {
            return (serviceTarget, defaultScenario) switch
            {
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.Completions) => _completionsDeploymentId,
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.ChatCompletions) => _chatCompletionsDeploymentId,
                (OpenAIClientServiceTarget.Azure, OpenAIClientDefaultScenario.Embeddings) => _embeddingsDeploymentId,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.Completions) => NonAzureCompletionsModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.ChatCompletions)
                    => NonAzureChatCompletionsModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientDefaultScenario.Embeddings) => NonAzureEmbeddingsModelName,
                _ => throw new ArgumentException("Unsupported service target / scenario combination")
            };
        }
    }
}

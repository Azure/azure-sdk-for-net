// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
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
            public const string EndpointVariable = "OPENAI_ENDPOINT";
            public const string ResourceGroupName = "openai-test-rg";
            public const string CognitiveServicesAccountName = "openai-sdk-test-automation-account-eastus";
            public const string SubDomainPrefix = "sdk";
            public static AzureLocation Location = AzureLocation.EastUS;
        }

        private static readonly object s_deploymentIdLock = new();

        private Uri _endpoint;
        private AzureKeyCredential _azureApiKey;
        private string _completionsDeploymentId;
        private string _chatCompletionsDeploymentId;
        private string _embeddingsDeploymentId;
        private string _nonAzureApiKey;
        private string _azureCognitiveSearchApiKey;

        protected OpenAITestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("sig=[^\"]*", "sig=Sanitized"));
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(\"key\" *: *\")[^ \n\"]*(\")", "$1placeholder$2"));
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("api-key", "***********"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("sig=[^\"]*", "sig=Sanitized"));
            SanitizedQueryParameters.Add("sig");
        }

        protected OpenAIClient GetAzureClientWithKey(
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null,
            string azureResourceUrlVariableName = null,
            string azureResourceApiKeyVariableName = null)
            => InstrumentClient(new OpenAIClient(
                !string.IsNullOrEmpty(azureResourceUrlVariableName)
                    ? TestEnvironment.GetUrlVariable(azureResourceUrlVariableName)
                    : _endpoint,
                !string.IsNullOrEmpty(azureResourceApiKeyVariableName)
                    ? TestEnvironment.GetKeyVariable(azureResourceApiKeyVariableName)
                    : GetAzureApiKey(),
                GetInstrumentedClientOptions(azureServiceVersionOverride)));

        protected OpenAIClient GetAzureClientWithToken(
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null,
            string azureResourceUrlVariableName = null)
            => InstrumentClient(new OpenAIClient(
                !string.IsNullOrEmpty(azureResourceUrlVariableName)
                    ? TestEnvironment.GetUrlVariable(azureResourceUrlVariableName)
                    : _endpoint,
                TestEnvironment.Credential,
                GetInstrumentedClientOptions(azureServiceVersionOverride)));

        protected OpenAIClient GetNonAzureClientWithKey() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions()));

        protected AzureKeyCredential GetAzureApiKey(string overrideVariableName = null)
        {
            if (!string.IsNullOrEmpty(overrideVariableName))
            {
                return TestEnvironment.GetKeyVariable(overrideVariableName);
            }
            return _azureApiKey ?? new AzureKeyCredential("placeholder");
        }
        protected string GetNonAzureApiKey() => string.IsNullOrEmpty(_nonAzureApiKey) ? "placeholder" : _nonAzureApiKey;

        protected AzureKeyCredential GetCognitiveSearchApiKey()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new AzureKeyCredential("placeholder");
            }
            else if (!string.IsNullOrEmpty(_azureCognitiveSearchApiKey))
            {
                return new AzureKeyCredential(_azureCognitiveSearchApiKey);
            }
            else
            {
                throw new InvalidOperationException(
                    "No Azure Cognitive Search API key found. Please set the appropriate environment variable to "
                    + "use this value.");
            }
        }

        protected Stream GetTestAudioInputStream(string language = "en")
        {
            Recording.DisableRequestBodyRecording();
            if (Mode == RecordedTestMode.Playback)
            {
                return new MemoryStream();
            }
            return File.OpenRead(language switch
            {
                "en" => TestEnvironment.TestAudioInputPathEnglish,
                _ => throw new NotImplementedException(),
            });
        }

        [SetUp]
        public void CreateDeployment()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                // For playback, setup details are populated directly from the test recordings
                _endpoint = new Uri(Recording.GetVariable(Constants.EndpointVariable, null));
                _completionsDeploymentId
                    = Recording.GetVariable(ModelDeploymentEntry.LegacyCompletions.EnvironmentVariableName, null);
                _embeddingsDeploymentId
                    = Recording.GetVariable(ModelDeploymentEntry.ChatCompletions.EnvironmentVariableName, null);
                _chatCompletionsDeploymentId
                    = Recording.GetVariable(ModelDeploymentEntry.Embeddings.EnvironmentVariableName, null);
            }
            else if (_azureApiKey is not null)
            {
                // Non-recording modes don't need to initialize again if we've already initialized the deployment
            }
            else
            {
                // Non-recording modes that haven't yet initialized need to go initialize the deployment
                lock (s_deploymentIdLock)
                {
                    if (_azureApiKey is not null)
                    {
                        // The lock may have taken a while to acquire if deployment was already underway in parallel; check here one more time
                        // and carry on if we're already good to go.
                    }
                    else
                    {
                        TestEnvironment.ThrowIfCannotDeploy();
                        ArmClient armClient = new(TestEnvironment.Credential);

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

                        CognitiveServicesAccountDeploymentResource completionsModelResource = GetEnsureDeployedModelResource(openAIResource, ModelDeploymentEntry.LegacyCompletions);
                        CognitiveServicesAccountDeploymentResource chatCompletionsModelResource = GetEnsureDeployedModelResource(openAIResource, ModelDeploymentEntry.ChatCompletions);
                        CognitiveServicesAccountDeploymentResource embeddingsModelResource = GetEnsureDeployedModelResource(openAIResource, ModelDeploymentEntry.Embeddings);

                        _endpoint = new Uri(openAIResource.Data.Properties.Endpoint);
                        _completionsDeploymentId = completionsModelResource.Id.Name;
                        _chatCompletionsDeploymentId = chatCompletionsModelResource.Id.Name;
                        _embeddingsDeploymentId = embeddingsModelResource.Id.Name;

                        ServiceAccountApiKeys keys = openAIResource.GetKeys();
                        _azureApiKey = new AzureKeyCredential(keys.Key1);
                        _nonAzureApiKey = TestEnvironment.NonAzureOpenAIApiKey;
                        _azureCognitiveSearchApiKey = TestEnvironment.AzureCognitiveSearchApiKey;
                    }
                }
            }

            if (Mode == RecordedTestMode.Record)
            {
                Recording.SetVariable(Constants.EndpointVariable, _endpoint.ToString());
                Recording.SetVariable(
                    ModelDeploymentEntry.LegacyCompletions.EnvironmentVariableName,
                    _completionsDeploymentId);
                Recording.SetVariable(
                    ModelDeploymentEntry.ChatCompletions.EnvironmentVariableName,
                    _chatCompletionsDeploymentId);
                Recording.SetVariable(
                    ModelDeploymentEntry.Embeddings.EnvironmentVariableName,
                    _embeddingsDeploymentId);
            }
        }

        private static ResourceGroupResource GetEnsureTestResourceGroup(SubscriptionResource subscription)
        {
            ResourceGroupData rgData = new(Constants.Location);
            rgData.Tags.Add("DeleteAfter", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy hh:mm:sszzz"));
            ResourceGroupResource resourceGroup = subscription.GetResourceGroups().Exists(Constants.ResourceGroupName)
                ? subscription.GetResourceGroup(Constants.ResourceGroupName)
                : subscription.GetResourceGroups().CreateOrUpdate(WaitUntil.Completed, Constants.ResourceGroupName, rgData).Value;
            return resourceGroup;
        }

        private static CognitiveServicesAccountResource GetEnsureTestOpenAIResource(ResourceGroupResource resourceGroup, string subdomain)
        {
            CognitiveServicesAccountData csaData = new(Constants.Location)
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
            ModelDeploymentEntry modelEntry)
        {
            // Special case: "legacy" models can't be re-deployed and so we'll just make a best effort to retrieve
            // it. By design, we cannot automatically regenerate the test resource programmatically if it's deleted.
            if (modelEntry.IsLegacyAzureModel)
            {
                return openAIResource.GetCognitiveServicesAccountDeployment(modelEntry.AzureDeploymentName).Value;
            }

            Pageable<CognitiveServicesAccountModel> availableModels = openAIResource.GetModels();
            CognitiveServicesAccountModel matchingModel = availableModels
                .FirstOrDefault(m => m.Name == modelEntry.AzureModelName)
                ?? throw new Exception(
                    $"No available models match 'modelName' for Azure OpenAI resource: {openAIResource.Id}"
                    + $"Available models:\n  {string.Join("\n  ", availableModels.Select(model => model.Name))}");

            CognitiveServicesAccountDeploymentCollection existingModelDeployments = openAIResource.GetCognitiveServicesAccountDeployments();

            if (existingModelDeployments.Exists(matchingModel.Name))
            {
                return openAIResource.GetCognitiveServicesAccountDeployment(matchingModel.Name).Value;
            }
            else
            {
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
                            ScaleType = CognitiveServicesAccountDeploymentScaleType.Standard,
                        },
                    },
                };

                return openAIResource.GetCognitiveServicesAccountDeployments().CreateOrUpdate(WaitUntil.Completed, matchingModel.Name, deploymentData).Value;
            }
        }

        private OpenAIClientOptions GetInstrumentedClientOptions(
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
        {
            OpenAIClientOptions uninstrumentedClientOptions = azureServiceVersionOverride.HasValue
                ? new OpenAIClientOptions(azureServiceVersionOverride.Value)
                : new OpenAIClientOptions();
            return InstrumentClientOptions(uninstrumentedClientOptions);
        }

        public class ModelDeploymentEntry
        {
            /// <summary>
            /// Model/deployment information to use for /completions that include old features like echo
            /// and logprobs. Azure OpenAI added new Completions support for gpt-35-turbo but did not carry
            /// these forward.
            /// </summary>
            public static readonly ModelDeploymentEntry LegacyCompletions = new()
            {
                AzureDeploymentName = "text-davinci-002",
                AzureModelName = "text-davinci-002",
                NonAzureModelName = "text-davinci-002",
                EnvironmentVariableName = "COMPLETIONS_DEPLOYMENT_NAME",
                IsLegacyAzureModel = true,
            };

            /// <summary>
            /// Model/deployment information to use for latest /completions features. Azure OpenAI has a different
            /// capability set exposed via gpt-35-turbo than legacy models like text-davinci-002.
            /// </summary>
            public static readonly ModelDeploymentEntry Completions = new()
            {
                AzureDeploymentName = "gpt-35-turbo",
                AzureModelName = "gpt-35-turbo",
                NonAzureModelName = "text-davinci-002",
            };

            public static readonly ModelDeploymentEntry ChatCompletions = new()
            {
                AzureDeploymentName = "gpt-4-0613",
                AzureModelName = "gpt-35-turbo",
                NonAzureModelName = "gpt-3.5-turbo",
                EnvironmentVariableName = "CHAT_COMPLETIONS_DEPLOYMENT_NAME",
            };

            public static readonly ModelDeploymentEntry Embeddings = new()
            {
                AzureDeploymentName = "text-embedding-ada-002",
                AzureModelName = "text-embedding-ada-002",
                NonAzureModelName = "text-embedding-ada-002",
                EnvironmentVariableName = "EMBEDDINGS_DEPLOYMENT_NAME",
            };

            public static readonly ModelDeploymentEntry AudioTranscription = new()
            {
                AzureDeploymentName = "whisper-deployment",
                NonAzureModelName = "whisper-1",
            };

            public string AzureDeploymentName { get; set; }
            public string AzureModelName { get; set; }
            public string NonAzureModelName { get; set; }
            public string EnvironmentVariableName { get; set; }
            public bool IsLegacyAzureModel { get; set; } = false;
        }

        public enum OpenAIClientServiceTarget
        {
            Azure,
            NonAzure
        }

        public enum OpenAIClientAuthenticationType
        {
            Unknown,
            ApiKey,
            Token,
            ActiveDirectory,
        }

        public OpenAIClient GetTestClient(
            OpenAIClientServiceTarget serviceTarget,
            OpenAIClientAuthenticationType authenticationType = OpenAIClientAuthenticationType.ApiKey,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
        {
            return (serviceTarget, authenticationType) switch
            {
                (OpenAIClientServiceTarget.Azure, OpenAIClientAuthenticationType.ApiKey)
                    => GetAzureClientWithKey(azureServiceVersionOverride),
                (OpenAIClientServiceTarget.Azure, OpenAIClientAuthenticationType.Token)
                    => GetAzureClientWithToken(azureServiceVersionOverride),
                (OpenAIClientServiceTarget.Azure, OpenAIClientAuthenticationType.ActiveDirectory)
                    => throw new NotImplementedException(),
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientAuthenticationType.ApiKey)
                    => GetNonAzureClientWithKey(),
                _ => throw new ArgumentException($"Unsupported combo: {serviceTarget}, {authenticationType}")
            };
        }

        public OpenAIClient GetDevelopmentTestClient(
            OpenAIClientServiceTarget serviceTarget,
            string azureDevelopmentResourceUrlVariableName,
            string azureDevelopmentResourceApiKeyVariableName,
            OpenAIClientAuthenticationType authenticationType = OpenAIClientAuthenticationType.ApiKey,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
        {
            if (serviceTarget == OpenAIClientServiceTarget.NonAzure)
            {
                return GetTestClient(serviceTarget, authenticationType, azureServiceVersionOverride);
            }
            else
            {
                return authenticationType switch
                {
                    OpenAIClientAuthenticationType.ApiKey
                        => GetAzureClientWithKey(
                            azureServiceVersionOverride,
                            azureDevelopmentResourceUrlVariableName,
                            azureDevelopmentResourceApiKeyVariableName),
                    OpenAIClientAuthenticationType.Token
                        => GetAzureClientWithToken(
                            azureServiceVersionOverride,
                            azureDevelopmentResourceUrlVariableName),
                    _ => throw new NotImplementedException()
                };
            }
        }

        public enum OpenAIClientScenario
        {
            None,
            LegacyCompletions,
            Completions,
            ChatCompletions,
            Embeddings,
            AudioTranscription,
        }

        protected static string GetDeploymentOrModelName(
            OpenAIClientServiceTarget serviceTarget,
            OpenAIClientScenario defaultScenario)
        {
            return (serviceTarget, defaultScenario) switch
            {
                (OpenAIClientServiceTarget.Azure, OpenAIClientScenario.LegacyCompletions)
                    => ModelDeploymentEntry.LegacyCompletions.AzureDeploymentName,
                (OpenAIClientServiceTarget.Azure, OpenAIClientScenario.ChatCompletions)
                    => ModelDeploymentEntry.ChatCompletions.AzureDeploymentName,
                (OpenAIClientServiceTarget.Azure, OpenAIClientScenario.Completions)
                    => ModelDeploymentEntry.Completions.AzureDeploymentName,
                (OpenAIClientServiceTarget.Azure, OpenAIClientScenario.Embeddings)
                    => ModelDeploymentEntry.Embeddings.AzureDeploymentName,
                (OpenAIClientServiceTarget.Azure, OpenAIClientScenario.AudioTranscription)
                    => ModelDeploymentEntry.AudioTranscription.AzureDeploymentName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientScenario.LegacyCompletions)
                    => ModelDeploymentEntry.LegacyCompletions.NonAzureModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientScenario.Completions)
                    => ModelDeploymentEntry.Completions.NonAzureModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientScenario.ChatCompletions)
                    => ModelDeploymentEntry.ChatCompletions.NonAzureModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientScenario.Embeddings)
                    => ModelDeploymentEntry.Embeddings.NonAzureModelName,
                (OpenAIClientServiceTarget.NonAzure, OpenAIClientScenario.AudioTranscription)
                    => ModelDeploymentEntry.AudioTranscription.NonAzureModelName,
                _ => throw new ArgumentException("Unsupported service target / scenario combination")
            };
        }
    }
}

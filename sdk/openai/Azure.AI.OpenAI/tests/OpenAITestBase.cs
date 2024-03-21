// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        private static string GetAzureEndpointVariableNameForScenario(Scenario scenario)
            => $"AOAI_{scenario.ToString().ToUpper()}_ENDPOINT";

        private static string GetAzureKeyVariableNameForScenario(Scenario scenario)
            => $"AOAI_{scenario.ToString().ToUpper()}_API_KEY";

        private static readonly object s_deploymentIdLock = new();
        private static bool s_deploymentComplete = false;

        private readonly Scenario _defaultScenario;

        protected OpenAITestBase(Scenario defaultScenario, bool isAsync, RecordedTestMode? mode = null)
            : this(isAsync, mode)
        {
            _defaultScenario = defaultScenario;
        }

        protected OpenAITestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("sig=[^\"]*", "sig=Sanitized"));
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(\"key\" *: *\")[^ \n\"]*(\")", "$1placeholder$2"));
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("api-key", "***********"));
            UriRegexSanitizers.Add(new UriRegexSanitizer("sig=[^\"]*", "sig=Sanitized"));
            SanitizedQueryParameters.Add("sig");
        }

        protected OpenAIClient GetAzureClientWithKey(
            Scenario scenario,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null,
            string azureResourceUrlVariableName = null,
            string azureResourceApiKeyVariableName = null)
        {
            string endpointVariableName = GetAzureEndpointVariableNameForScenario(scenario);
            string keyVariableName = GetAzureKeyVariableNameForScenario(scenario);
            if (TestEnvironment.TryGetUrlVariable(endpointVariableName, out var urlVariable)
                && TestEnvironment.TryGetKeyVariable(keyVariableName, out var keyVariable))
            {
                return InstrumentClient(
                    new OpenAIClient(
                        urlVariable,
                        keyVariable,
                        GetInstrumentedClientOptions(azureServiceVersionOverride)));
            }
            else
            {
                return InstrumentClient(
                    new OpenAIClient(
                        DeploymentEntriesByScenario[scenario].AzureResourceUri,
                        DeploymentEntriesByScenario[scenario].AzureResourceKey,
                        GetInstrumentedClientOptions(azureServiceVersionOverride)));
            }
        }

        protected OpenAIClient GetAzureClientWithToken(
            Scenario scenario,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null,
            string azureResourceUrlVariableName = null)
        {
            if (!string.IsNullOrEmpty(azureResourceUrlVariableName))
            {
                throw new NotImplementedException("Environment override not yet supported with token auth");
            }
            return InstrumentClient(
                new OpenAIClient(
                    DeploymentEntriesByScenario[scenario].AzureResourceUri,
                    TestEnvironment.Credential,
                    GetInstrumentedClientOptions(azureServiceVersionOverride)));
        }

        protected OpenAIClient GetNonAzureClientWithKey() => InstrumentClient(
            new OpenAIClient(GetNonAzureApiKey(), GetInstrumentedClientOptions()));

        protected string GetNonAzureApiKey()
            => string.IsNullOrEmpty(TestEnvironment.NonAzureOpenAIApiKey)
                ? "placeholder"
                : TestEnvironment.NonAzureOpenAIApiKey;

        protected AzureKeyCredential GetCognitiveSearchApiKey()
            => Mode == RecordedTestMode.Playback
                ? new AzureKeyCredential("placeholder")
                : !string.IsNullOrEmpty(TestEnvironment.AzureCognitiveSearchApiKey)
                    ? new AzureKeyCredential(TestEnvironment.AzureCognitiveSearchApiKey)
                    : throw new InvalidOperationException(
                        "No Azure Cognitive Search API key found. Please set the appropriate environment variable to "
                        + "use this value.");

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
                foreach (KeyValuePair<Scenario, ModelDeploymentEntry> pair in s_deploymentEntriesByScenarioForPlayback)
                {
                    if (!string.IsNullOrEmpty(pair.Value.AzureDeploymentName))
                    {
                        string variableName = GetAzureEndpointVariableNameForScenario(pair.Key);
                        string variableValue = Recording.GetVariable(variableName, null);
                        if (!string.IsNullOrEmpty(variableValue))
                        {
                            pair.Value.AzureResourceUri = new Uri(variableValue);
                            pair.Value.AzureResourceKey = new AzureKeyCredential("placeholder");
                        }
                    }
                }
            }
            else if (s_deploymentComplete)
            {
                // Non-recording modes don't need to initialize again if we've already initialized the deployment
            }
            else
            {
                // Non-recording modes that haven't yet initialized need to go initialize the deployment
                lock (s_deploymentIdLock)
                {
                    if (s_deploymentComplete)
                    {
                        // The lock may have taken a while to acquire if deployment was already underway in parallel; check here one more time
                        // and carry on if we're already good to go.
                    }
                    else
                    {
                        // First, ensure we have all the environment variables we need to query for the test resources
                        TestEnvironment.ThrowIfCannotDeploy();
                        ArmClient armClient = new(TestEnvironment.Credential);

                        // Now query for the test resources all the way up the resource group
                        ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
                        SubscriptionResource subscription = armClient.GetSubscriptionResource(subscriptionResourceId);
                        ResourceGroupResource resourceGroup = GetEnsureTestResourceGroup(subscription);

                        // Next, for each distinct resource name we care about, fetch the resource and store it in all deployment entries that need it
                        IEnumerable<IGrouping<string, ModelDeploymentEntry>> deploymentEntriesByAzureResourceName = s_deploymentEntriesByScenarioForRecording.Values
                            .Where(entry => !string.IsNullOrEmpty(entry.AzureDeploymentName))
                            .GroupBy(entry => entry.AzureResourceName);

                        var uniqueDeploymentEntries = s_deploymentEntriesByScenarioForRecording.Values
                            .Where(entry => !string.IsNullOrEmpty(entry.AzureDeploymentName))
                            .Select(entry => new KeyValuePair<ModelDeploymentEntry, string>(entry, entry.AzureDeploymentName))
                            .Distinct()
                            .Select(pair => pair.Key)
                            .ToList();

                        foreach (IGrouping<string, ModelDeploymentEntry> resourceNameGrouping in deploymentEntriesByAzureResourceName)
                        {
                            AzureLocation resourceLocation = resourceNameGrouping.First().AzureResourceLocation;
                            CognitiveServicesAccountResource resourceForResourceName = new Func<CognitiveServicesAccountResource>(() =>
                            {
                                string randomizedSubdomain = Recording.GenerateAssetName(prefix: "sdk");
                                try
                                {
                                    return GetEnsureTestOpenAIResource(resourceGroup, resourceLocation, resourceNameGrouping.Key, randomizedSubdomain);
                                }
                                catch (RequestFailedException ex) when (ex.Status == 409)
                                {
                                    // A single retry attempt to automatically purge a previously deleted stale resource
                                    CognitiveServicesDeletedAccountResource deletedOpenAIResource = subscription.GetCognitiveServicesDeletedAccount(
                                        location: resourceLocation,
                                        resourceGroupName: "openai-test-rg",
                                        accountName: resourceNameGrouping.Key);
                                    deletedOpenAIResource.Delete(WaitUntil.Completed);
                                    return GetEnsureTestOpenAIResource(resourceGroup, resourceLocation, resourceNameGrouping.Key, randomizedSubdomain);
                                }
                            }).Invoke();

                            Uri uriForResource = new(resourceForResourceName.Data.Properties.Endpoint);
                            AzureKeyCredential keyForResource = new AzureKeyCredential(resourceForResourceName.GetKeys().Value.Key1);

                            foreach (ModelDeploymentEntry deploymentEntry in resourceNameGrouping)
                            {
                                deploymentEntry.AzureResourceUri = uriForResource;
                                deploymentEntry.AzureResourceKey = keyForResource;
                            }

                            var modelDeploymentsInResource = uniqueDeploymentEntries.Where(entry => entry.AzureDeploymentName == resourceNameGrouping.Key);
                            foreach (var modelDeploymentInResource in modelDeploymentsInResource)
                            {
                                _ = GetEnsureDeployedModelResource(resourceForResourceName, modelDeploymentInResource);
                            }
                        }

                        s_deploymentComplete = true;
                    }
                }
            }
        }

        private static ResourceGroupResource GetEnsureTestResourceGroup(SubscriptionResource subscription)
        {
            if (!subscription.GetResourceGroups().Exists("openai-test-rg"))
            {
                throw new NotImplementedException("dynamic regeneration of resource group not yet supported");
            }
            return subscription.GetResourceGroup("openai-test-rg");
        }

        private static CognitiveServicesAccountResource GetEnsureTestOpenAIResource(ResourceGroupResource resourceGroup, AzureLocation location, string resourceName, string subdomain)
        {
            CognitiveServicesAccountData csaData = new(location)
            {
                Kind = "OpenAI",
                Sku = new CognitiveServicesSku("S0"),
                Properties = new CognitiveServicesAccountProperties()
                {
                    CustomSubDomainName = subdomain,
                },
            };

            return resourceGroup.GetCognitiveServicesAccounts().Exists(resourceName)
                ? resourceGroup.GetCognitiveServicesAccounts().Get(resourceName)
                : resourceGroup.GetCognitiveServicesAccounts().CreateOrUpdate(WaitUntil.Completed, resourceName, csaData).Value;
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
            uninstrumentedClientOptions.Diagnostics.IsLoggingContentEnabled = true;
            return InstrumentClientOptions(uninstrumentedClientOptions);
        }

        public class ModelDeploymentEntry
        {
            public string AzureResourceName { get; set; }
            public Uri AzureResourceUri { get; set; }
            public AzureLocation AzureResourceLocation { get; set; }
            public AzureKeyCredential AzureResourceKey { get; set; }
            public string AzureDeploymentName { get; set; }
            public string AzureModelName { get; set; }
            public string NonAzureModelName { get; set; }
            public string EnvironmentVariableName { get; set; }
            public bool IsLegacyAzureModel { get; set; } = false;
        }

        private static readonly Dictionary<Scenario, ModelDeploymentEntry> s_deploymentEntriesByScenarioForPlayback = CreateDeploymentEntriesByScenario();
        private static readonly Dictionary<Scenario, ModelDeploymentEntry> s_deploymentEntriesByScenarioForRecording = CreateDeploymentEntriesByScenario();

        protected Dictionary<Scenario, ModelDeploymentEntry> DeploymentEntriesByScenario => Mode == RecordedTestMode.Playback
            ? s_deploymentEntriesByScenarioForPlayback
            : s_deploymentEntriesByScenarioForRecording;

        protected static Dictionary<Scenario, ModelDeploymentEntry> CreateDeploymentEntriesByScenario()
        {
            return new()
            {
                /// <summary>
                /// Model/deployment information to use for /completions that include old features like echo
                /// and logprobs. Azure OpenAI added new Completions support for gpt-35-turbo but did not carry
                /// these forward.
                /// </summary>
                [Scenario.LegacyCompletions] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-eastus",
                    AzureResourceLocation = AzureLocation.EastUS,
                    AzureDeploymentName = "gpt-35-turbo-instruct",
                    AzureModelName = "gpt-35-turbo-instruct",
                    NonAzureModelName = "gpt-3.5-turbo-instruct",
                    EnvironmentVariableName = "COMPLETIONS_DEPLOYMENT_NAME",
                    IsLegacyAzureModel = true,
                },

                /// <summary>
                /// Model/deployment information to use for latest /completions features. Azure OpenAI has a different
                /// capability set exposed via gpt-35-turbo than legacy models like text-davinci-002.
                /// </summary>
                [Scenario.Completions] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-eastus",
                    AzureResourceLocation = AzureLocation.EastUS,
                    AzureDeploymentName = "gpt-35-turbo-instruct",
                    AzureModelName = "gpt-35-turbo-instruct",
                    NonAzureModelName = "gpt-3.5-turbo-instruct",
                },

                [Scenario.ChatCompletions] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-eastus",
                    AzureResourceLocation = AzureLocation.EastUS,
                    AzureDeploymentName = "gpt-4-0613",
                    AzureModelName = "gpt-35-turbo",
                    NonAzureModelName = "gpt-3.5-turbo",
                    EnvironmentVariableName = "CHAT_COMPLETIONS_DEPLOYMENT_NAME",
                },

                [Scenario.Embeddings] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-eastus",
                    AzureResourceLocation = AzureLocation.EastUS,
                    AzureDeploymentName = "text-embedding-3-small",
                    AzureModelName = "text-embedding-3-small",
                    NonAzureModelName = "text-embedding-3-small",
                    EnvironmentVariableName = "EMBEDDINGS_DEPLOYMENT_NAME",
                },

                [Scenario.AudioTranscription] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-northcentralus",
                    AzureResourceLocation = AzureLocation.NorthCentralUS,
                    AzureDeploymentName = "whisper",
                    NonAzureModelName = "whisper-1",
                },

                [Scenario.SpeechGeneration] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-sweden-central",
                    AzureResourceLocation = AzureLocation.SwedenCentral,
                    AzureDeploymentName = "tts",
                    NonAzureModelName = "tts-1",
                },

                [Scenario.ImageGenerations] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-sweden-central",
                    AzureResourceLocation = AzureLocation.SwedenCentral,
                    AzureDeploymentName = "dall-e-3",
                    NonAzureModelName = "dall-e-3",
                },

                [Scenario.LegacyImageGenerations] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-eastus",
                    AzureDeploymentName = "None!",
                    AzureResourceLocation = AzureLocation.EastUS,
                },

                [Scenario.ChatTools] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-sweden-central",
                    AzureResourceLocation = AzureLocation.SwedenCentral,
                    AzureDeploymentName = "gpt-4-1106-preview",
                    NonAzureModelName = "gpt-3.5-turbo-1106",
                },

                [Scenario.VisionPreview] = new()
                {
                    AzureResourceName = "openai-sdk-test-automation-account-sweden-central",
                    AzureResourceLocation = AzureLocation.SwedenCentral,
                    AzureDeploymentName = "gpt-4-vision-preview",
                    NonAzureModelName = "gpt-4-vision-preview",
                }
            };
        }

        public enum Service
        {
            Azure,
            NonAzure
        }

        public enum TestAuthType
        {
            Unknown,
            ApiKey,
            Token,
            ActiveDirectory,
        }

        public OpenAIClient GetTestClient(
            Service serviceTarget,
            Scenario scenario,
            TestAuthType authenticationType = TestAuthType.ApiKey,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
        {
            RecordScenarioVariables(serviceTarget, scenario);
            return (serviceTarget, authenticationType) switch
            {
                (Service.Azure, TestAuthType.ApiKey) => GetAzureClientWithKey(scenario, azureServiceVersionOverride),
                (Service.Azure, TestAuthType.Token) => GetAzureClientWithToken(scenario, azureServiceVersionOverride),
                (Service.Azure, TestAuthType.ActiveDirectory) => throw new NotImplementedException(),
                (Service.NonAzure, TestAuthType.ApiKey) => GetNonAzureClientWithKey(),
                _ => throw new ArgumentException($"Unsupported combo: {serviceTarget}, {authenticationType}")
            };
        }

        public OpenAIClient GetTestClient(
            Service serviceTarget,
            TestAuthType authenticationType = TestAuthType.ApiKey,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
            => GetTestClient(serviceTarget, _defaultScenario, authenticationType, azureServiceVersionOverride);

        public OpenAIClient GetDevelopmentTestClient(
            Scenario scenario,
            Service serviceTarget,
            string azureDevelopmentResourceUrlVariableName,
            string azureDevelopmentResourceApiKeyVariableName,
            TestAuthType authenticationType = TestAuthType.ApiKey,
            OpenAIClientOptions.ServiceVersion? azureServiceVersionOverride = null)
        {
            if (serviceTarget == Service.NonAzure)
            {
                return GetTestClient(serviceTarget, scenario, authenticationType, azureServiceVersionOverride);
            }
            else
            {
                return authenticationType switch
                {
                    TestAuthType.ApiKey
                        => GetAzureClientWithKey(
                            scenario,
                            azureServiceVersionOverride,
                            azureDevelopmentResourceUrlVariableName,
                            azureDevelopmentResourceApiKeyVariableName),
                    TestAuthType.Token
                        => GetAzureClientWithToken(
                            scenario,
                            azureServiceVersionOverride,
                            azureDevelopmentResourceUrlVariableName),
                    _ => throw new NotImplementedException()
                };
            }
        }

        public enum Scenario
        {
            None,
            LegacyCompletions,
            Completions,
            ChatCompletions,
            Embeddings,
            AudioTranscription,
            SpeechGeneration,
            ImageGenerations,
            LegacyImageGenerations,
            ChatTools,
            VisionPreview,
        }

        protected string GetDeploymentOrModelName(Service serviceTarget, Scenario scenario)
        {
            RecordScenarioVariables(serviceTarget, scenario);
            ModelDeploymentEntry entry = DeploymentEntriesByScenario[scenario];
            return (serviceTarget == Service.Azure) ? entry.AzureDeploymentName : entry.NonAzureModelName;
        }

        protected string GetDeploymentOrModelName(Service serviceTarget)
            => GetDeploymentOrModelName(serviceTarget, _defaultScenario);

        protected void AssertExpectedPromptFilterResults(
    IReadOnlyList<ContentFilterResultsForPrompt> promptFilterResults,
    Service serviceTarget,
    int expectedCount)
        {
            if (serviceTarget == Service.NonAzure)
            {
                Assert.That(promptFilterResults, Is.Null.Or.Empty);
            }
            else
            {
                Assert.That(promptFilterResults, Is.Not.Null.Or.Empty);
                Assert.That(promptFilterResults.Count, Is.EqualTo(expectedCount));
                for (int i = 0; i < promptFilterResults.Count; i++)
                {
                    Assert.That(promptFilterResults[i].PromptIndex, Is.EqualTo(i));
                    Assert.That(promptFilterResults[i].ContentFilterResults, Is.Not.Null);
                    Assert.That(promptFilterResults[i].ContentFilterResults.Hate, Is.Not.Null);
                    Assert.That(promptFilterResults[i].ContentFilterResults.Hate.Filtered, Is.False);
                    Assert.That(
                        promptFilterResults[0].ContentFilterResults.Hate.Severity,
                        Is.EqualTo(ContentFilterSeverity.Safe));
                }
            }
        }

        protected void AssertExpectedContentFilterResponseResults(
            ContentFilterResultsForChoice contentFilterResults,
            Service serviceTarget)
        {
            if (serviceTarget == Service.NonAzure)
            {
                Assert.That(contentFilterResults, Is.Null);
            }
            else
            {
                Assert.That(contentFilterResults, Is.Not.Null.Or.Empty);
                Assert.That(contentFilterResults.Hate, Is.Not.Null);
                Assert.That(contentFilterResults.Hate.Filtered, Is.False);
                Assert.That(contentFilterResults.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
            }
        }

        protected void AssertExpectedContentFilterRequestResults(
            ContentFilterResultDetailsForPrompt contentFilterResults,
            Service serviceTarget)
        {
            if (serviceTarget == Service.NonAzure)
            {
                Assert.That(contentFilterResults, Is.Null);
            }
            else
            {
                Assert.That(contentFilterResults, Is.Not.Null.Or.Empty);
                Assert.That(contentFilterResults.Hate, Is.Not.Null);
                Assert.That(contentFilterResults.Hate.Filtered, Is.False);
                Assert.That(contentFilterResults.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
            }
        }

        private void RecordScenarioVariables(Service service, Scenario scenario)
        {
            if (service == Service.Azure && Mode == RecordedTestMode.Record)
            {
                string variableName = GetAzureEndpointVariableNameForScenario(scenario);
                Recording.SetVariable(variableName, DeploymentEntriesByScenario[scenario].AzureResourceUri.AbsoluteUri);
            }
        }
    }
}

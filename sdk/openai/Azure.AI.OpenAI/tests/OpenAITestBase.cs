// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public abstract class OpenAITestBase : RecordedTestBase<OpenAITestEnvironment>
    {
        private const string DeploymentIdVariable = "OPENAI_DEPLOYMENT_ID";
        private const string EmbeddingsDeploymentIdVariable = "OPENAI_EMBEDDINGS_DEPLOYMENT_ID";
        private const string EndpointVariable = "OPENAI_ENDPOINT";
        private const string ResourceGroupName = "openai-test-rg";
        private const string CognitiveServicesAccountName = "openai-test-account";
        private const string SubDomain = "sdk";
        private static AzureLocation Location = AzureLocation.SouthCentralUS;
        private CognitiveServicesAccountResource _cognitiveServiceAccount;
        private string _key = "DUMMY_VALUE";
        private string _endpoint;

        protected OpenAITestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            HeaderRegexSanitizers.Add(new Core.TestFramework.Models.HeaderRegexSanitizer("api-key", "***********"));
        }

        private static readonly object _deploymentIdLock = new object();
        [SetUp]
        public void CreateDeployment()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                DeploymentId = Recording.GetVariable(DeploymentIdVariable, null);
                EmbeddingsDeploymentId = Recording.GetVariable(EmbeddingsDeploymentIdVariable, null);
                _endpoint = Recording.GetVariable(EndpointVariable, null);
            }

            if ((Mode == RecordedTestMode.Live || Mode == RecordedTestMode.Record) && (DeploymentId == null || EmbeddingsDeploymentId == null))
            {
                lock (_deploymentIdLock)
                {
                    if (DeploymentId == null || EmbeddingsDeploymentId == null)
                    {
                        ArmClient armClient = new ArmClient(TestEnvironment.Credential);
                        var subscription = armClient.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId));

                        ResourceGroupResource resourceGroup = CreateResourceGroupIfNotExists(subscription);

                        CreateCognitiveServicesAccountIfNotExists(armClient, resourceGroup);

                        _endpoint = _cognitiveServiceAccount.Data.Properties.Endpoint;
                        Recording.SetVariable(EndpointVariable, _endpoint);

                        CognitiveServicesAccountDeploymentResource modelDeployment = CreateModelDeploymentIfNotExists("text-davinci-002");
                        CognitiveServicesAccountDeploymentResource embeddingsModelDeployment = CreateModelDeploymentIfNotExists("text-similarity-davinci-001");

                        DeploymentId = modelDeployment.Id.Name;
                        Recording.SetVariable(DeploymentIdVariable, DeploymentId);
                        EmbeddingsDeploymentId = embeddingsModelDeployment.Id.Name;
                        Recording.SetVariable(EmbeddingsDeploymentIdVariable, EmbeddingsDeploymentId);

                        var keys = _cognitiveServiceAccount.GetKeys();
                        _key = keys.Value.Key1;
                    }
                }
            }
        }

        private CognitiveServicesAccountDeploymentResource CreateModelDeploymentIfNotExists(string modelName)
        {
            var models = _cognitiveServiceAccount.GetModels();
            var model = models.FirstOrDefault(m => m.Name == modelName);
            if (model == null)
                throw new Exception($"No models available for {_cognitiveServiceAccount.Id}");

            var deploymentData = new CognitiveServicesAccountDeploymentData();
            deploymentData.Properties = new CognitiveServicesAccountDeploymentProperties();
            deploymentData.Properties.Model = new CognitiveServicesAccountDeploymentModel();
            deploymentData.Properties.Model.Format = model.Format;
            deploymentData.Properties.Model.Name = model.Name;
            deploymentData.Properties.Model.Version = model.Version;
            deploymentData.Properties.ScaleSettings = new CognitiveServicesAccountDeploymentScaleSettings();
            deploymentData.Properties.ScaleSettings.ScaleType = CognitiveServicesAccountDeploymentScaleType.Standard;

            var modelDeployment = _cognitiveServiceAccount.GetCognitiveServicesAccountDeployments().Exists(model.Name)
                ? _cognitiveServiceAccount.GetCognitiveServicesAccountDeployment(model.Name)
                : _cognitiveServiceAccount.GetCognitiveServicesAccountDeployments().CreateOrUpdate(WaitUntil.Completed, model.Name, deploymentData).Value;
            return modelDeployment;
        }

        private void CreateCognitiveServicesAccountIfNotExists(ArmClient armClient, ResourceGroupResource resourceGroup)
        {
            var csaData = new CognitiveServicesAccountData(Location);
            csaData.Kind = "OpenAI";
            csaData.Sku = new CognitiveServicesSku("S0");
            csaData.Properties = new CognitiveServicesAccountProperties();
            csaData.Properties.CustomSubDomainName = SubDomain;
            try
            {
                _cognitiveServiceAccount = resourceGroup.GetCognitiveServicesAccounts().Exists(CognitiveServicesAccountName)
                    ? resourceGroup.GetCognitiveServicesAccounts().Get(CognitiveServicesAccountName)
                    : resourceGroup.GetCognitiveServicesAccounts().CreateOrUpdate(WaitUntil.Completed, CognitiveServicesAccountName, csaData).Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 409)
            {
                var deletedAccountId = CognitiveServicesDeletedAccountResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, Location, ResourceGroupName, CognitiveServicesAccountName);
                var deletedAccount = armClient.GetCognitiveServicesDeletedAccountResource(deletedAccountId);
                deletedAccount.Delete(WaitUntil.Completed);
                _cognitiveServiceAccount = resourceGroup.GetCognitiveServicesAccounts().CreateOrUpdate(WaitUntil.Completed, CognitiveServicesAccountName, csaData).Value;
            }
        }

        private static ResourceGroupResource CreateResourceGroupIfNotExists(SubscriptionResource subscription)
        {
            var rgData = new ResourceGroupData(Location);
            rgData.Tags.Add("DeleteAfter", DateTime.Now.AddDays(2).ToString("MM/dd/yyyy hh:mm:sszzz"));
            var resourceGroup = subscription.GetResourceGroups().Exists(ResourceGroupName)
                ? subscription.GetResourceGroup(ResourceGroupName)
                : subscription.GetResourceGroups().CreateOrUpdate(WaitUntil.Completed, ResourceGroupName, rgData).Value;
            return resourceGroup;
        }

        public string DeploymentId { get; private set; }
        public string EmbeddingsDeploymentId { get; private set; }

        protected OpenAIClient GetClient() => InstrumentClient(
            new OpenAIClient(
                new Uri(_endpoint),
                new AzureKeyCredential(_key),
                InstrumentClientOptions(new OpenAIClientOptions(OpenAIClientOptions.ServiceVersion.V2022_06_01_Preview))));

        protected OpenAIClient GetClientWithToken() => InstrumentClient(
            new OpenAIClient(
                new Uri(_endpoint),
                TestEnvironment.Credential,
                InstrumentClientOptions(new OpenAIClientOptions(OpenAIClientOptions.ServiceVersion.V2022_06_01_Preview))));
    }
}

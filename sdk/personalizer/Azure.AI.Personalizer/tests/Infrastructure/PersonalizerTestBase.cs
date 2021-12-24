// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Rl.Net;

namespace Azure.AI.Personalizer.Tests
{
    public abstract class PersonalizerTestBase : RecordedTestBase<PersonalizerTestEnvironment>
    {
        public static bool IsTestTenant = false;

        public PersonalizerTestBase(bool isAsync): base(isAsync)
        {
            // TODO: Compare bodies again when https://github.com/Azure/azure-sdk-for-net/issues/22219 is resolved.
            Matcher = new RecordMatcher(compareBodies: false);
            Sanitizer = new PersonalizerRecordedTestSanitizer();
        }

        protected async Task<PersonalizerClient> GetPersonalizerClientAsync(bool isSingleSlot = false, bool isLocalInference = false)
        {
            //string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            //string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            string endpoint = isSingleSlot ? "https://autoopte2etest3.ppe.cognitiveservices.azure.com" : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? "{personalizerApiKey}" : TestEnvironment.MultiSlotApiKey;
            PersonalizerAdministrationClient adminClient = GetAdministrationClient(isSingleSlot);
            if (!isSingleSlot)
            {
                await EnableMultiSlot(adminClient);
            }
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerClient personalizerClient = null;
            if (isLocalInference)
            {
                Configuration config = new Configuration();

                // configure the personalizer loop
                config["appid"] = "appId1";

                // set up the model
                config["model.source"] = "FILE_MODEL_DATA";
                config["model_file_loader.file_name"] = "modelfile.data";
                config["model.backgroundrefresh"] = "false";

                config["interaction.http.api.host"] = "https://{personalizerEndPoint}/personalizer/v1.1-preview.2/logs/interactions";
                config["observation.http.api.host"] = "https://{personalizerEndPoint}/personalizer/v1.1-preview.2/logs/observations";
                config["http.api.key"] = "{personalizerApiKey}";

                config["InitialCommandLine"] = "--cb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::";
                config["InitialExplorationEpsilon"] = "1";
                config["LearningMode"] = "Online";
                config["ProtocolVersion"] = "2";
                config["LearningMode"] = "Online";
                config["observation.sender.implementation"] = "OBSERVATION_HTTP_API_SENDER";
                config["interaction.sender.implementation"] = "INTERACTION_HTTP_API_SENDER";

                personalizerClient = new PersonalizerClient(new Uri(endpoint), credential, true, config, options);
            }
            else
            {
                personalizerClient = new PersonalizerClient(new Uri(endpoint), credential, options);
            }

            personalizerClient = InstrumentClient(personalizerClient);
            return personalizerClient;
        }

        protected PersonalizerAdministrationClient GetAdministrationClient(bool isSingleSlot = false)
        {
            //string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            //string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            string endpoint = isSingleSlot ? "https://autoopte2etest3.ppe.cognitiveservices.azure.com" : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? "{personalizerApiKey}" : TestEnvironment.MultiSlotApiKey;
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerAdministrationClient personalizerAdministrationClient = new PersonalizerAdministrationClient(new Uri(endpoint), credential, options);
            personalizerAdministrationClient = InstrumentClient(personalizerAdministrationClient);
            return personalizerAdministrationClient;
        }

        private async Task EnableMultiSlot(PersonalizerAdministrationClient adminClient)
        {
            PersonalizerServiceProperties properties = await adminClient.GetPersonalizerPropertiesAsync();
            properties.IsAutoOptimizationEnabled = false;
            await adminClient.UpdatePersonalizerPropertiesAsync(properties);
            await Delay(30000);
            await adminClient.UpdatePersonalizerPolicyAsync(new PersonalizerPolicy("multiSlot", "--ccb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::"));
            //sleep 30 seconds to allow settings to propagate
            await Delay(30000);
        }
    }
}

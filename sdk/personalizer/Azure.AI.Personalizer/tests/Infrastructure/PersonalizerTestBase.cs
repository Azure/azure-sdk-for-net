// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Personalizer.Tests
{
    public abstract class PersonalizerTestBase : RecordedTestBase<PersonalizerTestEnvironment>
    {
        public static bool IsTestTenant = false;

        public PersonalizerTestBase(bool isAsync): base(isAsync)
        {
            Sanitizer = new PersonalizerRecordedTestSanitizer();
        }

        protected async Task<PersonalizerClient> GetPersonalizerClientAsync(bool isSingleSlot = false)
        {
            string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            PersonalizerAdministrationClient adminClient = await GetPersonalizerAdministrationClientAsync(false);
            if (! isSingleSlot)
            {
                await EnableMultiSlot(adminClient);
            }
            await SetTestInstanceProperties(adminClient);
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerClient personalizerClient = new PersonalizerClient(new Uri(endpoint), credential, options);
            personalizerClient = InstrumentClient(personalizerClient);
            return personalizerClient;
        }

        protected async Task<PersonalizerAdministrationClient> GetPersonalizerAdministrationClientAsync(bool isSingleSlot = false, bool shouldSetProperties = true)
        {
            string endpoint = isSingleSlot ? TestEnvironment.SingleSlotEndpoint : TestEnvironment.MultiSlotEndpoint;
            string apiKey = isSingleSlot ? TestEnvironment.SingleSlotApiKey : TestEnvironment.MultiSlotApiKey;
            var credential = new AzureKeyCredential(apiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerAdministrationClient personalizerAdministrationClient = new PersonalizerAdministrationClient(new Uri(endpoint), credential, options);
            personalizerAdministrationClient = InstrumentClient(personalizerAdministrationClient);
            if (shouldSetProperties)
            {
                await SetTestInstanceProperties(personalizerAdministrationClient);
            }
            return personalizerAdministrationClient;
        }

        private async Task EnableMultiSlot(PersonalizerAdministrationClient adminClient)
        {
            PersonalizerServiceProperties properties = await adminClient.GetPersonalizerPropertiesAsync();
            properties.IsAutoOptimizationEnabled = false;
            await adminClient.UpdatePersonalizerPropertiesAsync(properties);
            await adminClient.UpdatePersonalizerPolicyAsync(new PersonalizerPolicy("multiSlot", "--ccb_explore_adf --epsilon 0.2 --power_t 0 -l 0.001 --cb_type mtr -q ::"));
        }

        private async Task SetTestInstanceProperties(PersonalizerAdministrationClient adminClient)
        {
            PersonalizerServiceProperties properties = await adminClient.GetPersonalizerPropertiesAsync();
            TimeSpan eud = new TimeSpan(hours: 0, minutes: 0, seconds: 5);
            if (properties.RewardWaitTime != eud)
            {
                properties.RewardWaitTime = eud;
                await adminClient.UpdatePersonalizerPropertiesAsync(properties);
            }
        }
    }
}

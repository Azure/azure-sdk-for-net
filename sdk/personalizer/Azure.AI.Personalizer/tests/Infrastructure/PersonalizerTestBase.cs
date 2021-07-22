// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        protected PersonalizerClient GetPersonalizerClient()
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerClient personalizerClient = new PersonalizerClient(TestEnvironment.Endpoint, credential, options);
            personalizerClient.RankClient = InstrumentClient(personalizerClient.RankClient);
            personalizerClient.EventsClient = InstrumentClient(personalizerClient.EventsClient);
            personalizerClient.MultiSlotClient = InstrumentClient(personalizerClient.MultiSlotClient);
            personalizerClient.MultiSlotEventsClient = InstrumentClient(personalizerClient.MultiSlotEventsClient);
            return personalizerClient;
        }

        protected PersonalizerManagementClient GetPersonalizerManagementClient()
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerManagementClient personalizerManagementClient = new PersonalizerManagementClient(TestEnvironment.Endpoint, credential, options);
            personalizerManagementClient.LogClient = InstrumentClient(personalizerManagementClient.LogClient);
            personalizerManagementClient.ModelClient = InstrumentClient(personalizerManagementClient.ModelClient);
            personalizerManagementClient.PolicyClient = InstrumentClient(personalizerManagementClient.PolicyClient);
            personalizerManagementClient.EvaluationsClient = InstrumentClient(personalizerManagementClient.EvaluationsClient);
            personalizerManagementClient.ServiceConfigurationClient = InstrumentClient(personalizerManagementClient.ServiceConfigurationClient);
            return personalizerManagementClient;
        }
    }
}

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
            var options = InstrumentClientOptions(new PersonalizerBaseClientOptions());
            PersonalizerClient client = new PersonalizerClient(TestEnvironment.Endpoint, credential, options);
            client.PersonalizerBase = InstrumentClient(client.PersonalizerBase);
            client.MultiSlot = InstrumentClient(client.MultiSlot);
            client.MultiSlotEvents = InstrumentClient(client.MultiSlotEvents);
            client.Model = InstrumentClient(client.Model);
            client.Log = InstrumentClient(client.Log);
            client.Events = InstrumentClient(client.Events);
            client.Evaluations = InstrumentClient(client.Evaluations);
            client.Policy = InstrumentClient(client.Policy);
            client.ServiceConfiguration = InstrumentClient(client.ServiceConfiguration);
            return client;
        }

        internal MultiSlotEventsClient GetMultiSlotEventClient()
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            return new MultiSlotEventsClient(TestEnvironment.Endpoint, credential);
        }

        internal MultiSlotClient GetMultiSlotClient()
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            return new MultiSlotClient(TestEnvironment.Endpoint, credential);
        }
    }
}

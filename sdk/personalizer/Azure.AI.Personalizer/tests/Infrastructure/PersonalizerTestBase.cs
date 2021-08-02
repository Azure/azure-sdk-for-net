// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            PersonalizerClient personalizerClient = new PersonalizerClient(new Uri(TestEnvironment.Endpoint), credential, options);
            personalizerClient = InstrumentClient(personalizerClient);
            return personalizerClient;
        }

        protected PersonalizerAdministrationClient GetPersonalizerAdministrationClient()
        {
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
            var options = InstrumentClientOptions(new PersonalizerClientOptions());
            PersonalizerAdministrationClient PersonalizerAdministrationClient = new PersonalizerAdministrationClient(new Uri(TestEnvironment.Endpoint), credential, options);
            PersonalizerAdministrationClient = InstrumentClient(PersonalizerAdministrationClient);
            return PersonalizerAdministrationClient;
        }
    }
}

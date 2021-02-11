// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the Digital twins client.
    /// </summary>
    [Parallelizable(ParallelScope.Self)]
    public abstract class E2eTestBase : RecordedTestBase<DigitalTwinsTestEnvironment>
    {
        protected static readonly int MaxTries = 1000;

        // Based on testing, the max length of models can be 27 only and works well for other resources as well. This can be updated when required.
        protected static readonly int MaxIdLength = 27;

        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
            Sanitizer = new TestUrlSanitizer();
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            // TODO: set via client options and pipeline instead
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected DigitalTwinsClient GetClient(DigitalTwinsClientOptions options = null)
        {
            if (options == null)
            {
                options = new DigitalTwinsClientOptions();
            }

            return InstrumentClient(
                new DigitalTwinsClient(
                    new Uri(TestEnvironment.DigitalTwinHostname),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(options)));
        }

        protected DigitalTwinsClient GetFakeClient()
        {
            return InstrumentClient(
                new DigitalTwinsClient(
                    new Uri(TestEnvironment.DigitalTwinHostname),
                    new FakeTokenCredential(),
                    InstrumentClientOptions(new DigitalTwinsClientOptions())));
        }

        public async Task<string> GetUniqueModelIdAsync(DigitalTwinsClient dtClient, string baseName)
        {
            return await GetUniqueIdAsync(baseName, (modelId) => dtClient.GetModelAsync(modelId)).ConfigureAwait(false);
        }

        public async Task<string> GetUniqueTwinIdAsync(DigitalTwinsClient dtClient, string baseName)
        {
            return await GetUniqueIdAsync(baseName, (twinId) => dtClient.GetDigitalTwinAsync<BasicDigitalTwin>(twinId)).ConfigureAwait(false);
        }

        private async Task<string> GetUniqueIdAsync(string baseName, Func<string, Task> getResource)
        {
            var id = Recording.GenerateId(baseName, MaxIdLength);

            for (int i = 0; i < MaxTries; ++i)
            {
                try
                {
                    await getResource(id).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    return id;
                }
                id = Recording.GenerateId(baseName, MaxIdLength);
            }

            throw new Exception($"Unique Id could not be found with base {baseName}");
        }

        protected string GetRandom()
        {
            return Recording.GenerateId();
        }

        // This method is used as a helper method to accommodate for the lag on the service side between creating a new
        // model and creating a digital twin that implements this model. The work around is to list the model(s) after
        // creating them in order to accommodate for that lag. Once service side investigates and comes up with a solution,
        // there is no need to list the models after creating them.
        protected async Task CreateAndListModelsAsync(DigitalTwinsClient client, List<string> lists)
        {
            await client.CreateModelsAsync(lists).ConfigureAwait(false);

            // list the models
            AsyncPageable<DigitalTwinsModelData> models = client.GetModelsAsync();
            await foreach (DigitalTwinsModelData model in models)
            {
                Console.WriteLine($"{model.Id}");
            }
        }
    }
}

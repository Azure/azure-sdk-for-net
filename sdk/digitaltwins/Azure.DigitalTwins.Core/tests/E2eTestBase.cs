// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
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
        protected static readonly int MaxTries = 10;

        // Based on testing, the max length of models can be 27 only and works well for other resources as well. This can be updated when required.
        protected static readonly int MaxIdLength = 27;

        public E2eTestBase(bool isAsync)
         : base(isAsync, TestSettings.Instance.TestMode)
        {
        }

        public E2eTestBase(bool isAsync, RecordedTestMode testMode)
           : base(isAsync, testMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            TestDiagnostics = false;

            // TODO: set via client options and pipeline instead
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected DigitalTwinsClient GetClient()
        {
            return InstrumentClient(
                new DigitalTwinsClient(
                    new Uri(TestEnvironment.DigitalTwinHostname),
                    TestEnvironment.Credential,
                    Recording.InstrumentClientOptions(new DigitalTwinsClientOptions())));
        }

        protected DigitalTwinsClient GetFakeClient()
        {
            return InstrumentClient(
                new DigitalTwinsClient(
                    new Uri(TestEnvironment.DigitalTwinHostname),
                    new FakeTokenCredential(),
                    Recording.InstrumentClientOptions(new DigitalTwinsClientOptions())));
        }

        public async Task<string> GetUniqueModelIdAsync(DigitalTwinsClient dtClient, string baseName)
        {
            return await GetUniqueIdAsync(baseName, (modelId) => dtClient.GetModelAsync(modelId)).ConfigureAwait(false);
        }

        public async Task<string> GetUniqueTwinIdAsync(DigitalTwinsClient dtClient, string baseName)
        {
            return await GetUniqueIdAsync(baseName, (twinId) => dtClient.GetDigitalTwinAsync(twinId)).ConfigureAwait(false);
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
    }
}

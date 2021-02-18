// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ModelsRepoRecordedTestBase : RecordedTestBase<ModelsRepoTestEnvironment>
    {
        protected const string TestModeEnvVariable = "AZURE_TEST_MODE";

        protected static RecordedTestMode TestMode => (RecordedTestMode)Enum.Parse(
            typeof(RecordedTestMode),
            Environment.GetEnvironmentVariable(TestModeEnvVariable));

        public ModelsRepoRecordedTestBase(bool isAsync) : base(isAsync, TestMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected ModelsRepoClient GetClient(ModelsRepoTestBase.ClientType clientType, ModelsRepoClientOptions options = null)
        {
            if (options == null)
            {
                options = new ModelsRepoClientOptions();
            }

            return
                clientType == ModelsRepoTestBase.ClientType.Local
                ? InstrumentClient(
                    new ModelsRepoClient(
                        new Uri(ModelsRepoTestBase.TestLocalModelRepository),
                        InstrumentClientOptions(options)))
                : InstrumentClient(
                    new ModelsRepoClient(
                        new Uri(ModelsRepoTestBase.TestRemoteModelRepository),
                        InstrumentClientOptions(options)));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class ModelsRepositoryRecordedTestBase : RecordedTestBase<ModelsRepositoryTestEnvironment>
    {
        protected const string TestModeEnvVariable = "AZURE_TEST_MODE";

        protected static RecordedTestMode TestMode => (RecordedTestMode)Enum.Parse(
            typeof(RecordedTestMode),
            Environment.GetEnvironmentVariable(TestModeEnvVariable) ?? "Playback");

        public ModelsRepositoryRecordedTestBase(bool isAsync) : base(isAsync, TestMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected ModelsRepositoryClient GetClient(ModelsRepositoryTestBase.ClientType clientType, ModelsRepositoryClientOptions options = default)
        {
            if (options == null)
            {
                options = new ModelsRepositoryClientOptions();
            }

            return
                clientType == ModelsRepositoryTestBase.ClientType.Local
                    ? InstrumentClient(
                        new ModelsRepositoryClient(
                            new Uri(ModelsRepositoryTestBase.TestLocalModelRepository),
                            InstrumentClientOptions(options)))
                    : InstrumentClient(
                        new ModelsRepositoryClient(
                            new Uri(ModelsRepositoryTestBase.TestRemoteModelRepository),
                            InstrumentClientOptions(options)));
        }
    }
}
